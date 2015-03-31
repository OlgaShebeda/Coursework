using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using info.lundin.math;
using System.Diagnostics;
using Novacode;
using System.IO;

namespace MathСalculator.Domain.Methods
{
    public class SimpleIterationMethod
    {
        /// <summary>
        /// метед простой итерации
        /// </summary>
        /// <param name="Function">искомая функция</param>
        /// <param name="X0">начальное приближение</param>
        /// <param name="Epsilon">точность вычисления</param>
        /// <param name="resultTEXT"></param>
        /// <returns></returns>
        public double MethodOfSimpleIteration(string Function, double X0, double Epsilon, ref string resultTEXT)
        {
            double y = CalcMethods.ParseFunction(Function, X0);
            double k = 1;
            resultTEXT = "Функция x = f(x) = " + Function + "\n";
            resultTEXT += "x0 = " + X0 + "   Epsilon =  " + Epsilon + "\n"; 
            while ((Math.Abs(y - X0) > Epsilon))
            {
                resultTEXT += "\n|у -x0| = " + (Math.Abs(y - X0));
                if (k > 500) throw new ArgumentException("k > 500");
                resultTEXT += "\n y = " + y;
                resultTEXT += "\n k =" + k + "\n";
                k++;
                
                X0 = y;
                y = CalcMethods.ParseFunction(Function, X0);
            }
            resultTEXT += "Результат =" + X0 + "\n";
            return y;
        }

        /// <summary>
        /// Метод Хорд
        /// </summary>
        /// <param name="Function"></param>
        /// <param name="X0">x(n)</param>
        /// <param name="XLast">x(n-1) - not changed</param>
        /// <param name="Epsilon"></param>
        /// <returns>x(n+1)=y</returns>
        public double ChordMethod(string Function, double X0, double XLast, double Epsilon, ref string resultTEXT)
        {
            double y = X0 - (X0 - XLast) * CalcMethods.ParseFunction(Function, X0) / (CalcMethods.DerivativeOfFunction(Function, X0) - CalcMethods.DerivativeOfFunction(Function, XLast));
            double k = 1;
            resultTEXT = "Функция x = f(x) = " + Function + "\n";
            resultTEXT += "x0 = " + X0 + "  X1 = " + XLast + "   Epsilon =  " + Epsilon + "\n";
            while ((Math.Abs(y - X0) > Epsilon))
            {
                resultTEXT += "\n|у -x0| = " + (Math.Abs(y - X0));
                if (k > 500) throw new ArgumentException("k > 500");
                resultTEXT += "\n y = " + y;
                resultTEXT += "\n k =" + k + "\n";
                k++;

                X0 = y;
                y = X0 - (X0 - XLast) * CalcMethods.ParseFunction(Function, X0) / (CalcMethods.DerivativeOfFunction(Function, X0) - CalcMethods.DerivativeOfFunction(Function, XLast));
            }
            resultTEXT += "Результат =" + y + "\n";
            return y;
        }

        /// <summary>
        /// все то же, что и в методе простых итераций
        /// </summary>
        /// <param name="Function"></param>
        /// <param name="X0"></param>
        /// <param name="Epsilon"></param>
        /// <returns></returns>
        public double NewtonsMethod(string Function, double X0, double Epsilon, ref string resultTEXT)
        {
            double y = X0 - CalcMethods.ParseFunction(Function, X0) / CalcMethods.DerivativeOfFunction(Function, X0);
            double k = 1;
            resultTEXT = "Функция x = f(x) = " + Function + "\n";
            resultTEXT += "x0 = " + X0 + "   Epsilon =  " + Epsilon + "\n";
            while ((Math.Abs(y - X0) > Epsilon))
            {
                resultTEXT += "\n|у -x0| = " + (Math.Abs(y - X0));
                if (k > 500) throw new ArgumentException("k > 500");
                resultTEXT += "\n y = " + y;
                resultTEXT += "\n k =" + k + "\n";
                k++;

                X0 = y;
                y = X0 - CalcMethods.ParseFunction(Function, X0) / CalcMethods.DerivativeOfFunction(Function, X0);
            }
            resultTEXT += "Результат =" + X0 + "\n";
            return y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Function"></param>
        /// <param name="X0">x(n)</param>
        /// <param name="XLast">x(n-1) - changed</param>
        /// <param name="Epsilon"></param>
        /// <returns>x(n+1)=y</returns>
        public double OfSecantsMethod(string Function, double X0, double XLast, double Epsilon, ref string resultTEXT)
        {
            double y = X0 -
                       (X0 - XLast) * CalcMethods.ParseFunction(Function, X0) /
                       (CalcMethods.DerivativeOfFunction(Function, X0) -
                        CalcMethods.DerivativeOfFunction(Function, XLast));
            double k = 1;
            resultTEXT = "Функция x = f(x) = " + Function + "\n";
            resultTEXT += "x0 = " + X0 + "  X1 = " + XLast + "   Epsilon =  " + Epsilon + "\n";
            while ((Math.Abs(y - X0) > Epsilon))
            {
                resultTEXT += "\n|у -x0| = " + (Math.Abs(y - X0));
                if (k > 500) throw new ArgumentException("k > 500");
                resultTEXT += "\n y = " + y;
                resultTEXT += "\n k =" + k + "\n";
                k++;
                XLast = X0;
                X0 = y;
                y = X0 -
                    (X0 - XLast) * CalcMethods.ParseFunction(Function, X0) /
                    (CalcMethods.DerivativeOfFunction(Function, X0) - CalcMethods.DerivativeOfFunction(Function, XLast));
            }
            resultTEXT += "Результат =" + y + "\n";
            return y;
        }
    }
}
