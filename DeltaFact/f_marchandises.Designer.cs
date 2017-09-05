namespace DeltaFact
{
    partial class f_marchandises
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_marchandises));
            this.comrealvista = new MySql.Data.MySqlClient.MySqlCommand();
            this.codearticle = new System.Windows.Forms.TextBox();
            this.descriptif_ligne1 = new System.Windows.Forms.TextBox();
            this.unite = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.p_affiche = new System.Windows.Forms.Panel();
            this.lb_entreprise = new System.Windows.Forms.Label();
            this.edrabaispourcent = new System.Windows.Forms.TextBox();
            this.eddaterabaisa = new System.Windows.Forms.DateTimePicker();
            this.bt_suplignerab = new System.Windows.Forms.Button();
            this.bt_ajoutlignerab = new System.Windows.Forms.Button();
            this.eddaterabaisde = new System.Windows.Forms.DateTimePicker();
            this.gv_rabais = new System.Windows.Forms.DataGridView();
            this.g_idrabais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_daterabaisde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_daterabaisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_rabaispourcent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_rabaismontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edrabaismontant = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.bt_supligne = new System.Windows.Forms.Button();
            this.bt_ajoutprix = new System.Windows.Forms.Button();
            this.eddateprix = new System.Windows.Forms.DateTimePicker();
            this.gv_prix = new System.Windows.Forms.DataGridView();
            this.g_idprix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_dateprix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_prix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edprix = new System.Windows.Forms.TextBox();
            this.descriptif_ligne5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.descriptif_ligne4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.descriptif_ligne3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.descriptif_ligne2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.remarque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.p_button = new System.Windows.Forms.Panel();
            this.bt_annul = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bt_valider = new System.Windows.Forms.Button();
            this.bt_suppr = new System.Windows.Forms.Button();
            this.bt_ajout = new System.Windows.Forms.Button();
            this.bt_modif = new System.Windows.Forms.Button();
            this.gv_article = new System.Windows.Forms.DataGridView();
            this.g_idarticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_codearticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif_ligne1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif_ligne2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif_ligne3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif_ligne4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif_ligne5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_unite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.p_affiche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_rabais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_prix)).BeginInit();
            this.p_button.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_article)).BeginInit();
            this.SuspendLayout();
            // 
            // comrealvista
            // 
            this.comrealvista.CacheAge = 60;
            this.comrealvista.Connection = null;
            this.comrealvista.EnableCaching = false;
            this.comrealvista.Transaction = null;
            // 
            // codearticle
            // 
            this.codearticle.Location = new System.Drawing.Point(106, 46);
            this.codearticle.Name = "codearticle";
            this.codearticle.Size = new System.Drawing.Size(183, 20);
            this.codearticle.TabIndex = 1;
            this.codearticle.Tag = "2";
            // 
            // descriptif_ligne1
            // 
            this.descriptif_ligne1.Location = new System.Drawing.Point(106, 72);
            this.descriptif_ligne1.Name = "descriptif_ligne1";
            this.descriptif_ligne1.Size = new System.Drawing.Size(364, 20);
            this.descriptif_ligne1.TabIndex = 2;
            this.descriptif_ligne1.Tag = "2";
            // 
            // unite
            // 
            this.unite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.unite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.unite.DisplayMember = "unitecode";
            this.unite.FormattingEnabled = true;
            this.unite.Location = new System.Drawing.Point(106, 202);
            this.unite.Name = "unite";
            this.unite.Size = new System.Drawing.Size(183, 21);
            this.unite.TabIndex = 7;
            this.unite.Tag = "2";
            this.unite.ValueMember = "idunite";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "code article";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "descriptif ligne1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "unité";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "prix unitaire";
            // 
            // p_affiche
            // 
            this.p_affiche.BackColor = System.Drawing.Color.Transparent;
            this.p_affiche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p_affiche.Controls.Add(this.lb_entreprise);
            this.p_affiche.Controls.Add(this.edrabaispourcent);
            this.p_affiche.Controls.Add(this.eddaterabaisa);
            this.p_affiche.Controls.Add(this.bt_suplignerab);
            this.p_affiche.Controls.Add(this.bt_ajoutlignerab);
            this.p_affiche.Controls.Add(this.eddaterabaisde);
            this.p_affiche.Controls.Add(this.gv_rabais);
            this.p_affiche.Controls.Add(this.edrabaismontant);
            this.p_affiche.Controls.Add(this.label11);
            this.p_affiche.Controls.Add(this.bt_supligne);
            this.p_affiche.Controls.Add(this.bt_ajoutprix);
            this.p_affiche.Controls.Add(this.eddateprix);
            this.p_affiche.Controls.Add(this.gv_prix);
            this.p_affiche.Controls.Add(this.edprix);
            this.p_affiche.Controls.Add(this.descriptif_ligne5);
            this.p_affiche.Controls.Add(this.label10);
            this.p_affiche.Controls.Add(this.descriptif_ligne4);
            this.p_affiche.Controls.Add(this.label9);
            this.p_affiche.Controls.Add(this.descriptif_ligne3);
            this.p_affiche.Controls.Add(this.label8);
            this.p_affiche.Controls.Add(this.descriptif_ligne2);
            this.p_affiche.Controls.Add(this.label7);
            this.p_affiche.Controls.Add(this.codearticle);
            this.p_affiche.Controls.Add(this.descriptif_ligne1);
            this.p_affiche.Controls.Add(this.remarque);
            this.p_affiche.Controls.Add(this.label3);
            this.p_affiche.Controls.Add(this.label6);
            this.p_affiche.Controls.Add(this.unite);
            this.p_affiche.Controls.Add(this.label1);
            this.p_affiche.Controls.Add(this.label4);
            this.p_affiche.Controls.Add(this.label5);
            this.p_affiche.Location = new System.Drawing.Point(22, 12);
            this.p_affiche.Name = "p_affiche";
            this.p_affiche.Size = new System.Drawing.Size(491, 535);
            this.p_affiche.TabIndex = 0;
            // 
            // lb_entreprise
            // 
            this.lb_entreprise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_entreprise.Location = new System.Drawing.Point(8, 11);
            this.lb_entreprise.Name = "lb_entreprise";
            this.lb_entreprise.Size = new System.Drawing.Size(456, 25);
            this.lb_entreprise.TabIndex = 28;
            this.lb_entreprise.Text = "Entreprise";
            this.lb_entreprise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edrabaispourcent
            // 
            this.edrabaispourcent.Location = new System.Drawing.Point(278, 443);
            this.edrabaispourcent.Name = "edrabaispourcent";
            this.edrabaispourcent.Size = new System.Drawing.Size(63, 20);
            this.edrabaispourcent.TabIndex = 18;
            this.edrabaispourcent.Tag = "9";
            this.edrabaispourcent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edrabaispourcent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edrabaispourcent_KeyPress);
            // 
            // eddaterabaisa
            // 
            this.eddaterabaisa.AccessibleName = "datecommande";
            this.eddaterabaisa.CalendarMonthBackground = System.Drawing.Color.White;
            this.eddaterabaisa.CustomFormat = "dd.MM.yyyy";
            this.eddaterabaisa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eddaterabaisa.Location = new System.Drawing.Point(192, 443);
            this.eddaterabaisa.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.eddaterabaisa.Name = "eddaterabaisa";
            this.eddaterabaisa.Size = new System.Drawing.Size(80, 20);
            this.eddaterabaisa.TabIndex = 17;
            this.eddaterabaisa.Tag = "9";
            this.eddaterabaisa.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            // 
            // bt_suplignerab
            // 
            this.bt_suplignerab.Location = new System.Drawing.Point(447, 353);
            this.bt_suplignerab.Name = "bt_suplignerab";
            this.bt_suplignerab.Size = new System.Drawing.Size(22, 23);
            this.bt_suplignerab.TabIndex = 15;
            this.bt_suplignerab.Tag = "9";
            this.bt_suplignerab.Text = "-";
            this.bt_suplignerab.UseVisualStyleBackColor = true;
            this.bt_suplignerab.Click += new System.EventHandler(this.bt_suplignerab_Click);
            // 
            // bt_ajoutlignerab
            // 
            this.bt_ajoutlignerab.Location = new System.Drawing.Point(447, 324);
            this.bt_ajoutlignerab.Name = "bt_ajoutlignerab";
            this.bt_ajoutlignerab.Size = new System.Drawing.Size(22, 23);
            this.bt_ajoutlignerab.TabIndex = 14;
            this.bt_ajoutlignerab.Tag = "9";
            this.bt_ajoutlignerab.Text = "+";
            this.bt_ajoutlignerab.UseVisualStyleBackColor = true;
            this.bt_ajoutlignerab.Click += new System.EventHandler(this.bt_ajoutlignerab_Click);
            // 
            // eddaterabaisde
            // 
            this.eddaterabaisde.AccessibleName = "datecommande";
            this.eddaterabaisde.CalendarMonthBackground = System.Drawing.Color.White;
            this.eddaterabaisde.CustomFormat = "dd.MM.yyyy";
            this.eddaterabaisde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eddaterabaisde.Location = new System.Drawing.Point(106, 443);
            this.eddaterabaisde.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.eddaterabaisde.Name = "eddaterabaisde";
            this.eddaterabaisde.Size = new System.Drawing.Size(80, 20);
            this.eddaterabaisde.TabIndex = 16;
            this.eddaterabaisde.Tag = "9";
            this.eddaterabaisde.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            // 
            // gv_rabais
            // 
            this.gv_rabais.AllowUserToAddRows = false;
            this.gv_rabais.AllowUserToDeleteRows = false;
            this.gv_rabais.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gv_rabais.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gv_rabais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_rabais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_idrabais,
            this.g_daterabaisde,
            this.g_daterabaisa,
            this.g_rabaispourcent,
            this.g_rabaismontant});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_rabais.DefaultCellStyle = dataGridViewCellStyle5;
            this.gv_rabais.Location = new System.Drawing.Point(106, 324);
            this.gv_rabais.MultiSelect = false;
            this.gv_rabais.Name = "gv_rabais";
            this.gv_rabais.ReadOnly = true;
            this.gv_rabais.RowHeadersVisible = false;
            this.gv_rabais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_rabais.Size = new System.Drawing.Size(335, 113);
            this.gv_rabais.TabIndex = 13;
            this.gv_rabais.Tag = "9";
            this.gv_rabais.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_rabais_CellClick);
            this.gv_rabais.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_rabais_CellDoubleClick);
            // 
            // g_idrabais
            // 
            this.g_idrabais.HeaderText = "Column1";
            this.g_idrabais.Name = "g_idrabais";
            this.g_idrabais.ReadOnly = true;
            this.g_idrabais.Visible = false;
            // 
            // g_daterabaisde
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_daterabaisde.DefaultCellStyle = dataGridViewCellStyle1;
            this.g_daterabaisde.HeaderText = "du";
            this.g_daterabaisde.Name = "g_daterabaisde";
            this.g_daterabaisde.ReadOnly = true;
            this.g_daterabaisde.Width = 80;
            // 
            // g_daterabaisa
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_daterabaisa.DefaultCellStyle = dataGridViewCellStyle2;
            this.g_daterabaisa.HeaderText = "au";
            this.g_daterabaisa.Name = "g_daterabaisa";
            this.g_daterabaisa.ReadOnly = true;
            this.g_daterabaisa.Width = 80;
            // 
            // g_rabaispourcent
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_rabaispourcent.DefaultCellStyle = dataGridViewCellStyle3;
            this.g_rabaispourcent.HeaderText = "%";
            this.g_rabaispourcent.Name = "g_rabaispourcent";
            this.g_rabaispourcent.ReadOnly = true;
            this.g_rabaispourcent.Width = 70;
            // 
            // g_rabaismontant
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_rabaismontant.DefaultCellStyle = dataGridViewCellStyle4;
            this.g_rabaismontant.HeaderText = "montant";
            this.g_rabaismontant.Name = "g_rabaismontant";
            this.g_rabaismontant.ReadOnly = true;
            this.g_rabaismontant.Width = 85;
            // 
            // edrabaismontant
            // 
            this.edrabaismontant.Location = new System.Drawing.Point(347, 443);
            this.edrabaismontant.Name = "edrabaismontant";
            this.edrabaismontant.Size = new System.Drawing.Size(77, 20);
            this.edrabaismontant.TabIndex = 19;
            this.edrabaismontant.Tag = "9";
            this.edrabaismontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edrabaismontant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edrabaismontant_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 327);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "rabais";
            // 
            // bt_supligne
            // 
            this.bt_supligne.Location = new System.Drawing.Point(295, 258);
            this.bt_supligne.Name = "bt_supligne";
            this.bt_supligne.Size = new System.Drawing.Size(22, 23);
            this.bt_supligne.TabIndex = 10;
            this.bt_supligne.Tag = "9";
            this.bt_supligne.Text = "-";
            this.bt_supligne.UseVisualStyleBackColor = true;
            this.bt_supligne.Click += new System.EventHandler(this.bt_supligne_Click);
            // 
            // bt_ajoutprix
            // 
            this.bt_ajoutprix.Location = new System.Drawing.Point(295, 229);
            this.bt_ajoutprix.Name = "bt_ajoutprix";
            this.bt_ajoutprix.Size = new System.Drawing.Size(22, 23);
            this.bt_ajoutprix.TabIndex = 9;
            this.bt_ajoutprix.Tag = "9";
            this.bt_ajoutprix.Text = "+";
            this.bt_ajoutprix.UseVisualStyleBackColor = true;
            this.bt_ajoutprix.Click += new System.EventHandler(this.bt_ajoutprix_Click);
            // 
            // eddateprix
            // 
            this.eddateprix.AccessibleName = "datecommande";
            this.eddateprix.CalendarMonthBackground = System.Drawing.Color.White;
            this.eddateprix.CustomFormat = "dd.MM.yyyy";
            this.eddateprix.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eddateprix.Location = new System.Drawing.Point(106, 298);
            this.eddateprix.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.eddateprix.Name = "eddateprix";
            this.eddateprix.Size = new System.Drawing.Size(80, 20);
            this.eddateprix.TabIndex = 11;
            this.eddateprix.Tag = "9";
            this.eddateprix.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            // 
            // gv_prix
            // 
            this.gv_prix.AllowUserToAddRows = false;
            this.gv_prix.AllowUserToDeleteRows = false;
            this.gv_prix.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gv_prix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gv_prix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_prix.ColumnHeadersVisible = false;
            this.gv_prix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_idprix,
            this.g_dateprix,
            this.g_prix});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_prix.DefaultCellStyle = dataGridViewCellStyle8;
            this.gv_prix.Location = new System.Drawing.Point(106, 229);
            this.gv_prix.MultiSelect = false;
            this.gv_prix.Name = "gv_prix";
            this.gv_prix.ReadOnly = true;
            this.gv_prix.RowHeadersVisible = false;
            this.gv_prix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_prix.Size = new System.Drawing.Size(183, 63);
            this.gv_prix.TabIndex = 8;
            this.gv_prix.Tag = "9";
            this.gv_prix.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_prix_CellClick);
            this.gv_prix.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_prix_CellDoubleClick);
            // 
            // g_idprix
            // 
            this.g_idprix.HeaderText = "Column1";
            this.g_idprix.Name = "g_idprix";
            this.g_idprix.ReadOnly = true;
            this.g_idprix.Visible = false;
            // 
            // g_dateprix
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_dateprix.DefaultCellStyle = dataGridViewCellStyle6;
            this.g_dateprix.HeaderText = "dateprix";
            this.g_dateprix.Name = "g_dateprix";
            this.g_dateprix.ReadOnly = true;
            this.g_dateprix.Width = 80;
            // 
            // g_prix
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.g_prix.DefaultCellStyle = dataGridViewCellStyle7;
            this.g_prix.HeaderText = "prix";
            this.g_prix.Name = "g_prix";
            this.g_prix.ReadOnly = true;
            this.g_prix.Width = 80;
            // 
            // edprix
            // 
            this.edprix.Location = new System.Drawing.Point(192, 298);
            this.edprix.Name = "edprix";
            this.edprix.Size = new System.Drawing.Size(97, 20);
            this.edprix.TabIndex = 12;
            this.edprix.Tag = "9";
            this.edprix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edprix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edprix_KeyPress);
            // 
            // descriptif_ligne5
            // 
            this.descriptif_ligne5.Location = new System.Drawing.Point(106, 176);
            this.descriptif_ligne5.Name = "descriptif_ligne5";
            this.descriptif_ligne5.Size = new System.Drawing.Size(364, 20);
            this.descriptif_ligne5.TabIndex = 6;
            this.descriptif_ligne5.Tag = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "descriptif ligne5";
            // 
            // descriptif_ligne4
            // 
            this.descriptif_ligne4.Location = new System.Drawing.Point(106, 150);
            this.descriptif_ligne4.Name = "descriptif_ligne4";
            this.descriptif_ligne4.Size = new System.Drawing.Size(364, 20);
            this.descriptif_ligne4.TabIndex = 5;
            this.descriptif_ligne4.Tag = "2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "descriptif ligne4";
            // 
            // descriptif_ligne3
            // 
            this.descriptif_ligne3.Location = new System.Drawing.Point(106, 124);
            this.descriptif_ligne3.Name = "descriptif_ligne3";
            this.descriptif_ligne3.Size = new System.Drawing.Size(364, 20);
            this.descriptif_ligne3.TabIndex = 4;
            this.descriptif_ligne3.Tag = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "descriptif ligne3";
            // 
            // descriptif_ligne2
            // 
            this.descriptif_ligne2.Location = new System.Drawing.Point(106, 98);
            this.descriptif_ligne2.Name = "descriptif_ligne2";
            this.descriptif_ligne2.Size = new System.Drawing.Size(364, 20);
            this.descriptif_ligne2.TabIndex = 3;
            this.descriptif_ligne2.Tag = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "descriptif ligne2";
            // 
            // remarque
            // 
            this.remarque.Location = new System.Drawing.Point(106, 473);
            this.remarque.Multiline = true;
            this.remarque.Name = "remarque";
            this.remarque.Size = new System.Drawing.Size(363, 47);
            this.remarque.TabIndex = 20;
            this.remarque.Tag = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 474);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "remarque";
            // 
            // p_button
            // 
            this.p_button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_button.Controls.Add(this.bt_annul);
            this.p_button.Controls.Add(this.bt_valider);
            this.p_button.Controls.Add(this.bt_suppr);
            this.p_button.Controls.Add(this.bt_ajout);
            this.p_button.Controls.Add(this.bt_modif);
            this.p_button.Location = new System.Drawing.Point(22, 563);
            this.p_button.Name = "p_button";
            this.p_button.Size = new System.Drawing.Size(491, 40);
            this.p_button.TabIndex = 11;
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
            // gv_article
            // 
            this.gv_article.AllowUserToAddRows = false;
            this.gv_article.AllowUserToDeleteRows = false;
            this.gv_article.AllowUserToResizeColumns = false;
            this.gv_article.AllowUserToResizeRows = false;
            this.gv_article.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_article.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_idarticle,
            this.g_codearticle,
            this.g_descriptif_ligne1,
            this.g_descriptif_ligne2,
            this.g_descriptif_ligne3,
            this.g_descriptif_ligne4,
            this.g_descriptif_ligne5,
            this.g_unite});
            this.gv_article.Location = new System.Drawing.Point(529, 12);
            this.gv_article.Name = "gv_article";
            this.gv_article.ReadOnly = true;
            this.gv_article.RowHeadersVisible = false;
            this.gv_article.Size = new System.Drawing.Size(918, 535);
            this.gv_article.TabIndex = 12;
            this.gv_article.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_article_CellClick);
            this.gv_article.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_article_CellDoubleClick);
            this.gv_article.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_article_RowEnter);
            // 
            // g_idarticle
            // 
            this.g_idarticle.HeaderText = "idarticle";
            this.g_idarticle.Name = "g_idarticle";
            this.g_idarticle.ReadOnly = true;
            this.g_idarticle.Visible = false;
            // 
            // g_codearticle
            // 
            this.g_codearticle.HeaderText = "code";
            this.g_codearticle.Name = "g_codearticle";
            this.g_codearticle.ReadOnly = true;
            this.g_codearticle.Width = 60;
            // 
            // g_descriptif_ligne1
            // 
            this.g_descriptif_ligne1.HeaderText = "descriptif ligne1";
            this.g_descriptif_ligne1.Name = "g_descriptif_ligne1";
            this.g_descriptif_ligne1.ReadOnly = true;
            this.g_descriptif_ligne1.Width = 250;
            // 
            // g_descriptif_ligne2
            // 
            this.g_descriptif_ligne2.HeaderText = "déscriptif ligne2";
            this.g_descriptif_ligne2.Name = "g_descriptif_ligne2";
            this.g_descriptif_ligne2.ReadOnly = true;
            this.g_descriptif_ligne2.Width = 150;
            // 
            // g_descriptif_ligne3
            // 
            this.g_descriptif_ligne3.HeaderText = "descriptif ligne3";
            this.g_descriptif_ligne3.Name = "g_descriptif_ligne3";
            this.g_descriptif_ligne3.ReadOnly = true;
            this.g_descriptif_ligne3.Width = 120;
            // 
            // g_descriptif_ligne4
            // 
            this.g_descriptif_ligne4.HeaderText = "descriptif ligne4";
            this.g_descriptif_ligne4.Name = "g_descriptif_ligne4";
            this.g_descriptif_ligne4.ReadOnly = true;
            this.g_descriptif_ligne4.Width = 120;
            // 
            // g_descriptif_ligne5
            // 
            this.g_descriptif_ligne5.HeaderText = "descriptif ligne5";
            this.g_descriptif_ligne5.Name = "g_descriptif_ligne5";
            this.g_descriptif_ligne5.ReadOnly = true;
            this.g_descriptif_ligne5.Width = 120;
            // 
            // g_unite
            // 
            this.g_unite.HeaderText = "unité";
            this.g_unite.Name = "g_unite";
            this.g_unite.ReadOnly = true;
            this.g_unite.Width = 70;
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // f_marchandises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 615);
            this.Controls.Add(this.gv_article);
            this.Controls.Add(this.p_button);
            this.Controls.Add(this.p_affiche);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_marchandises";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des Marchandises";
            this.Load += new System.EventHandler(this.f_marchandises_Load);
            this.p_affiche.ResumeLayout(false);
            this.p_affiche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_rabais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_prix)).EndInit();
            this.p_button.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_article)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox codearticle;
        private System.Windows.Forms.TextBox descriptif_ligne1;
        private System.Windows.Forms.ComboBox unite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel p_affiche;
        private System.Windows.Forms.Panel p_button;
        private System.Windows.Forms.Button bt_modif;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bt_annul;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.Button bt_suppr;
        private System.Windows.Forms.Button bt_ajout;
        private System.Windows.Forms.DataGridView gv_article;
        private System.Windows.Forms.TextBox remarque;
        private System.Windows.Forms.Label label6;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.TextBox descriptif_ligne5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox descriptif_ligne4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox descriptif_ligne3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox descriptif_ligne2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edprix;
        public MySql.Data.MySqlClient.MySqlCommand comrealvista;
        private System.Windows.Forms.DataGridView gv_prix;
        private System.Windows.Forms.DateTimePicker eddateprix;
        private System.Windows.Forms.Button bt_ajoutprix;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idprix;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_dateprix;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_prix;
        private System.Windows.Forms.Button bt_supligne;
        private System.Windows.Forms.Button bt_suplignerab;
        private System.Windows.Forms.Button bt_ajoutlignerab;
        private System.Windows.Forms.DateTimePicker eddaterabaisde;
        private System.Windows.Forms.DataGridView gv_rabais;
        private System.Windows.Forms.TextBox edrabaismontant;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox edrabaispourcent;
        private System.Windows.Forms.DateTimePicker eddaterabaisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idrabais;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_daterabaisde;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_daterabaisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_rabaispourcent;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_rabaismontant;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idarticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_codearticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif_ligne1;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif_ligne2;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif_ligne3;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif_ligne4;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif_ligne5;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_unite;
        private System.Windows.Forms.Label lb_entreprise;
    }
}

