using MortgageCalculator.Dll.Entities;
using MortgageCalculator.Dll.Repos;
using MortgageCalculator.Dto;
using MortgageCalculator.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculator.Bll.Services
{
	public class MortgageBLService : IMortgageBlService
	{
		private readonly IMortgageRepo _mortgageRepo;
		public MortgageBLService(IMortgageRepo mortgageRepo)
		{
			_mortgageRepo = mortgageRepo;
		}

		public BaseResponse<MortgageHomepageDto> GetAllMortgageCalculations()
		{
			BaseResponse<MortgageHomepageDto> response;
			try
			{
				var mortgagesList = _mortgageRepo.GetAllMortgageCalculationQueryable().ToList();

				if (mortgagesList == null || mortgagesList.Count == 0)
				{
					return new BaseResponse<MortgageHomepageDto>()
					{
						isSuccess = false,
						Result = null,
						ErrorInfo = "No mortgage calculations found.",
						HttpStatusCode = 404
					};
				}

				response = new BaseResponse<MortgageHomepageDto>()
				{
					isSuccess = true,
					Result = new MortgageHomepageDto() { Mortgage = null, MortgageHistory = MapToHistoryDto(mortgagesList) },
					ErrorInfo = null,
					HttpStatusCode = 200
				};
			}
			catch (Exception ex)
			{
				response = new BaseResponse<MortgageHomepageDto>()
				{
					isSuccess = false,
					Result = null,
					ErrorInfo = ex.Message,
					HttpStatusCode = 500
				};
			}

			return response;
		}
		public BaseResponse<MortgageHomepageDto> GetAllMortgageCalculations(string sortBy, string sortOrder)
		{
			BaseResponse<MortgageHomepageDto> response;
			try
			{
				var mortgagesquery = _mortgageRepo.GetAllMortgageCalculationQueryable();

				if (mortgagesquery == null)
				{
					return new BaseResponse<MortgageHomepageDto>()
					{
						isSuccess = false,
						Result = null,
						ErrorInfo = "No mortgage calculations found.",
						HttpStatusCode = 404
					};
				}
				switch (sortBy?.ToLower())
				{
					case "roi":
						mortgagesquery = sortOrder == "desc"
							? mortgagesquery.OrderByDescending(m => m.RateofInterest)
							: mortgagesquery.OrderBy(m => m.RateofInterest);
						break;

					case "repaymenttype":
						mortgagesquery = sortOrder == "desc"
							? mortgagesquery.OrderByDescending(m => m.InterestDetails.InterestRepayment)
							: mortgagesquery.OrderBy(m => m.InterestDetails.InterestRepayment);
						break;

					default:
						mortgagesquery = mortgagesquery.OrderBy(m => m.MortgageId); // default sort
						break;
				}
				response = new BaseResponse<MortgageHomepageDto>()
				{
					isSuccess = true,
					Result = new MortgageHomepageDto() { Mortgage = null, MortgageHistory = MapToHistoryDto(mortgagesquery.ToList()) },
					ErrorInfo = null,
					HttpStatusCode = 200
				};
			}
			catch (Exception ex)
			{
				response = new BaseResponse<MortgageHomepageDto>()
				{
					isSuccess = false,
					Result = null,
					ErrorInfo = ex.Message,
					HttpStatusCode = 500
				};
			}
			return response;
		}

		public async Task<BaseResponse<MortgagewithCalculationDto>> InsertMortgage(MortgageDto mortgage)
		{
			BaseResponse<MortgagewithCalculationDto> response;
			try
			{
				var mortageEntity = MapToMortgageEntity(mortgage);

				int result = await _mortgageRepo.SaveCalculation(mortageEntity);
				if (result > 0)
				{
					response = new BaseResponse<MortgagewithCalculationDto>()
					{
						isSuccess = true,
						Result = new MortgagewithCalculationDto
						{
							Mortgage = MapToMortgageDto(mortageEntity),
							TotalInterest = mortageEntity.TotalInterest,
							TotalRepaymentAmount = mortageEntity.TotalAmount,
							MonthlyAmortization = MapToMonthlyAmortizationDTO(mortageEntity.MonthlyAmortizations.ToList()),							
						},
						ErrorInfo = null,
						HttpStatusCode = 201
					}; 
				}
				else
				{
					response = new BaseResponse<MortgagewithCalculationDto>()
					{
						isSuccess = false,
						Result = null,
						ErrorInfo = "Failed to save mortgage calculation.",
						HttpStatusCode = 400
					};
				}
			}
			catch (Exception ex)
			{
				response = new BaseResponse<MortgagewithCalculationDto>()
				{
					isSuccess = false,
					Result = null,
					ErrorInfo = ex.Message,
					HttpStatusCode = 400
				};
			}

			return response;
		}

		public BaseResponse<MortgagewithCalculationDto> GetMortageDetailsbyId(int mortgageId)
		{
			BaseResponse<MortgagewithCalculationDto> response;
			try
			{
				var mortgage = _mortgageRepo.GetCalculationwithAmortization(mortgageId);
				if(mortgage == null)
				{
					response = new BaseResponse<MortgagewithCalculationDto>()
					{
						isSuccess = false,
						ErrorInfo = "Not Found.Invalid MortgageId provided",
						HttpStatusCode = 404,
						Result = null
					};
				}
				else
				{
					response = new BaseResponse<MortgagewithCalculationDto>()
					{
						isSuccess = true,
						ErrorInfo = null,
						HttpStatusCode = 200,
						Result = new MortgagewithCalculationDto
						{
							Mortgage = MapToMortgageDto(mortgage),
							TotalInterest = mortgage.TotalInterest,
							TotalRepaymentAmount = mortgage.TotalAmount,
							MonthlyAmortization = (mortgage.MonthlyAmortizations == null || mortgage.MonthlyAmortizations.Count == 0) ?
							 MapToMonthlyAmortizationDTO(CalculateMonthlyAmortization(mortgage.PrincipalAmount, mortgage.RateofInterest, mortgage.TermsInMonths, mortgage.InterestDetails.InterestRepayment))
							: MapToMonthlyAmortizationDTO(mortgage.MonthlyAmortizations.ToList()),
						}
					};
				}					
			}
			catch (Exception ex)
			{
				response = new BaseResponse<MortgagewithCalculationDto>()
				{
					isSuccess = false,
					ErrorInfo = ex.Message,
					HttpStatusCode = 400,
					Result = null
				};
			}
			return response;
		}
		private List<MortgageHistoryDto> MapToHistoryDto(List<Mortgage> entity)
		{

			return entity?.Select(e => new MortgageHistoryDto
			{
				MortgageId = e.MortgageId,
				MortgageName = e.MortgageName,
				PrincipalAmount = e.PrincipalAmount,
				RateofInterest = e.RateofInterest,
				TermsInYears = e.TermsInMonths/12,
				TotalAmount = e.TotalAmount,
				TotalInterest = e.TotalInterest
			}).ToList();
		}

		private Mortgage MapToMortgageEntity(MortgageDto dto)
		{
			return new Mortgage
			{
				MortgageId = dto.MortgageId,
				MortgageName = dto.MortgageName,
				PrincipalAmount = dto.PrincipalAmount,
				RateofInterest = dto.RateofInterest,
				TermsInMonths = dto.TermsInYears * 12,
				TotalAmount = CalculateTotalRePaymentAmt(dto.PrincipalAmount, dto.RateofInterest, dto.TermsInYears*12, dto.InterestDetails.InterestRepayment),
				TotalInterest = CalculateTotalInterest(dto.PrincipalAmount, dto.RateofInterest, dto.TermsInYears * 12, dto.InterestDetails.InterestRepayment),
				InterestDetails = dto.InterestDetails != null ? new InterestDetails
				{					
					EffectiveStartDate = dto.InterestDetails.EffectiveStartDate,
					EffectiveEndDate = dto.InterestDetails.EffectiveStartDate.AddYears(dto.TermsInYears),
					MortgageType = dto.InterestDetails.MortgageType,
					InterestRepayment = dto.InterestDetails.InterestRepayment,
					MortgageId = dto.InterestDetails.MortgageDetailsId
				} : null,
				MortgageFees = dto.MortgageFees.Select(f => new MortgageFees
				{
					FeesID = f.FeesID,
					FeesName = f.FeesName,
					FeesAmount = f.FeesAmount,
					MortgageDetailsId = f.MortgageDetailsId
				}).ToList(),
				MonthlyAmortizations = CalculateMonthlyAmortization(dto.PrincipalAmount, 
				dto.RateofInterest, dto.TermsInYears * 12, dto.InterestDetails.InterestRepayment)
			};
		}
		private MortgageDto MapToMortgageDto(Mortgage entity)
		{
			return new MortgageDto
			{
				MortgageId = entity.MortgageId,
				MortgageName = entity.MortgageName,
				PrincipalAmount = entity.PrincipalAmount,
				RateofInterest = entity.RateofInterest,
				TermsInYears = entity.TermsInMonths / 12,
				InterestDetails = entity.InterestDetails != null ? new InterestDetailsDto
				{					
					EffectiveStartDate = entity.InterestDetails.EffectiveStartDate,
					EffectiveEndDate = entity.InterestDetails.EffectiveEndDate,
					MortgageType = entity.InterestDetails.MortgageType,
					InterestRepayment = entity.InterestDetails.InterestRepayment,
					MortgageDetailsId = entity.InterestDetails.MortgageId
				} : null,
				MortgageFees = entity.MortgageFees?.Select(f => new MortgageFeesDto
				{
					FeesID = f.FeesID,
					FeesName = f.FeesName,
					FeesAmount = f.FeesAmount,
					MortgageDetailsId = f.MortgageDetailsId
				}).ToList()
			};
		}
		
		private List<MonthlyAmortizationDto> MapToMonthlyAmortizationDTO(List<MonthlyAmortizations> entity)
		{			
			var monthlyAmortization = entity?.Select((emi,i) => new MonthlyAmortizationDto
										{
											PaymentCount = emi.PaymentCount,
											EmiAmount = emi.EmiAmount,
											MonthlyInterest = emi.MonthlyInterest,
											MonthlyPrincipal = emi.MonthlyPrincipal,
											OpeningBalance = emi.OpeningBalance,
											OutStandingPrincipal = emi.OutStandingPrincipal
										}).ToList();
			return monthlyAmortization;
		}
		private decimal CalculateEMIofFixedIntRate(int principal, decimal rate, int terms)
		{
			decimal monthlyRoi = (rate/100m) / 12m ;

			//formula = P * r * (1+r)^n / ((1+r)^n -1)
			var emi = (principal * monthlyRoi * (decimal)Math.Pow((double)(1 + monthlyRoi), terms))
					/ ((decimal)Math.Pow((double)(1 + monthlyRoi), terms) - 1);
			return Math.Round(emi, 2);
		}

		private decimal CalculateTotalRePaymentAmt(int principal, decimal rate, int terms,MortgageEnum.InterestRepayment repaymentType)
		{
			if (repaymentType == MortgageEnum.InterestRepayment.InterestOnly)
			{
				return Math.Round(CalculateTotalInterest(principal,rate,terms,repaymentType) + principal);
			}
			var totalRepayment = CalculateEMIofFixedIntRate(principal, rate, terms) * terms;
			return Math.Round(totalRepayment, 2);
		}

		private decimal CalculateTotalInterest(int principal, decimal rate, int terms,MortgageEnum.InterestRepayment repaymentType)
		{	
			if(repaymentType == MortgageEnum.InterestRepayment.InterestOnly)
			{
				return Math.Round(((principal * rate) / 100) * (terms/12));
			}
				
			var totalInterest = CalculateTotalRePaymentAmt(principal, rate, terms,repaymentType) - principal;
			return Math.Round(totalInterest, 2);
		}

		private List<MonthlyAmortizations> CalculateMonthlyAmortization(int principal, decimal rate, int terms,MortgageEnum.InterestRepayment interestRepayment)
		{
			if(interestRepayment == MortgageEnum.InterestRepayment.InterestOnly)
			{
				return CalculateMonthlyAmortizationforInterestOnly(principal, rate, terms);
			}			
			var amortizationList = new List<MonthlyAmortizations>();
			decimal monthlyRoi = (rate / 100m) / 12m;
			decimal emi = CalculateEMIofFixedIntRate(principal, rate, terms);
			decimal outstandingBalance = principal;
			for (int month = 1; month <= terms; month++)
			{
				decimal interestPayment = Math.Round(outstandingBalance * monthlyRoi, 2);
				decimal principalPayment = Math.Round(emi - interestPayment, 2);
				outstandingBalance -= principalPayment;
				amortizationList.Add(new MonthlyAmortizations
				{
					EmiAmount = emi,
					PaymentCount = month,
					MonthlyInterest = interestPayment,
					MonthlyPrincipal = principalPayment,
					OpeningBalance = outstandingBalance + principalPayment,
					OutStandingPrincipal = ((int)outstandingBalance <= 0) ? 0 : outstandingBalance
				});
			} 
			return amortizationList;
		}
		
		private List<MonthlyAmortizations> CalculateMonthlyAmortizationforInterestOnly(int principal, decimal rate, int terms)
		{
			var amortizationList = new List<MonthlyAmortizations>();

			decimal monthlyRoi = (rate / 100m) / 12m;
			decimal interestPayment = Math.Round(principal * monthlyRoi, 2);
			decimal outstandingBalance = principal;
			for (int month = 1; month <= terms; month++)
			{
				decimal principalPayment = (month == terms) ? principal : 0;
				decimal emi = interestPayment + principalPayment;
				outstandingBalance -= principalPayment;
				amortizationList.Add(new MonthlyAmortizations
				{
					EmiAmount = emi,
					PaymentCount = month,
					MonthlyInterest = interestPayment,
					MonthlyPrincipal = principalPayment,
					OpeningBalance = outstandingBalance + principalPayment,
					OutStandingPrincipal = ((int)outstandingBalance <= 0) ? 0 : outstandingBalance
				});
			}
			return amortizationList;
		}
	}
}
