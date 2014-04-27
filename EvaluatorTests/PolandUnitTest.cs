using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultibaseCalculator;

namespace EvaluatorTests
{
    [TestClass]
    public class PolandUnitTest
    {
        private static void ParsingAssert(string expected, string input)
        {
            Assert.AreEqual(expected, ReversePolandNotation.ParseExpression(input));
        }

        [TestMethod]
        public void InfixToRp()
        {
            ParsingAssert("3 4 +", "3+4");  
            ParsingAssert("7 2 3 * -", "7-2*3");
            ParsingAssert("2 1 + #", "-(2+1)");
            ParsingAssert("1 2 + 4 * 3 +", "(1+2)*4+3");
            ParsingAssert("3 4 2 * 1 5 - 2 ^ / +", "3+4*2/(1-5)^2");
            ParsingAssert("5 3 # 8 + *", "5*(-3+8)");
            ParsingAssert("5 1 2 + 4 * + 3 -", "5+((1+2)*4)-3");
        }

        private static void EvaluatingRawAssert(double expected, string raw)
        {
            Assert.AreEqual(expected, ReversePolishComputer.ComputeRaw(raw));
        }

        [TestMethod]
        public void RpComputeRaw()
        {
            EvaluatingRawAssert(7, "3+4");
            EvaluatingRawAssert(1, "7-2*3");
            EvaluatingRawAssert(-3, "-(2+1)");
            EvaluatingRawAssert(15, "(1+2)*4+3");
            EvaluatingRawAssert(3.5, "3+4*2/(1-5)^2");
            EvaluatingRawAssert(25, "5*(-3+8)");
            EvaluatingRawAssert(2, "(((1+3)/(16-14)^1))");
            EvaluatingRawAssert(14, "5+((1+2)*4)-3");
        }

        private static void EvaluatingAssert(double expected, string rpnString)
        {
            Assert.AreEqual(expected, ReversePolishComputer.Compute(rpnString));
        }

        [TestMethod]
        public void RpCompute()
        {
            EvaluatingAssert(7, "3 4 +");
            EvaluatingAssert(1, "7 2 3 * -");
            EvaluatingAssert(15, "1 2 + 4 * 3 +");
            EvaluatingAssert(3.5, "3 4 2 * 1 5 - 2 ^ / +");
            EvaluatingAssert(25, "5 3 # 8 + *");
            EvaluatingAssert(14, "5 1 2 + 4 * + 3 -");
        }

        
    }
}
