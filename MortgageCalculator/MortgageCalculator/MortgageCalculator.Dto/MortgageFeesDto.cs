using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
	public class MortgageFeesDto
	{
		public int FeesID { get; set; }

		[Required]
		public string FeesName { get; set; }

		[Required, Range(1, int.MaxValue)]
		public decimal FeesAmount { get; set; }

		public int MortgageDetailsId { get; set; }
	}
}
