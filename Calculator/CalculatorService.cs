using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram.Service
{
    class CalculatorService
    {
        private bool isCalculationZeroAndDivide;

        public List<String> CombineCharsToNumberStrings(char[] inputArray)
        {
            isCalculationZeroAndDivide = false;
            List<String> calculation = new List<String>();
            int lastOperator = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (CheckOperator(inputArray[i]))
                {
                    calculation.Add(CharsToNumberString(i, lastOperator, inputArray));
                    calculation.Add(inputArray[i].ToString());
                    lastOperator = i + 1;
                }
                else if (i == inputArray.Length - 1)
                {
                    calculation.Add(CharsToNumberString(i + inputArray.Length - i, lastOperator, inputArray));
                }
            }
            return calculation;
        }

        private bool CheckOperator(char value)
        {
            return value.Equals('+') || value.Equals('-') || value.Equals('*') || value.Equals('/') ? true : false;
        }

        private String CharsToNumberString(int stop, int start, char[] values)
        {
            String number = "";
            for (int i = start; i < stop; i++)
            {
                number = number + values[i].ToString();
            }
            return number;
        }

        public String CalculateByOperator(List<String> calculations)
        {
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
            return GetIsCalculationZeroAndDivide() ? "Can't divide with 0 \n" : "result: " + sum;
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

        public bool GetIsCalculationZeroAndDivide()
        {
            return isCalculationZeroAndDivide;
        }
    }
}
