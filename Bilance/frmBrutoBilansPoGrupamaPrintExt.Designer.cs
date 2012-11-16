namespace Bilance
{
    partial class frmBrutoBilansPoGrupamaPrintExt
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.brutoBilansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.brutoBilansBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetBrutoBilansPoGrupamaExt";
            reportDataSource1.Value = this.brutoBilansBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bilance.Reports.rptBrutoBilansPoGrupamaExt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1011, 524);
            this.reportViewer1.TabIndex = 0;
            // 
            // brutoBilansBindingSource
            // 
            this.brutoBilansBindingSource.DataSource = typeof(Podaci.BrutoBilans);
            // 
            // frmBrutoBilansPoGrupamaPrintExt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 524);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmBrutoBilansPoGrupamaPrintExt";
            this.Text = "Ispis bruto bilansa sa početnim stanjem po grupama konta";
            this.Load += new System.EventHandler(this.frmBrutoBilansPoGrupamaPrintExt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brutoBilansBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource brutoBilansBindingSource;
    }
}