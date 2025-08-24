using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Validations
{
	public class MortgageEndDateValidation : ValidationAttribute
	{
		private readonly string _endDatePropertyName;
		private readonly string _startDatePropertyName;
        public MortgageEndDateValidation(string endDatePropertyName, string startDatePropertyName)
        {
            _endDatePropertyName = endDatePropertyName;
			_startDatePropertyName = startDatePropertyName;
        }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var endDateProperty = validationContext.ObjectType.GetProperty(_endDatePropertyName);
			var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

			if (endDateProperty == null || startDateProperty == null)
			{
				return new ValidationResult($"Invalid Dates property");
			}

			var endDateValue = endDateProperty.GetValue(validationContext.ObjectInstance, null);
			var startDateValue = startDateProperty.GetValue(validationContext.ObjectInstance, null);

			if (!(endDateValue is DateTime endDate) || !(startDateValue is DateTime startDate))
			{
				return new ValidationResult("Invalid date values.");
			}

			// Start date should be today or later
			if (endDate.Date < startDate.Date)
			{
				return new ValidationResult("End date must be later that Start date");
			}
			return ValidationResult.Success;
		}
	}
}
