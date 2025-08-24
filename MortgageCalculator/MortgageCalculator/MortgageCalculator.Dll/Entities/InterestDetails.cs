using MortgageCalculator.Dll.Validations;
using MortgageCalculator.Dto.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Entities
{
	public class InterestDetails
	{
		[Key, ForeignKey("Mortgage")]
		public int MortgageId { get; set; }

		[Required(ErrorMessage = "Mortgage Start date is Required")]
		[MortgageStartDateValidation(nameof(EffectiveStartDate), ErrorMessage = "Invalid Start date")]
		public DateTime EffectiveStartDate { get; set; }

		[Required(ErrorMessage = "Mortgage Start date is Required")]
		[MortgageEndDateValidation(nameof(EffectiveEndDate),nameof(EffectiveStartDate), ErrorMessage = "Invalid Start date")]
		public DateTime EffectiveEndDate { get; set; }

		public MortgageEnum.MortgageType MortgageType { get; set; } = MortgageEnum.MortgageType.Fixed;
		
		public MortgageEnum.InterestRepayment InterestRepayment { get; set; } = MortgageEnum.InterestRepayment.PrincipalAndInterest;
		public virtual Mortgage Mortgage { get; set; }		
	}
}
