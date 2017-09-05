using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace DeltaFact
{
    public partial class f_debiteur : Form
    {
        public f_debiteur()
        {
            InitializeComponent();
        }

        util_fact uf = new util_fact();
        public int etat = 0;
        string reqdon = "";
        string reqarch = "";
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);

        private void f_debiteur_Load(object sender, EventArgs e)
        {
            //lb_entreprise.Text = uf.ValeurParCond(comrealvista, "fact_entreprise entreprise left join " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal", "if (entreprise.iddeltareal > 0, concat(clidelta.socligne1, ' ', clidelta.socligne2), concat(entreprise.socligne1, ' ', entreprise.socligne2)) as entreprise", "entreprise", "identreprise = " + Fmain.identreprisesel);
            uf.initialisation(p_affiche);
            string sz = "SELECT idCity, zip, cityname FROM " + Fmain.baseInit + ".City ORDER BY Zip";
            comrealvista.CommandText = sz;
            MySqlDataReader myReader;
            myReader = comrealvista.ExecuteReader();
            while (myReader.Read())
            {
                npa.charger(myReader.GetValue(myReader.GetOrdinal("zip")).ToString(),
                    myReader.GetValue(myReader.GetOrdinal("cityname")).ToString(),
                    myReader.GetValue(myReader.GetOrdinal("idcity")).ToString());
                ville.charger(myReader.GetValue(myReader.GetOrdinal("cityname")).ToString(),
                    myReader.GetValue(myReader.GetOrdinal("zip")).ToString(),
                    myReader.GetValue(myReader.GetOrdinal("idcity")).ToString());
                
            }
            ville.drom.dataGridView1.Sort(ville.drom.dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            myReader.Close();

            uf.RemplirCombo(politesse, "SELECT politesse, idpolitesse FROM " + Fmain.baseInit + ".typepolitesse ORDER by idlangue, idpolitesse", comrealvista, mySqlDataAdapter1);
            
            reqdon = "select cli.idclient as refclient, socligne as raisonsociale, pol.idlangue as idlanguage, lang.language as language, " +
                "cli.idpolitesse as idpolitesse, pol.politesse as politesse, cli.nom, cli.prenom, cli.co, " +
                "cli.adresse1 as adresse1, cli.adresse2 as adresse2, city.zip as npa, city.cityname as ville, " +
                "cli.idville as idville, cli.telpro as telpro, cli.telmob as telmob, " +
                "cli.fax as fax, cli.email as email " +
                "FROM fact_client cli " +
                "LEFT join " + Fmain.baseInit + ".typepolitesse pol ON pol.idpolitesse = cli.idpolitesse LEFT join " + Fmain.baseInit + ".language lang ON lang.idlanguage = pol.idlangue " +
                "left join " + Fmain.baseInit + ".city ON city.idcity = cli.idville " +
                "ORDER BY idclient, nom, prenom, socligne";
            reqarch = reqdon.Replace("fact_client", "fact_clientarchive").Replace("select", "select cli.idarchive as refarchive, cli.datearchive, ");
            if (etatrech == 0 && etatajoutimport == 0)
                affichedonnees(reqdon);
            else if (etatajoutimport > 0)
            {
                recherche(false, "", ((f_importation)fImport).GetDonnee("socligne"), ((f_importation)fImport).GetDonnee("nom"), ((f_importation)fImport).GetDonnee("prenom"), "", ((f_importation)fImport).GetDonnee("zip"));
                //recherche noprenom, soclign si existe. Si resultat, remplir grille par recherche, sinon ajout
                if (gv_client.RowCount == 0)
                {
                    AfficherDonneesAjout(true);
                    bt_valider_Click(bt_valider, new EventArgs());
                }
                else
                {
                    AfficherDonneesAjout(false);
                }
            }

        }
        public int etatajoutimport = 0;
        private void annule() //affichage du client en cours
        {
            bt_recherche.Text = "recherche";
            p_button.Enabled = true;
            refclient.Enabled = false;
            uf.enablecontrol(p_button, "2", false);
            uf.enablecontrol(p_button, "1", false);
            bt_ajout.Enabled = true;
            if (curligne > gv_client.RowCount - 1)
                curligne = gv_client.RowCount - 1;
            if (curligne > -1 && bt_recherche.Text == "recherche")
            {
                gv_client.Rows[curligne].Selected = true;
                gv_client.CurrentCell = gv_client.Rows[curligne].Cells[1];
            }
            if (gv_client.RowCount > 0 && gv_client.CurrentRow.Index > -1)
            {
                uf.afficherInfo(p_affiche, reqdon.Replace("ORDER", "WHERE cli.idclient =" + gv_client.CurrentRow.Cells["g_refclient"].Value.ToString() + " ORDER"), comrealvista, null, "");
                uf.enablemulticontrol(p_button, "1", "2");
            }
            else
                uf.initcontrol(p_affiche, "", raisonsociale);
            p_button.Focus();
            if (refclient.Text.Trim() != "")
                valclient = prendrevaleurclient();
            uf.enablecontrol(p_affiche, "2", false);
            bt_recherche.Enabled = true;
            remplirarchive();
            etat = 0;
        }

        private void affichedonnees(string sql)
        {
            uf.afficherInfo(this, sql, comrealvista, gv_client, "");
            if (gv_client.RowCount == 0)
                bt_modif.Enabled = bt_suppr.Enabled = false;
            
            if (etatajoutimport == 0)
                annule();
            //string sz = reqdon.Replace("ORDER", "WHERE deb.iddebiteur =" + g_debiteur.Rows[0].Cells["g_refdebiteur"].Value.ToString() + " ORDER");

            //uf.afficherInfo(this, sz, comrealvista, null, "");
        }

        private void remplirarchive()
        {
            l_archive.ValueMember = "idarchive";
            l_archive.DisplayMember = "datearchive";
            uf.RemplirCombo(l_archive, "SELECT date_format(datearchive, '%d.%m.%Y') as datearchive, idarchive FROM fact_clientarchive WHERE idclient = '" + refclient.Text + "' ORDER BY datearchive DESC", comrealvistamod, mySqlDataAdapter1);
            affichearchive();
        }
        private void affichearchive()
        {
            //if (l_archive.SelectedItems.Count == 0) 
            //{
                uf.initcontrol(p_archive, "12", refarchive_1);

            //}
            //else
            //{
            if (l_archive.SelectedItems.Count > 0)
                uf.afficherInfo(p_archive, reqarch.Replace("ORDER", "WHERE cli.idarchive =" + l_archive.SelectedValue.ToString() + " ORDER"), comrealvista, null, "");
                //uf.afficherInfo(this, reqarch.Replace("ORDER", "WHERE cli.idarchive =" + gv_client.CurrentRow.Cells["g_refclient"].Value.ToString() + " ORDER"), comrealvista, null, "");
            //}

        }

        private void bt_modif_Click(object sender, EventArgs e)
        {
            etat = 1;
            modifajout();
        }

        

        public void modifajout()
        {
            //etat ==> 1 MODIF  2 AJOUT
            uf.enablemulticontrol(p_button, "2", "1");
            uf.enablecontrol(p_affiche, "2", true);
            if (etat == 2)
            {
                uf.initcontrol(p_archive, "", refarchive_1);
                l_archive.DataSource = null;
                uf.initcontrol(p_affiche, "", raisonsociale);
                int newcli = numclisuivant();
                refclient.Text = newcli.ToString();
            }
        }

        private int numclisuivant()
        {
            int numsuiv = 0;
            
            string listeexistant = uf.ValeurParCond(comrealvistamod, "fact_client", "group_concat(idclient) as listecli", "listecli", "idclient > 0 order by idclient", "SET SESSION group_concat_max_len = 10000000;") ;

            if (listeexistant != "")
            {
                string liste = "";
                string[] se = listeexistant.Split(',');
                int maxi = int.Parse( se[se.Length - 1]);
                string[] sorig = new string[maxi];
                for (int i = 0; i < maxi; i++)
                {
                    sorig[i] = (i + 1).ToString();
                }
                
                for (int i =0; i< sorig.Length; i++)
                {
                    if (se[i] == sorig[i])
                        continue;
                    else
                    {
                        numsuiv = int.Parse(sorig[i]);
                        return numsuiv;
                    }
                }

                return maxi + 1;

            }
            else
                numsuiv = 0;
            return numsuiv + 1;
        }

        private void bt_ajout_Click(object sender, EventArgs e)
        {
            etat = 2;
            
            modifajout();
        }

        Form fImport = Application.OpenForms["f_importation"];

        public void remonterlignesuivant()
        {
            if (((f_importation)fImport).gvins.CurrentRow.Index == ((f_importation)fImport).gvins.RowCount - 1)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }

            for (int rw = ((f_importation)fImport).gvins.CurrentRow.Index + 1; rw < ((f_importation)fImport).gvins.RowCount; rw++)
            {
                //Tester si débiteur vide existe encore. Ligne par ligne. Si oui afficher.
                ((f_importation)fImport).gvins.CurrentCell = ((f_importation)fImport).gvins.Rows[rw].Cells["idclient"];
                if (((f_importation)fImport).GetDonnee("idclient").Trim() == "")
                {
                    recherche(false, "", ((f_importation)fImport).GetDonnee("socligne"), ((f_importation)fImport).GetDonnee("nom"), ((f_importation)fImport).GetDonnee("prenom"), "", ((f_importation)fImport).GetDonnee("zip"));
                    //recherche noprenom, soclign si existe. Si resultat, remplir grille par recherche, sinon ajout
                    if (gv_client.RowCount == 0)
                    {
                        AfficherDonneesAjout(true);
                        bt_valider_Click(bt_valider, new EventArgs());
                    }
                    else
                        AfficherDonneesAjout(false);
                    break;
                }
                else
                {
                    if (rw == ((f_importation)fImport).gvins.RowCount - 1)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void AfficherDonneesAjout(bool ajout)
        {
            if (ajout)
            {
                etat = 2;
                modifajout();
            }
            else
            {
                etat = 2;
                modifajout();
            }
            if (((f_importation)fImport).gvins.Columns.Contains("socligne")) 
                raisonsociale.Text = ((f_importation)fImport).GetDonnee("socligne");
            if (((f_importation)fImport).gvins.Columns.Contains("politesse"))
                politesse.SelectedValue = ((f_importation)fImport).GetDonnee("politesse");
            nom.Text = ((f_importation)fImport).GetDonnee("nom");
            prenom.Text = ((f_importation)fImport).GetDonnee("prenom");
            if (((f_importation)fImport).gvins.Columns.Contains("co"))
                co.Text = ((f_importation)fImport).GetDonnee("co");
            if (((f_importation)fImport).gvins.Columns.Contains("adresse1"))
                adresse1.Text = ((f_importation)fImport).GetDonnee("adresse1");
            if (((f_importation)fImport).gvins.Columns.Contains("adresse2"))
                adresse2.Text = ((f_importation)fImport).GetDonnee("adresse2");
            npa.IndCombo = ((f_importation)fImport).GetDonnee("idcity");
            ville.IndCombo = ((f_importation)fImport).GetDonnee("idcity");
            //npa.textBox1.Text = ((f_importation)fImport).GetDonnee("zip");
            //ville.textBox1.Text = ((f_importation)fImport).GetDonnee("cityname");
            
            if (((f_importation)fImport).gvins.Columns.Contains("telmob"))
                telmob.Text = ((f_importation)fImport).GetDonnee("telmob");
            if (((f_importation)fImport).gvins.Columns.Contains("telpro"))
                telpro.Text = ((f_importation)fImport).GetDonnee("telpro");
            if (((f_importation)fImport).gvins.Columns.Contains("fax"))
                fax.Text = ((f_importation)fImport).GetDonnee("fax");
            if (((f_importation)fImport).gvins.Columns.Contains("emai"))
                email.Text = ((f_importation)fImport).GetDonnee("email");
            
        }

        private void bt_annul_Click(object sender, EventArgs e)
        {
            annule();
            etat = 0;
        }

        private string valtexte(TextBox txt)
        {
            if (txt.Name.Contains("tel") || txt.Name.Contains("fax") || txt.Name.Contains("mob"))
                return txt.Text.Replace(" ", "");
            else
                return txt.Text.Trim();
        }

        int curligne = -1;

        private void enregistrerclient()
        {
            if (valtexte(raisonsociale) == "" && valtexte(nom) == "" && valtexte(prenom) == "" )
            {
                uf.message_info("Veuillez saisir la raison sociale, ou les champs nom/prénom !");
                return;
            }
            if (politesse.SelectedIndex < 0)
            {
                uf.message_info("Veuillez définir la politesse !");
                return;
            }
            string champ = "";
            string val = "";

            champ = "idclient, socligne, nom, prenom, idpolitesse, adresse1, adresse2, co, idville, telpro, telmob, fax, email";
            if (etat == 2)
            {
                refclient.Text = numclisuivant().ToString();
            }
            val = valtexte(refclient) + "$" + valtexte(raisonsociale) + "$" + valtexte(nom) + "$" + valtexte(prenom) + "$" + uf.valcombo(politesse) + "$" + valtexte(adresse1) + "$" + valtexte(adresse2) + "$"
                + valtexte(co) + "$" + npa.IndCombo + "$" + valtexte(telpro) + "$" + valtexte(telmob) + "$" + valtexte(fax) + "$" + valtexte(email);

            if (etat == 2)
            {
                
                string newid = uf.executeSQL(comrealvista, "fact_client", champ, val, etat, "");
                if (etatajoutimport > 0)
                {
                    ((f_importation)(fImport)).gvins.CurrentRow.Cells["idclient"].Value = newid;
                    remonterlignesuivant();
                    return;
                }
                uf.afficherInfo(this, reqdon.Replace("ORDER", "WHERE idclient=" + newid + " ORDER"), comrealvista, gv_client, "");
                annule();
            }
            else if (etat == 1)
            { 
                uf.executeSQL(comrealvista, "fact_client", champ, val, etat, "idclient = " + gv_client.CurrentRow.Cells["g_refclient"].Value.ToString());
            
                if (uf.confirmer_questionON(this, "Archiver la dernière adresse ?") == DialogResult.Yes)
                {
                    enregistrerarchive();
                }
                curligne = gv_client.CurrentRow.Index;
                annule();

            }
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            enregistrerclient();
            
            
        }

        private void g_debiteur_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //string g = sender.GetType().Name;
        }

        private void g_debiteur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gv_client.RowCount > 0)
                curligne = gv_client.CurrentRow.Index;
            if (etatajoutimport == 0)
                annule();
        }

        private void bt_suppr_Click(object sender, EventArgs e)
        {
            if (uf.ValeurParCond(comrealvistamod, "fact_facturation", "idfacture, idclient", "idfacture", "idclient = " + refclient.Text ) != "")
            {
                uf.AfficherErreur("Attention, ce client a déjà une facture !");
                return;
            }
            if (uf.confirmer_questionON(this, "Etes-vous sûre de supprimer cette ligne ?") == DialogResult.No)
            {
                annule();
                return;
            }
            uf.executeSQL(comrealvista, "fact_client", "", "", 3, "idclient = " + gv_client.CurrentRow.Cells["g_refclient"].Value.ToString());
            uf.executeSQL(comrealvista, "fact_clientarchive", "", "", 3, "idclient = " + gv_client.CurrentRow.Cells["g_refclient"].Value.ToString());
            gv_client.Rows.Remove(gv_client.CurrentRow);
            annule();
            
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void edInternet_TextChanged(object sender, EventArgs e)
        {

        }

        private void npa_Combo_DropDown(object sender, EventArgs e)
        {
            ville.IndCombo = npa.IndCombo;
        }

        private void ville_Combo_DropDown(object sender, EventArgs e)
        {
            npa.IndCombo = ville.IndCombo;
        }

        private void ville_Combo_DropUp(object sender, EventArgs e)
        {
            npa.IndCombo = ville.IndCombo;
            npa.drom.Visible = false;
        }

        private void npa_Combo_DropUp(object sender, EventArgs e)
        {
            ville.IndCombo = npa.IndCombo;
            ville.drom.Visible = false;
        }

        
        private void tauxtva_KeyPress(object sender, KeyPressEventArgs e)
        {
            uf.TestKey(e, true);
        }

        public int etatrech = 0;
        public void bt_recherche_Click(object sender, EventArgs e)
        {
            if (bt_recherche.Text == "recherche")
            {
                p_button.Enabled = false;
                refclient.Enabled = raisonsociale.Enabled = nom.Enabled = prenom.Enabled = adresse1.Enabled = npa.Enabled = ville.Enabled = true;
                uf.initcontrol(p_affiche, "2", refclient);
                refclient.Text = "";
                bt_recherche.Text = "valider rech.";
            }
            else
            {
                recherche(true, valtexte(refclient), valtexte(raisonsociale), valtexte(nom), valtexte(prenom), valtexte(adresse1), npa.textBox1.Text);
                bt_recherche.Text = "recherche";
            }

        }

        private string recherche(bool panneau,  string rrefclient, string rraisonsociale, string rnom, string rprenom, string radresse, string rnpa)
        {
            string ret = "";

            if (panneau)
            {
                rrefclient = valtexte(refclient);
                rraisonsociale = valtexte(raisonsociale);
                rnom = valtexte(nom);
                rprenom = valtexte(prenom);
                rnpa = npa.textBox1.Text;
                if (rrefclient == "" && rraisonsociale == "" && rnom == "" && rprenom == "" && rnpa == "")
                {
                    uf.AfficherErreur("Veuillez saisir vos critères de recherche !");
                    return "";
                }
            }
            string cond = "";
            string ordre = "";
            if (rrefclient != "")
            {
                cond = "idclient = " + rrefclient;
                ordre = "idclient Asc";
            }
            else
            {
                cond = "idclient > 0 and (idclient =-1 ";
                ordre = "idclient = 0";
                if (rraisonsociale != "")
                {
                    cond += "OR socligne LIKE \"%" + rraisonsociale + "%\" ";
                    ordre += ", socligne = \"" + rraisonsociale + "\" desc";
                }
                if (rnom != "")
                {
                    cond += "OR nom LIKE \"%" + rnom + "%\" ";
                    ordre += ", nom = \"" + rnom + "\" desc";
                }
                if (rprenom != "")
                {
                    cond += "OR prenom LIKE \"%" + rprenom + "%\" ";
                    ordre += ", prenom = \"" + rprenom + "\" desc";
                }
                if (radresse != "")
                { 
                    cond += "OR adresse1 LIKE \"%" + radresse + "%\" OR adresse2 LIKE \"%" + radresse + "%\" ";
                    ordre += ", adresse1 = \"" + radresse + "\" desc";
                }
                cond += ") ";
                if (rnpa != "")
                    cond += "AND zip = \"" + rnpa + "\" ";
                
            }

            string sqlrech = reqdon.Replace("ORDER BY", "WHERE " + cond + " ORDER BY " + ordre + ",");
            affichedonnees(sqlrech);
            return ret; 
        }

        private void bt_toutafficher_Click(object sender, EventArgs e)
        {
            affichedonnees(reqdon);
        }

        string[] valclient; 
        private string[] prendrevaleurclient()
        {
            string[] ret = new string[] { valtexte(raisonsociale), politesse.SelectedValue.ToString(), valtexte(nom), valtexte(prenom), valtexte(co), valtexte(adresse1), valtexte(adresse2), npa.IndCombo, valtexte(telpro), valtexte(telmob), valtexte(fax), valtexte(email) };

            return ret;
        }

        private void p_affiche_Validating(object sender, CancelEventArgs e)
        {
            
        }
        string h = "";
        private void p_affiche_Validated(object sender, EventArgs e)
        {
           

        }

        private void p_affiche_Leave(object sender, EventArgs e)
        {
           /* bool modif = false;
            string[] newval = prendrevaleurclient();
            for (int i = 0; i < valclient.Length; i++)
            {
                if (valclient[i] != newval[i])
                {
                    modif = true;
                    break;
                }
            }
            if (modif)
            {
                if (uf.confirmer_questionON(this, "Enregistrer la modification ?") == DialogResult.Yes)
                {
                    if (etat == 0)
                        etat = 1;
                    //uf.executeSQL(comrealvistamod, "fact_client", )
                    bt_valider_Click(bt_valider, new EventArgs());
                    return;
                    //e.Cancel = true;
                }
                else
                {
                    annule();
                    //e.Cancel = true;
                }
            }*/
        }

        private void enregistrerarchive()
        {
            string champ = "";
            string val = "";

            champ = "idclient, socligne, idpolitesse, nom, prenom, co, adresse1, adresse2, idville, telpro, telmob, fax, email, datearchive";

            val = refclient.Text + "$" + valclient[0] + "$" + valclient[1] + "$" + valclient[2] + "$" + valclient[3] + "$" + valclient[4] + "$" + valclient[5] + "$"
                + valclient[6] + "$" + valclient[7] + "$" + valclient[8] + "$" + valclient[9] + "$" + valclient[10] + "$" + valclient[11] + "$" + DateTime.Now.ToString();

            uf.executeSQL(comrealvista, "fact_clientarchive", champ, val, 2, "");
            //else if (etat == 1)
            //    uf.executeSQL(comrealvista, "fact_client", champ, val, etat, "idclient = " + gv_client.CurrentRow.Cells["g_refclient"].Value.ToString());
        }

        private void f_debiteur_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (etat != 0 && etatajoutimport == 0)
            {
                if (uf.confirmer_questionON(this, "Enregistrer la modification ?") == DialogResult.Yes)
                {
                    enregistrerclient();
                   
                }
                etat = 0;
            }
        }

        private void l_archive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (l_archive.SelectedIndex > -1)
            {
                affichearchive();
            }
        }

        private void bt_ajoutfact_Click(object sender, EventArgs e)
        {
            if (refclient.Text.Trim() == "")
                return;
            if (Application.OpenForms["f_gesfact"] == null)
            {
                f_gesfact ffact = new f_gesfact();
                ffact.comaffichefacture.Connection = comrealvista.Connection;
                ffact.comrealvistamod.Connection = ffact.comrech.Connection = comrealvistamod.Connection;
                ffact.ajoutdepuisclient = true;
                ffact.curidcli = refclient.Text.Trim();
                this.DialogResult = DialogResult.OK;
                ffact.ShowDialog();
            }
            else
            {
                ((f_gesfact)(Application.OpenForms["f_gesfact"])).ajoutdepuisclient = true;
                ((f_gesfact)(Application.OpenForms["f_gesfact"])).curidcli = refclient.Text.Trim();
                this.DialogResult = DialogResult.OK;
                ((f_gesfact)(Application.OpenForms["f_gesfact"])).ajoutevent();
            }
        }

        private void nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (bt_recherche.Text == "valider rech.")
                    bt_recherche_Click(bt_recherche, new EventArgs());
            }
            else if (e.KeyChar == 27)
                bt_annul_Click(bt_annul, new EventArgs());
        }

        private void raisonsociale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (bt_recherche.Text == "valider rech.")
                    bt_recherche_Click(bt_recherche, new EventArgs());
            }
            else if (e.KeyChar == 27)
                bt_annul_Click(bt_annul, new EventArgs());
        }

        private void prenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (bt_recherche.Text == "valider rech.")
                    bt_recherche_Click(bt_recherche, new EventArgs());
            }
            else if (e.KeyChar == 27)
                bt_annul_Click(bt_annul, new EventArgs());
        }

        private void co_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (bt_recherche.Text == "valider rech.")
                    bt_recherche_Click(bt_recherche, new EventArgs());
            }
            else if (e.KeyChar == 27)
                bt_annul_Click(bt_annul, new EventArgs());
        }

        private void adresse1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (bt_recherche.Text == "valider rech.")
                    bt_recherche_Click(bt_recherche, new EventArgs());
            }
            else if (e.KeyChar == 27)
                bt_annul_Click(bt_annul, new EventArgs());
        }

        private void adresse2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (bt_recherche.Text == "valider rech.")
                    bt_recherche_Click(bt_recherche, new EventArgs());
            }
            else if (e.KeyChar == 27)
                bt_annul_Click(bt_annul, new EventArgs());
        }

        private void gv_client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (etatajoutimport == 0)
                bt_ajoutfact_Click(bt_ajoutfact, new EventArgs());
            else
            {
                ((f_importation)fImport).gvins.CurrentRow.Cells["idclient"].Value = gv_client.CurrentRow.Cells["g_refclient"].FormattedValue.ToString();
                remonterlignesuivant();
            }
        }

        private void refclient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (bt_recherche.Text == "valider rech.")
                    bt_recherche_Click(bt_recherche, new EventArgs());
            }
            else if (e.KeyChar == 27)
                bt_annul_Click(bt_annul, new EventArgs());
        }
    }
}
