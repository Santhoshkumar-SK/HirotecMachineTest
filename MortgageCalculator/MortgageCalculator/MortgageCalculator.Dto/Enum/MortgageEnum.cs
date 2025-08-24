using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto.Enum
{
	public class MortgageEnum
	{
		public enum MortgageType
		{
			Variable,
			Fixed
		}

		public enum InterestRepayment
		{
			InterestOnly,
			PrincipalAndInterest
		}
	}
}
