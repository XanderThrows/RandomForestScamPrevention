using System;
using System.Drawing;
using System.Windows.Forms;

public class RiskGuage : UserControl  
{
    private float riskValue = 0;  //private

    public float RiskValue
    {
        get { return riskValue; }
        set
        {
            riskValue = Math.Max(0, Math.Min(100, value));
            Invalidate(); // redraw the control
        }
    }

    public RiskGuage()
    {
        this.DoubleBuffered = true;
        this.Size = new Size(250, 250);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        int thickness = 20;
        Rectangle rect = new Rectangle(
            thickness,
            thickness,
            this.Width - thickness * 2,
            this.Height - thickness * 2);

        // Background ring
        using (Pen backgroundPen = new Pen(Color.LightGray, thickness))
            g.DrawArc(backgroundPen, rect, -90, 360);

        // Determine color based on risk
        Color riskColor;
        if (riskValue < 40) riskColor = Color.Green;
        else if (riskValue < 70) riskColor = Color.Goldenrod;
        else riskColor = Color.Red;

        // Foreground arc
        using (Pen riskPen = new Pen(riskColor, thickness))
        {
            float sweepAngle = (riskValue / 100) * 360;
            g.DrawArc(riskPen, rect, -90, sweepAngle);
        }

        // Draw risk number in center
        string text = riskValue.ToString("0");
        Font font = new Font("Segoe UI", 24, FontStyle.Bold);
        SizeF textSize = g.MeasureString(text, font);
        g.DrawString(text,
            font,
            Brushes.Black,
            (Width - textSize.Width) / 2,
            (Height - textSize.Height) / 2);
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // RiskGuage
            // 
            this.Name = "RiskGuage";
            this.Size = new System.Drawing.Size(651, 591);
            this.Load += new System.EventHandler(this.RiskGuage_Load);
            this.ResumeLayout(false);

    }

    private void RiskGuage_Load(object sender, EventArgs e)
    {

    }
}