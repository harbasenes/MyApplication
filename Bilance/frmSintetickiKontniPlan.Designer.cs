namespace Bilance
{
    partial class frmSintetickiKontniPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSintetickiKontniPlan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.txtKorisnik = new System.Windows.Forms.TextBox();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDbfFajl = new System.Windows.Forms.TextBox();
            this.sintetickiKontoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.sintetickiKontoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorKonto = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorAOP = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorNazivKonta = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorBtnTrazi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sintetickiKontoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sintetickiKontoBindingNavigator)).BeginInit();
            this.sintetickiKontoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sintetickiKontoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sintetickiKontoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Korisnik:";
            // 
            // txtProgram
            // 
            this.txtProgram.Location = new System.Drawing.Point(86, 52);
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.ReadOnly = true;
            this.txtProgram.Size = new System.Drawing.Size(616, 22);
            this.txtProgram.TabIndex = 2;
            this.txtProgram.TabStop = false;
            // 
            // txtKorisnik
            // 
            this.txtKorisnik.Location = new System.Drawing.Point(86, 109);
            this.txtKorisnik.Name = "txtKorisnik";
            this.txtKorisnik.ReadOnly = true;
            this.txtKorisnik.Size = new System.Drawing.Size(616, 22);
            this.txtKorisnik.TabIndex = 3;
            this.txtKorisnik.TabStop = false;
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzlaz.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIzlaz.Location = new System.Drawing.Point(631, 603);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(75, 25);
            this.btnIzlaz.TabIndex = 1;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dbf fajl:";
            // 
            // txtDbfFajl
            // 
            this.txtDbfFajl.Location = new System.Drawing.Point(86, 81);
            this.txtDbfFajl.Name = "txtDbfFajl";
            this.txtDbfFajl.ReadOnly = true;
            this.txtDbfFajl.Size = new System.Drawing.Size(616, 22);
            this.txtDbfFajl.TabIndex = 8;
            this.txtDbfFajl.TabStop = false;
            // 
            // sintetickiKontoBindingNavigator
            // 
            this.sintetickiKontoBindingNavigator.AddNewItem = null;
            this.sintetickiKontoBindingNavigator.BindingSource = this.sintetickiKontoBindingSource;
            this.sintetickiKontoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.sintetickiKontoBindingNavigator.DeleteItem = null;
            this.sintetickiKontoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorBtnPrint,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.bindingNavigatorKonto,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.bindingNavigatorAOP,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.bindingNavigatorNazivKonta,
            this.bindingNavigatorBtnTrazi,
            this.toolStripSeparator3});
            this.sintetickiKontoBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.sintetickiKontoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.sintetickiKontoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.sintetickiKontoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.sintetickiKontoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.sintetickiKontoBindingNavigator.Name = "sintetickiKontoBindingNavigator";
            this.sintetickiKontoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.sintetickiKontoBindingNavigator.Size = new System.Drawing.Size(734, 28);
            this.sintetickiKontoBindingNavigator.TabIndex = 2;
            this.sintetickiKontoBindingNavigator.Text = "bindingNavigator1";
            // 
            // sintetickiKontoBindingSource
            // 
            this.sintetickiKontoBindingSource.DataSource = typeof(Podaci.SintetickiKonto);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 25);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 25);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 25);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 28);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 25);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 25);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // bindingNavigatorBtnPrint
            // 
            this.bindingNavigatorBtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorBtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorBtnPrint.Image")));
            this.bindingNavigatorBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bindingNavigatorBtnPrint.Name = "bindingNavigatorBtnPrint";
            this.bindingNavigatorBtnPrint.Size = new System.Drawing.Size(23, 25);
            this.bindingNavigatorBtnPrint.ToolTipText = "Ispis kontnog plana";
            this.bindingNavigatorBtnPrint.Click += new System.EventHandler(this.bindingNavigatorBtnPrint_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 25);
            this.toolStripLabel1.Text = "Konto:";
            // 
            // bindingNavigatorKonto
            // 
            this.bindingNavigatorKonto.DropDownWidth = 75;
            this.bindingNavigatorKonto.Name = "bindingNavigatorKonto";
            this.bindingNavigatorKonto.Size = new System.Drawing.Size(75, 28);
            this.bindingNavigatorKonto.SelectedIndexChanged += new System.EventHandler(this.bindingNavigatorKonto_SelectedIndexChanged);
            this.bindingNavigatorKonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bindingNavigatorKonto_KeyDown);
          
            this.bindingNavigatorKonto.TextChanged += new System.EventHandler(this.bindingNavigatorKonto_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(41, 25);
            this.toolStripLabel2.Text = "AOP:";
            // 
            // bindingNavigatorAOP
            // 
            this.bindingNavigatorAOP.Name = "bindingNavigatorAOP";
            this.bindingNavigatorAOP.Size = new System.Drawing.Size(75, 28);
            this.bindingNavigatorAOP.TextChanged += new System.EventHandler(this.bindingNavigatorAOP_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(49, 25);
            this.toolStripLabel3.Text = "Naziv:";
            // 
            // bindingNavigatorNazivKonta
            // 
            this.bindingNavigatorNazivKonta.Name = "bindingNavigatorNazivKonta";
            this.bindingNavigatorNazivKonta.Size = new System.Drawing.Size(100, 28);
            this.bindingNavigatorNazivKonta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bindingNavigatorNazivKonta_KeyDown);
            // 
            // bindingNavigatorBtnTrazi
            // 
            this.bindingNavigatorBtnTrazi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorBtnTrazi.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorBtnTrazi.Image")));
            this.bindingNavigatorBtnTrazi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bindingNavigatorBtnTrazi.Name = "bindingNavigatorBtnTrazi";
            this.bindingNavigatorBtnTrazi.Size = new System.Drawing.Size(23, 25);
            this.bindingNavigatorBtnTrazi.Text = "Traži";
            this.bindingNavigatorBtnTrazi.ToolTipText = "Traži dio naziva";
            this.bindingNavigatorBtnTrazi.Click += new System.EventHandler(this.bindingNavigatorBtnTrazi_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // sintetickiKontoDataGridView
            // 
            this.sintetickiKontoDataGridView.AllowUserToAddRows = false;
            this.sintetickiKontoDataGridView.AllowUserToDeleteRows = false;
            this.sintetickiKontoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sintetickiKontoDataGridView.AutoGenerateColumns = false;
            this.sintetickiKontoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sintetickiKontoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4});
            this.sintetickiKontoDataGridView.DataSource = this.sintetickiKontoBindingSource;
            this.sintetickiKontoDataGridView.Location = new System.Drawing.Point(16, 137);
            this.sintetickiKontoDataGridView.Name = "sintetickiKontoDataGridView";
            this.sintetickiKontoDataGridView.ReadOnly = true;
            this.sintetickiKontoDataGridView.RowTemplate.Height = 24;
            this.sintetickiKontoDataGridView.Size = new System.Drawing.Size(690, 460);
            this.sintetickiKontoDataGridView.TabIndex = 0;
            this.sintetickiKontoDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sintetickiKontoDataGridView_KeyDown);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Konto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Konto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NazivKonta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Naziv sintetičkog konta";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 450;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AOPOznaka";
            this.dataGridViewTextBoxColumn5.HeaderText = "AOP";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AktivniPasivni";
            this.dataGridViewTextBoxColumn4.HeaderText = "AktivniPasivni";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "AddTableHH.bmp");
            this.imageList.Images.SetKeyName(1, "ArrangeWindowsHH.bmp");
            this.imageList.Images.SetKeyName(2, "AttachmentHH.bmp");
            this.imageList.Images.SetKeyName(3, "ClosePreviewHH.bmp");
            this.imageList.Images.SetKeyName(4, "Color_fillHH.bmp");
            this.imageList.Images.SetKeyName(5, "Color_lineHH.bmp");
            this.imageList.Images.SetKeyName(6, "CopyHH.bmp");
            this.imageList.Images.SetKeyName(7, "CropHH.bmp");
            this.imageList.Images.SetKeyName(8, "Delete_tableHH.bmp");
            this.imageList.Images.SetKeyName(9, "FindHH.bmp");
            this.imageList.Images.SetKeyName(10, "FullScreenHH.bmp");
            this.imageList.Images.SetKeyName(11, "FunctionHH.bmp");
            this.imageList.Images.SetKeyName(12, "GraphHH.bmp");
            this.imageList.Images.SetKeyName(13, "HighlightHH.bmp");
            this.imageList.Images.SetKeyName(14, "HomePageHH.bmp");
            this.imageList.Images.SetKeyName(15, "InsertPictureHH.bmp");
            this.imageList.Images.SetKeyName(16, "LandscapeHH.bmp");
            this.imageList.Images.SetKeyName(17, "MoveToFolderHH.bmp");
            this.imageList.Images.SetKeyName(18, "MultiplePagesHH.bmp");
            this.imageList.Images.SetKeyName(19, "NewClassModuleHH.bmp");
            this.imageList.Images.SetKeyName(20, "OpenHH.bmp");
            this.imageList.Images.SetKeyName(21, "OpenPH.bmp");
            this.imageList.Images.SetKeyName(22, "PasteHH.bmp");
            this.imageList.Images.SetKeyName(23, "PieChart3DHH.bmp");
            this.imageList.Images.SetKeyName(24, "PortraitHH.bmp");
            this.imageList.Images.SetKeyName(25, "PortraitLandscapeHH.bmp");
            this.imageList.Images.SetKeyName(26, "PrintHH.bmp");
            this.imageList.Images.SetKeyName(27, "PrintPreviewHH.bmp");
            this.imageList.Images.SetKeyName(28, "PrintRelationshipsHH.bmp");
            this.imageList.Images.SetKeyName(29, "PropertiesHH.bmp");
            this.imageList.Images.SetKeyName(30, "ProtectDocumentHH.bmp");
            this.imageList.Images.SetKeyName(31, "ProtectFormHH.bmp");
            this.imageList.Images.SetKeyName(32, "RelationshipsHH.bmp");
            this.imageList.Images.SetKeyName(33, "SaveAsHH.bmp");
            this.imageList.Images.SetKeyName(34, "SaveFormDesignHH.bmp");
            this.imageList.Images.SetKeyName(35, "SaveHH.bmp");
            this.imageList.Images.SetKeyName(36, "TaskHH.bmp");
            this.imageList.Images.SetKeyName(37, "WebInsertHyperlinkHH.bmp");
            this.imageList.Images.SetKeyName(38, "WebPagePreviewHH.bmp");
            this.imageList.Images.SetKeyName(39, "WebRefreshHH.bmp");
            this.imageList.Images.SetKeyName(40, "ZoomHH.bmp");
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(16, 603);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Ispis";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmSintetickiKontniPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIzlaz;
            this.ClientSize = new System.Drawing.Size(734, 638);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.sintetickiKontoDataGridView);
            this.Controls.Add(this.sintetickiKontoBindingNavigator);
            this.Controls.Add(this.txtDbfFajl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.txtKorisnik);
            this.Controls.Add(this.txtProgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSintetickiKontniPlan";
            this.Text = "Sintetički kontni plan";
            this.Load += new System.EventHandler(this.frmSintetickiKontniPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sintetickiKontoBindingNavigator)).EndInit();
            this.sintetickiKontoBindingNavigator.ResumeLayout(false);
            this.sintetickiKontoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sintetickiKontoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sintetickiKontoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.TextBox txtKorisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDbfFajl;
        private System.Windows.Forms.BindingSource sintetickiKontoBindingSource;
        private System.Windows.Forms.BindingNavigator sintetickiKontoBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView sintetickiKontoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ToolStripComboBox bindingNavigatorKonto;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox bindingNavigatorAOP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorNazivKonta;
        private System.Windows.Forms.ToolStripButton bindingNavigatorBtnTrazi;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ToolStripButton bindingNavigatorBtnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}