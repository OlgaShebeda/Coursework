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
        public double NewtonsMethod(string Function, double X0, double Epsilon, ref string resultTEXT)
        {
            double y = X0 - CalcMethods.ParseFunction(Function, X0)/CalcMethods.DerivativeOfFunction(Function, X0);
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
                y = X0 - CalcMethods.ParseFunction(Function, X0)/CalcMethods.DerivativeOfFunction(Function, X0);
            }
            resultTEXT += "Результат =" + X0 + "\n";
            return y;
        }
    }
}
