using System;
using System.Collections.Generic;
using System.Globalization;

namespace MultibaseCalculator
{
    public static class BaseConverter
    {
        private const int MinRadix = 2;
        private const int MaxRadix = 36;

        private const ushort CellIsUsed = 2;
        private const ushort CellIsConverted = 1;
        private const ushort CellIsUnused = 0;
        private static readonly char[][] PriorizedOperators = {new[] {'^'}, new[] {'*', '/'}, new[] {'+', '-'}};

        private static readonly char[] RadixDigits =
        {
            '0', '1', '2', '3', '4', '5',
            '6', '7', '8', '9', 'a', 'b',
            'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z'
        };

        public static readonly char[] AllOperators = {'^', '+', '-', '*', '/'};

        public static string ConvertFromDecimalFrac(double frac, int radix)
        {
            const int epsDigits = 12;

            var buf = new char[epsDigits];
            int charPos = 0;
            for (; charPos < epsDigits; charPos++)
            {
                frac *= radix;
                var integer = (int) Math.Floor(frac);
                buf[charPos] = RadixDigits[integer];
                frac -= integer;
            }

            return String.Concat('.', new string(buf, 0, charPos));
        }

        public static string ConvertFromDecimal(double d, int radix)
        {
            if (radix == 10)
            {
                return d.ToString(CultureInfo.InvariantCulture);
            }
            if (radix < MinRadix || radix > MaxRadix)
            {
                throw new ArgumentException("Wrong radix number");
            }

            var i = (int) Math.Floor(d);
            double frac = d - i;


            var bufInt = new char[65];
            int charPosInt = 64;
            bool negative = (i < 0);

            if (!negative)
            {
                i = -i;
            }

            while (i <= -radix)
            {
                bufInt[charPosInt--] = RadixDigits[-(i%radix)];
                i = i/radix;
            }
            bufInt[charPosInt] = RadixDigits[-i];

            if (negative)
            {
                bufInt[--charPosInt] = '-';
            }

            var sResult = new string(bufInt, charPosInt, (65 - charPosInt));
            Console.WriteLine(@"converted back int part: " + Math.Floor(d) + @"->" + sResult);
            if (!(Math.Abs(frac) > Double.Epsilon)) return sResult;

            string sFrac = ConvertFromDecimalFrac(frac, radix);
            Console.WriteLine(@"converted back frac part:" + frac + @"->" + sFrac);

            return RemoveTailingZeros(string.Concat(sResult, sFrac));
        }

        public static double ConvertToDecimalFrac(string s, int radix)
        {
            s = string.Concat(Reverse(s), '0');

            double result = 0;
            bool negative = false;
            int i = 0;

            if (s.Length > 0)
            {
                char firstChar = s[0];
                if (firstChar < '0')
                {
                    // Possible leading "-"
                    if (firstChar == '-')
                    {
                        negative = true;
                    }
                    else
                        throw new Exception(s);

                    if (s.Length == 1) // Cannot have lone "-"
                        throw new Exception(s);
                    i++;
                }
                while (i < s.Length)
                {
                    // Accumulating negatively avoids surprises near MAX_VALUE
                    // FIXME WARNING!! THIS CODE WORKS ONLY FOR SUBDECIMAL DIGIT
                    double digit = Char.GetNumericValue(s[i++]);
                    result /= radix;
                    result -= digit;
                }
            }
            else
            {
                throw new Exception(s);
            }
            return negative ? result : -result;
        }

        public static double ConvertToDecimal(string s, int radix)
        {
            if (radix == 10)
            {
                return Double.Parse(s);
            }

            if (0 <= s.IndexOf('.'))
            {
                return ConvertToDecimal(IntPart(s), radix) + ConvertToDecimalFrac(FracPart(s), radix);
            }


            double result = 0;
            bool negative = false;
            int i = 0;

            if (s.Length > 0)
            {
                char firstChar = s[0];
                if (firstChar < '0')
                {
                    // Possible leading "-"
                    if (firstChar == '-')
                    {
                        negative = true;
                    }
                    else
                        throw new Exception(s);

                    if (s.Length == 1) // Cannot have lone "-"
                        throw new Exception(s);
                    i++;
                }
                while (i < s.Length)
                {
                    // Accumulating negatively avoids surprises near MAX_VALUE
                    // FIXME WARNING!! THIS CODE WORKS ONLY FOR SUBDECIMAL DIGIT
                    double digit = Char.GetNumericValue(s[i++]);
                    result *= radix;
                    result -= digit;
                }
            }
            else
            {
                throw new Exception(s);
            }
            return negative ? result : -result;
        }

        public static string RemoveTailingZeros(string s)
        {
            if (s.IndexOf('.') == -1)
            {
                return s;
            }
            int newLength = s.Length - 1;
            while (newLength > 1 && s[newLength] == '0')
            {
                newLength--;
            }
            return s.Substring(0, newLength + 1);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string IntPart(string d)
        {
            int dot = d.IndexOf('.');
            return dot == -1 ? d : dot == 0 ? "0" : d.Substring(0, dot);
        }

        public static string FracPart(string d)
        {
            int dot = d.IndexOf('.');
            return dot == -1 ? "0" : dot == d.Length - 1 ? "0" : d.Substring(dot + 1);
        }

        public static string ConvertFromTo(string value, int from, int to)
        {
            return ConvertFromDecimal(ConvertToDecimal(value, from), to);
        }
    }
}