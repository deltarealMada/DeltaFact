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
    public partial class f_marchandises : Form
    {
        public f_marchandises()
        {
            InitializeComponent();
        }

        util_fact uf = new util_fact();
        public int etat = 0;
        string reqdon = "";
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);

        private void f_marchandises_Load(object sender, EventArgs e) 
        {
            uf.initialisation(p_affiche);
            //remplir les combos
            //uf.RemplirCombo(client, "SELECT if (entreprise.iddeltareal > 0, concat(clidelta.socligne1, ' ', clidelta.socligne2), concat(entreprise.socligne1, ' ', entreprise.socligne2)) as entreprise, entreprise.identreprise FROM fact_entreprise entreprise left join " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal ORDER BY entreprise.identreprise ", comrealvista, mySqlDataAdapter1);
            lb_entreprise.Text = uf.ValeurParCond(comrealvista, "fact_entreprise entreprise left join " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal", "if (entreprise.iddeltareal > 0, concat(clidelta.socligne1, ' ', clidelta.socligne2), concat(entreprise.socligne1, ' ', entreprise.socligne2)) as entreprise", "entreprise", "identreprise = " + Fmain.identreprisesel);
            uf.RemplirCombo(unite, "SELECT unitecode, unitelibelle, idunite FROM fact_unite ORDER BY unitecode", comrealvista, mySqlDataAdapter1);
            reqdon = "select idarticle, codearticle, descriptif_ligne1, descriptif_ligne2, descriptif_ligne3, descriptif_ligne4, descriptif_ligne5, " +
                "remarque, concat(unitecode, ' ', unitelibelle) as unite, fact_unite.idunite as idunite FROM fact_articles " +
                //"LEFT JOIN fact_entreprise entreprise ON entreprise.identreprise = fact_articles.identreprise AND entreprise.identreprise =" + Fmain.identreprisesel + " " +
                //"left join " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal " +
                "LEFT JOIN fact_unite ON fact_unite.idunite = fact_articles.idunite WHERE fact_articles.identreprise =" + Fmain.identreprisesel + " ORDER BY codearticle";
            //uf.afficherInfo(this, reqdon, comrealvista, gv_article, "");
            
            //if (gv_article.RowCount > 0)
            //    uf.afficherInfo(this, reqdon.Replace("ORDER", "WHERE idarticle =" + gv_article.Rows[0].Cells["g_idarticle"].Value.ToString() + " ORDER"), comrealvista, null, "");
            affichedonnees();
            //uf.enablecontrol(p_affiche, "2", false);
            //uf.enablemulticontrol(p_button, "1", "2,3");

            
        }

        bool ajoutp = false;
        private void chargerprix(string idarticle)
        {
            edprix.Text = "";
            eddateprix.Value = DateTime.Now;
            edprix.Enabled = eddateprix.Enabled = false;
            bt_ajoutprix.Enabled = bt_supligne.Enabled = false;
            ajoutp = false;
            string sq = "SELECT idprix, prix, date_format(dateprix, '%d.%m.%Y') as dateprix FrOM fact_prix prix where idarticleprix =" + idarticle + " order by dateprix desc";
            uf.afficherInfo(this, sq, comrealvista, gv_prix);
                eddateprix.Enabled = edprix.Enabled = false;
            if (gv_prix.RowCount > 0)
            {
                eddateprix.Enabled = edprix.Enabled = true;
                gv_prix_CellClick(gv_prix, new DataGridViewCellEventArgs(1, 0));
                bt_ajoutprix.Enabled = bt_supligne.Enabled = true;
            }
            else
                bt_ajoutprix.Enabled = true;
            //uf.RemplirCombo(lprix, sq, comrealvista, mySqlDataAdapter1);
        }

        private void chargerrabais(string idarticle)
        {
            edrabaismontant.Text = edrabaispourcent.Text = "";
            eddaterabaisde.Value = DateTime.Now;
            eddaterabaisa.Value = DateTime.Now;
            edrabaispourcent.Enabled = edrabaismontant.Enabled = eddaterabaisa.Enabled = eddaterabaisde.Enabled = false;
            bt_suplignerab.Enabled = bt_ajoutlignerab.Enabled = false;
            ajoutp = false;
            string sq = "SELECT idrabais, concat(if(rabaispourcent>0, rabaispourcent, 0), '%') as rabaispourcent, if(rabaismontant>0, rabaismontant, 0) as rabaismontant, " +
                "date_format(daterabaisde, '%d.%m.%Y') as daterabaisde, date_format(daterabaisa, '%d.%m.%Y') as daterabaisa FrOM fact_rabais rabais where idarticlerabais =" + idarticle + " order by daterabaisa desc";
            uf.afficherInfo(this, sq, comrealvista, gv_rabais);
            eddateprix.Enabled = eddaterabaisa.Enabled = eddaterabaisde.Enabled = edrabaismontant.Enabled = edrabaispourcent.Enabled = edprix.Enabled = false;

            if (gv_rabais.RowCount > 0)
            {
                gv_rabais_CellClick(gv_rabais, new DataGridViewCellEventArgs(1, 0));
                eddaterabaisa.Enabled = eddaterabaisde.Enabled = edrabaismontant.Enabled = edrabaispourcent.Enabled = false;
                bt_suplignerab.Enabled = bt_ajoutlignerab.Enabled = true;
            }
            else
                bt_ajoutlignerab.Enabled = true;
            //uf.RemplirCombo(lprix, sq, comrealvista, mySqlDataAdapter1);
        }

        private void affichedonnees()
        {
            /*string sz = "select idarticle, socligne as client, client.idclient as id_client, codearticle, descriptif_ligne1, descriptif_ligne2, descriptif_ligne3, descriptif_ligne4, descriptif_ligne5, remarque, concat(unitecode, ' ', unitelibelle) as unite, fact_unite.idunite as id_unite, prix FROM fact_articles " +
                "LEFT JOIN fact_entreprise entreprise ON entreprise.identreprise = fact_articles.identreprise LEFT JOIN fact_unite ON fact_unite.idunite = fact_articles.idunite ORDER BY codearticle";
            uf.afficherInfo(this, sz, comrealvista, gv_article, "");
            
            sz = sz.Replace("ORDER", "WHERE idarticle =" + gv_article.Rows[0].Cells["g_idarticle"].Value.ToString() + " ORDER");

            uf.afficherInfo(this, sz, comrealvista, null, "");*/
            uf.afficherInfo(this, reqdon, comrealvista, gv_article, "");
            if (gv_article.RowCount > 0)
            {
                uf.afficherInfo(this, reqdon.Replace("ORDER", "AND idarticle =" + gv_article.Rows[0].Cells["g_idarticle"].Value.ToString() + " ORDER"), comrealvista, null, "");
                chargerprix(gv_article.Rows[0].Cells["g_idarticle"].Value.ToString());
                chargerrabais(gv_article.Rows[0].Cells["g_idarticle"].Value.ToString());
            }
            uf.enablemulticontrol(p_button, "1", "2");
            uf.enablecontrol(p_affiche, "2", false);
            Program.variableglobale = "azerty";
            util_fact.variableglobale = "kjgkjgkjkj";
            if (gv_article.RowCount == 0)
                bt_modif.Enabled = bt_suppr.Enabled = false;
        }

        private void bt_modif_Click(object sender, EventArgs e)
        {
            etat = 1;
            modifajout();
        }

        private void annule()
        {
            if (curligne > -1)
            {
                gv_article.Rows[curligne].Selected = true;
                gv_article.CurrentCell = gv_article.Rows[curligne].Cells[1];
            }
            if (gv_article.RowCount > 0 && gv_article.CurrentRow.Index > -1)
            {
                uf.afficherInfo(this, reqdon.Replace("ORDER", "AND idarticle =" + gv_article.CurrentRow.Cells["g_idarticle"].Value.ToString() + " ORDER"), comrealvista, null, "");
                chargerprix(gv_article.CurrentRow.Cells["g_idarticle"].Value.ToString());
                chargerrabais(gv_article.CurrentRow.Cells["g_idarticle"].Value.ToString());
            }
            else
                uf.initcontrol(p_affiche, "", codearticle);
            uf.enablemulticontrol(p_button, "1", "2");
            uf.enablecontrol(p_affiche, "2", false);
            if (gv_article.RowCount == 0)
                bt_modif.Enabled = bt_suppr.Enabled = false;
            etat = 0;
        }

        private void modifajout()
        {
            //etat ==> 1 MODIF  2 AJOUT
            uf.enablemulticontrol(p_button, "2", "1");
            uf.enablecontrol(p_affiche, "2", true);
            if (etat == 2)
            {
                uf.initcontrol(p_affiche, "", codearticle);
                gv_prix.Rows.Clear();
                gv_rabais.Rows.Clear();
                bt_ajoutlignerab.Enabled = bt_ajoutprix.Enabled = bt_supligne.Enabled = bt_suplignerab.Enabled = false;
                eddateprix.Value = eddaterabaisa.Value = eddaterabaisde.Value = DateTime.Now;
                edprix.Text = edrabaismontant.Text = edrabaispourcent.Text = "0.00";
                eddateprix.Enabled = eddaterabaisa.Enabled = eddaterabaisde.Enabled = edrabaismontant.Enabled = edrabaispourcent.Enabled = edprix.Enabled = true;
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
        
        private string valtexte(TextBox txt)
        {
            return txt.Text.Trim();
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            decimal dprix = 0;
            decimal.TryParse(uf.valtexte(edprix), out dprix);
            
            decimal drabaisp = 0;
            decimal drabaism = 0;
            decimal.TryParse(uf.valtexte(edrabaismontant), out drabaism);
            decimal.TryParse(uf.valtexte(edrabaispourcent), out drabaisp);
            if (unite.SelectedIndex < 0)
            {
                uf.AfficherErreur("Veuillez l'unité de cet article !");
                return;
            }
            if (drabaisp > 0)
                drabaism = 0;

            if (dprix == 0)
            {
                uf.AfficherErreur("Veuillez entrer le prix de cet article !");
                return;
            }
            if (etat == 2 && dprix == 0)
            {
                uf.AfficherErreur("Veuillez entrer le prix de cet article !");
                return;
            }
            
            string champ = "identreprise, codearticle, descriptif_ligne1, descriptif_ligne2, descriptif_ligne3, descriptif_ligne4, descriptif_ligne5, remarque, idunite";
            string val = "115 $ ART 02 $ DESCR 2 $ remarque 2 $ 3 $ 20.30";
            val = Fmain.identreprisesel + "$" + valtexte(codearticle) + "$" + valtexte(descriptif_ligne1) + "$" + valtexte(descriptif_ligne2) + "$" + valtexte(descriptif_ligne3) + "$" + valtexte(descriptif_ligne4) + "$" + valtexte(descriptif_ligne5) + "$"
                + valtexte(remarque) + "$" + uf.valcombo(unite);

            if (etat == 2)
            {
                string newid = uf.executeSQL(comrealvista, "fact_articles", champ, val, etat, "");
                uf.executeSQL(comrealvista, "fact_prix", "idarticleprix, dateprix, prix", newid + "$" + string.Format("{0:yyyy-MM-dd}", eddateprix.Value) + "$" + uf.getFormatCur(dprix), 2, "");
                if (drabaisp > 0 || drabaism > 0)
                    uf.executeSQL(comrealvista, "fact_rabais", "idarticlerabais, dateranaisde, dateranaisa, rabaispourcent, rabaismontant", newid + "$" + string.Format("{0:yyyy-MM-dd}", eddaterabaisde.Value) + "$" + string.Format("{0:yyyy-MM-dd}", eddaterabaisa.Value) + "$" + uf.getFormatCur(edrabaispourcent) + "$" + uf.getFormatCur(edrabaismontant), 2, "");

            }
            else if (etat == 1)
                uf.executeSQL(comrealvista, "fact_articles", champ, val, etat, "idarticle = " + gv_article.CurrentRow.Cells["g_idarticle"].Value.ToString());
            if (etat == 1)
                curligne = gv_article.CurrentRow.Index;
            else
                curligne = gv_article.RowCount - 1;
            uf.afficherInfo(this, reqdon, comrealvista, gv_article, "");
            annule();
        }

        private void g_article_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //string g = sender.GetType().Name;
        }

        int curligne = -1;
        private void g_article_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gv_article.RowCount > 0)
                curligne = gv_article.CurrentRow.Index;
            annule();
        }

        private void bt_suppr_Click(object sender, EventArgs e)
        {
            if (uf.ValeurParCond(comrealvista, "fact_facturation", "idfacture, idprix", "idfacture", "idarticle =" + gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString() + " GROUP BY idprix") != "")
            {
                uf.AfficherErreur("Attention, il y a déjà une facture qui utilise cet article !");
                return;
            }
            if (uf.confirmer_questionON(this, "Etes-vous sûre de supprimer cette ligne ?") == DialogResult.No)
            {
                annule();
                return;
            }
            uf.executeSQL(comrealvista, "fact_articles", "", "", 3, "idarticle = " + gv_article.CurrentRow.Cells["g_idarticle"].Value.ToString());
            gv_article.Rows.Remove(gv_article.CurrentRow);
            annule();
        }


        private void gv_prix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            edprix.Text = "0.00";
            eddateprix.Value = DateTime.Now;
            if (e.RowIndex > -1)
            {
                edprix.Text = gv_prix.CurrentRow.Cells["g_prix"].FormattedValue.ToString();
                eddateprix.Text = gv_prix.CurrentRow.Cells["g_dateprix"].FormattedValue.ToString();
            }
        }

        private void edprix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gv_prix.RowCount == 0)
                return;
            if (e.KeyChar == 13)
            {
                if (gv_prix.RowCount > 0 && gv_prix.SelectedRows.Count > 0)
                {
                    decimal pri = 0;
                    decimal.TryParse(uf.valtexte(edprix), out pri);
                    if (pri > 0)
                    {
                        if (uf.confirmer_questionON(this, "Valider le changement ?") == DialogResult.No)
                            return;
                        int typer = 2;
                        string cond = "";
                        if (gv_prix.CurrentRow.Cells["g_idprix"].FormattedValue.ToString() != "" && gv_prix.CurrentRow.Cells["g_idprix"].FormattedValue.ToString() != "0")
                        {
                            typer = 1;
                            cond = "idprix =" + gv_prix.CurrentRow.Cells["g_idprix"].FormattedValue.ToString() + " AND idarticleprix = " + gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString();
                        }
                        //gv_prix.CurrentRow.Cells["g_idprix"].Value = "";
                        uf.executeSQL(comrealvista, "fact_prix", "prix,dateprix,idarticleprix", uf.getFormatCur(uf.valtexte(edprix), false) + "$" + string.Format("{0:yyyy-MM-dd}", eddateprix.Value) + "$" + gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString(), typer, cond);
                        chargerprix(gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString());
                    }
                }
            }
        }

        private void bt_ajoutprix_Click(object sender, EventArgs e)
        {
            gv_prix.Rows.Add(1);
            gv_prix.CurrentCell = gv_prix.Rows[gv_prix.RowCount - 1].Cells[1];
            gv_prix.CurrentRow.Selected = true;
            gv_prix.CurrentRow.Cells["g_idprix"].Value = "";
            gv_prix.CurrentRow.Cells["g_dateprix"].Value = DateTime.Now;
            gv_prix.CurrentRow.Cells["g_prix"].Value = "0.00";
            gv_prix_CellClick(gv_prix, new DataGridViewCellEventArgs(1, gv_prix.CurrentRow.Index));
            edprix.Enabled = eddateprix.Enabled = true;

            eddateprix.Focus();
        }

        private void gv_prix_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                eddateprix.Enabled = true;
                edprix.Enabled = true;
                edprix.Focus();
            }
        }

        private void bt_supligne_Click(object sender, EventArgs e)
        {
            if (gv_prix.SelectedRows.Count <= 1)
                return;
            if (uf.ValeurParCond(comrealvista, "fact_facturation", "idfacture, idprix", "idfacture", "idprix =" + gv_prix.CurrentRow.Cells["g_idprix"].FormattedValue.ToString() + " GROUP BY idprix") != "")
            {
                uf.AfficherErreur("Attention, il y a déjà une facture qui utilise ce prix !");
                return;
            }
            if (uf.confirmer_questionON(this, "Valider la suppression ?") == DialogResult.Yes)
            {
                uf.executeSQL(comrealvista, "fact_prix", "", "", 3, "idprix =" + gv_prix.CurrentRow.Cells["g_idprix"].FormattedValue.ToString());
                chargerprix(gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString());
            }
        }

        private void gv_rabais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            edrabaispourcent.Text = "0.00";
            edrabaismontant.Text = "0.00";
            eddaterabaisde.Value = DateTime.Now;
            eddaterabaisa.Value = DateTime.Now;
            if (e.RowIndex > -1)
            {
                edrabaispourcent.Text = gv_rabais.CurrentRow.Cells["g_rabaispourcent"].FormattedValue.ToString();
                edrabaismontant.Text = gv_rabais.CurrentRow.Cells["g_rabaismontant"].FormattedValue.ToString();
                eddaterabaisde.Text = gv_rabais.CurrentRow.Cells["g_daterabaisde"].FormattedValue.ToString();
                eddaterabaisa.Text = gv_rabais.CurrentRow.Cells["g_daterabaisa"].FormattedValue.ToString();
            }
        }

        private void gv_rabais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                edrabaismontant.Enabled = eddaterabaisa.Enabled = edrabaispourcent.Enabled = eddaterabaisde.Enabled = true;
                edrabaispourcent.Focus();
            }
        }

        private void edrabaispourcent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validerrabais();
            }
        }

        private void validerrabais()
        {
            if (gv_rabais.RowCount == 0)
                return;
            if (eddaterabaisa.Value < eddaterabaisde.Value)
            {
                uf.AfficherErreur("Veuillez entrer des dates de début et fin valides du rabais !");
                return;
            }
            if (gv_rabais.RowCount > 0 && gv_rabais.SelectedRows.Count > 0)
            {
                decimal rabm = 0;
                decimal rabp = 0;
                decimal.TryParse(uf.valtexte(edrabaismontant), out rabm);

                decimal.TryParse(uf.valtexte(edrabaispourcent), out rabp);
                if (rabp > 0)
                    rabm = 0;
                if (rabp > 0 || rabm > 0)
                {
                    if (uf.confirmer_questionON(this, "Valider le changement ?") == DialogResult.No)
                        return;
                    int typer = 2;
                    string cond = "";
                    if (gv_rabais.CurrentRow.Cells["g_idrabais"].FormattedValue.ToString() != "" && gv_rabais.CurrentRow.Cells["g_idrabais"].FormattedValue.ToString() != "0")
                    {
                        typer = 1;
                        cond = "idrabais =" + gv_rabais.CurrentRow.Cells["g_idrabais"].FormattedValue.ToString() + " AND idarticlerabais = " + gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString();
                    }
                    uf.executeSQL(comrealvista, "fact_rabais", "rabaispourcent,rabaismontant,daterabaisde,daterabaisa, idarticlerabais", uf.getFormatCur(uf.valtexte(edrabaispourcent), false) + "$" + uf.getFormatCur(uf.valtexte(edrabaismontant), false) + "$" + 
                        string.Format("{0:yyyy-MM-dd}", eddaterabaisde.Value) + "$" + string.Format("{0:yyyy-MM-dd}", eddaterabaisa.Value) + "$" + gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString(), typer, cond);
                    chargerrabais(gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString());
                }
            }
        }

        private void edrabaismontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validerrabais();
            }
        }

        private void bt_ajoutlignerab_Click(object sender, EventArgs e)
        {
            gv_rabais.Rows.Add(1);
            gv_rabais.CurrentCell = gv_rabais.Rows[gv_rabais.RowCount - 1].Cells[1];
            gv_rabais.CurrentRow.Selected = true;
            gv_rabais.CurrentRow.Cells["g_idrabais"].Value = "";
            gv_rabais.CurrentRow.Cells["g_daterabaisde"].Value = DateTime.Now;
            gv_rabais.CurrentRow.Cells["g_daterabaisa"].Value = DateTime.Now.AddDays(30);
            gv_rabais.CurrentRow.Cells["g_rabaispourcent"].Value = "0.00";
            gv_rabais.CurrentRow.Cells["g_rabaismontant"].Value = "0.00";
            gv_rabais_CellClick(gv_rabais, new DataGridViewCellEventArgs(1, gv_rabais.CurrentRow.Index));
            edrabaismontant.Enabled = eddaterabaisa.Enabled = edrabaispourcent.Enabled = eddaterabaisde.Enabled = true;

            eddaterabaisde.Focus();
        }

        private void bt_suplignerab_Click(object sender, EventArgs e)
        {
            if (gv_rabais.SelectedRows.Count <= 1)
                return;
            if (uf.ValeurParCond(comrealvista, "fact_facturation", "idfacture, idrabais", "idfacture", "idrabais =" + gv_rabais.CurrentRow.Cells["g_idrabais"].FormattedValue.ToString() + " GROUP BY idprix") != "")
            {
                uf.AfficherErreur("Attention, il y a déjà une facture qui utilise ce système de rabais!");
                return;
            }
            if (uf.confirmer_questionON(this, "Valider la suppression du rabais?") == DialogResult.Yes)
            {
                uf.executeSQL(comrealvista, "fact_rabais", "", "", 3, "idrabais =" + gv_rabais.CurrentRow.Cells["g_idrabais"].FormattedValue.ToString());
                chargerrabais(gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString());
            }
        }

        public string selart = "";
        public string selidart = "";
        private void gv_article_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gv_article.RowCount > 0 && e.RowIndex> -1)
            {
                selart = gv_article.CurrentRow.Cells["g_codearticle"].FormattedValue.ToString();
                selidart = gv_article.CurrentRow.Cells["g_idarticle"].FormattedValue.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
