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
    public class HomeController : Controller
    {
		private readonly IMortgageBlService _mortgageService;
		public HomeController(IMortgageBlService mortgageService)
		{
			_mortgageService = mortgageService;
		}
		public ActionResult Index()
        {	
			BaseResponse<MortgageHomepageDto> result = _mortgageService.GetAllMortgageCalculations();
			if(result.isSuccess)
			{
				return View(result.Result);
			}
			else
			{
				ViewBag.ErrorMessage = String.Concat( result.HttpStatusCode, result.ErrorInfo);
				return View("Error");
			}			
        }

        [HttpPost]
        public async Task<ActionResult> Index(MortgageHomepageDto mortgageDto) 
		{
			if (ModelState.IsValid)
			{					
				BaseResponse<MortgagewithCalculationDto> result = await _mortgageService.InsertMortgage(mortgageDto.Mortgage);
				if(result.isSuccess)
				{
					TempData["MortgageCalculationData"] = result.Result;
					return RedirectToAction("Amortization", "Amortization");
				}
				else
				{
					ViewBag.ErrorMessage = String.Concat(result.HttpStatusCode, result.ErrorInfo);
					return View("Error");
				}	
			}
			else
			{
				ViewBag.Message = "Please correct the errors and try again.";
			}
			return View(new MortgageHomepageDto() { Mortgage = null, MortgageHistory = null });
		}

		[HttpPost]
		public  ActionResult ViewMortgage(int mortgageId)
		{
			BaseResponse<MortgagewithCalculationDto> result = _mortgageService.GetMortageDetailsbyId(mortgageId);
			if (result.isSuccess)
			{
				TempData["MortgageCalculationData"] = result.Result;
				return RedirectToAction("Amortization", "Amortization");
			}
			else
			{
				ViewBag.Message = result.ErrorInfo;
				return View("Index", new MortgageHomepageDto() { Mortgage = null, MortgageHistory = null });
			}
		}

		[HttpGet]
		public ActionResult Index(string sortBy = "default", string sortOrder = "asc")
		{
			BaseResponse<MortgageHomepageDto> result = _mortgageService.GetAllMortgageCalculations(sortBy, sortOrder);
			ViewBag.CurrentSort = sortBy;
			ViewBag.SortOrder = sortOrder == "asc" ? "desc" : "asc";
			if(result.isSuccess)
			{
				return View(result.Result);
			}
			else
			{
				ViewBag.ErrorMessage = String.Concat( result.HttpStatusCode, result.ErrorInfo);
				return View("Error");
			}
		}
	}
}