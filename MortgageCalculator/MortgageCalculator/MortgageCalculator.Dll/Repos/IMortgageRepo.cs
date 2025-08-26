using MortgageCalculator.Dll.Entities;
using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Repos
{
	public interface IMortgageRepo
	{		
		Task<int> SaveCalculation(Mortgage mortgage);
		IQueryable<Mortgage> GetAllMortgageCalculationQueryable();
		Mortgage GetCalculationwithAmortization(int mortgageId);
	}
}
