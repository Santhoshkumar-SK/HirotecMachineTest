
using MortgageCalculator.Dll.Data;
using MortgageCalculator.Dll.Entities;
using MortgageCalculator.Dto;
using MortgageCalculator.Dto.CustomException;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Repos
{
	public class MortgageRepo : IMortgageRepo
	{
		MortgageDataContext _context;
		public MortgageRepo(MortgageDataContext context)
		{
			_context = context;
		}
				
		public IQueryable<Mortgage> GetAllMortgageCalculationQueryable()
		{
			return _context.Mortgages.AsQueryable();
		}

		public Mortgage GetCalculationwithAmortization(int mortgageId)
		{
			return _context.Mortgages.
					Include(am => am.MonthlyAmortizations)
					.Include(fe => fe.MortgageFees)
					.Where(mor => mor.MortgageId == mortgageId)
					.FirstOrDefault()
					;
		}

		public async Task<int> SaveCalculation(Mortgage mortgage) 
		{
			try
			{
				_context.Mortgages.Add(mortgage);
				return await _context.SaveChangesAsync();
			}
			catch (DbEntityValidationException ex)
			{
				string exceptionmessage = "DbEntityValidationException ";
				foreach (var eve in ex.EntityValidationErrors)
				{					
					foreach (var ve in eve.ValidationErrors)
					{						
						exceptionmessage += $"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}\t";
					}
				}
				throw new MortgageCalculatorCustomException(exceptionmessage);
			}
			catch (Exception ex)
			{
				throw ex;
			}
						
		}		
	}
}
