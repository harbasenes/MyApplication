namespace Bilance
{
    partial class frmBilanceSetup
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
            this.txtPrazanObrazac = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnGetPrazneBilance = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolderPopunjeniObrasci = new System.Windows.Forms.TextBox();
            this.btnGetFolderPopunjeni = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOdDatuma = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDoDatuma = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNazivKorisnika = new System.Windows.Forms.RadioButton();
            this.rdoIdKorisnika2 = new System.Windows.Forms.RadioButton();
            this.rdoSifraKorisnika2 = new System.Windows.Forms.RadioButton();
            this.rdoIdKorisnika = new System.Windows.Forms.RadioButton();
            this.rdoSifraKorisnika = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTelefonRacunovodje = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLicencaRacunovodje = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIDbrojRacunovodje = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdresaRacunovodje = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImeRacunovodje = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDatumPredaje = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prazni obrasci (Excel datoteka):";
            // 
            // txtPrazanObrazac
            // 
            this.txtPrazanObrazac.Location = new System.Drawing.Point(15, 29);
            this.txtPrazanObrazac.Name = "txtPrazanObrazac";
            this.txtPrazanObrazac.Size = new System.Drawing.Size(554, 22);
            this.txtPrazanObrazac.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel files|*.xls;*.xlsx|All files|*.*";
            // 
            // btnGetPrazneBilance
            // 
            this.btnGetPrazneBilance.Image = global::Bilance.Properties.Resources.openfolderHS;
            this.btnGetPrazneBilance.Location = new System.Drawing.Point(575, 29);
            this.btnGetPrazneBilance.Name = "btnGetPrazneBilance";
            this.btnGetPrazneBilance.Size = new System.Drawing.Size(30, 22);
            this.btnGetPrazneBilance.TabIndex = 2;
            this.btnGetPrazneBilance.UseVisualStyleBackColor = true;
            this.btnGetPrazneBilance.Click += new System.EventHandler(this.btnGetPrazneBilance_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder u kom se formiraju popunjeni obrasci:";
            // 
            // txtFolderPopunjeniObrasci
            // 
            this.txtFolderPopunjeniObrasci.Location = new System.Drawing.Point(15, 85);
            this.txtFolderPopunjeniObrasci.Name = "txtFolderPopunjeniObrasci";
            this.txtFolderPopunjeniObrasci.Size = new System.Drawing.Size(554, 22);
            this.txtFolderPopunjeniObrasci.TabIndex = 4;
            // 
            // btnGetFolderPopunjeni
            // 
            this.btnGetFolderPopunjeni.Image = global::Bilance.Properties.Resources.openfolderHS;
            this.btnGetFolderPopunjeni.Location = new System.Drawing.Point(575, 85);
            this.btnGetFolderPopunjeni.Name = "btnGetFolderPopunjeni";
            this.btnGetFolderPopunjeni.Size = new System.Drawing.Size(30, 22);
            this.btnGetFolderPopunjeni.TabIndex = 5;
            this.btnGetFolderPopunjeni.UseVisualStyleBackColor = true;
            this.btnGetFolderPopunjeni.Click += new System.EventHandler(this.btnGetFolderPopunjeni_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Folder u kom će se spremati popunjeni obrasci";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Period za koji se formiraju obrasci:";
            // 
            // dtpOdDatuma
            // 
            this.dtpOdDatuma.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOdDatuma.Location = new System.Drawing.Point(236, 130);
            this.dtpOdDatuma.Name = "dtpOdDatuma";
            this.dtpOdDatuma.Size = new System.Drawing.Size(110, 22);
            this.dtpOdDatuma.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "-";
            // 
            // dtpDoDatuma
            // 
            this.dtpDoDatuma.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDoDatuma.Location = new System.Drawing.Point(372, 130);
            this.dtpDoDatuma.Name = "dtpDoDatuma";
            this.dtpDoDatuma.Size = new System.Drawing.Size(110, 22);
            this.dtpDoDatuma.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoNazivKorisnika);
            this.groupBox1.Controls.Add(this.rdoIdKorisnika2);
            this.groupBox1.Controls.Add(this.rdoSifraKorisnika2);
            this.groupBox1.Controls.Add(this.rdoIdKorisnika);
            this.groupBox1.Controls.Add(this.rdoSifraKorisnika);
            this.groupBox1.Location = new System.Drawing.Point(18, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 171);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Način formiranja imena popunjenog obrasca";
            // 
            // rdoNazivKorisnika
            // 
            this.rdoNazivKorisnika.AutoSize = true;
            this.rdoNazivKorisnika.Location = new System.Drawing.Point(7, 143);
            this.rdoNazivKorisnika.Name = "rdoNazivKorisnika";
            this.rdoNazivKorisnika.Size = new System.Drawing.Size(350, 21);
            this.rdoNazivKorisnika.TabIndex = 4;
            this.rdoNazivKorisnika.TabStop = true;
            this.rdoNazivKorisnika.Text = "Naziv korisnika_Sifra korisnika_Bilance_DoDatuma";
            this.rdoNazivKorisnika.UseVisualStyleBackColor = true;
            // 
            // rdoIdKorisnika2
            // 
            this.rdoIdKorisnika2.AutoSize = true;
            this.rdoIdKorisnika2.Location = new System.Drawing.Point(7, 116);
            this.rdoIdKorisnika2.Name = "rdoIdKorisnika2";
            this.rdoIdKorisnika2.Size = new System.Drawing.Size(177, 21);
            this.rdoIdKorisnika2.TabIndex = 3;
            this.rdoIdKorisnika2.TabStop = true;
            this.rdoIdKorisnika2.Text = "ID korisnika_DoDatuma";
            this.rdoIdKorisnika2.UseVisualStyleBackColor = true;
            // 
            // rdoSifraKorisnika2
            // 
            this.rdoSifraKorisnika2.AutoSize = true;
            this.rdoSifraKorisnika2.Location = new System.Drawing.Point(7, 88);
            this.rdoSifraKorisnika2.Name = "rdoSifraKorisnika2";
            this.rdoSifraKorisnika2.Size = new System.Drawing.Size(193, 21);
            this.rdoSifraKorisnika2.TabIndex = 2;
            this.rdoSifraKorisnika2.TabStop = true;
            this.rdoSifraKorisnika2.Text = "Šifra korisnika_DoDatuma";
            this.rdoSifraKorisnika2.UseVisualStyleBackColor = true;
            // 
            // rdoIdKorisnika
            // 
            this.rdoIdKorisnika.AutoSize = true;
            this.rdoIdKorisnika.Location = new System.Drawing.Point(7, 60);
            this.rdoIdKorisnika.Name = "rdoIdKorisnika";
            this.rdoIdKorisnika.Size = new System.Drawing.Size(304, 21);
            this.rdoIdKorisnika.TabIndex = 1;
            this.rdoIdKorisnika.TabStop = true;
            this.rdoIdKorisnika.Text = "ID korisnika_Bilance_OdDatuma-DoDatuma";
            this.rdoIdKorisnika.UseVisualStyleBackColor = true;
            // 
            // rdoSifraKorisnika
            // 
            this.rdoSifraKorisnika.AutoSize = true;
            this.rdoSifraKorisnika.Location = new System.Drawing.Point(7, 33);
            this.rdoSifraKorisnika.Name = "rdoSifraKorisnika";
            this.rdoSifraKorisnika.Size = new System.Drawing.Size(320, 21);
            this.rdoSifraKorisnika.TabIndex = 0;
            this.rdoSifraKorisnika.TabStop = true;
            this.rdoSifraKorisnika.Text = "Šifra korisnika_Bilance_OdDatuma-DoDatuma";
            this.rdoSifraKorisnika.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTelefonRacunovodje);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtLicencaRacunovodje);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtIDbrojRacunovodje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtAdresaRacunovodje);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtImeRacunovodje);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(18, 397);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 144);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o računovođi";
            // 
            // txtTelefonRacunovodje
            // 
            this.txtTelefonRacunovodje.Location = new System.Drawing.Point(110, 106);
            this.txtTelefonRacunovodje.Name = "txtTelefonRacunovodje";
            this.txtTelefonRacunovodje.Size = new System.Drawing.Size(155, 22);
            this.txtTelefonRacunovodje.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Telefon:";
            // 
            // txtLicencaRacunovodje
            // 
            this.txtLicencaRacunovodje.Location = new System.Drawing.Point(378, 78);
            this.txtLicencaRacunovodje.Name = "txtLicencaRacunovodje";
            this.txtLicencaRacunovodje.Size = new System.Drawing.Size(155, 22);
            this.txtLicencaRacunovodje.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Broj dozvole:";
            // 
            // txtIDbrojRacunovodje
            // 
            this.txtIDbrojRacunovodje.Location = new System.Drawing.Point(110, 78);
            this.txtIDbrojRacunovodje.Name = "txtIDbrojRacunovodje";
            this.txtIDbrojRacunovodje.Size = new System.Drawing.Size(155, 22);
            this.txtIDbrojRacunovodje.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "ID broj:";
            // 
            // txtAdresaRacunovodje
            // 
            this.txtAdresaRacunovodje.Location = new System.Drawing.Point(110, 50);
            this.txtAdresaRacunovodje.Name = "txtAdresaRacunovodje";
            this.txtAdresaRacunovodje.Size = new System.Drawing.Size(423, 22);
            this.txtAdresaRacunovodje.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Adresa:";
            // 
            // txtImeRacunovodje
            // 
            this.txtImeRacunovodje.Location = new System.Drawing.Point(110, 22);
            this.txtImeRacunovodje.Name = "txtImeRacunovodje";
            this.txtImeRacunovodje.Size = new System.Drawing.Size(423, 22);
            this.txtImeRacunovodje.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Prezime i ime:";
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Location = new System.Drawing.Point(530, 558);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(75, 25);
            this.btnIzlaz.TabIndex = 12;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(18, 556);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 25);
            this.btnSpremi.TabIndex = 13;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Datum predaje obrazaca:";
            // 
            // dtpDatumPredaje
            // 
            this.dtpDatumPredaje.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumPredaje.Location = new System.Drawing.Point(190, 166);
            this.dtpDatumPredaje.Name = "dtpDatumPredaje";
            this.dtpDatumPredaje.Size = new System.Drawing.Size(110, 22);
            this.dtpDatumPredaje.TabIndex = 16;
            // 
            // frmBilanceSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 595);
            this.Controls.Add(this.dtpDatumPredaje);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDoDatuma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpOdDatuma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetFolderPopunjeni);
            this.Controls.Add(this.txtFolderPopunjeniObrasci);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetPrazneBilance);
            this.Controls.Add(this.txtPrazanObrazac);
            this.Controls.Add(this.label1);
            this.Name = "frmBilanceSetup";
            this.Text = "Opća podešenja";
            this.Load += new System.EventHandler(this.frmBilanceSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrazanObrazac;
        private System.Windows.Forms.Button btnGetPrazneBilance;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolderPopunjeniObrasci;
        private System.Windows.Forms.Button btnGetFolderPopunjeni;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOdDatuma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDoDatuma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoIdKorisnika2;
        private System.Windows.Forms.RadioButton rdoSifraKorisnika2;
        private System.Windows.Forms.RadioButton rdoIdKorisnika;
        private System.Windows.Forms.RadioButton rdoSifraKorisnika;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTelefonRacunovodje;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLicencaRacunovodje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIDbrojRacunovodje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAdresaRacunovodje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImeRacunovodje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.RadioButton rdoNazivKorisnika;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDatumPredaje;
    }
}