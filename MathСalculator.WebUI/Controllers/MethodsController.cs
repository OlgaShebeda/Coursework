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

namespace MathСalculator.WebUI.Controllers
{
    public class MethodsController : Controller
    {

        private IUserRepository _userRepos;
        private int PostsPerPage = 3;


        //
        // GET: /Methods/
        [HttpGet, ValidateInput(false)]
        public ActionResult Index()
        {
            ViewBag.Browser = true;
            string user_agent = HttpContext.Request.UserAgent;
            string browser = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
            if (user_agent != browser)
                ViewBag.Browser = false;
            return View();
        }

        [HttpGet]
        public ActionResult GCD()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MathCalc()
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
                double[] Matr = { };
                double[,] Matrix = new double[model1.countRows, model1.countVariable];
                var count = ints.Count() / model1.countRows;
                for (int i = 0; i < model1.countRows; i++)
                {
                    Matr = ints.Skip(i * Matr.Length).Take(count).ToArray();
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
                ModelState.AddModelError("", "Пожалуйста введите корректно начальные данные");
                return View(model);
            }
            COfSecantsMethod method = new COfSecantsMethod();
            try
            {
                model.Result = method.OfSecantsMethod(model.Fuctions, model.X0, model.X1, model.Epsilon);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Метод расходится");
                return View(model);
            }

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
                ModelState.AddModelError("", "Пожалуйста введите корректно начальные данные");
                return View(model);
            }
            CChordMethod method = new CChordMethod();
            try
            {
                model.Result = method.ChordMethod(model.Fuctions, model.X0,model.X1, model.Epsilon);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Метод расходится");
                return View(model);
            }

            return View(model);
        }



        [HttpPost]
        public ViewResult Newton(SimpleIterationModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Пожалуйста введите корректно начальные данные");
                return View(model);
            }
            CNewtonsMethod method = new CNewtonsMethod();
            try
            {
                model.Result = method.NewtonsMethod(model.Fuctions, model.X0, model.Epsilon);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Метод расходится");
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public ViewResult SimpleIteration(SimpleIterationModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Пожалуйста введите корректно начальные данные");
                return View(model);
            }
            SimpleIterationMethod method = new SimpleIterationMethod();
            try
            {
                model.Result = method.Calc(model.Fuctions, model.X0, model.Epsilon);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Метод расходится");
                return View(model);
            }
            
            return View(model);
        }
    }
}