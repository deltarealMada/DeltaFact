namespace DeltaFact
{
    partial class f_debiteur
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_debiteur));
            this.comrealvista = new MySql.Data.MySqlClient.MySqlCommand();
            this.raisonsociale = new System.Windows.Forms.TextBox();
            this.nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.p_affiche = new System.Windows.Forms.Panel();
            this.prenom = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.language = new System.Windows.Forms.TextBox();
            this.co = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.adresse2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.refclient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fax = new System.Windows.Forms.TextBox();
            this.telpro = new System.Windows.Forms.TextBox();
            this.telmob = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.ville = new WindowsFormsControlLibrary1.ComboMi();
            this.npa = new WindowsFormsControlLibrary1.ComboMi();
            this.label7 = new System.Windows.Forms.Label();
            this.politesse = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.adresse1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.p_button = new System.Windows.Forms.Panel();
            this.bt_annul = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bt_valider = new System.Windows.Forms.Button();
            this.bt_suppr = new System.Windows.Forms.Button();
            this.bt_ajout = new System.Windows.Forms.Button();
            this.bt_modif = new System.Windows.Forms.Button();
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
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.comrealvistamod = new MySql.Data.MySqlClient.MySqlCommand();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.p_archive = new System.Windows.Forms.Panel();
            this.politesse_1 = new System.Windows.Forms.TextBox();
            this.ville_1 = new System.Windows.Forms.TextBox();
            this.npa_1 = new System.Windows.Forms.TextBox();
            this.prenom_1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.language_1 = new System.Windows.Forms.TextBox();
            this.co_1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.adresse2_1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.refarchive_1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.fax_1 = new System.Windows.Forms.TextBox();
            this.telpro_1 = new System.Windows.Forms.TextBox();
            this.telmob_1 = new System.Windows.Forms.TextBox();
            this.email_1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.adresse1_1 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.raisonsociale_1 = new System.Windows.Forms.TextBox();
            this.nom_1 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.l_archive = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_ajoutfact = new System.Windows.Forms.Button();
            this.bt_fermer = new System.Windows.Forms.Button();
            this.bt_toutafficher = new System.Windows.Forms.Button();
            this.bt_recherche = new System.Windows.Forms.Button();
            this.p_affiche.SuspendLayout();
            this.p_button.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_client)).BeginInit();
            this.p_archive.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comrealvista
            // 
            this.comrealvista.CacheAge = 60;
            this.comrealvista.Connection = null;
            this.comrealvista.EnableCaching = false;
            this.comrealvista.Transaction = null;
            // 
            // raisonsociale
            // 
            this.raisonsociale.Location = new System.Drawing.Point(93, 48);
            this.raisonsociale.Name = "raisonsociale";
            this.raisonsociale.Size = new System.Drawing.Size(386, 20);
            this.raisonsociale.TabIndex = 1;
            this.raisonsociale.Tag = "2";
            this.raisonsociale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.raisonsociale_KeyPress);
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(93, 100);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(161, 20);
            this.nom.TabIndex = 4;
            this.nom.Tag = "2";
            this.nom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nom_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "raison sociale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "réf client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "nom";
            // 
            // p_affiche
            // 
            this.p_affiche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.p_affiche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p_affiche.Controls.Add(this.prenom);
            this.p_affiche.Controls.Add(this.label14);
            this.p_affiche.Controls.Add(this.language);
            this.p_affiche.Controls.Add(this.co);
            this.p_affiche.Controls.Add(this.label6);
            this.p_affiche.Controls.Add(this.adresse2);
            this.p_affiche.Controls.Add(this.label11);
            this.p_affiche.Controls.Add(this.label12);
            this.p_affiche.Controls.Add(this.refclient);
            this.p_affiche.Controls.Add(this.label5);
            this.p_affiche.Controls.Add(this.label4);
            this.p_affiche.Controls.Add(this.fax);
            this.p_affiche.Controls.Add(this.telpro);
            this.p_affiche.Controls.Add(this.telmob);
            this.p_affiche.Controls.Add(this.email);
            this.p_affiche.Controls.Add(this.label28);
            this.p_affiche.Controls.Add(this.label29);
            this.p_affiche.Controls.Add(this.ville);
            this.p_affiche.Controls.Add(this.npa);
            this.p_affiche.Controls.Add(this.label7);
            this.p_affiche.Controls.Add(this.politesse);
            this.p_affiche.Controls.Add(this.label9);
            this.p_affiche.Controls.Add(this.adresse1);
            this.p_affiche.Controls.Add(this.label8);
            this.p_affiche.Controls.Add(this.raisonsociale);
            this.p_affiche.Controls.Add(this.nom);
            this.p_affiche.Controls.Add(this.label3);
            this.p_affiche.Controls.Add(this.label2);
            this.p_affiche.Controls.Add(this.label1);
            this.p_affiche.Location = new System.Drawing.Point(22, 54);
            this.p_affiche.Name = "p_affiche";
            this.p_affiche.Size = new System.Drawing.Size(494, 274);
            this.p_affiche.TabIndex = 0;
            this.p_affiche.Leave += new System.EventHandler(this.p_affiche_Leave);
            this.p_affiche.Validating += new System.ComponentModel.CancelEventHandler(this.p_affiche_Validating);
            this.p_affiche.Validated += new System.EventHandler(this.p_affiche_Validated);
            // 
            // prenom
            // 
            this.prenom.Location = new System.Drawing.Point(319, 101);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(160, 20);
            this.prenom.TabIndex = 5;
            this.prenom.Tag = "2";
            this.prenom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.prenom_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(260, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 300;
            this.label14.Text = "prénom";
            // 
            // language
            // 
            this.language.BackColor = System.Drawing.SystemColors.Window;
            this.language.Enabled = false;
            this.language.Location = new System.Drawing.Point(319, 75);
            this.language.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(160, 20);
            this.language.TabIndex = 3;
            this.language.Tag = "3";
            // 
            // co
            // 
            this.co.Location = new System.Drawing.Point(93, 127);
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(386, 20);
            this.co.TabIndex = 6;
            this.co.Tag = "2";
            this.co.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.co_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 297;
            this.label6.Text = "c/o";
            // 
            // adresse2
            // 
            this.adresse2.Location = new System.Drawing.Point(319, 153);
            this.adresse2.Name = "adresse2";
            this.adresse2.Size = new System.Drawing.Size(160, 20);
            this.adresse2.TabIndex = 8;
            this.adresse2.Tag = "2";
            this.adresse2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adresse2_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(260, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 295;
            this.label11.Text = "adresse 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(260, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 293;
            this.label12.Text = "langue";
            // 
            // refclient
            // 
            this.refclient.Enabled = false;
            this.refclient.Location = new System.Drawing.Point(93, 22);
            this.refclient.Name = "refclient";
            this.refclient.Size = new System.Drawing.Size(86, 20);
            this.refclient.TabIndex = 0;
            this.refclient.Tag = "0";
            this.refclient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.refclient_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(269, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 285;
            this.label5.Text = "email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 209);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 284;
            this.label4.Text = "tél. mob.";
            // 
            // fax
            // 
            this.fax.Location = new System.Drawing.Point(93, 232);
            this.fax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(161, 20);
            this.fax.TabIndex = 13;
            this.fax.Tag = "2";
            // 
            // telpro
            // 
            this.telpro.Location = new System.Drawing.Point(93, 206);
            this.telpro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.telpro.Name = "telpro";
            this.telpro.Size = new System.Drawing.Size(161, 20);
            this.telpro.TabIndex = 11;
            this.telpro.Tag = "2";
            // 
            // telmob
            // 
            this.telmob.Location = new System.Drawing.Point(319, 206);
            this.telmob.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.telmob.Name = "telmob";
            this.telmob.Size = new System.Drawing.Size(160, 20);
            this.telmob.TabIndex = 12;
            this.telmob.Tag = "2";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(319, 232);
            this.email.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(160, 20);
            this.email.TabIndex = 14;
            this.email.Tag = "2";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(9, 232);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 14);
            this.label28.TabIndex = 281;
            this.label28.Text = "fax";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(9, 210);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(43, 14);
            this.label29.TabIndex = 280;
            this.label29.Text = "tél. pro.";
            // 
            // ville
            // 
            this.ville.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ville.BackColor = System.Drawing.Color.Transparent;
            this.ville.IndCombo = null;
            this.ville.LargeurCol2 = 267;
            this.ville.Location = new System.Drawing.Point(180, 179);
            this.ville.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ville.Name = "ville";
            this.ville.Size = new System.Drawing.Size(300, 21);
            this.ville.TabIndex = 10;
            this.ville.Tag = "2";
            this.ville.Combo_DropDown += new WindowsFormsControlLibrary1.ComboMi.Combo_DropDHandler(this.ville_Combo_DropDown);
            this.ville.Combo_DropUp += new WindowsFormsControlLibrary1.ComboMi.Combo_DropUHandler(this.ville_Combo_DropUp);
            // 
            // npa
            // 
            this.npa.AccessibleRole = System.Windows.Forms.AccessibleRole.Animation;
            this.npa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.npa.BackColor = System.Drawing.Color.Transparent;
            this.npa.IndCombo = null;
            this.npa.LargeurCol2 = 267;
            this.npa.Location = new System.Drawing.Point(91, 179);
            this.npa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.npa.Name = "npa";
            this.npa.Size = new System.Drawing.Size(88, 22);
            this.npa.TabIndex = 9;
            this.npa.Tag = "2";
            this.npa.Combo_DropDown += new WindowsFormsControlLibrary1.ComboMi.Combo_DropDHandler(this.npa_Combo_DropDown);
            this.npa.Combo_DropUp += new WindowsFormsControlLibrary1.ComboMi.Combo_DropUHandler(this.npa_Combo_DropUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "politesse";
            // 
            // politesse
            // 
            this.politesse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.politesse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.politesse.DisplayMember = "politesse";
            this.politesse.FormattingEnabled = true;
            this.politesse.Location = new System.Drawing.Point(93, 74);
            this.politesse.Name = "politesse";
            this.politesse.Size = new System.Drawing.Size(161, 21);
            this.politesse.TabIndex = 2;
            this.politesse.Tag = "2";
            this.politesse.ValueMember = "idpolitesse";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "npa ville";
            // 
            // adresse1
            // 
            this.adresse1.Location = new System.Drawing.Point(93, 153);
            this.adresse1.Name = "adresse1";
            this.adresse1.Size = new System.Drawing.Size(161, 20);
            this.adresse1.TabIndex = 7;
            this.adresse1.Tag = "2";
            this.adresse1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adresse1_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "adresse 1";
            // 
            // p_button
            // 
            this.p_button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_button.Controls.Add(this.bt_annul);
            this.p_button.Controls.Add(this.bt_valider);
            this.p_button.Controls.Add(this.bt_suppr);
            this.p_button.Controls.Add(this.bt_ajout);
            this.p_button.Controls.Add(this.bt_modif);
            this.p_button.Location = new System.Drawing.Point(22, 338);
            this.p_button.Name = "p_button";
            this.p_button.Size = new System.Drawing.Size(494, 40);
            this.p_button.TabIndex = 4;
            // 
            // bt_annul
            // 
            this.bt_annul.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_annul.ImageIndex = 9;
            this.bt_annul.ImageList = this.imageList1;
            this.bt_annul.Location = new System.Drawing.Point(395, 9);
            this.bt_annul.Name = "bt_annul";
            this.bt_annul.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_annul.Size = new System.Drawing.Size(85, 23);
            this.bt_annul.TabIndex = 4;
            this.bt_annul.Tag = "2";
            this.bt_annul.Text = "annuler";
            this.bt_annul.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_annul.UseVisualStyleBackColor = true;
            this.bt_annul.Click += new System.EventHandler(this.bt_annul_Click);
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
            this.imageList1.Images.SetKeyName(10, "search_glyph.png");
            this.imageList1.Images.SetKeyName(11, "settings_16.png");
            // 
            // bt_valider
            // 
            this.bt_valider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_valider.ImageIndex = 1;
            this.bt_valider.ImageList = this.imageList1;
            this.bt_valider.Location = new System.Drawing.Point(300, 9);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_valider.Size = new System.Drawing.Size(85, 23);
            this.bt_valider.TabIndex = 3;
            this.bt_valider.Tag = "2";
            this.bt_valider.Text = "valider";
            this.bt_valider.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // bt_suppr
            // 
            this.bt_suppr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_suppr.ImageIndex = 6;
            this.bt_suppr.ImageList = this.imageList1;
            this.bt_suppr.Location = new System.Drawing.Point(205, 9);
            this.bt_suppr.Name = "bt_suppr";
            this.bt_suppr.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_suppr.Size = new System.Drawing.Size(85, 23);
            this.bt_suppr.TabIndex = 2;
            this.bt_suppr.Tag = "1";
            this.bt_suppr.Text = "supprimer";
            this.bt_suppr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_suppr.UseVisualStyleBackColor = true;
            this.bt_suppr.Click += new System.EventHandler(this.bt_suppr_Click);
            // 
            // bt_ajout
            // 
            this.bt_ajout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ajout.ImageIndex = 5;
            this.bt_ajout.ImageList = this.imageList1;
            this.bt_ajout.Location = new System.Drawing.Point(108, 9);
            this.bt_ajout.Name = "bt_ajout";
            this.bt_ajout.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_ajout.Size = new System.Drawing.Size(85, 23);
            this.bt_ajout.TabIndex = 1;
            this.bt_ajout.Tag = "1";
            this.bt_ajout.Text = "ajouter";
            this.bt_ajout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_ajout.UseVisualStyleBackColor = true;
            this.bt_ajout.Click += new System.EventHandler(this.bt_ajout_Click);
            // 
            // bt_modif
            // 
            this.bt_modif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_modif.ImageIndex = 2;
            this.bt_modif.ImageList = this.imageList1;
            this.bt_modif.Location = new System.Drawing.Point(11, 9);
            this.bt_modif.Name = "bt_modif";
            this.bt_modif.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_modif.Size = new System.Drawing.Size(85, 23);
            this.bt_modif.TabIndex = 0;
            this.bt_modif.Tag = "1";
            this.bt_modif.Text = "modifier";
            this.bt_modif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_modif.UseVisualStyleBackColor = true;
            this.bt_modif.Click += new System.EventHandler(this.bt_modif_Click);
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
            this.gv_client.Location = new System.Drawing.Point(22, 433);
            this.gv_client.Name = "gv_client";
            this.gv_client.ReadOnly = true;
            this.gv_client.RowHeadersVisible = false;
            this.gv_client.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_client.Size = new System.Drawing.Size(1151, 316);
            this.gv_client.TabIndex = 6;
            this.gv_client.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_debiteur_CellClick);
            this.gv_client.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_client_CellDoubleClick);
            this.gv_client.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_debiteur_RowEnter);
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
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 412);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1151, 21);
            this.label13.TabIndex = 7;
            this.label13.Text = "liste clients";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Beige;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(542, 35);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(631, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "adresses archives du client sélectionné";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // p_archive
            // 
            this.p_archive.BackColor = System.Drawing.Color.Beige;
            this.p_archive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_archive.Controls.Add(this.politesse_1);
            this.p_archive.Controls.Add(this.ville_1);
            this.p_archive.Controls.Add(this.npa_1);
            this.p_archive.Controls.Add(this.prenom_1);
            this.p_archive.Controls.Add(this.label15);
            this.p_archive.Controls.Add(this.language_1);
            this.p_archive.Controls.Add(this.co_1);
            this.p_archive.Controls.Add(this.label16);
            this.p_archive.Controls.Add(this.adresse2_1);
            this.p_archive.Controls.Add(this.label17);
            this.p_archive.Controls.Add(this.label18);
            this.p_archive.Controls.Add(this.refarchive_1);
            this.p_archive.Controls.Add(this.label19);
            this.p_archive.Controls.Add(this.label20);
            this.p_archive.Controls.Add(this.fax_1);
            this.p_archive.Controls.Add(this.telpro_1);
            this.p_archive.Controls.Add(this.telmob_1);
            this.p_archive.Controls.Add(this.email_1);
            this.p_archive.Controls.Add(this.label21);
            this.p_archive.Controls.Add(this.label22);
            this.p_archive.Controls.Add(this.label23);
            this.p_archive.Controls.Add(this.label24);
            this.p_archive.Controls.Add(this.adresse1_1);
            this.p_archive.Controls.Add(this.label25);
            this.p_archive.Controls.Add(this.raisonsociale_1);
            this.p_archive.Controls.Add(this.nom_1);
            this.p_archive.Controls.Add(this.label26);
            this.p_archive.Controls.Add(this.label27);
            this.p_archive.Controls.Add(this.label30);
            this.p_archive.Enabled = false;
            this.p_archive.Location = new System.Drawing.Point(680, 54);
            this.p_archive.Name = "p_archive";
            this.p_archive.Size = new System.Drawing.Size(493, 274);
            this.p_archive.TabIndex = 2;
            // 
            // politesse_1
            // 
            this.politesse_1.Location = new System.Drawing.Point(93, 76);
            this.politesse_1.Name = "politesse_1";
            this.politesse_1.Size = new System.Drawing.Size(161, 20);
            this.politesse_1.TabIndex = 2;
            this.politesse_1.Tag = "12";
            // 
            // ville_1
            // 
            this.ville_1.Location = new System.Drawing.Point(185, 181);
            this.ville_1.Name = "ville_1";
            this.ville_1.Size = new System.Drawing.Size(294, 20);
            this.ville_1.TabIndex = 10;
            this.ville_1.Tag = "12";
            // 
            // npa_1
            // 
            this.npa_1.Location = new System.Drawing.Point(93, 181);
            this.npa_1.Name = "npa_1";
            this.npa_1.Size = new System.Drawing.Size(86, 20);
            this.npa_1.TabIndex = 9;
            this.npa_1.Tag = "12";
            // 
            // prenom_1
            // 
            this.prenom_1.Location = new System.Drawing.Point(319, 103);
            this.prenom_1.Name = "prenom_1";
            this.prenom_1.Size = new System.Drawing.Size(160, 20);
            this.prenom_1.TabIndex = 5;
            this.prenom_1.Tag = "12";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(260, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 300;
            this.label15.Text = "prénom";
            // 
            // language_1
            // 
            this.language_1.BackColor = System.Drawing.SystemColors.Window;
            this.language_1.Enabled = false;
            this.language_1.Location = new System.Drawing.Point(319, 77);
            this.language_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.language_1.Name = "language_1";
            this.language_1.Size = new System.Drawing.Size(160, 20);
            this.language_1.TabIndex = 3;
            this.language_1.Tag = "12";
            // 
            // co_1
            // 
            this.co_1.Location = new System.Drawing.Point(93, 129);
            this.co_1.Name = "co_1";
            this.co_1.Size = new System.Drawing.Size(386, 20);
            this.co_1.TabIndex = 6;
            this.co_1.Tag = "12";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 132);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 297;
            this.label16.Text = "c/o";
            // 
            // adresse2_1
            // 
            this.adresse2_1.Location = new System.Drawing.Point(319, 155);
            this.adresse2_1.Name = "adresse2_1";
            this.adresse2_1.Size = new System.Drawing.Size(160, 20);
            this.adresse2_1.TabIndex = 8;
            this.adresse2_1.Tag = "12";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(260, 158);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 295;
            this.label17.Text = "adresse 2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(260, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 13);
            this.label18.TabIndex = 293;
            this.label18.Text = "langue";
            // 
            // refarchive_1
            // 
            this.refarchive_1.Enabled = false;
            this.refarchive_1.Location = new System.Drawing.Point(93, 24);
            this.refarchive_1.Name = "refarchive_1";
            this.refarchive_1.Size = new System.Drawing.Size(86, 20);
            this.refarchive_1.TabIndex = 0;
            this.refarchive_1.Tag = "12";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(269, 238);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 14);
            this.label19.TabIndex = 285;
            this.label19.Text = "email";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(269, 211);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 14);
            this.label20.TabIndex = 284;
            this.label20.Text = "tél. mob.";
            // 
            // fax_1
            // 
            this.fax_1.Location = new System.Drawing.Point(93, 234);
            this.fax_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fax_1.Name = "fax_1";
            this.fax_1.Size = new System.Drawing.Size(161, 20);
            this.fax_1.TabIndex = 13;
            this.fax_1.Tag = "12";
            // 
            // telpro_1
            // 
            this.telpro_1.Location = new System.Drawing.Point(93, 208);
            this.telpro_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.telpro_1.Name = "telpro_1";
            this.telpro_1.Size = new System.Drawing.Size(161, 20);
            this.telpro_1.TabIndex = 11;
            this.telpro_1.Tag = "12";
            // 
            // telmob_1
            // 
            this.telmob_1.Location = new System.Drawing.Point(319, 208);
            this.telmob_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.telmob_1.Name = "telmob_1";
            this.telmob_1.Size = new System.Drawing.Size(160, 20);
            this.telmob_1.TabIndex = 12;
            this.telmob_1.Tag = "12";
            // 
            // email_1
            // 
            this.email_1.Location = new System.Drawing.Point(319, 234);
            this.email_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.email_1.Name = "email_1";
            this.email_1.Size = new System.Drawing.Size(160, 20);
            this.email_1.TabIndex = 14;
            this.email_1.Tag = "12";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(9, 238);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 14);
            this.label21.TabIndex = 281;
            this.label21.Text = "fax";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 212);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 14);
            this.label22.TabIndex = 280;
            this.label22.Text = "tél. pro.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 79);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 13);
            this.label23.TabIndex = 25;
            this.label23.Text = "politesse";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 187);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 13);
            this.label24.TabIndex = 20;
            this.label24.Text = "npa ville";
            // 
            // adresse1_1
            // 
            this.adresse1_1.Location = new System.Drawing.Point(93, 155);
            this.adresse1_1.Name = "adresse1_1";
            this.adresse1_1.Size = new System.Drawing.Size(161, 20);
            this.adresse1_1.TabIndex = 7;
            this.adresse1_1.Tag = "12";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 158);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 13);
            this.label25.TabIndex = 18;
            this.label25.Text = "adresse 1";
            // 
            // raisonsociale_1
            // 
            this.raisonsociale_1.Location = new System.Drawing.Point(93, 50);
            this.raisonsociale_1.Name = "raisonsociale_1";
            this.raisonsociale_1.Size = new System.Drawing.Size(386, 20);
            this.raisonsociale_1.TabIndex = 1;
            this.raisonsociale_1.Tag = "12";
            // 
            // nom_1
            // 
            this.nom_1.Location = new System.Drawing.Point(93, 102);
            this.nom_1.Name = "nom_1";
            this.nom_1.Size = new System.Drawing.Size(161, 20);
            this.nom_1.TabIndex = 4;
            this.nom_1.Tag = "12";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 106);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(27, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "nom";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(9, 27);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 13);
            this.label27.TabIndex = 6;
            this.label27.Text = "réf archive";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 53);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(71, 13);
            this.label30.TabIndex = 5;
            this.label30.Text = "raison sociale";
            // 
            // l_archive
            // 
            this.l_archive.BackColor = System.Drawing.Color.Beige;
            this.l_archive.DisplayMember = "datearchive";
            this.l_archive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_archive.FormattingEnabled = true;
            this.l_archive.ItemHeight = 15;
            this.l_archive.Location = new System.Drawing.Point(542, 54);
            this.l_archive.Name = "l_archive";
            this.l_archive.Size = new System.Drawing.Size(138, 274);
            this.l_archive.TabIndex = 1;
            this.l_archive.ValueMember = "idarchive";
            this.l_archive.SelectedIndexChanged += new System.EventHandler(this.l_archive_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bt_ajoutfact);
            this.panel1.Controls.Add(this.bt_fermer);
            this.panel1.Controls.Add(this.bt_toutafficher);
            this.panel1.Controls.Add(this.bt_recherche);
            this.panel1.Location = new System.Drawing.Point(542, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 38);
            this.panel1.TabIndex = 5;
            // 
            // bt_ajoutfact
            // 
            this.bt_ajoutfact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ajoutfact.ImageIndex = 11;
            this.bt_ajoutfact.ImageList = this.imageList1;
            this.bt_ajoutfact.Location = new System.Drawing.Point(235, 7);
            this.bt_ajoutfact.Name = "bt_ajoutfact";
            this.bt_ajoutfact.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_ajoutfact.Size = new System.Drawing.Size(101, 23);
            this.bt_ajoutfact.TabIndex = 3;
            this.bt_ajoutfact.Tag = "2";
            this.bt_ajoutfact.Text = "ajout facture";
            this.bt_ajoutfact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_ajoutfact.UseVisualStyleBackColor = true;
            this.bt_ajoutfact.Click += new System.EventHandler(this.bt_ajoutfact_Click);
            // 
            // bt_fermer
            // 
            this.bt_fermer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_fermer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_fermer.ImageIndex = 8;
            this.bt_fermer.ImageList = this.imageList1;
            this.bt_fermer.Location = new System.Drawing.Point(532, 8);
            this.bt_fermer.Name = "bt_fermer";
            this.bt_fermer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_fermer.Size = new System.Drawing.Size(85, 23);
            this.bt_fermer.TabIndex = 2;
            this.bt_fermer.Tag = "99";
            this.bt_fermer.Text = "fermer";
            this.bt_fermer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_fermer.UseVisualStyleBackColor = true;
            // 
            // bt_toutafficher
            // 
            this.bt_toutafficher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_toutafficher.ImageIndex = 0;
            this.bt_toutafficher.ImageList = this.imageList1;
            this.bt_toutafficher.Location = new System.Drawing.Point(128, 8);
            this.bt_toutafficher.Name = "bt_toutafficher";
            this.bt_toutafficher.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_toutafficher.Size = new System.Drawing.Size(101, 23);
            this.bt_toutafficher.TabIndex = 1;
            this.bt_toutafficher.Tag = "2";
            this.bt_toutafficher.Text = "tout afficher";
            this.bt_toutafficher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_toutafficher.UseVisualStyleBackColor = true;
            this.bt_toutafficher.Click += new System.EventHandler(this.bt_toutafficher_Click);
            // 
            // bt_recherche
            // 
            this.bt_recherche.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_recherche.ImageIndex = 10;
            this.bt_recherche.ImageList = this.imageList1;
            this.bt_recherche.Location = new System.Drawing.Point(15, 8);
            this.bt_recherche.Name = "bt_recherche";
            this.bt_recherche.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_recherche.Size = new System.Drawing.Size(107, 23);
            this.bt_recherche.TabIndex = 0;
            this.bt_recherche.Tag = "2";
            this.bt_recherche.Text = "recherche";
            this.bt_recherche.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_recherche.UseVisualStyleBackColor = true;
            this.bt_recherche.Click += new System.EventHandler(this.bt_recherche_Click);
            // 
            // f_debiteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 766);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.l_archive);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.p_archive);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gv_client);
            this.Controls.Add(this.p_button);
            this.Controls.Add(this.p_affiche);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_debiteur";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des Clients";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_debiteur_FormClosing);
            this.Load += new System.EventHandler(this.f_debiteur_Load);
            this.p_affiche.ResumeLayout(false);
            this.p_affiche.PerformLayout();
            this.p_button.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_client)).EndInit();
            this.p_archive.ResumeLayout(false);
            this.p_archive.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel p_affiche;
        private System.Windows.Forms.Panel p_button;
        private System.Windows.Forms.Button bt_modif;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bt_annul;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.Button bt_suppr;
        private System.Windows.Forms.Button bt_ajout;
        private System.Windows.Forms.DataGridView gv_client;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox refclient;
        public MySql.Data.MySqlClient.MySqlCommand comrealvista;
        private System.Windows.Forms.Label label12;
        public MySql.Data.MySqlClient.MySqlCommand comrealvistamod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel p_archive;
        private System.Windows.Forms.TextBox prenom_1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox language_1;
        private System.Windows.Forms.TextBox co_1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox adresse2_1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox refarchive_1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox fax_1;
        private System.Windows.Forms.TextBox telpro_1;
        private System.Windows.Forms.TextBox telmob_1;
        private System.Windows.Forms.TextBox email_1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox adresse1_1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox raisonsociale_1;
        private System.Windows.Forms.TextBox nom_1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ListBox l_archive;
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
        private System.Windows.Forms.TextBox ville_1;
        private System.Windows.Forms.TextBox npa_1;
        private System.Windows.Forms.TextBox politesse_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_toutafficher;
        private System.Windows.Forms.Button bt_fermer;
        private System.Windows.Forms.Button bt_ajoutfact;
        public System.Windows.Forms.TextBox raisonsociale;
        public System.Windows.Forms.TextBox nom;
        public System.Windows.Forms.TextBox adresse1;
        public System.Windows.Forms.ComboBox politesse;
        public System.Windows.Forms.TextBox fax;
        public System.Windows.Forms.TextBox telpro;
        public System.Windows.Forms.TextBox telmob;
        public System.Windows.Forms.TextBox email;
        public WindowsFormsControlLibrary1.ComboMi ville;
        public WindowsFormsControlLibrary1.ComboMi npa;
        public System.Windows.Forms.TextBox adresse2;
        public System.Windows.Forms.TextBox co;
        public System.Windows.Forms.TextBox language;
        public System.Windows.Forms.TextBox prenom;
        public System.Windows.Forms.Button bt_recherche;
    }
}

