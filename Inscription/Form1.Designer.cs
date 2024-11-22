namespace DashboardInscription
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTotalInscritsTitle;
        private System.Windows.Forms.Label lblTotalInscrits;
        private System.Windows.Forms.Label lblRecentInscritsTitle;
        private System.Windows.Forms.Label lblRecentInscrits;
        private System.Windows.Forms.Label lblRevenuTotalTitle;
        private System.Windows.Forms.Label lblRevenuTotal;
        private System.Windows.Forms.DataGridView dgvInscriptions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTotalInscritsTitle = new System.Windows.Forms.Label();
            this.lblTotalInscrits = new System.Windows.Forms.Label();
            this.lblRecentInscritsTitle = new System.Windows.Forms.Label();
            this.lblRecentInscrits = new System.Windows.Forms.Label();
            this.lblRevenuTotalTitle = new System.Windows.Forms.Label();
            this.lblRevenuTotal = new System.Windows.Forms.Label();
            this.dgvInscriptions = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvInscriptions)).BeginInit();
            this.SuspendLayout();

            this.lblTotalInscritsTitle.AutoSize = true;
            this.lblTotalInscritsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalInscritsTitle.Text = "Total des Inscriptions :";

            this.lblTotalInscrits.AutoSize = true;
            this.lblTotalInscrits.Location = new System.Drawing.Point(180, 20);
            this.lblTotalInscrits.Text = "0";

            this.lblRecentInscritsTitle.AutoSize = true;
            this.lblRecentInscritsTitle.Location = new System.Drawing.Point(20, 50);
            this.lblRecentInscritsTitle.Text = "Inscriptions Récentes :";

            this.lblRecentInscrits.AutoSize = true;
            this.lblRecentInscrits.Location = new System.Drawing.Point(180, 50);
            this.lblRecentInscrits.Text = "0";

            this.lblRevenuTotalTitle.AutoSize = true;
            this.lblRevenuTotalTitle.Location = new System.Drawing.Point(20, 80);
            this.lblRevenuTotalTitle.Text = "Revenu Total :";

            this.lblRevenuTotal.AutoSize = true;
            this.lblRevenuTotal.Location = new System.Drawing.Point(180, 80);
            this.lblRevenuTotal.Text = "0 €";

            this.dgvInscriptions.Location = new System.Drawing.Point(20, 120);
            this.dgvInscriptions.Size = new System.Drawing.Size(600, 300);
            this.dgvInscriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.lblTotalInscritsTitle);
            this.Controls.Add(this.lblTotalInscrits);
            this.Controls.Add(this.lblRecentInscritsTitle);
            this.Controls.Add(this.lblRecentInscrits);
            this.Controls.Add(this.lblRevenuTotalTitle);
            this.Controls.Add(this.lblRevenuTotal);
            this.Controls.Add(this.dgvInscriptions);
            this.Text = "Tableau de Bord des Inscriptions";

            ((System.ComponentModel.ISupportInitialize)(this.dgvInscriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
