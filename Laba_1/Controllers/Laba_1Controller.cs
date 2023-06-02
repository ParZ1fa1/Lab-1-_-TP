using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laba_1.Models;

namespace Laba_1.Controllers
{
    public class Laba_1Controller : Controller
    {
        //
        // GET: /Laba_1/
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.Number = ' ';
            return View(new Calculator());
        }

        [HttpPost]
        public ViewResult Index(Calculator c, string click)
        {
            /*Динамическое значение*/
            double number = 3.00;
            ViewBag.Number = number;

            if (click == "calculate" && ModelState.IsValid)
            {
                /*Калькулятор*/
                switch (c.Sign)
                {
                    case '+':
                        c.Result = c.Operand_1 + c.Operand_2;
                        break;
                    case '-':
                        c.Result = c.Operand_1 - c.Operand_2;
                        break;
                    case '*':
                        c.Result = c.Operand_1 * c.Operand_2;
                        break;
                    case '/':
                        if (c.Operand_2 != 0)
                        {
                            c.Result = c.Operand_1 / c.Operand_2;
                        }
                        break;
                }
            }
            else
            {
                if (click == "clear")
                {
                    c.Operand_1 = 0;
                    c.Operand_2 = 0;
                    c.Result = 0;
                }
            }

            Session["equation"] = c.Operand_1.ToString() + c.Sign.ToString() + c.Operand_2.ToString() + " = " + c.Result.ToString();
            Session["sign"] = c.Sign.ToString();
            return View(c);
        }

        public ViewResult Equation()
        {
            if (Session["equation"] != null)
            {
                string Result = Session["equation"].ToString();
                string ResultInfo = " ";
                switch (Session["sign"])
                {
                    case "+":
                        ResultInfo = Result.Substring(0, Result.LastIndexOf('+')) + " плюс " + Result.Substring(Result.LastIndexOf('+') + 1);
                        break;
                    case "-":
                        ResultInfo = Result.Substring(0, Result.LastIndexOf('-')) + " минус " + Result.Substring(Result.LastIndexOf('-') + 1);
                        break;
                    case "*":
                        ResultInfo = Result.Substring(0, Result.LastIndexOf('*')) + " умножить " + Result.Substring(Result.LastIndexOf('*') + 1);
                        break;
                    case "/":
                        ResultInfo = Result.Substring(0, Result.LastIndexOf('/')) + " разделить " + Result.Substring(Result.LastIndexOf('/') + 1);
                        break;
                }
                ViewBag.Equat = ResultInfo;
            }
            return View();
        }
    }
}
