namespace DeltaFact
{
    partial class f_selection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_selection));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comrealvistamod = new MySql.Data.MySqlClient.MySqlCommand();
            this.bt_fermer = new System.Windows.Forms.Button();
            this.gv_client = new System.Windows.Forms.DataGridView();
            this.g_refclient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_raisonsociale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_politesse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_adresse1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_adresse2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_npa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_ville = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_client)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // comrealvistamod
            // 
            this.comrealvistamod.CacheAge = 60;
            this.comrealvistamod.Connection = null;
            this.comrealvistamod.EnableCaching = false;
            this.comrealvistamod.Transaction = null;
            // 
            // bt_fermer
            // 
            this.bt_fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_fermer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_fermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fermer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_fermer.ImageIndex = 10;
            this.bt_fermer.ImageList = this.imageList1;
            this.bt_fermer.Location = new System.Drawing.Point(1045, 383);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_fermer.Size = new System.Drawing.Size(118, 30);
            this.bt_fermer.TabIndex = 7;
            this.bt_fermer.Tag = "9";
            this.bt_fermer.Text = "FERMER  ";
            this.bt_fermer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_fermer.UseVisualStyleBackColor = true;
            // 
            // gv_client
            // 
            this.gv_client.AllowUserToAddRows = false;
            this.gv_client.AllowUserToDeleteRows = false;
            this.gv_client.AllowUserToResizeColumns = false;
            this.gv_client.AllowUserToResizeRows = false;
            this.gv_client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_client.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_refclient,
            this.g_raisonsociale,
            this.g_politesse,
            this.g_nom,
            this.g_prenom,
            this.g_co,
            this.g_adresse1,
            this.g_adresse2,
            this.g_npa,
            this.g_ville});
            this.gv_client.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gv_client.Location = new System.Drawing.Point(12, 12);
            this.gv_client.Name = "gv_client";
            this.gv_client.ReadOnly = true;
            this.gv_client.RowHeadersVisible = false;
            this.gv_client.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_client.Size = new System.Drawing.Size(1151, 365);
            this.gv_client.TabIndex = 8;
            this.gv_client.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_client_CellDoubleClick);
            // 
            // g_refclient
            // 
            this.g_refclient.HeaderText = "ref         client";
            this.g_refclient.Name = "g_refclient";
            this.g_refclient.ReadOnly = true;
            this.g_refclient.Width = 65;
            // 
            // g_raisonsociale
            // 
            this.g_raisonsociale.HeaderText = "raison sociale";
            this.g_raisonsociale.Name = "g_raisonsociale";
            this.g_raisonsociale.ReadOnly = true;
            this.g_raisonsociale.Width = 120;
            // 
            // g_politesse
            // 
            this.g_politesse.HeaderText = "politesse";
            this.g_politesse.Name = "g_politesse";
            this.g_politesse.ReadOnly = true;
            this.g_politesse.Width = 75;
            // 
            // g_nom
            // 
            this.g_nom.HeaderText = "nom";
            this.g_nom.Name = "g_nom";
            this.g_nom.ReadOnly = true;
            this.g_nom.Width = 150;
            // 
            // g_prenom
            // 
            this.g_prenom.HeaderText = "prénom";
            this.g_prenom.Name = "g_prenom";
            this.g_prenom.ReadOnly = true;
            this.g_prenom.Width = 150;
            // 
            // g_co
            // 
            this.g_co.HeaderText = "c/o";
            this.g_co.Name = "g_co";
            this.g_co.ReadOnly = true;
            this.g_co.Width = 150;
            // 
            // g_adresse1
            // 
            this.g_adresse1.HeaderText = "adresse1";
            this.g_adresse1.Name = "g_adresse1";
            this.g_adresse1.ReadOnly = true;
            this.g_adresse1.Width = 120;
            // 
            // g_adresse2
            // 
            this.g_adresse2.HeaderText = "adresse 2";
            this.g_adresse2.Name = "g_adresse2";
            this.g_adresse2.ReadOnly = true;
            this.g_adresse2.Width = 120;
            // 
            // g_npa
            // 
            this.g_npa.HeaderText = "npa";
            this.g_npa.Name = "g_npa";
            this.g_npa.ReadOnly = true;
            this.g_npa.Width = 60;
            // 
            // g_ville
            // 
            this.g_ville.HeaderText = "ville";
            this.g_ville.Name = "g_ville";
            this.g_ville.ReadOnly = true;
            this.g_ville.Width = 120;
            // 
            // f_selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_fermer;
            this.ClientSize = new System.Drawing.Size(1178, 425);
            this.ControlBox = false;
            this.Controls.Add(this.gv_client);
            this.Controls.Add(this.bt_fermer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_selection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Liste";
            this.Load += new System.EventHandler(this.f_selection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_client)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        public MySql.Data.MySqlClient.MySqlCommand comrealvistamod;
        private System.Windows.Forms.Button bt_fermer;
        private System.Windows.Forms.DataGridView gv_client;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_refclient;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_raisonsociale;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_politesse;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_adresse1;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_adresse2;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_npa;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_ville;
    }
}