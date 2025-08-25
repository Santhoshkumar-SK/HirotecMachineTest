using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MortgageCalculator.WindowsApp
{
	public partial class AmortizationForm : Form
	{
		MortgagewithCalculationDto mortgageData;
		public AmortizationForm(MortgagewithCalculationDto mortgageDto)
		{
			mortgageData = mortgageDto;
			InitializeComponent();
		}
		public AmortizationForm()
		{
			InitializeComponent();
		}

		private void AmortizationForm_Load(object sender, EventArgs e)
		{
			try
			{
				amortizationGridView.DataSource = mortgageData.MonthlyAmortization;
				mortgageNameTextBox.Text = mortgageData.Mortgage.MortgageName;
				principleAmtTxtBox.Text = mortgageData.Mortgage.PrincipalAmount.ToString("C2");
				roiTextBox.Text = mortgageData.Mortgage.RateofInterest.ToString("N2");
				termsinYearsTxtBox.Text = mortgageData.Mortgage.TermsInYears.ToString();
				repaymentTypeTextBox.Text = mortgageData.Mortgage.InterestDetails.MortgageType.ToString();
				interestTypeTextBox.Text = mortgageData.Mortgage.InterestDetails.InterestRepayment.ToString();
				totalInterestTextBox.Text = mortgageData.TotalInterest.ToString("C2");
				totalRepayementTextBox.Text = mortgageData.TotalRepaymentAmount.ToString("C2");

				mortgageNameTextBox.Enabled= false;
				principleAmtTxtBox.Enabled = false;
				roiTextBox.Enabled = false;
				termsinYearsTxtBox.Enabled = false;
				repaymentTypeTextBox.Enabled = false;
				interestTypeTextBox.Enabled = false;
				totalRepayementTextBox.Enabled = false;
				totalInterestTextBox.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}	
	}
}
