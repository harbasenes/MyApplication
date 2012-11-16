namespace Bilance
{
    partial class frmAnalitickiKontniPlanPrint
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.AnalitickiKontoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.AnalitickiKontoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AnalitickiKontoBindingSource
            // 
            this.AnalitickiKontoBindingSource.DataSource = typeof(Podaci.AnalitickiKonto);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetPodaci";
            reportDataSource1.Value = this.AnalitickiKontoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bilance.Reports.rptAnalitickiKontniPlan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(789, 699);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmAnalitickiKontniPlanPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 699);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmAnalitickiKontniPlanPrint";
            this.Text = "Ispis analitičkog kontnog plana";
            this.Load += new System.EventHandler(this.frmAnalitickiKontniPlanPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnalitickiKontoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource AnalitickiKontoBindingSource;
    }
}