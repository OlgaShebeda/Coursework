using Novacode;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Methods.helpers
{
   public class CreateDoc
    {

        public void CreateSampleDocument(string paraOne, string headlineText)
        {

            // Modify to suit your machine:
            string fileName = @"E:\DocXExample.docx";

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
            Process.Start("WINWORD.EXE", fileName);
        }

    
    }
}
