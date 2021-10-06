using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class CalculatorTestData
    {
        public static IEnumerable<object[]> AdditionData =>
        
            new List<object[]>
            {
                new object[] {new List<String>() {"4", "+", "4"}, "result: 8"},
                new object[] {new List<String>() {"4", "+", "4", "+", "4", "+", "4"}, "result: 16"},
                new object[] {new List<String>() {"4.1", "+", "4.2", "+", "4", "+", "4.2"}, "result: 16.5"}
            };

        public static IEnumerable<object[]> SubtractionData =>

            new List<object[]>
            {
                new object[] {new List<String>() {"16", "-", "4"}, "result: 12"},
                new object[] {new List<String>() {"4", "-", "16"}, "result: -12"},
                new object[] {new List<String>() {"16", "-", "4", "-", "4", "-", "4"}, "result: 4"},
                new object[] {new List<String>() {"4", "-", "4", "-", "4", "-", "4"}, "result: -8"},
                new object[] {new List<String>() {"30.5", "-", "42.5", "-", "4.2" }, "result: -16.2"}
            };

        public static IEnumerable<object[]> DivisionZeroData =>

            new List<object[]>
            {
                new object[] {new List<String>() {"0", "/", "6"}, "result: 0"},
                new object[] {new List<String>() {"6", "/", "0"}, "Can't divide with 0 \n"},
                new object[] {new List<String>() { "16", "/", "4", "/", "0" }, "Can't divide with 0 \n"}
            };
    }
}
