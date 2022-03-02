using Business.Abstract;
using Dtos.Calculator;
using Entities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }


        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll()
        {
            List<CalculatorDto> result = _calculatorService.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(CalculatorDto input)
        {
            Result result = _calculatorService.Add(input);
            return Json(result);
        }
        public async Task<JsonResult> Calculate(CalculatorDto input)
        {
            var result = await _calculatorService.Calculate(input);
            return Json(result);
        }
    }
}