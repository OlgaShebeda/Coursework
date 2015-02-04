using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathСalculator.WebUI.Models;
using MathСalculator.Domain.Methods;

namespace MathСalculator.WebUI.Controllers
{
    public class MethodsController : Controller
    {
        //
        // GET: /Methods/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GCD()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GCD(GCDModel model)
        {
            model.result = GCDMethod.GCD(model.firstNumber, model.secondNumber);
            return View(model);
        }

        [HttpGet]
        public ActionResult Gaus()
        {
            ViewBag.flag1 = true;
            return View();
        }

        [HttpPost]
        public ActionResult Gaus(GausModel model1,IList<double> ints)
        {
            if (model1.myArray == null)
            {
                ViewBag.flag = true;
                ViewBag.flag1 = false;
                return View(model1);
            }
            if (ints != null)
            {
                double[] Matr = {};
                double[,] Matrix = new double[model1.countRows, model1.countVariable];
                var count = ints.Count()/model1.countRows;
                for (int i = 0; i < model1.countRows; i++)
                {
                    Matr = ints.Skip(i *Matr.Length).Take(count).ToArray();
                    for (int j = 0; j < model1.countVariable; j++)
                    {
                        
                        Matrix[i, j] = Matr[j];
                    }
                   
                }
                model1.Matrix = Matrix;
            }
            ViewBag.flag = true;
            ViewBag.answer = true;
            model1.answer = GausResult(model1.Matrix, model1.myArray, model1.countRows);
            return View(model1);
        }

    [NonAction]
        public double[] GausResult(double[,] matrix, double[] mas, int n)
        {
            var row = (uint)n; 
            var answer = new double[row];
            var solution = new GausMethod(row, row);
            for (var i = 0; i < row; i++)
                solution.RightPart[i] = mas[i];
          
            for (var i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                    solution.Matrix[i][j] = matrix[i, j];
            }
            solution.SolveMatrix();
            for (int i = 0; i < row; i++)
                answer[i] = solution.Answer[i];
            return answer;
        }
    }
}