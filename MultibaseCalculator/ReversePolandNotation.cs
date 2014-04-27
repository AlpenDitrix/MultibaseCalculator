using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace MultibaseCalculator
{
    public static class ReversePolandNotation
    {
        private static string ReplacePrefixMinuses(string expr)
        {
            char[] chars = expr.ToCharArray();
            if (chars[0] == '-')
            {
                chars[0] = '#';
            }
            for (int i = 1; i < chars.Length; i++)
            {
                if (chars[i] == '-' && chars[i - 1] == '(')
                {
                    chars[i] = '#';
                }
            }
            return new string(chars);
        }

        public static string ParseExpression(string expr)
        {
            expr = ReplacePrefixMinuses(expr);

            var stack = new Stack<char>();
            var result = new StringBuilder();
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                if (Char.IsDigit(c))
                {
                    int j = i;
                    do
                    {
                        result.Append(expr[j++]);
                    } while (j < expr.Length && Char.IsDigit(expr[j]));
                    result.Append(' ');
                    i = j - 1;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    try
                    {
                        while (stack.Peek() != '(')
                        {
                            result.Append(stack.Pop());
                            result.Append(' ');
                        }
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new WrongBracketStructureException();
                    }
                }
                else if (c == '+' || c == '*' || c == '-' || c == '/' || c == '^' || c == '#')
                {
                    while (stack.Count>0 && A_LessOrEqualPriorThan_B(c, stack.Peek()))
                    {
                        result.Append(stack.Pop());
                        result.Append(' ');
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() != '(')
                {
                    result.Append(stack.Pop());
                    result.Append(' ');
                }
                else
                {
                    throw new WrongBracketStructureException();
                }
            }

            return result.ToString(0, result.Length-1);
        }

        private static bool A_LessOrEqualPriorThan_B(char A, char B)
        {
            if(B=='('){
            return false;}
            switch (A)
            {   case '#':
                    return B == '#';
                case '^':
                    return B == '^' || B == '#';
                case '*':
                case '/':
                    switch (B)
                    {
                        case '+':
                        case '-':
                            return false;
                        default:
                            return true;
                    }
                case '-':
                case '+':
                    return true;
                default : 
                    throw new Exception("Unsupported operator");
            }
        }
    }

    public static class ReversePolishComputer
    {
        public static string ComputeRaw(string rawString)
        {
            return Compute(ReversePolandNotation.ParseExpression(rawString));
        }

        public static string Compute(string rpnString)
        {
            var splitted = rpnString.Split(' ');
            var stack = new Stack<double>();

            foreach (var s in splitted)
            {
                if (s.Equals("#"))
                {
                    stack.Push(-stack.Pop());
                }
                else if (s.Equals("+"))
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (s.Equals("-"))
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    stack.Push(left - right);
                }
                else if (s.Equals("*"))
                {
                    stack.Push(stack.Pop()*stack.Pop());
                }
                else if (s.Equals("/"))
                {
                    var right = stack.Pop();
                    if (Math.Abs(right) < Double.Epsilon)
                    {
                        throw new DivideByZeroException();
                    }
                    var left = stack.Pop();
                    stack.Push(left/right);
                }
                else if (s.Equals("^"))
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    stack.Push(Math.Pow(left, right));
                }
                else // it's a number
                {
                    stack.Push(BaseConverter.ConvertToDecimal(s, CalculatorForm.Radix));
                }
            }
            if (stack.Count != 1)
            {
                throw new Exception("Обнаружена неизвестная ошибка обработки выражения");
            }
            return BaseConverter.ConvertFromDecimal(stack.Pop(), CalculatorForm.Radix);
        }
    }

    public class WrongBracketStructureException : Exception
    {
        public WrongBracketStructureException() : base("В вычисляемом выражении неправильная скобочная структура")
        {
        }
    }
}