using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CalculatorTests")]

namespace CalculatorProgram
{
        
    class Calculator
    {
        private bool isCalculationZeroAndDivide= false;
        public void Start()
        {
            List<String> menu = new List<String>() { "1. Calculate", "2. Exit Program\n" };
            bool isCalculatorRunning = true;

            while (isCalculatorRunning)
            {
                isCalculationZeroAndDivide = false;
                ShowMenu(menu);
                int menuChoice = Convert.ToInt32(InputValue("Enter a menu choice: "));

                if (menuChoice == 1)
                {
                    Console.WriteLine("Enter a calculation with /, *, + and -. Example: 2+6/3-3*2");
                    String input = Console.ReadLine();
                    char[] inputArray = input.ToCharArray();
                    List<String> calculation = CombineCharsToNumberStrings(inputArray);
                    String result = CalculateByOperator(calculation);
                    Console.WriteLine(isCalculationZeroAndDivide ? "Can't divide with 0 \n" : "result: " + result);
                }

                else
                {
                    isCalculatorRunning = false;
                }

            }
        }

        private List<String> CombineCharsToNumberStrings(char[] inputArray)
        {
            List<String> calculation = new List<String>();
            int lastOperator = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if(CheckOperator(inputArray[i]))
                {
                    calculation.Add(CharsToNumberString(i, lastOperator, inputArray));
                    calculation.Add(inputArray[i].ToString());
                    lastOperator = i+1;
                }
                 else if(i == inputArray.Length-1)
                {
                    calculation.Add(CharsToNumberString(i+ inputArray.Length-i, lastOperator, inputArray));
                }
            }
            return calculation;
        }

        private bool CheckOperator(char value)
        {
            return value.Equals('+') || value.Equals('-') || value.Equals('*') || value.Equals('/') ?  true :  false;
        }

        private String CharsToNumberString(int stop, int start, char[] values)
        {
            String number = "";
            for(int i = start; i < stop; i++)
            {
                number = number + values[i].ToString();
            }
            return number;
        }

        private void ShowMenu(List<String> menu)
        {
            menu.ForEach(menuItem => Console.WriteLine(menuItem));
        }

        private double InputValue(String message)
        {
            double value = 0;
            while (true)
            {
                Console.WriteLine(message);
                try
                {
                    value = Convert.ToDouble(Console.ReadLine());
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a valid number");
                }
            }
        }

        private String CalculateByOperator(List<String> calculations)
        {
            List<String> mathOperators = new List<String>() {"/", "*", "-", "+" };

            double sum = 0;
            foreach (String mathOperator in mathOperators)
            {
                for (int i = 0; i < calculations.Count; i++)
                {
                    if (calculations.ElementAt(i).Equals(mathOperator))
                    {
                        double value1 = Convert.ToDouble(calculations.ElementAt(i - 1));
                        double value2 = Convert.ToDouble(calculations.ElementAt(i+1));
                        CheckInputDivideAndInputZero(value2, mathOperator);
                        sum = Calculate(value1, value2, mathOperator);
                        calculations = DeleteUsedNumbers(i+1, i-1, calculations, sum);
                        i = 0;
                    }
                }
            }
            return calculations.ElementAt(0);
        }

        private List<String> DeleteUsedNumbers(int start, int stop, List<String> calculations, double sum)
        {
            for(int i = start ; i >= stop; i--)
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
                    return Add(value1, value2);

                case "-":
                    return Subtract(value1, value2);


                case "*":
                    return Multiply(value1, value2);

                case "/":
                    return Divide(value1, value2);
                default:
                    return 0;
            }   
        }

        private double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        private double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        private double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        private double Divide(double value1, double value2)
        {
            return value1 / value2;
        }

        private void CheckInputDivideAndInputZero(double value, String mathOperator)
        {
            if(value == 0 && mathOperator.Equals("/"))
            {
                isCalculationZeroAndDivide = true;
            }
        }
    }
}

