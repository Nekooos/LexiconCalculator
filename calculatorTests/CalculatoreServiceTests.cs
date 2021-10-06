
using CalculatorProgram.Service;
using CalculatorTests;
using System;
using System.Collections.Generic;
using Xunit;

namespace CalculatorTestsXunit
{
    public class CalculatorTests
    {
        private CalculatorService calculatorService;

        public CalculatorTests()
        {
            calculatorService = new CalculatorService();
        }

        [Fact]
        public void CombineCharsToNumberStringsTest()
        {
            string input = "34+42*55/4";
            List<String> result = calculatorService.StringToNumberStrings(input);

            List<String> expectedList = new List<String>() { "34", "+", "42", "*", "55", "/", "4" };

            Assert.Equal(expectedList, result);
        }

        [Theory]
        [MemberData(nameof(CalculatorTestData.DivisionZeroData), MemberType = typeof(CalculatorTestData))]
        public void DivisionZeroTest(List<String> inputList, String expected)
        {
            String result = calculatorService.CalculateByOperator(inputList);

            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Invalid input list Throws FormatException")]
        public void invalidListInput()
        {
            List<String> inputList = new List<String>() { "b", "+", "5" };

            Assert.Throws<FormatException>(() => calculatorService.CalculateByOperator(inputList));
        }

        [Fact(DisplayName = "Empty list Throws FormatException")]
        public void emptyListInput()
        {
            List<String> inputList = new List<String>();

            String result = calculatorService.CalculateByOperator(inputList);

            Assert.Equal("result: 0", result);
        }

        [Fact]
        public void MultiplyAndDivsionBeforeSubtractionAndAdditionTest()
        {
            List<String> inputList = new List<String>() {"3", "+", "5", "-", "10", "*", "3", "/", "2" };

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "result: -7";

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(CalculatorTestData.AdditionData), MemberType = typeof(CalculatorTestData))]
        public void AdditionTest(List<String> inputList, String expected) {
            string result = calculatorService.CalculateByOperator(inputList);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(CalculatorTestData.SubtractionData), MemberType = typeof(CalculatorTestData))]
        public void SubtractionTest(List<String> inputList, String expected)
        {
            String result = calculatorService.CalculateByOperator(inputList);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void MultiplyTest(List<String> inputList, String expected)
        {
            String result = calculatorService.CalculateByOperator(inputList);
 
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivisionTest()
        {
            List<String> inputList = new List<String>() { "10", "/", "2.5", "/", "2" };

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "result: 2";

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new String[] { "5", "+", "5" }, 10),]
        public void overLoadedAddition(String[] calculation, double expected)
        {
            double result = calculatorService.Addition(calculation);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void overLoadedSubtraction()
        {
            String[] calculation = new String[] { "5", "-", "5" };
            double result = calculatorService.Subtraction(calculation);
            double expected = 0;
            Assert.Equal(expected, result);
        }

    public static IEnumerable<object[]> MultiplyData() =>
            new List<object[]>
            {
                new object[] {new List<String>() { "2", "*", "3"}, "result: 6" },
                new object[] {new List<String>() { "2", "*", "3.2"}, "result: 6.4" },
                new object[] {new List<String>() { "4", "*", "2.5", "*", "2" }, "result: 20" }
            };
    }
}
