﻿using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public ref partial struct Utf16ValueStringBuilder
    {
        delegate bool TryFormat<T>(T value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format);

        const int DefaultBufferSize = 32768; // use 32K default buffer.

        static char newLine1;
        static char newLine2;
        static bool crlf;

        static Utf16ValueStringBuilder()
        {
            var newLine = Environment.NewLine.ToCharArray();
            if (newLine.Length == 1)
            {
                // cr or lf
                newLine1 = newLine[0];
                crlf = false;
            }
            else
            {
                // crlf(windows)
                newLine1 = newLine[0];
                newLine2 = newLine[1];
                crlf = true;
            }
        }

        [ThreadStatic]
        static char[] scratchBuffer;

        char[] buffer;
        int index;

        public int Length => index;
        public ReadOnlySpan<char> AsSpan() => buffer.AsSpan(0, index);

        internal void Init()
        {
            var buf = scratchBuffer;
            if (buf == null)
            {
                buf = scratchBuffer = new char[DefaultBufferSize];
            }

            buffer = buf;
            index = 0;
        }

        public void Dispose()
        {
            if (buffer.Length != DefaultBufferSize)
            {
                ArrayPool<char>.Shared.Return(buffer);
            }
            buffer = null;
            index = 0;
        }

        void TryGrow(int sizeHint)
        {
            if (buffer.Length < index + sizeHint)
            {
                Grow(sizeHint);
            }
        }

        void Grow(int sizeHint = 0)
        {
            var nextSize = buffer.Length * 2;
            if (sizeHint != 0)
            {
                nextSize = Math.Max(nextSize, index + sizeHint);
            }

            var newBuffer = ArrayPool<char>.Shared.Rent(nextSize);

            buffer.CopyTo(newBuffer, 0);
            if (buffer.Length != DefaultBufferSize)
            {
                ArrayPool<char>.Shared.Return(buffer);
            }

            buffer = newBuffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendNewLine()
        {
            if (crlf)
            {
                if (buffer.Length - index < 2) Grow(2);
                buffer[index] = newLine1;
                buffer[index + 1] = newLine2;
                index += 2;
            }
            else
            {
                if (buffer.Length - index < 1) Grow(1);
                buffer[index] = newLine1;
                index += 1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(string value)
        {
            if (buffer.Length - index < value.Length)
            {
                Grow(value.Length);
            }

            value.CopyTo(0, buffer, index, value.Length);
            index += value.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(string value)
        {
            Append(value);
            AppendNewLine();
        }

        public void Append<T>(T value)
        {
            if (!FormatterCache<T>.TryFormatDelegate(value, buffer.AsSpan(index), out var written, default))
            {
                Grow();
                if (!FormatterCache<T>.TryFormatDelegate(value, buffer.AsSpan(index), out written, default))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        public void AppendLine<T>(T value)
        {
            Append(value);
            AppendNewLine();
        }

        // Output

        public bool TryCopyTo(Span<char> destination, out int charsWritten)
        {
            if (destination.Length < index)
            {
                charsWritten = 0;
                return false;
            }

            charsWritten = index;
            buffer.AsSpan(0, index).CopyTo(destination);
            return true;
        }

        public override string ToString()
        {
            return new string(buffer, 0, index);
        }

        // IBufferWriter like interface.

        public Span<char> GetWritableBuffer(int sizeHint = 0)
        {
            if ((buffer.Length - index) < sizeHint)
            {
                Grow(sizeHint);
            }

            return buffer.AsSpan(index);
        }

        public void Advance(int count)
        {
            index += count;
        }

        void ThrowArgumentException(string paramName)
        {
            throw new ArgumentException("Can't format argument.", paramName);
        }

        void ThrowFormatException()
        {
            throw new FormatException("Index (zero based) must be greater than or equal to zero and less than the size of the argument list.");
        }

        static class FormatterCache<T>
        {
            public static TryFormat<T> TryFormatDelegate;
            static FormatterCache()
            {
                var formatter = (TryFormat<T>)CreateFormatter(typeof(T));
                if (formatter == null)
                {
                    if (typeof(T).IsEnum)
                    {
                        formatter = new TryFormat<T>(EnumUtil<T>.TryFormatUtf16);
                    }
                    else
                    {
                        formatter = new TryFormat<T>(TryFormatDefault);
                    }
                }

                TryFormatDelegate = formatter;
            }

            static bool TryFormatDefault(T value, Span<char> dest, out int written, ReadOnlySpan<char> format)
            {
                if (value == null)
                {
                    written = 0;
                    return true;
                }

                var s = value.ToString();

                // also use this length when result is false.
                written = s.Length;
                return s.AsSpan().TryCopyTo(dest);
            }
        }
    }
}