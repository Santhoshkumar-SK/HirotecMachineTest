using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
	public class MonthlyAmortizationDto
	{
		public int PaymentCount { get; set; }
		public decimal OpeningBalance { get; set; }
		public decimal EmiAmount { get; set; }
		public decimal MonthlyPrincipal { get; set; }
		public decimal MonthlyInterest { get; set; }
		public decimal OutStandingPrincipal { get; set; }
	}
}
