
using CalculatorProgram.Service;
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
            char[] calculationArray = "34+42*55/4".ToCharArray();
            List<String> result = calculatorService.CombineCharsToNumberStrings(calculationArray);

            List<String> expectedList = new List<String>() { "34", "+", "42", "*", "55", "/", "4" };

            Assert.Equal(expectedList, result);
        }

        [Fact]
        public void DivisionZeroTest()
        {
            List<String> inputList = new List<String>() { "3", "+", "5", "-", "10", "*", "3", "/", "0" };

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "Can't divide with 0 \n";
            Console.WriteLine(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyAndDivsionBeforeSubtractionAndAdditionTest()
        {
            List<String> inputList = new List<String>() {"3", "+", "5", "-", "10", "*", "3", "/", "2" };

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "result: -7";
            Console.WriteLine(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AdditionTest() {
            List<String> inputList = new List<String>() { "34.5", "+", "42.5", "+", "4.2"};

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "result: 81.2";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SubtractionTest()
        {
            List<String> inputList = new List<String>() { "30.5", "-", "42.5", "-", "4.2" };

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "result: -16.2";
            Console.WriteLine(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyTest()
        {
            List<String> inputList = new List<String>() { "4", "*", "2.5", "*", "2" };

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "result: 20";
            Console.WriteLine(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivisionTest()
        {
            List<String> inputList = new List<String>() { "10", "/", "2.5", "/", "2" };

            String result = calculatorService.CalculateByOperator(inputList);
            String expected = "result: 2";
            Console.WriteLine(result);
            Assert.Equal(expected, result);
        }
    }
}
