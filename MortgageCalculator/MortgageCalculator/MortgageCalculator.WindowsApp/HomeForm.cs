using MortgageCalculator.Bll.Services;
using MortgageCalculator.Dll.Data;
using MortgageCalculator.Dll.Repos;
using MortgageCalculator.Dto;
using MortgageCalculator.Dto.Enum;
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
	public partial class HomeForm : Form
	{
		private readonly IMortgageBlService _mortgageService;
		private string _currentSort = "roi";
		private string _sortOrder = "asc";
			
		public HomeForm()
		{
			InitializeComponent();

			var dbContext = new MortgageDataContext();
			var repo = new MortgageRepo(dbContext);
			_mortgageService = new MortgageBLService(repo);
		}

		private async void calculateBtn_Click(object sender, EventArgs e)
		{
			try
			{
				MortgageDto mortgageDto = new MortgageDto()
				{
					MortgageName = mortgageNameTextBox.Text.ToString(),
					PrincipalAmount = Convert.ToInt32(principleAmtTxtBox.Text),
					RateofInterest = Convert.ToDecimal(roiTextBox.Text),
					TermsInYears = Convert.ToInt32(termsinYearsTxtBox.Text),
					InterestDetails = new InterestDetailsDto()
					{
						MortgageType = (MortgageEnum.MortgageType)interestTypeComboBox.SelectedItem,
						InterestRepayment = (MortgageEnum.InterestRepayment)repaymentTypeComboBox.SelectedItem
					},
					MortgageFees = new List<MortgageFeesDto>()
				{
					new MortgageFeesDto()
					{
						FeesName = feesNameTextBox.Text.ToString(),
						FeesAmount = Convert.ToDecimal(feesAmountTextBox.Text)
					},
				}
				};
				BaseResponse<MortgagewithCalculationDto> result = await _mortgageService.InsertMortgage(mortgageDto);
				if (result.isSuccess)
				{
					AmortizationForm calcForm = new AmortizationForm(result.Result);
					calcForm.FormClosed += (s, args) => ClearHomeForm();
					calcForm.ShowDialog();
				}
				else
				{
					MessageBox.Show(String.Concat(result.HttpStatusCode, result.ErrorInfo), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
		}

		private void HomeForm_Load(object sender, EventArgs e)
		{
			interestTypeComboBox.DataSource = Enum.GetValues(typeof(MortgageEnum.MortgageType));
			repaymentTypeComboBox.DataSource = Enum.GetValues(typeof(MortgageEnum.InterestRepayment));
			LoadMortgageHistory("default",_sortOrder);
		}

		private void LoadMortgageHistory(string currentsort,string sortOrder)
		{
			BaseResponse<MortgageHomepageDto> result = _mortgageService.GetAllMortgageCalculations(currentsort, sortOrder);
			if (result.isSuccess)
			{
				mortgageHistoryGrid.DataSource = result.Result.MortgageHistory;
				return;
			}
			else
			{
				MessageBox.Show(String.Concat(result.HttpStatusCode, result.ErrorInfo), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		private void ClearHomeForm()
		{
			mortgageNameTextBox.Text = String.Empty;
			principleAmtTxtBox.Text = String.Empty;
			roiTextBox.Text = String.Empty;
			termsinYearsTxtBox.Text = String.Empty;
			feesNameTextBox.Text = String.Empty;
			feesAmountTextBox.Text = String.Empty;
			interestTypeComboBox.SelectedIndex = -1;
			repaymentTypeComboBox.SelectedIndex = -1;
			LoadMortgageHistory("default", _sortOrder);
		}

		private void mortgageHistoryGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{			
			
			try
			{
					if (e.RowIndex < 0)
					{
						_sortOrder = (_sortOrder == "asc") ? "desc" : "asc";
						LoadMortgageHistory(_currentSort,_sortOrder);
						return;
					}

					DataGridViewRow row = mortgageHistoryGrid.Rows[e.RowIndex];
					int mortgageId = Convert.ToInt32(row.Cells["mortgageId"].Value);

					BaseResponse<MortgagewithCalculationDto> result = _mortgageService.GetMortageDetailsbyId(mortgageId);
					if (result.isSuccess) { 
						AmortizationForm calcForm = new AmortizationForm(result.Result);						
						calcForm.FormClosed += (s, args) => ClearHomeForm();
						calcForm.ShowDialog(); 						
					}
					else
					{
						MessageBox.Show(String.Concat(result.HttpStatusCode, result.ErrorInfo), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}			

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

	}
}
