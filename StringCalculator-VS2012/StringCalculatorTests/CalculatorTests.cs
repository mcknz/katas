using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestEmptyStringReturnsZero()
        {
            //Assert
            Assert.AreEqual(0, GetAddResult(""));
        }

        [TestMethod]
        public void TestOneStringNumberReturnsNumberOne()
        {
            Assert.AreEqual(1, GetAddResult("1"));
        }

        [TestMethod]
        public void TestTwoNumbersWithCommaReturnsSum()
        {
            Assert.AreEqual(3, GetAddResult("1,2"));
        }

        [TestMethod]
        public void TestManyNumbersWithCommaReturnsSum()
        {
            Assert.AreEqual(21, GetAddResult("1,2,4,5,9,0"));
        }

        [TestMethod]
        public void TestNumbersWithNewLineAndCommaReturnsSum()
        {
            Assert.AreEqual(21, GetAddResult("1\n2,4,5,9,0"));
        }

        [TestMethod]
        public void TestNumbersWithCustomDelimiter()
        {
            Assert.AreEqual(3, GetAddResult("//;\n1;2"));
        }

        [TestMethod]
        public void TestNumbersOver1000DontCount()
        {
            Assert.AreEqual(2, GetAddResult("1001,2"));
        }

        [TestMethod]
        public void TestMultiLengthDelimiter()
        {
            Assert.AreEqual(6, GetAddResult("//[***]\n1***2***3"));
        }

        [TestMethod]
        public void TestMultipleCustomDelimiter()
        {
            Assert.AreEqual(7, GetAddResult("//[***][^^]\n1***2***3^^1"));
        }

        [TestMethod]
        public void TestMultipleCustomDelimiter2()
        {
            Assert.AreEqual(6, GetAddResult("//[*][%]\n1*2%3"));
        }        

        private int GetAddResult(string input)
        {
            return new Calculator().Add(input);            
        }
    }
}
