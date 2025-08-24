using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Entities
{
	public class MortgageFees
	{
		[Key]
        public int FeesID { get; set; }
		public string FeesName { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Fees Amount must be greater than 0")]
		public decimal FeesAmount { get; set; }

		public int MortgageDetailsId { get; set; }
		
		[ForeignKey(nameof(MortgageFees.MortgageDetailsId))]
		public Mortgage MortgageDetails { get; set; }
	}
}
