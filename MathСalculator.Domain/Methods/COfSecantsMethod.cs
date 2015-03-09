using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Methods
{
    public class COfSecantsMethod
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Function"></param>
        /// <param name="X0">x(n)</param>
        /// <param name="XLast">x(n-1) - changed</param>
        /// <param name="Epsilon"></param>
        /// <returns>x(n+1)=y</returns>
        public double OfSecantsMethod(string Function, double X0, double XLast, double Epsilon)
        {
            double y = X0 - (X0 - XLast) * CalcMethods.ParseFunction(Function, X0) / (CalcMethods.DerivativeOfFunction(Function, X0) - CalcMethods.DerivativeOfFunction(Function, XLast));
            double k = 1;
            string resultTEXT = "Функция x = f(x) = " + Function + "\n";
            while ((Math.Abs(y - X0) > Epsilon))
            {
                if (k > 500) throw new ArgumentException("k > 500");
                resultTEXT += "\n y = " + y;
                k++;
                resultTEXT += "\n k =" + k + "\n";
                XLast = X0;
                X0 = y;
                y = X0 - (X0 - XLast) * CalcMethods.ParseFunction(Function, X0) / (CalcMethods.DerivativeOfFunction(Function, X0) - CalcMethods.DerivativeOfFunction(Function, XLast));
            }
            resultTEXT += "Результат =" + X0 + "\n";
            return y;
        }
    }
}
