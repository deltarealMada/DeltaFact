using System;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Data;
using System.IO;


namespace DeltaFact
{
	public partial class MainForm : Form //partial
	{
		//C
		//Form f_collaborateurs;
	    util_fact Util = new util_fact();
		IniFile Inif = new IniFile(Environment.CurrentDirectory + "\\Deltareal.ini");
		public string lUser = "";
		public string InitUser = "";
		public int idUser = 0;
		public string szPath = "";
		//private int childFormNumber = 0;
		public string baseD = "";
		public string exercice = "2013";
		public string szCompteDebit;
        bool bclosing = false;
        public string reqdoncli = "";
		public MainForm()
		{
			
			InitializeComponent();
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        string dbase;
        public string basefact;

        public string generernumfacture(string ident)
        {
            int numsuiv = 0;

            string listeexistant = Util.ValeurParCond(DeltaSQLTmp, "fact_facturation", "group_concat(distinct right(reffacturedeltareal, 4) order by reffacturedeltareal asc) as listefact", "listefact", "identreprise =" + identreprisesel + " AND year(datefacturedeltareal) = " + DateTime.Now.Year.ToString() + " order by reffacturedeltareal", "SET SESSION group_concat_max_len = 10000000;");

            if (listeexistant != "")
            {
                string liste = "";
                string[] se = listeexistant.Split(',');
                int maxi = int.Parse(se[se.Length - 1]);
                string[] sorig = new string[maxi];
                for (int i = 0; i < maxi; i++)
                {
                    sorig[i] = (i + 1).ToString();
                }

                for (int i = 0; i < sorig.Length; i++)
                {
                    if (int.Parse(se[i]).ToString() == sorig[i])
                        continue;
                    else
                    {
                        numsuiv = int.Parse(sorig[i]);
                        return DateTime.Now.Year.ToString() + identreprisesel.PadLeft(2, '0') + numsuiv.ToString().PadLeft(4, '0');
                        //return numsuiv;
                    }
                }
                return DateTime.Now.Year.ToString() + identreprisesel.PadLeft(2, '0') + (maxi + 1).ToString().PadLeft(4, '0');

                //return maxi + 1;

            }
            else
                numsuiv = 0;
            return DateTime.Now.Year.ToString() + identreprisesel.PadLeft(2, '0') + (numsuiv + 1).ToString().PadLeft(4, '0');

            //return numsuiv + 1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            //System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            double j = 1.1228;
            j = Math.Round(j / 0.05) * 0.05;
            string h = string.Format("{0:0.00;-0.00;0}", j);
            //this.TransparencyKey = System.Drawing.Color.Blue;
            //MessageBox.Show("kkkk");
            szPath = Inif.ReadString("files", "filespath");
            if (Inif.ReadString("PARAM", "posX") != "")
                this.Left = int.Parse(Inif.ReadString("PARAM", "posX"));
            if (Inif.ReadString("PARAM", "posY") != "")
                this.Top = int.Parse(Inif.ReadString("PARAM", "posY"));
            //Inif.ReadString("BDD", "databaseName")


            dbase = Inif.ReadString("BDD", "databaseName");
            basefact = Inif.ReadString("BDD", "databaseNameFact");
            baseInit = dbase;
            /*string[] s = dbase.Split(';');
			for (int i = 0; i < s.Length; i++)
			{
				cb_base.Items.Add(s[i]);
			}
			if (cb_base.Items.Count > 0)
				cb_base.SelectedIndex = 0;
			
			string cptDebit = "";
			cptDebit = Inif.ReadString("BDD", "CompteDebit");
			LiCompteDebit = cptDebit.Split(';');
			*/
            reqdoncli = "select pub, texterappel, comptedebit as compte, compteb, comptefacture, client.identreprise as refentreprise, basededonnees, if (isnull(client.iddeltareal) OR client.iddeltareal = 0, '', client.iddeltareal) as iddeltareal, " +
                "if(iddeltareal > 0, clidelta.socligne1, client.socligne1) as socligne1, if(iddeltareal > 0, clidelta.socligne2, client.socligne2) as socligne2, " +
                "client.idtauxtva, typetva.taux as tauxtva, client.numtva, client.monnaie as monnaie, client.monnaie as idmonnaie, client.echeance as nbrecheance, client.echeancerappel,  client.frais, client.fraispourcent, client.infos, " +
                "monnaie.monnaie as smonnaie FROM fact_entreprise client LEFT JOIN fact_monnaie monnaie on monnaie.idmonnaie = client.monnaie " +

                "LEFT JOIN " + baseInit + ".client clidelta ON clidelta.idclient = client.iddeltareal LEFT JOIN typetva ON typetva.idtva = client.idtauxtva " + //where client.identreprise = " + identreprisesel +
                " ORDER BY client.identreprise";
            connecter();
            
        }
        public string identreprisesel = "1";
        public string baseInit = "";
        private bool connecter()
        {
            string ConStr = "";
            DeltaCon.Close();
            DeltaConTmp1.Close();
            deltaConTmp2.Close();
            deltaConMod.Close();

           ConStr = "SERVER=" + Inif.ReadString("BDD", "hostname") + "; Allow User Variables=True; DATABASE=" + baseInit +
                "; UID=" + Inif.ReadString("BDD", "user") + "; PASSWORD=" + Inif.ReadString("BDD", "password") + "; PORT=" + Inif.ReadString("BDD", "port") + ";default command timeout=600;ConnectionTimeout=600";

            DeltaCon.ConnectionString = DeltaConTmp1.ConnectionString = deltaConMod.ConnectionString = deltaConTmp2.ConnectionString = ConStr;

            //server=localhost;User Id=root;password=za;Persist Security Info=True;database=deltareal
            ConStr = "server=" + Inif.ReadString("BDD", "hostname") + "; DATABASE=" + baseInit +
                "; User ID=" + Inif.ReadString("BDD", "user") + "; PASSWORD=" + Inif.ReadString("BDD", "password") + "; Persist Security Info=True" + ";default command timeout=600;ConnectionTimeout=600";
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DeltaCon.Open();
                DeltaConTmp1.Open();
                deltaConTmp2.Open();
                deltaConMod.Open();

                DeltaSQLTmp.Connection = DeltaConTmp1;
                //DeltaSQLCon.Connection = DeltaConTmp1;
                Cursor.Current = Cursors.Default;
                this.ActiveControl = edUser;
                this.StatusLabel.Text = "Connection à la base réussie !";


                Properties.Settings.Default["deltarealConnectionString"] = ConStr;

                return true;
            }
            catch
            {
                //var result = MessageBox.Show(this, "Connexion échouée ! Veuillez vérifier les paramètres !", "Connexion action la Base de Données.");
                Util.AfficherErreur("Connexion à la base échouée ! Veuillez vérifier les paramètres !");
                DeltaCon.Close();
                DeltaConTmp1.Close();
                deltaConTmp2.Close();
                deltaConMod.Close();
                return false;

                //System.Windows.Forms.Application.Exit();
            }

        }


        private void button5_Click(object sender, EventArgs e)
		{
			//connecter();
			DeltaSQLCon.CommandText = "SELECT nomprenom, username, password, initials, idcollaborateur FROM " + baseInit + ".Collaborateur WHERE username = '" + edUser.Text +
				"' AND password = '" + edMdp.Text + "'";

			MySqlDataReader myReader = DeltaSQLCon.ExecuteReader();
			if (myReader.Read())
			{
				//var result = MessageBox.Show(myReader.GetString(myReader.GetOrdinal("nomprenom")) + ". Vous êtes connecté !");

				Menu1.Enabled = true;
				ToolBar1.Enabled = true;
				panel1.Enabled = true;
				panel3.Visible = false;
				this.StatusLabel.Text = "Accès réussi de : " + myReader.GetString(myReader.GetOrdinal("nomprenom")) + "!";
				lUser = myReader.GetString(myReader.GetOrdinal("nomprenom"));
				InitUser = myReader.GetString(myReader.GetOrdinal("initials"));
				idUser = myReader.GetInt32(myReader.GetOrdinal("idcollaborateur"));
                
			}
			else
			{
				Util.AfficherErreur("Attention ! Login ou Mot de pass incorrect ! Veuillez rééssayer !");
				edUser.Focus();
                    myReader.Close();
                return;
            }
			myReader.Close();
			szU = Inif.ReadString("BDD", "user");
			szH = Inif.ReadString("BDD", "Hostname");
			szP = Inif.ReadString("BDD", "password");
            //if (cb_base.SelectedIndex > 0)
            //{
            bclosing = true;
				DeltaCon.Close();
				DeltaConTmp1.Close();
				deltaConTmp2.Close();
				deltaConMod.Close();
				string ConStr = "SERVER=" + Inif.ReadString("BDD", "hostname") + "; Allow User Variables=True; DATABASE=" + basefact +
					"; UID=" + Inif.ReadString("BDD", "user") + "; PASSWORD=" + Inif.ReadString("BDD", "password") + "; PORT=" + Inif.ReadString("BDD", "port") + ";default command timeout=600;ConnectionTimeout=600";

				DeltaCon.ConnectionString = DeltaConTmp1.ConnectionString = deltaConMod.ConnectionString = deltaConTmp2.ConnectionString = ConStr;
				Properties.Settings.Default["deltarealConnectionString"] = ConStr;
            bclosing = false;

            DeltaCon.Open();
				DeltaConTmp1.Open();
				deltaConTmp2.Open();
				deltaConMod.Open();
            myReader.Close();
            Util.RemplirCombo(cmbentreprisesource, "SELECT identreprise, if (entreprise.iddeltareal > 0, concat(clidelta.socligne1, ' ', clidelta.socligne2), concat(entreprise.socligne1, ' ', entreprise.socligne2)) as entreprise FROM fact_entreprise entreprise left join " + baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal ORDER BY identreprise", DeltaSQLCon, mySqlDataAdapter1);
            if (cmbentreprisesource.Items.Count == 0)
            {
                Util.AfficherErreur("Il n'y a pas encore d'entreprise enregistré ! Veuillez vérifier.");
                bt_marchandises.Enabled = bt_debiteur.Enabled = bt_facture.Enabled = false;

            }
            else
            {

                for (int i = 0; i < cmbentreprisesource.Items.Count; i++)
                {
                    cmbentreprise.Items.Add(cmbentreprisesource.GetItemText(cmbentreprisesource.Items[i]));
                }
                cmbentreprise.SelectedItem = cmbentreprise.Items[0];
            }

            this.Text = "DeltaFact v.1.2" + " - Base : " + basefact + " - Entreprise : " + cmbentreprisesource.Text ;
			

		}
        string szU, szH, szP = "";
		
		public DataTable ImportCSV(string filename, string[] delimeter, bool requriedHeader)
		{
			DataTable csvDataTable = new DataTable();
			try
			{
				if (!System.IO.File.Exists(filename))
				{
					throw new System.IO.FileNotFoundException("Le fichier sélectionné n'est pas trouvé :" + filename);
				}
				using (StreamReader readFile = new StreamReader(filename, System.Text.Encoding.Default, true))
				{

					string line; string[] orginalRow;
					bool onlyFirstTime = true;
					DataRow csvdataRow = null;

					while ((line = readFile.ReadLine()) != null)
					{
						line = line.Replace("\n", " ");
						/*while (line.Contains("\""))
						{
							string tex1 = line.Substring(0, line.IndexOf('"'));
							string tex2 = line.Substring(line.IndexOf('"') + 1, line.IndexOf('"', line.IndexOf('"')+1)).Replace(;

						}*/
						orginalRow = line.Replace(@"""", "").Split(delimeter, StringSplitOptions.None);
						if (orginalRow.Length == 1)
						{
							orginalRow = new string[] { };
							if (delimeter[0] == ";")
								delimeter[0] = ",";
							else
								delimeter[0] = ";";
							orginalRow = line.Split(delimeter, StringSplitOptions.None);

						}
						if (onlyFirstTime)
						{
							onlyFirstTime = false;
							if (requriedHeader)
							{

								for (int i = 0; i < orginalRow.Length; i++)
								{
									if (csvDataTable.Columns.Contains(orginalRow[i]))
										csvDataTable.Columns.Add(new DataColumn((orginalRow[i].Replace(@"""", "")) + i.ToString(), typeof(string)));
									else
										csvDataTable.Columns.Add(new DataColumn((orginalRow[i].Replace(@"""", "")), typeof(string)));
								}

							}
							else
							{
								for (int i = 0; i < orginalRow.Length; i++)
								{
									/*if (csvDataTable.Columns.Contains(orginalRow[i]))
										csvDataTable.Columns.Add(new DataColumn(orginalRow[i] + i.ToString(), typeof(string)));
									else
										csvDataTable.Columns.Add(new DataColumn(orginalRow[i], typeof(string)));*/
									csvDataTable.Columns.Add(new DataColumn("Colonne" + i.ToString(), typeof(string)));
								}

								//ajout line
								csvdataRow = csvDataTable.NewRow();
								csvdataRow.ItemArray = orginalRow;
								csvDataTable.Rows.Add(csvdataRow);
							}
						}
						else
						{
							csvdataRow = csvDataTable.NewRow();
							csvdataRow.ItemArray = orginalRow;
							csvDataTable.Rows.Add(csvdataRow);
						}
					}
				}
			}
			catch (Exception ex)
			{ throw ex; }
			return csvDataTable;
		}

        
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			nPAVilleToolStripMenuItem.PerformClick();
		}
        
		private void toolStripButton10_Click(object sender, EventArgs e)
		{
			//button2_Click(sender, e);
		}
        
		private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void déconnexionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Menu1.Enabled = false;
			ToolBar1.Enabled = false;
			panel1.Enabled = false;
			panel3.Visible = true;
			edMdp.Text = "";
			edUser.Text = "";
			this.StatusLabel.Text = "Déconnexion réussie de : " + lUser;
		}

		private void toolStripButton14_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
        
		
		private void toolStripMenuItem8_Click(object sender, EventArgs e)
		{
			//(button2, e);    
		}
        
		
		private void edUser_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				button5_Click(button5, new EventArgs());
			//MessageBox.Show(((int)e.KeyChar).ToString());
		}

		private void edMdp_Enter(object sender, EventArgs e)
		{
			edMdp.SelectAll();
		}

		private void edUser_Enter(object sender, EventArgs e)
		{
			edUser.SelectAll();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Inif.ReadString("PARAM", "posX") == "")
			{
				string[] lines = { "\n", "[PARAM]", "posX = " + this.Left.ToString(), "posY = " + this.Top.ToString() };
				System.IO.File.AppendAllLines(Environment.CurrentDirectory + "\\Deltareal.ini", lines);
			}
						/*else
			{*/
				rtB.LoadFile(Environment.CurrentDirectory + "\\Deltareal.ini", RichTextBoxStreamType.PlainText);
				string[] linesa = rtB.Lines;
				for (int i = 0; i < rtB.Lines.Length; i++)
				{
					if (rtB.Lines[i].ToString().Contains("posX"))
						linesa[i] = "posX = " + this.Left.ToString();
						//rtB.Lines[i] = "posX = " + this.Left.ToString();
					if (rtB.Lines[i].ToString().Contains("posY"))
						linesa[i] = "posY = " + this.Top.ToString();
						//rtB.Lines[i] = "posY = " + this.Top.ToString();
					
					
				}
				rtB.ResetText();
				for (int u = 0; u < linesa.Length; u++)
				{
					if (linesa[u].ToString().Trim() != "")
						rtB.AppendText(linesa[u].ToString() + "\n");
				}
				rtB.SaveFile(Environment.CurrentDirectory + "\\Deltareal.ini", RichTextBoxStreamType.PlainText);
			//}
			
		}
        
		public string DeviceID { get; set; }

		
		
		private void exportcloturewatch_Click(object sender, EventArgs e)
		{
			
		}

		private void button3_Click_1(object sender, EventArgs e)
		{

		}
        
		private void edMdp_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				button5_Click(button5, new EventArgs());
		}
        
        private void deltaConMod_StateChange(object sender, StateChangeEventArgs e)
        {
            if (!bclosing && e.CurrentState != ConnectionState.Connecting && (e.CurrentState == ConnectionState.Closed || e.CurrentState == ConnectionState.Broken))
                deltaConMod.Open();
        }

        private void deltaConTmp2_StateChange(object sender, StateChangeEventArgs e)
        {
            if (!bclosing && e.CurrentState != ConnectionState.Connecting && (e.CurrentState == ConnectionState.Closed || e.CurrentState == ConnectionState.Broken))
                deltaConTmp2.Open();
        }

        private void DeltaConTmp1_StateChange(object sender, StateChangeEventArgs e)
        {
            if (!bclosing && e.CurrentState != ConnectionState.Connecting && (e.CurrentState == ConnectionState.Closed || e.CurrentState == ConnectionState.Broken))
                DeltaConTmp1.Open();
        }

        private void bt_marchandises_Click(object sender, EventArgs e)
        {
            f_marchandises f2 = new f_marchandises();
            
            f2.comrealvista.Connection = DeltaCon;
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void bt_client_Click(object sender, EventArgs e)
        {
            f_client f2 = new f_client();

            f2.comrealvista.Connection = DeltaCon;
            f2.comrealvistamod.Connection = deltaConMod;
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void bt_debiteur_Click(object sender, EventArgs e)
        {
            f_debiteur f2 = new f_debiteur();

            f2.comrealvista.Connection = DeltaCon;
            f2.comrealvistamod.Connection = deltaConMod;
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void bt_facture_Click(object sender, EventArgs e)
        {
            f_gesfact f2 = new f_gesfact();

            f2.comaffichefacture.Connection = DeltaCon;
            f2.comrealvistamod.Connection = deltaConMod;
            f2.comrech.Connection = deltaConMod;
            f2.Owner = this;
            f2.ShowDialog();
        }

        public decimal dtvachf = 0;
        public int iecheance = 20;
        public string nombasecompta = "";
        public string comptedebit = "";
        public string compteb = "";
        public string comptefacture = "";
        private void cmbentreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbentreprise.SelectedIndex > -1)
            {
                cmbentreprisesource.SelectedIndex = cmbentreprise.SelectedIndex;
                string sql = "SELECT fact_entreprise.*, typetva.taux as tauxtva, typetva.idtva FROM fact_entreprise LEFT JOIN typetva ON typetva.idtva = fact_entreprise.idtauxtva where identreprise =" + cmbentreprisesource.SelectedValue.ToString();
                DeltaSQLCon.CommandText = sql;
                MySqlDataReader mr = DeltaSQLCon.ExecuteReader();
                if (mr.Read())
                {
                    identreprisesel = cmbentreprisesource.SelectedValue.ToString();
                    decimal.TryParse(Util.GetValue(mr, "tauxtva"), out dtvachf);
                    int.TryParse(Util.GetValue(mr, "echeance"), out iecheance);
                    nombasecompta = Util.GetValue(mr, "basededonnees");
                    comptedebit = Util.GetValue(mr, "comptedebit");
                    compteb = Util.GetValue(mr, "compteb");
                    comptefacture = Util.GetValue(mr, "comptefacture");

                }
                mr.Close();
            }
        }

        private void importationFactureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_importation f = new f_importation();
            f.Owner = this;
            f.comrealvistamod.Connection = DeltaSQLCon.Connection;
            f.comrech.Connection = DeltaSQLTmp.Connection;
            if (f.ShowDialog() == DialogResult.OK)
                bt_facture_Click(bt_facture, new EventArgs());
        }

        public string Maxsuivant(string sTable, string sChamp, string scond)
        {
            //int iCount = GetRecordCount(QC, sTable, "");
            DeltaSQLTmp.CommandText = "SELECT (max(" + sChamp + ") + 1) as tmp FROM " + sTable;
            if (scond != "")
                DeltaSQLTmp.CommandText = DeltaSQLTmp.CommandText + " WHERE " + scond;
            MySql.Data.MySqlClient.MySqlDataReader Q = DeltaSQLTmp.ExecuteReader();
            //Q.Read();
            string Ret = "";

            //if (Q.RecordCount != 0)
            //if (iCount != 0)
            if (Q.Read() && Q.GetValue(Q.GetOrdinal("tmp")).ToString() != "")
            {
                Ret = Q.GetValue(Q.GetOrdinal("tmp")).ToString();
            }
            else
                Ret = "1";
            Q.Close();
            return Ret;
        }

        private void importationPaiementToolStripMenuItem_Click(object sender, EventArgs e)
        {

            f_paiement f = new f_paiement();
            f.comrech.Connection = DeltaSQLTmp.Connection;
            f.comrealvistamod.Connection = DeltaSQLCon.Connection;
            //f.numfact = s;
            f.typefen = 2;
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                f_gesfact f2 = new f_gesfact();

                f2.comaffichefacture.Connection = DeltaCon;
                f2.comrealvistamod.Connection = deltaConMod;
                f2.comrech.Connection = deltaConMod;
                f2.Owner = this;
                f2.loadfrompaiement = true;
                f2.ShowDialog(this);
            }
        }

        private void DeltaCon_InfoMessage(object sender, MySqlInfoMessageEventArgs args)
        {
             
        }

        private void DeltaCon_StateChange(object sender, StateChangeEventArgs e)
        {
            if (!bclosing && e.CurrentState != ConnectionState.Connecting && ( e.CurrentState == ConnectionState.Closed || e.CurrentState == ConnectionState.Broken))
                DeltaCon.Open();
        }
        

	}
}