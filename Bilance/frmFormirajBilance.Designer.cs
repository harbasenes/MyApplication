namespace Bilance
{
    partial class frmFormirajBilance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormirajBilance));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lvPreduvjeti = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIzaberiProgram = new System.Windows.Forms.Button();
            this.btnIzaberiKorisnika = new System.Windows.Forms.Button();
            this.btnPodesenja = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.btnPopuniObrazac = new System.Windows.Forms.Button();
            this.btnOtvoriFolderSource = new System.Windows.Forms.Button();
            this.btnOtvoriPopunjen = new System.Windows.Forms.Button();
            this.btnOtvoriPrazan = new System.Windows.Forms.Button();
            this.btnOtvoriFolder = new System.Windows.Forms.Button();
            this.txtStatusObrazaca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPopunjenObrazac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList.Images.SetKeyName(0, "OK.bmp");
            this.imageList.Images.SetKeyName(1, "Warning.bmp");
            // 
            // lvPreduvjeti
            // 
            this.lvPreduvjeti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPreduvjeti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPreduvjeti.GridLines = true;
            this.lvPreduvjeti.Location = new System.Drawing.Point(6, 31);
            this.lvPreduvjeti.Name = "lvPreduvjeti";
            this.lvPreduvjeti.Size = new System.Drawing.Size(899, 336);
            this.lvPreduvjeti.TabIndex = 27;
            this.lvPreduvjeti.UseCompatibleStateImageBehavior = false;
            this.lvPreduvjeti.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Podatak";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Vrijednost podatka";
            this.columnHeader2.Width = 400;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ispravan";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Preduvjeti i podešenja za formiranje bilanci:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Uvjeti";
            // 
            // btnIzaberiProgram
            // 
            this.btnIzaberiProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzaberiProgram.Location = new System.Drawing.Point(919, 30);
            this.btnIzaberiProgram.Name = "btnIzaberiProgram";
            this.btnIzaberiProgram.Size = new System.Drawing.Size(159, 25);
            this.btnIzaberiProgram.TabIndex = 30;
            this.btnIzaberiProgram.Text = "Izaberi program";
            this.btnIzaberiProgram.UseVisualStyleBackColor = true;
            this.btnIzaberiProgram.Click += new System.EventHandler(this.btnIzaberiProgram_Click);
            // 
            // btnIzaberiKorisnika
            // 
            this.btnIzaberiKorisnika.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzaberiKorisnika.Location = new System.Drawing.Point(919, 78);
            this.btnIzaberiKorisnika.Name = "btnIzaberiKorisnika";
            this.btnIzaberiKorisnika.Size = new System.Drawing.Size(159, 25);
            this.btnIzaberiKorisnika.TabIndex = 31;
            this.btnIzaberiKorisnika.Text = "Izaberi korisnika";
            this.btnIzaberiKorisnika.UseVisualStyleBackColor = true;
            this.btnIzaberiKorisnika.Click += new System.EventHandler(this.btnIzaberiKorisnika_Click);
            // 
            // btnPodesenja
            // 
            this.btnPodesenja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPodesenja.Location = new System.Drawing.Point(919, 126);
            this.btnPodesenja.Name = "btnPodesenja";
            this.btnPodesenja.Size = new System.Drawing.Size(159, 25);
            this.btnPodesenja.TabIndex = 32;
            this.btnPodesenja.Text = "Podešenja bilanci";
            this.btnPodesenja.UseVisualStyleBackColor = true;
            this.btnPodesenja.Click += new System.EventHandler(this.btnPodesenja_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(919, 342);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(159, 25);
            this.btnRefresh.TabIndex = 33;
            this.btnRefresh.Text = "Ponovna provjera";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.btnIzlaz);
            this.panel1.Controls.Add(this.btnPopuniObrazac);
            this.panel1.Controls.Add(this.btnOtvoriFolderSource);
            this.panel1.Controls.Add(this.btnOtvoriPopunjen);
            this.panel1.Controls.Add(this.btnOtvoriPrazan);
            this.panel1.Controls.Add(this.btnOtvoriFolder);
            this.panel1.Controls.Add(this.txtStatusObrazaca);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPopunjenObrazac);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 178);
            this.panel1.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "Popuna u toku:";
            this.label5.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(144, 65);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(620, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 41;
            this.progressBar.Visible = false;
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzlaz.Location = new System.Drawing.Point(950, 97);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(127, 70);
            this.btnIzlaz.TabIndex = 40;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnPopuniObrazac
            // 
            this.btnPopuniObrazac.Location = new System.Drawing.Point(566, 97);
            this.btnPopuniObrazac.Name = "btnPopuniObrazac";
            this.btnPopuniObrazac.Size = new System.Drawing.Size(127, 70);
            this.btnPopuniObrazac.TabIndex = 39;
            this.btnPopuniObrazac.Text = "Popuni obrazac";
            this.btnPopuniObrazac.UseVisualStyleBackColor = true;
            this.btnPopuniObrazac.Click += new System.EventHandler(this.btnPopuniObrazac_Click);
            // 
            // btnOtvoriFolderSource
            // 
            this.btnOtvoriFolderSource.Location = new System.Drawing.Point(11, 97);
            this.btnOtvoriFolderSource.Name = "btnOtvoriFolderSource";
            this.btnOtvoriFolderSource.Size = new System.Drawing.Size(112, 70);
            this.btnOtvoriFolderSource.TabIndex = 38;
            this.btnOtvoriFolderSource.Text = "Otvori mapu s praznim obrascima";
            this.btnOtvoriFolderSource.UseVisualStyleBackColor = true;
            this.btnOtvoriFolderSource.Click += new System.EventHandler(this.btnOtvoriFolderSource_Click);
            // 
            // btnOtvoriPopunjen
            // 
            this.btnOtvoriPopunjen.Location = new System.Drawing.Point(407, 97);
            this.btnOtvoriPopunjen.Name = "btnOtvoriPopunjen";
            this.btnOtvoriPopunjen.Size = new System.Drawing.Size(139, 70);
            this.btnOtvoriPopunjen.TabIndex = 37;
            this.btnOtvoriPopunjen.Text = "Otvori popunjen obrazac";
            this.btnOtvoriPopunjen.UseVisualStyleBackColor = true;
            this.btnOtvoriPopunjen.Click += new System.EventHandler(this.btnOtvoriPopunjen_Click);
            // 
            // btnOtvoriPrazan
            // 
            this.btnOtvoriPrazan.Location = new System.Drawing.Point(262, 97);
            this.btnOtvoriPrazan.Name = "btnOtvoriPrazan";
            this.btnOtvoriPrazan.Size = new System.Drawing.Size(139, 70);
            this.btnOtvoriPrazan.TabIndex = 36;
            this.btnOtvoriPrazan.Text = "Otvori prazan obrazac";
            this.btnOtvoriPrazan.UseVisualStyleBackColor = true;
            this.btnOtvoriPrazan.Click += new System.EventHandler(this.btnOtvoriPrazan_Click);
            // 
            // btnOtvoriFolder
            // 
            this.btnOtvoriFolder.Location = new System.Drawing.Point(129, 97);
            this.btnOtvoriFolder.Name = "btnOtvoriFolder";
            this.btnOtvoriFolder.Size = new System.Drawing.Size(112, 70);
            this.btnOtvoriFolder.TabIndex = 35;
            this.btnOtvoriFolder.Text = "Otvori mapu s popunjenim obrascima";
            this.btnOtvoriFolder.UseVisualStyleBackColor = true;
            this.btnOtvoriFolder.Click += new System.EventHandler(this.btnOtvoriFolder_Click);
            // 
            // txtStatusObrazaca
            // 
            this.txtStatusObrazaca.Location = new System.Drawing.Point(144, 36);
            this.txtStatusObrazaca.Name = "txtStatusObrazaca";
            this.txtStatusObrazaca.ReadOnly = true;
            this.txtStatusObrazaca.Size = new System.Drawing.Size(620, 22);
            this.txtStatusObrazaca.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Status obrazaca:";
            // 
            // txtPopunjenObrazac
            // 
            this.txtPopunjenObrazac.Location = new System.Drawing.Point(144, 7);
            this.txtPopunjenObrazac.Name = "txtPopunjenObrazac";
            this.txtPopunjenObrazac.ReadOnly = true;
            this.txtPopunjenObrazac.Size = new System.Drawing.Size(620, 22);
            this.txtPopunjenObrazac.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ime datoteke:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1090, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1075, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lvPreduvjeti);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnIzaberiProgram);
            this.panel2.Controls.Add(this.btnIzaberiKorisnika);
            this.panel2.Controls.Add(this.btnPodesenja);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1090, 409);
            this.panel2.TabIndex = 36;
            // 
            // frmFormirajBilance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 615);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmFormirajBilance";
            this.Text = "Formiranje bilanci";
            this.Load += new System.EventHandler(this.frmFormirajBilance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView lvPreduvjeti;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIzaberiProgram;
        private System.Windows.Forms.Button btnIzaberiKorisnika;
        private System.Windows.Forms.Button btnPodesenja;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtStatusObrazaca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPopunjenObrazac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOtvoriFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOtvoriPrazan;
        private System.Windows.Forms.Button btnOtvoriPopunjen;
        private System.Windows.Forms.Button btnOtvoriFolderSource;
        private System.Windows.Forms.Button btnPopuniObrazac;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel2;
    }
}