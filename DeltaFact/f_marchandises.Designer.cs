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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_marchandises));
            this.conrealvista = new MySql.Data.MySqlClient.MySqlConnection();
            this.comrealvista = new MySql.Data.MySqlClient.MySqlCommand();
            this.codearticle = new System.Windows.Forms.TextBox();
            this.client = new System.Windows.Forms.ComboBox();
            this.descriptif = new System.Windows.Forms.TextBox();
            this.unite = new System.Windows.Forms.ComboBox();
            this.prix = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.p_affiche = new System.Windows.Forms.Panel();
            this.lb_client = new System.Windows.Forms.Label();
            this.lb_unite = new System.Windows.Forms.Label();
            this.remarque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.p_button = new System.Windows.Forms.Panel();
            this.bt_annul = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bt_valider = new System.Windows.Forms.Button();
            this.bt_suppr = new System.Windows.Forms.Button();
            this.bt_ajout = new System.Windows.Forms.Button();
            this.bt_modif = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.g_idarticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_codearticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_idclient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_descriptif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_unite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_prix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.p_affiche.SuspendLayout();
            this.p_button.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comrealvista
            // 
            this.comrealvista.CacheAge = 60;
            this.comrealvista.Connection = this.conrealvista;
            this.comrealvista.EnableCaching = false;
            this.comrealvista.Transaction = null;
            // 
            // codearticle
            // 
            this.codearticle.Location = new System.Drawing.Point(128, 11);
            this.codearticle.Name = "codearticle";
            this.codearticle.Size = new System.Drawing.Size(128, 20);
            this.codearticle.TabIndex = 0;
            this.codearticle.Tag = "2";
            // 
            // client
            // 
            this.client.DisplayMember = "idclient";
            this.client.FormattingEnabled = true;
            this.client.Location = new System.Drawing.Point(128, 41);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(129, 21);
            this.client.TabIndex = 1;
            this.client.Tag = "2";
            this.client.ValueMember = "client";
            // 
            // descriptif
            // 
            this.descriptif.Location = new System.Drawing.Point(128, 68);
            this.descriptif.Name = "descriptif";
            this.descriptif.Size = new System.Drawing.Size(373, 20);
            this.descriptif.TabIndex = 2;
            this.descriptif.Tag = "2";
            // 
            // unite
            // 
            this.unite.DisplayMember = "unitecode";
            this.unite.FormattingEnabled = true;
            this.unite.Location = new System.Drawing.Point(128, 94);
            this.unite.Name = "unite";
            this.unite.Size = new System.Drawing.Size(129, 21);
            this.unite.TabIndex = 3;
            this.unite.Tag = "2";
            this.unite.ValueMember = "unitelibelle";
            // 
            // prix
            // 
            this.prix.Location = new System.Drawing.Point(128, 121);
            this.prix.Name = "prix";
            this.prix.Size = new System.Drawing.Size(129, 20);
            this.prix.TabIndex = 4;
            this.prix.Tag = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "code article";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "descriptif";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "unité";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "prix unitaire";
            // 
            // p_affiche
            // 
            this.p_affiche.BackColor = System.Drawing.Color.Transparent;
            this.p_affiche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p_affiche.Controls.Add(this.lb_client);
            this.p_affiche.Controls.Add(this.codearticle);
            this.p_affiche.Controls.Add(this.lb_unite);
            this.p_affiche.Controls.Add(this.descriptif);
            this.p_affiche.Controls.Add(this.remarque);
            this.p_affiche.Controls.Add(this.label3);
            this.p_affiche.Controls.Add(this.label2);
            this.p_affiche.Controls.Add(this.label6);
            this.p_affiche.Controls.Add(this.client);
            this.p_affiche.Controls.Add(this.unite);
            this.p_affiche.Controls.Add(this.label1);
            this.p_affiche.Controls.Add(this.label4);
            this.p_affiche.Controls.Add(this.prix);
            this.p_affiche.Controls.Add(this.label5);
            this.p_affiche.Location = new System.Drawing.Point(22, 12);
            this.p_affiche.Name = "p_affiche";
            this.p_affiche.Size = new System.Drawing.Size(519, 210);
            this.p_affiche.TabIndex = 10;
            // 
            // lb_client
            // 
            this.lb_client.AutoSize = true;
            this.lb_client.Location = new System.Drawing.Point(263, 44);
            this.lb_client.Name = "lb_client";
            this.lb_client.Size = new System.Drawing.Size(30, 13);
            this.lb_client.TabIndex = 14;
            this.lb_client.Tag = "2";
            this.lb_client.Text = "unité";
            // 
            // lb_unite
            // 
            this.lb_unite.AutoSize = true;
            this.lb_unite.Location = new System.Drawing.Point(263, 97);
            this.lb_unite.Name = "lb_unite";
            this.lb_unite.Size = new System.Drawing.Size(30, 13);
            this.lb_unite.TabIndex = 13;
            this.lb_unite.Tag = "2";
            this.lb_unite.Text = "unité";
            // 
            // remarque
            // 
            this.remarque.Location = new System.Drawing.Point(129, 149);
            this.remarque.Multiline = true;
            this.remarque.Name = "remarque";
            this.remarque.Size = new System.Drawing.Size(372, 47);
            this.remarque.TabIndex = 12;
            this.remarque.Tag = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 150);
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
            this.p_button.Location = new System.Drawing.Point(21, 256);
            this.p_button.Name = "p_button";
            this.p_button.Size = new System.Drawing.Size(518, 40);
            this.p_button.TabIndex = 11;
            // 
            // bt_annul
            // 
            this.bt_annul.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_annul.ImageIndex = 9;
            this.bt_annul.ImageList = this.imageList1;
            this.bt_annul.Location = new System.Drawing.Point(405, 9);
            this.bt_annul.Name = "bt_annul";
            this.bt_annul.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_annul.Size = new System.Drawing.Size(89, 23);
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
            this.bt_valider.Location = new System.Drawing.Point(310, 9);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_valider.Size = new System.Drawing.Size(89, 23);
            this.bt_valider.TabIndex = 3;
            this.bt_valider.Tag = "2";
            this.bt_valider.Text = "valider";
            this.bt_valider.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_valider.UseVisualStyleBackColor = true;
            // 
            // bt_suppr
            // 
            this.bt_suppr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_suppr.ImageIndex = 6;
            this.bt_suppr.ImageList = this.imageList1;
            this.bt_suppr.Location = new System.Drawing.Point(215, 9);
            this.bt_suppr.Name = "bt_suppr";
            this.bt_suppr.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_suppr.Size = new System.Drawing.Size(89, 23);
            this.bt_suppr.TabIndex = 2;
            this.bt_suppr.Tag = "1";
            this.bt_suppr.Text = "supprimer";
            this.bt_suppr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_suppr.UseVisualStyleBackColor = true;
            // 
            // bt_ajout
            // 
            this.bt_ajout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ajout.ImageIndex = 5;
            this.bt_ajout.ImageList = this.imageList1;
            this.bt_ajout.Location = new System.Drawing.Point(118, 9);
            this.bt_ajout.Name = "bt_ajout";
            this.bt_ajout.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_ajout.Size = new System.Drawing.Size(89, 23);
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
            this.bt_modif.Location = new System.Drawing.Point(21, 9);
            this.bt_modif.Name = "bt_modif";
            this.bt_modif.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bt_modif.Size = new System.Drawing.Size(89, 23);
            this.bt_modif.TabIndex = 0;
            this.bt_modif.Tag = "1";
            this.bt_modif.Text = "modifier";
            this.bt_modif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_modif.UseVisualStyleBackColor = true;
            this.bt_modif.Click += new System.EventHandler(this.bt_modif_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_idarticle,
            this.g_codearticle,
            this.g_idclient,
            this.g_descriptif,
            this.g_unite,
            this.g_prix});
            this.dataGridView1.Location = new System.Drawing.Point(22, 311);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(517, 243);
            this.dataGridView1.TabIndex = 12;
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
            // 
            // g_idclient
            // 
            this.g_idclient.HeaderText = "client";
            this.g_idclient.Name = "g_idclient";
            this.g_idclient.ReadOnly = true;
            this.g_idclient.Width = 50;
            // 
            // g_descriptif
            // 
            this.g_descriptif.HeaderText = "descriptif";
            this.g_descriptif.Name = "g_descriptif";
            this.g_descriptif.ReadOnly = true;
            this.g_descriptif.Width = 150;
            // 
            // g_unite
            // 
            this.g_unite.HeaderText = "unité";
            this.g_unite.Name = "g_unite";
            this.g_unite.ReadOnly = true;
            // 
            // g_prix
            // 
            this.g_prix.HeaderText = "prix unitaire";
            this.g_prix.Name = "g_prix";
            this.g_prix.ReadOnly = true;
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
            this.ClientSize = new System.Drawing.Size(565, 576);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.p_button);
            this.Controls.Add(this.p_affiche);
            this.Name = "f_marchandises";
            this.Text = "Gestion des Marchandises";
            this.Load += new System.EventHandler(this.f_marchandises_Load);
            this.p_affiche.ResumeLayout(false);
            this.p_affiche.PerformLayout();
            this.p_button.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlConnection conrealvista;
        private MySql.Data.MySqlClient.MySqlCommand comrealvista;
        private System.Windows.Forms.TextBox codearticle;
        private System.Windows.Forms.ComboBox client;
        private System.Windows.Forms.TextBox descriptif;
        private System.Windows.Forms.ComboBox unite;
        private System.Windows.Forms.MaskedTextBox prix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox remarque;
        private System.Windows.Forms.Label label6;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Label lb_unite;
        private System.Windows.Forms.Label lb_client;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idarticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_codearticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_idclient;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_descriptif;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_unite;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_prix;
    }
}

