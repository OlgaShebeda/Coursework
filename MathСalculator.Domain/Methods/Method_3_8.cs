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
            /// метод парабол/симпсона
            /// </summary>
            /// <param name="function">подинтегральная функция</param>
            /// <param name="a">начало отрезка [a, b]</param>
            /// <param name="b">конец отрезка [a, b]</param>
            /// <returns></returns>
            public double MethodSimpsona(string function, double a, double b)
            {
                double h = (a - b)/1000;
                double x0 = a;
                double x1 = x0 + h;
                double s = 0;
                for (int i = 0; i <= n - 1; i++)
                {
                    S += CalcMethods.ParseFunction(function, x0) + 4 * CalcMethods.ParseFunction(function, (x0 + h / 2)) + CalcMethods.ParseFunction(function, x1);
                    x0 = x1;
                    x1 += h;
                }

                return s;
            }

            /// <summary>
            /// метод 3/8
            /// </summary>
            /// <param name="function">подинтегральная функция</param>
            /// <param name="a">начало отрезка [a, b]</param>
            /// <param name="b">конец отрезка [a, b]</param>
            /// <returns></returns>
            public double Method_3_8(string function, double a, double b)
            {
                double h = (b - a) / (3 * n);
                S = CalcMethods.ParseFunction(function, a) + CalcMethods.ParseFunction(function, b);
                int m = 3 * n - 1;
                double x;
                for (int i = 1; i <= m; i++)
                {
                    x = a + h * i;
                    if (i % 3 == 0)
                        S = S + 2 * CalcMethods.ParseFunction(function, x);
                    else
                        S = S + 3 * CalcMethods.ParseFunction(function, x);
                }
                S = S * 3 / 8 * h;
            }
        }
    }
}
