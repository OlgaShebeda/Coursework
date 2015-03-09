using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;

namespace MathСalculator.Domain.Methods
{
    public static class CalcMethods
    {
        public static double ParseFunction(string Function, double X0)
        {
            ExpressionParser parser = new ExpressionParser();
            parser.Values.Add("x", X0);
            return parser.Parse(Function);
        }

        /// <summary>
        /// нахождение производной
        /// </summary>
        /// <param name="Function">уравнение</param>
        /// <param name="X0"></param>
        /// <returns></returns>
        public static double DerivativeOfFunction(string Function, double X0)
        {
            double delta_x = 0.000000001;
            return (ParseFunction(Function, (X0 + delta_x)) - ParseFunction(Function, X0)) / delta_x;
        }

    }
}
