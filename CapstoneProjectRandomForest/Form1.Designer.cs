namespace CapstoneProjectRandomForest
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.transAmountTextBox = new System.Windows.Forms.TextBox();
            this.avgTransAmountTextBox = new System.Windows.Forms.TextBox();
            this.customerLocDropBox = new System.Windows.Forms.ComboBox();
            this.recLocDropBox = new System.Windows.Forms.ComboBox();
            this.transTypeDropBox = new System.Windows.Forms.ComboBox();
            this.currencyTypeDropBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.classLbl = new System.Windows.Forms.Label();
            this.confLbl = new System.Windows.Forms.Label();
            this.classLblVal = new System.Windows.Forms.Label();
            this.confLblVal = new System.Windows.Forms.Label();
            this.riskGuage1 = new RiskGuage();
            this.RecActLbl = new System.Windows.Forms.Label();
            this.recActLblVal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transaction Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Average Transaction Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Customer Location:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Recipient Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Transaction Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Currency Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 497);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Timestamp";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(111, 579);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(245, 87);
            this.btnAnalyze.TabIndex = 8;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(723, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 61);
            this.label8.TabIndex = 9;
            this.label8.Text = "Results";
            // 
            // transAmountTextBox
            // 
            this.transAmountTextBox.Location = new System.Drawing.Point(316, 108);
            this.transAmountTextBox.Name = "transAmountTextBox";
            this.transAmountTextBox.Size = new System.Drawing.Size(208, 31);
            this.transAmountTextBox.TabIndex = 10;
            // 
            // avgTransAmountTextBox
            // 
            this.avgTransAmountTextBox.Location = new System.Drawing.Point(409, 176);
            this.avgTransAmountTextBox.Name = "avgTransAmountTextBox";
            this.avgTransAmountTextBox.Size = new System.Drawing.Size(100, 31);
            this.avgTransAmountTextBox.TabIndex = 11;
            // 
            // customerLocDropBox
            // 
            this.customerLocDropBox.FormattingEnabled = true;
            this.customerLocDropBox.Items.AddRange(new object[] {
            "New York",
            "London",
            "Sydney",
            "Tokyo",
            "Paris",
            "Berlin",
            "Toronto",
            "Dubai",
            "Moscow",
            "Rio de Janeiro",
            "Cape Town",
            "Mumbai",
            "Seoul",
            "Mexico City",
            "Rome",
            "Amsterdam",
            "Stockholm",
            "Dublin",
            "Athens",
            "Helsinki"});
            this.customerLocDropBox.Location = new System.Drawing.Point(304, 234);
            this.customerLocDropBox.Name = "customerLocDropBox";
            this.customerLocDropBox.Size = new System.Drawing.Size(334, 33);
            this.customerLocDropBox.TabIndex = 12;
            // 
            // recLocDropBox
            // 
            this.recLocDropBox.FormattingEnabled = true;
            this.recLocDropBox.Items.AddRange(new object[] {
            "New York",
            "London",
            "Sydney",
            "Tokyo",
            "Paris",
            "Berlin",
            "Toronto",
            "Dubai",
            "Moscow",
            "Rio de Janeiro",
            "Cape Town",
            "Mumbai",
            "Seoul",
            "Mexico City",
            "Rome",
            "Amsterdam",
            "Stockholm",
            "Dublin",
            "Athens",
            "Helsinki"});
            this.recLocDropBox.Location = new System.Drawing.Point(304, 304);
            this.recLocDropBox.Name = "recLocDropBox";
            this.recLocDropBox.Size = new System.Drawing.Size(334, 33);
            this.recLocDropBox.TabIndex = 13;
            // 
            // transTypeDropBox
            // 
            this.transTypeDropBox.FormattingEnabled = true;
            this.transTypeDropBox.Items.AddRange(new object[] {
            "Purchase",
            "Refund",
            "Transfer",
            "Deposit",
            "Withdrawal",
            "Payment",
            "Exchange",
            "Donation",
            "Subscription",
            "Loan",
            "Credit",
            "Debit",
            "Invoice",
            "Reimbursement",
            "Fee"});
            this.transTypeDropBox.Location = new System.Drawing.Point(298, 365);
            this.transTypeDropBox.Name = "transTypeDropBox";
            this.transTypeDropBox.Size = new System.Drawing.Size(313, 33);
            this.transTypeDropBox.TabIndex = 14;
            // 
            // currencyTypeDropBox
            // 
            this.currencyTypeDropBox.FormattingEnabled = true;
            this.currencyTypeDropBox.Items.AddRange(new object[] {
            "USD",
            "EUR",
            "JPY",
            "GBP",
            "CAD",
            "AUD",
            "CHF",
            "CNY",
            "INR",
            "RUB",
            "BRL",
            "MXN",
            "KRW",
            "TRY",
            "ZAR",
            "SEK",
            "NOK",
            "SGD",
            "HKD",
            "NZD"});
            this.currencyTypeDropBox.Location = new System.Drawing.Point(272, 428);
            this.currencyTypeDropBox.Name = "currencyTypeDropBox";
            this.currencyTypeDropBox.Size = new System.Drawing.Size(146, 33);
            this.currencyTypeDropBox.TabIndex = 15;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(229, 497);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(395, 31);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(727, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 42);
            this.label9.TabIndex = 17;
            this.label9.Text = "Risk Score:";
            // 
            // classLbl
            // 
            this.classLbl.AutoSize = true;
            this.classLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLbl.Location = new System.Drawing.Point(727, 250);
            this.classLbl.Name = "classLbl";
            this.classLbl.Size = new System.Drawing.Size(248, 42);
            this.classLbl.TabIndex = 18;
            this.classLbl.Text = "Classification:";
            // 
            // confLbl
            // 
            this.confLbl.AutoSize = true;
            this.confLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confLbl.Location = new System.Drawing.Point(727, 351);
            this.confLbl.Name = "confLbl";
            this.confLbl.Size = new System.Drawing.Size(218, 42);
            this.confLbl.TabIndex = 19;
            this.confLbl.Text = "Confidence:";
            // 
            // classLblVal
            // 
            this.classLblVal.AutoSize = true;
            this.classLblVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLblVal.Location = new System.Drawing.Point(981, 250);
            this.classLblVal.Name = "classLblVal";
            this.classLblVal.Size = new System.Drawing.Size(0, 42);
            this.classLblVal.TabIndex = 21;
            // 
            // confLblVal
            // 
            this.confLblVal.AutoSize = true;
            this.confLblVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confLblVal.Location = new System.Drawing.Point(951, 351);
            this.confLblVal.Name = "confLblVal";
            this.confLblVal.Size = new System.Drawing.Size(0, 42);
            this.confLblVal.TabIndex = 22;
            // 
            // riskGuage1
            // 
            this.riskGuage1.Location = new System.Drawing.Point(953, 40);
            this.riskGuage1.Name = "riskGuage1";
            this.riskGuage1.RiskValue = 0F;
            this.riskGuage1.Size = new System.Drawing.Size(219, 188);
            this.riskGuage1.TabIndex = 23;
            // 
            // RecActLbl
            // 
            this.RecActLbl.AutoSize = true;
            this.RecActLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecActLbl.Location = new System.Drawing.Point(734, 441);
            this.RecActLbl.Name = "RecActLbl";
            this.RecActLbl.Size = new System.Drawing.Size(395, 42);
            this.RecActLbl.TabIndex = 24;
            this.RecActLbl.Text = "Recommended Action:";
            // 
            // recActLblVal
            // 
            this.recActLblVal.AutoSize = true;
            this.recActLblVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recActLblVal.Location = new System.Drawing.Point(1135, 441);
            this.recActLblVal.Name = "recActLblVal";
            this.recActLblVal.Size = new System.Drawing.Size(0, 42);
            this.recActLblVal.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 819);
            this.Controls.Add(this.recActLblVal);
            this.Controls.Add(this.RecActLbl);
            this.Controls.Add(this.riskGuage1);
            this.Controls.Add(this.confLblVal);
            this.Controls.Add(this.classLblVal);
            this.Controls.Add(this.confLbl);
            this.Controls.Add(this.classLbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.currencyTypeDropBox);
            this.Controls.Add(this.transTypeDropBox);
            this.Controls.Add(this.recLocDropBox);
            this.Controls.Add(this.customerLocDropBox);
            this.Controls.Add(this.avgTransAmountTextBox);
            this.Controls.Add(this.transAmountTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox transAmountTextBox;
        private System.Windows.Forms.TextBox avgTransAmountTextBox;
        private System.Windows.Forms.ComboBox customerLocDropBox;
        private System.Windows.Forms.ComboBox recLocDropBox;
        private System.Windows.Forms.ComboBox transTypeDropBox;
        private System.Windows.Forms.ComboBox currencyTypeDropBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label classLbl;
        private System.Windows.Forms.Label confLbl;
        private System.Windows.Forms.Label classLblVal;
        private System.Windows.Forms.Label confLblVal;
        private RiskGuage riskGuage1;
        private System.Windows.Forms.Label RecActLbl;
        private System.Windows.Forms.Label recActLblVal;
    }
}

