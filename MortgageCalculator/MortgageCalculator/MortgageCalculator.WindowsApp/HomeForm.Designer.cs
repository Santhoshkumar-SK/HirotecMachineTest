namespace MortgageCalculator.WindowsApp
{
	partial class HomeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mortgageNameLabel = new System.Windows.Forms.Label();
			this.mortgageNameTextBox = new System.Windows.Forms.TextBox();
			this.principleAmtTxtBox = new System.Windows.Forms.TextBox();
			this.principleAmtlabel = new System.Windows.Forms.Label();
			this.roiTextBox = new System.Windows.Forms.TextBox();
			this.rateofInterestLabel = new System.Windows.Forms.Label();
			this.termsinYearsTxtBox = new System.Windows.Forms.TextBox();
			this.temsLabel = new System.Windows.Forms.Label();
			this.repaymentTypeLabel = new System.Windows.Forms.Label();
			this.interestTypeLabel = new System.Windows.Forms.Label();
			this.feesnameLabel = new System.Windows.Forms.Label();
			this.feesAmtLabel = new System.Windows.Forms.Label();
			this.feesAmountTextBox = new System.Windows.Forms.TextBox();
			this.feesNameTextBox = new System.Windows.Forms.TextBox();
			this.interestTypeComboBox = new System.Windows.Forms.ComboBox();
			this.repaymentTypeComboBox = new System.Windows.Forms.ComboBox();
			this.calculateBtn = new System.Windows.Forms.Button();
			this.mortgageHistoryGrid = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.mortgageHistoryGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mortgageNameLabel
			// 
			this.mortgageNameLabel.AutoSize = true;
			this.mortgageNameLabel.Location = new System.Drawing.Point(32, 34);
			this.mortgageNameLabel.Name = "mortgageNameLabel";
			this.mortgageNameLabel.Size = new System.Drawing.Size(83, 13);
			this.mortgageNameLabel.TabIndex = 0;
			this.mortgageNameLabel.Text = "Mortgage Name";
			// 
			// mortgageNameTextBox
			// 
			this.mortgageNameTextBox.Location = new System.Drawing.Point(133, 31);
			this.mortgageNameTextBox.Name = "mortgageNameTextBox";
			this.mortgageNameTextBox.Size = new System.Drawing.Size(159, 20);
			this.mortgageNameTextBox.TabIndex = 1;
			// 
			// principleAmtTxtBox
			// 
			this.principleAmtTxtBox.Location = new System.Drawing.Point(419, 34);
			this.principleAmtTxtBox.Name = "principleAmtTxtBox";
			this.principleAmtTxtBox.Size = new System.Drawing.Size(82, 20);
			this.principleAmtTxtBox.TabIndex = 3;
			// 
			// principleAmtlabel
			// 
			this.principleAmtlabel.AutoSize = true;
			this.principleAmtlabel.Location = new System.Drawing.Point(318, 37);
			this.principleAmtlabel.Name = "principleAmtlabel";
			this.principleAmtlabel.Size = new System.Drawing.Size(86, 13);
			this.principleAmtlabel.TabIndex = 2;
			this.principleAmtlabel.Text = "Principle Amount";
			// 
			// roiTextBox
			// 
			this.roiTextBox.Location = new System.Drawing.Point(631, 34);
			this.roiTextBox.Name = "roiTextBox";
			this.roiTextBox.Size = new System.Drawing.Size(105, 20);
			this.roiTextBox.TabIndex = 5;
			// 
			// rateofInterestLabel
			// 
			this.rateofInterestLabel.AutoSize = true;
			this.rateofInterestLabel.Location = new System.Drawing.Point(536, 38);
			this.rateofInterestLabel.Name = "rateofInterestLabel";
			this.rateofInterestLabel.Size = new System.Drawing.Size(80, 13);
			this.rateofInterestLabel.TabIndex = 4;
			this.rateofInterestLabel.Text = "Rate of Interest";
			// 
			// termsinYearsTxtBox
			// 
			this.termsinYearsTxtBox.Location = new System.Drawing.Point(846, 35);
			this.termsinYearsTxtBox.Name = "termsinYearsTxtBox";
			this.termsinYearsTxtBox.Size = new System.Drawing.Size(71, 20);
			this.termsinYearsTxtBox.TabIndex = 7;
			// 
			// temsLabel
			// 
			this.temsLabel.AutoSize = true;
			this.temsLabel.Location = new System.Drawing.Point(758, 38);
			this.temsLabel.Name = "temsLabel";
			this.temsLabel.Size = new System.Drawing.Size(72, 13);
			this.temsLabel.TabIndex = 6;
			this.temsLabel.Text = "Terms in Year";
			// 
			// repaymentTypeLabel
			// 
			this.repaymentTypeLabel.AutoSize = true;
			this.repaymentTypeLabel.Location = new System.Drawing.Point(246, 79);
			this.repaymentTypeLabel.Name = "repaymentTypeLabel";
			this.repaymentTypeLabel.Size = new System.Drawing.Size(88, 13);
			this.repaymentTypeLabel.TabIndex = 8;
			this.repaymentTypeLabel.Text = "Repayment Type";
			// 
			// interestTypeLabel
			// 
			this.interestTypeLabel.AutoSize = true;
			this.interestTypeLabel.Location = new System.Drawing.Point(32, 77);
			this.interestTypeLabel.Name = "interestTypeLabel";
			this.interestTypeLabel.Size = new System.Drawing.Size(69, 13);
			this.interestTypeLabel.TabIndex = 9;
			this.interestTypeLabel.Text = "Interest Type";
			// 
			// feesnameLabel
			// 
			this.feesnameLabel.AutoSize = true;
			this.feesnameLabel.Location = new System.Drawing.Point(477, 79);
			this.feesnameLabel.Name = "feesnameLabel";
			this.feesnameLabel.Size = new System.Drawing.Size(61, 13);
			this.feesnameLabel.TabIndex = 10;
			this.feesnameLabel.Text = "Fees Name";
			// 
			// feesAmtLabel
			// 
			this.feesAmtLabel.AutoSize = true;
			this.feesAmtLabel.Location = new System.Drawing.Point(667, 79);
			this.feesAmtLabel.Name = "feesAmtLabel";
			this.feesAmtLabel.Size = new System.Drawing.Size(69, 13);
			this.feesAmtLabel.TabIndex = 11;
			this.feesAmtLabel.Text = "Fees Amount";
			// 
			// feesAmountTextBox
			// 
			this.feesAmountTextBox.Location = new System.Drawing.Point(742, 77);
			this.feesAmountTextBox.Name = "feesAmountTextBox";
			this.feesAmountTextBox.Size = new System.Drawing.Size(92, 20);
			this.feesAmountTextBox.TabIndex = 12;
			// 
			// feesNameTextBox
			// 
			this.feesNameTextBox.Location = new System.Drawing.Point(544, 74);
			this.feesNameTextBox.Name = "feesNameTextBox";
			this.feesNameTextBox.Size = new System.Drawing.Size(103, 20);
			this.feesNameTextBox.TabIndex = 13;
			// 
			// interestTypeComboBox
			// 
			this.interestTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.interestTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.interestTypeComboBox.FormattingEnabled = true;
			this.interestTypeComboBox.Location = new System.Drawing.Point(107, 74);
			this.interestTypeComboBox.Name = "interestTypeComboBox";
			this.interestTypeComboBox.Size = new System.Drawing.Size(121, 21);
			this.interestTypeComboBox.TabIndex = 14;
			// 
			// repaymentTypeComboBox
			// 
			this.repaymentTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.repaymentTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.repaymentTypeComboBox.FormattingEnabled = true;
			this.repaymentTypeComboBox.Location = new System.Drawing.Point(340, 74);
			this.repaymentTypeComboBox.Name = "repaymentTypeComboBox";
			this.repaymentTypeComboBox.Size = new System.Drawing.Size(121, 21);
			this.repaymentTypeComboBox.TabIndex = 15;
			// 
			// calculateBtn
			// 
			this.calculateBtn.Location = new System.Drawing.Point(846, 79);
			this.calculateBtn.Name = "calculateBtn";
			this.calculateBtn.Size = new System.Drawing.Size(74, 22);
			this.calculateBtn.TabIndex = 16;
			this.calculateBtn.Text = "Calculate";
			this.calculateBtn.UseVisualStyleBackColor = true;
			this.calculateBtn.Click += new System.EventHandler(this.calculateBtn_Click);
			// 
			// mortgageHistoryGrid
			// 
			this.mortgageHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mortgageHistoryGrid.Location = new System.Drawing.Point(84, 132);
			this.mortgageHistoryGrid.Name = "mortgageHistoryGrid";
			this.mortgageHistoryGrid.Size = new System.Drawing.Size(746, 286);
			this.mortgageHistoryGrid.TabIndex = 18;
			this.mortgageHistoryGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mortgageHistoryGrid_CellContentClick);
			// 
			// HomeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 450);
			this.Controls.Add(this.mortgageHistoryGrid);
			this.Controls.Add(this.calculateBtn);
			this.Controls.Add(this.repaymentTypeComboBox);
			this.Controls.Add(this.interestTypeComboBox);
			this.Controls.Add(this.feesNameTextBox);
			this.Controls.Add(this.feesAmountTextBox);
			this.Controls.Add(this.feesAmtLabel);
			this.Controls.Add(this.feesnameLabel);
			this.Controls.Add(this.interestTypeLabel);
			this.Controls.Add(this.repaymentTypeLabel);
			this.Controls.Add(this.termsinYearsTxtBox);
			this.Controls.Add(this.temsLabel);
			this.Controls.Add(this.roiTextBox);
			this.Controls.Add(this.rateofInterestLabel);
			this.Controls.Add(this.principleAmtTxtBox);
			this.Controls.Add(this.principleAmtlabel);
			this.Controls.Add(this.mortgageNameTextBox);
			this.Controls.Add(this.mortgageNameLabel);
			this.Name = "HomeForm";
			this.Text = "Home";
			this.Load += new System.EventHandler(this.HomeForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.mortgageHistoryGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label mortgageNameLabel;
		private System.Windows.Forms.TextBox mortgageNameTextBox;
		private System.Windows.Forms.TextBox principleAmtTxtBox;
		private System.Windows.Forms.Label principleAmtlabel;
		private System.Windows.Forms.TextBox roiTextBox;
		private System.Windows.Forms.Label rateofInterestLabel;
		private System.Windows.Forms.TextBox termsinYearsTxtBox;
		private System.Windows.Forms.Label temsLabel;
		private System.Windows.Forms.Label repaymentTypeLabel;
		private System.Windows.Forms.Label interestTypeLabel;
		private System.Windows.Forms.Label feesnameLabel;
		private System.Windows.Forms.Label feesAmtLabel;
		private System.Windows.Forms.TextBox feesAmountTextBox;
		private System.Windows.Forms.TextBox feesNameTextBox;
		private System.Windows.Forms.ComboBox interestTypeComboBox;
		private System.Windows.Forms.ComboBox repaymentTypeComboBox;
		private System.Windows.Forms.Button calculateBtn;
		private System.Windows.Forms.DataGridView mortgageHistoryGrid;
	}
}

