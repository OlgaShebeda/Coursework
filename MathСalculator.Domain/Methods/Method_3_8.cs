using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Methods
{
    class Method_3_8
    {
        public class CMethodSimpsona
        {
            /// <summary>
            /// метод парабол/симпсона решения интегрального уровнения
            /// </summary>
            /// <param name="function">подинтегральная функция</param>
            /// <param name="a">начало отрезка [a, b]</param>
            /// <param name="b">конец отрезка [a, b]</param>
            /// <returns></returns>
            public double MethodSimpsona(string function, double a, double b)
            {
                return (a - b) / 6 * (CalcMethods.ParseFunction(function, a) + 4 * CalcMethods.ParseFunction(function, (a + b) / 2) + CalcMethods.ParseFunction(function, b));
            }
        }
    }
}
