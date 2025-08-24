using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
	public class MortgageHomepageDto
	{
		public MortgageDto Mortgage { get; set; }
		public List<MortgageHistoryDto> MortgageHistory { get; set; }
	}
}
