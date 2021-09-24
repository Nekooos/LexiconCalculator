using CalculatorProgram.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CalculatorTests")]

namespace CalculatorProgram
{
        
    class Calculator
    {
        private CalculatorService calculatorService;

        public Calculator()
        {
            calculatorService = new CalculatorService();
        }

        public void Start()
        {
            List<String> menu = new List<String>() { "1. Calculate", "2. Exit Program\n" };
            bool isCalculatorRunning = true;

            while (isCalculatorRunning)
            {
                ShowMenu(menu);
                int menuChoice = Convert.ToInt32(InputValue("Enter a menu choice: "));

                if (menuChoice == 1)
                {
                    Console.WriteLine("Enter a calculation with /, *, + and -. Example: 2+6/3-3*2");
                    String input = Console.ReadLine();
                    char[] inputArray = input.ToCharArray();
                    List<String> calculation = calculatorService.CombineCharsToNumberStrings(inputArray);
                    String result = calculatorService.CalculateByOperator(calculation);
                    Console.WriteLine(result);
                }

                else
                {
                    isCalculatorRunning = false;
                }
            }
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

        
    }
}

