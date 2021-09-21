using System;
using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {

        private readonly List<String> menu;
        bool isCalculatorRunning;

        public Calculator()
        {
            menu = new List<String>() { "1. Calculate", "2. Exit Program\n" };
            isCalculatorRunning = true;
        }

        public void start()
        {
            while (isCalculatorRunning)
            {
                ShowMenu();
                int menuChoice = Convert.ToInt32(inputValue("Enter a menu choice: "));

                if (menuChoice == 1)
                {
                    double number1 = inputValue("Enter the first number in the calculation");
                    string mathOperator = InputOperator();
                    double number2 = inputValue("Enter the second number in the calculation");
                    bool isInputDivisionAndZero = CheckInputDivideAndInputZero(number1, number2, mathOperator);

                    if (!isInputDivisionAndZero)
                    {
                        double result = Calculate(number1, number2, mathOperator);
                        Console.WriteLine($"{number1} {mathOperator} {number2} = {result} \n");
                    }
                }

                else
                {
                    isCalculatorRunning = false;
                }

            }
        }

        private void ShowMenu()
        {
            menu.ForEach(menuItem => Console.WriteLine(menuItem));
        }

        private double inputValue(String message)
        {
            double value;

            while (true)
            {
                Console.WriteLine(message);
                try
                {
                    value = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a valid number");
                }
            }
            return value;
        }

        private string InputOperator()
        {
            String mathOperator;
            while (true)
            {
                Console.WriteLine("Enter operator: +, -, * or /");
                mathOperator = Console.ReadLine();

                if (mathOperator == "+" || mathOperator == "-" || mathOperator == "*" || mathOperator == "/")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid operator");
                }

            }
            return mathOperator;
        }

        private double Calculate(double value1, double value2, String mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "+":
                    result = Add(value1, value2);
                    break;

                case "-":
                    result = Subtract(value1, value2);
                    break;

                case "*":
                    result = Multiply(value1, value2);
                    break;

                case "/":
                    result = Divide(value1, value2);
                    break;
            }

            return result;
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

        private bool CheckInputDivideAndInputZero(double value1, double value2, String mathOperator)
        {
            if (value1 == 0 || value2 == 0 && mathOperator.Equals("/"))
            {
                Console.WriteLine("Can't divide with 0");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

