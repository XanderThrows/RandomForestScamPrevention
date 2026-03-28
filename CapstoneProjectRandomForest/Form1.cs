using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScamModelTrainer;



namespace CapstoneProjectRandomForest
{


    public partial class Form1 : Form
    {

        private ScamPredict predictor;

        public Form1()
        {
            InitializeComponent();
            predictor = new ScamPredict();
            predictor.LoadModel(@"C:\Users\zande\OneDrive\Desktop\CapstoneProjectRandomForest\ScamModelTrainer\bin\x64\Debug\ScamRandomForest.zip");
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            /* Example mock score
            float probability = 0.82f;

            float riskScore = probability * 100;

            riskGuage1.RiskValue = riskScore;

            UpdateRiskScoreUI(riskScore, probability);*/

            // Create transaction object from UI

            if(string.IsNullOrWhiteSpace(transAmountTextBox.Text) ||
               string.IsNullOrWhiteSpace(avgTransAmountTextBox.Text) ||
               string.IsNullOrWhiteSpace(customerLocDropBox.Text) ||
               string.IsNullOrWhiteSpace(recLocDropBox.Text) ||
               string.IsNullOrWhiteSpace(transTypeDropBox.Text) ||
               string.IsNullOrWhiteSpace(currencyTypeDropBox.Text))
            {
                throw new FormatException("Missing value in a field. Please check all fields.");
                
            }

            var transaction = new TransactionData
            {
                TransactionAmount = float.Parse(transAmountTextBox.Text),
                AverageTransactionAmount = float.Parse(avgTransAmountTextBox.Text),
                CustomerLocation = customerLocDropBox.SelectedItem.ToString(),
                RecipientLocation = recLocDropBox.SelectedItem.ToString(),
                TransactionType = transTypeDropBox.SelectedItem.ToString(),
                CurrencyType = currencyTypeDropBox.SelectedItem.ToString()
            };

            // Predict
            var result = predictor.Predict(transaction);

            // Compute risk score
            float riskScore = result.Probability * 100;

            // Update gauge & labels
            riskGuage1.RiskValue = riskScore;
            UpdateRiskScoreUI(riskScore, result.Probability);
        }

        private void UpdateRiskScoreUI(float riskScore, float probability)
        {
            //lblRiskScoreValue.Text = riskScore.ToString("0");

            confLblVal.Text = (probability * 100).ToString("0") + "%";

            if (riskScore < 40)
            {
                classLblVal.Text = "LOW RISK";
                recActLblVal.Text = "No Action";
                //lblRiskScoreValue.ForeColor = Color.Green;
            }
            else if (riskScore < 70)
            {
                classLblVal.Text = "SUSPICIOUS";
                recActLblVal.Text = "Flag for Review";
                //lblRiskScoreValue.ForeColor = Color.Goldenrod;
            }
            else
            {
                classLblVal.Text = "HIGH FRAUD RISK";
                recActLblVal.Text = "BLOCK";
                //lblRiskScoreValue.ForeColor = Color.Red;
            }
        }
    }
}
