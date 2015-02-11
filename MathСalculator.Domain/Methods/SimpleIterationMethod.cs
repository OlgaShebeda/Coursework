using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;

namespace MathСalculator.Domain.Methods
{
    public class SimpleIterationMethod
    {
        public double Calc(string Function, double X0, double Epsilon)
        {
            ExpressionParser parser = new ExpressionParser();
            double k = 0;
            double y = 0;

            do
            {
                if (k > 0) X0 = y;
                parser.Values.Add("x", X0);
                y = parser.Parse(Function);
                k++;
                parser.Values.Remove("x");
            } while ((Math.Abs(y - X0) > Epsilon));
            return X0;
        }
    }
}
