using System.Data.Entity;
using MortgageCalculator.Dll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dll.Data
{
	public class MortgageDataContext : DbContext
	{
		public MortgageDataContext() : base("name=MortgageDatabase") // connection string name from config
		{
		}
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{			
		//	optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MortgageDb;Trusted_Connection=True;");
		//}

		public DbSet<Mortgage> Mortgages { get; set; }
		public DbSet<InterestDetails> InterestDetails { get; set; }
		public DbSet<MortgageFees> MortgageFees { get; set; }	
		public DbSet<MonthlyAmortizations> MonthlyAmortizations { get; set; }
	}
}
