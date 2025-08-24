using MortgageCalculator.Bll.Services;
using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
	public class AmortizationController : Controller
	{
		private readonly IMortgageBlService _mortgageService;
		public AmortizationController(IMortgageBlService mortgageService)
		{
			_mortgageService = mortgageService;
		}

		public ActionResult Amortization()
		{
			var amortizationList = TempData["MortgageCalculationData"] as MortgagewithCalculationDto;
			if (amortizationList == null)
				return RedirectToAction("Index","Home");
			return View(amortizationList);
		}	
	}
}