namespace DeltaFact
{
    partial class f_importation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_importation));
            this.FileDg = new System.Windows.Forms.OpenFileDialog();
            this.gvins = new System.Windows.Forms.DataGridView();
            this.comrealvistamod = new MySql.Data.MySqlClient.MySqlCommand();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comrech = new MySql.Data.MySqlClient.MySqlCommand();
            this.bt_importer = new System.Windows.Forms.Button();
            this.bt_verifier = new System.Windows.Forms.Button();
            this.bt_verifaddclient = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.bt_validerimport = new System.Windows.Forms.Button();
            this.comboMi2 = new WindowsFormsControlLibrary1.ComboMi();
            this.comboMi1 = new WindowsFormsControlLibrary1.ComboMi();
            this.men_col = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.définirLaColonnea = new System.Windows.Forms.ToolStripMenuItem();
            this.politesseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.socligneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prénomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adresse1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adresse2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.npaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.villeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateFactureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réfFactureEntrepriseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateCommandeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noCommandebonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libelléArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nbrArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remarqueArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_errsuiv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvins)).BeginInit();
            this.men_col.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDg
            // 
            this.FileDg.Filter = "Fichier Excel XLSX|*.xlsx|Fichiers Excel XLS|*.xls|Fichier texte|*.txt;*.csv";
            // 
            // gvins
            // 
            this.gvins.AllowUserToAddRows = false;
            this.gvins.AllowUserToOrderColumns = true;
            this.gvins.AllowUserToResizeRows = false;
            this.gvins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvins.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvins.ContextMenuStrip = this.men_col;
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
            this.gvins.Location = new System.Drawing.Point(30, 29);
            this.gvins.Name = "gvins";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvins.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvins.Size = new System.Drawing.Size(1245, 654);
            this.gvins.TabIndex = 6;
            this.gvins.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvins_CellBeginEdit);
            this.gvins.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvins_CellContentClick);
            this.gvins.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvins_CellDoubleClick);
            this.gvins.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvins_CellEndEdit);
            this.gvins.CurrentCellChanged += new System.EventHandler(this.gvins_CurrentCellChanged);
            this.gvins.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gvins_Scroll);
            this.gvins.Click += new System.EventHandler(this.gvins_Click);
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
            // 
            // comrech
            // 
            this.comrech.CacheAge = 60;
            this.comrech.Connection = null;
            this.comrech.EnableCaching = false;
            this.comrech.Transaction = null;
            // 
            // bt_importer
            // 
            this.bt_importer.Location = new System.Drawing.Point(674, 689);
            this.bt_importer.Name = "bt_importer";
            this.bt_importer.Size = new System.Drawing.Size(109, 23);
            this.bt_importer.TabIndex = 7;
            this.bt_importer.Text = "Charger un fichier";
            this.bt_importer.UseVisualStyleBackColor = true;
            this.bt_importer.Click += new System.EventHandler(this.bt_importer_Click);
            // 
            // bt_verifier
            // 
            this.bt_verifier.Enabled = false;
            this.bt_verifier.Location = new System.Drawing.Point(789, 688);
            this.bt_verifier.Name = "bt_verifier";
            this.bt_verifier.Size = new System.Drawing.Size(122, 23);
            this.bt_verifier.TabIndex = 8;
            this.bt_verifier.Text = "vérifier les données";
            this.bt_verifier.UseVisualStyleBackColor = true;
            this.bt_verifier.Click += new System.EventHandler(this.bt_verifier_Click);
            // 
            // bt_verifaddclient
            // 
            this.bt_verifaddclient.Enabled = false;
            this.bt_verifaddclient.Location = new System.Drawing.Point(1014, 689);
            this.bt_verifaddclient.Name = "bt_verifaddclient";
            this.bt_verifaddclient.Size = new System.Drawing.Size(111, 23);
            this.bt_verifaddclient.TabIndex = 9;
            this.bt_verifaddclient.Text = "vérifier/ajout client";
            this.bt_verifaddclient.UseVisualStyleBackColor = true;
            this.bt_verifaddclient.Click += new System.EventHandler(this.bt_verifaddclient_Click);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // bt_validerimport
            // 
            this.bt_validerimport.Enabled = false;
            this.bt_validerimport.Location = new System.Drawing.Point(1131, 689);
            this.bt_validerimport.Name = "bt_validerimport";
            this.bt_validerimport.Size = new System.Drawing.Size(146, 23);
            this.bt_validerimport.TabIndex = 10;
            this.bt_validerimport.Text = "Valider importation";
            this.bt_validerimport.UseVisualStyleBackColor = true;
            this.bt_validerimport.Click += new System.EventHandler(this.bt_validerimport_Click);
            // 
            // comboMi2
            // 
            this.comboMi2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comboMi2.IndCombo = null;
            this.comboMi2.LargeurCol2 = 267;
            this.comboMi2.Location = new System.Drawing.Point(537, 689);
            this.comboMi2.Name = "comboMi2";
            this.comboMi2.Size = new System.Drawing.Size(106, 22);
            this.comboMi2.TabIndex = 103;
            this.comboMi2.Visible = false;
            this.comboMi2.Combo_DropDown += new WindowsFormsControlLibrary1.ComboMi.Combo_DropDHandler(this.comboMi2_Combo_DropDown);
            this.comboMi2.Combo_DropUp += new WindowsFormsControlLibrary1.ComboMi.Combo_DropUHandler(this.comboMi2_Combo_DropUp);
            // 
            // comboMi1
            // 
            this.comboMi1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comboMi1.IndCombo = null;
            this.comboMi1.LargeurCol2 = 267;
            this.comboMi1.Location = new System.Drawing.Point(410, 689);
            this.comboMi1.Name = "comboMi1";
            this.comboMi1.Size = new System.Drawing.Size(106, 22);
            this.comboMi1.TabIndex = 102;
            this.comboMi1.Visible = false;
            this.comboMi1.Combo_DropDown += new WindowsFormsControlLibrary1.ComboMi.Combo_DropDHandler(this.comboMi1_Combo_DropDown);
            this.comboMi1.Combo_DropUp += new WindowsFormsControlLibrary1.ComboMi.Combo_DropUHandler(this.comboMi1_Combo_DropUp);
            // 
            // men_col
            // 
            this.men_col.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.définirLaColonnea});
            this.men_col.Name = "men_col";
            this.men_col.Size = new System.Drawing.Size(168, 26);
            this.men_col.Opening += new System.ComponentModel.CancelEventHandler(this.men_col_Opening);
            // 
            // définirLaColonnea
            // 
            this.définirLaColonnea.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.politesseToolStripMenuItem,
            this.socligneToolStripMenuItem,
            this.prénomToolStripMenuItem,
            this.nomToolStripMenuItem,
            this.coToolStripMenuItem,
            this.adresse1ToolStripMenuItem,
            this.adresse2ToolStripMenuItem,
            this.npaToolStripMenuItem,
            this.villeToolStripMenuItem,
            this.dateFactureToolStripMenuItem,
            this.réfFactureEntrepriseToolStripMenuItem,
            this.dateCommandeToolStripMenuItem,
            this.noCommandebonToolStripMenuItem,
            this.codeArticleToolStripMenuItem,
            this.libelléArticleToolStripMenuItem,
            this.nbrArticleToolStripMenuItem,
            this.remarqueArticleToolStripMenuItem});
            this.définirLaColonnea.Name = "définirLaColonnea";
            this.définirLaColonnea.Size = new System.Drawing.Size(167, 22);
            this.définirLaColonnea.Text = "Définir la colonne";
            // 
            // politesseToolStripMenuItem
            // 
            this.politesseToolStripMenuItem.Name = "politesseToolStripMenuItem";
            this.politesseToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.politesseToolStripMenuItem.Text = "politesse";
            this.politesseToolStripMenuItem.ToolTipText = "politesse";
            // 
            // socligneToolStripMenuItem
            // 
            this.socligneToolStripMenuItem.Name = "socligneToolStripMenuItem";
            this.socligneToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.socligneToolStripMenuItem.Text = "socligne";
            this.socligneToolStripMenuItem.ToolTipText = "socligne";
            // 
            // prénomToolStripMenuItem
            // 
            this.prénomToolStripMenuItem.Name = "prénomToolStripMenuItem";
            this.prénomToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.prénomToolStripMenuItem.Text = "prénom";
            this.prénomToolStripMenuItem.ToolTipText = "prenom";
            // 
            // nomToolStripMenuItem
            // 
            this.nomToolStripMenuItem.Name = "nomToolStripMenuItem";
            this.nomToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nomToolStripMenuItem.Text = "nom";
            this.nomToolStripMenuItem.ToolTipText = "nom";
            // 
            // coToolStripMenuItem
            // 
            this.coToolStripMenuItem.Name = "coToolStripMenuItem";
            this.coToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.coToolStripMenuItem.Text = "co";
            this.coToolStripMenuItem.ToolTipText = "co";
            // 
            // adresse1ToolStripMenuItem
            // 
            this.adresse1ToolStripMenuItem.Name = "adresse1ToolStripMenuItem";
            this.adresse1ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.adresse1ToolStripMenuItem.Text = "adresse1";
            this.adresse1ToolStripMenuItem.ToolTipText = "adresse1";
            // 
            // adresse2ToolStripMenuItem
            // 
            this.adresse2ToolStripMenuItem.Name = "adresse2ToolStripMenuItem";
            this.adresse2ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.adresse2ToolStripMenuItem.Text = "adresse2";
            this.adresse2ToolStripMenuItem.ToolTipText = "adresse2";
            // 
            // npaToolStripMenuItem
            // 
            this.npaToolStripMenuItem.Name = "npaToolStripMenuItem";
            this.npaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.npaToolStripMenuItem.Text = "npa";
            this.npaToolStripMenuItem.ToolTipText = "zip";
            // 
            // villeToolStripMenuItem
            // 
            this.villeToolStripMenuItem.Name = "villeToolStripMenuItem";
            this.villeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.villeToolStripMenuItem.Text = "ville";
            this.villeToolStripMenuItem.ToolTipText = "cityname";
            // 
            // dateFactureToolStripMenuItem
            // 
            this.dateFactureToolStripMenuItem.Name = "dateFactureToolStripMenuItem";
            this.dateFactureToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.dateFactureToolStripMenuItem.Text = "date facture";
            this.dateFactureToolStripMenuItem.ToolTipText = "date_facture";
            // 
            // réfFactureEntrepriseToolStripMenuItem
            // 
            this.réfFactureEntrepriseToolStripMenuItem.Name = "réfFactureEntrepriseToolStripMenuItem";
            this.réfFactureEntrepriseToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.réfFactureEntrepriseToolStripMenuItem.Text = "réf. facture entreprise";
            this.réfFactureEntrepriseToolStripMenuItem.ToolTipText = "reffact_entreprise";
            // 
            // dateCommandeToolStripMenuItem
            // 
            this.dateCommandeToolStripMenuItem.Name = "dateCommandeToolStripMenuItem";
            this.dateCommandeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.dateCommandeToolStripMenuItem.Text = "date commande";
            this.dateCommandeToolStripMenuItem.ToolTipText = "date_commande";
            // 
            // noCommandebonToolStripMenuItem
            // 
            this.noCommandebonToolStripMenuItem.Name = "noCommandebonToolStripMenuItem";
            this.noCommandebonToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.noCommandebonToolStripMenuItem.Text = "no commande (bon)";
            this.noCommandebonToolStripMenuItem.ToolTipText = "no_commande";
            // 
            // codeArticleToolStripMenuItem
            // 
            this.codeArticleToolStripMenuItem.Name = "codeArticleToolStripMenuItem";
            this.codeArticleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.codeArticleToolStripMenuItem.Text = "code article";
            this.codeArticleToolStripMenuItem.ToolTipText = "codearticle";
            // 
            // libelléArticleToolStripMenuItem
            // 
            this.libelléArticleToolStripMenuItem.Name = "libelléArticleToolStripMenuItem";
            this.libelléArticleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.libelléArticleToolStripMenuItem.Text = "libellé article";
            this.libelléArticleToolStripMenuItem.ToolTipText = "libelle_article";
            // 
            // nbrArticleToolStripMenuItem
            // 
            this.nbrArticleToolStripMenuItem.Name = "nbrArticleToolStripMenuItem";
            this.nbrArticleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nbrArticleToolStripMenuItem.Text = "nbr article";
            this.nbrArticleToolStripMenuItem.ToolTipText = "nbr_article";
            // 
            // remarqueArticleToolStripMenuItem
            // 
            this.remarqueArticleToolStripMenuItem.Name = "remarqueArticleToolStripMenuItem";
            this.remarqueArticleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.remarqueArticleToolStripMenuItem.Text = "remarque article";
            this.remarqueArticleToolStripMenuItem.ToolTipText = "remarquearticle";
            // 
            // bt_errsuiv
            // 
            this.bt_errsuiv.Enabled = false;
            this.bt_errsuiv.Location = new System.Drawing.Point(917, 688);
            this.bt_errsuiv.Name = "bt_errsuiv";
            this.bt_errsuiv.Size = new System.Drawing.Size(91, 23);
            this.bt_errsuiv.TabIndex = 106;
            this.bt_errsuiv.Text = "erreur suivant !";
            this.bt_errsuiv.UseVisualStyleBackColor = true;
            this.bt_errsuiv.Click += new System.EventHandler(this.bt_errsuiv_Click);
            // 
            // f_importation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 724);
            this.Controls.Add(this.bt_errsuiv);
            this.Controls.Add(this.comboMi2);
            this.Controls.Add(this.comboMi1);
            this.Controls.Add(this.bt_validerimport);
            this.Controls.Add(this.bt_verifaddclient);
            this.Controls.Add(this.bt_verifier);
            this.Controls.Add(this.bt_importer);
            this.Controls.Add(this.gvins);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_importation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importation facture";
            this.Load += new System.EventHandler(this.f_importation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvins)).EndInit();
            this.men_col.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog FileDg;
        public System.Windows.Forms.DataGridView gvins;
        public MySql.Data.MySqlClient.MySqlCommand comrealvistamod;
        private System.Windows.Forms.ImageList imageList1;
        public MySql.Data.MySqlClient.MySqlCommand comrech;
        private System.Windows.Forms.Button bt_importer;
        private System.Windows.Forms.Button bt_verifier;
        private System.Windows.Forms.Button bt_verifaddclient;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Button bt_validerimport;
        private WindowsFormsControlLibrary1.ComboMi comboMi2;
        private WindowsFormsControlLibrary1.ComboMi comboMi1;
        private System.Windows.Forms.ContextMenuStrip men_col;
        private System.Windows.Forms.ToolStripMenuItem politesseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem socligneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prénomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adresse1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adresse2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem npaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem villeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateFactureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem réfFactureEntrepriseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateCommandeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noCommandebonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libelléArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nbrArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remarqueArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem définirLaColonnea;
        private System.Windows.Forms.Button bt_errsuiv;
    }
}