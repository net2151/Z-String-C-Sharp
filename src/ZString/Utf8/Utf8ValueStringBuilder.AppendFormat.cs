﻿using System;

namespace Cysharp.Text
{
    public ref partial struct Utf8ValueStringBuilder
    {
        public void AppendFormat<T0>(ReadOnlySpan<char> format, T0 arg0)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0>(ReadOnlySpan<char> format, T0 arg0)
        {
            AppendFormat(format, arg0);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1>(ReadOnlySpan<char> format, T0 arg0, T1 arg1)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1>(ReadOnlySpan<char> format, T0 arg0, T1 arg1)
        {
            AppendFormat(format, arg0, arg1);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2)
        {
            AppendFormat(format, arg0, arg1, arg2);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 14:
                            {
                                if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            AppendNewLine();
        }

        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.Slice(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.Slice(i));
                    copyFrom = indexParse.LastIndex + 1;
                    i = indexParse.LastIndex;
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 14:
                            {
                                if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 15:
                            {
                                if (!FormatterCache<T15>.TryFormatDelegate(arg15, buffer.AsSpan(index), out var written, default))
                                {
                                    Grow();
                                    if (!FormatterCache<T15>.TryFormatDelegate(arg15, buffer.AsSpan(index), out written, default))
                                    {
                                        ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.Slice(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        public void AppendFormatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ReadOnlySpan<char> format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            AppendNewLine();
        }

    }
}