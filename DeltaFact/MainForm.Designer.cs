
namespace DeltaFact
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgRessB = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_facture = new System.Windows.Forms.Button();
            this.bt_debiteur = new System.Windows.Forms.Button();
            this.bt_client = new System.Windows.Forms.Button();
            this.bt_marchandises = new System.Windows.Forms.Button();
            this.Menu1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionclient = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionmarchandises = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.nPAVilleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.utilitaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importationFactureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importationPaiementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBar1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbentreprise = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbentreprisesource = new System.Windows.Forms.ComboBox();
            this.gvins = new System.Windows.Forms.DataGridView();
            this.rtB = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edUser = new System.Windows.Forms.TextBox();
            this.edMdp = new System.Windows.Forms.MaskedTextBox();
            this.DeltaCon = new MySql.Data.MySqlClient.MySqlConnection();
            this.DeltaSQLCon = new MySql.Data.MySqlClient.MySqlCommand();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.DeltaSQLTmp = new MySql.Data.MySqlClient.MySqlCommand();
            this.deltaConTmp2 = new MySql.Data.MySqlClient.MySqlConnection();
            this.DeltaConTmp1 = new MySql.Data.MySqlClient.MySqlConnection();
            this.deltaConMod = new MySql.Data.MySqlClient.MySqlConnection();
            this.FileDg = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Menu1.SuspendLayout();
            this.ToolBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvins)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgRessB});
            this.statusStrip.Location = new System.Drawing.Point(0, 429);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(655, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(640, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "État";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusLabel.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // ProgRessB
            // 
            this.ProgRessB.Name = "ProgRessB";
            this.ProgRessB.Size = new System.Drawing.Size(100, 16);
            this.ProgRessB.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgRessB.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bt_facture);
            this.panel1.Controls.Add(this.bt_debiteur);
            this.panel1.Controls.Add(this.bt_client);
            this.panel1.Controls.Add(this.bt_marchandises);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(-2, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 377);
            this.panel1.TabIndex = 1;
            // 
            // bt_facture
            // 
            this.bt_facture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bt_facture.Location = new System.Drawing.Point(25, 241);
            this.bt_facture.Name = "bt_facture";
            this.bt_facture.Size = new System.Drawing.Size(130, 25);
            this.bt_facture.TabIndex = 3;
            this.bt_facture.Text = "Gestion Facturation";
            this.bt_facture.UseVisualStyleBackColor = true;
            this.bt_facture.Click += new System.EventHandler(this.bt_facture_Click);
            // 
            // bt_debiteur
            // 
            this.bt_debiteur.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bt_debiteur.Location = new System.Drawing.Point(25, 152);
            this.bt_debiteur.Name = "bt_debiteur";
            this.bt_debiteur.Size = new System.Drawing.Size(130, 25);
            this.bt_debiteur.TabIndex = 1;
            this.bt_debiteur.Text = "Gestion Clients";
            this.bt_debiteur.UseVisualStyleBackColor = true;
            this.bt_debiteur.Click += new System.EventHandler(this.bt_debiteur_Click);
            // 
            // bt_client
            // 
            this.bt_client.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bt_client.Location = new System.Drawing.Point(25, 110);
            this.bt_client.Name = "bt_client";
            this.bt_client.Size = new System.Drawing.Size(130, 25);
            this.bt_client.TabIndex = 0;
            this.bt_client.Text = "Gestion Entreprises";
            this.bt_client.UseVisualStyleBackColor = true;
            this.bt_client.Click += new System.EventHandler(this.bt_client_Click);
            // 
            // bt_marchandises
            // 
            this.bt_marchandises.Location = new System.Drawing.Point(25, 190);
            this.bt_marchandises.Name = "bt_marchandises";
            this.bt_marchandises.Size = new System.Drawing.Size(130, 25);
            this.bt_marchandises.TabIndex = 2;
            this.bt_marchandises.Text = "Gestion Marchandises";
            this.bt_marchandises.UseVisualStyleBackColor = true;
            this.bt_marchandises.Click += new System.EventHandler(this.bt_marchandises_Click);
            // 
            // Menu1
            // 
            this.Menu1.Enabled = false;
            this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.gestionToolStripMenuItem,
            this.utilitaireToolStripMenuItem});
            this.Menu1.Location = new System.Drawing.Point(0, 0);
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(655, 24);
            this.Menu1.TabIndex = 3;
            this.Menu1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.déconnexionToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // déconnexionToolStripMenuItem
            // 
            this.déconnexionToolStripMenuItem.Name = "déconnexionToolStripMenuItem";
            this.déconnexionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.déconnexionToolStripMenuItem.Text = "Déconnexion";
            this.déconnexionToolStripMenuItem.Click += new System.EventHandler(this.déconnexionToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionclient,
            this.gestionmarchandises,
            this.toolStripSeparator10,
            this.nPAVilleToolStripMenuItem,
            this.toolStripMenuItem6});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // gestionclient
            // 
            this.gestionclient.Name = "gestionclient";
            this.gestionclient.Size = new System.Drawing.Size(190, 22);
            this.gestionclient.Text = "Gestion Clients";
            this.gestionclient.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // gestionmarchandises
            // 
            this.gestionmarchandises.Name = "gestionmarchandises";
            this.gestionmarchandises.Size = new System.Drawing.Size(190, 22);
            this.gestionmarchandises.Text = "Gestion Marchandises";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(187, 6);
            // 
            // nPAVilleToolStripMenuItem
            // 
            this.nPAVilleToolStripMenuItem.Name = "nPAVilleToolStripMenuItem";
            this.nPAVilleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nPAVilleToolStripMenuItem.Text = "NPA/Ville";
            this.nPAVilleToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(187, 6);
            // 
            // utilitaireToolStripMenuItem
            // 
            this.utilitaireToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importationFactureToolStripMenuItem,
            this.importationPaiementToolStripMenuItem});
            this.utilitaireToolStripMenuItem.Name = "utilitaireToolStripMenuItem";
            this.utilitaireToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.utilitaireToolStripMenuItem.Text = "Utilitaire";
            // 
            // importationFactureToolStripMenuItem
            // 
            this.importationFactureToolStripMenuItem.Name = "importationFactureToolStripMenuItem";
            this.importationFactureToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importationFactureToolStripMenuItem.Text = "Importation Facture";
            this.importationFactureToolStripMenuItem.Click += new System.EventHandler(this.importationFactureToolStripMenuItem_Click);
            // 
            // importationPaiementToolStripMenuItem
            // 
            this.importationPaiementToolStripMenuItem.Name = "importationPaiementToolStripMenuItem";
            this.importationPaiementToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importationPaiementToolStripMenuItem.Text = "Importation paiement";
            this.importationPaiementToolStripMenuItem.Click += new System.EventHandler(this.importationPaiementToolStripMenuItem_Click);
            // 
            // ToolBar1
            // 
            this.ToolBar1.Enabled = false;
            this.ToolBar1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.ToolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbentreprise,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.toolStripButton14});
            this.ToolBar1.Location = new System.Drawing.Point(0, 24);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.Size = new System.Drawing.Size(655, 32);
            this.ToolBar1.TabIndex = 2;
            this.ToolBar1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 29);
            this.toolStripLabel1.Text = "Entreprise à gérer :";
            // 
            // cmbentreprise
            // 
            this.cmbentreprise.AutoSize = false;
            this.cmbentreprise.Name = "cmbentreprise";
            this.cmbentreprise.Size = new System.Drawing.Size(200, 23);
            this.cmbentreprise.SelectedIndexChanged += new System.EventHandler(this.cmbentreprise_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::DeltaFact.Properties.Resources.Users;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Gestion des Employés";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = global::DeltaFact.Properties.Resources.Exit;
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton14.Text = "toolStripButton14";
            this.toolStripButton14.ToolTipText = "Quitter DeltaFact";
            this.toolStripButton14.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::DeltaFact.Properties.Resources.Image1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.cmbentreprisesource);
            this.panel2.Controls.Add(this.gvins);
            this.panel2.Controls.Add(this.rtB);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(178, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 373);
            this.panel2.TabIndex = 0;
            // 
            // cmbentreprisesource
            // 
            this.cmbentreprisesource.DisplayMember = "entreprise";
            this.cmbentreprisesource.FormattingEnabled = true;
            this.cmbentreprisesource.Location = new System.Drawing.Point(258, 19);
            this.cmbentreprisesource.Name = "cmbentreprisesource";
            this.cmbentreprisesource.Size = new System.Drawing.Size(121, 21);
            this.cmbentreprisesource.TabIndex = 73;
            this.cmbentreprisesource.ValueMember = "identreprise";
            this.cmbentreprisesource.Visible = false;
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
            this.gvins.Location = new System.Drawing.Point(3, 222);
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
            this.gvins.Size = new System.Drawing.Size(462, 143);
            this.gvins.TabIndex = 72;
            this.gvins.Visible = false;
            // 
            // rtB
            // 
            this.rtB.Location = new System.Drawing.Point(119, 269);
            this.rtB.Name = "rtB";
            this.rtB.Size = new System.Drawing.Size(310, 96);
            this.rtB.TabIndex = 1;
            this.rtB.Text = "";
            this.rtB.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.edUser);
            this.panel3.Controls.Add(this.edMdp);
            this.panel3.ForeColor = System.Drawing.Color.Ivory;
            this.panel3.Location = new System.Drawing.Point(88, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 132);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DeltaFact.Properties.Resources.Users;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 30);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.ImageIndex = 0;
            this.button5.ImageList = this.imageList1;
            this.button5.Location = new System.Drawing.Point(254, 85);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 22);
            this.button5.TabIndex = 3;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "onebit2 (33).ico");
            this.imageList1.Images.SetKeyName(1, "onebit2 (34).ico");
            this.imageList1.Images.SetKeyName(2, "refresh_forward.ico");
            this.imageList1.Images.SetKeyName(3, "onebit2 (19).ico");
            this.imageList1.Images.SetKeyName(4, "onebit2 (30).ico");
            this.imageList1.Images.SetKeyName(5, "menu.ico");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(14, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mot de passe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Utilisateur";
            // 
            // edUser
            // 
            this.edUser.Location = new System.Drawing.Point(93, 52);
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(152, 20);
            this.edUser.TabIndex = 1;
            this.edUser.Enter += new System.EventHandler(this.edUser_Enter);
            this.edUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edUser_KeyPress);
            // 
            // edMdp
            // 
            this.edMdp.Location = new System.Drawing.Point(93, 85);
            this.edMdp.Name = "edMdp";
            this.edMdp.PasswordChar = '*';
            this.edMdp.Size = new System.Drawing.Size(152, 20);
            this.edMdp.TabIndex = 2;
            this.edMdp.UseSystemPasswordChar = true;
            this.edMdp.Enter += new System.EventHandler(this.edMdp_Enter);
            this.edMdp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edMdp_KeyPress);
            // 
            // DeltaCon
            // 
            this.DeltaCon.InfoMessage += new MySql.Data.MySqlClient.MySqlInfoMessageEventHandler(this.DeltaCon_InfoMessage);
            this.DeltaCon.StateChange += new System.Data.StateChangeEventHandler(this.DeltaCon_StateChange);
            // 
            // DeltaSQLCon
            // 
            this.DeltaSQLCon.CacheAge = 60;
            this.DeltaSQLCon.CommandTimeout = 600;
            this.DeltaSQLCon.Connection = this.DeltaCon;
            this.DeltaSQLCon.EnableCaching = false;
            this.DeltaSQLCon.Transaction = null;
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // DeltaSQLTmp
            // 
            this.DeltaSQLTmp.CacheAge = 0;
            this.DeltaSQLTmp.CommandTimeout = 600;
            this.DeltaSQLTmp.Connection = null;
            this.DeltaSQLTmp.EnableCaching = false;
            this.DeltaSQLTmp.Transaction = null;
            // 
            // deltaConTmp2
            // 
            this.deltaConTmp2.StateChange += new System.Data.StateChangeEventHandler(this.deltaConTmp2_StateChange);
            // 
            // DeltaConTmp1
            // 
            this.DeltaConTmp1.StateChange += new System.Data.StateChangeEventHandler(this.DeltaConTmp1_StateChange);
            // 
            // deltaConMod
            // 
            this.deltaConMod.StateChange += new System.Data.StateChangeEventHandler(this.deltaConMod_StateChange);
            // 
            // FileDg
            // 
            this.FileDg.Filter = "Fichier Abacus CSV|*.csv|Fichiers Excel XLS|*.xls|Fichier Excel XLSX|*.xlsx";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(655, 451);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ToolBar1);
            this.Controls.Add(this.Menu1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeltaFact v.0.1";
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Menu1.ResumeLayout(false);
            this.Menu1.PerformLayout();
            this.ToolBar1.ResumeLayout(false);
            this.ToolBar1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvins)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_client;
        private System.Windows.Forms.Button bt_marchandises;
        private System.Windows.Forms.MenuStrip Menu1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem déconnexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitaireToolStripMenuItem;
        private System.Windows.Forms.ToolStrip ToolBar1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem nPAVilleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edUser;
        public System.Windows.Forms.MaskedTextBox edMdp;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ToolStripProgressBar ProgRessB;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        public MySql.Data.MySqlClient.MySqlConnection DeltaCon;
        public MySql.Data.MySqlClient.MySqlCommand DeltaSQLCon;
        public MySql.Data.MySqlClient.MySqlCommand DeltaSQLTmp;
        public MySql.Data.MySqlClient.MySqlConnection deltaConTmp2;
        public MySql.Data.MySqlClient.MySqlConnection DeltaConTmp1;
        private System.Windows.Forms.ToolStripMenuItem gestionclient;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        public MySql.Data.MySqlClient.MySqlConnection deltaConMod;
        private System.Windows.Forms.RichTextBox rtB;
        private System.Windows.Forms.OpenFileDialog FileDg;
        public System.Windows.Forms.DataGridView gvins;
        private System.Windows.Forms.ToolStripMenuItem gestionmarchandises;
        private System.Windows.Forms.Button bt_debiteur;
        private System.Windows.Forms.Button bt_facture;
        private System.Windows.Forms.ToolStripComboBox cmbentreprise;
        private System.Windows.Forms.ComboBox cmbentreprisesource;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem importationFactureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importationPaiementToolStripMenuItem;
    }
}



