namespace Bilance
{
    partial class frmAfip
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
            this.txtPrazanAfip = new System.Windows.Forms.TextBox();
            this.btnGetPrazanAfip = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtFolderPopunjeniAfip = new System.Windows.Forms.TextBox();
            this.btnGetFolderPopunjeni = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPopunjenObrazac = new System.Windows.Forms.TextBox();
            this.btnGetObrasci = new System.Windows.Forms.Button();
            this.btnOtvoriFolderSource = new System.Windows.Forms.Button();
            this.btnOtvoriFolder = new System.Windows.Forms.Button();
            this.btnOtvoriFolderBilanci = new System.Windows.Forms.Button();
            this.btnOtvoriPrazan = new System.Windows.Forms.Button();
            this.btnOtvoriPopunjenAfip = new System.Windows.Forms.Button();
            this.txtPopunjenAfip = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOtvoriBilance = new System.Windows.Forms.Button();
            this.btnPopuni = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrazanAfip
            // 
            this.txtPrazanAfip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrazanAfip.Location = new System.Drawing.Point(6, 21);
            this.txtPrazanAfip.Name = "txtPrazanAfip";
            this.txtPrazanAfip.Size = new System.Drawing.Size(670, 22);
            this.txtPrazanAfip.TabIndex = 1;
            // 
            // btnGetPrazanAfip
            // 
            this.btnGetPrazanAfip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetPrazanAfip.Image = global::Bilance.Properties.Resources.openfolderHS;
            this.btnGetPrazanAfip.Location = new System.Drawing.Point(682, 21);
            this.btnGetPrazanAfip.Name = "btnGetPrazanAfip";
            this.btnGetPrazanAfip.Size = new System.Drawing.Size(30, 22);
            this.btnGetPrazanAfip.TabIndex = 3;
            this.btnGetPrazanAfip.UseVisualStyleBackColor = true;
            this.btnGetPrazanAfip.Click += new System.EventHandler(this.btnGetPrazanAfip_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // txtFolderPopunjeniAfip
            // 
            this.txtFolderPopunjeniAfip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderPopunjeniAfip.Location = new System.Drawing.Point(5, 21);
            this.txtFolderPopunjeniAfip.Name = "txtFolderPopunjeniAfip";
            this.txtFolderPopunjeniAfip.Size = new System.Drawing.Size(670, 22);
            this.txtFolderPopunjeniAfip.TabIndex = 5;
            this.txtFolderPopunjeniAfip.TextChanged += new System.EventHandler(this.txtFolderPopunjeniAfip_TextChanged);
            // 
            // btnGetFolderPopunjeni
            // 
            this.btnGetFolderPopunjeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderPopunjeni.Image = global::Bilance.Properties.Resources.openfolderHS;
            this.btnGetFolderPopunjeni.Location = new System.Drawing.Point(681, 21);
            this.btnGetFolderPopunjeni.Name = "btnGetFolderPopunjeni";
            this.btnGetFolderPopunjeni.Size = new System.Drawing.Size(30, 22);
            this.btnGetFolderPopunjeni.TabIndex = 6;
            this.btnGetFolderPopunjeni.UseVisualStyleBackColor = true;
            this.btnGetFolderPopunjeni.Click += new System.EventHandler(this.btnGetFolderPopunjeni_Click);
            // 
            // txtPopunjenObrazac
            // 
            this.txtPopunjenObrazac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPopunjenObrazac.Location = new System.Drawing.Point(5, 21);
            this.txtPopunjenObrazac.Name = "txtPopunjenObrazac";
            this.txtPopunjenObrazac.Size = new System.Drawing.Size(669, 22);
            this.txtPopunjenObrazac.TabIndex = 8;
            this.txtPopunjenObrazac.TextChanged += new System.EventHandler(this.txtFolderPopunjeniAfip_TextChanged);
            // 
            // btnGetObrasci
            // 
            this.btnGetObrasci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetObrasci.Image = global::Bilance.Properties.Resources.openfolderHS;
            this.btnGetObrasci.Location = new System.Drawing.Point(680, 21);
            this.btnGetObrasci.Name = "btnGetObrasci";
            this.btnGetObrasci.Size = new System.Drawing.Size(30, 22);
            this.btnGetObrasci.TabIndex = 9;
            this.btnGetObrasci.UseVisualStyleBackColor = true;
            this.btnGetObrasci.Click += new System.EventHandler(this.btnGetObrasci_Click);
            // 
            // btnOtvoriFolderSource
            // 
            this.btnOtvoriFolderSource.Location = new System.Drawing.Point(6, 49);
            this.btnOtvoriFolderSource.Name = "btnOtvoriFolderSource";
            this.btnOtvoriFolderSource.Size = new System.Drawing.Size(120, 25);
            this.btnOtvoriFolderSource.TabIndex = 39;
            this.btnOtvoriFolderSource.Text = "Otvori mapu ";
            this.btnOtvoriFolderSource.UseVisualStyleBackColor = true;
            this.btnOtvoriFolderSource.Click += new System.EventHandler(this.btnOtvoriFolderSource_Click);
            // 
            // btnOtvoriFolder
            // 
            this.btnOtvoriFolder.Location = new System.Drawing.Point(6, 49);
            this.btnOtvoriFolder.Name = "btnOtvoriFolder";
            this.btnOtvoriFolder.Size = new System.Drawing.Size(120, 25);
            this.btnOtvoriFolder.TabIndex = 40;
            this.btnOtvoriFolder.Text = "Otvori mapu";
            this.btnOtvoriFolder.UseVisualStyleBackColor = true;
            this.btnOtvoriFolder.Click += new System.EventHandler(this.btnOtvoriFolder_Click);
            // 
            // btnOtvoriFolderBilanci
            // 
            this.btnOtvoriFolderBilanci.Location = new System.Drawing.Point(4, 49);
            this.btnOtvoriFolderBilanci.Name = "btnOtvoriFolderBilanci";
            this.btnOtvoriFolderBilanci.Size = new System.Drawing.Size(120, 25);
            this.btnOtvoriFolderBilanci.TabIndex = 41;
            this.btnOtvoriFolderBilanci.Text = "Otvori mapu ";
            this.btnOtvoriFolderBilanci.UseVisualStyleBackColor = true;
            this.btnOtvoriFolderBilanci.Click += new System.EventHandler(this.btnOtvoriFolderBilanci_Click);
            // 
            // btnOtvoriPrazan
            // 
            this.btnOtvoriPrazan.Location = new System.Drawing.Point(136, 49);
            this.btnOtvoriPrazan.Name = "btnOtvoriPrazan";
            this.btnOtvoriPrazan.Size = new System.Drawing.Size(120, 25);
            this.btnOtvoriPrazan.TabIndex = 42;
            this.btnOtvoriPrazan.Text = "Otvori datoteku";
            this.btnOtvoriPrazan.UseVisualStyleBackColor = true;
            this.btnOtvoriPrazan.Click += new System.EventHandler(this.btnOtvoriPrazan_Click);
            // 
            // btnOtvoriPopunjenAfip
            // 
            this.btnOtvoriPopunjenAfip.Location = new System.Drawing.Point(6, 49);
            this.btnOtvoriPopunjenAfip.Name = "btnOtvoriPopunjenAfip";
            this.btnOtvoriPopunjenAfip.Size = new System.Drawing.Size(120, 25);
            this.btnOtvoriPopunjenAfip.TabIndex = 43;
            this.btnOtvoriPopunjenAfip.Text = "Otvori datoteku";
            this.btnOtvoriPopunjenAfip.UseVisualStyleBackColor = true;
            this.btnOtvoriPopunjenAfip.Click += new System.EventHandler(this.btnOtvoriPopunjenAfip_Click);
            // 
            // txtPopunjenAfip
            // 
            this.txtPopunjenAfip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPopunjenAfip.Location = new System.Drawing.Point(6, 21);
            this.txtPopunjenAfip.Name = "txtPopunjenAfip";
            this.txtPopunjenAfip.Size = new System.Drawing.Size(668, 22);
            this.txtPopunjenAfip.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPrazanAfip);
            this.groupBox1.Controls.Add(this.btnGetPrazanAfip);
            this.groupBox1.Controls.Add(this.btnOtvoriFolderSource);
            this.groupBox1.Controls.Add(this.btnOtvoriPrazan);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 90);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prazna Excel-ova datoteka od Afip-a";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtFolderPopunjeniAfip);
            this.groupBox2.Controls.Add(this.btnGetFolderPopunjeni);
            this.groupBox2.Controls.Add(this.btnOtvoriFolder);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 90);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mapa u koju će se spremiti popunjene Excel datoteke za Afip";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnOtvoriBilance);
            this.groupBox3.Controls.Add(this.txtPopunjenObrazac);
            this.groupBox3.Controls.Add(this.btnGetObrasci);
            this.groupBox3.Controls.Add(this.btnOtvoriFolderBilanci);
            this.groupBox3.Location = new System.Drawing.Point(13, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(718, 90);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Popunjeni obrasci (bilance) iz kojih se čitaju podaci i upisuju u Afip";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtPopunjenAfip);
            this.groupBox4.Controls.Add(this.btnOtvoriPopunjenAfip);
            this.groupBox4.Location = new System.Drawing.Point(13, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(718, 90);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ime popunjene Afip datoteke pod kojim će se spremiti na disk";
            // 
            // btnOtvoriBilance
            // 
            this.btnOtvoriBilance.Location = new System.Drawing.Point(135, 50);
            this.btnOtvoriBilance.Name = "btnOtvoriBilance";
            this.btnOtvoriBilance.Size = new System.Drawing.Size(120, 25);
            this.btnOtvoriBilance.TabIndex = 42;
            this.btnOtvoriBilance.Text = "Otvori datoteku";
            this.btnOtvoriBilance.UseVisualStyleBackColor = true;
            this.btnOtvoriBilance.Click += new System.EventHandler(this.btnOtvoriBilance_Click);
            // 
            // btnPopuni
            // 
            this.btnPopuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPopuni.Location = new System.Drawing.Point(446, 416);
            this.btnPopuni.Name = "btnPopuni";
            this.btnPopuni.Size = new System.Drawing.Size(203, 25);
            this.btnPopuni.TabIndex = 50;
            this.btnPopuni.Text = "Popuni Afip-ovu datoteku";
            this.btnPopuni.UseVisualStyleBackColor = true;
            this.btnPopuni.Click += new System.EventHandler(this.btnPopuni_Click);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzlaz.Location = new System.Drawing.Point(655, 416);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(75, 25);
            this.btnIzlaz.TabIndex = 51;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // frmAfip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 475);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnPopuni);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAfip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Priprema za Afip";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAfip_FormClosed);
            this.Load += new System.EventHandler(this.frmAfip_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrazanAfip;
        private System.Windows.Forms.Button btnGetPrazanAfip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtFolderPopunjeniAfip;
        private System.Windows.Forms.Button btnGetFolderPopunjeni;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtPopunjenObrazac;
        private System.Windows.Forms.Button btnGetObrasci;
        private System.Windows.Forms.Button btnOtvoriFolderSource;
        private System.Windows.Forms.Button btnOtvoriFolder;
        private System.Windows.Forms.Button btnOtvoriFolderBilanci;
        private System.Windows.Forms.Button btnOtvoriPrazan;
        private System.Windows.Forms.Button btnOtvoriPopunjenAfip;
        private System.Windows.Forms.TextBox txtPopunjenAfip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOtvoriBilance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnPopuni;
        private System.Windows.Forms.Button btnIzlaz;
    }
}