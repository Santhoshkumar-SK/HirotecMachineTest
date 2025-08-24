using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
	public class MortgagewithCalculationDto
	{
		public MortgageDto Mortgage { get; set; }
		public decimal TotalRepaymentAmount { get; set; }
		public decimal TotalInterest { get; set; }
		public List<MonthlyAmortizationDto> MonthlyAmortization { get; set; }
	}
}
