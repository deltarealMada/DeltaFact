using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaFact
{
    public partial class f_etatfact : Form
    {
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);
        util_fact uf = new util_fact();
        public f_etatfact()
        {
            InitializeComponent();
        }

        public string cond = "";
        public int typecompta = 0;
        private void f_etatfact_Load(object sender, EventArgs e)
        {
            //datedeb.Value = DateTime.Parse("01.01" + string.Format("{0:yyyy}", DateTime.Now)); 
            datedeb.Value = datefin.Value = DateTime.Now;
            if (typecompta == 1)
                ck_envoye.Checked = true;
            else if (typecompta == 2)
                ck_paye.Checked = true;

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            /*
            
            SELECT 0 as idfacture, ' ' as numbvrcomplet, '' as numbvrspace, '' as fact_nofacture, '' as fact_reffactureentreprise, '' as fact_datefacture, '' as fact_dateecheance, '' as fact_datecommande, '' as fact_datefacturedeltareal, '' as fact_datepaiement, 0.00 as fact_totalmontantbrut, '' as fact_tvapourcent, 0.00 as fact_totalrabais, 0.00 as fact_totaltvachf, 0.00 as fact_fraisenvoi, 0.00 as fact_fraisassurance, 0.00 as fact_interets, 0.00 as fact_fraisrappel, 0.00 as fact_montantapayer, 0.00 as fact_montantpaye, 0 as art_numligne, '' as art_codearticle, '' as art_libellearticle, '' as art_remarque, '' as art_unite, 0.00 as art_prixunitaire, 0 as art_nbrarticle, 0.00 as art_montantbrut, '' as art_rabaispourcent, 0.00 as art_rabaischf, 0 as identreprise, 0 as iddeltareal, '' as letter, '' as ent_societe, '' as ent_societecompl, '' as ent_politesse, '' as ent_nomprenom, '' as ent_adresse1, '' as ent_adresse2, '' as ent_co, '' as ent_npa, '' as ent_ville, '' as ent_iban, '' as ent_banqueccp, '' as ent_notva, 0 as ent_echeancejour, '' as ent_email, '' as ent_siteweb, '' as ent_nobvr, '' as ent_noccp, '' as ent_noremiseadherent, 0 as iCli, '' as cli_adressecomplet, '' as cli_societe, '' as cli_politesse, '' as cli_nom, '' as cli_prenom, '' as cli_co, '' as cli_adresse1, '' as cli_adresse2, '' as cli_npa, '' as cli_ville, '' as modemens, 0 as nbrmens FROM fact_facturation
            PREPARE stmt FROM @tri;
            EXECUTE stmt;

            */
            /*SELECT ' ' as numbvrcomplet, '' as numbvrspace, '' as fact_nofacture, '' as fact_reffactureentreprise, now() as fact_datefacture, now() as fact_dateecheance, now() as fact_datecommande, now() as fact_datefacturedeltareal, now() as fact_datepaiement, 0.00 as fact_totalmontantbrut, 0.00 as fact_tvapourcent, 0.00 as fact_totalrabais, 0.00 as fact_totaltvachf, 0.00 as fact_fraisenvoi, 0.00 as fact_fraisassurance, 0.00 as fact_interets, 0.00 as fact_fraisrappel, 0.00 as fact_montantapayer, 0.00 as fact_montantpaye, 0 as art_numligne, '' as art_codearticle, '' as art_libellearticle, '' as art_remarque, '' as art_unite, 0.00 as art_prixunitaire, 0 as art_nbrarticle, 0.00 as art_montantbrut, 0.00 as art_rabaispourcent, 0.00 as art_rabaischf, 0 as identreprise, 0 as iddeltareal, '' as letter, '' as ent_societe, '' as ent_societecompl, '' as ent_politesse, '' as ent_nomprenom, '' as ent_adresse1, '' as ent_adresse2, '' as ent_co, '' as ent_npa, '' as ent_ville, '' as ent_iban, '' as ent_banqueccp, '' as ent_notva, 0 as ent_echeancejour, '' as ent_email, '' as ent_siteweb, 0 as iCli, '' as cli_adressecomplet, '' as cli_societe, '' as cli_politesse, '' as cli_nom, '' as cli_prenom, '' as cli_co, '' as cli_adresse1, '' as cli_adresse2, '' as cli_npa, '' as cli_ville, '' as modemens, 0 as nbrmens FROM fact_facturation*/
            
        }

        private void bntValid_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_valideretat_Click(object sender, EventArgs e)
        {
            /*SELECT '' as dateecriture, '' as numecriture, 0 as idmouvement, 0 as idcompte, '' as codecompte, 0 as idcomptec, '' as codecomptec, '' as libelle, 0.00 as entree, 0.00 as sortie from fact_facturation*/
            this.reportViewer1.RefreshReport();
            string tri = ""; 
            Microsoft.Reporting.WinForms.ReportDataSource dd = null;
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Fact_modele\\fact_recapfacture.rdlc";
            dd = new Microsoft.Reporting.WinForms.ReportDataSource("FactDataSet");
            tri = "SELECT mouv.numfolio as numecriture, date_format(mouv.datemouvement, '%d.%m.%y') as dateecriture, mouv.idmouvement, mouv.idcompte, mouv.codecompte, mouv.idcomptec, mouv.codecomptec, mouv.libelledetail as libelle, mouv.entree, mouv.sortie, fact.identreprise ";
            if (ck_envoye.Checked)
                tri += " FROM fact_facturation fact INNER JOIN " + Fmain.nombasecompta + ".cpta_mouvement mouv ON mouv.idmouvement = fact.idmouvementenvoye AND fact.identreprise = " + Fmain.identreprisesel + " AND mouv.datesaisie BETWEEN '" + uf.getDateSQL(datedeb.Value) + "' AND '" + uf.getDateSQL(datefin.Value) + "' group by fact.reffacturedeltareal ORDER BY mouv.numfolio desc";
            else
                tri += " FROM fact_paiement fact INNER JOIN " + Fmain.nombasecompta + ".cpta_mouvement mouv ON mouv.idmouvement = fact.idmouvementpaye AND fact.identreprise = " + Fmain.identreprisesel + " AND mouv.datesaisie BETWEEN '" + uf.getDateSQL(datedeb.Value) + "' AND '" + uf.getDateSQL(datefin.Value) + "' group by mouv.numfolio ORDER BY mouv.numfolio desc";

            realvistaDataSetTableAdapters.recapfactureTableAdapter recapfacture = new realvistaDataSetTableAdapters.recapfactureTableAdapter();
            clientBindingSource.ResetBindings(false);
            recapfacture.ClearBeforeFill = true;
            clientBindingSource.DataMember = "recapfacture";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dd);
            string txt = " du " + string.Format("{0:dd.MM.yyyy}", datedeb.Value);
            if (datedeb.Value != datefin.Value)
                txt = txt + " au " + string.Format("{0:dd.MM.yyyy}", datefin.Value);
            if (ck_envoye.Checked)
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("typereport", "ENVOYEES" + txt));
            else
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("typereport", "PAYEES" + txt));
            reportViewer1.LocalReport.DataSources[0].Value = clientBindingSource;
            recapfacture.Fill(realvistaDataSet.recapfacture, tri);
            if (clientBindingSource.Position == -1)
            {
                uf.message_info("Il n'y a pas de données !");
                return;
            }
            this.Top = this.Owner.Top;
            this.Left = this.Owner.Left;
            pboutons.Visible = false;
            this.Width = 1376;
            this.Height = 846;
            reportViewer1.Show();
            reportViewer1.Visible = true;
            reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }
    }
}
