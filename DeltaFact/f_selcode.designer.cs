namespace DeltaFact
{
    partial class f_selcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_selcode));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.codearticlerech = new System.Windows.Forms.Label();
            this.edcode = new System.Windows.Forms.TextBox();
            this.btnFermer = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DeltaSQLCon = new MySql.Data.MySqlClient.MySqlCommand();
            this.g_idcodearticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_codearticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif_ligne1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif_ligne2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_unitecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_prix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_rabaispourcent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_rabaismontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idrabais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idprix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToResizeColumns = false;
            this.dgView.AllowUserToResizeRows = false;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_idcodearticle,
            this.g_codearticle,
            this.g_descriptif_ligne1,
            this.g_descriptif_ligne2,
            this.g_unitecode,
            this.g_prix,
            this.g_rabaispourcent,
            this.g_rabaismontant,
            this.g_idrabais,
            this.g_idprix});
            this.dgView.Location = new System.Drawing.Point(12, 52);
            this.dgView.MultiSelect = false;
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowHeadersVisible = false;
            this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgView.Size = new System.Drawing.Size(953, 317);
            this.dgView.TabIndex = 0;
            this.dgView.TabStop = false;
            this.dgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellDoubleClick);
            // 
            // codearticlerech
            // 
            this.codearticlerech.AutoSize = true;
            this.codearticlerech.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codearticlerech.Location = new System.Drawing.Point(12, 9);
            this.codearticlerech.Name = "codearticlerech";
            this.codearticlerech.Size = new System.Drawing.Size(71, 14);
            this.codearticlerech.TabIndex = 8;
            this.codearticlerech.Text = "code article";
            // 
            // edcode
            // 
            this.edcode.Location = new System.Drawing.Point(12, 26);
            this.edcode.Name = "edcode";
            this.edcode.Size = new System.Drawing.Size(204, 20);
            this.edcode.TabIndex = 1;
            this.edcode.Tag = "0";
            this.edcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edcode_KeyPress);
            // 
            // btnFermer
            // 
            this.btnFermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFermer.ImageKey = "system-log-out.ico";
            this.btnFermer.ImageList = this.imageList1;
            this.btnFermer.Location = new System.Drawing.Point(869, 375);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(94, 27);
            this.btnFermer.TabIndex = 2;
            this.btnFermer.Tag = "0";
            this.btnFermer.Text = "Fermer";
            this.btnFermer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "ok.ico");
            this.imageList1.Images.SetKeyName(1, "okay.ico");
            this.imageList1.Images.SetKeyName(2, "onebit_50.ico");
            this.imageList1.Images.SetKeyName(3, "onebit2 (1).ico");
            this.imageList1.Images.SetKeyName(4, "onebit2 (2).ico");
            this.imageList1.Images.SetKeyName(5, "onebit2 (3).ico");
            this.imageList1.Images.SetKeyName(6, "onebit2 (4).ico");
            this.imageList1.Images.SetKeyName(7, "onebit2 (13).ico");
            this.imageList1.Images.SetKeyName(8, "onebit2 (15).ico");
            this.imageList1.Images.SetKeyName(9, "onebit2 (18).ico");
            this.imageList1.Images.SetKeyName(10, "onebit2 (19).ico");
            this.imageList1.Images.SetKeyName(11, "onebit2 (33).ico");
            this.imageList1.Images.SetKeyName(12, "onebit2 (34).ico");
            this.imageList1.Images.SetKeyName(13, "onebit2 (35).ico");
            this.imageList1.Images.SetKeyName(14, "onebit2 (36).ico");
            this.imageList1.Images.SetKeyName(15, "onebit2 (37).ico");
            this.imageList1.Images.SetKeyName(16, "pencil.ico");
            this.imageList1.Images.SetKeyName(17, "Phone.ico");
            this.imageList1.Images.SetKeyName(18, "preferences-system.ico");
            this.imageList1.Images.SetKeyName(19, "preferences-system-windows.ico");
            this.imageList1.Images.SetKeyName(20, "printer.ico");
            this.imageList1.Images.SetKeyName(21, "process-stop.ico");
            this.imageList1.Images.SetKeyName(22, "refresh_backwards.ico");
            this.imageList1.Images.SetKeyName(23, "refresh_forward.ico");
            this.imageList1.Images.SetKeyName(24, "remove.ico");
            this.imageList1.Images.SetKeyName(25, "remove_minus_sign.ico");
            this.imageList1.Images.SetKeyName(26, "remove_outline.ico");
            this.imageList1.Images.SetKeyName(27, "search.ico");
            this.imageList1.Images.SetKeyName(28, "Settings.ico");
            this.imageList1.Images.SetKeyName(29, "sprocket_light.ico");
            this.imageList1.Images.SetKeyName(30, "system-file-manager.ico");
            this.imageList1.Images.SetKeyName(31, "system-log-out.ico");
            this.imageList1.Images.SetKeyName(32, "system-search.ico");
            this.imageList1.Images.SetKeyName(33, "onebit2 (19).ico");
            this.imageList1.Images.SetKeyName(34, "onebit2 (30).ico");
            this.imageList1.Images.SetKeyName(35, "onebit_20.ico");
            // 
            // DeltaSQLCon
            // 
            this.DeltaSQLCon.CacheAge = 0;
            this.DeltaSQLCon.Connection = null;
            this.DeltaSQLCon.EnableCaching = false;
            this.DeltaSQLCon.Transaction = null;
            // 
            // g_idcodearticle
            // 
            this.g_idcodearticle.DataPropertyName = "idcompte";
            this.g_idcodearticle.HeaderText = "Column1";
            this.g_idcodearticle.MinimumWidth = 2;
            this.g_idcodearticle.Name = "g_idcodearticle";
            this.g_idcodearticle.ReadOnly = true;
            this.g_idcodearticle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.g_idcodearticle.Width = 2;
            // 
            // g_codearticle
            // 
            this.g_codearticle.DataPropertyName = "codearticle";
            this.g_codearticle.HeaderText = "code article";
            this.g_codearticle.Name = "g_codearticle";
            this.g_codearticle.ReadOnly = true;
            this.g_codearticle.Width = 80;
            // 
            // g_descriptif_ligne1
            // 
            this.g_descriptif_ligne1.DataPropertyName = "descriptif_ligne1";
            this.g_descriptif_ligne1.HeaderText = "descriptif ligne1";
            this.g_descriptif_ligne1.Name = "g_descriptif_ligne1";
            this.g_descriptif_ligne1.ReadOnly = true;
            this.g_descriptif_ligne1.Width = 250;
            // 
            // g_descriptif_ligne2
            // 
            this.g_descriptif_ligne2.DataPropertyName = "descriptif_ligne2";
            this.g_descriptif_ligne2.HeaderText = "descriptif ligne2";
            this.g_descriptif_ligne2.Name = "g_descriptif_ligne2";
            this.g_descriptif_ligne2.ReadOnly = true;
            this.g_descriptif_ligne2.Width = 250;
            // 
            // g_unitecode
            // 
            this.g_unitecode.DataPropertyName = "unitecode";
            this.g_unitecode.HeaderText = "unite";
            this.g_unitecode.Name = "g_unitecode";
            this.g_unitecode.ReadOnly = true;
            // 
            // g_prix
            // 
            this.g_prix.DataPropertyName = "prix";
            this.g_prix.HeaderText = "prix unitaire";
            this.g_prix.Name = "g_prix";
            this.g_prix.ReadOnly = true;
            this.g_prix.Width = 80;
            // 
            // g_rabaispourcent
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_rabaispourcent.DefaultCellStyle = dataGridViewCellStyle3;
            this.g_rabaispourcent.HeaderText = "rabais %";
            this.g_rabaispourcent.Name = "g_rabaispourcent";
            this.g_rabaispourcent.ReadOnly = true;
            this.g_rabaispourcent.Width = 80;
            // 
            // g_rabaismontant
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_rabaismontant.DefaultCellStyle = dataGridViewCellStyle4;
            this.g_rabaismontant.HeaderText = "rabais chf";
            this.g_rabaismontant.Name = "g_rabaismontant";
            this.g_rabaismontant.ReadOnly = true;
            this.g_rabaismontant.Width = 80;
            // 
            // g_idrabais
            // 
            this.g_idrabais.HeaderText = "idrabais";
            this.g_idrabais.Name = "g_idrabais";
            this.g_idrabais.ReadOnly = true;
            this.g_idrabais.Visible = false;
            // 
            // g_idprix
            // 
            this.g_idprix.HeaderText = "idprix";
            this.g_idprix.Name = "g_idprix";
            this.g_idprix.ReadOnly = true;
            this.g_idprix.Visible = false;
            // 
            // f_selcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFermer;
            this.ClientSize = new System.Drawing.Size(975, 407);
            this.ControlBox = false;
            this.Controls.Add(this.edcode);
            this.Controls.Add(this.codearticlerech);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.dgView);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_selcode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Liste marchandises";
            this.Load += new System.EventHandler(this.F_langues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label codearticlerech;
        public MySql.Data.MySqlClient.MySqlCommand DeltaSQLCon;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.DataGridView dgView;
        public System.Windows.Forms.TextBox edcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idcodearticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_codearticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif_ligne1;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif_ligne2;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_unitecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_prix;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_rabaispourcent;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_rabaismontant;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idrabais;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idprix;
    }
}