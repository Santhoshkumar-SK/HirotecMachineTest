using MortgageCalculator.Dto.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
	public class InterestDetailsDto
	{
		public int InterestID { get; set; }

		[Required]
		public DateTime EffectiveStartDate { get; set; } = DateTime.Now.AddDays(1);

		[Required]
		public DateTime EffectiveEndDate { get; set; }

		[Required]
		public MortgageEnum.MortgageType MortgageType { get; set; }

		[Required]
		public MortgageEnum.InterestRepayment InterestRepayment { get; set; }

		public decimal InterestRateDropPercentage { get; set; }
		public int MortgageDetailsId { get; set; }
	}	
}