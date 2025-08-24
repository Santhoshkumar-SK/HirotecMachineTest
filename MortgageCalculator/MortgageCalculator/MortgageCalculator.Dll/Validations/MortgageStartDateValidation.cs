using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Validations
{
	public class MortgageStartDateValidation : ValidationAttribute
	{
		private readonly string _startDatePropertyName;
		public MortgageStartDateValidation(string startDatePropertyName)
		{
			_startDatePropertyName = startDatePropertyName;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

			if (startDateProperty == null)
			{
				return new ValidationResult($"Invalid property: {_startDatePropertyName}");
			}

			var startDateValue = startDateProperty.GetValue(validationContext.ObjectInstance, null);

			if (!(startDateValue is DateTime startDate))
			{
				return new ValidationResult("Invalid start date value.");
			}

			// Start date should be today or later
			if (startDate.Date <= DateTime.Now.Date)
			{
				return new ValidationResult("Start date must be today or later.");
			}
			return ValidationResult.Success;
		} 

	}
}
