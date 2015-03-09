using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Methods
{
    public class CNewtonsMethod
    {
        /// <summary>
        /// все то же, что и в методе простых итераций
        /// </summary>
        /// <param name="Function"></param>
        /// <param name="X0"></param>
        /// <param name="Epsilon"></param>
        /// <returns></returns>
        public double NewtonsMethod(string Function, double X0 = 1, double Epsilon = 0.000001)
        {
            double y = X0 - CalcMethods.ParseFunction(Function, X0)/CalcMethods.DerivativeOfFunction(Function, X0);
            double k = 1;
            string resultTEXT = "Функция x = f(x) = " + Function + "\n";
            while ((Math.Abs(y - X0) > Epsilon))
            {
                if (k > 500) throw new ArgumentException("k > 500");
                resultTEXT += "\n y = " + y;
                k++;
                resultTEXT += "\n k =" + k + "\n";
                X0 = y;
                y = X0 - CalcMethods.ParseFunction(Function, X0)/CalcMethods.DerivativeOfFunction(Function, X0);
            }
            resultTEXT += "Результат =" + X0 + "\n";
            return y;
        }
    }
}
