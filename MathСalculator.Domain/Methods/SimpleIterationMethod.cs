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

        public double MethodOfSimpleIteration(string Function, double X0, double Epsilon)
        {
            double y = CalcMethods.ParseFunction(Function, X0);
            double k = 1;
            string resultTEXT = "Функция x = f(x) = " + Function + "\n";
            while ((Math.Abs(y - X0) > Epsilon))
            {
                if (k > 500) throw new ArgumentException("k > 500");
                resultTEXT += "\n y = " + y;
                k++;
                resultTEXT += "\n k =" + k + "\n";
                X0 = y;
                y = CalcMethods.ParseFunction(Function, X0);
            }
            resultTEXT += "Результат =" + X0 + "\n";
            return y;
        }

        public void CreateSampleDocument(string paraOne, string headlineText)
        {
            string path1 = @"docExample/docExample1";

 
            // Modify to suit your machine:
            string fileName = Path.GetFullPath(path1); 

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.Size = 10D;

            // Create the document in memory:
            var doc = DocX.Create(fileName);

            // Insert the now text obejcts;
            doc.InsertParagraph(headlineText, false, headLineFormat);
            doc.InsertParagraph(paraOne, false, paraFormat);

            // Save to the 
            doc.Save();
            //// Open in Word:
          
        }
    }
}
