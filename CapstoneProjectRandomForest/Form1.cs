using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneProjectRandomForest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // Example mock score
            float probability = 0.82f;

            float riskScore = probability * 100;

            riskGuage1.RiskValue = riskScore;

            UpdateRiskScoreUI(riskScore, probability);
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
