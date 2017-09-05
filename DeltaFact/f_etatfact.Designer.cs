namespace DeltaFact
{
    partial class f_etatfact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_etatfact));
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.comrealvistamod = new MySql.Data.MySqlClient.MySqlCommand();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bntValid = new System.Windows.Forms.Button();
            this.bntFemer = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pboutons = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_annul = new System.Windows.Forms.Button();
            this.ck_paye = new System.Windows.Forms.RadioButton();
            this.ck_envoye = new System.Windows.Forms.RadioButton();
            this.bt_valideretat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.datefin = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.datedeb = new System.Windows.Forms.DateTimePicker();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.realvistaDataSet = new DeltaFact.realvistaDataSet();
            this.facturationTableAdapter = new DeltaFact.realvistaDataSetTableAdapters.facturationTableAdapter();
            this.pboutons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realvistaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // comrealvistamod
            // 
            this.comrealvistamod.CacheAge = 60;
            this.comrealvistamod.Connection = null;
            this.comrealvistamod.EnableCaching = false;
            this.comrealvistamod.Transaction = null;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "onebit2 (3).ico");
            this.imageList1.Images.SetKeyName(1, "onebit2 (14).ico");
            this.imageList1.Images.SetKeyName(2, "onebit2 (19).ico");
            this.imageList1.Images.SetKeyName(3, "onebit2 (26).ico");
            this.imageList1.Images.SetKeyName(4, "onebit2 (28).ico");
            this.imageList1.Images.SetKeyName(5, "onebit2 (30).ico");
            this.imageList1.Images.SetKeyName(6, "onebit2 (31).ico");
            this.imageList1.Images.SetKeyName(7, "onebit2 (33).ico");
            this.imageList1.Images.SetKeyName(8, "onebit2 (34).ico");
            this.imageList1.Images.SetKeyName(9, "refresh_backwards.ico");
            this.imageList1.Images.SetKeyName(10, "Exit.gif");
            this.imageList1.Images.SetKeyName(11, "search_glyph.png");
            this.imageList1.Images.SetKeyName(12, "searchDocuments.bmp");
            this.imageList1.Images.SetKeyName(13, "menu_dropdown.ico");
            this.imageList1.Images.SetKeyName(14, "newFolder.bmp");
            this.imageList1.Images.SetKeyName(15, "XPfolder_closed.bmp");
            this.imageList1.Images.SetKeyName(16, "printer.bmp");
            this.imageList1.Images.SetKeyName(17, "printer.ico");
            this.imageList1.Images.SetKeyName(18, "df.bmp");
            this.imageList1.Images.SetKeyName(19, "Exit.gif");
            // 
            // bntValid
            // 
            this.bntValid.ImageKey = "onebit2 (33).ico";
            this.bntValid.ImageList = this.imageList1;
            this.bntValid.Location = new System.Drawing.Point(412, 687);
            this.bntValid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bntValid.Name = "bntValid";
            this.bntValid.Size = new System.Drawing.Size(115, 29);
            this.bntValid.TabIndex = 28;
            this.bntValid.Text = "   Valider";
            this.bntValid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntValid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bntValid.UseVisualStyleBackColor = true;
            this.bntValid.Click += new System.EventHandler(this.bntValid_Click);
            // 
            // bntFemer
            // 
            this.bntFemer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bntFemer.ImageKey = "Exit.gif";
            this.bntFemer.ImageList = this.imageList1;
            this.bntFemer.Location = new System.Drawing.Point(1231, 766);
            this.bntFemer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bntFemer.Name = "bntFemer";
            this.bntFemer.Size = new System.Drawing.Size(115, 29);
            this.bntFemer.TabIndex = 29;
            this.bntFemer.Text = "   Fermer";
            this.bntFemer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntFemer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bntFemer.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 24);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1334, 736);
            this.reportViewer1.TabIndex = 31;
            this.reportViewer1.Visible = false;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // pboutons
            // 
            this.pboutons.Controls.Add(this.label2);
            this.pboutons.Controls.Add(this.bt_annul);
            this.pboutons.Controls.Add(this.ck_paye);
            this.pboutons.Controls.Add(this.ck_envoye);
            this.pboutons.Controls.Add(this.bt_valideretat);
            this.pboutons.Controls.Add(this.label1);
            this.pboutons.Controls.Add(this.datefin);
            this.pboutons.Controls.Add(this.label27);
            this.pboutons.Controls.Add(this.datedeb);
            this.pboutons.Location = new System.Drawing.Point(21, 24);
            this.pboutons.Name = "pboutons";
            this.pboutons.Size = new System.Drawing.Size(251, 178);
            this.pboutons.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "ETAT DE FACTURE";
            // 
            // bt_annul
            // 
            this.bt_annul.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_annul.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_annul.ImageIndex = 9;
            this.bt_annul.ImageList = this.imageList1;
            this.bt_annul.Location = new System.Drawing.Point(29, 132);
            this.bt_annul.Name = "bt_annul";
            this.bt_annul.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_annul.Size = new System.Drawing.Size(80, 21);
            this.bt_annul.TabIndex = 21;
            this.bt_annul.Tag = "2";
            this.bt_annul.Text = "annuler";
            this.bt_annul.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_annul.UseVisualStyleBackColor = true;
            // 
            // ck_paye
            // 
            this.ck_paye.AutoSize = true;
            this.ck_paye.Location = new System.Drawing.Point(115, 47);
            this.ck_paye.Name = "ck_paye";
            this.ck_paye.Size = new System.Drawing.Size(59, 17);
            this.ck_paye.TabIndex = 20;
            this.ck_paye.TabStop = true;
            this.ck_paye.Text = "payées";
            this.ck_paye.UseVisualStyleBackColor = true;
            // 
            // ck_envoye
            // 
            this.ck_envoye.AutoSize = true;
            this.ck_envoye.Location = new System.Drawing.Point(29, 47);
            this.ck_envoye.Name = "ck_envoye";
            this.ck_envoye.Size = new System.Drawing.Size(71, 17);
            this.ck_envoye.TabIndex = 19;
            this.ck_envoye.TabStop = true;
            this.ck_envoye.Text = "envoyées";
            this.ck_envoye.UseVisualStyleBackColor = true;
            // 
            // bt_valideretat
            // 
            this.bt_valideretat.ImageKey = "onebit2 (33).ico";
            this.bt_valideretat.ImageList = this.imageList1;
            this.bt_valideretat.Location = new System.Drawing.Point(115, 132);
            this.bt_valideretat.Margin = new System.Windows.Forms.Padding(0);
            this.bt_valideretat.Name = "bt_valideretat";
            this.bt_valideretat.Size = new System.Drawing.Size(80, 21);
            this.bt_valideretat.TabIndex = 18;
            this.bt_valideretat.Tag = "8";
            this.bt_valideretat.Text = "OK";
            this.bt_valideretat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_valideretat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_valideretat.UseVisualStyleBackColor = true;
            this.bt_valideretat.Click += new System.EventHandler(this.bt_valideretat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "au";
            // 
            // datefin
            // 
            this.datefin.AccessibleName = "datefin";
            this.datefin.CalendarMonthBackground = System.Drawing.Color.White;
            this.datefin.CausesValidation = false;
            this.datefin.CustomFormat = "dd.MM.yyyy";
            this.datefin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datefin.Location = new System.Drawing.Point(115, 92);
            this.datefin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.datefin.Name = "datefin";
            this.datefin.Size = new System.Drawing.Size(80, 20);
            this.datefin.TabIndex = 15;
            this.datefin.Tag = "6";
            this.datefin.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(26, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(19, 13);
            this.label27.TabIndex = 14;
            this.label27.Text = "du";
            // 
            // datedeb
            // 
            this.datedeb.AccessibleName = "datedeb";
            this.datedeb.CalendarMonthBackground = System.Drawing.Color.White;
            this.datedeb.CustomFormat = "dd.MM.yyyy";
            this.datedeb.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datedeb.Location = new System.Drawing.Point(29, 92);
            this.datedeb.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.datedeb.Name = "datedeb";
            this.datedeb.Size = new System.Drawing.Size(80, 20);
            this.datedeb.TabIndex = 13;
            this.datedeb.Tag = "6";
            this.datedeb.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "facturation";
            this.clientBindingSource.DataSource = this.realvistaDataSet;
            // 
            // realvistaDataSet
            // 
            this.realvistaDataSet.DataSetName = "realvistaDataSet";
            this.realvistaDataSet.EnforceConstraints = false;
            this.realvistaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturationTableAdapter
            // 
            this.facturationTableAdapter.ClearBeforeFill = true;
            // 
            // f_etatfact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bntFemer;
            this.ClientSize = new System.Drawing.Size(284, 215);
            this.Controls.Add(this.pboutons);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.bntValid);
            this.Controls.Add(this.bntFemer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_etatfact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Etats de Facture";
            this.Load += new System.EventHandler(this.f_etatfact_Load);
            this.pboutons.ResumeLayout(false);
            this.pboutons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realvistaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        public MySql.Data.MySqlClient.MySqlCommand comrealvistamod;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bntValid;
        private System.Windows.Forms.Button bntFemer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource clientBindingSource;
        private realvistaDataSet realvistaDataSet;
        private realvistaDataSetTableAdapters.facturationTableAdapter facturationTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datefin;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker datedeb;
        private System.Windows.Forms.Button bt_valideretat;
        private System.Windows.Forms.RadioButton ck_paye;
        private System.Windows.Forms.RadioButton ck_envoye;
        private System.Windows.Forms.Button bt_annul;
        public System.Windows.Forms.Panel pboutons;
        private System.Windows.Forms.Label label2;
    }
}