using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathСalculator.Domain.Methods;
using MathСalculator.WebUI.Models;
using MathСalculator.WebUI.Properties;
using Novacode;

namespace MathСalculator.WebUI.Controllers
{
    public class IterationController : Controller
    {
        #region Итерационные методы

        [HttpGet]
        public ViewResult Iteration()
        {
            return View();
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
                ModelState.AddModelError("",
                    Resources.MethodsController_Newton_Пожалуйста_введите_корректно_начальные_данные);
                return View(model);
            }
            string resultTxt = string.Empty;
            SimpleIterationMethod method = new SimpleIterationMethod();
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
            SimpleIterationMethod method = new SimpleIterationMethod();
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
            SimpleIterationMethod method = new SimpleIterationMethod();
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

        public FileResult GetFile(string path)
        {

            string file_path = Server.MapPath("~/Content/" + path);
            string file_type = "application/msword";
            return File(file_path, file_type, path);
        }
        #endregion
    }
}