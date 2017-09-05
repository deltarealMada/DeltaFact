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
    public partial class f_client : Form
    {
        public f_client()
        {
            InitializeComponent();
        }

        util_fact uf = new util_fact();
        public int etat = 0;
        string reqdon = "";
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);
        string nombasecompta = "";
        
        private void f_client_Load(object sender, EventArgs e)
        {
            uf.initialisation(p_client);
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


            uf.RemplirCombo(tauxtva, "SELECT idtva as idtauxtva, taux, desctva, concat(taux, '>', desctva) as tva FROM typetva order by idtva", comrealvista, mySqlDataAdapter1);
            uf.RemplirCombo(monnaie, "SELECT idmonnaie, monnaie FROM fact_monnaie ORDER by (idmonnaie='F') DESC", comrealvista, mySqlDataAdapter1);
            uf.RemplirCombo(politesse, "SELECT politesse, idpolitesse FROM " + Fmain.baseInit + ".typepolitesse ORDER by idlangue, idpolitesse", comrealvista, mySqlDataAdapter1);
            //uf.RemplirCombo(compte, "SELECT codecompte, idcompte FROM " + Fmain.baseInit + ".cpta_compte where codecompte like '25%' AND length(codecompte) > 3 ORDER BY codecompte ", comrealvista, mySqlDataAdapter1);
            //uf.remplircombo(language, comrealvista, "SELECT language, idlanguage FROM " + Fmain.baseInit + ".language ORDER by idlanguage");
            reqdon = Fmain.reqdoncli;

            uf.afficherInfo(this, reqdon, comrealvista, g_client, "");
            annule();
            /*
            //sz = sz.Replace("ORDER", "WHERE idarticle =" + g_article.Rows[0].Cells["g_idarticle"].Value.ToString() + " ORDER");
            if (g_client.RowCount > 0)
            {
                uf.afficherInfo(p_client, reqdon.Replace("ORDER", "WHERE client.identreprise =" + g_client.Rows[0].Cells["g_refentreprise"].Value.ToString() + " ORDER"), comrealvista, null, "");
                chargertypeadr(false, g_client.Rows[0].Cells["g_refentreprise"].Value.ToString(), "");
                if (l_adresses.Items.Count > 0)
                {
                    l_adresses.SelectedIndex = 0;
                    afficheadresse(g_client.Rows[0].Cells["g_refentreprise"].Value.ToString(), "");
                }
                affichefrais(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
                affichecommentaire(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            }
            else
            {
                uf.enablecontrol(p_adresse, "2", false);
                uf.enablecontrol(p_adresse, "4", false);

            }
            //affichedonnees();
            //uf.enablecontrol(p_affiche, "2", false);
            //uf.enablemulticontrol(p_button, "1", "2,3");

            uf.enablemulticontrol(p_button, "1", "2");
            uf.enablecontrol(p_client, "2", false);
            uf.enablecontrol(p_client, "3", false);
            uf.enablecontrol(p_client, "12", false);
            uf.enablecontrol(p_client, "8", false);
            pub.Enabled = false;
            if (g_client.RowCount == 0)
                bt_modif.Enabled = bt_suppr.Enabled = false;*/
        }

        string reqadresse = "";
        private void afficheadresse(string idclient, string iddelta)
        {
            uf.enablemulticontrol(p_adresse, "6", "4,5");

            string idfonction = "";
            if (l_adresses.Items.Count > 0)
            {
                idfonction = l_adresses.SelectedValue.ToString();
            }
            else
            {
                idfonction = "-1";
            }
            reqadresse = "SELECT if (client.iddeltareal > 0, foncdel.idfonctiondelta, fonccli.idfonction) as idfonction, langclient.idlanguage, langclient.language, " +
                "polclient.idpolitesse, polclient.politesse, if(client.iddeltareal > 0, foncdel.nomprenom, fonccli.nomprenom) as nomprenom, " +
                "if(client.iddeltareal > 0, foncdel.adresse1, fonccli.adresse1) as adresse1, if(client.iddeltareal > 0, foncdel.co, fonccli.co) as co, if(client.iddeltareal > 0, foncdel.adresse2, fonccli.adresse2) as adresse2, clicity.zip as npa, clicity.cityname as ville, " +
                "clicity.idcity as idville, if(client.iddeltareal > 0, foncdel.teldirect, fonccli.telpro) as telpro, if(client.iddeltareal > 0, foncdel.mobile, fonccli.telmob) as telmob, " +
                "if(client.iddeltareal > 0, foncdel.fax, fonccli.fax) as fax, if(client.iddeltareal > 0, foncdel.email, fonccli.email) as email, if(client.iddeltareal > 0, foncdel.adresseweb, fonccli.siteweb) as siteweb, " +
                "if(client.iddeltareal > 0, foncdel.idbanque, fonccli.idbanque) as idbanque, if(client.iddeltareal > 0, foncdel.comptebanque, fonccli.comptebanque) as comptebanque, " + //if(client.iddeltareal > 0, foncdel.ccp, fonccli.ccp) as ccp,
                "if(client.iddeltareal > 0, foncdel.ccp, fonccli.noccp) as noccp, if(client.iddeltareal > 0, '', fonccli.nobvr) as nobvr, if(client.iddeltareal > 0, '', fonccli.noremiseadherent) as noremiseadherent, " +
                "concat(banque.nombanque, ' - ', banque.adresse, ', ', banque.npa, ' ', banque.ville)  as banque " +
                "FROM fact_entreprise client " +
                "LEFT JOIN fact_entreprisefonction fonccli ON fonccli.identreprise = client.identreprise AND fonccli.idfonction = " + idfonction + " " +
                "LEFT JOIN " + Fmain.baseInit + ".clientfonction foncdel ON foncdel.idclient = client.iddeltareal AND foncdel.idfonctiondelta = " + idfonction + " " +
                "LEFT join " + Fmain.baseInit + ".typepolitesse polclient ON polclient.idpolitesse = if (client.iddeltareal > 0, foncdel.idpolitesse, fonccli.idpolitesse) " +
                "LEFT join " + Fmain.baseInit + ".language langclient ON langclient.idlanguage = polclient.idlangue " + //if (client.iddeltareal > 0, foncdel.idlanguage, fonccli.idlanguage) " +
                "left join " + Fmain.baseInit + ".city clicity ON clicity.idcity = if (client.iddeltareal > 0, foncdel.idville, fonccli.idville) " +
                "LEFT JOIn " + Fmain.baseInit + ".cpta_banque banque ON banque.idbanque = if (client.iddeltareal > 0, foncdel.idbanque, fonccli.idbanque) " +
                "ORDER by client.identreprise"; // iddeltareal> 0 asc, iddeltareal, client.idclient";"
            string sz = "";
            if (iddelta == "")
                sz = reqadresse.Replace("ORDER", "WHERE client.identreprise =" + idclient + " ORDER");
            else
                sz = reqadresse.Replace("ORDER", "WHERE foncdel.idclient =" + idclient + " ORDER");

            uf.afficherInfo(p_adresse, sz, comrealvista, null, "");
            uf.enablecontrol(p_adresse, "2", false);
            if (g_client.RowCount > 0 && l_adresses.Items.Count > 0 && g_client.CurrentRow.Cells["g_iddeltareal"].Value.ToString() == "")
                uf.enablemulticontrol(p_adresse, "4", "5");
            if (l_adresses.Items.Count == 0 && g_client.CurrentRow.Cells["g_iddeltareal"].Value.ToString() == "")
                bt_adrajout.Enabled = true;
              
        }

        private void chargertypeadr(bool nouveau, string idclient, string iddelta)
        {
            string idc = "";
            if (idclient != "")
                idc = idclient;
            else if (iddelta != "")
                idc = iddelta;
            string reqtypeadr = "SELECT typefonction.nomfonction, typefonction.idfonction  " +
                "from  " + Fmain.baseInit + ".typefonction left join " +
                "(SELECT typef.idfonction, typef.nomfonction, typef.typefonction from " +
                "fact_entreprise client " +
                "LEFT JOIN fact_entreprisefonction fonccli ON fonccli.identreprise = client.identreprise " +
                "LEFT JOIN " + Fmain.baseInit + ".clientfonction foncdel ON foncdel.idclient = client.iddeltareal " +
                "left join " + Fmain.baseInit + ".typefonction typef on(typef.idfonction = (if (client.iddeltareal > 0, foncdel.idfonctiondelta, fonccli.idfonction)) and typef.typefonction = 'Deltareal') " +
                "where client.identreprise = " + idc + ") typeff ON typeff.idfonction = typefonction.idfonction where typefonction.typefonction = 'Deltareal'";
            if (nouveau)
                reqtypeadr += " AND typeff.nomfonction is null ";
            else
                reqtypeadr += " AND typeff.nomfonction is NOT null ";
            uf.RemplirCombo(l_adresses, reqtypeadr, comrealvistamod, mySqlDataAdapter1);
            uf.enablecontrol(p_client, "8", false);
            uf.initcontrol(p_client, "8", m_mttde);

        }

        private void bt_modif_Click(object sender, EventArgs e)
        {
            etat = 1;
            modifajout();
        }
        string reqfrais = "";

        private void affichefrais(string ident)
        {
            reqfrais = "SELECT idfraisprocedure, identreprise, facturede as mttde, facturea as mtta, frais as fraisproc, honoraire, interet FROM fact_fraisprocedure WHERE identreprise = " + ident + " ORDER BY facturede";
            uf.afficherInfo(p_client, reqfrais, comrealvistamod, gv_frais, "");

        }

        private void affichecommentaire(string ident)
        {
            reqfrais = "SELECT identretien, identreprise as identreprisecom, typecom, dateentretien as datecom, infos as commentaire FROM fact_entreprisehistory WHERE identreprise = " + ident + " ORDER BY datecom";
            uf.afficherInfo(p_client, reqfrais, comrealvistamod, gv_commentaire, "");
            uf.enablecontrol(p_client, "12", false);
            uf.initcontrol(p_client, "12", typecom);
        }

        private void annule()
        {
            if (curligne > -1)
            {
                g_client.Rows[curligne].Selected = true;
                g_client.CurrentCell = g_client.Rows[curligne].Cells[1];
            }
            if (g_client.RowCount > 0 && g_client.CurrentRow.Index > -1)
            {
                uf.afficherInfo(p_client, reqdon.Replace("ORDER", "WHERE client.identreprise =" + g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString() + " ORDER"), comrealvista, null, "");
                pub.Text = uf.ValeurParCond(comrealvistamod, "fact_entreprise", "pub", "pub", "identreprise =" + Fmain.identreprisesel);
                texterappel.Text = uf.ValeurParCond(comrealvistamod, "fact_entreprise", "texterappel", "texterappel", "identreprise =" + Fmain.identreprisesel);
                chargertypeadr(false, g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString(), "");
                afficheadresse(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString(), "");
                affichefrais(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
                affichecommentaire(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            }
            else
                uf.initcontrol(p_client, "", socligne1);
            uf.enablemulticontrol(p_button, "1", "2");
            uf.enablecontrol(p_client, "2", false);
            uf.enablecontrol(p_client, "3", false);
            uf.enablecontrol(p_client, "8", false);
            uf.enablecontrol(p_client, "12", false);
            pub.Enabled = false;
            texterappel.Enabled = false;
            if (g_client.RowCount == 0)
                bt_modif.Enabled = bt_suppr.Enabled = false;
            etat = 0;
            etatadr = 0;
            etatfrais = 0;
        }

        private void modifajout()
        {
            //etat ==> 1 MODIF  2 AJOUT
            uf.enablemulticontrol(p_button, "2", "1");
            if (iddeltareal.Text != "" && etat == 1)
                iddeltareal.Enabled = true;
            else
            {
                uf.enablecontrol(p_client, "2", true);

                //uf.enablecontrol(p_adresse, "2", true);
            }
            uf.enablecontrol(p_client, "3", true);
            pub.Enabled = texterappel.Enabled =  true;
            if (etat == 2)
            {
                uf.initcontrol(p_client, "", socligne1);
            }
        }

        private void bt_ajout_Click(object sender, EventArgs e)
        {
            etat = 2;
            modifajout();
        }

        private void bt_annul_Click(object sender, EventArgs e)
        {
            annule();
            etat = 0;
        }

        

        private void chargerclireal(string idcli)
        {
            string sz = "SELECT '' as refentreprise, cli.idclient as iddeltareal, cli.socligne1, cli.socligne2, " +
                "if(cli.tva = '', 0.00, cli.tva) as tauxtva from " + Fmain.baseInit + ".client cli  WHERE cli.idclient = " + idcli;
            socligne1.Text = "";
            /*"SELECT '' as refclient, cli.idclient as iddeltareal, concat(cli.socligne1, ' ', cli.socligne2) as raisonsociale, " +
               "clidelta.idlanguage as idlanguage, langfonc.language as language, " +
               "clidelta.idpolitesse, typepolfonc.politesse as politesse, " +
               "clidelta.nomprenom as administrateur, " +
               "clidelta.adresse1 as adresse, cityfonc.zip as npa, cityfonc.cityname as ville, " +
               "cityfonc.idcity as idville, clidelta.teldirect as telpro, clidelta.mobile as telmob, " +
               "clidelta.fax as fax, clidelta.email as email, clidelta.adresseweb as siteweb, " +
               "if(cli.tva = '', 0, cli.tva) as tauxtva from " + Fmain.baseInit + ".client cli left join " + Fmain.baseInit + ".clientfonction clidelta ON clidelta.idclient = cli.idclient " +
               "AND clidelta.idfonctiondelta = 9 left join " + Fmain.baseInit + ".typepolitesse typepolfonc ON typepolfonc.idpolitesse = clidelta.idpolitesse " +
               "LEFT join " + Fmain.baseInit + ".language langfonc ON langfonc.idlanguage = clidelta.idlanguage LEFT JOIN " + Fmain.baseInit + ".city cityfonc ON cityfonc.idcity = clidelta.idville WHERE cli.idclient = " + idcli;
            */

            uf.afficherInfo(p_client, sz, comrealvista, null, "");
            if (socligne1.Text == "")
                uf.AfficherErreur("Client Deltareal non trouvé !");
            else
            {
                uf.enablecontrol(p_client, "2", false);
                iddeltareal.Enabled = true;
            }
        }

        private string valtexte(TextBox txt)
        {
            string ret = txt.Text.Trim();
            if (txt.Name.Contains("id") && txt.Text.Trim() == "")
                ret = "0";
            return ret;
        }

        private string valcheck(CheckBox chk)
        {
            string ret = "0";
            if (chk.Checked)
                ret = "1";
            return ret;
        }


        int curligne = -1;
        private void bt_valider_Click(object sender, EventArgs e)
        {
            string champ = "";
            string val = "";
            //if (tauxtva.selec == "")
            //    tauxtva.Text = "0";
            if (iddeltareal.Text.Trim() == "0")
                iddeltareal.Text = "";
            champ = "socligne1, socligne2, idtauxtva, numtva, echeance, echeancerappel, infos, iddeltareal, basededonnees, comptedebit,compteb,comptefacture, pub, texterappel"; //adresse, idville, telpro, telmob, fax, email, siteweb, 

            if (iddeltareal.Text.Trim() == "")
            {
                val = valtexte(socligne1) + "$" + valtexte(socligne2) + "$" + tauxtva.SelectedValue.ToString()+ "$" + valtexte(numtva) +
                     "$" + valtexte(nbrecheance) + "$" + valtexte(echeancerappel) + "$" + valtexte(infos) + "$" + "0" + "$" + valtexte(basededonnees) + "$" + valtexte(compte) + "$" + valtexte(compteb) + "$" + valtexte(comptefacture) + "$" + pub.Text + "$" + texterappel.Text; //+ valtexte(adresse1) + "$" + npa.IndCombo + "$" + valtexte(telpro) + "$" + valtexte(telmob) + "$"
                                                                                                                  //"$" + valcheck(fraispourcent) + +valtexte(fax) + "$" + valtexte(email) + "$" + valtexte(siteweb) + "$" + valtexte(tauxtva) + "$"
            }
            else
            {
                val = "null" + "$" + "null" + "$" + tauxtva.SelectedValue.ToString() + "$" + valtexte(numtva) +
                     "$" + valtexte(nbrecheance) + "$" + valtexte(echeancerappel) + "$" + valtexte(infos) + "$" + valtexte(iddeltareal) + "$" + valtexte(basededonnees) + "$" + valtexte(compte) + "$" + valtexte(compteb) + "$" + valtexte(comptefacture) + "$" + pub.Text + "$" + texterappel.Text;
            }
            
            
               
            if (etat == 2)
                uf.executeSQL(comrealvista, "fact_entreprise", champ, val, etat, "");
            else if (etat == 1)
                uf.executeSQL(comrealvista, "fact_entreprise", champ, val, etat, "identreprise = " + g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            
            if (etat == 1)
                curligne = g_client.CurrentRow.Index;
            else
                curligne = g_client.RowCount - 1;
            uf.afficherInfo(this, reqdon, comrealvista, g_client, "politesse");
            annule();
        }

        private void g_client_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //string g = sender.GetType().Name;
        }

        private void g_client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (g_client.RowCount > 0)
                curligne = g_client.CurrentRow.Index;
            annule();
        }

        private void bt_suppr_Click(object sender, EventArgs e)
        {
            if (uf.confirmer_questionON(this, "Etes-vous sûre de supprimer cette ligne ?") == DialogResult.No)
            {
                annule();
                return;
            }
            uf.executeSQL(comrealvista, "fact_entreprise", "", "", 3, "identreprise = " + g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            uf.executeSQL(comrealvista, "fact_entreprisefonction", "", "", 3, "identreprise = " + g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            uf.executeSQL(comrealvista, "fact_fraisprocedure", "", "", 3, "identreprise = " + g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            g_client.Rows.Remove(g_client.CurrentRow);
            annule();
            
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
        

        private void iddeltareal_KeyPress(object sender, KeyPressEventArgs e)
        {
            uf.TestKey(e, false);
            if (e.KeyChar == 13)
            {
                if (iddeltareal.Text.Trim() == "")
                {
                    if (etat == 2)
                    {
                        bt_ajout_Click(bt_ajout, new EventArgs());
                        refentreprise.Focus();
                    }
                    else
                    {
                        annule();
                        iddeltareal.Text = "";
                        bt_modif_Click(bt_modif, new EventArgs());
                    }
                }
                else
                    chargerclireal(iddeltareal.Text.Trim());

            }    
        }

        private void tauxtva_KeyPress(object sender, KeyPressEventArgs e)
        {
            uf.TestKey(e, true);
        }

        private void l_adresses_Click(object sender, EventArgs e)
        {
            if (l_adresses.Items.Count > 0 && etatadr <= 1)
                afficheadresse(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString(), "");   
        }

        int etatadr = 0;
        private void bt_adrajout_Click(object sender, EventArgs e)
        {
            etatadr = 2;
            chargertypeadr(true, refentreprise.Text, "");
            modifajoutadr();
        }

        private void modifajoutadr()
        {

            //etat ==> 1 MODIF  2 AJOUT
            uf.enablemulticontrol(p_adresse, "5", "4");
            uf.enablecontrol(p_adresse, "2", true);

            if (etatadr == 2)
            {
                uf.initcontrol(p_adresse, "", l_adresses);
            }
        }

        private void bt_adrmodif_Click(object sender, EventArgs e)
        {
            etatadr = 1;
            modifajoutadr();
        }

        private void bt_adrannul_Click(object sender, EventArgs e)
        {
            /*chargertypeadr(false, g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString(), "");
            l_adresses_Click(l_adresses, e);*/
            annule();
        }

        private void men_affacturage_Opening(object sender, CancelEventArgs e)
        {
            if (g_client.SelectedRows.Count == 0)
                modifierLaLigneToolStripMenuItem.Enabled = supprimerLaLigneToolStripMenuItem.Enabled = ajouterUneLigneDeCalculToolStripMenuItem.Enabled = false;
            if (gv_frais.SelectedRows.Count == 0)
                modifierLaLigneToolStripMenuItem.Enabled = supprimerLaLigneToolStripMenuItem.Enabled = false;
            else
                modifierLaLigneToolStripMenuItem.Enabled = supprimerLaLigneToolStripMenuItem.Enabled = ajouterUneLigneDeCalculToolStripMenuItem.Enabled = true;

        }

        private void bt_adrvalider_Click(object sender, EventArgs e)
        {
            string champ = "";
            string val = "";

            champ = "identreprise, idfonction, nomprenom, idpolitesse, co, adresse1, adresse2, idville, telpro, telmob, fax, email, siteweb, idbanque, comptebanque, noccp, nobvr, noremiseadherent";

            val = valtexte(refentreprise) + "$" + uf.valliste(l_adresses) + "$" + valtexte(nomprenom) + "$" + uf.valcombo(politesse) +
                "$" + valtexte(co) + "$" + valtexte(adresse1) + "$" + valtexte(adresse2) + "$" + npa.IndCombo + "$" + valtexte(telpro) + "$" + valtexte(telmob) + 
                "$" + valtexte(fax) + "$" + valtexte(email) + "$" + valtexte(siteweb) + "$" + valtexte(idbanque) + "$" + valtexte(comptebanque) + "$" + valtexte(noccp) + "$" + valtexte(nobvr) + "$" + valtexte(noremiseadherent); //+ 

            if (etatadr == 2)
                uf.executeSQL(comrealvista, "fact_entreprisefonction", champ, val, etatadr, "");
            else if (etatadr == 1)
                uf.executeSQL(comrealvista, "fact_entreprisefonction", champ, val, etatadr, "idfonction = " + uf.valliste(l_adresses) + " and identreprise = " + g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            
            /*if (etatadr  == 1)
                curligne = l_adresses.SelectedIndex;
            else
                curligne = l_adresses.Items.Count;*/
            //uf.afficherInfo(this, reqdon, comrealvista, g_client, "politesse");
            annule();
        }

        int etatfrais = 0;
        private void ajouterUneLigneDeCalculToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uf.enablecontrol(p_client, "8", true);
            uf.initcontrol(p_client, "8", m_mttde);
            etatfrais = 2;
        }

        private void g_frais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uf.initcontrol(p_client, "8", m_mttde);
            if (gv_frais.SelectedRows.Count == 0)
                return;
            m_mttde.Text = gv_frais.CurrentRow.Cells["g_mttde"].FormattedValue.ToString();
            m_mtta.Text = gv_frais.CurrentRow.Cells["g_mtta"].FormattedValue.ToString();
            m_frais.Text = gv_frais.CurrentRow.Cells["g_fraisproc"].FormattedValue.ToString();
            m_honoraire.Text = gv_frais.CurrentRow.Cells["g_honoraire"].FormattedValue.ToString();
            m_interet.Text = gv_frais.CurrentRow.Cells["g_interet"].FormattedValue.ToString();
            uf.enablecontrol(p_client, "8", false);
            etatfrais = 0;
        }

        private void modifierLaLigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_frais_CellClick(gv_frais, new DataGridViewCellEventArgs(0, gv_frais.CurrentRow.Index));
            uf.enablecontrol(p_client, "8", true);
            //uf.initcontrol(p_client, "8", m_mttde);
            etatfrais = 1;
        }

        private void bt_fraisvalider_Click(object sender, EventArgs e)
        {
            string champ = "identreprise, facturede, facturea, frais, honoraire, interet";
            string val = g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString() + "$" + uf.formatsqldec(m_mttde) + "$" + uf.formatsqldec(m_mtta) + "$" + 
                uf.formatsqldec(m_frais) + "$" + uf.formatsqldec(m_honoraire) + "$" + uf.formatsqldec(m_interet);
            if (etatfrais == 1)
                uf.executeSQL(comrealvistamod, "fact_fraisprocedure", champ, val, 1, "idfraisprocedure = " + gv_frais.CurrentRow.Cells["g_idfraisprocedure"].Value.ToString());
            else if (etatfrais == 2)
                uf.executeSQL(comrealvistamod, "fact_fraisprocedure", champ, val, 2, "");

            affichefrais(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());
            uf.enablecontrol(p_client, "8", false);

            bt_valider.Enabled = false;
            etatfrais = 0;
        }

        private void supprimerLaLigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uf.confirmer_questionON(this, "Etes-vous sûre de supprimer cette ligne de frais ?") == DialogResult.Yes)
            {
                uf.executeSQL(comrealvista, "fact_fraisprocedure", "", "", 3, "idfraisprocedure = " + gv_frais.CurrentRow.Cells["g_idfraisprocedure"].Value.ToString());
                affichefrais(g_client.CurrentRow.Cells["g_refentreprise"].Value.ToString());

            }
        }

        private void ajouterCommentaireToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //gv_commentaire.Rows.Add(1);
            //gv_commentaire.EditMode = DataGridViewEditMode.EditOnF2;
            //gv_commentaire.Rows[gv_commentaire.RowCount - 1].Cells[0].Value = string.Format("{0:dd.MM.yyyy}", DateTime.Now);
            //gv_commentaire.BeginEdit(false);
            uf.enablecontrol(p_client, "12", true);
            uf.initcontrol(p_client, "12", typecom);
            typecom.Enabled = commentaire.Enabled = bt_comvalider.Enabled = true;
            etatcom = 1;
        }

        private void gv_commentaire_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == 13 && e.
                )
            {

            }*/
        }

        private void gv_commentaire_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void gv_frais_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            
        }

        private void gv_commentaire_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        int etatcom = 0;
        private void bt_comvalider_Click(object sender, EventArgs e)
        {
            if (typecom.SelectedIndex < 0 || commentaire.Text.Trim() == "")
                return;

            if (etatcom == 2) //donc modif
            {
                string champ = "typecom, infos";
                string val = typecom.Text + "$" + valtexte(commentaire);
                uf.executeSQL(comrealvistamod, "fact_entreprisehistory", champ, val, 1, "identretien = " + gv_commentaire.CurrentRow.Cells["g_identretien"].Value.ToString());
            }
            else if (etatcom == 1)//ajout
            {
                string champ = "dateentretien,typecom,identreprise,infos";
                string val = string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + typecom.Text + "$" + refentreprise.Text + "$" + valtexte(commentaire);
                string ret = uf.executeSQL(comrealvistamod, "fact_entreprisehistory", champ, val, 2, "");
                /*if (ret != "-1")
                {
                    gv_commentaire.CurrentRow.Cells["g_identretien"].Value = ret;
                }*/
            }
            affichecommentaire(refentreprise.Text);
        }

        private void modifierCommentaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uf.enablecontrol(p_client, "12", true);
            uf.initcontrol(p_client, "12", typecom);
            typecom.Text = gv_commentaire.CurrentRow.Cells["g_typecom"].Value.ToString();
            commentaire.Text = gv_commentaire.CurrentRow.Cells["g_commentaire"].Value.ToString();
            //typecom.Enabled = commentaire.Enabled = bt_comvalider.Enabled = true;
            etatcom = 2;
        }

        private void gv_commentaire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            typecom.Text = gv_commentaire.CurrentRow.Cells["g_typecom"].Value.ToString();
            commentaire.Text = gv_commentaire.CurrentRow.Cells["g_commentaire"].Value.ToString();
            typecom.Enabled = commentaire.Enabled = bt_comvalider.Enabled = false;
        }

        private void men_commentaire_Opening(object sender, CancelEventArgs e)
        {
            modifierCommentaireToolStripMenuItem.Enabled = false;
            supprimerCommentaireToolStripMenuItem.Enabled = false;
            if (gv_commentaire.SelectedRows.Count > 0)
                supprimerCommentaireToolStripMenuItem.Enabled = modifierCommentaireToolStripMenuItem.Enabled = true;
        }

        private void bt_banque_Click(object sender, EventArgs e)
        {
            f_banque f = new f_banque();
            f.DeltaSQLTmp.Connection = comrealvistamod.Connection;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                idbanque.Text = f.idbanque;
                banque.Text = f.gvins.CurrentRow.Cells["nombanque"].FormattedValue.ToString() + " - " + f.gvins.CurrentRow.Cells["adresse"].FormattedValue.ToString() + " " + f.gvins.CurrentRow.Cells["npa"].FormattedValue.ToString() + " " + f.gvins.CurrentRow.Cells["ville"].FormattedValue.ToString();
            }
        }

        private void bt_pub_Click(object sender, EventArgs e)
        {
            /*FileDg.InitialDirectory = @Application.StartupPath + @"\Fact_modele";
            if (FileDg.ShowDialog() == DialogResult.OK)
                pub.Text = FileDg.SafeFileName;*/
            
        }

        public static Bitmap RtbToBitmap(RichTextBox rtb)
        {
            rtb.Update();  // Ensure RTB fully painted
            Bitmap bmp = new Bitmap(rtb.Width, rtb.Height);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.CopyFromScreen(rtb.PointToScreen(Point.Empty), Point.Empty, rtb.Size);
            }
            return bmp;
        }


        public void SaveControlToBitmap(Control control, string fileName)
        {
            //Get graphics from the control  
            Graphics g = control.CreateGraphics();
            
            Bitmap bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));

            bitmap.Save(fileName);
            bitmap.Dispose();

        }


        private void pub_TextChanged(object sender, EventArgs e)
        {
            /*if (pub.Text == "")
                r_pub.Text = "";
            else
            {
                r_pub.LoadFile(@Application.StartupPath + @"\Fact_modele\" + pub.Text, RichTextBoxStreamType.RichText);
            }*/
        }

        private void label37_Click(object sender, EventArgs e)
        {
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            pub.Visible = true;
            texterappel.Visible = false;
        }

        private void label38_Click(object sender, EventArgs e)
        {
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel1.BorderStyle = BorderStyle.Fixed3D;

            texterappel.Visible = true;
            pub.Visible = false;
        }
    }
}
