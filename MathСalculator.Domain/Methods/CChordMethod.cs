using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Methods
{
    public class CChordMethod
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Function"></param>
        /// <param name="X0">x(n)</param>
        /// <param name="XLast">x(n-1) - not changed</param>
        /// <param name="Epsilon"></param>
        /// <returns>x(n+1)=y</returns>
        public double ChordMethod(string Function, double X0 , double XLast, double Epsilon,ref string resultTEXT)
        {
            double y = X0 - (X0 - XLast) * CalcMethods.ParseFunction(Function, X0) / (CalcMethods.DerivativeOfFunction(Function, X0) - CalcMethods.DerivativeOfFunction(Function, XLast));
            double k = 1;
           resultTEXT = "Функция x = f(x) = " + Function + "\n";
           resultTEXT += "x0 = " + X0 +"  X1 = "+XLast+"   Epsilon =  " + Epsilon + "\n"; 
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
    }
}
