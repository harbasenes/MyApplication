namespace Bilance
{
    partial class frmIzborPrograma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIzborPrograma));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindExeFile = new System.Windows.Forms.Button();
            this.btnFindFolder = new System.Windows.Forms.Button();
            this.btnDodajNaListu = new System.Windows.Forms.Button();
            this.txtOpisPrograma = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIzvrsnaDatoteka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboVrstaPrograma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImeMape = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGodina = new System.Windows.Forms.ComboBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lvListaPrograma = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnIzaberi = new System.Windows.Forms.Button();
            this.btnUkloni = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnRunApp = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFindExeFile);
            this.groupBox1.Controls.Add(this.btnFindFolder);
            this.groupBox1.Controls.Add(this.btnDodajNaListu);
            this.groupBox1.Controls.Add(this.txtOpisPrograma);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIzvrsnaDatoteka);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboVrstaPrograma);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtImeMape);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboGodina);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 202);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o programu";
            // 
            // btnFindExeFile
            // 
            this.btnFindExeFile.Image = global::Bilance.Properties.Resources.openfolderHS;
            this.btnFindExeFile.Location = new System.Drawing.Point(703, 117);
            this.btnFindExeFile.Name = "btnFindExeFile";
            this.btnFindExeFile.Size = new System.Drawing.Size(30, 22);
            this.btnFindExeFile.TabIndex = 12;
            this.btnFindExeFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFindExeFile.UseVisualStyleBackColor = true;
            this.btnFindExeFile.Click += new System.EventHandler(this.btnFindExeFile_Click);
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.Image = global::Bilance.Properties.Resources.openfolderHS1;
            this.btnFindFolder.Location = new System.Drawing.Point(703, 59);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(30, 22);
            this.btnFindFolder.TabIndex = 11;
            this.btnFindFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFindFolder.UseVisualStyleBackColor = true;
            this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
            // 
            // btnDodajNaListu
            // 
            this.btnDodajNaListu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDodajNaListu.Location = new System.Drawing.Point(703, 173);
            this.btnDodajNaListu.Name = "btnDodajNaListu";
            this.btnDodajNaListu.Size = new System.Drawing.Size(176, 25);
            this.btnDodajNaListu.TabIndex = 10;
            this.btnDodajNaListu.Text = "Dodaj na listu";
            this.btnDodajNaListu.UseVisualStyleBackColor = true;
            this.btnDodajNaListu.Click += new System.EventHandler(this.btnDodajNaListu_Click);
            // 
            // txtOpisPrograma
            // 
            this.txtOpisPrograma.Location = new System.Drawing.Point(127, 145);
            this.txtOpisPrograma.Name = "txtOpisPrograma";
            this.txtOpisPrograma.Size = new System.Drawing.Size(569, 22);
            this.txtOpisPrograma.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Opis programa:";
            // 
            // txtIzvrsnaDatoteka
            // 
            this.txtIzvrsnaDatoteka.Location = new System.Drawing.Point(127, 117);
            this.txtIzvrsnaDatoteka.Name = "txtIzvrsnaDatoteka";
            this.txtIzvrsnaDatoteka.Size = new System.Drawing.Size(569, 22);
            this.txtIzvrsnaDatoteka.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Izvršna datoteka:";
            // 
            // cboVrstaPrograma
            // 
            this.cboVrstaPrograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVrstaPrograma.FormattingEnabled = true;
            this.cboVrstaPrograma.Location = new System.Drawing.Point(127, 87);
            this.cboVrstaPrograma.Name = "cboVrstaPrograma";
            this.cboVrstaPrograma.Size = new System.Drawing.Size(121, 24);
            this.cboVrstaPrograma.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vrsta programa:";
            // 
            // txtImeMape
            // 
            this.txtImeMape.Location = new System.Drawing.Point(127, 59);
            this.txtImeMape.Name = "txtImeMape";
            this.txtImeMape.Size = new System.Drawing.Size(569, 22);
            this.txtImeMape.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ime mape:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Godina:";
            // 
            // cboGodina
            // 
            this.cboGodina.FormattingEnabled = true;
            this.cboGodina.Location = new System.Drawing.Point(127, 29);
            this.cboGodina.Name = "cboGodina";
            this.cboGodina.Size = new System.Drawing.Size(95, 24);
            this.cboGodina.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "VSFolder_open.bmp");
            // 
            // lvListaPrograma
            // 
            this.lvListaPrograma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvListaPrograma.CheckBoxes = true;
            this.lvListaPrograma.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvListaPrograma.FullRowSelect = true;
            this.lvListaPrograma.GridLines = true;
            this.lvListaPrograma.HideSelection = false;
            this.lvListaPrograma.Location = new System.Drawing.Point(13, 220);
            this.lvListaPrograma.MultiSelect = false;
            this.lvListaPrograma.Name = "lvListaPrograma";
            this.lvListaPrograma.Size = new System.Drawing.Size(884, 287);
            this.lvListaPrograma.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvListaPrograma.TabIndex = 1;
            this.lvListaPrograma.UseCompatibleStateImageBehavior = false;
            this.lvListaPrograma.View = System.Windows.Forms.View.Details;
            this.lvListaPrograma.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvListaPrograma_ItemCheck);
            this.lvListaPrograma.DoubleClick += new System.EventHandler(this.btnIzaberi_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Godina";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mapa u kojoj je program instaliran";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Vrsta programa";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Izvršna datoteka";
            this.columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Opis programa";
            this.columnHeader5.Width = 200;
            // 
            // btnIzaberi
            // 
            this.btnIzaberi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIzaberi.Location = new System.Drawing.Point(13, 513);
            this.btnIzaberi.Name = "btnIzaberi";
            this.btnIzaberi.Size = new System.Drawing.Size(110, 25);
            this.btnIzaberi.TabIndex = 2;
            this.btnIzaberi.Text = "Izaberi";
            this.btnIzaberi.UseVisualStyleBackColor = true;
            this.btnIzaberi.Click += new System.EventHandler(this.btnIzaberi_Click);
            // 
            // btnUkloni
            // 
            this.btnUkloni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUkloni.Location = new System.Drawing.Point(129, 513);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(110, 25);
            this.btnUkloni.TabIndex = 3;
            this.btnUkloni.Text = "Ukloni sa liste";
            this.btnUkloni.UseVisualStyleBackColor = true;
            this.btnUkloni.Click += new System.EventHandler(this.btnUkloni_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpremi.Location = new System.Drawing.Point(245, 513);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(110, 25);
            this.btnSpremi.TabIndex = 4;
            this.btnSpremi.Text = "Spremi listu";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzlaz.Location = new System.Drawing.Point(816, 513);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(75, 25);
            this.btnIzlaz.TabIndex = 5;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Izbor mape/foldera u kom je program instaliran na lokalnom ili mrežnom disku.";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Izvršne datoteke (*.exe; *.com; *.bat)|*.exe;*.com;*.bat|All files (*.*)|*.*";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.Location = new System.Drawing.Point(490, 513);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(107, 25);
            this.btnClearAll.TabIndex = 6;
            this.btnClearAll.Text = "Obriši listu";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnRunApp
            // 
            this.btnRunApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRunApp.Location = new System.Drawing.Point(361, 513);
            this.btnRunApp.Name = "btnRunApp";
            this.btnRunApp.Size = new System.Drawing.Size(123, 25);
            this.btnRunApp.TabIndex = 7;
            this.btnRunApp.Text = "Pokreni program";
            this.btnRunApp.UseVisualStyleBackColor = true;
            this.btnRunApp.Click += new System.EventHandler(this.btnRunApp_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(909, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(0, 17);
            // 
            // frmIzborPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 581);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRunApp);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.btnIzaberi);
            this.Controls.Add(this.lvListaPrograma);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmIzborPrograma";
            this.Text = "Izbor programa";
            this.Load += new System.EventHandler(this.frmIzborPrograma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDodajNaListu;
        private System.Windows.Forms.TextBox txtOpisPrograma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIzvrsnaDatoteka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboVrstaPrograma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImeMape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGodina;
        private System.Windows.Forms.ListView lvListaPrograma;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnIzaberi;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Button btnFindExeFile;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnFindFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnRunApp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
    }
}