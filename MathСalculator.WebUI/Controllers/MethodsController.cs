using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathСalculator.WebUI.Models;
using MathСalculator.Domain.Methods;
using MathСalculator.Domain.Abstract;
using MathСalculator.Domain.Entities;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using System.Security;
using System.Web.UI.WebControls;
using MathСalculator.WebUI.Properties;
using Novacode;

namespace MathСalculator.WebUI.Controllers
{
    public class MethodsController : Controller
    {

        private IUserRepository _userRepos;

        //
        // GET: /Methods/
        [HttpGet, ValidateInput(false)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Error404()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MathCalc()
        {
            return View();
        }

        public FileResult GetFile(string path)
        {

            string file_path = Server.MapPath("~/Content/" + path);
            string file_type = "application/msword";
            return File(file_path, file_type, path);
        }

        public FileResult Download(string path)
        {
            string actualPath = Server.MapPath("~/Content/" + path);
            return File(actualPath, "application/pdf", Server.UrlEncode(path));
        }

        #region Методы решения СЛАУ

        [HttpGet]
        public ActionResult Gaus()
        {
            ViewBag.flag1 = true;
            return View();
        }

        [HttpPost]
        public ActionResult Gaus(GausModel model1, IList<double> ints)
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
                    Matr = ints.Skip(i*Matr.Length).Take(count).ToArray();
                    for (int j = 0; j < model1.countVariable; j++)
                    {

                        Matrix[i, j] = Matr[j];
                    }

                }
                model1.Matrix = Matrix;
            }
            ViewBag.flag = false;
            ViewBag.answer = true;
            model1.answer = GausResult(model1.Matrix, model1.myArray, model1.countRows);
            return View(model1);
        }

        [NonAction]
        private double[] GausResult(double[,] matrix, double[] mas, int n)
        {
            var row = (uint) n;
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

        #endregion

        #region Итерационные методы

        [HttpGet]
        public ViewResult SimpleIteration()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Secants()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Secants(ChordModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("",
                    Resources.MethodsController_Newton_Пожалуйста_введите_корректно_начальные_данные);
                return View(model);
            }
            string resultTxt = string.Empty;
            COfSecantsMethod method = new COfSecantsMethod();
            try
            {
                model.Result = method.OfSecantsMethod(model.Fuctions, model.X0, model.X1, model.Epsilon, ref resultTxt);
                if (model.Result.Equals(Double.NaN))
                {
                    ModelState.AddModelError("",
                        Resources.MethodsController_Chord_Решение_не_найдено__Произошло_деление_на_ноль_);
                    return View(model);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", Resources.MethodsController_Chord_Метод_расходится);
                return View(model);
            }
            if (!String.IsNullOrEmpty(model.Equation))
                ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                 Server.UrlEncode("solve(" + model.Equation + ")");
            CreateSampleDocument(resultTxt, "Метод секущих", "Secants.doc");
            return View(model);
        }

        [HttpGet]
        public ViewResult Newton()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Chord()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Chord(ChordModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("",
                    Resources.MethodsController_Newton_Пожалуйста_введите_корректно_начальные_данные);
                return View(model);
            }
            CChordMethod method = new CChordMethod();
            string resultTxt = string.Empty;
            try
            {
                model.Result = method.ChordMethod(model.Fuctions, model.X0, model.X1, model.Epsilon, ref resultTxt);
                if (model.Result.Equals(Double.NaN))
                {
                    ModelState.AddModelError("",
                        Resources.MethodsController_Chord_Решение_не_найдено__Произошло_деление_на_ноль_);
                    return View(model);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", Resources.MethodsController_Chord_Метод_расходится);
                return View(model);
            }
            if (!String.IsNullOrEmpty(model.Equation))
                ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                 Server.UrlEncode("solve(" + model.Equation + ")");
            CreateSampleDocument(resultTxt, "Метод хорд", "Chord.doc");
            return View(model);
        }



        [HttpPost]
        public ViewResult Newton(SimpleIterationModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("",
                    Resources.MethodsController_Newton_Пожалуйста_введите_корректно_начальные_данные);
                return View(model);
            }
            CNewtonsMethod method = new CNewtonsMethod();
            string resultTxt = "";
            try
            {
                model.Result = method.NewtonsMethod(model.Fuctions, model.X0, model.Epsilon, ref resultTxt);

                if (model.Result.Equals(Double.NaN))
                {
                    ModelState.AddModelError("",
                        Resources.MethodsController_Chord_Решение_не_найдено__Произошло_деление_на_ноль_);
                    return View(model);
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", Resources.MethodsController_Chord_Метод_расходится);
                return View(model);
            }
            if (!String.IsNullOrEmpty(model.equation))
            {
                ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                 Server.UrlEncode("solve(" + model.equation + ")");
            }

            CreateSampleDocument(resultTxt, "Метод Ньютона", "Newton.doc");
            return View(model);
        }


        [HttpPost]
        public ViewResult SimpleIteration(SimpleIterationModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("",
                    Resources.MethodsController_Newton_Пожалуйста_введите_корректно_начальные_данные);
                return View(model);
            }
            SimpleIterationMethod method = new SimpleIterationMethod();
            try
            {
                string resultTxt = "";
                model.Result = method.MethodOfSimpleIteration(model.Fuctions, model.X0, model.Epsilon, ref resultTxt);
                if (model.Result.Equals(Double.NaN))
                {
                    ModelState.AddModelError("",
                        Resources.MethodsController_Chord_Решение_не_найдено__Произошло_деление_на_ноль_);
                    return View(model);
                }
                CreateSampleDocument(resultTxt, "Метод простой итерации", "MPI.doc");

            }
            catch (Exception)
            {

                ModelState.AddModelError("", Resources.MethodsController_Chord_Метод_расходится);
                return View(model);
            }

            if (!String.IsNullOrEmpty(model.equation))
            {
                ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                 Server.UrlEncode("solve(" + model.equation + ")");
            }

            return View(model);
        }

        #endregion

        [NonAction]
        public void CreateSampleDocument(string paraOne, string headlineText, string path)
        {
            string path1 = Server.MapPath("~/Content/" + path);
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

        [HttpGet]
        public ActionResult Simpson()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Simpson(NumericalIntegration model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("",
                    Resources.MethodsController_Newton_Пожалуйста_введите_корректно_начальные_данные);
                return View(model);
            }
            NumericalMethods method = new NumericalMethods();
            try
            {
                model.Result = method.MethodSimpsona(model.Function, model.A, model.B,model.N);

                if (model.Result.Equals(Double.NaN))
                {
                    ModelState.AddModelError("",
                        Resources.MethodsController_Chord_Решение_не_найдено__Произошло_деление_на_ноль_);
                    return View(model);
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", Resources.MethodsController_Chord_Метод_расходится);
                return View(model);
            }

            if (!String.IsNullOrEmpty(model.Function))
            {
                ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                 Server.UrlEncode("integrate sqrt("+model.Function+")dx Simpson's rule x="+model.A+".."+model.B);
            }
            return View(model);
        }



            [HttpGet]
        public ActionResult Trapezoids()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Trapezoids(NumericalIntegration model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("",
                    Resources.MethodsController_Newton_Пожалуйста_введите_корректно_начальные_данные);
                return View(model);
            }
            NumericalMethods method = new NumericalMethods();
            try
            {
                model.Result = method.MethodOfTrapezoids(model.Function, model.A, model.B,model.N);

                if (model.Result.Equals(Double.NaN))
                {
                    ModelState.AddModelError("",
                        Resources.MethodsController_Chord_Решение_не_найдено__Произошло_деление_на_ноль_);
                    return View(model);
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", Resources.MethodsController_Chord_Метод_расходится);
                return View(model);
            }

            if (!String.IsNullOrEmpty(model.Function))
            {
                ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                 Server.UrlEncode("integrate sqrt(" + model.Function + ")dx trapezoidal rule x=" + model.A + ".." + model.B);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Graph()
        {
            return View();
        }
    }
}