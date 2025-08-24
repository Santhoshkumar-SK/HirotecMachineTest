using MortgageCalculator.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageCalculator.Bll.Services
{
	public interface IMortgageBlService
	{
		BaseResponse<MortgageHomepageDto> GetAllMortgageCalculations();
		BaseResponse<MortgageHomepageDto> GetAllMortgageCalculations(string sortBy, string sortOrder);
		Task<BaseResponse<MortgagewithCalculationDto>> InsertMortgage(MortgageDto mortgage);
		BaseResponse<MortgagewithCalculationDto> GetMortageDetailsbyId(int mortgageId);
	}
}
