using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Methods
{
   public class GCDMethod
    {
       public static int GCD(int firstNumber, int secondNumber)
       {
           if (firstNumber < 0 || secondNumber < 0) throw new Exception("Incorrect input numbers");

           while (secondNumber != 0)
           {
               secondNumber = firstNumber % (firstNumber = secondNumber);
           }
           return firstNumber;
       }
    }
}
