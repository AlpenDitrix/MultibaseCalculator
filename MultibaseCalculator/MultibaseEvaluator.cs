using System;
using System.Collections.Generic;
using System.Globalization;

namespace MultibaseCalculator
{
    public class MultibaseEvaluator
    {
        private const int MinRadix = 2;
        private const int MaxRadix = 36;

        private const ushort CellIsUsed = 2;
        private const ushort CellIsConverted = 1;
        private const ushort CellIsUnused = 0;
        private static readonly char[][] PriorizedOperators = {new[] {'^'}, new[] {'*', '/'}, new[] {'+', '#'}};

        private static readonly char[] RadixDigits =
        {
            '0', '1', '2', '3', '4', '5',
            '6', '7', '8', '9', 'a', 'b',
            'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z'
        };

        public readonly char[] AllOperators = {'^', '+', '-', '*', '/'};

        public MultibaseEvaluator(int radix = 10)
        {
            if (radix < 2 || radix > 36)
            {
                throw new ArgumentOutOfRangeException("radix: " + radix);
            }
            Radix = radix;
        }

        public int Radix { get; private set; }


        public string EvaluateWithBrackets(string infixInputString)
        {
            return
                RemoveTailingZeros(EvaluatePlain(CustomSplit(AllOperators, RemoveSurroundingBrackets(infixInputString))));
        }

        private string RemoveSurroundingBrackets(string s)
        {
            string zero = "0";

            if (s.Length == 0)
            {
                return zero;
            }
            if (s[0] != '(' || s[s.Length - 1] != ')')
            {
                return s;
            }
            var bracketCounter = new int[s.Length];
            int indexer = 1;
            var indexers = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    bracketCounter[i] = indexer;
                    indexers.Push(indexer++);
                }
                else if (s[i] == ')')
                {
                    bracketCounter[i] = -indexers.Pop();
                }
            }
            int k = -1;
            while (bracketCounter[++k] != 0 && bracketCounter[k] == -bracketCounter[bracketCounter.Length - 1 - k])
            {
                if (k == bracketCounter.Length - 1 - k)
                {
                    return s[k].ToString(CultureInfo.InvariantCulture);
                }
                if (k == bracketCounter.Length - 1 - k)
                {
                    return zero;
                }
            }
            return s.Substring(k, s.Length - 2*k);
        }

        public static object[] CustomSplit(char[] delimeters, string s)
        {
            bool leadingMinus = s[0] == '-';
            if (s[0] == '-' || s[0] == '+')
            {
                s = s.Substring(1);
            }

            int prevStart = 0;
            var list = new List<object>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    int end = FindClosingBracketFrom(i, s);
                    i = end + 1; //skip brackets to next operator
                    if (i < s.Length)
                    {
                        //check if that brackets was trailing or not (s2 example)
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (char delimeter in delimeters)
                {
                    if (s[i] != delimeter) continue;
                    list.Add(s.Substring(prevStart, i - prevStart));
                    list.Add(s.Substring(i, 1));
                    prevStart = i + 1;
                }
            }
            list.Add(s.Substring(prevStart));
            //следующее говно сделано для того, чтобы работали отрицательные промежуточные числа и проверка if(s[0] == '-') не агрилась на "-123"
            object[] result = list.ToArray();
            if (leadingMinus)
            {
                result[0] = String.Concat("-", result[0]);
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Equals("-"))
                {
                    result[i] = "#";
                }
            }
            return result;
        }


        private string EvaluatePlain(object[] splitted)
        {
            var cellState = new ushort[splitted.Length];

            foreach (var operators in PriorizedOperators)
            {
                int i = -1;
                while (++i < splitted.Length)
                {
                    Print(splitted, cellState, i);
                    FindAndEvaluateOperators(operators, splitted, i, cellState);
                }
            }

            for (int k = 0; k < cellState.Length; k++)
            {
                switch (cellState[k])
                {
                    case CellIsUsed:
                        continue;
                    case CellIsConverted: // convert back
                        return ConvertFromDecimal((double) splitted[k]);
                    case CellIsUnused: // input was just a number without operators
                        return splitted[k].ToString();
                    default:
                        throw new Exception("Unknown cell state");
                }
            }
            throw new Exception("Something gone wrong");
        }

        private void FindAndEvaluateOperators(char[] operators, object[] splitted, int i, ushort[] used)
        {
            if (used[i] == CellIsUsed)
            {
                return;
            }
            foreach (char op in operators)
            {
                if (splitted[i].ToString()[0] != op) continue;

                double left = 0;
                if (i > 0) // check for leading unary operators
                {
                    int l = i;
                    while (used[--l] == CellIsUsed)
                    {
                    }
                    left = GetOrAndConvert(used, splitted, l);
                    used[l] = CellIsUsed;
                }
                int r = i;
                while (used[++r] == CellIsUsed)
                {
                }
                double right = GetOrAndConvert(used, splitted, r);
                used[r] = CellIsUsed;

                splitted[i] = EvaluateOperator(left, op, right); //evaluate as decimal
                used[i] = CellIsConverted;
                return;
            }
        }

        private double GetOrAndConvert(ushort[] used, object[] from, int index)
        {
            return used[index] == 1 ? (double) @from[index] : ConvertToDecimal(@from[index].ToString());
        }

        private double EvaluateOperator(double left, char op, double right)
        {
            switch (op)
            {
                case '+':
                    return left + right;
                case '#':
                    return left - right;
                case '*':
                    return left*right;
                case '/':
                    if (Math.Abs(right) > 0) // epsilon = 0
                    {
                        return left/right;
                    }
                    throw new DivideByZeroException(string.Concat(left, "/", right));
                case '^':
                    return Math.Pow(left, right);
                default:
                    throw new ArgumentException("Unsupported operator: " + op);
            }
        }


        public string ConvertFromDecimalFrac(double frac)
        {
            const int epsDigits = 12;

            var buf = new char[epsDigits];
            int charPos = 0;
            for (; charPos < epsDigits; charPos++)
            {
                frac *= Radix;
                var integer = (int) Math.Floor(frac);
                buf[charPos] = RadixDigits[integer];
                frac -= integer;
            }

            return String.Concat('.', new string(buf, 0, charPos));
        }

        public string ConvertFromDecimal(double d)
        {
            if (Radix == 10)
            {
                return d.ToString(CultureInfo.InvariantCulture);
            }
            if (Radix < MinRadix || Radix > MaxRadix)
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

            while (i <= -Radix)
            {
                bufInt[charPosInt--] = RadixDigits[-(i%Radix)];
                i = i/Radix;
            }
            bufInt[charPosInt] = RadixDigits[-i];

            if (negative)
            {
                bufInt[--charPosInt] = '-';
            }

            var sResult = new string(bufInt, charPosInt, (65 - charPosInt));
            Console.WriteLine(@"converted back int part: " + Math.Floor(d) + @"->" + sResult);
            if (!(Math.Abs(frac) > Double.Epsilon)) return sResult;

            string sFrac = ConvertFromDecimalFrac(frac);
            Console.WriteLine(@"converted back frac part:" + frac + @"->" + sFrac);

            return string.Concat(sResult, sFrac);
        }

        public double ConvertToDecimalFrac(string s)
        {
            if (Radix == 10)
            {
                string dec = string.Concat("0", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, s);
                return Double.Parse(dec);
            }
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
                    result /= Radix;
                    result -= digit;
                }
            }
            else
            {
                throw new Exception(s);
            }
            return negative ? result : -result;
        }

        public double ConvertToDecimal(string s)
        {
            if (s[0] == '(')
            {
                s = EvaluateWithBrackets(s.Substring(1, s.Length - 2));
            } //may be removed for using out that class

            if (0 <= s.IndexOf('.'))
            {
                return ConvertToDecimal(IntPart(s)) + ConvertToDecimalFrac(FracPart(s));
            }
            //that check used only for Evaluator needs

            if (Radix == 10)
            {
                return Double.Parse(s);
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
                    result *= Radix;
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

        public static int FindClosingBracketFrom(int start, string s)
        {
            int level = 1;
            for (int i = start + 1; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    level++;
                }
                if (s[i] == ')')
                {
                    level--;
                }
                if (level == 0)
                {
                    return i;
                }
            }
            throw new Exception("Wrong bracket structure");
        }

        private static void Print(object[] splitted, ushort[] used, int i)
        {
            for (int k = 0; k < splitted.Length; k++)
            {
                if (used[k] != CellIsUsed)
                {
                    //                    Console.Write(op+": ");
                    Console.Write(k == i ? String.Concat("{", splitted[k], "}") : splitted[k]);
                    Console.Write(@" ");
                }
            }
            Console.WriteLine();
        }
    }
}