using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Methods
{

        public class NumericalMethods
        {
            /// <summary>
            /// метод парабол/симпсона
            /// </summary>
            /// <param name="function">подинтегральная функция</param>
            /// <param name="a">начало отрезка [a, b]</param>
            /// <param name="b">конец отрезка [a, b]</param>
            /// <returns></returns>
            public double MethodSimpsona(string function, double a, double b, int n)
            {
                double S = 0;
                double h = (b - a) / n;

                for (int i = 0; i <= n; i++)
                {
                    if (i == 0 || i == n)
                        S = S + ((CalcMethods.ParseFunction(function, (a + i * h)))) * h / 2;
                    else
                        if (i % 2 == 0)
                            S = S + (2 * CalcMethods.ParseFunction(function, (a + i * h))) * h / 3;
                        else
                            S = S + (4 * CalcMethods.ParseFunction(function, (a + i * h))) * h / 3;
                }

                return S;
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
                int m = 3 *n -1;
                double x;
                for (int i = 1; i <= m; i++)
                {
                    x = a + h * i;
                    if (i % 3 == 0)
                        S = S + 2 * CalcMethods.ParseFunction(function, x);
                    else
                        S = S + 3 * CalcMethods.ParseFunction(function, x);
                }
                return S * 3 / 8 * h;
            }

            /// <summary>
            /// метод трапеций
            /// </summary>
            /// <param name="function">подинтегральная функция</param>
            /// <param name="a">начало отрезка [a, b]</param>
            /// <param name="b">конец отрезка [a, b]</param>
            /// <returns></returns>
            public double MethodOfTrapezoids(string function, double a, double b, int n)
            {
                double S = 0;
                double h = (b - a) / n;
                double x = a;
                for (double i = 0; i < n + 1; i++)
                {
                    if (i == 0 || i == n)
                        S = S + ((CalcMethods.ParseFunction(function, (x + i * h)))) * h / 2;
                    else
                        S = S + ((CalcMethods.ParseFunction(function, (x + i * h)))) * h;
                }
                return S;
            }
        }
    }

