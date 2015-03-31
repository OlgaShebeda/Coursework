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

       
    }
}
