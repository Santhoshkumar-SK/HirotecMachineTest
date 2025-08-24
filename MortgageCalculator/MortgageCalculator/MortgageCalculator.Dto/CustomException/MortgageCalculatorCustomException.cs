using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto.CustomException
{
	public class MortgageCalculatorCustomException : Exception
	{
		public MortgageCalculatorCustomException() { }

		public MortgageCalculatorCustomException(string message)
			: base(message) { }

		public MortgageCalculatorCustomException(string message, Exception inner)
			: base(message, inner) { }
	}
}

