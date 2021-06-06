using Calculator.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Test
{
    [TestClass]
    public class UnitTestCalculator
    {
        StringCalculator objSC = new StringCalculator();

        //It tests normal valid input
        [TestMethod]
        public void TestString()
        {
            string number = "1,2";
            string expectedResult = "3";
            string actualResult = objSC.StringAdd(number).ToString();
            Assert.AreEqual<string>(expectedResult, actualResult);
        }

        //It tests Empty input
        [TestMethod]
        public void TestEmptyString()
        {
            string number = String.Empty;
            string expectedResult = "0";
            string actualResult = objSC.StringAdd(number).ToString();
            Assert.AreEqual<string>(expectedResult, actualResult);
        }

        //It tests NULL input
        [TestMethod]
        public void TestNullString()
        {
            string number = null;
            string expectedResult = "0";
            string actualResult = objSC.StringAdd(number).ToString();
            Assert.AreEqual<string>(expectedResult, actualResult);
        }

        //It tests input with new line 
        [TestMethod]
        public void TestNewLine()
        {
            string number = "1\n2,3";
            string expectedResult = "6";
            string actualResult = objSC.StringAdd(number).ToString();
            Assert.AreEqual<string>(expectedResult, actualResult);
        }

        //It tests input with different delimiters
        [TestMethod]
        public void TestNewDelimiters()
        {
            string number = "//;\n1;2";
            string expectedResult = "3";
            string actualResult = objSC.StringAdd(number).ToString();
            Assert.AreEqual<string>(expectedResult, actualResult);
        }

        //It tests input with Negative numbers and throw exception 
        [TestMethod]
        [ExpectedException(typeof(FormatException), "negatives not allowed")]
        public void TestNegative()
        {
            string number = "-1,-2";
            string expectedResult = "negatives not allowed " + number;
            string actualResult = objSC.StringAdd(number).ToString();
        }
    }
}
