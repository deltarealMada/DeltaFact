namespace DeltaFact
{
    partial class f_modelefact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_modelefact));
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.comrealvistamod = new MySql.Data.MySqlClient.MySqlCommand();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bntValid = new System.Windows.Forms.Button();
            this.bntFemer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_ = new System.Windows.Forms.Button();
            this.edDocument = new System.Windows.Forms.TextBox();
            this.edNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.realvistaDataSet = new DeltaFact.realvistaDataSet();
            this.facturationTableAdapter = new DeltaFact.realvistaDataSetTableAdapters.facturationTableAdapter();
            this.bt_valider = new System.Windows.Forms.Button();
            this.comrech = new MySql.Data.MySqlClient.MySqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.bntFemer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.bntFemer.Click += new System.EventHandler(this.bntFemer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 147);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Etat Filename";
            // 
            // bt_
            // 
            this.bt_.ImageKey = "df.bmp";
            this.bt_.ImageList = this.imageList1;
            this.bt_.Location = new System.Drawing.Point(466, 161);
            this.bt_.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_.Name = "bt_";
            this.bt_.Size = new System.Drawing.Size(32, 23);
            this.bt_.TabIndex = 26;
            this.bt_.Tag = "3";
            this.bt_.UseVisualStyleBackColor = true;
            // 
            // edDocument
            // 
            this.edDocument.Location = new System.Drawing.Point(67, 163);
            this.edDocument.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.edDocument.Name = "edDocument";
            this.edDocument.Size = new System.Drawing.Size(399, 20);
            this.edDocument.TabIndex = 25;
            this.edDocument.Tag = "3";
            // 
            // edNom
            // 
            this.edNom.Location = new System.Drawing.Point(67, 120);
            this.edNom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.edNom.Name = "edNom";
            this.edNom.Size = new System.Drawing.Size(431, 20);
            this.edNom.TabIndex = 23;
            this.edNom.Tag = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nom type état";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 252);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(431, 223);
            this.dataGridView1.TabIndex = 30;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1334, 748);
            this.reportViewer1.TabIndex = 31;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
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
            // bt_valider
            // 
            this.bt_valider.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_valider.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_valider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_valider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_valider.ImageIndex = 1;
            this.bt_valider.ImageList = this.imageList1;
            this.bt_valider.Location = new System.Drawing.Point(1119, 766);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_valider.Size = new System.Drawing.Size(105, 30);
            this.bt_valider.TabIndex = 32;
            this.bt_valider.Tag = "2";
            this.bt_valider.Text = "valider  ";
            this.bt_valider.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // comrech
            // 
            this.comrech.CacheAge = 60;
            this.comrech.Connection = null;
            this.comrech.EnableCaching = false;
            this.comrech.Transaction = null;
            // 
            // f_modelefact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bntFemer;
            this.ClientSize = new System.Drawing.Size(1359, 807);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bntValid);
            this.Controls.Add(this.bntFemer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bt_);
            this.Controls.Add(this.edDocument);
            this.Controls.Add(this.edNom);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_modelefact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion de modèle de facture";
            this.Load += new System.EventHandler(this.f_modelefact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realvistaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        public MySql.Data.MySqlClient.MySqlCommand comrealvistamod;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bntValid;
        private System.Windows.Forms.Button bntFemer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_;
        private System.Windows.Forms.TextBox edDocument;
        private System.Windows.Forms.TextBox edNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource clientBindingSource;
        private realvistaDataSet realvistaDataSet;
        private realvistaDataSetTableAdapters.facturationTableAdapter facturationTableAdapter;
        public MySql.Data.MySqlClient.MySqlCommand comrech;
        public System.Windows.Forms.Button bt_valider;
    }
}