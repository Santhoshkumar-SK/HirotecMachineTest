using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Entities
{
	public class MonthlyAmortizations
	{
		[Key]
		public long PaymentId { get; set; }
		[Required]
		public int PaymentCount { get; set; }
		[Required]
		public decimal OpeningBalance { get; set; }
		[Required]
		public decimal EmiAmount { get; set; }
		[Required]
		public decimal MonthlyPrincipal { get; set; }
		[Required]
		public decimal MonthlyInterest { get; set; }
		[Required]
		public decimal OutStandingPrincipal { get; set; }
		public int MortgageDetailsId { get; set; }

		[ForeignKey(nameof(MonthlyAmortizations.MortgageDetailsId))]
		public Mortgage MortgageDetails { get; set; }
	}
}
