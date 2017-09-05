namespace DeltaFact
{
    partial class f_gesfact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_gesfact));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Client", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comrealvistamod = new MySql.Data.MySqlClient.MySqlCommand();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comaffichefacture = new MySql.Data.MySqlClient.MySqlCommand();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.p_menu = new System.Windows.Forms.Panel();
            this.bt_modifajoutart = new System.Windows.Forms.Button();
            this.bt_rappel = new System.Windows.Forms.Button();
            this.men_rappel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pourLaFactureSélectionnéeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pourToutesLesFacturesÀÉchéanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_compta = new System.Windows.Forms.Button();
            this.bt_imprimertout = new System.Windows.Forms.Button();
            this.bt_imprimer = new System.Windows.Forms.Button();
            this.bt_toutaffciher = new System.Windows.Forms.Button();
            this.bt_fermer = new System.Windows.Forms.Button();
            this.bt_annul = new System.Windows.Forms.Button();
            this.bt_valider = new System.Windows.Forms.Button();
            this.bt_impression = new System.Windows.Forms.Button();
            this.men_impression = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimerLaFactureSélectionnéeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimerToutesLesFacturesDansLaListeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimerrappel = new System.Windows.Forms.ToolStripMenuItem();
            this.impressionComptableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_modif = new System.Windows.Forms.Button();
            this.bt_suppr = new System.Windows.Forms.Button();
            this.bt_ajout = new System.Windows.Forms.Button();
            this.gv_fact = new System.Windows.Forms.DataGridView();
            this.g_reffactdeltareal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_reffactentreprise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_datecommande = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_codearticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_libellearticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_remarquearticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_nbrarticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_montantbrut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_rabaisfacturepourcent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_rabaisfacturechf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_tvachf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_fraisenvoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_fraisassurance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_interets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_fraisrappel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_montantapayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_dateimpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_echeance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_montantpaye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_solde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idfacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_identreprise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idclient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idarticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_numligne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idprix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idrabais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_groupe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_rappel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_facture = new System.Windows.Forms.Panel();
            this.remarquearticle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.idrabais = new System.Windows.Forms.TextBox();
            this.idprix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ed_rabaischf = new System.Windows.Forms.TextBox();
            this.ed_rabaispourcent = new System.Windows.Forms.TextBox();
            this.ck_typesaisie = new System.Windows.Forms.CheckBox();
            this.idarticle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.unite = new System.Windows.Forms.TextBox();
            this.codearticle = new System.Windows.Forms.TextBox();
            this.montantarticle = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.prixunitaire = new System.Windows.Forms.TextBox();
            this.nbrarticle = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.libellearticle = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.datecommande = new System.Windows.Forms.DateTimePicker();
            this.reffacturedeltareal = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.reffactureentreprise = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.p_recherche = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.rechfacture = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rechclient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_entreprise = new System.Windows.Forms.Label();
            this.comrech = new MySql.Data.MySqlClient.MySqlCommand();
            this.lv = new System.Windows.Forms.ListView();
            this.men_ligne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menligne_ajouterUneLigne = new System.Windows.Forms.ToolStripMenuItem();
            this.menligne_supprimerUneLigne = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bt_listepaiement = new System.Windows.Forms.Button();
            this.bt_pajout = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.gv_paiement = new System.Windows.Forms.DataGridView();
            this.g_datesaisie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_datepaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_typepaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_montantpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idclientpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gv_procedure = new System.Windows.Forms.DataGridView();
            this.g_initial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_inouttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_dateproc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_typecourrier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_echeanceproc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idprocedure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_numfacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idclientproc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_supproc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tp_facture = new System.Windows.Forms.TabControl();
            this.pg_saisies = new System.Windows.Forms.TabPage();
            this.pg_envoyes = new System.Windows.Forms.TabPage();
            this.pg_rappel = new System.Windows.Forms.TabPage();
            this.pg_echeance = new System.Windows.Forms.TabPage();
            this.pg_payes = new System.Windows.Forms.TabPage();
            this.pg_toutes = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_rappel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_nbrfact = new System.Windows.Forms.Label();
            this.lb_mttfact = new System.Windows.Forms.Label();
            this.lb_saisies = new System.Windows.Forms.Label();
            this.lb_nbrsai = new System.Windows.Forms.Label();
            this.lb_mttsai = new System.Windows.Forms.Label();
            this.lb_mttenv = new System.Windows.Forms.Label();
            this.lb_nbrenv = new System.Windows.Forms.Label();
            this.lb_envoyees = new System.Windows.Forms.Label();
            this.lb_mttech = new System.Windows.Forms.Label();
            this.lb_nbrech = new System.Windows.Forms.Label();
            this.lb_echeances = new System.Windows.Forms.Label();
            this.lb_mttpay = new System.Windows.Forms.Label();
            this.lb_nbrpay = new System.Windows.Forms.Label();
            this.lb_payees = new System.Windows.Forms.Label();
            this.lb_mtttou = new System.Windows.Forms.Label();
            this.lb_nbrtou = new System.Windows.Forms.Label();
            this.lb_toutes = new System.Windows.Forms.Label();
            this.lb_lbrappel = new System.Windows.Forms.Label();
            this.lb_mttrap = new System.Windows.Forms.Label();
            this.lb_nbrrap = new System.Windows.Forms.Label();
            this.lb_rappelenvoye = new System.Windows.Forms.Label();
            this.ck_rap1 = new System.Windows.Forms.CheckBox();
            this.ck_rap2 = new System.Windows.Forms.CheckBox();
            this.imprimerÉtatDeFactureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.p_menu.SuspendLayout();
            this.men_rappel.SuspendLayout();
            this.men_impression.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_fact)).BeginInit();
            this.p_facture.SuspendLayout();
            this.p_recherche.SuspendLayout();
            this.men_ligne.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_paiement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_procedure)).BeginInit();
            this.panel1.SuspendLayout();
            this.tp_facture.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(18, "008_Reminder_16x16_72.png");
            // 
            // comaffichefacture
            // 
            this.comaffichefacture.CacheAge = 60;
            this.comaffichefacture.Connection = null;
            this.comaffichefacture.EnableCaching = false;
            this.comaffichefacture.Transaction = null;
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // p_menu
            // 
            this.p_menu.BackColor = System.Drawing.Color.LavenderBlush;
            this.p_menu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p_menu.Controls.Add(this.bt_modifajoutart);
            this.p_menu.Controls.Add(this.bt_rappel);
            this.p_menu.Controls.Add(this.bt_compta);
            this.p_menu.Controls.Add(this.bt_imprimertout);
            this.p_menu.Controls.Add(this.bt_imprimer);
            this.p_menu.Controls.Add(this.bt_toutaffciher);
            this.p_menu.Controls.Add(this.bt_fermer);
            this.p_menu.Controls.Add(this.bt_annul);
            this.p_menu.Controls.Add(this.bt_valider);
            this.p_menu.Controls.Add(this.bt_impression);
            this.p_menu.Controls.Add(this.bt_modif);
            this.p_menu.Controls.Add(this.bt_suppr);
            this.p_menu.Controls.Add(this.bt_ajout);
            this.p_menu.Location = new System.Drawing.Point(12, 677);
            this.p_menu.Name = "p_menu";
            this.p_menu.Size = new System.Drawing.Size(1628, 46);
            this.p_menu.TabIndex = 1;
            // 
            // bt_modifajoutart
            // 
            this.bt_modifajoutart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_modifajoutart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_modifajoutart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_modifajoutart.ImageIndex = 2;
            this.bt_modifajoutart.ImageList = this.imageList1;
            this.bt_modifajoutart.Location = new System.Drawing.Point(127, 10);
            this.bt_modifajoutart.Name = "bt_modifajoutart";
            this.bt_modifajoutart.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_modifajoutart.Size = new System.Drawing.Size(118, 24);
            this.bt_modifajoutart.TabIndex = 14;
            this.bt_modifajoutart.Tag = "1";
            this.bt_modifajoutart.Text = "ajout article";
            this.bt_modifajoutart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_modifajoutart.UseVisualStyleBackColor = true;
            this.bt_modifajoutart.Click += new System.EventHandler(this.bt_modifajoutart_Click);
            // 
            // bt_rappel
            // 
            this.bt_rappel.ContextMenuStrip = this.men_rappel;
            this.bt_rappel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_rappel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_rappel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_rappel.ImageIndex = 18;
            this.bt_rappel.ImageList = this.imageList1;
            this.bt_rappel.Location = new System.Drawing.Point(955, 10);
            this.bt_rappel.Name = "bt_rappel";
            this.bt_rappel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_rappel.Size = new System.Drawing.Size(120, 24);
            this.bt_rappel.TabIndex = 13;
            this.bt_rappel.Tag = "1";
            this.bt_rappel.Text = "envoi rappel";
            this.bt_rappel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_rappel.UseVisualStyleBackColor = true;
            this.bt_rappel.Click += new System.EventHandler(this.bt_rappel_Click);
            this.bt_rappel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_rappel_MouseDown);
            // 
            // men_rappel
            // 
            this.men_rappel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pourLaFactureSélectionnéeToolStripMenuItem,
            this.pourToutesLesFacturesÀÉchéanceToolStripMenuItem,
            this.imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem});
            this.men_rappel.Name = "men_rappel";
            this.men_rappel.Size = new System.Drawing.Size(288, 70);
            // 
            // pourLaFactureSélectionnéeToolStripMenuItem
            // 
            this.pourLaFactureSélectionnéeToolStripMenuItem.Name = "pourLaFactureSélectionnéeToolStripMenuItem";
            this.pourLaFactureSélectionnéeToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.pourLaFactureSélectionnéeToolStripMenuItem.Text = "pour la facture sélectionnée";
            this.pourLaFactureSélectionnéeToolStripMenuItem.Click += new System.EventHandler(this.pourLaFactureSélectionnéeToolStripMenuItem_Click);
            // 
            // pourToutesLesFacturesÀÉchéanceToolStripMenuItem
            // 
            this.pourToutesLesFacturesÀÉchéanceToolStripMenuItem.Name = "pourToutesLesFacturesÀÉchéanceToolStripMenuItem";
            this.pourToutesLesFacturesÀÉchéanceToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.pourToutesLesFacturesÀÉchéanceToolStripMenuItem.Text = "pour toutes les factures à échéance";
            this.pourToutesLesFacturesÀÉchéanceToolStripMenuItem.Click += new System.EventHandler(this.pourToutesLesFacturesÀÉchéanceToolStripMenuItem_Click);
            // 
            // imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem
            // 
            this.imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem.Name = "imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem";
            this.imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem.Text = "imprimer la liste des factures à échéance";
            this.imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem.Click += new System.EventHandler(this.imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem_Click);
            // 
            // bt_compta
            // 
            this.bt_compta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_compta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_compta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_compta.ImageIndex = 16;
            this.bt_compta.ImageList = this.imageList1;
            this.bt_compta.Location = new System.Drawing.Point(1089, 12);
            this.bt_compta.Name = "bt_compta";
            this.bt_compta.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_compta.Size = new System.Drawing.Size(120, 24);
            this.bt_compta.TabIndex = 12;
            this.bt_compta.Tag = "1";
            this.bt_compta.Text = "comptabilité";
            this.bt_compta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_compta.UseVisualStyleBackColor = true;
            this.bt_compta.Visible = false;
            this.bt_compta.Click += new System.EventHandler(this.bt_compta_Click);
            // 
            // bt_imprimertout
            // 
            this.bt_imprimertout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_imprimertout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_imprimertout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_imprimertout.ImageIndex = 16;
            this.bt_imprimertout.ImageList = this.imageList1;
            this.bt_imprimertout.Location = new System.Drawing.Point(1059, 13);
            this.bt_imprimertout.Name = "bt_imprimertout";
            this.bt_imprimertout.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_imprimertout.Size = new System.Drawing.Size(120, 24);
            this.bt_imprimertout.TabIndex = 11;
            this.bt_imprimertout.Tag = "3";
            this.bt_imprimertout.Text = "imprimer tout";
            this.bt_imprimertout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_imprimertout.UseVisualStyleBackColor = true;
            this.bt_imprimertout.Visible = false;
            this.bt_imprimertout.Click += new System.EventHandler(this.bt_imprimertout_Click);
            // 
            // bt_imprimer
            // 
            this.bt_imprimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_imprimer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_imprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_imprimer.ImageIndex = 16;
            this.bt_imprimer.ImageList = this.imageList1;
            this.bt_imprimer.Location = new System.Drawing.Point(1024, 13);
            this.bt_imprimer.Name = "bt_imprimer";
            this.bt_imprimer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_imprimer.Size = new System.Drawing.Size(120, 24);
            this.bt_imprimer.TabIndex = 10;
            this.bt_imprimer.Tag = "3";
            this.bt_imprimer.Text = "impr sélection";
            this.bt_imprimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_imprimer.UseVisualStyleBackColor = true;
            this.bt_imprimer.Visible = false;
            this.bt_imprimer.Click += new System.EventHandler(this.bt_imprimer_Click);
            // 
            // bt_toutaffciher
            // 
            this.bt_toutaffciher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_toutaffciher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_toutaffciher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_toutaffciher.ImageIndex = 0;
            this.bt_toutaffciher.ImageList = this.imageList1;
            this.bt_toutaffciher.Location = new System.Drawing.Point(683, 11);
            this.bt_toutaffciher.Name = "bt_toutaffciher";
            this.bt_toutaffciher.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_toutaffciher.Size = new System.Drawing.Size(116, 24);
            this.bt_toutaffciher.TabIndex = 7;
            this.bt_toutaffciher.Tag = "3";
            this.bt_toutaffciher.Text = "tout afficher";
            this.bt_toutaffciher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_toutaffciher.UseVisualStyleBackColor = true;
            this.bt_toutaffciher.Click += new System.EventHandler(this.bt_toutaffciher_Click);
            // 
            // bt_fermer
            // 
            this.bt_fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_fermer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_fermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_fermer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_fermer.ImageIndex = 10;
            this.bt_fermer.ImageList = this.imageList1;
            this.bt_fermer.Location = new System.Drawing.Point(1484, 10);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_fermer.Size = new System.Drawing.Size(126, 30);
            this.bt_fermer.TabIndex = 6;
            this.bt_fermer.Tag = "9";
            this.bt_fermer.Text = "FERMER  ";
            this.bt_fermer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_fermer.UseVisualStyleBackColor = true;
            // 
            // bt_annul
            // 
            this.bt_annul.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_annul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_annul.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_annul.ImageIndex = 9;
            this.bt_annul.ImageList = this.imageList1;
            this.bt_annul.Location = new System.Drawing.Point(571, 10);
            this.bt_annul.Name = "bt_annul";
            this.bt_annul.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_annul.Size = new System.Drawing.Size(93, 24);
            this.bt_annul.TabIndex = 4;
            this.bt_annul.Tag = "2";
            this.bt_annul.Text = "annuler";
            this.bt_annul.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_annul.UseVisualStyleBackColor = true;
            this.bt_annul.Click += new System.EventHandler(this.bt_annul_Click);
            // 
            // bt_valider
            // 
            this.bt_valider.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_valider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_valider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_valider.ImageIndex = 1;
            this.bt_valider.ImageList = this.imageList1;
            this.bt_valider.Location = new System.Drawing.Point(466, 10);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_valider.Size = new System.Drawing.Size(93, 24);
            this.bt_valider.TabIndex = 3;
            this.bt_valider.Tag = "2";
            this.bt_valider.Text = "valider";
            this.bt_valider.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // bt_impression
            // 
            this.bt_impression.ContextMenuStrip = this.men_impression;
            this.bt_impression.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_impression.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_impression.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_impression.ImageIndex = 13;
            this.bt_impression.ImageList = this.imageList1;
            this.bt_impression.Location = new System.Drawing.Point(820, 10);
            this.bt_impression.Name = "bt_impression";
            this.bt_impression.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_impression.Size = new System.Drawing.Size(120, 24);
            this.bt_impression.TabIndex = 9;
            this.bt_impression.Tag = "1";
            this.bt_impression.Text = "impression";
            this.bt_impression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_impression.UseVisualStyleBackColor = true;
            this.bt_impression.Click += new System.EventHandler(this.bt_paiement_Click);
            this.bt_impression.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_impression_MouseDown);
            // 
            // men_impression
            // 
            this.men_impression.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimerLaFactureSélectionnéeToolStripMenuItem,
            this.imprimerToutesLesFacturesDansLaListeToolStripMenuItem,
            this.imprimerrappel,
            this.impressionComptableToolStripMenuItem,
            this.imprimerÉtatDeFactureToolStripMenuItem});
            this.men_impression.Name = "men_impression";
            this.men_impression.Size = new System.Drawing.Size(286, 136);
            this.men_impression.Opening += new System.ComponentModel.CancelEventHandler(this.men_impression_Opening);
            // 
            // imprimerLaFactureSélectionnéeToolStripMenuItem
            // 
            this.imprimerLaFactureSélectionnéeToolStripMenuItem.Name = "imprimerLaFactureSélectionnéeToolStripMenuItem";
            this.imprimerLaFactureSélectionnéeToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.imprimerLaFactureSélectionnéeToolStripMenuItem.Text = "imprimer la facture sélectionnée";
            this.imprimerLaFactureSélectionnéeToolStripMenuItem.Click += new System.EventHandler(this.imprimerLaFactureSélectionnéeToolStripMenuItem_Click);
            // 
            // imprimerToutesLesFacturesDansLaListeToolStripMenuItem
            // 
            this.imprimerToutesLesFacturesDansLaListeToolStripMenuItem.Name = "imprimerToutesLesFacturesDansLaListeToolStripMenuItem";
            this.imprimerToutesLesFacturesDansLaListeToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.imprimerToutesLesFacturesDansLaListeToolStripMenuItem.Text = "imprimer toutes les factures dans la liste";
            this.imprimerToutesLesFacturesDansLaListeToolStripMenuItem.Click += new System.EventHandler(this.imprimerToutesLesFacturesDansLaListeToolStripMenuItem_Click);
            // 
            // imprimerrappel
            // 
            this.imprimerrappel.Name = "imprimerrappel";
            this.imprimerrappel.Size = new System.Drawing.Size(285, 22);
            this.imprimerrappel.Text = "imprimer le dernier rappel envoyé";
            this.imprimerrappel.Click += new System.EventHandler(this.imprimerrappel_Click);
            // 
            // impressionComptableToolStripMenuItem
            // 
            this.impressionComptableToolStripMenuItem.Name = "impressionComptableToolStripMenuItem";
            this.impressionComptableToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.impressionComptableToolStripMenuItem.Text = "impression comptable";
            this.impressionComptableToolStripMenuItem.Click += new System.EventHandler(this.impressionComptableToolStripMenuItem_Click);
            // 
            // bt_modif
            // 
            this.bt_modif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_modif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_modif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_modif.ImageIndex = 2;
            this.bt_modif.ImageList = this.imageList1;
            this.bt_modif.Location = new System.Drawing.Point(14, 10);
            this.bt_modif.Name = "bt_modif";
            this.bt_modif.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_modif.Size = new System.Drawing.Size(108, 24);
            this.bt_modif.TabIndex = 0;
            this.bt_modif.Tag = "1";
            this.bt_modif.Text = "modifier";
            this.bt_modif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_modif.UseVisualStyleBackColor = true;
            this.bt_modif.Click += new System.EventHandler(this.bt_modif_Click);
            // 
            // bt_suppr
            // 
            this.bt_suppr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_suppr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_suppr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_suppr.ImageIndex = 6;
            this.bt_suppr.ImageList = this.imageList1;
            this.bt_suppr.Location = new System.Drawing.Point(361, 10);
            this.bt_suppr.Name = "bt_suppr";
            this.bt_suppr.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_suppr.Size = new System.Drawing.Size(93, 24);
            this.bt_suppr.TabIndex = 2;
            this.bt_suppr.Tag = "1";
            this.bt_suppr.Text = "suppr.";
            this.bt_suppr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_suppr.UseVisualStyleBackColor = true;
            this.bt_suppr.Click += new System.EventHandler(this.bt_suppr_Click);
            // 
            // bt_ajout
            // 
            this.bt_ajout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_ajout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ajout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ajout.ImageIndex = 5;
            this.bt_ajout.ImageList = this.imageList1;
            this.bt_ajout.Location = new System.Drawing.Point(256, 10);
            this.bt_ajout.Name = "bt_ajout";
            this.bt_ajout.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_ajout.Size = new System.Drawing.Size(93, 24);
            this.bt_ajout.TabIndex = 1;
            this.bt_ajout.Tag = "1";
            this.bt_ajout.Text = "ajouter  ";
            this.bt_ajout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_ajout.UseVisualStyleBackColor = true;
            this.bt_ajout.Click += new System.EventHandler(this.bt_ajout_Click);
            // 
            // gv_fact
            // 
            this.gv_fact.AllowUserToAddRows = false;
            this.gv_fact.AllowUserToDeleteRows = false;
            this.gv_fact.AllowUserToResizeColumns = false;
            this.gv_fact.AllowUserToResizeRows = false;
            this.gv_fact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_fact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_reffactdeltareal,
            this.g_reffactentreprise,
            this.g_datecommande,
            this.g_codearticle,
            this.g_libellearticle,
            this.g_remarquearticle,
            this.g_nbrarticle,
            this.g_montantbrut,
            this.g_rabaisfacturepourcent,
            this.g_rabaisfacturechf,
            this.g_tvachf,
            this.g_fraisenvoi,
            this.g_fraisassurance,
            this.g_interets,
            this.g_fraisrappel,
            this.g_montantapayer,
            this.g_dateimpression,
            this.g_echeance,
            this.g_montantpaye,
            this.g_solde,
            this.g_idfacture,
            this.g_identreprise,
            this.g_idclient,
            this.g_idarticle,
            this.g_numligne,
            this.g_idprix,
            this.g_idrabais,
            this.g_groupe,
            this.g_rappel});
            this.gv_fact.Location = new System.Drawing.Point(577, 554);
            this.gv_fact.MultiSelect = false;
            this.gv_fact.Name = "gv_fact";
            this.gv_fact.RowHeadersVisible = false;
            this.gv_fact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_fact.Size = new System.Drawing.Size(638, 117);
            this.gv_fact.TabIndex = 6;
            this.gv_fact.Visible = false;
            this.gv_fact.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gv_fact_CellPainting);
            this.gv_fact.Click += new System.EventHandler(this.gv_fact_Click);
            // 
            // g_reffactdeltareal
            // 
            this.g_reffactdeltareal.HeaderText = "No facture";
            this.g_reffactdeltareal.Name = "g_reffactdeltareal";
            // 
            // g_reffactentreprise
            // 
            this.g_reffactentreprise.HeaderText = "réf. Facture Entr.";
            this.g_reffactentreprise.Name = "g_reffactentreprise";
            // 
            // g_datecommande
            // 
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.g_datecommande.DefaultCellStyle = dataGridViewCellStyle39;
            this.g_datecommande.HeaderText = "date de commande";
            this.g_datecommande.Name = "g_datecommande";
            this.g_datecommande.Width = 80;
            // 
            // g_codearticle
            // 
            this.g_codearticle.HeaderText = "code article";
            this.g_codearticle.Name = "g_codearticle";
            this.g_codearticle.Width = 70;
            // 
            // g_libellearticle
            // 
            this.g_libellearticle.HeaderText = "libellé article";
            this.g_libellearticle.Name = "g_libellearticle";
            this.g_libellearticle.Width = 200;
            // 
            // g_remarquearticle
            // 
            this.g_remarquearticle.HeaderText = "remarque";
            this.g_remarquearticle.Name = "g_remarquearticle";
            this.g_remarquearticle.Visible = false;
            // 
            // g_nbrarticle
            // 
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.g_nbrarticle.DefaultCellStyle = dataGridViewCellStyle40;
            this.g_nbrarticle.HeaderText = "nbr article";
            this.g_nbrarticle.Name = "g_nbrarticle";
            this.g_nbrarticle.Width = 50;
            // 
            // g_montantbrut
            // 
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_montantbrut.DefaultCellStyle = dataGridViewCellStyle41;
            this.g_montantbrut.HeaderText = "montant brut";
            this.g_montantbrut.Name = "g_montantbrut";
            this.g_montantbrut.Width = 80;
            // 
            // g_rabaisfacturepourcent
            // 
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_rabaisfacturepourcent.DefaultCellStyle = dataGridViewCellStyle42;
            this.g_rabaisfacturepourcent.HeaderText = "% rabais";
            this.g_rabaisfacturepourcent.Name = "g_rabaisfacturepourcent";
            this.g_rabaisfacturepourcent.Width = 50;
            // 
            // g_rabaisfacturechf
            // 
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_rabaisfacturechf.DefaultCellStyle = dataGridViewCellStyle43;
            this.g_rabaisfacturechf.HeaderText = "rabais chf";
            this.g_rabaisfacturechf.Name = "g_rabaisfacturechf";
            this.g_rabaisfacturechf.Width = 65;
            // 
            // g_tvachf
            // 
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_tvachf.DefaultCellStyle = dataGridViewCellStyle44;
            this.g_tvachf.HeaderText = "tva chf";
            this.g_tvachf.Name = "g_tvachf";
            this.g_tvachf.Width = 70;
            // 
            // g_fraisenvoi
            // 
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_fraisenvoi.DefaultCellStyle = dataGridViewCellStyle45;
            this.g_fraisenvoi.HeaderText = "frais d\'envoi";
            this.g_fraisenvoi.Name = "g_fraisenvoi";
            this.g_fraisenvoi.Width = 75;
            // 
            // g_fraisassurance
            // 
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_fraisassurance.DefaultCellStyle = dataGridViewCellStyle46;
            this.g_fraisassurance.HeaderText = "frais assurance";
            this.g_fraisassurance.Name = "g_fraisassurance";
            this.g_fraisassurance.Width = 70;
            // 
            // g_interets
            // 
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_interets.DefaultCellStyle = dataGridViewCellStyle47;
            this.g_interets.HeaderText = "intérêts";
            this.g_interets.Name = "g_interets";
            this.g_interets.Width = 70;
            // 
            // g_fraisrappel
            // 
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_fraisrappel.DefaultCellStyle = dataGridViewCellStyle48;
            this.g_fraisrappel.HeaderText = "frais rappel";
            this.g_fraisrappel.Name = "g_fraisrappel";
            this.g_fraisrappel.Width = 70;
            // 
            // g_montantapayer
            // 
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_montantapayer.DefaultCellStyle = dataGridViewCellStyle49;
            this.g_montantapayer.HeaderText = "montant à payer";
            this.g_montantapayer.Name = "g_montantapayer";
            // 
            // g_dateimpression
            // 
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.g_dateimpression.DefaultCellStyle = dataGridViewCellStyle50;
            this.g_dateimpression.HeaderText = "imprimé/date";
            this.g_dateimpression.Name = "g_dateimpression";
            this.g_dateimpression.Width = 80;
            // 
            // g_echeance
            // 
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.g_echeance.DefaultCellStyle = dataGridViewCellStyle51;
            this.g_echeance.HeaderText = "écheance";
            this.g_echeance.Name = "g_echeance";
            this.g_echeance.Width = 80;
            // 
            // g_montantpaye
            // 
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_montantpaye.DefaultCellStyle = dataGridViewCellStyle52;
            this.g_montantpaye.HeaderText = "montant payé";
            this.g_montantpaye.Name = "g_montantpaye";
            // 
            // g_solde
            // 
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_solde.DefaultCellStyle = dataGridViewCellStyle53;
            this.g_solde.HeaderText = "solde ouvert";
            this.g_solde.Name = "g_solde";
            // 
            // g_idfacture
            // 
            this.g_idfacture.HeaderText = "idfacture";
            this.g_idfacture.Name = "g_idfacture";
            this.g_idfacture.Visible = false;
            // 
            // g_identreprise
            // 
            this.g_identreprise.HeaderText = "identreprise";
            this.g_identreprise.Name = "g_identreprise";
            this.g_identreprise.Visible = false;
            // 
            // g_idclient
            // 
            this.g_idclient.HeaderText = "idclient";
            this.g_idclient.Name = "g_idclient";
            this.g_idclient.Visible = false;
            // 
            // g_idarticle
            // 
            this.g_idarticle.HeaderText = "idarticle";
            this.g_idarticle.Name = "g_idarticle";
            this.g_idarticle.Visible = false;
            // 
            // g_numligne
            // 
            this.g_numligne.HeaderText = "numligne";
            this.g_numligne.Name = "g_numligne";
            this.g_numligne.Visible = false;
            // 
            // g_idprix
            // 
            this.g_idprix.HeaderText = "idprix";
            this.g_idprix.Name = "g_idprix";
            this.g_idprix.Visible = false;
            // 
            // g_idrabais
            // 
            this.g_idrabais.HeaderText = "idrabais";
            this.g_idrabais.Name = "g_idrabais";
            this.g_idrabais.Visible = false;
            // 
            // g_groupe
            // 
            this.g_groupe.HeaderText = "groupe";
            this.g_groupe.Name = "g_groupe";
            this.g_groupe.Visible = false;
            // 
            // g_rappel
            // 
            this.g_rappel.HeaderText = "rappel";
            this.g_rappel.Name = "g_rappel";
            this.g_rappel.Visible = false;
            // 
            // p_facture
            // 
            this.p_facture.BackColor = System.Drawing.Color.NavajoWhite;
            this.p_facture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p_facture.Controls.Add(this.remarquearticle);
            this.p_facture.Controls.Add(this.label7);
            this.p_facture.Controls.Add(this.idrabais);
            this.p_facture.Controls.Add(this.idprix);
            this.p_facture.Controls.Add(this.label5);
            this.p_facture.Controls.Add(this.ed_rabaischf);
            this.p_facture.Controls.Add(this.ed_rabaispourcent);
            this.p_facture.Controls.Add(this.ck_typesaisie);
            this.p_facture.Controls.Add(this.idarticle);
            this.p_facture.Controls.Add(this.label3);
            this.p_facture.Controls.Add(this.label84);
            this.p_facture.Controls.Add(this.unite);
            this.p_facture.Controls.Add(this.codearticle);
            this.p_facture.Controls.Add(this.montantarticle);
            this.p_facture.Controls.Add(this.label64);
            this.p_facture.Controls.Add(this.label4);
            this.p_facture.Controls.Add(this.label63);
            this.p_facture.Controls.Add(this.prixunitaire);
            this.p_facture.Controls.Add(this.nbrarticle);
            this.p_facture.Controls.Add(this.label66);
            this.p_facture.Controls.Add(this.libellearticle);
            this.p_facture.Controls.Add(this.label73);
            this.p_facture.Controls.Add(this.label74);
            this.p_facture.Controls.Add(this.label27);
            this.p_facture.Controls.Add(this.datecommande);
            this.p_facture.Controls.Add(this.reffacturedeltareal);
            this.p_facture.Controls.Add(this.label26);
            this.p_facture.Controls.Add(this.reffactureentreprise);
            this.p_facture.Controls.Add(this.label23);
            this.p_facture.Location = new System.Drawing.Point(12, 69);
            this.p_facture.Name = "p_facture";
            this.p_facture.Size = new System.Drawing.Size(1628, 54);
            this.p_facture.TabIndex = 0;
            // 
            // remarquearticle
            // 
            this.remarquearticle.BackColor = System.Drawing.Color.White;
            this.remarquearticle.Enabled = false;
            this.remarquearticle.Location = new System.Drawing.Point(1150, 22);
            this.remarquearticle.Name = "remarquearticle";
            this.remarquearticle.Size = new System.Drawing.Size(312, 20);
            this.remarquearticle.TabIndex = 10;
            this.remarquearticle.Tag = "6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1147, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 337;
            this.label7.Text = "remarque";
            // 
            // idrabais
            // 
            this.idrabais.BackColor = System.Drawing.Color.White;
            this.idrabais.Enabled = false;
            this.idrabais.Location = new System.Drawing.Point(1017, 34);
            this.idrabais.Name = "idrabais";
            this.idrabais.Size = new System.Drawing.Size(56, 20);
            this.idrabais.TabIndex = 335;
            this.idrabais.Tag = "7";
            this.idrabais.Visible = false;
            // 
            // idprix
            // 
            this.idprix.BackColor = System.Drawing.Color.White;
            this.idprix.Enabled = false;
            this.idprix.Location = new System.Drawing.Point(914, 34);
            this.idprix.Name = "idprix";
            this.idprix.ReadOnly = true;
            this.idprix.Size = new System.Drawing.Size(93, 20);
            this.idprix.TabIndex = 334;
            this.idprix.Tag = "7";
            this.idprix.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1073, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 333;
            this.label5.Text = "rabais chf";
            // 
            // ed_rabaischf
            // 
            this.ed_rabaischf.BackColor = System.Drawing.Color.White;
            this.ed_rabaischf.Enabled = false;
            this.ed_rabaischf.Location = new System.Drawing.Point(1073, 22);
            this.ed_rabaischf.Name = "ed_rabaischf";
            this.ed_rabaischf.Size = new System.Drawing.Size(71, 20);
            this.ed_rabaischf.TabIndex = 9;
            this.ed_rabaischf.Tag = "7";
            // 
            // ed_rabaispourcent
            // 
            this.ed_rabaispourcent.BackColor = System.Drawing.Color.White;
            this.ed_rabaispourcent.Enabled = false;
            this.ed_rabaispourcent.Location = new System.Drawing.Point(1011, 22);
            this.ed_rabaispourcent.Name = "ed_rabaispourcent";
            this.ed_rabaispourcent.Size = new System.Drawing.Size(56, 20);
            this.ed_rabaispourcent.TabIndex = 8;
            this.ed_rabaispourcent.Tag = "7";
            // 
            // ck_typesaisie
            // 
            this.ck_typesaisie.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ck_typesaisie.Checked = true;
            this.ck_typesaisie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_typesaisie.Location = new System.Drawing.Point(346, 22);
            this.ck_typesaisie.Name = "ck_typesaisie";
            this.ck_typesaisie.Size = new System.Drawing.Size(26, 18);
            this.ck_typesaisie.TabIndex = 3;
            this.ck_typesaisie.Tag = "6";
            this.ck_typesaisie.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ck_typesaisie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ck_typesaisie.UseVisualStyleBackColor = true;
            // 
            // idarticle
            // 
            this.idarticle.BackColor = System.Drawing.Color.White;
            this.idarticle.Enabled = false;
            this.idarticle.Location = new System.Drawing.Point(444, 40);
            this.idarticle.Name = "idarticle";
            this.idarticle.Size = new System.Drawing.Size(85, 20);
            this.idarticle.TabIndex = 329;
            this.idarticle.Tag = "6";
            this.idarticle.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "saisie Simple";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(838, 5);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(30, 13);
            this.label84.TabIndex = 328;
            this.label84.Text = "unité";
            // 
            // unite
            // 
            this.unite.BackColor = System.Drawing.Color.White;
            this.unite.Enabled = false;
            this.unite.Location = new System.Drawing.Point(841, 22);
            this.unite.Name = "unite";
            this.unite.ReadOnly = true;
            this.unite.Size = new System.Drawing.Size(60, 20);
            this.unite.TabIndex = 6;
            this.unite.Tag = "7";
            // 
            // codearticle
            // 
            this.codearticle.BackColor = System.Drawing.Color.White;
            this.codearticle.Enabled = false;
            this.codearticle.Location = new System.Drawing.Point(444, 22);
            this.codearticle.Name = "codearticle";
            this.codearticle.Size = new System.Drawing.Size(85, 20);
            this.codearticle.TabIndex = 4;
            this.codearticle.Tag = "6";
            this.codearticle.TextChanged += new System.EventHandler(this.codearticle_TextChanged);
            this.codearticle.DoubleClick += new System.EventHandler(this.codearticle_DoubleClick);
            this.codearticle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codearticle_KeyPress_1);
            this.codearticle.Leave += new System.EventHandler(this.codearticle_Leave);
            // 
            // montantarticle
            // 
            this.montantarticle.BackColor = System.Drawing.Color.White;
            this.montantarticle.Enabled = false;
            this.montantarticle.Location = new System.Drawing.Point(1531, 22);
            this.montantarticle.Name = "montantarticle";
            this.montantarticle.ReadOnly = true;
            this.montantarticle.Size = new System.Drawing.Size(83, 20);
            this.montantarticle.TabIndex = 12;
            this.montantarticle.Tag = "7";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(1528, 5);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(45, 13);
            this.label64.TabIndex = 322;
            this.label64.Text = "montant";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1008, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 319;
            this.label4.Text = "rabais %";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(904, 5);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(60, 13);
            this.label63.TabIndex = 319;
            this.label63.Text = "prix unitaire";
            // 
            // prixunitaire
            // 
            this.prixunitaire.BackColor = System.Drawing.Color.White;
            this.prixunitaire.Enabled = false;
            this.prixunitaire.Location = new System.Drawing.Point(907, 22);
            this.prixunitaire.Name = "prixunitaire";
            this.prixunitaire.ReadOnly = true;
            this.prixunitaire.Size = new System.Drawing.Size(93, 20);
            this.prixunitaire.TabIndex = 7;
            this.prixunitaire.Tag = "7";
            // 
            // nbrarticle
            // 
            this.nbrarticle.BackColor = System.Drawing.Color.White;
            this.nbrarticle.Enabled = false;
            this.nbrarticle.Location = new System.Drawing.Point(1468, 22);
            this.nbrarticle.Name = "nbrarticle";
            this.nbrarticle.Size = new System.Drawing.Size(47, 20);
            this.nbrarticle.TabIndex = 11;
            this.nbrarticle.Tag = "6";
            this.nbrarticle.TextChanged += new System.EventHandler(this.nbrarticle_TextChanged);
            this.nbrarticle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nbrarticle_KeyPress);
            this.nbrarticle.Leave += new System.EventHandler(this.nbrarticle_Leave);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(1465, 5);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(53, 13);
            this.label66.TabIndex = 313;
            this.label66.Text = "nbr article";
            // 
            // libellearticle
            // 
            this.libellearticle.BackColor = System.Drawing.Color.White;
            this.libellearticle.Enabled = false;
            this.libellearticle.ForeColor = System.Drawing.Color.Maroon;
            this.libellearticle.Location = new System.Drawing.Point(546, 22);
            this.libellearticle.Name = "libellearticle";
            this.libellearticle.Size = new System.Drawing.Size(289, 20);
            this.libellearticle.TabIndex = 5;
            this.libellearticle.Tag = "7";
            this.libellearticle.TextChanged += new System.EventHandler(this.libellearticle_TextChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(543, 5);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(64, 13);
            this.label73.TabIndex = 10;
            this.label73.Text = "libellé article";
            this.label73.Click += new System.EventHandler(this.label73_Click);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(441, 5);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(62, 13);
            this.label74.TabIndex = 8;
            this.label74.Text = "code article";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(133, 5);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 13);
            this.label27.TabIndex = 12;
            this.label27.Text = "date commande";
            // 
            // datecommande
            // 
            this.datecommande.AccessibleName = "datecommande";
            this.datecommande.CalendarMonthBackground = System.Drawing.Color.White;
            this.datecommande.CustomFormat = "dd.MM.yyyy";
            this.datecommande.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datecommande.Location = new System.Drawing.Point(136, 22);
            this.datecommande.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.datecommande.Name = "datecommande";
            this.datecommande.Size = new System.Drawing.Size(80, 20);
            this.datecommande.TabIndex = 1;
            this.datecommande.Tag = "6";
            this.datecommande.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            this.datecommande.ValueChanged += new System.EventHandler(this.datecommande_ValueChanged);
            // 
            // reffacturedeltareal
            // 
            this.reffacturedeltareal.AccessibleName = "reffacturedeltareal";
            this.reffacturedeltareal.BackColor = System.Drawing.Color.White;
            this.reffacturedeltareal.Enabled = false;
            this.reffacturedeltareal.ForeColor = System.Drawing.Color.Maroon;
            this.reffacturedeltareal.Location = new System.Drawing.Point(12, 22);
            this.reffacturedeltareal.Name = "reffacturedeltareal";
            this.reffacturedeltareal.Size = new System.Drawing.Size(108, 20);
            this.reffacturedeltareal.TabIndex = 0;
            this.reffacturedeltareal.Tag = "7";
            this.reffacturedeltareal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.reffacturedeltareal_KeyPress);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "No de facture";
            // 
            // reffactureentreprise
            // 
            this.reffactureentreprise.AccessibleName = "reffactureentreprise";
            this.reffactureentreprise.BackColor = System.Drawing.Color.White;
            this.reffactureentreprise.Enabled = false;
            this.reffactureentreprise.Location = new System.Drawing.Point(236, 22);
            this.reffactureentreprise.Name = "reffactureentreprise";
            this.reffactureentreprise.Size = new System.Drawing.Size(104, 20);
            this.reffactureentreprise.TabIndex = 2;
            this.reffactureentreprise.Tag = "5";
            this.reffactureentreprise.TextChanged += new System.EventHandler(this.reffactureentreprise_TextChanged);
            this.reffactureentreprise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.reffactureentreprise_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(233, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "réf. facture ent.";
            // 
            // p_recherche
            // 
            this.p_recherche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p_recherche.Controls.Add(this.label6);
            this.p_recherche.Controls.Add(this.rechfacture);
            this.p_recherche.Controls.Add(this.label2);
            this.p_recherche.Controls.Add(this.rechclient);
            this.p_recherche.Controls.Add(this.label1);
            this.p_recherche.Controls.Add(this.lb_entreprise);
            this.p_recherche.Location = new System.Drawing.Point(12, 12);
            this.p_recherche.Name = "p_recherche";
            this.p_recherche.Size = new System.Drawing.Size(1628, 47);
            this.p_recherche.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "RECHERCHE";
            // 
            // rechfacture
            // 
            this.rechfacture.AccessibleName = "reffacturedeltareal";
            this.rechfacture.BackColor = System.Drawing.Color.White;
            this.rechfacture.ForeColor = System.Drawing.Color.Maroon;
            this.rechfacture.Location = new System.Drawing.Point(406, 13);
            this.rechfacture.Name = "rechfacture";
            this.rechfacture.Size = new System.Drawing.Size(115, 20);
            this.rechfacture.TabIndex = 13;
            this.rechfacture.Tag = "7";
            this.rechfacture.TextChanged += new System.EventHandler(this.rechfacture_TextChanged);
            this.rechfacture.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rechfacture_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "facture";
            // 
            // rechclient
            // 
            this.rechclient.AccessibleName = "reffacturedeltareal";
            this.rechclient.BackColor = System.Drawing.Color.White;
            this.rechclient.ForeColor = System.Drawing.Color.Maroon;
            this.rechclient.Location = new System.Drawing.Point(181, 13);
            this.rechclient.Name = "rechclient";
            this.rechclient.Size = new System.Drawing.Size(168, 20);
            this.rechclient.TabIndex = 11;
            this.rechclient.Tag = "7";
            this.rechclient.TextChanged += new System.EventHandler(this.rechclient_TextChanged);
            this.rechclient.DoubleClick += new System.EventHandler(this.rechclient_DoubleClick);
            this.rechclient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rechclient_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "client";
            // 
            // lb_entreprise
            // 
            this.lb_entreprise.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_entreprise.Location = new System.Drawing.Point(573, 12);
            this.lb_entreprise.Name = "lb_entreprise";
            this.lb_entreprise.Size = new System.Drawing.Size(874, 25);
            this.lb_entreprise.TabIndex = 10;
            this.lb_entreprise.Text = "Entreprise";
            this.lb_entreprise.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comrech
            // 
            this.comrech.CacheAge = 60;
            this.comrech.Connection = null;
            this.comrech.EnableCaching = false;
            this.comrech.Transaction = null;
            // 
            // lv
            // 
            this.lv.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv.AutoArrange = false;
            this.lv.ContextMenuStrip = this.men_ligne;
            this.lv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            listViewGroup1.Header = "Client";
            listViewGroup1.Name = "grp_client";
            this.lv.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(15, 201);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(1624, 464);
            this.lv.TabIndex = 3;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lv_DrawItem);
            this.lv.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv_DrawSubItem);
            this.lv.ItemActivate += new System.EventHandler(this.lv_ItemActivate);
            this.lv.Click += new System.EventHandler(this.lv_Click);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            this.lv.MouseHover += new System.EventHandler(this.lv_MouseHover);
            this.lv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tp_facture_MouseEnter);
            // 
            // men_ligne
            // 
            this.men_ligne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menligne_ajouterUneLigne,
            this.menligne_supprimerUneLigne});
            this.men_ligne.Name = "men_ligne";
            this.men_ligne.Size = new System.Drawing.Size(240, 48);
            this.men_ligne.Opening += new System.ComponentModel.CancelEventHandler(this.men_ligne_Opening);
            // 
            // menligne_ajouterUneLigne
            // 
            this.menligne_ajouterUneLigne.Name = "menligne_ajouterUneLigne";
            this.menligne_ajouterUneLigne.Size = new System.Drawing.Size(239, 22);
            this.menligne_ajouterUneLigne.Text = "Ajouter une ligne";
            this.menligne_ajouterUneLigne.Click += new System.EventHandler(this.menligne_ajouterUneLigne_Click);
            // 
            // menligne_supprimerUneLigne
            // 
            this.menligne_supprimerUneLigne.Name = "menligne_supprimerUneLigne";
            this.menligne_supprimerUneLigne.Size = new System.Drawing.Size(239, 22);
            this.menligne_supprimerUneLigne.Text = "Supprimer la ligne sélectionnée";
            this.menligne_supprimerUneLigne.Click += new System.EventHandler(this.menligne_supprimerUneLigne_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(254)))), ((int)(((byte)(207)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.bt_listepaiement);
            this.panel3.Controls.Add(this.bt_pajout);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.gv_paiement);
            this.panel3.Location = new System.Drawing.Point(744, 733);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(580, 165);
            this.panel3.TabIndex = 4;
            // 
            // bt_listepaiement
            // 
            this.bt_listepaiement.Location = new System.Drawing.Point(14, 51);
            this.bt_listepaiement.Name = "bt_listepaiement";
            this.bt_listepaiement.Size = new System.Drawing.Size(89, 23);
            this.bt_listepaiement.TabIndex = 12;
            this.bt_listepaiement.Text = "afficher détails";
            this.bt_listepaiement.UseVisualStyleBackColor = true;
            this.bt_listepaiement.Click += new System.EventHandler(this.bt_listepaiement_Click);
            // 
            // bt_pajout
            // 
            this.bt_pajout.Location = new System.Drawing.Point(14, 25);
            this.bt_pajout.Name = "bt_pajout";
            this.bt_pajout.Size = new System.Drawing.Size(89, 23);
            this.bt_pajout.TabIndex = 11;
            this.bt_pajout.Text = "ajouter";
            this.bt_pajout.UseVisualStyleBackColor = true;
            this.bt_pajout.Click += new System.EventHandler(this.bt_pajout_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "PAIEMENTS";
            // 
            // gv_paiement
            // 
            this.gv_paiement.AllowUserToAddRows = false;
            this.gv_paiement.AllowUserToDeleteRows = false;
            dataGridViewCellStyle54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gv_paiement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle54;
            this.gv_paiement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_paiement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_datesaisie,
            this.g_datepaiement,
            this.g_typepaiement,
            this.g_montantpaiement,
            this.g_idclientpaiement,
            this.g_idpaiement});
            this.gv_paiement.Location = new System.Drawing.Point(109, 5);
            this.gv_paiement.MultiSelect = false;
            this.gv_paiement.Name = "gv_paiement";
            this.gv_paiement.ReadOnly = true;
            this.gv_paiement.RowHeadersVisible = false;
            dataGridViewCellStyle55.BackColor = System.Drawing.Color.Silver;
            this.gv_paiement.RowsDefaultCellStyle = dataGridViewCellStyle55;
            this.gv_paiement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_paiement.Size = new System.Drawing.Size(460, 149);
            this.gv_paiement.TabIndex = 8;
            // 
            // g_datesaisie
            // 
            this.g_datesaisie.HeaderText = "date saisie";
            this.g_datesaisie.Name = "g_datesaisie";
            this.g_datesaisie.ReadOnly = true;
            // 
            // g_datepaiement
            // 
            this.g_datepaiement.HeaderText = "date paiement";
            this.g_datepaiement.Name = "g_datepaiement";
            this.g_datepaiement.ReadOnly = true;
            // 
            // g_typepaiement
            // 
            this.g_typepaiement.HeaderText = "type paiement";
            this.g_typepaiement.Name = "g_typepaiement";
            this.g_typepaiement.ReadOnly = true;
            this.g_typepaiement.Width = 140;
            // 
            // g_montantpaiement
            // 
            this.g_montantpaiement.HeaderText = "montant";
            this.g_montantpaiement.Name = "g_montantpaiement";
            this.g_montantpaiement.ReadOnly = true;
            // 
            // g_idclientpaiement
            // 
            this.g_idclientpaiement.HeaderText = "idclient";
            this.g_idclientpaiement.Name = "g_idclientpaiement";
            this.g_idclientpaiement.ReadOnly = true;
            this.g_idclientpaiement.Visible = false;
            // 
            // g_idpaiement
            // 
            this.g_idpaiement.HeaderText = "idpaiement";
            this.g_idpaiement.Name = "g_idpaiement";
            this.g_idpaiement.ReadOnly = true;
            this.g_idpaiement.Visible = false;
            // 
            // gv_procedure
            // 
            this.gv_procedure.AllowUserToAddRows = false;
            this.gv_procedure.AllowUserToDeleteRows = false;
            dataGridViewCellStyle56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gv_procedure.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle56;
            this.gv_procedure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_procedure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_initial,
            this.g_inouttype,
            this.g_dateproc,
            this.g_typecourrier,
            this.g_echeanceproc,
            this.g_idprocedure,
            this.g_numfacture,
            this.g_idclientproc});
            this.gv_procedure.Location = new System.Drawing.Point(132, 5);
            this.gv_procedure.MultiSelect = false;
            this.gv_procedure.Name = "gv_procedure";
            this.gv_procedure.ReadOnly = true;
            this.gv_procedure.RowHeadersVisible = false;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.Silver;
            this.gv_procedure.RowsDefaultCellStyle = dataGridViewCellStyle57;
            this.gv_procedure.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_procedure.Size = new System.Drawing.Size(575, 151);
            this.gv_procedure.TabIndex = 7;
            // 
            // g_initial
            // 
            this.g_initial.HeaderText = "initial";
            this.g_initial.Name = "g_initial";
            this.g_initial.ReadOnly = true;
            this.g_initial.Width = 50;
            // 
            // g_inouttype
            // 
            this.g_inouttype.HeaderText = "in/out";
            this.g_inouttype.Name = "g_inouttype";
            this.g_inouttype.ReadOnly = true;
            this.g_inouttype.Width = 50;
            // 
            // g_dateproc
            // 
            this.g_dateproc.HeaderText = "date";
            this.g_dateproc.Name = "g_dateproc";
            this.g_dateproc.ReadOnly = true;
            // 
            // g_typecourrier
            // 
            this.g_typecourrier.HeaderText = "type courrier";
            this.g_typecourrier.Name = "g_typecourrier";
            this.g_typecourrier.ReadOnly = true;
            this.g_typecourrier.Width = 250;
            // 
            // g_echeanceproc
            // 
            this.g_echeanceproc.HeaderText = "échéance";
            this.g_echeanceproc.Name = "g_echeanceproc";
            this.g_echeanceproc.ReadOnly = true;
            // 
            // g_idprocedure
            // 
            this.g_idprocedure.HeaderText = "idprocedure";
            this.g_idprocedure.Name = "g_idprocedure";
            this.g_idprocedure.ReadOnly = true;
            this.g_idprocedure.Visible = false;
            // 
            // g_numfacture
            // 
            this.g_numfacture.HeaderText = "numfacture";
            this.g_numfacture.Name = "g_numfacture";
            this.g_numfacture.ReadOnly = true;
            this.g_numfacture.Visible = false;
            // 
            // g_idclientproc
            // 
            this.g_idclientproc.HeaderText = "idclient";
            this.g_idclientproc.Name = "g_idclientproc";
            this.g_idclientproc.ReadOnly = true;
            this.g_idclientproc.Visible = false;
            // 
            // bt_supproc
            // 
            this.bt_supproc.Location = new System.Drawing.Point(12, 30);
            this.bt_supproc.Name = "bt_supproc";
            this.bt_supproc.Size = new System.Drawing.Size(107, 23);
            this.bt_supproc.TabIndex = 8;
            this.bt_supproc.Text = "supprimer proc.";
            this.bt_supproc.UseVisualStyleBackColor = true;
            this.bt_supproc.Click += new System.EventHandler(this.bt_supproc_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(224)))), ((int)(((byte)(254)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.bt_supproc);
            this.panel1.Controls.Add(this.gv_procedure);
            this.panel1.Location = new System.Drawing.Point(12, 733);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 165);
            this.panel1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "PROCEDURES";
            // 
            // tp_facture
            // 
            this.tp_facture.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tp_facture.Controls.Add(this.pg_saisies);
            this.tp_facture.Controls.Add(this.pg_envoyes);
            this.tp_facture.Controls.Add(this.pg_rappel);
            this.tp_facture.Controls.Add(this.pg_echeance);
            this.tp_facture.Controls.Add(this.pg_payes);
            this.tp_facture.Controls.Add(this.pg_toutes);
            this.tp_facture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.tp_facture.HotTrack = true;
            this.tp_facture.ImageList = this.imageList1;
            this.tp_facture.ItemSize = new System.Drawing.Size(170, 60);
            this.tp_facture.Location = new System.Drawing.Point(12, 131);
            this.tp_facture.Name = "tp_facture";
            this.tp_facture.Padding = new System.Drawing.Point(0, 0);
            this.tp_facture.SelectedIndex = 0;
            this.tp_facture.Size = new System.Drawing.Size(1631, 375);
            this.tp_facture.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tp_facture.TabIndex = 8;
            this.tp_facture.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tp_facture_DrawItem);
            this.tp_facture.SelectedIndexChanged += new System.EventHandler(this.tp_facture_SelectedIndexChanged);
            this.tp_facture.MouseEnter += new System.EventHandler(this.tp_facture_MouseEnter);
            this.tp_facture.MouseLeave += new System.EventHandler(this.tp_facture_MouseEnter);
            this.tp_facture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tp_facture_MouseEnter);
            // 
            // pg_saisies
            // 
            this.pg_saisies.BackColor = System.Drawing.SystemColors.Control;
            this.pg_saisies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pg_saisies.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pg_saisies.Location = new System.Drawing.Point(4, 64);
            this.pg_saisies.Name = "pg_saisies";
            this.pg_saisies.Size = new System.Drawing.Size(1623, 307);
            this.pg_saisies.TabIndex = 3;
            // 
            // pg_envoyes
            // 
            this.pg_envoyes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pg_envoyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pg_envoyes.Location = new System.Drawing.Point(4, 64);
            this.pg_envoyes.Name = "pg_envoyes";
            this.pg_envoyes.Size = new System.Drawing.Size(1623, 307);
            this.pg_envoyes.TabIndex = 1;
            this.pg_envoyes.UseVisualStyleBackColor = true;
            this.pg_envoyes.Click += new System.EventHandler(this.pg_envoyes_Click);
            // 
            // pg_rappel
            // 
            this.pg_rappel.Location = new System.Drawing.Point(4, 64);
            this.pg_rappel.Name = "pg_rappel";
            this.pg_rappel.Size = new System.Drawing.Size(1623, 307);
            this.pg_rappel.TabIndex = 5;
            this.pg_rappel.UseVisualStyleBackColor = true;
            // 
            // pg_echeance
            // 
            this.pg_echeance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pg_echeance.Location = new System.Drawing.Point(4, 64);
            this.pg_echeance.Name = "pg_echeance";
            this.pg_echeance.Padding = new System.Windows.Forms.Padding(3);
            this.pg_echeance.Size = new System.Drawing.Size(1623, 307);
            this.pg_echeance.TabIndex = 4;
            this.pg_echeance.UseVisualStyleBackColor = true;
            // 
            // pg_payes
            // 
            this.pg_payes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pg_payes.Location = new System.Drawing.Point(4, 64);
            this.pg_payes.Name = "pg_payes";
            this.pg_payes.Padding = new System.Windows.Forms.Padding(3);
            this.pg_payes.Size = new System.Drawing.Size(1623, 307);
            this.pg_payes.TabIndex = 2;
            this.pg_payes.UseVisualStyleBackColor = true;
            // 
            // pg_toutes
            // 
            this.pg_toutes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pg_toutes.ImageKey = "(aucun)";
            this.pg_toutes.Location = new System.Drawing.Point(4, 64);
            this.pg_toutes.Name = "pg_toutes";
            this.pg_toutes.Padding = new System.Windows.Forms.Padding(3);
            this.pg_toutes.Size = new System.Drawing.Size(1623, 307);
            this.pg_toutes.TabIndex = 0;
            this.pg_toutes.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lb_rappel);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(1339, 733);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 164);
            this.panel2.TabIndex = 9;
            // 
            // lb_rappel
            // 
            this.lb_rappel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rappel.Location = new System.Drawing.Point(67, 9);
            this.lb_rappel.Name = "lb_rappel";
            this.lb_rappel.Size = new System.Drawing.Size(68, 13);
            this.lb_rappel.TabIndex = 12;
            this.lb_rappel.Text = "Rappel";
            this.lb_rappel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Rappel";
            // 
            // lb_nbrfact
            // 
            this.lb_nbrfact.AutoSize = true;
            this.lb_nbrfact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nbrfact.Location = new System.Drawing.Point(1127, 51);
            this.lb_nbrfact.Name = "lb_nbrfact";
            this.lb_nbrfact.Size = new System.Drawing.Size(96, 15);
            this.lb_nbrfact.TabIndex = 0;
            this.lb_nbrfact.Text = "Nbr de factures :";
            this.lb_nbrfact.Visible = false;
            // 
            // lb_mttfact
            // 
            this.lb_mttfact.AutoSize = true;
            this.lb_mttfact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mttfact.Location = new System.Drawing.Point(1297, 51);
            this.lb_mttfact.Name = "lb_mttfact";
            this.lb_mttfact.Size = new System.Drawing.Size(127, 15);
            this.lb_mttfact.TabIndex = 10;
            this.lb_mttfact.Text = "Montant des factures :";
            this.lb_mttfact.Visible = false;
            // 
            // lb_saisies
            // 
            this.lb_saisies.BackColor = System.Drawing.Color.MistyRose;
            this.lb_saisies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_saisies.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_saisies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_saisies.ForeColor = System.Drawing.Color.Magenta;
            this.lb_saisies.Location = new System.Drawing.Point(19, 135);
            this.lb_saisies.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lb_saisies.Name = "lb_saisies";
            this.lb_saisies.Size = new System.Drawing.Size(161, 52);
            this.lb_saisies.TabIndex = 0;
            this.lb_saisies.Text = "Factures saisies";
            this.lb_saisies.BackColorChanged += new System.EventHandler(this.lb_toutes_BackColorChanged);
            this.lb_saisies.Click += new System.EventHandler(this.lb_saisies_Click);
            this.lb_saisies.MouseEnter += new System.EventHandler(this.lb_payees_MouseHover);
            // 
            // lb_nbrsai
            // 
            this.lb_nbrsai.AutoSize = true;
            this.lb_nbrsai.BackColor = System.Drawing.Color.Transparent;
            this.lb_nbrsai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_nbrsai.Location = new System.Drawing.Point(34, 155);
            this.lb_nbrsai.Name = "lb_nbrsai";
            this.lb_nbrsai.Size = new System.Drawing.Size(28, 13);
            this.lb_nbrsai.TabIndex = 11;
            this.lb_nbrsai.Text = "nbr :";
            this.lb_nbrsai.Click += new System.EventHandler(this.lb_saisies_Click);
            // 
            // lb_mttsai
            // 
            this.lb_mttsai.AutoSize = true;
            this.lb_mttsai.BackColor = System.Drawing.Color.Transparent;
            this.lb_mttsai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_mttsai.Location = new System.Drawing.Point(34, 170);
            this.lb_mttsai.Name = "lb_mttsai";
            this.lb_mttsai.Size = new System.Drawing.Size(27, 13);
            this.lb_mttsai.TabIndex = 12;
            this.lb_mttsai.Text = "mtt :";
            this.lb_mttsai.Click += new System.EventHandler(this.lb_saisies_Click);
            // 
            // lb_mttenv
            // 
            this.lb_mttenv.AutoSize = true;
            this.lb_mttenv.BackColor = System.Drawing.Color.Transparent;
            this.lb_mttenv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_mttenv.Location = new System.Drawing.Point(206, 170);
            this.lb_mttenv.Name = "lb_mttenv";
            this.lb_mttenv.Size = new System.Drawing.Size(27, 13);
            this.lb_mttenv.TabIndex = 15;
            this.lb_mttenv.Text = "mtt :";
            this.lb_mttenv.Click += new System.EventHandler(this.lb_encoyees_Click);
            // 
            // lb_nbrenv
            // 
            this.lb_nbrenv.AutoSize = true;
            this.lb_nbrenv.BackColor = System.Drawing.Color.Transparent;
            this.lb_nbrenv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_nbrenv.Location = new System.Drawing.Point(206, 155);
            this.lb_nbrenv.Name = "lb_nbrenv";
            this.lb_nbrenv.Size = new System.Drawing.Size(28, 13);
            this.lb_nbrenv.TabIndex = 14;
            this.lb_nbrenv.Text = "nbr :";
            this.lb_nbrenv.Click += new System.EventHandler(this.lb_encoyees_Click);
            // 
            // lb_envoyees
            // 
            this.lb_envoyees.BackColor = System.Drawing.Color.Transparent;
            this.lb_envoyees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_envoyees.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_envoyees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_envoyees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lb_envoyees.Location = new System.Drawing.Point(191, 135);
            this.lb_envoyees.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lb_envoyees.Name = "lb_envoyees";
            this.lb_envoyees.Size = new System.Drawing.Size(162, 52);
            this.lb_envoyees.TabIndex = 13;
            this.lb_envoyees.Text = "Factures envoyées";
            this.lb_envoyees.BackColorChanged += new System.EventHandler(this.lb_toutes_BackColorChanged);
            this.lb_envoyees.Click += new System.EventHandler(this.lb_encoyees_Click);
            this.lb_envoyees.MouseEnter += new System.EventHandler(this.lb_payees_MouseHover);
            // 
            // lb_mttech
            // 
            this.lb_mttech.AutoSize = true;
            this.lb_mttech.BackColor = System.Drawing.Color.Transparent;
            this.lb_mttech.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_mttech.Location = new System.Drawing.Point(552, 170);
            this.lb_mttech.Name = "lb_mttech";
            this.lb_mttech.Size = new System.Drawing.Size(27, 13);
            this.lb_mttech.TabIndex = 18;
            this.lb_mttech.Text = "mtt :";
            this.lb_mttech.Click += new System.EventHandler(this.lb_echeances_Click);
            // 
            // lb_nbrech
            // 
            this.lb_nbrech.AutoSize = true;
            this.lb_nbrech.BackColor = System.Drawing.Color.Transparent;
            this.lb_nbrech.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_nbrech.Location = new System.Drawing.Point(552, 155);
            this.lb_nbrech.Name = "lb_nbrech";
            this.lb_nbrech.Size = new System.Drawing.Size(28, 13);
            this.lb_nbrech.TabIndex = 17;
            this.lb_nbrech.Text = "nbr :";
            this.lb_nbrech.Click += new System.EventHandler(this.lb_echeances_Click);
            // 
            // lb_echeances
            // 
            this.lb_echeances.BackColor = System.Drawing.Color.Transparent;
            this.lb_echeances.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_echeances.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_echeances.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_echeances.ForeColor = System.Drawing.Color.Red;
            this.lb_echeances.Location = new System.Drawing.Point(537, 135);
            this.lb_echeances.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lb_echeances.Name = "lb_echeances";
            this.lb_echeances.Size = new System.Drawing.Size(162, 52);
            this.lb_echeances.TabIndex = 16;
            this.lb_echeances.Text = "Factures à échéance";
            this.lb_echeances.BackColorChanged += new System.EventHandler(this.lb_toutes_BackColorChanged);
            this.lb_echeances.Click += new System.EventHandler(this.lb_echeances_Click);
            this.lb_echeances.MouseEnter += new System.EventHandler(this.lb_payees_MouseHover);
            // 
            // lb_mttpay
            // 
            this.lb_mttpay.AutoSize = true;
            this.lb_mttpay.BackColor = System.Drawing.Color.Transparent;
            this.lb_mttpay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_mttpay.Location = new System.Drawing.Point(725, 170);
            this.lb_mttpay.Name = "lb_mttpay";
            this.lb_mttpay.Size = new System.Drawing.Size(27, 13);
            this.lb_mttpay.TabIndex = 21;
            this.lb_mttpay.Text = "mtt :";
            this.lb_mttpay.Click += new System.EventHandler(this.lb_payees_Click);
            // 
            // lb_nbrpay
            // 
            this.lb_nbrpay.AutoSize = true;
            this.lb_nbrpay.BackColor = System.Drawing.Color.Transparent;
            this.lb_nbrpay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_nbrpay.Location = new System.Drawing.Point(725, 155);
            this.lb_nbrpay.Name = "lb_nbrpay";
            this.lb_nbrpay.Size = new System.Drawing.Size(28, 13);
            this.lb_nbrpay.TabIndex = 20;
            this.lb_nbrpay.Text = "nbr :";
            this.lb_nbrpay.Click += new System.EventHandler(this.lb_payees_Click);
            // 
            // lb_payees
            // 
            this.lb_payees.BackColor = System.Drawing.Color.Transparent;
            this.lb_payees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_payees.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_payees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_payees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lb_payees.Location = new System.Drawing.Point(710, 135);
            this.lb_payees.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lb_payees.Name = "lb_payees";
            this.lb_payees.Size = new System.Drawing.Size(162, 52);
            this.lb_payees.TabIndex = 19;
            this.lb_payees.Text = "Factures payées";
            this.lb_payees.BackColorChanged += new System.EventHandler(this.lb_toutes_BackColorChanged);
            this.lb_payees.Click += new System.EventHandler(this.lb_payees_Click);
            this.lb_payees.MouseEnter += new System.EventHandler(this.lb_payees_MouseHover);
            // 
            // lb_mtttou
            // 
            this.lb_mtttou.AutoSize = true;
            this.lb_mtttou.BackColor = System.Drawing.Color.Transparent;
            this.lb_mtttou.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_mtttou.Location = new System.Drawing.Point(899, 170);
            this.lb_mtttou.Name = "lb_mtttou";
            this.lb_mtttou.Size = new System.Drawing.Size(27, 13);
            this.lb_mtttou.TabIndex = 24;
            this.lb_mtttou.Text = "mtt :";
            this.lb_mtttou.Click += new System.EventHandler(this.lb_toutes_Click);
            // 
            // lb_nbrtou
            // 
            this.lb_nbrtou.AutoSize = true;
            this.lb_nbrtou.BackColor = System.Drawing.Color.Transparent;
            this.lb_nbrtou.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_nbrtou.Location = new System.Drawing.Point(899, 155);
            this.lb_nbrtou.Name = "lb_nbrtou";
            this.lb_nbrtou.Size = new System.Drawing.Size(28, 13);
            this.lb_nbrtou.TabIndex = 23;
            this.lb_nbrtou.Text = "nbr :";
            this.lb_nbrtou.Click += new System.EventHandler(this.lb_toutes_Click);
            // 
            // lb_toutes
            // 
            this.lb_toutes.BackColor = System.Drawing.Color.Transparent;
            this.lb_toutes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_toutes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_toutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_toutes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lb_toutes.Location = new System.Drawing.Point(884, 135);
            this.lb_toutes.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lb_toutes.Name = "lb_toutes";
            this.lb_toutes.Size = new System.Drawing.Size(160, 52);
            this.lb_toutes.TabIndex = 22;
            this.lb_toutes.Text = "Toutes les Factures";
            this.lb_toutes.BackColorChanged += new System.EventHandler(this.lb_toutes_BackColorChanged);
            this.lb_toutes.Click += new System.EventHandler(this.lb_toutes_Click);
            this.lb_toutes.MouseEnter += new System.EventHandler(this.lb_payees_MouseHover);
            // 
            // lb_lbrappel
            // 
            this.lb_lbrappel.AutoSize = true;
            this.lb_lbrappel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lbrappel.Location = new System.Drawing.Point(1422, 167);
            this.lb_lbrappel.Name = "lb_lbrappel";
            this.lb_lbrappel.Size = new System.Drawing.Size(127, 15);
            this.lb_lbrappel.TabIndex = 25;
            this.lb_lbrappel.Text = "nbr de rappel envoyé :";
            this.lb_lbrappel.Visible = false;
            // 
            // lb_mttrap
            // 
            this.lb_mttrap.AutoSize = true;
            this.lb_mttrap.BackColor = System.Drawing.Color.Transparent;
            this.lb_mttrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_mttrap.Location = new System.Drawing.Point(379, 170);
            this.lb_mttrap.Name = "lb_mttrap";
            this.lb_mttrap.Size = new System.Drawing.Size(27, 13);
            this.lb_mttrap.TabIndex = 28;
            this.lb_mttrap.Text = "mtt :";
            this.lb_mttrap.Click += new System.EventHandler(this.lb_rappelenvoye_Click);
            // 
            // lb_nbrrap
            // 
            this.lb_nbrrap.AutoSize = true;
            this.lb_nbrrap.BackColor = System.Drawing.Color.Transparent;
            this.lb_nbrrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_nbrrap.Location = new System.Drawing.Point(379, 155);
            this.lb_nbrrap.Name = "lb_nbrrap";
            this.lb_nbrrap.Size = new System.Drawing.Size(28, 13);
            this.lb_nbrrap.TabIndex = 27;
            this.lb_nbrrap.Text = "nbr :";
            this.lb_nbrrap.Click += new System.EventHandler(this.lb_rappelenvoye_Click);
            // 
            // lb_rappelenvoye
            // 
            this.lb_rappelenvoye.BackColor = System.Drawing.Color.Transparent;
            this.lb_rappelenvoye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_rappelenvoye.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_rappelenvoye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rappelenvoye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lb_rappelenvoye.Location = new System.Drawing.Point(364, 135);
            this.lb_rappelenvoye.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lb_rappelenvoye.Name = "lb_rappelenvoye";
            this.lb_rappelenvoye.Size = new System.Drawing.Size(162, 52);
            this.lb_rappelenvoye.TabIndex = 26;
            this.lb_rappelenvoye.Text = "Rappel envoyé";
            this.lb_rappelenvoye.BackColorChanged += new System.EventHandler(this.lb_toutes_BackColorChanged);
            this.lb_rappelenvoye.Click += new System.EventHandler(this.lb_rappelenvoye_Click);
            this.lb_rappelenvoye.MouseEnter += new System.EventHandler(this.lb_payees_MouseHover);
            // 
            // ck_rap1
            // 
            this.ck_rap1.AutoSize = true;
            this.ck_rap1.Checked = true;
            this.ck_rap1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_rap1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ck_rap1.Location = new System.Drawing.Point(1555, 168);
            this.ck_rap1.Margin = new System.Windows.Forms.Padding(0);
            this.ck_rap1.Name = "ck_rap1";
            this.ck_rap1.Size = new System.Drawing.Size(32, 17);
            this.ck_rap1.TabIndex = 29;
            this.ck_rap1.Text = "1";
            this.ck_rap1.UseVisualStyleBackColor = true;
            this.ck_rap1.Visible = false;
            this.ck_rap1.Click += new System.EventHandler(this.lb_rappelenvoye_Click);
            // 
            // ck_rap2
            // 
            this.ck_rap2.AutoSize = true;
            this.ck_rap2.Checked = true;
            this.ck_rap2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_rap2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ck_rap2.Location = new System.Drawing.Point(1602, 168);
            this.ck_rap2.Name = "ck_rap2";
            this.ck_rap2.Size = new System.Drawing.Size(32, 17);
            this.ck_rap2.TabIndex = 30;
            this.ck_rap2.Text = "2";
            this.ck_rap2.UseVisualStyleBackColor = true;
            this.ck_rap2.Visible = false;
            this.ck_rap2.Click += new System.EventHandler(this.lb_rappelenvoye_Click);
            // 
            // imprimerÉtatDeFactureToolStripMenuItem
            // 
            this.imprimerÉtatDeFactureToolStripMenuItem.Name = "imprimerÉtatDeFactureToolStripMenuItem";
            this.imprimerÉtatDeFactureToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.imprimerÉtatDeFactureToolStripMenuItem.Text = "imprimer la liste";
            this.imprimerÉtatDeFactureToolStripMenuItem.Click += new System.EventHandler(this.imprimerÉtatDeFactureToolStripMenuItem_Click);
            // 
            // f_gesfact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 909);
            this.Controls.Add(this.ck_rap2);
            this.Controls.Add(this.ck_rap1);
            this.Controls.Add(this.lb_mttrap);
            this.Controls.Add(this.lb_nbrrap);
            this.Controls.Add(this.lb_rappelenvoye);
            this.Controls.Add(this.lb_lbrappel);
            this.Controls.Add(this.lb_mtttou);
            this.Controls.Add(this.lb_nbrtou);
            this.Controls.Add(this.lb_toutes);
            this.Controls.Add(this.lb_mttpay);
            this.Controls.Add(this.lb_nbrpay);
            this.Controls.Add(this.lb_payees);
            this.Controls.Add(this.lb_mttech);
            this.Controls.Add(this.lb_nbrech);
            this.Controls.Add(this.lb_echeances);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.lb_mttenv);
            this.Controls.Add(this.lb_nbrenv);
            this.Controls.Add(this.lb_envoyees);
            this.Controls.Add(this.lb_mttsai);
            this.Controls.Add(this.lb_nbrsai);
            this.Controls.Add(this.lb_saisies);
            this.Controls.Add(this.lb_mttfact);
            this.Controls.Add(this.lb_nbrfact);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.p_recherche);
            this.Controls.Add(this.p_facture);
            this.Controls.Add(this.gv_fact);
            this.Controls.Add(this.p_menu);
            this.Controls.Add(this.tp_facture);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_gesfact";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion de Facturation";
            this.Load += new System.EventHandler(this.f_gesfact_Load);
            this.Shown += new System.EventHandler(this.f_gesfact_Shown);
            this.p_menu.ResumeLayout(false);
            this.men_rappel.ResumeLayout(false);
            this.men_impression.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_fact)).EndInit();
            this.p_facture.ResumeLayout(false);
            this.p_facture.PerformLayout();
            this.p_recherche.ResumeLayout(false);
            this.p_recherche.PerformLayout();
            this.men_ligne.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_paiement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_procedure)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tp_facture.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MySql.Data.MySqlClient.MySqlCommand comrealvistamod;
        private System.Windows.Forms.ImageList imageList1;
        public MySql.Data.MySqlClient.MySqlCommand comaffichefacture;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Panel p_menu;
        private System.Windows.Forms.DataGridView gv_fact;
        private System.Windows.Forms.Panel p_facture;
        private System.Windows.Forms.TextBox reffactureentreprise;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox reffacturedeltareal;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker datecommande;
        private System.Windows.Forms.Button bt_annul;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.Button bt_modif;
        private System.Windows.Forms.Button bt_suppr;
        private System.Windows.Forms.Button bt_ajout;
        private System.Windows.Forms.Button bt_fermer;
        private System.Windows.Forms.TextBox montantarticle;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox prixunitaire;
        private System.Windows.Forms.TextBox nbrarticle;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox libellearticle;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Panel p_recherche;
        public MySql.Data.MySqlClient.MySqlCommand comrech;
        private System.Windows.Forms.TextBox codearticle;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TextBox unite;
        private System.Windows.Forms.Button bt_toutaffciher;
        private System.Windows.Forms.Button bt_impression;
        private System.Windows.Forms.TextBox idarticle;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Label lb_entreprise;
        private System.Windows.Forms.TextBox rechfacture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rechclient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_typesaisie;
        private System.Windows.Forms.TextBox ed_rabaischf;
        private System.Windows.Forms.TextBox ed_rabaispourcent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox idrabais;
        private System.Windows.Forms.TextBox idprix;
        private System.Windows.Forms.ContextMenuStrip men_ligne;
        private System.Windows.Forms.ToolStripMenuItem menligne_ajouterUneLigne;
        private System.Windows.Forms.ToolStripMenuItem menligne_supprimerUneLigne;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox remarquearticle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_imprimer;
        private System.Windows.Forms.Button bt_imprimertout;
        private System.Windows.Forms.DataGridView gv_procedure;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_initial;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_inouttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_dateproc;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_typecourrier;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_echeanceproc;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idprocedure;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_numfacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idclientproc;
        private System.Windows.Forms.Button bt_supproc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tp_facture;
        private System.Windows.Forms.TabPage pg_toutes;
        private System.Windows.Forms.TabPage pg_envoyes;
        private System.Windows.Forms.TabPage pg_payes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView gv_paiement;
        private System.Windows.Forms.Button bt_listepaiement;
        private System.Windows.Forms.Button bt_pajout;
        private System.Windows.Forms.TabPage pg_saisies;
        private System.Windows.Forms.Button bt_compta;
        private System.Windows.Forms.Label lb_nbrfact;
        private System.Windows.Forms.Label lb_mttfact;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_datesaisie;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_datepaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_typepaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_montantpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idclientpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_reffactdeltareal;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_reffactentreprise;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_datecommande;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_codearticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_libellearticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_remarquearticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_nbrarticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_montantbrut;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_rabaisfacturepourcent;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_rabaisfacturechf;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_tvachf;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_fraisenvoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_fraisassurance;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_interets;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_fraisrappel;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_montantapayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_dateimpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_echeance;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_montantpaye;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_solde;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idfacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_identreprise;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idclient;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idarticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_numligne;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idprix;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idrabais;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_groupe;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_rappel;
        private System.Windows.Forms.Label lb_rappel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage pg_echeance;
        private System.Windows.Forms.ContextMenuStrip men_impression;
        private System.Windows.Forms.ToolStripMenuItem imprimerLaFactureSélectionnéeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimerToutesLesFacturesDansLaListeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impressionComptableToolStripMenuItem;
        private System.Windows.Forms.Button bt_rappel;
        private System.Windows.Forms.ToolStripMenuItem imprimerrappel;
        private System.Windows.Forms.Label lb_saisies;
        private System.Windows.Forms.Label lb_nbrsai;
        private System.Windows.Forms.Label lb_mttsai;
        private System.Windows.Forms.Label lb_mttenv;
        private System.Windows.Forms.Label lb_nbrenv;
        private System.Windows.Forms.Label lb_envoyees;
        private System.Windows.Forms.Label lb_mttech;
        private System.Windows.Forms.Label lb_nbrech;
        private System.Windows.Forms.Label lb_echeances;
        private System.Windows.Forms.Label lb_mttpay;
        private System.Windows.Forms.Label lb_nbrpay;
        private System.Windows.Forms.Label lb_payees;
        private System.Windows.Forms.Label lb_mtttou;
        private System.Windows.Forms.Label lb_nbrtou;
        private System.Windows.Forms.Label lb_toutes;
        private System.Windows.Forms.Label lb_lbrappel;
        private System.Windows.Forms.TabPage pg_rappel;
        private System.Windows.Forms.Label lb_mttrap;
        private System.Windows.Forms.Label lb_nbrrap;
        private System.Windows.Forms.Label lb_rappelenvoye;
        private System.Windows.Forms.ContextMenuStrip men_rappel;
        private System.Windows.Forms.ToolStripMenuItem pourLaFactureSélectionnéeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pourToutesLesFacturesÀÉchéanceToolStripMenuItem;
        private System.Windows.Forms.CheckBox ck_rap1;
        private System.Windows.Forms.CheckBox ck_rap2;
        private System.Windows.Forms.Button bt_modifajoutart;
        private System.Windows.Forms.ToolStripMenuItem imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimerÉtatDeFactureToolStripMenuItem;
    }
}