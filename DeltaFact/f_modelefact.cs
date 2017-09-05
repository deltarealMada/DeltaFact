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
    public partial class f_modelefact : Form
    {
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);
        util_fact uf = new util_fact();
        public f_modelefact()
        {
            InitializeComponent();
        }

        public string cond = "";
        public bool brappel = false;
        public bool brappelimp = false;
        public bool blisterap = false;
        public int stypefact = 0;
        private void f_modelefact_Load(object sender, EventArgs e)
        {

            if (blisterap)
            {
                string sql = "Select  fact.reffacturedeltareal as fact_nofacture, fact.rappel as fact_nbrrappel, date_format(dateimpression, '%d.%m.%Y') as fact_datefacture, " +
                "date_format(dateecheance, '%d.%m.%Y') as fact_dateecheance, date_format(fact.datecommande, '%d.%m.%Y') as fact_datecommande, fact.montantapayer as fact_montantapayer, " +
                "if (isnull(paiement.montantpaye), 0, paiement.montantpaye) as fact_montantpaye, entreprise.identreprise, " +
                "client.idclient as iCli, concat_ws(' ', if (trim(socligne) = '', null, concat(socligne, ',')), if (trim(clientpolitesse.politesseadr) = '',null,clientpolitesse.politesseadr), " +
                "if (trim(concat(client.prenom, ' ', client.nom)) = '', null, trim(concat(client.prenom, ' ', client.nom))), if (trim(client.co) = '', null, client.co), " +
                "if (trim(client.adresse1) = '', null, concat('\n', client.adresse1)), if (trim(client.adresse2) = '', null, client.adresse2), concat('- ', city.zip, ' ', city.cityname)) as cli_adressecomplet " +
                "fROM fact_facturation fact inner join fact_entreprise entreprise on entreprise.identreprise = fact.identreprise LEFT JOIN (select identreprise, numfacture, datepaiement, " +
                "sum(montant) as montantpaye FROM fact_paiement GROUP BY identreprise, numfacture order by datepaiement desc) paiement ON paiement.identreprise = fact.identreprise AND fact.reffacturedeltareal = paiement.numfacture " +
                "LEFT JOIN fact_client client ON client.idclient = fact.idclient left join   " + Fmain.baseInit + ".city ON city.idcity = client.idville left join   " + Fmain.baseInit + ".typepolitesse clientpolitesse ON client.idpolitesse = clientpolitesse.idpolitesse ";
                string styperep = "";
                if (stypefact == 3)
                {
                    sql += "WHERE fact.dateimpression is not null AND fact.dateecheance < now()  and fact.rappel > -1 AND(paiement.montantpaye is null or paiement.montantpaye < montantapayer)  group by reffacturedeltareal ORDER by fact_dateecheance asc, fact.reffacturedeltareal desc, fact.idclient, fact.numligne ";
                    styperep = "A ECHEANCE";
                }
                else if (stypefact == 2)
                {
                    sql += "WHERE fact.dateimpression is not null AND fact.dateecheance > now()  and fact.rappel > 0 AND(paiement.montantpaye is null or paiement.montantpaye < montantapayer)  group by reffacturedeltareal ORDER by  fact_dateecheance asc, fact.reffacturedeltareal desc, fact.idclient, fact.numligne ";
                    styperep = " AVEC RAPPEL ENVOYE";
                }
                else if (stypefact == 1)
                {
                    sql += "WHERE fact.dateimpression is not null and fact.rappel = 0 AND fact.dateecheance >= now() AND (paiement.montantpaye = 0 OR paiement.montantpaye IS NULL OR paiement.montantpaye < fact.montantapayer)  group by reffacturedeltareal ORDER by  fact_dateimpression asc, fact.reffacturedeltareal desc, fact.idclient, fact.numligne ";
                    styperep = " ENVOYEES";
                }
                else if (stypefact == 0)
                {
                    sql += "WHERE fact.dateimpression is null group by reffacturedeltareal ORDER by fact.reffacturedeltareal desc";
                    styperep = " SAISIES";
                }
                else if (stypefact == 4)
                {
                    sql += "WHERE fact.dateimpression is not null AND paiement.montantpaye >= fact.montantapayer  group by reffacturedeltareal ORDER by fact.reffacturedeltareal desc";
                    styperep = " PAYEES";
                }
                else if (stypefact == 5)
                {
                    sql += " group by reffacturedeltareal ORDER by fact.reffacturedeltareal desc";
                    styperep = "";
                }

                this.reportViewer1.RefreshReport();
                Microsoft.Reporting.WinForms.ReportDataSource dd = null;
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Fact_modele\\Fact_recaprappel.rdlc";
                dd = new Microsoft.Reporting.WinForms.ReportDataSource("FactDataSet");

                realvistaDataSetTableAdapters.recaprappelTableAdapter Recaprappel = new realvistaDataSetTableAdapters.recaprappelTableAdapter();
                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("typereport", styperep));
                clientBindingSource.ResetBindings(false);
                Recaprappel.ClearBeforeFill = true;
                clientBindingSource.DataMember = "Recaprappel";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dd);
                reportViewer1.LocalReport.DataSources[0].Value = clientBindingSource;

                Recaprappel.Fill(realvistaDataSet.recaprappel, sql);
                if (clientBindingSource.Position == -1)
                {
                    uf.message_info("Il n'y a pas de données !");
                    this.DialogResult = DialogResult.Cancel;
                }
                reportViewer1.Show();
                reportViewer1.Visible = true;
                reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            else
                rep();
        }

        public int stypefat = 0; //0 si facture, 1 si rappel
        private void rep()
        {
            /*

           SELECT '' as fact_daterappel, 0 as fact_rappel, 0 as ent_echeancerappel, 0 as idfacture, ' ' as numbvrcomplet, '' as numbvrspace, '' as fact_nofacture, '' as fact_reffactureentreprise, '' as fact_datefacture, '' as fact_dateecheance, '' as fact_datecommande, '' as fact_datefacturedeltareal, '' as fact_datepaiement, 0.00 as fact_totalmontantbrut, '' as fact_tvapourcent, 0.00 as fact_totalrabais, 0.00 as fact_totaltvachf, 0.00 as fact_fraisenvoi, 0.00 as fact_fraisassurance, 0.00 as fact_interets, 0.00 as fact_fraisrappel, 0.00 as fact_montantapayer, 0.00 as fact_montantpaye, 0 as art_numligne, '' as art_codearticle, '' as art_libellearticle, '' as art_remarque, '' as art_unite, 0.00 as art_prixunitaire, 0 as art_nbrarticle, 0.00 as art_montantbrut, '' as art_rabaispourcent, 0.00 as art_rabaischf, 0 as identreprise, 0 as iddeltareal, '' as letter, '' as ent_societe, '' as ent_societecompl, '' as ent_politesse, '' as ent_nomprenom, '' as ent_adresse1, '' as ent_adresse2, '' as ent_co, '' as ent_npa, '' as ent_ville, '' as ent_iban, '' as ent_banqueccp, '' as ent_notva, 0 as ent_echeancejour, '' as ent_email, '' as ent_siteweb, '' as ent_nobvr, '' as ent_noccp, '' as ent_noremiseadherent, 0 as iCli, '' as cli_adressecomplet, '' as cli_societe, '' as cli_politesse, '' as cli_nom, '' as cli_prenom, '' as cli_co, '' as cli_adresse1, '' as cli_adresse2, '' as cli_npa, '' as cli_ville, '' as modemens, 0 as nbrmens FROM fact_facturation
           PREPARE stmt FROM @tri;
           EXECUTE stmt;

            PREPARE stmt FROM @tri;
            SET lc_time_names = 'fr_FR';
            EXECUTE stmt;
           */
            /*SELECT ' ' as numbvrcomplet, '' as numbvrspace, '' as fact_nofacture, '' as fact_reffactureentreprise, now() as fact_datefacture, now() as fact_dateecheance, now() as fact_datecommande, now() as fact_datefacturedeltareal, now() as fact_datepaiement, 0.00 as fact_totalmontantbrut, 0.00 as fact_tvapourcent, 0.00 as fact_totalrabais, 0.00 as fact_totaltvachf, 0.00 as fact_fraisenvoi, 0.00 as fact_fraisassurance, 0.00 as fact_interets, 0.00 as fact_fraisrappel, 0.00 as fact_montantapayer, 0.00 as fact_montantpaye, 0 as art_numligne, '' as art_codearticle, '' as art_libellearticle, '' as art_remarque, '' as art_unite, 0.00 as art_prixunitaire, 0 as art_nbrarticle, 0.00 as art_montantbrut, 0.00 as art_rabaispourcent, 0.00 as art_rabaischf, 0 as identreprise, 0 as iddeltareal, '' as letter, '' as ent_societe, '' as ent_societecompl, '' as ent_politesse, '' as ent_nomprenom, '' as ent_adresse1, '' as ent_adresse2, '' as ent_co, '' as ent_npa, '' as ent_ville, '' as ent_iban, '' as ent_banqueccp, '' as ent_notva, 0 as ent_echeancejour, '' as ent_email, '' as ent_siteweb, 0 as iCli, '' as cli_adressecomplet, '' as cli_societe, '' as cli_politesse, '' as cli_nom, '' as cli_prenom, '' as cli_co, '' as cli_adresse1, '' as cli_adresse2, '' as cli_npa, '' as cli_ville, '' as modemens, 0 as nbrmens FROM fact_facturation*/
            this.reportViewer1.RefreshReport();
            string tri = "";
            Microsoft.Reporting.WinForms.ReportDataSource dd = null;
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Fact_modele\\Fact_modele1.rdlc";
            dd = new Microsoft.Reporting.WinForms.ReportDataSource("FactDataSet");
            //tri = "select 'modele_facture_1' as document, fbvr.numbvrcomplet, concat_ws(' ', mid(numbvrcomplet, 0, 2), mid(numbvrcomplet, 2, 5), mid(numbvrcomplet, 7, 5), mid(numbvrcomplet, 12, 5), mid(numbvrcomplet, 17, 5), mid(numbvrcomplet, 22)) as numbvrspace, fact.reffacturedeltareal as fact_nofacture, fact.reffactureentreprise as fact_reffactureentreprise,  date_format(fact.dateimpression, '%d.%m.%Y') as fact_datefacture, date_format(DATE_ADD(fact.dateimpression, INTERVAL entreprise.echeance day), '%d.%m.%Y') as fact_dateecheance, date_format(fact.datecommande, '%d.%m.%Y') as fact_datecommande, date_format(fact.datefacturedeltareal, '%d.%m.%Y') as fact_datefacturedeltareal, '' as fact_datepaiement, fact.totmontantbrut as fact_totalmontantbrut, concat(fact.tauxtva, '%') as fact_tvapourcent, fact.totrabais as fact_totalrabais, fact.tottva as fact_totaltvachf, fact.fraisenvoi as fact_fraisenvoi, fact.fraisassurance as fact_fraisassurance, fact.interets as fact_interets, fact.fraisrappel as fact_fraisrappel, (fact.totmontantbrut - fact.totrabais + fact.tottva) as fact_montantapayer, 0 as fact_montantpaye, " +
            tri = "Select 'modele_facture_1' as document, fbvr.numbvrcomplet, concat_ws(' ', mid(numbvrcomplet, 1, 2), mid(numbvrcomplet, 3, 5), mid(numbvrcomplet, 8, 5), mid(numbvrcomplet, 13, 5), mid(numbvrcomplet, 18, 5), mid(numbvrcomplet, 23)) as numbvrspace, fact.reffacturedeltareal as fact_nofacture, fact.reffactureentreprise as fact_reffactureentreprise, ";
            
            if (brappel)
            {
                if (brappelimp)
                    tri += "date_format(DATE_ADD(fact.dateecheance, INTERVAL -entreprise.echeancerappel DAY), '%d %M %Y')";
                else
                    tri += "date_format(date(now()), '%d %M %Y')";
            }
            else
                tri += "date_format(if(isnull(dateimpression), date(now()), dateimpression), '%d %M %Y')";
            //tri += "date_format(if(isnull(dateimpression), date(now()), dateimpression), '%d %M %Y')

            tri += " as fact_datefacture, rappel as fact_nbrrappel, date_format(if(isnull(daterappel), date(now()), daterappel), '%d %M %Y') as fact_daterappel,  date_format(DATE_ADD(date(now()), INTERVAL entreprise.echeance day), '%d.%m.%Y') as fact_dateecheance, date_format(fact.datecommande, '%d.%m.%Y') as fact_datecommande, date_format(now(),'%d %M %Y') as fact_datefacturedeltareal, date_format(paiement.datepaiement,'%d.%m.%Y') as fact_datepaiement, 0 as fact_totalmontantbrut, fact.tauxtva as fact_tvapourcent, 0 as fact_totalrabais, 0 as fact_totaltvachf, fact.fraisenvoi as fact_fraisenvoi, fact.fraisassurance as fact_fraisassurance, fact.interets as fact_interets, fact.fraisrappel as fact_fraisrappel, fact.montantapayer as fact_montantapayer, paiement.montantpaye as fact_montantpaye, " +

                "fact.numligne as art_numligne, article.codearticle as art_codearticle, concat_ws('\n', if (trim(article.descriptif_ligne1) = '', null, article.descriptif_ligne1), if (trim(article.descriptif_ligne2) = '', null, article.descriptif_ligne2), if (trim(article.descriptif_ligne3) = '', null, article.descriptif_ligne3), if (trim(article.descriptif_ligne4) = '', null, article.descriptif_ligne4), if (trim(fact.remarquearticle) = '', null, fact.remarquearticle)) as art_libellearticle, fact.remarquearticle as art_remarque, unite.unitecode as art_unite, prix.prix as art_prixunitaire, fact.nbr as art_nbrarticle, (prix.prix * fact.nbr) as art_montantbrut, if (rabais.rabaispourcent > 0, concat(rabais.rabaispourcent, '%'), '-') as art_rabaispourcent, if (if (isnull(rabais.rabaispourcent), 0, rabais.rabaispourcent) > 0, (fact.nbr * prix.prix) * rabais.rabaispourcent / 100, if (isnull(rabais.rabaismontant), 0, rabais.rabaismontant)) as art_rabaischf,  " +

                "entreprise.identreprise, entreprise.iddeltareal, langent.letter, if (entreprise.iddeltareal > 0, clidel.socligne1, entreprise.socligne1) as ent_societe, if (entreprise.iddeltareal > 0, clidel.socligne2, entreprise.socligne2) as ent_societecompl, polent.politesselettre as ent_politesse, if (entreprise.iddeltareal > 0, foncdel.nomprenom, fonccli.nomprenom) as ent_nomprenom,   " +
                "if (entreprise.iddeltareal > 0, foncdel.adresse1, fonccli.adresse1) as ent_adresse1, if (entreprise.iddeltareal > 0, foncdel.adresse2, fonccli.adresse2) as ent_adresse2,  " +
                "if (entreprise.iddeltareal > 0, foncdel.co, fonccli.co) as ent_co, clicity.zip as ent_npa, clicity.cityname as ent_ville, if (entreprise.iddeltareal > 0, foncdel.comptebanque, fonccli.comptebanque) as ent_iban, if (entreprise.iddeltareal > 0, foncdel.ccp, fonccli.noccp) as ent_noccp, if (entreprise.iddeltareal > 0, '', fonccli.nobvr) as ent_nobvr, if (entreprise.iddeltareal > 0, '', fonccli.noremiseadherent) as ent_noremiseadherent, concat(banque.nombanque, ' - ', banque.adresse, ', ', banque.npa, ' ', banque.ville) as ent_banqueccp,  " +
                "if (entreprise.iddeltareal > 0, clidel.numrc, entreprise.numtva) as ent_notva, ";
            /*if (brappel)
                tri += "concat(LPAD(entreprise.echeancerappel, 3, '0'), 'A', fact.rappel) ";
            else
                tri += "entreprise.echeance ";
                */
            tri += "entreprise.echeance as ent_echeancejour, entreprise.echeancerappel as ent_echeancerappel,  if (entreprise.iddeltareal > 0, foncdel.email, fonccli.email) as ent_email, if (entreprise.iddeltareal > 0, foncdel.adresseweb, fonccli.siteweb) as ent_siteweb,  " +

                "client.idclient as iCli, concat_ws('\n', if (trim(socligne) = '', null, socligne), if(trim(clientpolitesse.politesseadr)='',null,clientpolitesse.politesseadr), if(trim(concat(client.prenom, ' ', client.nom)) = '', null, trim(concat(client.prenom, ' ', client.nom))), if (trim(client.co) = '', null, client.co), if (trim(client.adresse1) = '', null, client.adresse1), if (trim(client.adresse2) = '', null, client.adresse2), concat(city.zip, ' ', city.cityname)) as cli_adressecomplet,  " +
                "client.socligne as cli_societe, clientpolitesse.politesselettre as cli_politesse, client.nom as cli_nom, client.prenom as cli_prenom, client.co as cli_co, client.adresse1 as cli_adresse1, client.adresse2 as cli_adresse2, city.zip as cli_npa, city.cityname as cli_ville,  " +

                "if (fact.nbrmens > 0, 'oui', 'non') as modemens, fact.nbrmens, article.idarticle, article.codearticle, concat_ws('\n', article.descriptif_ligne1, if (article.remarque = '', null, article.remarque)) as libellearticle, client.idclient, fact.identreprise, fact.idfacture, prix.idprix, rabais.idrabais " +

                "fROM " +
                "fact_facturation fact inner join (select idfacture, concat('000000', LPAD(identreprise, 4, '0'), LPAD(reffacturedeltareal, 10, '0'), date_format(if(isnull(dateimpression), now(), dateimpression), '%y%m%d'), ccpmodulo(concat('000000', LPAD(identreprise, 4, '0'), LPAD(reffacturedeltareal, 10, '0'), date_format(if(isnull(dateimpression), now(), dateimpression), '%y%m%d')))) as numbvrcomplet FROM fact_facturation) fbvr ON fbvr.idfacture = fact.idfacture " +

                "INNER join fact_entreprise entreprise on entreprise.identreprise = fact.identreprise " +
                "LEFT JOIN (select identreprise, numfacture, datepaiement, sum(montant) as montantpaye FROM fact_paiement GROUP BY identreprise, numfacture order by datepaiement desc) paiement ON paiement.identreprise = fact.identreprise AND fact.reffacturedeltareal = paiement.numfacture " +

                "left join " + Fmain.baseInit + ".client clidel on clidel.idclient = entreprise.iddeltareal " +
                "LEFT JOIN fact_entreprisefonction fonccli ON fonccli.identreprise = entreprise.identreprise AND(fonccli.idfonction = 10) " +
                "LEFT JOIN " + Fmain.baseInit + ".clientfonction foncdel ON foncdel.idclient = entreprise.iddeltareal AND(foncdel.idfonctiondelta = 10) " +
                "LEFT join " + Fmain.baseInit + ".typepolitesse polent ON polent.idpolitesse = if (entreprise.iddeltareal > 0, foncdel.idpolitesse, fonccli.idpolitesse)  " +
                "LEFT join " + Fmain.baseInit + ".language langent ON langent.idlanguage = polent.idlangue " +
                "left join " + Fmain.baseInit + ".city clicity ON clicity.idcity = if (entreprise.iddeltareal > 0, foncdel.idville, fonccli.idville)  " +
                "LEFT JOIn " + Fmain.baseInit + ".cpta_banque banque ON banque.idbanque = if (entreprise.iddeltareal > 0, foncdel.idbanque, fonccli.idbanque) " +

                "LEFT JOIN fact_client client ON client.idclient = fact.idclient left join   " + Fmain.baseInit + ".city ON city.idcity = client.idville left join " + Fmain.baseInit + ".typepolitesse clientpolitesse ON client.idpolitesse = clientpolitesse.idpolitesse " +

                "LEFT join fact_articles article ON article.idarticle = fact.idarticle left join (select idprix, idarticleprix, prix, dateprix from fact_prix group by idarticleprix, idprix order by dateprix desc) prix on prix.idarticleprix = article.idarticle and prix.idprix = fact.idprix " +
                "LEFT JOIN(Select idrabais, idarticlerabais, rabaismontant, rabaispourcent, daterabaisde, daterabaisa FROM fact_rabais group by idarticlerabais, idrabais order by daterabaisa desc) rabais ON rabais.idarticlerabais = article.idarticle AND fact.idrabais = rabais.idrabais " +
                "LEFT JOIN fact_unite unite ON unite.idunite = article.idunite " +
                "ORDER by fact.reffacturedeltareal, fact.idclient, fact.numligne";

            if (cond != "")
            {
                tri = tri.Replace("ORDER", "WHERE " + cond + " ORDER");
            }

            realvistaDataSetTableAdapters.facturationTableAdapter Facturations = new realvistaDataSetTableAdapters.facturationTableAdapter();
            clientBindingSource.ResetBindings(false);
            Facturations.ClearBeforeFill = true;
            clientBindingSource.DataMember = "facturation";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dd);
            reportViewer1.LocalReport.DataSources[0].Value = clientBindingSource;
            //reportViewer1.LocalReport.EnableExternalImages = true;
            string p = "";
            string rap = "";
            if (brappel)
            {
                p = uf.ValeurParCond(comrech, "fact_entreprise", "texterappel", "texterappel", "identreprise =" + Fmain.identreprisesel);
                rap = "Rappel : ";
            }
            else
            {
                p = uf.ValeurParCond(comrech, "fact_entreprise", "pub", "pub", "identreprise =" + Fmain.identreprisesel);
                rap = "";
            }
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("publicite", p));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("rappel", rap));
            Facturations.Fill(realvistaDataSet.facturation, tri);
            if (clientBindingSource.Position == -1)
            {
                uf.message_info("Il n'y a pas de données !");
                return;
            }
            reportViewer1.Show();
            reportViewer1.Visible = true;
            reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        
        private void bntValid_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            if (uf.confirmer_questionON(this, "Etes-vous sûre de valider ?") == DialogResult.Yes)
            {
                DataTableReader rr = realvistaDataSet.facturation.CreateDataReader();

                string numf = "";
                decimal mttbrutmoinsrabais = 0;
                decimal mttapayer = 0;
                int numfolio = 0;
                string idcomptedebit = "";
                string idcomptefacture = "";
                string nomprenom = "";
                if (!brappel)
                {

                    numfolio = int.Parse(Fmain.Maxsuivant(Fmain.nombasecompta + ".cpta_mouvement", "numfolio", "year(datemouvement) = " + DateTime.Now.Year.ToString()));

                    idcomptedebit = uf.ValeurParCond(comrech, Fmain.nombasecompta + ".cpta_compte", "idcompte, codecompte", "idcompte", "codecompte = " + Fmain.comptedebit);
                    idcomptefacture = uf.ValeurParCond(comrech, Fmain.nombasecompta + ".cpta_compte", "idcompte, codecompte", "idcompte", "codecompte = " + Fmain.comptefacture);
                    
                }

                while (rr.Read())
                {
                    if (numf != rr.GetValue(rr.GetOrdinal("fact_nofacture")).ToString())
                    {
                        if (brappel)
                        {
                            if (numf != "")
                            {
                                uf.executeSQL(comrealvistamod, "fact_facturation", "dateecheance, rappel", string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancerappel")).ToString()))) + "$" + "##rappel+1", 1, "identreprise = " + Fmain.identreprisesel + " AND reffacturedeltareal = '" + numf + "'");
                                uf.executeSQL(comrealvistamod, "fact_procedures", "identreprise,idclient,numfacture,inouttype,initial,dateproc,typecourrier,echeanceproc",
                                    Fmain.identreprisesel + "$" + rr.GetValue(rr.GetOrdinal("iCli")).ToString() + "$" + numf + "$" + "out" + "$" + Fmain.InitUser + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "Rappel " + ((int.Parse(rr.GetValue(rr.GetOrdinal("fact_nbrrappel")).ToString())) + 1).ToString() + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancerappel")).ToString()))), 2, "");
                            }
                        }
                        else
                        {
                            if (numf != "")
                            {
                                string newid = uf.executeSQL(comrealvistamod, Fmain.nombasecompta + ".cpta_mouvement", "numfolio,datesaisie,datemouvement,typeecriture,idcompte,codecompte,idcomptec,codecomptec,libelledetail,entree,sortie",
                                    numfolio.ToString() + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "1" + "$" + idcomptedebit + "$" + Fmain.comptedebit + "$" + idcomptefacture + "$" + Fmain.comptefacture + "$" + numf + " " + nomprenom + "$" + uf.getFormatCur(mttapayer, false) + "$" + "0", 2, "");
                                uf.executeSQL(comrealvistamod, "fact_facturation", "dateimpression, dateecheance, idmouvementenvoye", string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString()))) + "$" + newid, 1, "identreprise = " + Fmain.identreprisesel + " AND reffacturedeltareal ='" + numf + "'");
                                uf.executeSQL(comrealvistamod, "fact_procedures", "identreprise,idclient,numfacture,inouttype,initial,dateproc,typecourrier,echeanceproc",
                                Fmain.identreprisesel + "$" + rr.GetValue(rr.GetOrdinal("iCli")).ToString() + "$" + numf + "$" + "out" + "$" + Fmain.InitUser + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "Facture" + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString()))), 2, "");

                                numfolio++;
                            }
                            mttapayer = 0;

                            
                        }
                        numf = rr.GetValue(rr.GetOrdinal("fact_nofacture")).ToString();
                    }
                    if (!brappel)
                    {
                        mttbrutmoinsrabais = rr.GetDecimal(rr.GetOrdinal("art_montantbrut")) - rr.GetDecimal(rr.GetOrdinal("art_rabaischf"));
                        mttapayer += mttbrutmoinsrabais + (mttbrutmoinsrabais * decimal.Parse(rr.GetValue(rr.GetOrdinal("fact_tvapourcent")).ToString()) / 100);
                        nomprenom = rr.GetString(rr.GetOrdinal("cli_nom")) + " " + rr.GetString(rr.GetOrdinal("cli_prenom")) + " " + rr.GetString(rr.GetOrdinal("cli_npa")) + " " + rr.GetString(rr.GetOrdinal("cli_ville"));
                    }
                }
                if (numf != "")
                {
                    if (brappel)
                    {
                        //uf.executeSQL(comrealvistamod, "fact_facturation", "dateecheance, rappel", string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString()))) + "$" + "##rappel+1", 1, "identreprise = " + Fmain.identreprisesel + " AND reffacturedeltareal = '" + numf + "'");
                        uf.executeSQL(comrealvistamod, "fact_facturation", "dateecheance, rappel", string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancerappel")).ToString()))) + "$" + "##rappel+1", 1, "identreprise = " + Fmain.identreprisesel + " AND reffacturedeltareal = '" + numf + "'");
                        uf.executeSQL(comrealvistamod, "fact_procedures", "identreprise,idclient,numfacture,inouttype,initial,dateproc,typecourrier,echeanceproc",
                            Fmain.identreprisesel + "$" + rr.GetValue(rr.GetOrdinal("iCli")).ToString() + "$" + numf + "$" + "out" + "$" + Fmain.InitUser + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "Rappel " + ((int.Parse(rr.GetValue(rr.GetOrdinal("fact_nbrrappel")).ToString())) + 1).ToString() + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancerappel")).ToString()))), 2, "");
                        //Fmain.identreprisesel + "$" + rr.GetValue(rr.GetOrdinal("iCli")).ToString() + "$" + numf + "$" + "out" + "$" + Fmain.InitUser + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "Rappel" + rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString().Substring(rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString().IndexOf("A") + 1) + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString()))), 2, "");

                    }
                    else
                    {
                        string newid = uf.executeSQL(comrealvistamod, Fmain.nombasecompta + ".cpta_mouvement", "numfolio,datesaisie,datemouvement,typeecriture,idcompte,codecompte,idcomptec,codecomptec,libelledetail,entree,sortie",
                        numfolio.ToString() + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "1" + "$" + idcomptedebit + "$" + Fmain.comptedebit + "$" + idcomptefacture + "$" + Fmain.comptefacture + "$" + numf + " " + nomprenom + "$" + uf.getFormatCur(mttapayer, false) + "$" + "0", 2, "");
                        uf.executeSQL(comrealvistamod, "fact_facturation", "dateimpression, dateecheance, idmouvementenvoye", string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString()))) + "$" + newid, 1, "identreprise = " + Fmain.identreprisesel + " AND reffacturedeltareal ='" + numf + "'");
                        uf.executeSQL(comrealvistamod, "fact_procedures", "identreprise,idclient,numfacture,inouttype,initial,dateproc,typecourrier,echeanceproc",
                                Fmain.identreprisesel + "$" + rr.GetValue(rr.GetOrdinal("iCli")).ToString() + "$" + numf + "$" + "out" + "$" + Fmain.InitUser + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "Facture" + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(int.Parse(rr.GetValue(rr.GetOrdinal("ent_echeancejour")).ToString()))), 2, "");
                        numfolio++;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bntFemer_Click(object sender, EventArgs e)
        {

        }
    }
}
