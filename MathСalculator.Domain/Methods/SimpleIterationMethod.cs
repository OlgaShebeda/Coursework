using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using info.lundin.math;
using System.Diagnostics;
using Novacode;

namespace MathСalculator.Domain.Methods
{
    public class SimpleIterationMethod
    {
        public double Calc(string Function, double X0 =1, double Epsilon = 0.000001)
        {
            ExpressionParser parser = new ExpressionParser();
            double k = 0;
            double y = 0;
            string resultTEXT = "Функция x = f(x) = " + Function + "\n";
            //resultTEXT += "x0 =" + X0 + "\n" + "Eps = " + Epsilon + "\n";
            do
            {
                if (k > 0)
                {
                    X0 = y;
                   
                }
                parser.Values.Add("x", X0);
                y = parser.Parse(Function);
                resultTEXT+= "\n y = " + y.ToString();
                k++;
                resultTEXT += "\n k =" + k + "\n";
                parser.Values.Remove("x");
            } while ((Math.Abs(y - X0) > Epsilon));
            resultTEXT += "Результат =" + X0 +"\n";
            CreateSampleDocument(resultTEXT,"Метод простой итерации");
            return X0;
        }

        public void CreateSampleDocument(string paraOne, string headlineText)
        {

            // Modify to suit your machine:
            string fileName = @"D:\DocXExample.docx";

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
            //Process.Start("WINWORD.EXE", fileName);
        }
    }
}
