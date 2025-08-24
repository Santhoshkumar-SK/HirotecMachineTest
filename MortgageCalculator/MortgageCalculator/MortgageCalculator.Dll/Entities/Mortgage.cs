using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MortgageCalculator.Dll.Entities
{
    public class Mortgage
    {
        [Key]
        public int MortgageId { get; set; }
        [Required(ErrorMessage ="Mortgage Name is Required"),MaxLength(50,ErrorMessage ="Mortgage Name length should less than or equal 50")]
        public string MortgageName { get; set; }

        [Required(ErrorMessage = "Principle Amount is Required")]
		[Range(1, int.MaxValue, ErrorMessage = "Principal Amount must be greater than 0")]
		public int PrincipalAmount { get; set; }

		[Required(ErrorMessage = "Rate of Interest is Required")]
		[Range(1, int.MaxValue, ErrorMessage = "Rate of Interest must be greater than 0")]
		public decimal RateofInterest { get; set; }

		[Required(ErrorMessage = "Terms In Months is Required")]
		[Range(1, int.MaxValue, ErrorMessage = "Terms In Months must be greater than 0")]
		public int TermsInMonths { get; set; }

		[Required(ErrorMessage = "Total Amount is Required")]
		[Range(1, int.MaxValue, ErrorMessage = "Total Amount must be greater than 0")]
		public decimal TotalAmount { get; set; }

		[Required(ErrorMessage = "Total Interest is Required")]
		[Range(1, int.MaxValue, ErrorMessage = "Total Interest must be greater than 0")]
		public decimal TotalInterest { get; set; }
        public virtual InterestDetails InterestDetails { get; set; }
		public ICollection<MortgageFees> MortgageFees { get; set; }
	}

  
}
