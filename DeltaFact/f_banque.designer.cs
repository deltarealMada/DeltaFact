namespace DeltaFact
{
    partial class f_banque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_banque));
            this.gvins = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DeltaSQLTmp = new MySql.Data.MySqlClient.MySqlCommand();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bt_annuler = new System.Windows.Forms.Button();
            this.bt_modifier = new System.Windows.Forms.Button();
            this.bt_valider = new System.Windows.Forms.Button();
            this.bt_ajouter = new System.Windows.Forms.Button();
            this.bt_fermer = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.ed_nom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ed_sic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ed_cb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_tout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gvins
            // 
            this.gvins.AllowUserToDeleteRows = false;
            this.gvins.AllowUserToOrderColumns = true;
            this.gvins.AllowUserToResizeRows = false;
            this.gvins.AutoGenerateColumns = false;
            this.gvins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvins.DataSource = this.bindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = " ";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvins.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvins.EnableHeadersVisualStyles = false;
            this.gvins.Location = new System.Drawing.Point(12, 42);
            this.gvins.Name = "gvins";
            this.gvins.RowHeadersVisible = false;
            this.gvins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvins.Size = new System.Drawing.Size(974, 282);
            this.gvins.TabIndex = 4;
            this.gvins.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvins_CellDoubleClick);
            // 
            // DeltaSQLTmp
            // 
            this.DeltaSQLTmp.CacheAge = 0;
            this.DeltaSQLTmp.CommandTimeout = 120;
            this.DeltaSQLTmp.Connection = null;
            this.DeltaSQLTmp.EnableCaching = false;
            this.DeltaSQLTmp.Transaction = null;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "onebit2 (33).ico");
            this.imageList1.Images.SetKeyName(1, "onebit2 (34).ico");
            this.imageList1.Images.SetKeyName(2, "refresh_forward.ico");
            this.imageList1.Images.SetKeyName(3, "onebit2 (19).ico");
            this.imageList1.Images.SetKeyName(4, "onebit2 (30).ico");
            this.imageList1.Images.SetKeyName(5, "WebServer.bmp");
            this.imageList1.Images.SetKeyName(6, "install.bmp");
            // 
            // bt_annuler
            // 
            this.bt_annuler.ImageIndex = 2;
            this.bt_annuler.ImageList = this.imageList1;
            this.bt_annuler.Location = new System.Drawing.Point(222, 330);
            this.bt_annuler.Name = "bt_annuler";
            this.bt_annuler.Size = new System.Drawing.Size(95, 23);
            this.bt_annuler.TabIndex = 9;
            this.bt_annuler.Text = "Annuler";
            this.bt_annuler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_annuler.UseVisualStyleBackColor = true;
            // 
            // bt_modifier
            // 
            this.bt_modifier.ImageIndex = 3;
            this.bt_modifier.ImageList = this.imageList1;
            this.bt_modifier.Location = new System.Drawing.Point(117, 330);
            this.bt_modifier.Name = "bt_modifier";
            this.bt_modifier.Size = new System.Drawing.Size(95, 23);
            this.bt_modifier.TabIndex = 8;
            this.bt_modifier.Text = " Modifier";
            this.bt_modifier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_modifier.UseVisualStyleBackColor = true;
            // 
            // bt_valider
            // 
            this.bt_valider.ImageIndex = 0;
            this.bt_valider.ImageList = this.imageList1;
            this.bt_valider.Location = new System.Drawing.Point(327, 330);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(95, 23);
            this.bt_valider.TabIndex = 10;
            this.bt_valider.Text = "Valider";
            this.bt_valider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_valider.UseVisualStyleBackColor = true;
            // 
            // bt_ajouter
            // 
            this.bt_ajouter.ImageIndex = 4;
            this.bt_ajouter.ImageList = this.imageList1;
            this.bt_ajouter.Location = new System.Drawing.Point(12, 330);
            this.bt_ajouter.Name = "bt_ajouter";
            this.bt_ajouter.Size = new System.Drawing.Size(95, 23);
            this.bt_ajouter.TabIndex = 7;
            this.bt_ajouter.Text = " Ajouter";
            this.bt_ajouter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_ajouter.UseVisualStyleBackColor = true;
            // 
            // bt_fermer
            // 
            this.bt_fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_fermer.ImageIndex = 1;
            this.bt_fermer.ImageList = this.imageList1;
            this.bt_fermer.Location = new System.Drawing.Point(905, 330);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Size = new System.Drawing.Size(81, 23);
            this.bt_fermer.TabIndex = 11;
            this.bt_fermer.Text = " fermer";
            this.bt_fermer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_fermer.UseVisualStyleBackColor = true;
            this.bt_fermer.Click += new System.EventHandler(this.bt_fermer_Click);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "nom banque";
            // 
            // ed_nom
            // 
            this.ed_nom.Location = new System.Drawing.Point(383, 11);
            this.ed_nom.Name = "ed_nom";
            this.ed_nom.Size = new System.Drawing.Size(128, 20);
            this.ed_nom.TabIndex = 24;
            this.ed_nom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ed_nom_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "n° sic";
            // 
            // ed_sic
            // 
            this.ed_sic.Location = new System.Drawing.Point(236, 11);
            this.ed_sic.Name = "ed_sic";
            this.ed_sic.Size = new System.Drawing.Size(67, 20);
            this.ed_sic.TabIndex = 22;
            this.ed_sic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ed_sic_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "n° cb";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Recherche";
            // 
            // ed_cb
            // 
            this.ed_cb.Location = new System.Drawing.Point(125, 11);
            this.ed_cb.Name = "ed_cb";
            this.ed_cb.Size = new System.Drawing.Size(67, 20);
            this.ed_cb.TabIndex = 19;
            this.ed_cb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ed_cb_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(535, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "OU";
            // 
            // bt_tout
            // 
            this.bt_tout.Location = new System.Drawing.Point(566, 8);
            this.bt_tout.Name = "bt_tout";
            this.bt_tout.Size = new System.Drawing.Size(84, 23);
            this.bt_tout.TabIndex = 27;
            this.bt_tout.Text = "Afficher tout";
            this.bt_tout.UseVisualStyleBackColor = true;
            this.bt_tout.Click += new System.EventHandler(this.bt_tout_Click);
            // 
            // f_banque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 363);
            this.Controls.Add(this.bt_tout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ed_nom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ed_sic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ed_cb);
            this.Controls.Add(this.bt_annuler);
            this.Controls.Add(this.bt_modifier);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.bt_ajouter);
            this.Controls.Add(this.bt_fermer);
            this.Controls.Add(this.gvins);
            this.Name = "f_banque";
            this.Text = "Liste Banques";
            this.Load += new System.EventHandler(this.f_banque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView gvins;
        public MySql.Data.MySqlClient.MySqlCommand DeltaSQLTmp;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bt_annuler;
        private System.Windows.Forms.Button bt_modifier;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.Button bt_ajouter;
        private System.Windows.Forms.Button bt_fermer;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ed_nom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ed_sic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ed_cb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_tout;
    }
}