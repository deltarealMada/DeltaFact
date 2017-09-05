namespace DeltaFact
{
    partial class f_paiement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_paiement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.comrealvistamod = new MySql.Data.MySqlClient.MySqlCommand();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comrech = new MySql.Data.MySqlClient.MySqlCommand();
            this.ck_banque = new System.Windows.Forms.RadioButton();
            this.ck_poste = new System.Windows.Forms.RadioButton();
            this.typepaiement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datepaiement = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.datesaisie = new System.Windows.Forms.DateTimePicker();
            this.totfacture = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.solde = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mttpaye = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fraisenvoi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fraisassurance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fraisrappel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fraisaffacturage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.excedent = new System.Windows.Forms.TextBox();
            this.bt_annul = new System.Windows.Forms.Button();
            this.bt_valid = new System.Windows.Forms.Button();
            this.p_solde = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.reffacture = new System.Windows.Forms.TextBox();
            this.gv_import = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.FileDg = new System.Windows.Forms.OpenFileDialog();
            this.bt_valider = new System.Windows.Forms.Button();
            this.p_frais = new System.Windows.Forms.Panel();
            this.gv_listepaiement = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.refpaiement = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.coordpayeur = new System.Windows.Forms.TextBox();
            this.p_payeur = new System.Windows.Forms.Panel();
            this.bt_psuppr = new System.Windows.Forms.Button();
            this.bt_pmodif = new System.Windows.Forms.Button();
            this.bt_impsuppr = new System.Windows.Forms.Button();
            this.bt_impverif = new System.Windows.Forms.Button();
            this.typetransfert = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grp_ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp_ccymtt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp_mttot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_reffact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_numfact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_mttpaye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_moyenpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_deb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_debadr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_debcompte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.comptepayeur = new System.Windows.Forms.TextBox();
            this.g_datesaisie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_datepaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_postebanque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_typepaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_numfacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_montantpaye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idclient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_refpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_coordpayeur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_comptepaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_typetransfert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_solde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_import)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.p_frais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_listepaiement)).BeginInit();
            this.p_payeur.SuspendLayout();
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
            // 
            // comrech
            // 
            this.comrech.CacheAge = 60;
            this.comrech.Connection = null;
            this.comrech.EnableCaching = false;
            this.comrech.Transaction = null;
            // 
            // ck_banque
            // 
            this.ck_banque.AutoSize = true;
            this.ck_banque.Location = new System.Drawing.Point(390, 107);
            this.ck_banque.Name = "ck_banque";
            this.ck_banque.Size = new System.Drawing.Size(61, 17);
            this.ck_banque.TabIndex = 4;
            this.ck_banque.TabStop = true;
            this.ck_banque.Text = "banque";
            this.ck_banque.UseVisualStyleBackColor = true;
            // 
            // ck_poste
            // 
            this.ck_poste.AutoSize = true;
            this.ck_poste.Location = new System.Drawing.Point(340, 107);
            this.ck_poste.Name = "ck_poste";
            this.ck_poste.Size = new System.Drawing.Size(51, 17);
            this.ck_poste.TabIndex = 3;
            this.ck_poste.TabStop = true;
            this.ck_poste.Text = "poste";
            this.ck_poste.UseVisualStyleBackColor = true;
            // 
            // typepaiement
            // 
            this.typepaiement.AccessibleName = "Type Paiement";
            this.typepaiement.BackColor = System.Drawing.Color.AntiqueWhite;
            this.typepaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typepaiement.FormattingEnabled = true;
            this.typepaiement.IntegralHeight = false;
            this.typepaiement.Items.AddRange(new object[] {
            "Entreprise",
            "Deltareal"});
            this.typepaiement.Location = new System.Drawing.Point(219, 104);
            this.typepaiement.Name = "typepaiement";
            this.typepaiement.Size = new System.Drawing.Size(106, 21);
            this.typepaiement.TabIndex = 2;
            this.typepaiement.Tag = "12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(216, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "type paiement";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(119, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "date Paiement";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datepaiement
            // 
            this.datepaiement.CalendarMonthBackground = System.Drawing.Color.AntiqueWhite;
            this.datepaiement.CalendarTitleBackColor = System.Drawing.Color.AntiqueWhite;
            this.datepaiement.CustomFormat = "dd.MM.yyyy";
            this.datepaiement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepaiement.Location = new System.Drawing.Point(122, 105);
            this.datepaiement.Name = "datepaiement";
            this.datepaiement.Size = new System.Drawing.Size(91, 20);
            this.datepaiement.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(22, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "date Saisie";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datesaisie
            // 
            this.datesaisie.CalendarMonthBackground = System.Drawing.Color.AntiqueWhite;
            this.datesaisie.CalendarTitleBackColor = System.Drawing.Color.AntiqueWhite;
            this.datesaisie.CustomFormat = "dd.MM.yyyy";
            this.datesaisie.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datesaisie.Location = new System.Drawing.Point(25, 105);
            this.datesaisie.Name = "datesaisie";
            this.datesaisie.Size = new System.Drawing.Size(91, 20);
            this.datesaisie.TabIndex = 0;
            // 
            // totfacture
            // 
            this.totfacture.AccessibleName = "Montant à payer";
            this.totfacture.BackColor = System.Drawing.Color.AntiqueWhite;
            this.totfacture.Enabled = false;
            this.totfacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totfacture.Location = new System.Drawing.Point(101, 16);
            this.totfacture.Name = "totfacture";
            this.totfacture.Size = new System.Drawing.Size(90, 20);
            this.totfacture.TabIndex = 4;
            this.totfacture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(195, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "ancien solde";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solde
            // 
            this.solde.BackColor = System.Drawing.Color.AntiqueWhite;
            this.solde.Enabled = false;
            this.solde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solde.Location = new System.Drawing.Point(198, 16);
            this.solde.Name = "solde";
            this.solde.Size = new System.Drawing.Size(106, 20);
            this.solde.TabIndex = 5;
            this.solde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "mtt payé";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mttpaye
            // 
            this.mttpaye.BackColor = System.Drawing.Color.AntiqueWhite;
            this.mttpaye.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mttpaye.Location = new System.Drawing.Point(5, 16);
            this.mttpaye.Name = "mttpaye";
            this.mttpaye.Size = new System.Drawing.Size(106, 20);
            this.mttpaye.TabIndex = 0;
            this.mttpaye.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(116, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "frais d\'envoi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fraisenvoi
            // 
            this.fraisenvoi.BackColor = System.Drawing.Color.AntiqueWhite;
            this.fraisenvoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraisenvoi.Location = new System.Drawing.Point(119, 16);
            this.fraisenvoi.Name = "fraisenvoi";
            this.fraisenvoi.Size = new System.Drawing.Size(90, 20);
            this.fraisenvoi.TabIndex = 1;
            this.fraisenvoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(98, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "total facture";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(213, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "frais assurance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fraisassurance
            // 
            this.fraisassurance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.fraisassurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraisassurance.Location = new System.Drawing.Point(216, 16);
            this.fraisassurance.Name = "fraisassurance";
            this.fraisassurance.Size = new System.Drawing.Size(90, 20);
            this.fraisassurance.TabIndex = 2;
            this.fraisassurance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(311, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 71;
            this.label9.Text = "frais rappel";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fraisrappel
            // 
            this.fraisrappel.BackColor = System.Drawing.Color.AntiqueWhite;
            this.fraisrappel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraisrappel.Location = new System.Drawing.Point(314, 16);
            this.fraisrappel.Name = "fraisrappel";
            this.fraisrappel.Size = new System.Drawing.Size(90, 20);
            this.fraisrappel.TabIndex = 3;
            this.fraisrappel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(409, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "frais affacturage";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fraisaffacturage
            // 
            this.fraisaffacturage.BackColor = System.Drawing.Color.AntiqueWhite;
            this.fraisaffacturage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraisaffacturage.Location = new System.Drawing.Point(412, 16);
            this.fraisaffacturage.Name = "fraisaffacturage";
            this.fraisaffacturage.Size = new System.Drawing.Size(90, 20);
            this.fraisaffacturage.TabIndex = 4;
            this.fraisaffacturage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(506, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 75;
            this.label11.Text = "excédent";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // excedent
            // 
            this.excedent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.excedent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excedent.Location = new System.Drawing.Point(509, 16);
            this.excedent.Name = "excedent";
            this.excedent.Size = new System.Drawing.Size(81, 20);
            this.excedent.TabIndex = 5;
            this.excedent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bt_annul
            // 
            this.bt_annul.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_annul.ImageIndex = 9;
            this.bt_annul.ImageList = this.imageList1;
            this.bt_annul.Location = new System.Drawing.Point(1044, 576);
            this.bt_annul.Name = "bt_annul";
            this.bt_annul.Size = new System.Drawing.Size(87, 26);
            this.bt_annul.TabIndex = 15;
            this.bt_annul.Tag = "12";
            this.bt_annul.Text = " A&nnuler";
            this.bt_annul.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_annul.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_annul.UseVisualStyleBackColor = true;
            // 
            // bt_valid
            // 
            this.bt_valid.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_valid.ImageIndex = 7;
            this.bt_valid.ImageList = this.imageList1;
            this.bt_valid.Location = new System.Drawing.Point(1044, 152);
            this.bt_valid.Name = "bt_valid";
            this.bt_valid.Size = new System.Drawing.Size(87, 26);
            this.bt_valid.TabIndex = 8;
            this.bt_valid.Tag = "12";
            this.bt_valid.Text = " &Valider";
            this.bt_valid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_valid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_valid.UseVisualStyleBackColor = true;
            this.bt_valid.Visible = false;
            this.bt_valid.Click += new System.EventHandler(this.bt_valid_Click);
            // 
            // p_solde
            // 
            this.p_solde.Controls.Add(this.label12);
            this.p_solde.Controls.Add(this.reffacture);
            this.p_solde.Controls.Add(this.label7);
            this.p_solde.Controls.Add(this.solde);
            this.p_solde.Controls.Add(this.label5);
            this.p_solde.Controls.Add(this.totfacture);
            this.p_solde.Location = new System.Drawing.Point(21, 140);
            this.p_solde.Name = "p_solde";
            this.p_solde.Size = new System.Drawing.Size(309, 43);
            this.p_solde.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "n0 Facture";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // reffacture
            // 
            this.reffacture.AccessibleName = "Montant à payer";
            this.reffacture.BackColor = System.Drawing.Color.AntiqueWhite;
            this.reffacture.Enabled = false;
            this.reffacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reffacture.Location = new System.Drawing.Point(5, 16);
            this.reffacture.Name = "reffacture";
            this.reffacture.Size = new System.Drawing.Size(90, 20);
            this.reffacture.TabIndex = 3;
            // 
            // gv_import
            // 
            this.gv_import.AllowUserToAddRows = false;
            this.gv_import.AllowUserToDeleteRows = false;
            this.gv_import.AllowUserToResizeRows = false;
            this.gv_import.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_import.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grp_ref,
            this.grp_date,
            this.grp_ccymtt,
            this.grp_mttot,
            this.p_ref,
            this.p_reffact,
            this.p_numfact,
            this.p_mttpaye,
            this.p_client,
            this.p_moyenpaiement,
            this.p_deb,
            this.p_debadr,
            this.p_debcompte});
            this.gv_import.Location = new System.Drawing.Point(21, 244);
            this.gv_import.Name = "gv_import";
            this.gv_import.RowHeadersVisible = false;
            this.gv_import.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_import.Size = new System.Drawing.Size(1110, 326);
            this.gv_import.TabIndex = 10;
            this.gv_import.Visible = false;
            this.gv_import.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_import_CellEndEdit);
            this.gv_import.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_import_RowEnter);
            // 
            // button1
            // 
            this.button1.ImageIndex = 13;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(27, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 26);
            this.button1.TabIndex = 80;
            this.button1.Tag = "12";
            this.button1.Text = "Charger fichier";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 506);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 20);
            this.textBox1.TabIndex = 81;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(249, 508);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(267, 20);
            this.textBox2.TabIndex = 82;
            this.textBox2.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(653, 520);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(121, 108);
            this.listBox1.TabIndex = 83;
            this.listBox1.Visible = false;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(526, 520);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(121, 108);
            this.listBox2.TabIndex = 84;
            this.listBox2.Visible = false;
            // 
            // FileDg
            // 
            this.FileDg.Filter = "Fichier de paiement|*.xml";
            // 
            // bt_valider
            // 
            this.bt_valider.Enabled = false;
            this.bt_valider.ImageIndex = 7;
            this.bt_valider.ImageList = this.imageList1;
            this.bt_valider.Location = new System.Drawing.Point(892, 576);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(132, 26);
            this.bt_valider.TabIndex = 12;
            this.bt_valider.Tag = "12";
            this.bt_valider.Text = "Valider les paiements";
            this.bt_valider.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_valider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Visible = false;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // p_frais
            // 
            this.p_frais.Controls.Add(this.label3);
            this.p_frais.Controls.Add(this.fraisenvoi);
            this.p_frais.Controls.Add(this.mttpaye);
            this.p_frais.Controls.Add(this.label4);
            this.p_frais.Controls.Add(this.fraisassurance);
            this.p_frais.Controls.Add(this.label6);
            this.p_frais.Controls.Add(this.fraisrappel);
            this.p_frais.Controls.Add(this.label9);
            this.p_frais.Controls.Add(this.fraisaffacturage);
            this.p_frais.Controls.Add(this.label10);
            this.p_frais.Controls.Add(this.excedent);
            this.p_frais.Controls.Add(this.label11);
            this.p_frais.Location = new System.Drawing.Point(334, 140);
            this.p_frais.Name = "p_frais";
            this.p_frais.Size = new System.Drawing.Size(695, 51);
            this.p_frais.TabIndex = 7;
            // 
            // gv_listepaiement
            // 
            this.gv_listepaiement.AllowUserToAddRows = false;
            this.gv_listepaiement.AllowUserToDeleteRows = false;
            this.gv_listepaiement.AllowUserToResizeRows = false;
            this.gv_listepaiement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_listepaiement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_datesaisie,
            this.g_datepaiement,
            this.g_postebanque,
            this.g_typepaiement,
            this.g_numfacture,
            this.g_montantpaye,
            this.g_idclient,
            this.g_refpaiement,
            this.g_coordpayeur,
            this.g_comptepaiement,
            this.g_idpaiement,
            this.g_typetransfert});
            this.gv_listepaiement.Location = new System.Drawing.Point(21, 189);
            this.gv_listepaiement.Name = "gv_listepaiement";
            this.gv_listepaiement.ReadOnly = true;
            this.gv_listepaiement.RowHeadersVisible = false;
            this.gv_listepaiement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gv_listepaiement.Size = new System.Drawing.Size(1110, 240);
            this.gv_listepaiement.TabIndex = 11;
            this.gv_listepaiement.Visible = false;
            this.gv_listepaiement.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_listepaiement_RowEnter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(0, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 89;
            this.label13.Text = "réf. paiement";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // refpaiement
            // 
            this.refpaiement.BackColor = System.Drawing.Color.AntiqueWhite;
            this.refpaiement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refpaiement.Location = new System.Drawing.Point(3, 17);
            this.refpaiement.Name = "refpaiement";
            this.refpaiement.Size = new System.Drawing.Size(90, 20);
            this.refpaiement.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(98, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 13);
            this.label14.TabIndex = 91;
            this.label14.Text = "coordonnées de paiement";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // coordpayeur
            // 
            this.coordpayeur.BackColor = System.Drawing.Color.AntiqueWhite;
            this.coordpayeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordpayeur.Location = new System.Drawing.Point(101, 17);
            this.coordpayeur.Name = "coordpayeur";
            this.coordpayeur.Size = new System.Drawing.Size(188, 20);
            this.coordpayeur.TabIndex = 6;
            // 
            // p_payeur
            // 
            this.p_payeur.Controls.Add(this.label16);
            this.p_payeur.Controls.Add(this.comptepayeur);
            this.p_payeur.Controls.Add(this.label14);
            this.p_payeur.Controls.Add(this.coordpayeur);
            this.p_payeur.Controls.Add(this.label13);
            this.p_payeur.Controls.Add(this.refpaiement);
            this.p_payeur.Location = new System.Drawing.Point(548, 87);
            this.p_payeur.Name = "p_payeur";
            this.p_payeur.Size = new System.Drawing.Size(583, 37);
            this.p_payeur.TabIndex = 6;
            this.p_payeur.Visible = false;
            // 
            // bt_psuppr
            // 
            this.bt_psuppr.Location = new System.Drawing.Point(122, 435);
            this.bt_psuppr.Name = "bt_psuppr";
            this.bt_psuppr.Size = new System.Drawing.Size(89, 23);
            this.bt_psuppr.TabIndex = 88;
            this.bt_psuppr.Text = "supprimer";
            this.bt_psuppr.UseVisualStyleBackColor = true;
            this.bt_psuppr.Visible = false;
            this.bt_psuppr.Click += new System.EventHandler(this.bt_psuppr_Click);
            // 
            // bt_pmodif
            // 
            this.bt_pmodif.Location = new System.Drawing.Point(21, 435);
            this.bt_pmodif.Name = "bt_pmodif";
            this.bt_pmodif.Size = new System.Drawing.Size(89, 23);
            this.bt_pmodif.TabIndex = 89;
            this.bt_pmodif.Text = "modifier";
            this.bt_pmodif.UseVisualStyleBackColor = true;
            this.bt_pmodif.Visible = false;
            this.bt_pmodif.Click += new System.EventHandler(this.bt_pmodif_Click);
            // 
            // bt_impsuppr
            // 
            this.bt_impsuppr.Location = new System.Drawing.Point(21, 576);
            this.bt_impsuppr.Name = "bt_impsuppr";
            this.bt_impsuppr.Size = new System.Drawing.Size(89, 23);
            this.bt_impsuppr.TabIndex = 13;
            this.bt_impsuppr.Text = "supprimer ligne";
            this.bt_impsuppr.UseVisualStyleBackColor = true;
            this.bt_impsuppr.Visible = false;
            this.bt_impsuppr.Click += new System.EventHandler(this.bt_impsuppr_Click);
            // 
            // bt_impverif
            // 
            this.bt_impverif.Location = new System.Drawing.Point(122, 576);
            this.bt_impverif.Name = "bt_impverif";
            this.bt_impverif.Size = new System.Drawing.Size(91, 23);
            this.bt_impverif.TabIndex = 14;
            this.bt_impverif.Text = "vérifier données";
            this.bt_impverif.UseVisualStyleBackColor = true;
            this.bt_impverif.Visible = false;
            this.bt_impverif.Click += new System.EventHandler(this.bt_impverif_Click);
            // 
            // typetransfert
            // 
            this.typetransfert.AccessibleName = "Type Paiement";
            this.typetransfert.BackColor = System.Drawing.Color.AntiqueWhite;
            this.typetransfert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typetransfert.FormattingEnabled = true;
            this.typetransfert.IntegralHeight = false;
            this.typetransfert.Items.AddRange(new object[] {
            "tft banque",
            "postes différenciés"});
            this.typetransfert.Location = new System.Drawing.Point(454, 104);
            this.typetransfert.Name = "typetransfert";
            this.typetransfert.Size = new System.Drawing.Size(90, 21);
            this.typetransfert.TabIndex = 5;
            this.typetransfert.Tag = "12";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(451, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 93;
            this.label15.Text = "moyen paiement";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grp_ref
            // 
            this.grp_ref.HeaderText = "Réf Groupe paiement";
            this.grp_ref.Name = "grp_ref";
            // 
            // grp_date
            // 
            this.grp_date.HeaderText = "Date";
            this.grp_date.Name = "grp_date";
            this.grp_date.Width = 80;
            // 
            // grp_ccymtt
            // 
            this.grp_ccymtt.HeaderText = "Monnaie";
            this.grp_ccymtt.Name = "grp_ccymtt";
            this.grp_ccymtt.Width = 50;
            // 
            // grp_mttot
            // 
            this.grp_mttot.HeaderText = "Mtt Tot. Groupe";
            this.grp_mttot.Name = "grp_mttot";
            this.grp_mttot.Width = 70;
            // 
            // p_ref
            // 
            this.p_ref.HeaderText = "réf. Paiement";
            this.p_ref.Name = "p_ref";
            this.p_ref.Width = 110;
            // 
            // p_reffact
            // 
            this.p_reffact.HeaderText = "réf. Facture";
            this.p_reffact.Name = "p_reffact";
            this.p_reffact.Visible = false;
            // 
            // p_numfact
            // 
            this.p_numfact.HeaderText = "n0 Facture";
            this.p_numfact.Name = "p_numfact";
            // 
            // p_mttpaye
            // 
            this.p_mttpaye.HeaderText = "Montant Payé";
            this.p_mttpaye.Name = "p_mttpaye";
            this.p_mttpaye.Width = 70;
            // 
            // p_client
            // 
            this.p_client.HeaderText = "n0 Client";
            this.p_client.Name = "p_client";
            this.p_client.Width = 60;
            // 
            // p_moyenpaiement
            // 
            this.p_moyenpaiement.HeaderText = "moyen paiement";
            this.p_moyenpaiement.Name = "p_moyenpaiement";
            this.p_moyenpaiement.Width = 70;
            // 
            // p_deb
            // 
            this.p_deb.HeaderText = "Payeur";
            this.p_deb.Name = "p_deb";
            this.p_deb.Width = 130;
            // 
            // p_debadr
            // 
            this.p_debadr.HeaderText = "Adr. Payeur";
            this.p_debadr.Name = "p_debadr";
            this.p_debadr.Width = 120;
            // 
            // p_debcompte
            // 
            this.p_debcompte.HeaderText = "Compte Payeur";
            this.p_debcompte.Name = "p_debcompte";
            this.p_debcompte.Width = 130;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(293, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 93;
            this.label16.Text = "compte de paiement";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comptepayeur
            // 
            this.comptepayeur.BackColor = System.Drawing.Color.AntiqueWhite;
            this.comptepayeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comptepayeur.Location = new System.Drawing.Point(296, 17);
            this.comptepayeur.Name = "comptepayeur";
            this.comptepayeur.Size = new System.Drawing.Size(180, 20);
            this.comptepayeur.TabIndex = 92;
            // 
            // g_datesaisie
            // 
            this.g_datesaisie.HeaderText = "date saisie";
            this.g_datesaisie.Name = "g_datesaisie";
            this.g_datesaisie.ReadOnly = true;
            this.g_datesaisie.Width = 90;
            // 
            // g_datepaiement
            // 
            this.g_datepaiement.HeaderText = "date paiement";
            this.g_datepaiement.Name = "g_datepaiement";
            this.g_datepaiement.ReadOnly = true;
            this.g_datepaiement.Width = 90;
            // 
            // g_postebanque
            // 
            this.g_postebanque.HeaderText = "poste/banque";
            this.g_postebanque.Name = "g_postebanque";
            this.g_postebanque.ReadOnly = true;
            this.g_postebanque.Width = 75;
            // 
            // g_typepaiement
            // 
            this.g_typepaiement.HeaderText = "type paiement";
            this.g_typepaiement.Name = "g_typepaiement";
            this.g_typepaiement.ReadOnly = true;
            // 
            // g_numfacture
            // 
            this.g_numfacture.HeaderText = "n0 Facture";
            this.g_numfacture.Name = "g_numfacture";
            this.g_numfacture.ReadOnly = true;
            this.g_numfacture.Visible = false;
            // 
            // g_montantpaye
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.g_montantpaye.DefaultCellStyle = dataGridViewCellStyle1;
            this.g_montantpaye.HeaderText = "Montant Payé";
            this.g_montantpaye.Name = "g_montantpaye";
            this.g_montantpaye.ReadOnly = true;
            // 
            // g_idclient
            // 
            this.g_idclient.HeaderText = "n0 Client";
            this.g_idclient.Name = "g_idclient";
            this.g_idclient.ReadOnly = true;
            this.g_idclient.Visible = false;
            this.g_idclient.Width = 80;
            // 
            // g_refpaiement
            // 
            this.g_refpaiement.HeaderText = "réf. Paiement";
            this.g_refpaiement.Name = "g_refpaiement";
            this.g_refpaiement.ReadOnly = true;
            this.g_refpaiement.Width = 150;
            // 
            // g_coordpayeur
            // 
            this.g_coordpayeur.HeaderText = "coordonnées paiement";
            this.g_coordpayeur.Name = "g_coordpayeur";
            this.g_coordpayeur.ReadOnly = true;
            this.g_coordpayeur.Width = 300;
            // 
            // g_comptepaiement
            // 
            this.g_comptepaiement.HeaderText = "compte paiement";
            this.g_comptepaiement.Name = "g_comptepaiement";
            this.g_comptepaiement.ReadOnly = true;
            this.g_comptepaiement.Width = 185;
            // 
            // g_idpaiement
            // 
            this.g_idpaiement.HeaderText = "idpaiement";
            this.g_idpaiement.Name = "g_idpaiement";
            this.g_idpaiement.ReadOnly = true;
            this.g_idpaiement.Visible = false;
            // 
            // g_typetransfert
            // 
            this.g_typetransfert.HeaderText = "typetransfert";
            this.g_typetransfert.Name = "g_typetransfert";
            this.g_typetransfert.ReadOnly = true;
            this.g_typetransfert.Visible = false;
            // 
            // f_paiement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 619);
            this.Controls.Add(this.typetransfert);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.bt_impverif);
            this.Controls.Add(this.bt_impsuppr);
            this.Controls.Add(this.bt_pmodif);
            this.Controls.Add(this.bt_psuppr);
            this.Controls.Add(this.p_payeur);
            this.Controls.Add(this.gv_listepaiement);
            this.Controls.Add(this.p_frais);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gv_import);
            this.Controls.Add(this.p_solde);
            this.Controls.Add(this.bt_annul);
            this.Controls.Add(this.bt_valid);
            this.Controls.Add(this.ck_banque);
            this.Controls.Add(this.ck_poste);
            this.Controls.Add(this.typepaiement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datepaiement);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.datesaisie);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_paiement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeltaFact - Module de Paiement";
            this.Load += new System.EventHandler(this.f_paiement_Load);
            this.p_solde.ResumeLayout(false);
            this.p_solde.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_import)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.p_frais.ResumeLayout(false);
            this.p_frais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_listepaiement)).EndInit();
            this.p_payeur.ResumeLayout(false);
            this.p_payeur.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        public MySql.Data.MySqlClient.MySqlCommand comrealvistamod;
        private System.Windows.Forms.ImageList imageList1;
        public MySql.Data.MySqlClient.MySqlCommand comrech;
        private System.Windows.Forms.RadioButton ck_banque;
        private System.Windows.Forms.RadioButton ck_poste;
        public System.Windows.Forms.ComboBox typepaiement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker datepaiement;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datesaisie;
        public System.Windows.Forms.TextBox totfacture;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox solde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mttpaye;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fraisenvoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fraisassurance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox fraisrappel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fraisaffacturage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox excedent;
        public System.Windows.Forms.Button bt_annul;
        public System.Windows.Forms.Button bt_valid;
        private System.Windows.Forms.Panel p_solde;
        private System.Windows.Forms.DataGridView gv_import;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.OpenFileDialog FileDg;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox reffacture;
        public System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.Panel p_frais;
        private System.Windows.Forms.DataGridView gv_listepaiement;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox refpaiement;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox coordpayeur;
        private System.Windows.Forms.Panel p_payeur;
        private System.Windows.Forms.Button bt_psuppr;
        private System.Windows.Forms.Button bt_pmodif;
        private System.Windows.Forms.Button bt_impsuppr;
        private System.Windows.Forms.Button bt_impverif;
        public System.Windows.Forms.ComboBox typetransfert;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn grp_ref;
        private System.Windows.Forms.DataGridViewTextBoxColumn grp_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn grp_ccymtt;
        private System.Windows.Forms.DataGridViewTextBoxColumn grp_mttot;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_ref;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_reffact;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_numfact;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_mttpaye;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_client;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_moyenpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_deb;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_debadr;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_debcompte;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox comptepayeur;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_datesaisie;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_datepaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_postebanque;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_typepaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_numfacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_montantpaye;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idclient;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_refpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_coordpayeur;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_comptepaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_typetransfert;
    }
}