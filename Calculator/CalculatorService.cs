﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorProgram.Service
{
    class CalculatorService
    {
        private bool isCalculationZeroAndDivide;

        public List<String> StringToNumberStrings(string input)
        {
            return Regex.Split(input, @"\s*([-+/*])\s*")
                .Where(n => !string.IsNullOrEmpty(n))
                .ToList();
        }

        public String CalculateByOperator(List<String> calculations)
        {
            isCalculationZeroAndDivide = false;
            List<String> mathOperators = new List<String>() { "/", "*", "-", "+" };

            double sum = 0;
            foreach (String mathOperator in mathOperators)
            {
                for (int i = 0; i < calculations.Count; i++)
                {
                    if (calculations.ElementAt(i).Equals(mathOperator))
                    {
                        double value1 = Convert.ToDouble(calculations.ElementAt(i - 1));
                        double value2 = Convert.ToDouble(calculations.ElementAt(i + 1));
                        isCalculationZeroAndDivide = CheckInputDivideAndInputZero(value2, mathOperator);
                        sum = Calculate(value1, value2, mathOperator);
                        calculations = DeleteUsedNumbers(i + 1, i - 1, calculations, sum);
                        i = 0;
                    }
                }
            }
            return isCalculationZeroAndDivide ? "Can't divide with 0 \n" : "result: " + sum;
        }

        private List<String> DeleteUsedNumbers(int start, int stop, List<String> calculations, double sum)
        {
            for (int i = start; i >= stop; i--)
            {
                calculations.RemoveAt(i);
            }
            calculations.Insert(stop, sum.ToString());

            return calculations;
        }

        private double Calculate(double value1, double value2, String mathOperator)
        {
            switch (mathOperator)
            {
                case "+":
                    return value1 + value2;

                case "-":
                    return value1 - value2;


                case "*":
                    return value1 * value2;

                case "/":
                    return value1 / value2;
                default:
                    return 0;
            }
        }

        private bool CheckInputDivideAndInputZero(double value, String mathOperator)
        {
            if (value == 0 && mathOperator.Equals("/"))
            {
                return true;
            } 
            else
            {
                return isCalculationZeroAndDivide;
            }
        }
    }
}
