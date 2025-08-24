using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
	public class MortgageHistoryDto
	{		
		public int MortgageId { get; set; }

		[Required, MaxLength(50)]
		public string MortgageName { get; set; }

		[Required, Range(1, int.MaxValue)]
		public int PrincipalAmount { get; set; }

		[Required, Range(1, int.MaxValue)]
		public decimal RateofInterest { get; set; }

		[Required, Range(1, int.MaxValue)]
		public int TermsInYears { get; set; }

		[Required, Range(1, int.MaxValue)]
		public decimal TotalAmount { get; set; }

		[Required, Range(1, int.MaxValue)]
		public decimal TotalInterest { get; set; }
	}
}
