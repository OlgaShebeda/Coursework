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
    public class NumericIntegralController : Controller
    {
        #region Численное интегрирование

        [HttpGet]
        public ActionResult Simpson()
        {
            return View();
        }

        [HttpGet]
        public ViewResult NumericIntegr()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Method38()
        {
            return View();
        }


        [HttpPost]
        public ViewResult Method38(NumericalIntegration model)
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
                model.Result = method.Method_3_8(model.Function, model.A, model.B, model.N);

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
            return View(model);
        }


        [HttpGet]
        public ViewResult Rectangles()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Rectangles(RectanglesIntegration model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Пожалуйста,введите корректно начальные данные");
                return View(model);
            }

            NumericalMethods method = new NumericalMethods();
            try
            {

                switch (model.Method)
                {
                    case "Right":
                        model.Result = method.RightRectangles(model.Function, model.A, model.B, model.N);
                        ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                         Server.UrlEncode("integrate sqrt(" + model.Function +
                                                          ")dx right endpoint method x=" + model.A +
                                                          ".." + model.B);
                        break;
                    case "Midle":
                        model.Result = method.MidleRectangles(model.Function, model.A, model.B, model.N);
                        ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                         Server.UrlEncode("integrate sqrt(" + model.Function + ")dx midpoint method x=" +
                                                          model.A +
                                                          ".." + model.B);
                        break;
                    case "Left":
                        model.Result = method.LeftRectangles(model.Function, model.A, model.B, model.N);
                        ViewBag.Adress = "http://www.wolframalpha.com/input/?i=" +
                                         Server.UrlEncode("integrate sqrt(" + model.Function +
                                                          ")dx left endpoint method x=" + model.A +
                                                          ".." + model.B);
                        break;
                }
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

            return View(model);
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
                model.Result = method.MethodSimpsona(model.Function, model.A, model.B, model.N);

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
                                 Server.UrlEncode("integrate sqrt(" + model.Function + ")dx Simpson's rule x=" + model.A +
                                                  ".." + model.B);
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
                model.Result = method.MethodOfTrapezoids(model.Function, model.A, model.B, model.N);

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
                                 Server.UrlEncode("integrate sqrt(" + model.Function + ")dx trapezoidal rule x=" +
                                                  model.A + ".." + model.B);
            }
            return View(model);
        }
        #endregion
    }
}