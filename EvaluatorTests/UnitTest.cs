using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultibaseCalculator;

namespace EvaluatorTests
{
    [TestClass]
    public class UnitTest
    {
//        private readonly MultibaseEvaluator _decimalEvaluator = new MultibaseEvaluator();
//        private readonly MultibaseEvaluator _binaryEvaluator = new MultibaseEvaluator(2);
//
//        [TestMethod]
//        public void ReverseStringTest()
//        {
//            Assert.AreEqual("af4jk3j403ijomrni", MultibaseEvaluator.Reverse("inrmoji304j3kj4fa"));
//        }
//
//        [TestMethod]
//        public void IntPartTest()
//        {
//            Assert.AreEqual("123124122", MultibaseEvaluator.IntPart("123124122.123123"));
//            Assert.AreEqual("123124122", MultibaseEvaluator.IntPart("123124122"));
//            Assert.AreEqual("0", MultibaseEvaluator.IntPart(".123123"));
//        }
//
//        [TestMethod]
//        public void FracPartTest()
//        {
//            Assert.AreEqual("123123", MultibaseEvaluator.FracPart("123124122.123123"));
//            Assert.AreEqual("0", MultibaseEvaluator.FracPart("123124122"));
//            Assert.AreEqual("0", MultibaseEvaluator.FracPart("123123."));
//        }
//        [TestMethod]
//        public void RemoveTailingZerosTest()
//        {
//            Assert.AreEqual("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn", MultibaseEvaluator.RemoveTailingZeros("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn"));
//            Assert.AreEqual("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn0000000000000000", MultibaseEvaluator.RemoveTailingZeros("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn0000000000000000"));
//            Assert.AreEqual("0000j930ngu394ng8n0000000 5g8 ы   .000\nn59h84\\5hn", MultibaseEvaluator.RemoveTailingZeros("0000j930ngu394ng8n0000000 5g8 ы   .000\nn59h84\\5hn"));
//            Assert.AreEqual("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn.000000000000000000000.", MultibaseEvaluator.RemoveTailingZeros("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn.000000000000000000000."));
//            Assert.AreEqual("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn.000000000000000000000.", MultibaseEvaluator.RemoveTailingZeros("0000j930ngu394ng8n0000000 5g8 ы   000\nn59h84\\5hn.000000000000000000000.0000000000000000000000000000"));
//        }
//
//        [TestMethod]
//        public void FindClosingBracketTest()                             
//        {
//            Assert.AreEqual(23,MultibaseEvaluator.FindClosingBracketFrom(0, "(((((((()))(()))()))())))()()()"));
//            Assert.AreEqual(22,MultibaseEvaluator.FindClosingBracketFrom(1, "(((((((()))(()))()))())))()()()"));
//            Assert.AreEqual(19,MultibaseEvaluator.FindClosingBracketFrom(2, "(((((((()))(()))()))())))()()()"));
//            Assert.AreEqual(18,MultibaseEvaluator.FindClosingBracketFrom(3, "(((((((()))(()))()))())))()()()"));
//            Assert.AreEqual(15,MultibaseEvaluator.FindClosingBracketFrom(4, "(((((((()))(()))()))())))()()()"));
//            Assert.AreEqual(10,MultibaseEvaluator.FindClosingBracketFrom(5, "(((((((()))(()))()))())))()()()"));
//            Assert.AreEqual(28,MultibaseEvaluator.FindClosingBracketFrom(27, "(((((((()))(()))()))())))()()()"));
//        }
//
//        [TestMethod]
//        public void JustNumber()
//        {
//            Assert.AreEqual("124141231269874", _decimalEvaluator.EvaluateWithBrackets("124141231269874"));
//            Assert.AreEqual("124141231269874", _decimalEvaluator.EvaluateWithBrackets("(124141231269874)"), "Just a number in the brackets");
//            Assert.AreEqual("1001010111101110101", _binaryEvaluator.EvaluateWithBrackets("1001010111101110101"));
//            Assert.AreEqual("1001010111101110101", _binaryEvaluator.EvaluateWithBrackets("(1001010111101110101)"), "Just a number in the brackets");
//        }
//
//        [TestMethod]
//        public void SimpleOperatorsDecimal()
//        {
//            Assert.AreEqual("3.6", _decimalEvaluator.EvaluateWithBrackets("1.2+2.4"),"Plus");
//            Assert.AreEqual("7", _decimalEvaluator.EvaluateWithBrackets("10-3"),"Minus");
//            Assert.AreEqual("10.6", _decimalEvaluator.EvaluateWithBrackets("2*5.3"),"Production");
//            Assert.AreEqual("17", _decimalEvaluator.EvaluateWithBrackets("34/2"),"Division");
//            Assert.AreEqual("2.5", _decimalEvaluator.EvaluateWithBrackets("5/2"),"Non-integer division");
//            Assert.AreEqual("5", _decimalEvaluator.EvaluateWithBrackets("1/0.2"),"Division on number less than 1");
//            Assert.AreEqual("10460353203", _decimalEvaluator.EvaluateWithBrackets("27^7"));
//            Assert.AreEqual("723156399.703872", _decimalEvaluator.EvaluateWithBrackets("17^7.2"));
//        }
////        Assert.AreEqual("", _decimalEvaluator.EvaluateWithBrackets(""));
//
//        [TestMethod]
//        public void OperatorsPriority()
//        {
//            Assert.AreEqual("128", _decimalEvaluator.EvaluateWithBrackets("2*8^2"), "Involution must be before production");
//
//            Assert.AreEqual("1", _decimalEvaluator.EvaluateWithBrackets("64/8^2"), "Involution must be before division");
//            
//            Assert.AreEqual("65", _decimalEvaluator.EvaluateWithBrackets("1+8^2"), "Involution must be before addition");
//            Assert.AreEqual("5", _decimalEvaluator.EvaluateWithBrackets("1+8/2"), "Divisionion must be before addition");
//            Assert.AreEqual("5", _decimalEvaluator.EvaluateWithBrackets("1+2*2"), "Production must be before addition");
//
//            Assert.AreEqual("-3", _decimalEvaluator.EvaluateWithBrackets("1-2^2"), "Involution must be before subtraction");
//            Assert.AreEqual("-3", _decimalEvaluator.EvaluateWithBrackets("1-8/2"), "Divisionion must be before subtraction");
//            Assert.AreEqual("-3", _decimalEvaluator.EvaluateWithBrackets("1-2*2"), "Production must be before subtraction");
//        }
//
//        [TestMethod]
//        public void BracketsPriority()
//        {
//            Assert.AreEqual("256", _decimalEvaluator.EvaluateWithBrackets("(2*8)^2"), "Brackets must be before production");
//
//            Assert.AreEqual("64", _decimalEvaluator.EvaluateWithBrackets("(64/8)^2"), "Brackets must be before division");
//
//            Assert.AreEqual("81", _decimalEvaluator.EvaluateWithBrackets("(1+8)^2"), "Brackets must be before addition");
//            Assert.AreEqual("4.5", _decimalEvaluator.EvaluateWithBrackets("(1+8)/2"), "Brackets must be before addition");
//            Assert.AreEqual("6", _decimalEvaluator.EvaluateWithBrackets("(1+2)*2"), "Brackets must be before addition");
//
//            Assert.AreEqual("4", _decimalEvaluator.EvaluateWithBrackets("(1-3)^2"), "Brackets must be before subtraction");
//            Assert.AreEqual("-3.5", _decimalEvaluator.EvaluateWithBrackets("(1-8)/2"), "Brackets must be before subtraction");
//            Assert.AreEqual("-2", _decimalEvaluator.EvaluateWithBrackets("(1-2)*2"), "Brackets must be before subtraction");
//        }
//
//        [TestMethod]
//        public void EvaluateDecimal()
//        {
//            Assert.AreEqual("28", _decimalEvaluator.EvaluateWithBrackets("6/3-4+5*6"));
//            Assert.AreEqual("28", _decimalEvaluator.EvaluateWithBrackets("(6/3)-4+(5*6)"));
//            Assert.AreEqual("28", _decimalEvaluator.EvaluateWithBrackets("(6/3)-4+(5*6)"));
//            Assert.AreEqual("31", _decimalEvaluator.EvaluateWithBrackets("(6-2)/4+(5*6)"));
//            Assert.AreEqual("-6", _decimalEvaluator.EvaluateWithBrackets("(12-4)/4*(5-8)"));
//            Assert.AreEqual("140", _decimalEvaluator.EvaluateWithBrackets("((36-12*2)^2-(2*(3-1)))"));
//            Assert.AreEqual("-105", _decimalEvaluator.EvaluateWithBrackets("((36-12*2)^2-(2*(3-1)))/4*(5-8)"));
//        }
//
//        [TestMethod]
//        public void EvaluateBinary()
//        {
//            Assert.AreEqual("-100", _binaryEvaluator.EvaluateWithBrackets("11-111"));
//            Assert.AreEqual("1100", _binaryEvaluator.EvaluateWithBrackets("100100-1100*10"));
//            Assert.AreEqual("100", _binaryEvaluator.EvaluateWithBrackets("10*(11-1)"));
//            Assert.AreEqual("-1000",
//                _binaryEvaluator.EvaluateWithBrackets("((100100-1100*10)-(10*(11-1)))/100*(11-111)"));
//        }
    }
}
