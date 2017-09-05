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
using System.IO;
using System.Globalization;

namespace DeltaFact
{
    public partial class f_gesfact : Form
    {
        public f_gesfact()
        {
            InitializeComponent();
        }

        util_fact uf = new util_fact();
        string sqlfact = "";
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);
        MySqlDataReader myread;
        List<string> factcontrol = new List<string>(1);
        List<string> factvaleur = new List<string>(1);
        f_selcode fcode = new f_selcode();

        public decimal dfraisenvoi = 0;
        public decimal dfraisassurance = 0;
        public decimal dinterets = 0;
        public decimal dfraisrappel = 0;

        public bool ajoutdepuisclient = false;
        public string curidcli = "";
        
        private HorizontalAlignment halign(DataGridViewContentAlignment gvhalign)
        {
            if (gvhalign == DataGridViewContentAlignment.NotSet || gvhalign == DataGridViewContentAlignment.TopLeft)
                return HorizontalAlignment.Left;
            else if (gvhalign == DataGridViewContentAlignment.TopRight)
                return HorizontalAlignment.Right;
            else if (gvhalign == DataGridViewContentAlignment.TopCenter)
                return HorizontalAlignment.Center;
            else
                return HorizontalAlignment.Left;
        }


        public string loadclient(string id = "")
        {

            string reqclient = "select cli.idclient as refclient, concat_ws(' ', if(trim(socligne) = '', null, socligne), if(trim(cli.nom) = '', null, cli.nom), " +
                "if(trim(cli.prenom) = '', null, cli.prenom), ', ', if(trim(cli.co) = '', null, cli.co), concat_ws(' ', if(trim(cli.adresse1) = '', null, cli.adresse1), if(trim(cli.adresse2) = '', null, cli.adresse2)), " +
                "city.zip, city.cityname) as client FROM fact_client cli " +
                "left join " + Fmain.baseInit + ".city ON city.idcity = cli.idville where cli.idclient =" + id + " " +
                "ORDER BY nom, prenom, socligne";
            comrech.CommandText = reqclient;
            myread = comrech.ExecuteReader();
            string val = "";
            if (myread.Read())
            {
                val = uf.GetValue(myread, "client");
            }
            myread.Close();
            return val;
        }

        public bool loadfrompaiement = false;
        private void f_gesfact_Load(object sender, EventArgs e)
        {
            //tp_facture.ResetText();
            
            /*Size s = new Size(tp_facture.ItemSize.Width, 80);
            tp_facture.ItemSize = s;
            tp_facture.TabPages[0].Text = "aaaaaaaaaaaaaa\naaa\naaa\n";
            tp_facture.TabPages[4].Text = "aaaaaaaaaaaaaa\naaa\naaa\n";
            tp_facture.TabPages[3].Text = "aaaaaaaaaaaaaa\naaa\naaa\n";
            tp_facture.TabPages[2].Text = "aaaaaaaaaaaaaa\naaa\naaa\n";
            tp_facture.TabPages[1].Text = "aaaaaaaaaaaaaa\naaa\naaa\n";
            
            tp_facture.Refresh();*/
            lb_entreprise.Text = uf.ValeurParCond(comrealvistamod, "fact_entreprise entreprise left join " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal ", "if (entreprise.iddeltareal > 0, concat(clidelta.socligne1, ' ', clidelta.socligne2), concat(entreprise.socligne1, ' ', entreprise.socligne2)) as entreprise", "entreprise", "identreprise =" + Fmain.identreprisesel);
            
            lv.Groups.Clear();
            for (int i =0; i< gv_fact.Columns.Count; i++)
            {
                int wid = 0;
                if (gv_fact.Columns[i].Visible == false)
                    wid = 0;
                else
                    wid = gv_fact.Columns[i].Width;
                lv.Columns.Add(gv_fact.Columns[i].Name, gv_fact.Columns[i].HeaderText, wid, halign(gv_fact.Columns[i].DefaultCellStyle.Alignment), -1);

            }

            
            uf.initialisation(p_facture);
            remplirvaleursauve();

            fcode.Owner = this;
            fcode.DeltaSQLCon.Connection = comrech.Connection;
            //fcode.Initialisation();
            //
            int nb = 0;


            //(Fmain.identreprisesel);
            impressionComptableToolStripMenuItem.Enabled = false;
            if (!ajoutdepuisclient)
            {
                if (loadfrompaiement)
                {
                    tp_facture.SelectedIndex = 4;
                    impressionComptableToolStripMenuItem.Enabled = true;

                }
                else
                    chargerfacture(cond);
                //tp_facture.SelectedIndex = -1;
            }
            else
            {
                ajoutevent();

            }
            
            loadfrompaiement = false;
        }

        private void remplirvaleursauve()
        {
            foreach (Control c in p_facture.Controls)
            {
                if (c.GetType().Name == typeof(TextBox).Name || c.GetType().Name == typeof(DateTimePicker).Name)
                {
                    factcontrol.Add(c.Name);
                    factvaleur.Add(c.Text);
                }
            }
        }
        private void gv_fact_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex >= 2 && gv_fact.Rows[e.RowIndex].Cells[0].Value.ToString() == "Client")
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            else
                e.AdvancedBorderStyle.Right = gv_fact.AdvancedCellBorderStyle.Right ;

        }

        public string cond = "";
        System.Drawing.Font tFont = new System.Drawing.Font("Arial", 9, FontStyle.Bold);
        System.Drawing.Font tFontnorm = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
        System.Drawing.Font tFontit = new System.Drawing.Font("Arial", 9, FontStyle.Italic);

        int ordercli = 0;
        private void chargerfacture(string temprech = "", int orderclitmp = 0)
        {
            bt_ajout.Enabled = bt_listepaiement.Enabled = false;
                ordercli = orderclitmp;
            int i = 0;
            Color colore = Color.White;

            string iCli = "";
            string sreffacturedeltareal = "";
            int snbrarticle = 0;
            int tnbrarticle = 0;
            decimal tmontantbrut = 0;
            decimal trabaisarticlechf = 0;
            decimal trabaisfacturechf = 0;
            decimal smontantbrut = 0;
            decimal srabaisarticlechf = 0;
            decimal srabaisfacturechf = 0;

            decimal ttvachf = 0;
            decimal stvachf = 0;
            decimal tfraisenvoi = 0;
            decimal sfraisenvoi = 0;
            decimal tfraisassurance = 0;
            decimal sfraisassurance = 0;
            decimal tinterets = 0;
            decimal sinterets = 0;
            decimal tfraisrappel = 0;
            decimal sfraisrappel = 0;
            decimal tmontantapayer = 0;
            decimal smontantapayer = 0;
            decimal tmontantpaye = 0;
            decimal smontantpaye = 0;
            decimal tsolde = 0;
            decimal ssolde = 0;
            string tdateimpression = "";
            string tdateecheance = "";
            string cc = "";
            if (cond != "")
                cc = cond + " AND ";
            //if (cc.Contains("client."))
            //    cc = cc.Replace("client.", "");
            //tp_facture.ResetText();
            string texte = uf.ValeurParCond(comrech, "fact_facturation fact left join fact_client client on client.idclient = fact.idclient", "concat ('nbr : ', count(distinct reffacturedeltareal), ' ', 'mtt : ', sum(montantapayer)) as textetot", "textetot", cc + "identreprise = " + Fmain.identreprisesel + " AND dateimpression is null group by identreprise");
            if (texte == "")
                texte = "nbr : 0 mtt : 0.00";
            lb_nbrsai.Text = texte.Substring(0, texte.IndexOf("mtt")).Trim();
            lb_mttsai.Text = texte.Substring(texte.IndexOf("mtt")).Trim();

            texte = uf.ValeurParCond(comrech, "fact_facturation fact left join fact_client client on client.idclient = fact.idclient LEFT JOIN (select identreprise, numfacture, sum(montant) as montantpaye FROM fact_paiement GROUP BY identreprise, numfacture) paiement ON paiement.identreprise = fact.identreprise AND fact.reffacturedeltareal = paiement.numfacture ", "concat ('nbr : ', count(distinct reffacturedeltareal), ' ', 'mtt : ', sum(montantapayer)) as textetot", "textetot", cc + " fact.identreprise = " + Fmain.identreprisesel + " AND fact.dateimpression is not null AND fact.rappel = 0 AND fact.dateecheance >= now()  AND (paiement.montantpaye = 0 OR paiement.montantpaye IS NULL OR paiement.montantpaye < fact.montantapayer) group by fact.identreprise");
            if (texte == "")
                texte = "nbr : 0 mtt : 0.00";
            lb_nbrenv.Text = texte.Substring(0, texte.IndexOf("mtt")).Trim();
            lb_mttenv.Text = texte.Substring(texte.IndexOf("mtt")).Trim();


            string condrap = "";
            if (ck_rap1.Checked && ck_rap2.Checked)
                condrap = "";
            else
            {
                if (ck_rap1.Checked)
                    condrap = " AND fact.rappel = 1 ";
                if (ck_rap2.Checked)
                    condrap = " AND fact.rappel = 2 ";
            }
            texte = uf.ValeurParCond(comrech, "fact_facturation fact left join fact_client client on client.idclient = fact.idclient LEFT JOIN (select identreprise, numfacture, sum(montant) as montantpaye FROM fact_paiement GROUP BY identreprise, numfacture) paiement ON paiement.identreprise = fact.identreprise AND fact.reffacturedeltareal = paiement.numfacture ", "concat ('nbr : ', count(distinct reffacturedeltareal), ' ', 'mtt : ', sum(montantapayer)) as textetot", "textetot", cc + " fact.identreprise = " + Fmain.identreprisesel + " AND fact.dateimpression is not null AND fact.rappel > 0 " + condrap + " AND fact.dateecheance >= now()  AND (paiement.montantpaye = 0 OR paiement.montantpaye IS NULL OR paiement.montantpaye < fact.montantapayer) group by fact.identreprise");
            if (texte == "")
                texte = "nbr : 0 mtt : 0.00";
            lb_nbrrap.Text = texte.Substring(0, texte.IndexOf("mtt")).Trim();
            lb_mttrap.Text = texte.Substring(texte.IndexOf("mtt")).Trim();


            texte = uf.ValeurParCond(comrech, "fact_facturation fact left join fact_client client on client.idclient = fact.idclient LEFT JOIN (select identreprise, numfacture, sum(montant) as montantpaye FROM fact_paiement GROUP BY identreprise, numfacture) paiement ON paiement.identreprise = fact.identreprise AND fact.reffacturedeltareal = paiement.numfacture ", "concat ('nbr : ', count(distinct reffacturedeltareal), ' ', 'mtt : ', sum(montantapayer)) as textetot", "textetot", cc + " fact.identreprise = " + Fmain.identreprisesel + " AND fact.dateimpression is not null AND fact.dateecheance < now()  and fact.rappel > -1 AND (paiement.montantpaye < fact.montantapayer or paiement.montantpaye is null) group by fact.identreprise");
            if (texte == "")
                texte = "nbr : 0 mtt : 0.00";
            lb_nbrech.Text = texte.Substring(0, texte.IndexOf("mtt")).Trim();
            lb_mttech.Text = texte.Substring(texte.IndexOf("mtt")).Trim();

            texte = uf.ValeurParCond(comrech, "fact_facturation fact left join fact_client client on client.idclient = fact.idclient LEFT JOIN (select identreprise, numfacture, sum(montant) as montantpaye FROM fact_paiement GROUP BY identreprise, numfacture) paiement ON paiement.identreprise = fact.identreprise AND fact.reffacturedeltareal = paiement.numfacture ", "concat ('nbr : ', count(distinct reffacturedeltareal), ' ', 'mtt : ', sum(montantapayer)) as textetot", "textetot", cc + " fact.identreprise = " + Fmain.identreprisesel + " AND fact.dateimpression is not null AND paiement.montantpaye >= fact.montantapayer group by fact.identreprise");
            if (texte == "")
                texte = "nbr : 0 mtt : 0.00";
            lb_nbrpay.Text = texte.Substring(0, texte.IndexOf("mtt")).Trim();
            lb_mttpay.Text = texte.Substring(texte.IndexOf("mtt")).Trim();

            texte = uf.ValeurParCond(comrech, "fact_facturation fact left join fact_client client on client.idclient = fact.idclient  ", "concat ('nbr : ', count(distinct reffacturedeltareal), ' ', 'mtt : ',  sum(montantapayer)) as textetot", "textetot", cc + "identreprise = " + Fmain.identreprisesel + " group by identreprise");
            if (texte == "")
                texte = "nbr : 0 mtt : 0.00";
            lb_nbrtou.Text = texte.Substring(0, texte.IndexOf("mtt")).Trim();
            lb_mtttou.Text = texte.Substring(texte.IndexOf("mtt")).Trim();

            ajoutdepuisclient = false;
            tp_facture.Refresh();
            sqlfact = "select fact.numligne, fact.remarquearticle, " +
                "fact.reffacturedeltareal, fact.reffactureentreprise, " +
                "fact.idfacture, entreprise.identreprise, entreprise.iddeltareal,  " +
                "client.idclient as iCli, concat_ws(' ', if(trim(socligne) = '', null, socligne), if(trim(client.nom) = '', null, client.nom), " +
                "if(trim(client.prenom) = '', null, client.prenom), ', ', if(trim(client.co) = '', null, client.co), concat_ws(' ', if(trim(client.adresse1) = '', null, client.adresse1), if(trim(client.adresse2) = '', null, client.adresse2)), " +
                "city.zip, city.cityname) as client, " +
                "date_format(fact.datecommande, '%d.%m.%Y') as datecommande, date_format(fact.datefactureentreprise, '%d.%m.%Y') as datefacture, date_format(fact.dateimpression, '%d.%m.%Y') as dateimpression, " +
                "prix.prix as prixunitaire, fact.rappel as rappel, " + //prix à prendre dans table des prix
                "if (fact.nbrmens > 0, 'oui', 'non') as modemens, fact.nbrmens, fact.nbr as nbrarticle, fact.tauxtva as tvapourcent, " +
                "date_format(fact.dateecheance, '%d.%m.%Y') as dateecheance, fact.nbr * prix.prix as montantbrut, " + //prix à prendre dans table des prix
                "if(rabais.rabaispourcent>0, concat(rabais.rabaispourcent, '%'), '-') as rabaisarticlepourcent, " +
                "if(if(isnull(rabais.rabaispourcent), 0, rabais.rabaispourcent) > 0, (fact.nbr* prix.prix) * rabais.rabaispourcent/100, if(isnull(rabais.rabaismontant), 0, rabais.rabaismontant)) as rabaisarticlechf,  " + //à prendre dans table rabais
                "fact.fraisenvoi, fact.interets, fact.fraisassurance, fact.fraisrappel, paiement.montantpaye as montantpaye, article.idarticle, " +
                "article.codearticle, concat_ws('\n', article.descriptif_ligne1, if(article.remarque='', null, article.remarque)) as libellearticle, unite.unitelibelle as unite, client.idclient, fact.identreprise, fact.idfacture, prix.idprix, rabais.idrabais " +
                "from " +
                "fact_facturation fact INNER join fact_entreprise entreprise ON entreprise.identreprise = fact.identreprise and entreprise.identreprise = " + Fmain.identreprisesel + " " +
                "LEFT JOIN (select identreprise, numfacture, sum(montant) as montantpaye FROM fact_paiement GROUP BY identreprise, numfacture) paiement ON paiement.identreprise = fact.identreprise AND fact.reffacturedeltareal = paiement.numfacture " +
                "LEFT JOIN  " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal " +
                "LEFT JOIN fact_client client ON client.idclient = fact.idclient left join  " + Fmain.baseInit + ".city ON city.idcity = client.idville " +
                "LEFT join fact_articles article ON article.idarticle = fact.idarticle left join (select idprix, idarticleprix, prix, dateprix from fact_prix group by idarticleprix, idprix order by dateprix desc) prix on prix.idarticleprix = article.idarticle and prix.idprix = fact.idprix " +
                "LEFT JOIN (Select idrabais, idarticlerabais, rabaismontant, rabaispourcent, daterabaisde, daterabaisa FROM fact_rabais group by idarticlerabais, idrabais order by daterabaisa desc) rabais ON rabais.idarticlerabais = article.idarticle AND fact.idrabais = rabais.idrabais " +
                "LEFT JOIN fact_unite unite ON unite.idunite = article.idunite ";
            if (temprech != "") 
                sqlfact += " WHERE " + temprech;
            else if (cond != "")
                sqlfact += " WHERE " + cond;

            if (tp_facture.SelectedIndex == 1) //envoyées mais non payées en totalité et pas à écheance et pas encore de rappel 
            {
                if (temprech != "" || cond != "")
                {
                    sqlfact += " AND ";
                }
                else if (temprech == "" && cond == "")
                {
                    sqlfact += " WHERE ";
                }
                sqlfact += " fact.dateimpression is not null and fact.rappel = 0 AND fact.dateecheance >= now() AND (paiement.montantpaye = 0 OR paiement.montantpaye IS NULL OR paiement.montantpaye < fact.montantapayer)";
            }
            else if (tp_facture.SelectedIndex == 2) //envoyées mais non payées en totalité et pas à écheance et rappel déja envoyé
            {
                if (temprech != "" || cond != "")
                {
                    sqlfact += " AND ";
                }
                else if (temprech == "" && cond == "")
                {
                    sqlfact += " WHERE ";
                }
                sqlfact += " fact.dateimpression is not null and fact.rappel > 0 " + condrap + " AND fact.dateecheance >= now() AND (paiement.montantpaye = 0 OR paiement.montantpaye IS NULL OR paiement.montantpaye < fact.montantapayer)";
            }
            else if (tp_facture.SelectedIndex == 0) //saisies non encore envoyées
            {
                if (temprech != "" || cond != "")
                {
                    sqlfact += " AND ";
                }
                else if (temprech == "" && cond == "")
                {
                    sqlfact += " WHERE ";
                }
                sqlfact += " fact.dateimpression is null";
            }
            else if (tp_facture.SelectedIndex == 3) //envoyées et à écheance
            {
                if (temprech != "" || cond != "")
                {
                    sqlfact += " AND ";
                }
                else if (temprech == "" && cond == "")
                {
                    sqlfact += " WHERE ";
                }
                sqlfact += " fact.dateimpression is not null AND fact.dateecheance < now() and fact.rappel > -1 and (paiement.montantpaye < fact.montantapayer OR paiement.montantpaye is null)";
            }
            else if(tp_facture.SelectedIndex == 4) //payées
            {
                if (temprech != "" || cond != "")
                {
                    sqlfact += " AND ";
                }
                else if (temprech == "" && cond == "")
                {
                    sqlfact += " WHERE ";
                }
                sqlfact += " fact.dateimpression is not null AND paiement.montantpaye >= fact.montantapayer";
            }
            if (ordercli == 0)
                sqlfact += " order by fact.reffacturedeltareal desc, fact.numligne";
            else
                sqlfact += " order by client.idclient desc, fact.reffacturedeltareal desc, fact.numligne";

            if (cond.Contains("idclient"))
                this.Text = "Gestion de Facturation - Résultat de recherche par Client";
            else if (cond.Contains("reffacturedeltareal"))
                this.Text = "Gestion de Facturation - Résultat de recherche par réf. Facture";
            else
                this.Text = "Gestion de Facturation";
            gv_fact.Rows.Clear();
            initialisation();

            comrealvistamod.CommandText = sqlfact;
            myread = comrealvistamod.ExecuteReader();

            lv.Items.Clear();
            lv.Groups.Clear();
            int nbrGroup = 0;
            int nbrGroupFact = 0;
            
            //Pb.Show();
            int iddos = 0;
            //Pb.Maximum = tmpRead.RecordsAffected;
            decimal totalfactmtt = 0;
            int totalfactnbr = 0;
            while (myread.Read())
            {
                if (uf.GetValue(myread, "numligne") == "0")
                {
                    tdateimpression = uf.GetValue(myread, "dateimpression");
                    tdateecheance = uf.GetValue(myread, "dateecheance");
                }
                if (uf.GetValue(myread, "reffacturedeltareal") != sreffacturedeltareal) //nouveau facture
                {
                    if (sreffacturedeltareal != "")
                    {
                        lv.Items.Add("Total ");
                        lv.Items[i].BackColor = colore;
                        //lv.Items[i].ForeColor = Color.Blue;
                        lv.Items[i].Font = tFontnorm;
                        lv.Items[i].Group = lv.Groups[iCli];
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add(snbrarticle.ToString());
                        lv.Items[i].SubItems.Add(uf.getFormatCur(smontantbrut, true));
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add(uf.getFormatCur(srabaisfacturechf, true));
                        //lv.Items[i].SubItems.Add(uf.getFormatCur((smontantbrut - srabaisfacturechf) * decimal.Parse(uf.GetValueNonRound(myread, "tvapourcent"))/100, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(stvachf, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(sfraisenvoi, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(sfraisassurance, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(sinterets, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(sfraisrappel, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(smontantapayer, true));
                        totalfactmtt += smontantapayer;
                        totalfactnbr++;
                        lv.Items[i].SubItems.Add(tdateimpression);
                        //lv.Items[i].UseItemStyleForSubItems = false;
                        lv.Items[i].SubItems.Add(tdateecheance);
                        //if (DateTime.Parse(tdateecheance) < DateTime.Now)
                        //    lv.Items[i].SubItems[17].BackColor = Color.Red;
                        lv.Items[i].SubItems.Add(uf.getFormatCur(smontantpaye, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(smontantapayer - smontantpaye, true));
                         
                        //données non affichées facture
                        lv.Items[i].SubItems.Add(uf.GetValue(myread, "idfacture"));
                        lv.Items[i].SubItems.Add(uf.GetValue(myread, "identreprise"));
                        lv.Items[i].SubItems.Add(uf.GetValue(myread, "idclient"));
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");

                        //
                        lv.Items.Add("");
                        i++;
                        lv.Items[i].Group = lv.Groups[iCli];
                        
                        i++;
                    }
                    sreffacturedeltareal = uf.GetValue(myread, "reffacturedeltareal");
                    tnbrarticle += snbrarticle;
                    tmontantbrut += smontantbrut;
                    trabaisfacturechf += srabaisfacturechf;
                    ttvachf += stvachf;
                    tfraisenvoi += sfraisenvoi;
                    tfraisassurance += sfraisassurance;
                    tinterets += sinterets;
                    tfraisrappel += sfraisrappel;
                    tmontantapayer += smontantapayer;
                    tmontantpaye += smontantpaye;

                    //lv.Groups.Add(uf.GetValue(myread, "reffacturedeltareal"), uf.GetValue(myread, "reffacturedeltareal"));
                    //lv.Groups[uf.GetValue(myread, "reffacturedeltareal")].ListView.BackColor = Color.PaleGreen;

                    snbrarticle = 0;
                    smontantbrut = srabaisfacturechf = stvachf = sfraisenvoi = sfraisassurance = sinterets = sfraisrappel = smontantapayer = smontantpaye = ssolde = 0;

                    nbrGroupFact++;
                }

                
                if ((ordercli == 1 && uf.GetValue(myread, "icli") != iCli) || (ordercli == 0 && "F" + uf.GetValue(myread, "reffacturedeltareal") != iCli)) //nouveau client ou nouveau facture si order by fact
                {
                    nbrGroupFact = 0;
                    //Total
                    if (iCli != "" && ordercli == 1)
                    {
                        lv.Items.Add("Total Factures Client :");
                        lv.Items[i].BackColor = colore;
                        lv.Items[i].ForeColor = Color.Blue;
                        lv.Items[i].Font = tFontnorm;
                        lv.Items[i].Group = lv.Groups[iCli];
                        
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("A Payer");
                        lv.Items[i].SubItems.Add(uf.getFormatCur(tmontantapayer, true));
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("Payés :");
                        lv.Items[i].SubItems.Add(uf.getFormatCur(tmontantpaye, true));
                        lv.Items[i].SubItems.Add(uf.getFormatCur(tmontantapayer - tmontantpaye, true));

                        tmontantbrut = trabaisfacturechf = ttvachf = tfraisenvoi = tfraisassurance = tinterets = tfraisrappel = tmontantapayer = tmontantpaye = tsolde = 0;

                        lv.Items.Add("");
                        i++;
                        lv.Items[i].Group = lv.Groups[iCli];
                        i++;
                    }
                    nbrGroup++;

                    if (ordercli == 1)
                        iCli = uf.GetValue(myread, "icli");
                    else
                        iCli = "F" + uf.GetValue(myread, "reffacturedeltareal");
                    ListViewGroupCollection f;
                    
                    lv.Groups.Add(iCli, "Client " + uf.GetValue(myread, "icli").PadLeft(4, '0')+ " - " + uf.GetValue(myread, "client"));
                    //lv.Groups.Add(uf.GetValue(myread, "icli"), "Client " + uf.GetValue(myread, "icli").PadLeft(4, '0')+ " - " + uf.GetValue(myread, "client"));
                    //iCli = uf.GetValue(myread, "icli");
                    
                    
                }


                if (uf.GetValue(myread, "numligne") == "1")
                {
                    if (uf.GetValue(myread, "numligne") == "1")
                    {
                        /*if (nbrGroupFact > 0)
                        {
                            lv.Items.Add("");
                            lv.Items[i].Group = lv.Groups[iCli];
                            i++;
                        }*/
                        lv.Items.Add(uf.GetValue(myread, "reffacturedeltareal")); //première ligne facture
                        lv.Items[i].Group = lv.Groups[iCli];
                        
                        lv.Items[i].UseItemStyleForSubItems = false;
                        lv.Items[i].SubItems[0].Font = tFont;
                        //lv.Items[i].BackColor = Color.AntiqueWhite;
                        //lv.Items[i].SubItems.Add(uf.GetValue(myread, "reffactureentreprise"));
                        lv.Items[i].SubItems.Add(uf.GetValue(myread, "reffactureentreprise"));
                        lv.Items[i].SubItems.Add(uf.GetValue(myread, "datecommande"));
                        //stvachf = decimal.Parse(uf.GetValueNonRound(myread, "tvachf"));
                        sfraisenvoi = decimal.Parse(uf.GetValueNonRound(myread, "fraisenvoi"));
                        sfraisassurance = decimal.Parse(uf.GetValueNonRound(myread, "fraisassurance"));
                        sinterets = decimal.Parse(uf.GetValueNonRound(myread, "interets"));
                        sfraisrappel = decimal.Parse(uf.GetValueNonRound(myread, "fraisrappel"));
                        
                        smontantpaye = decimal.Parse(uf.GetValueNonRound(myread, "montantpaye"));
                        tdateecheance = uf.GetValue(myread, "dateecheance");

                        tdateimpression = uf.GetValue(myread, "dateimpression");

                        
                    }
                }
                else
                {
                    //lv.Items.Add(uf.GetValue(myread, "reffacturedeltareal") + "_" + uf.GetValue(myread, "numligne"), ); 
                    //if (etatfact == 0)
                    //{
                        lv.Items.Add(""); //première ligne facture
                        lv.Items[i].Group = lv.Groups[iCli];
                        lv.Items[i].SubItems.Add("");
                        lv.Items[i].SubItems.Add("");
                    //}
                }





                snbrarticle += int.Parse(uf.GetValue(myread, "nbrarticle"));
                    smontantbrut += decimal.Parse(uf.GetValueNonRound(myread, "montantbrut"));
                    srabaisfacturechf += decimal.Parse(uf.GetValueNonRound(myread, "rabaisarticlechf"));
                stvachf = (smontantbrut - srabaisfacturechf) * decimal.Parse(uf.GetValueNonRound(myread, "tvapourcent"))/100;
                    smontantapayer = smontantbrut - srabaisfacturechf + stvachf + sfraisenvoi + sfraisassurance + sfraisrappel + sinterets;
                //if (((double.Parse(i.ToString()) / 2) - (i / 2)) > 0)
                //    lv.Items[i].BackColor = Color.Beige;
                //else


                //ty le resaka couleur
                if (((double.Parse(nbrGroup.ToString()) / 2) - (int.Parse(nbrGroup.ToString()) / 2)) > 0)
                    lv.Groups[iCli].Items[0].BackColor = colore = Color.AntiqueWhite; //uf.GetValue(myread, "icli")
                else
                    lv.Groups[iCli].Items[0].BackColor = colore = Color.Beige;
                //lv.Groups[iCli].ListView.Items[0].BackColor = Color.Chartreuse;

                lv.Items[i].SubItems.Add(uf.GetValue(myread, "codearticle"));
                lv.Items[i].SubItems.Add(uf.GetValue(myread, "libellearticle"));
                lv.Items[i].ListView.LabelWrap = true;
                string rem = uf.GetValue(myread, "remarquearticle");
                lv.Items[i].SubItems.Add(rem);
                lv.Items[i].SubItems.Add(uf.GetValue(myread, "nbrarticle"));
                    
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "montantbrut"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "rabaisarticlepourcent"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "rabaisarticlechf"));
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "idfacture"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "identreprise"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "idclient"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "idarticle"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "numligne"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "idprix"));
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "idrabais"));
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add(uf.GetValueNonRound(myread, "rappel"));
                for (int j = 0; j< lv.Items[i].SubItems.Count; j++)
                {
                    lv.Items[i].SubItems[j].BackColor = colore;
                }
                i++;
                if (rem != "") //il y a une remarque
                {
                    lv.Items.Add(""); //première ligne facture
                    lv.Items[i].Group = lv.Groups[iCli];
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add(rem);
                    lv.Items[i].BackColor = colore;
                    lv.Items[i].Font = tFontit;
                    i++;
                }
            }
            if (i > 0)
            {
               // i--;
                lv.Items.Add("Total ");
                lv.Items[i].BackColor = colore;
                //lv.Items[i].BackColor = Color.Gold;
                //lv.Items[i].ForeColor = Color.Blue;
                lv.Items[i].Font = tFontnorm;
                lv.Items[i].Group = lv.Groups[iCli];
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add(snbrarticle.ToString());
                lv.Items[i].SubItems.Add(uf.getFormatCur(smontantbrut, true));
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add(uf.getFormatCur(srabaisfacturechf, true));
                lv.Items[i].SubItems.Add(uf.getFormatCur(stvachf, true));
                lv.Items[i].SubItems.Add(uf.getFormatCur(sfraisenvoi, true));
                lv.Items[i].SubItems.Add(uf.getFormatCur(sfraisassurance, true));
                lv.Items[i].SubItems.Add(uf.getFormatCur(sinterets, true));
                lv.Items[i].SubItems.Add(uf.getFormatCur(sfraisrappel, true));
                lv.Items[i].SubItems.Add(uf.getFormatCur(smontantapayer, true));
                totalfactmtt += smontantapayer;
                totalfactnbr++;
                lv.Items[i].SubItems.Add(tdateimpression);
                lv.Items[i].SubItems.Add(tdateecheance);
                //lv.Items[i].UseItemStyleForSubItems = false;
                //if (DateTime.Parse(tdateecheance) < DateTime.Now)
                //    lv.Items[i].SubItems[17].BackColor = Color.Red;
                lv.Items[i].SubItems.Add(uf.getFormatCur(smontantpaye, true));
                lv.Items[i].SubItems.Add(uf.getFormatCur(smontantapayer - smontantpaye, true));
                //données non affichées facture
                lv.Items[i].SubItems.Add(uf.GetValue(myread, "idfacture"));
                lv.Items[i].SubItems.Add(uf.GetValue(myread, "identreprise"));
                lv.Items[i].SubItems.Add(uf.GetValue(myread, "idclient"));
                
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add("");
                lv.Items[i].SubItems.Add(uf.GetValue(myread, "rappel"));
                //
                i++;
                if (etatfact == 0)
                {
                    lv.Items.Add("");
                    lv.Items[i].Group = lv.Groups[iCli];
                }
                i++;
                tnbrarticle += snbrarticle;
                tmontantbrut += smontantbrut;
                trabaisfacturechf += srabaisfacturechf;
                ttvachf += stvachf;
                tfraisenvoi += sfraisenvoi;
                tfraisassurance += sfraisassurance;
                tinterets += sinterets;
                tfraisrappel += sfraisrappel;
                tmontantapayer += smontantapayer;
                tmontantpaye += smontantpaye;

                if (etatfact == 0 && ordercli == 1)
                {
                    lv.Items.Add("Total Factures Client :");
                    lv.Items[i].BackColor = colore;
                    lv.Items[i].ForeColor = Color.Blue;
                    lv.Items[i].Font = tFontnorm;
                    lv.Items[i].Group = lv.Groups[iCli];
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("A Payer");
                    lv.Items[i].SubItems.Add(uf.getFormatCur(tmontantapayer, true));
                    lv.Items[i].SubItems.Add("");
                    lv.Items[i].SubItems.Add("Payés :");
                    lv.Items[i].SubItems.Add(uf.getFormatCur(tmontantpaye, true));
                    lv.Items[i].SubItems.Add(uf.getFormatCur(tmontantapayer - tmontantpaye, true));

                }
                myread.Close();
                lv.Groups[0].Items[0].Selected = true;
                selfact();
            }
            etatfact = 0;

            //Pb.Visible = false;
            myread.Close();
            bt_supproc.Enabled = bt_listepaiement.Enabled = false;
            lv.Refresh();
            if (tp_facture.SelectedIndex == 0)
            {
                bt_pajout.Enabled = false;
                if (lv.Groups.Count == 0)
                {
                    uf.enablecontrol(p_menu, "1", false, "2", false, "3", true);
                    bt_ajout.Enabled = true;
                    //lb_mttfact.Text = "Montant des factures : chf 0.00";
                    //lb_nbrfact.Text = "Nbr de factures : 0";
                    return;
                }
                else
                {
                    //lb_mttfact.Text = "Montant des factures : chf " + uf.getFormatCur(totalfactmtt);
                    //lb_nbrfact.Text = "Nbr de factures : " + totalfactnbr.ToString();
                }

                if (etatfact == 0)
                    uf.enablecontrol(p_menu, "1", true, "2", false, "3", true);
            }
            else
            {
                uf.enablecontrol(p_menu, "1", false, "2", false, "3", true);
                if (tp_facture.SelectedIndex == 1)
                    bt_pajout.Enabled = true;
            }
        }

       
        /*
        private void affichecommentaire(string ident)
        {
            string reqcom = "SELECT identretien, identreprise as identreprisecom, typecom, dateentretien as datecom, infos as commentaire FROM fact_entreprisehistory WHERE identreprise = " + ident + " ORDER BY datecom";
            uf.afficherInfo(p_entreprise, reqcom, comrealvistamod, gv_commentaire, "");
            
        }
        */

        /*private void afficherfacture(string idfacture)
        {
            
            string sqlfactaff = "SELECT idfacture, if(isnull(fact.reffactureentreprise), '',fact.reffactureentreprise) as reffactureentreprise, cli.idclient, entreprise.identreprise, entreprise.identreprise as idrefentreprise, reffacturedeltareal, datefactureentreprise, datecommande, dateecheance, montantfacture, rabaisfacturepourcent, rabaisfacturemontant, fact.tauxtva as tvafacture, montanttva, montantfacturettc, " +
                "lpad(entreprise.identreprise, 2, '0') as refentreprise, if (isnull(entreprise.iddeltareal) OR entreprise.iddeltareal = 0, '', entreprise.iddeltareal) as iddeltareal, " +
                "if(iddeltareal > 0, clidelta.socligne1, entreprise.socligne1) as socligne1, if(iddeltareal > 0, clidelta.socligne2, entreprise.socligne2) as socligne2, " +
                "entreprise.tauxtva as tauxtva, entreprise.numtva, entreprise.monnaie as idmonnaie, entreprise.echeance as nbrecheance, entreprise.frais, entreprise.fraispourcent, entreprise.infos, " +
                "monnaie.monnaie as monnaie, " +
                "cli.idclient as refclient, cli.idclient as currefclient, socligne as raisonsociale, pol.idlangue as idlanguage, lang.language as language, " +
                "cli.idpolitesse as idpolitesse, pol.politesse as politesse, cli.nom, cli.prenom, cli.co, " +
                "cli.adresse1 as adresse1, cli.adresse2 as adresse2, city.zip as npa, city.cityname as ville, " +
                "cli.idville as idville, cli.telpro as telpro, cli.telmob as telmob, " +
                "cli.fax as fax, cli.email as email " +
                "FROM fact_facturation fact LEFT JOIN fact_entreprise entreprise ON entreprise.identreprise = fact.identreprise and entreprise.identreprise = " + Fmain.identreprisesel + " LEFT JOIN fact_monnaie monnaie on monnaie.idmonnaie = entreprise.monnaie " +
                "LEFT JOIN " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal " +
                "LEFT JOIN fact_client cli ON cli.idclient = fact.idclient " +
                "LEFT join " + Fmain.baseInit + ".typepolitesse pol ON pol.idpolitesse = cli.idpolitesse LEFT join " + Fmain.baseInit + ".language lang ON lang.idlanguage = pol.idlangue " +
                "left join " + Fmain.baseInit + ".city ON city.idcity = cli.idville " +
                "WHERE idfacture = " + idfacture ;
            uf.readonlycontrol(p_client, "", true);
            uf.readonlycontrol(p_entreprise, "", true);
            etatrechcli = 0;
            etatfact = 0;
            //uf.afficherInfo(p_facture, sqlfactaff, comaffichefacture, null, sender1: p_entreprise, sender2: p_client);
            uf.afficherInfo(p_facture, sqlfactaff, comaffichefacture, null, sender1: p_client);
            foreach (Control c in p_facture.Controls)
            {
                if (c.GetType().Name == typeof(TextBox).Name || c.GetType().Name == typeof(DateTimePicker).Name)
                {
                    //factcontrol.Add(c.Name);
                    factvaleur[factcontrol.IndexOf(c.Name )] = c.Text;
                }
            }
            
            //etatfact = 0;
            //etatart = 0; 
        }
        */

        /*
        private void chargerentreprise(string ident)
        {
            uf.initcontrol(p_entreprise, "2", refentreprise);
            string reqdoncli = "select lpad(client.identreprise, 2, '0') as  refentreprise, if (isnull(client.iddeltareal) OR client.iddeltareal = 0, '', client.iddeltareal) as iddeltareal, " +
                "if(iddeltareal > 0, clidelta.socligne1, client.socligne1) as socligne1, if(iddeltareal > 0, clidelta.socligne2, client.socligne2) as socligne2, " +
                "client.tauxtva as tauxtva, client.numtva, client.monnaie as idmonnaie, client.echeance as nbrecheance, client.frais, client.fraispourcent, client.infos, " +
                "monnaie.monnaie as monnaie FROM fact_entreprise client LEFT JOIN fact_monnaie monnaie on monnaie.idmonnaie = client.monnaie " +

                "LEFT JOIN " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = client.iddeltareal " +
                "WHERE identreprise = " + ident;
            

            uf.afficherInfo(p_entreprise, reqdoncli, comrech, null);
            if (refentreprise.Text != "")
                identreprise.Text = refentreprise.Text;
            affichecommentaire(refentreprise.Text);


        }
        */
        private void initialisation()
        {

            uf.initcontrol(p_facture, "", reffacturedeltareal);
            uf.enablecontrol(p_facture, "", false);
            uf.enablecontrol(p_menu, "1", false, "2", false, "3", false);
            bt_ajout.Enabled = true;
            //uf.enablecontrol(p_menu, "", false);

        }

        
        //string idcurfact = "";
        private void charger(int numligne)
        {
            /*
            if (gv_fact.RowCount == 0 || gv_fact.Rows[numligne].Index == -1)
            {
                uf.enablecontrol(p_menu, "1", false, "2", false, "3", true);
                bt_ajout.Enabled = true;
                return;
            }
            int lignef = lignefact(numligne);
            if (etatfact == 0)
                uf.enablecontrol(p_menu, "1", true, "2", false, "3", true);
            
            if (( gv_fact.Rows[lignef].Cells["g_idfacture"].Value.ToString() != idfacture.Text) || idfacture.Text == "") //   || etatfact == 1// || reffactureentreprise.Enabled == true)
            {
                
                afficherfacture(gv_fact.Rows[lignef].Cells["g_idfacture"].Value.ToString());
                
            }
            //uf.enablecontrol(p_article, "6", false);
            uf.initcontrol(p_article, "6", codearticle);
            uf.enablecontrol(p_article, "6", false);

            if (gv_fact.Rows[numligne].Cells["g_numligne"].FormattedValue.ToString() != "0")
            {
                affichedetailarticle(numligne);
                if (etatfact > 0)
                    uf.enablecontrol(p_article, "6", true);
            }*/
        }
        

        private void gv_fact_Click(object sender, EventArgs e)
        {
            /*
            if (gv_fact.RowCount == 0 || gv_fact.CurrentRow.Index == -1)
            {
                uf.enablecontrol(p_menu, "1", false, "2", false, "3", true);
                bt_ajout.Enabled = true;
                return;
            }
            
            charger(gv_fact.CurrentRow.Index);
            */
        }

        string idcurfact = "";
        private int lignefact(int numligne)
        {
            int ret = -1;

            if (gv_fact.Rows[numligne].Cells["g_numligne"].FormattedValue.ToString() != "0") //clique sur ligne detail ==> prendre le num ligne principale
            {
                int currow = gv_fact.Rows[numligne].Index-1;
                while (gv_fact.Rows[currow].Cells["g_numligne"].FormattedValue.ToString() != "0")
                {

                    currow--;
                }
                ret = currow;
            }
            else
            {
                ret = gv_fact.Rows[numligne].Index;
            }
            idcurfact = gv_fact.Rows[ret].Cells["g_idfacture"].Value.ToString();
            return ret;
        }

        private bool testerfactimp(string numf)
        {
            bool val = false;
            string h = uf.ValeurParCond(comrealvistamod, "fact_facturation", "reffacturedeltareal, dateimpression", "dateimpression", "identreprise =" + Fmain.identreprisesel + " AND reffacturedeltareal = '" + numf + "'");
            if (h != "")
                val = true;
            return val;
        }

        int etatfact = 0; //1 modif; 2 ajout
        private void bt_modif_Click(object sender, EventArgs e)
        {
            //cond = ;
            if (lv.SelectedItems.Count == 0)
            {
                uf.AfficherErreur("Veuillez sélectionner une ligne d'article !");
                return;
            }
            string numf = getreffact();
            if (testerfactimp(numf) == true)
            {
                uf.message_info("Cette facture a déjà été imprimé. Impossible de modifier !");
                return;
            }
            etatfact = 1;
            chargerfacture("reffacturedeltareal = '" + numf + "'", 0);
            
                curidcli = getvallv("idclient", 0, lv.Items[0].Group.Name); // lv.Items[0].Group.Name;

            etatfact = 1;
            uf.initcontrol(p_facture, "");
            reffacturedeltareal.Text = getvallv("reffactdeltareal", 0);
            datecommande.Text = getvallv("datecommande", 0);
            reffactureentreprise.Text = getvallv("reffactentreprise", 0);
            if (lv.Items.Count == 2)
                ck_typesaisie.Checked = true;
            else
                ck_typesaisie.Checked = false;
            uf.enablecontrol(p_facture, "6", true, "7", false);
            uf.enablecontrol(p_menu, "1", false, "2", true, "3", false);
            int ind = 0;
            lv.Items[ind].Selected = true;
            lv.FocusedItem = lv.Items[ind];
            bt_modifajoutart.Enabled = true;
            codearticle.Focus();
        }

        private void selfact()
        {
            string rep = "";
            if (lv.Items.Count > 0 && etatfact > 0)
            {
                int l = lv.Groups[lv.SelectedItems[0].Group.Name].Items.IndexOf(lv.SelectedItems[0]);
                if (lv.SelectedItems[0].SubItems[0].Text.ToLower().Contains("total"))
                    lv.Groups[lv.SelectedItems[0].Group.Name].Items[l-1].Selected = true;
                return;
            }
            else if (lv.Items.Count == 0 || etatfact > 0)
                return;
            int ind = lv.Groups[lv.SelectedItems[0].Group.Name].Items.IndexOf(lv.SelectedItems[0]);
            int h = ind;
            //while ((getvallv("reffactdeltareal", h, lv.SelectedItems[0].Group.Name) == "" || getvallv("reffactdeltareal", h, lv.SelectedItems[0].Group.Name).ToLower().Contains("total")) && h > -1)
            while ((getvallv("reffactdeltareal", h, lv.SelectedItems[0].Group.Name).ToLower().Contains("total") || getvallv("codearticle", h, lv.SelectedItems[0].Group.Name) == "") && h > -1)
            {
                h--;
            }
            bt_impression.Enabled = false;
                    bt_rappel.Enabled = false;
            if (h >= 0)
            {
                lv.Groups[lv.SelectedItems[0].Group.Name].Items[h].Selected = true;
                string reff = getreffact();
                afficherprocedure(reff);
                afficherpaiement(reff);
                curidcli = getvallv("idclient", h, lv.SelectedItems[0].Group.Name);
                string rap = getvallv("rappel", h, lv.SelectedItems[0].Group.Name);
                int irap = 0;
                int.TryParse(rap, out irap);
                if (irap <= 0)
                    irap = 0;
                lb_rappel.Text = irap.ToString();
                bt_impression.Enabled = true;
                if (tp_facture.SelectedIndex == 3)
                    bt_rappel.Enabled = true;

            }
            
        }

        private void afficherpaiement(string reff)
        {
                bt_listepaiement.Enabled = false;
            bt_pajout.Enabled = true;
            
            string s = "select idpaiement, if (typepaiement = 0, 'Entreprise', 'Deltareal') as typepaiement, if(postebanque = 1, 'poste', 'banque') as postebanque, datesaisie, datepaiement, identreprise, idclient as idclientpaiement, montant as montantpaiement FROM " +
                    "fact_paiement WHERE identreprise = " + Fmain.identreprisesel + " AND numfacture = '" + reff+ "' ORDER BY datepaiement desc, idpaiement desc";
            uf.afficherInfo(null, s, comrealvistamod, gv_paiement);
            if (gv_paiement.RowCount > 0)
            {
                string sol = getvallv("solde", lv.Groups[lv.SelectedItems[0].Group.Name].Items.IndexOf(lv.SelectedItems[0]), lv.SelectedItems[0].Group.Name);
                decimal ss = 0;
                decimal.TryParse(sol, out ss);

                if (ss <= 0)
                    bt_pajout.Enabled = false;
                else
                    bt_pajout.Enabled = true;

                bt_listepaiement.Enabled = true;
            }
        }

        private string getreffact()
        {
            string rep = "";
            if (lv.SelectedItems.Count == 0)
                return "";
            int ind = lv.Groups[lv.SelectedItems[0].Group.Name].Items.IndexOf(lv.SelectedItems[0]);
            int h = ind;
            while((getvallv("reffactdeltareal", h, lv.SelectedItems[0].Group.Name) == "" || getvallv("reffactdeltareal", h, lv.SelectedItems[0].Group.Name).ToLower().Contains("total")) && h > -1 )
            {
                h--;
            }
            if (h >= 0)
                rep = getvallv("reffactdeltareal", h, lv.SelectedItems[0].Group.Name);

            return rep;
        }

        string nouveaufacture = "";
        private string fgenerernumfacture(string ident)
        {
            string req = "select right(max(reffacturedeltareal), 4) as max from fact_facturation where identreprise = " + ident;
            comrech.CommandText = req;
            myread = comrech.ExecuteReader();
            if (myread.Read() && uf.GetValue(myread, "max") != "")
            {
                int newfact = int.Parse(uf.GetValue(myread, "max")) + 1;
                nouveaufacture = DateTime.Now.Year.ToString() + ident.PadLeft(2, '0') + newfact.ToString().PadLeft(4, '0');
            }
            else
                nouveaufacture = DateTime.Now.Year.ToString() + ident.PadLeft(2, '0') + "0001";
            myread.Close();
            return nouveaufacture;

        }

        

        private void bt_ajout_Click(object sender, EventArgs e)
        {
            if (curidcli == "")
            {
                if (lv.SelectedItems.Count > 0)
                {
                    curidcli = getvallv("idclient", 0, lv.SelectedItems[0].Group.Name); // lv.SelectedItems[0].Group.Name;
                }
                else
                {
                    uf.AfficherErreur("Veuillez sélectionner le client ou faire une recherche !");
                    return;
                }
            }
            ajoutevent();
        }


        public void ajoutevent()
        {
            uf.initcontrol(p_facture, "", reffactureentreprise);
            lv.Items.Clear();
            lv.Groups.Clear();
            gv_procedure.Rows.Clear();
            gv_paiement.Rows.Clear();
            bt_pajout.Enabled = false;
            bt_supproc.Enabled = bt_listepaiement.Enabled = false;
            uf.enablecontrol(p_facture, "6", true, "7", false, "5", true);
            uf.enablecontrol(p_menu, "1", false, "2", true, "3", false);
            for (int i = 0; i < factvaleur.Count; i++)
                factvaleur[i] = "";
            etatfact = 2;

            lv.Groups.Add(curidcli, "Client No : " + curidcli.PadLeft(4, '0') + "   " + loadclient(curidcli));
            //lv.Groups[curidcli].ListView.BackColor = Color.Blue;
            //lv.Groups[curidcli].ListView.BackColor = Color.Beige;
            
            lv.Items.Add(Fmain.generernumfacture(Fmain.identreprisesel));
            lv.Items[0].UseItemStyleForSubItems = false;
            lv.Items[0].SubItems[0].Font = tFont;
            /*
            if (((double.Parse(i.ToString()) / 2) - (i / 2)) > 0)
                lv.Items[i].BackColor = Color.Beige;
            else
                lv.Items[i].BackColor = Color.AntiqueWhite;*/
            lv.Items[0].BackColor = Color.AntiqueWhite;

            lv.Items[0].Group = lv.Groups[curidcli];
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add(uf.valtexte(datecommande));
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");

            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            lv.Items[0].SubItems.Add("");
            for (int j = 0; j < lv.Items[0].SubItems.Count; j++)
            {
                lv.Items[0].SubItems[j].BackColor = Color.AntiqueWhite;
            }

            ajoutlignetot();
            bt_modifajoutart.Enabled = true;


            // ajoutevent();
            lv.Update();
            lv.Groups[0].Items[0].Selected = true;
            reffacturedeltareal.Text = Fmain.generernumfacture(Fmain.identreprisesel);
            reffactureentreprise.Focus();
        }

        private void ajoutlignetot()
        {
            //ajout ligne total
            lv.Items.Add("Total");
            int ind = lv.Items.Count - 1;
            lv.Items[ind].Group = lv.Groups[0]; //lv.SelectedItems[0].Group; // 
            lv.Items[ind].BackColor = Color.Beige;
            lv.Items[ind].Font = tFont;
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");

            lv.Items[ind].SubItems.Add("0.00");
            lv.Items[ind].SubItems.Add(uf.getFormatCur(Fmain.dtvachf));
            lv.Items[ind].SubItems.Add(uf.getFormatCur(dfraisenvoi));
            lv.Items[ind].SubItems.Add(uf.getFormatCur(dfraisassurance));
            lv.Items[ind].SubItems.Add(uf.getFormatCur(dinterets));
            lv.Items[ind].SubItems.Add(uf.getFormatCur(dfraisrappel));
            lv.Items[ind].SubItems.Add("0.00");
            lv.Items[ind].SubItems.Add(""); //date facture/impression
            lv.Items[ind].SubItems.Add(""); //date echeance
            //lv.Items[ind].SubItems.Add(string.Format("{0:dd.MM.yyyy}", DateTime.Now.AddDays(Fmain.iecheance)));
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add(Fmain.identreprisesel);
            lv.Items[ind].SubItems.Add(curidcli);
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");
            lv.Items[ind].SubItems.Add("");

        }
        
        int etatart = 0;
        private void calcmontart()
        {
            if (etatfact == 0)
                return;
            int nbr = 0;
            montantarticle.Text = "0.00";
            int.TryParse(nbrarticle.Text, out nbr);
            decimal prixunit = 0;
            decimal.TryParse(prixunitaire.Text, out prixunit);
            decimal rabp = 0;
            decimal.TryParse(ed_rabaispourcent.Text, out rabp);
            decimal rabm = 0;
            decimal.TryParse(ed_rabaischf.Text, out rabm);
            decimal rab = 0;
            if (rabp > 0)
            {
                prixunit = prixunit - (rabp * prixunit / 100);

            } 
            else if(rabm > 0)
            {
                prixunit = prixunit - rabm;
            }

            montantarticle.Text = uf.getFormatCur(prixunit * nbr);

            
            
        }
        /*
        private void calcmontfact()
        {
            if (etatfact == 0)
                return;
            
            
            montantfacturettc.Text = "0.00";
            decimal tva = 0;
            decimal tvam = 0;
            decimal rab = 0;
            decimal rabm = 0;
            decimal rabm1 = 0;
            decimal mtt = 0;
            decimal.TryParse(tvafacture.Text, out tva);
            decimal.TryParse(montantfacture.Text, out mtt);
            
            decimal.TryParse(rabaisfacturepourcent.Text, out rab);
            if (rab > 0) //rabais %
            {
                //rabaisfacturemontant.Text = "0.00";
                rabaisfacturemontant.Text = uf.getFormatCur((mtt * rab / 100).ToString());
            }
            decimal.TryParse(rabaisfacturemontant.Text, out rabm);
            
                montanttva.Text = "0.00";
                montanttva.Text = uf.getFormatCur(((mtt - rabm) * tva / 100).ToString());
            //}
            decimal.TryParse(montanttva.Text, out tvam);
            decimal.TryParse(rabaisfacturemontant.Text, out rabm1);
            montantfacturettc.Text = uf.getFormatCur(((mtt - rabm1) + tvam).ToString());
        }
        */

        


        private void bt_valider_Click(object sender, EventArgs e)
        {
            string champ = "";
            string valeur = "";

            /*
            //calcul reste à saisir.
            if (gv_fact.RowCount == 0)
            {
                uf.AfficherErreur("Veuillez d'abord valider les données principales de la facture !");
                return;
            }
                decimal resteasaisir = calculeresteasaisir();

            if (resteasaisir < 0) //saisie en trop
            {
                uf.message_info("Attention, le total des marchandises dépasse le montant initial de la facture !");
                gv_fact.CurrentCell = gv_fact.Rows[0].Cells[0];
                gv_fact.CurrentRow.Selected = true;
                charger(0);
                return; 
            }
            else if (resteasaisir > 0)
            {
                uf.message_info("Attention, le total des marchandises n'atteint pas encore le montant initial de la facture !");
                if (etatart == 2)
                {
                    uf.initcontrol(p_article, "6", codearticle);
                    return;
                }
                else if (etatart == 1)
                {
                    uf.initcontrol(p_article, "6", codearticle);
                    etatart = 2;
                    return;
                }
            }
            */
            /*
            //lecture de la LIST factcontrol et factvaleur. Si différent remplir champ et valeur
            foreach (string c in factcontrol)
            {
                if (c != "idfacture" && factvaleur[factcontrol.IndexOf(c)] != (p_facture.Controls[c]).Text)
                {
                    //uf.message_info("Nisy niova");
                    if (champ != "")
                    {
                        champ += ",";
                        valeur += "$";
                    }
                    champ += (p_facture.Controls[c]).AccessibleName;
                    string val = "";
                    if (p_facture.Controls[c].GetType().Name == typeof(DateTimePicker).Name)
                        val = string.Format("{0:yyyy-MM-dd}", (p_facture.Controls[c] as DateTimePicker).Value);
                    else
                        val = uf.valtexte(p_facture.Controls[c] as TextBox);
                    valeur += val;
                }

                
            }*/
            //Enregistrement facture principale
            champ = "identreprise, reffactureentreprise,reffacturedeltareal, idclient,montantapayer, datefactureentreprise, datefacturedeltareal, datecommande, " + 
                "rabaisfacturemontant, rabaisfacturepourcent, nbrmens, tauxtva, fraisenvoi, interets, fraisassurance, fraisrappel, numligne, " +
                //"rabaisfacturemontant, rabaisfacturepourcent, nbrmens, tauxtva, fraisenvoi, interets, fraisassurance, fraisrappel, numligne, " +
                "idarticle, idprix, remarquearticle, nbr, idrabais";

            string daty = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
            string datyech = string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(Fmain.iecheance));
            string datycom = string.Format("{0:yyyy-MM-dd}", datecommande.Value);
            decimal drabaisfactm = 0;
            decimal drabaisfactp = 0;
            string srabaisfactm = uf.getFormatCur(drabaisfactm);
            string srabaisfactp = uf.getFormatCur(drabaisfactp);
            string stva = uf.getFormatCur(Fmain.dtvachf);
            /*decimal drabaisartm = 0;
            decimal drabaisartp = 0;
            string srabaisartm = uf.getFormatCur(drabaisartm);
            string srabaisartp = uf.getFormatCur(drabaisartp);*/
            int nbrmens = 0;
            string reffact = getvallv("reffactdeltareal", 0);


            if (etatfact == 1) //modif
            {
                uf.executeSQL(comrealvistamod, "fact_facturation", "", "", 3, "reffacturedeltareal ='" + reffact + "' AND identreprise = " + Fmain.identreprisesel);
            }
            for (int i = 0; i< lv.Groups[0].Items.Count-1; i++)
            {
                if (getvallv("codearticle", i) == "")
                    continue;

                //if (lv.Groups[0].Items[i].SubItems[22].Text == "0") //première ligne
                //    valeur = Fmain.identreprisesel + "$" + getvallv("reffactentreprise", i) + "$" + getvallv("reffactdeltareal", i) + "$" + getvallv("idclient", i) + "$" + getvallv("montantapayer", i) + "$";
                //else
                    valeur = Fmain.identreprisesel + "$" + getvallv("reffactentreprise", 0) + "$" + getvallv("reffactdeltareal", 0) + "$" + getvallv("idclient", 0) + "$" + getvallv("montantapayer", lv.Groups[0].Items.Count - 1) + "$";

                valeur += daty + "$" + daty + "$" + datycom + "$" + srabaisfactm + "$" + srabaisfactp + "$" + nbrmens.ToString() + "$" + stva + "$" + uf.getFormatCur(dfraisenvoi) + "$" +
                        uf.getFormatCur(dinterets) + "$" + uf.getFormatCur(dfraisassurance) + "$" + uf.getFormatCur(dfraisrappel) + "$" + (i+1).ToString() + "$" + getvallv("idarticle", i) + "$" +
                        getvallv("idprix", i) + "$" + getvallv("remarquearticle", i) + "$" + getvallv("nbrarticle", i) + "$" + getvallv("idrabais", i);

                if (champ != "")
                {
                    //if (etatfact == 2) //ajout
                        uf.executeSQL(comrealvistamod, "fact_facturation", champ, valeur, 2, "");
                    //else if (etatfact == 1) //modif
                     //   uf.executeSQL(comrealvistamod, "fact_facturation", champ, valeur, etatfact, "idfacture = " + idcurfact);
                }
            }




            //chargerfacture("reffacturedeltareal = '" + reffact + "'", 0);
            rechclient.Text = curidcli;
            rechfacture.Text = "";
            cond = "fact.idclient = " + curidcli;
            etatfact = 0;
            chargerfacture("fact.idclient = " + curidcli, 1);
            
        }

        private string getvallv(string nomcol, int itemindex, object groupe = null)
        {
            bool indgroup = false;
            /*try
            {
                int d = int.Parse(groupe);
                indgroup = true;
            }
            catch
            {

            }*/
            string rep = "";

            if (groupe == null)
            {
                if (lv.Groups[0].Items[itemindex].SubItems.Count <= lv.Columns["g_" + nomcol].Index)
                    return "";
                rep = lv.Groups[0].Items[itemindex].SubItems[lv.Columns["g_" + nomcol].Index].Text;
            }
            else if (groupe.GetType().Name == typeof(string).Name)
            {
                if (lv.Groups[groupe.ToString()].Items[itemindex].SubItems.Count <= lv.Columns["g_" + nomcol].Index)
                    return "";
                rep = lv.Groups[groupe.ToString()].Items[itemindex].SubItems[lv.Columns["g_" + nomcol].Index].Text;
            }
            else if (groupe.GetType().Name == typeof(int).Name)
            {
                if (lv.Groups[int.Parse(groupe.ToString())].Items[itemindex].SubItems.Count <= lv.Columns["g_" + nomcol].Index)
                    return "";
                rep = lv.Groups[int.Parse(groupe.ToString())].Items[itemindex].SubItems[lv.Columns["g_" + nomcol].Index].Text;
            }

            if (nomcol.Contains("rabais") || nomcol.Contains("mtt") || nomcol.Contains("montant") || nomcol.Contains("tva") || nomcol.Contains("nbr") || nomcol.Contains("intere") || nomcol.Contains("frais"))
            {
                if (rep.Trim() == "")
                    rep = "0";
            }
            return rep.Trim().Replace("'", "");
        }
        


        private void bt_annul_Click(object sender, EventArgs e)
        {
            //curidcli = "";
            //if (etatfact == 1)
            //{
                etatfact = 0;
                chargerfacture(orderclitmp: ordercli);
            //}
            //else if (etatfact == 2)
            //    chargerfacture("");
        }

        
        private bool testdonneesfact()
        {
            Boolean ret = true;
            if (uf.testchampvide(p_facture) == true)
            {
                
                uf.message_info("Veuillez saisir les données utiles !");
                return false;
            }
            /*
            decimal tmp = 0;
            decimal.TryParse(montantfacture.Text, out tmp);
            if (tmp == 0 && ck_typesaisie.Checked == false)
            {
                uf.message_info("Veuillez saisir le montant initial de la facture !");
                return false;
            }
            */
            return ret;
        }

        private void validerfacture()
        {
            
            etatart = 2;
            //ajout des données saisies dans la grille, 1ere ligne avec mise en forme, après test saisie.
            //Test champ vide
            if (testdonneesfact() == false)
                return;
            //
            if (gv_fact.RowCount == 0)
                gv_fact.Rows.Add(1);
            DataGridViewRow dr = gv_fact.Rows[0];
            dr.Height = 30;
            dr.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            /*
            dr.Cells["g_reference"].Value = uf.valtexte(reffactureentreprise) + (char)(13) + uf.valtexte(reffacturedeltareal);
            dr.Cells["g_idclient"].Value = uf.valtexte(refclient);
            dr.Cells["g_reffactdeltareal"].Value = uf.valtexte(reffacturedeltareal);
            dr.Cells["g_reffactentreprise"].Value = uf.valtexte(reffactureentreprise);
            dr.Cells["g_identreprise"].Value = uf.valtexte(refentreprise);

            if (etatfact == 2)
                dr.Cells["g_idfacture"].Value = "0";
            dr.Cells["g_clientlibelle"].Value = getclient();
            dr.Cells["g_dateprix"].Value = uf.valtexte(datecommande) + (char)13 + uf.valtexte(datefactureentreprise);
            dr.Cells["g_mensnbrarticle"].Value = "non" + (char)13 + "0";
            dr.Cells["g_montanttotecheance"].Value = uf.valtexte(dateecheance) + (char)13 + uf.valtexte(montantfacture);
            dr.Cells["g_rabaispourcent"].Value = uf.valtexte(rabaisfacturepourcent);
            dr.Cells["g_rabaismontant"].Value = uf.valtexte(rabaisfacturemontant);
            dr.Cells["g_tvapourcent"].Value = uf.valtexte(tvafacture);
            dr.Cells["g_tvamontant"].Value = uf.valtexte(montanttva);
            dr.Cells["g_rabaistva"].Value = uf.valtexte(rabaisfacturepourcent) + "%" + (char)13 + uf.valtexte(tvafacture) + "%";
            dr.Cells["g_montantrabaistva"].Value = uf.valtexte(rabaisfacturemontant) + (char)13 + uf.valtexte(montanttva);
            dr.Cells["g_montantapayeart"].Value = uf.valtexte(montantfacturettc);
            dr.Cells["g_montantpaye"].Value = "0.00";
            dr.Cells["g_numligne"].Value = "0";
            */
            //calc reste a saisir
            calculeresteasaisir();

            //if (gv_fact.Rows.Count == 1)
            //    ajoutligneart();
            codearticle.Focus();
            
        }

        
        private void ajoutligneart()
        {
            if (lv.SelectedItems.Count == 0)
                lv.Groups[0].Items[0].Selected = true;

            decimal rabaisp = 0; //c'est selon, montant ou pourcentage
            decimal rabaism = 0; //c'est selon, montant ou pourcentage
            decimal.TryParse(ed_rabaispourcent.Text, out rabaisp);
            decimal.TryParse(ed_rabaischf.Text, out rabaism);
            decimal montantb = decimal.Parse(uf.valtexte(prixunitaire)) * decimal.Parse(uf.valtexte(nbrarticle));
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[3].Text = uf.valtexte(codearticle);
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[4].Text = uf.valtexte(libellearticle);
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[5].Text = uf.valtexte(remarquearticle);
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[6].Text = uf.valtexte(nbrarticle);
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[7].Text = uf.getFormatCur(montantb);
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[8].Text = uf.getFormatCur(rabaisp) + "%";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[9].Text = uf.getFormatCur(rabaism * decimal.Parse(uf.valtexte(nbrarticle))); //rabaischf
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[10].Text = "";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[11].Text = "";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[12].Text = "";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[13].Text = "";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[14].Text = "";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[15].Text = ""; //montant à payer
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[16].Text = "";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[17].Text = "";
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[18].Text = "";
                //lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[19].Text = ""; //solde
                //lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[20].Text = ""; //dfacture
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[21].Text = Fmain.identreprisesel.ToString();
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[22].Text = curidcli;
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[23].Text = idarticle.Text;
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[24].Text = lv.SelectedItems[0].Index.ToString();
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[25].Text = idprix.Text;
                lv.Groups[0].Items[lv.SelectedItems[0].Index].SubItems[26].Text = idrabais.Text;

            calcultotalligne();
            
            if (etatfact > 0 && ck_typesaisie.Checked) //modif ou ajout saisie simple
            {
                if (uf.confirmer_questionON(this, "Valider la facture ?") == DialogResult.No)
                    return;
                //Enregistrement
                bt_valider_Click(bt_valider, new EventArgs());
            }
            else if(etatfact > 0 && ck_typesaisie.Checked == false) //plusieurs ligne, mode ajout
            {

                lv.Items.RemoveAt(lv.Items.Count - 1);
                ajoutlignevide();
                ajoutlignetot();
                calcultotalligne();

                int ind = lv.Items.Count - 2;
                lv.Items[ind].Selected = true;
                lv.FocusedItem = lv.Items[ind];
                uf.initcontrol(p_facture, "", codearticle, reffactureentreprise, reffacturedeltareal, datecommande);
            } 

            /*if (etatart == 2)
            {
                gv_fact.Rows.Add(1);
                gv_fact.CurrentCell = gv_fact.Rows[gv_fact.Rows.Count - 1].Cells[0];
            }
            else
            {

            }
            
             codearticle.Text = gv_fact.Rows[numligne].Cells["g_codearticle"].FormattedValue.ToString();
            libellearticle.Text = gv_fact.Rows[numligne].Cells["g_libellearticle"].FormattedValue.ToString();
            prixunitaire.Text = gv_fact.Rows[numligne].Cells["g_prixunitaire"].FormattedValue.ToString();
            unite.Text = gv_fact.Rows[numligne].Cells["g_unite"].FormattedValue.ToString();
            nbrarticle.Text = gv_fact.Rows[numligne].Cells["g_nbrarticle"].FormattedValue.ToString();
            montantarticle.Text = gv_fact.Rows[numligne].Cells["g_montantarticle"].FormattedValue.ToString();
            rabaisarticlepourcent.Text = gv_fact.Rows[numligne].Cells["g_rabaispourcent"].FormattedValue.ToString();
            rabaisarticlemontant.Text = gv_fact.Rows[numligne].Cells["g_rabaismontant"].FormattedValue.ToString();
            montantarticlefinal.Text = gv_fact.Rows[numligne].Cells["g_montantarticlefinal"].FormattedValue.ToString();
            */

            /*
            gv_fact.CurrentRow.Selected = true;
            DataGridViewRow dr = gv_fact.CurrentRow;
            dr.Cells["g_reference"].Value = uf.valtexte(codearticle);
            dr.Cells["g_reffactdeltareal"].Value = uf.valtexte(reffacturedeltareal);
            dr.Cells["g_reffactentreprise"].Value = uf.valtexte(reffactureentreprise);
            dr.Cells["g_codearticle"].Value = uf.valtexte(codearticle);
            dr.Cells["g_idarticle"].Value = uf.valtexte(idarticle);
            dr.Cells["g_idclient"].Value = uf.valtexte(idclient);
            dr.Cells["g_identreprise"].Value = uf.valtexte(identreprise );

            //dr.Cells["g_idfacture"].Value = "";
            dr.Cells["g_clientlibelle"].Value = uf.valtexte(libellearticle);
            dr.Cells["g_libellearticle"].Value = uf.valtexte(libellearticle);
            dr.Cells["g_unite"].Value = uf.valtexte(unite);
            dr.Cells["g_dateprix"].Value = uf.valtexte(prixunitaire);
            dr.Cells["g_prixunitaire"].Value = uf.valtexte(prixunitaire);
            dr.Cells["g_mensnbrarticle"].Value = uf.valtexte(nbrarticle);
            dr.Cells["g_nbrarticle"].Value = uf.valtexte(nbrarticle);
            dr.Cells["g_montanttotecheance"].Value = uf.valtexte(montantarticle);
            dr.Cells["g_montantarticle"].Value = uf.valtexte(montantarticle);

            dr.Cells["g_rabaispourcent"].Value = uf.valtexte(rabaisarticlepourcent); 
            dr.Cells["g_rabaismontant"].Value = uf.valtexte(rabaisarticlemontant);
            dr.Cells["g_tvapourcent"].Value = "";
            dr.Cells["g_tvamontant"].Value = "";
            dr.Cells["g_rabaistva"].Value = "0.00%";
            dr.Cells["g_montantrabaistva"].Value = "0.00";
            dr.Cells["g_montantarticlefinal"].Value = uf.valtexte(montantarticlefinal);
            dr.Cells["g_montantapayeart"].Value = uf.valtexte(montantarticlefinal);
            dr.Cells["g_montantpaye"].Value = "";
            dr.Cells["g_numligne"].Value = dr.Index;
            */
            //calcul reste à saisir. Si ajout et montant facture atteint donc validation auto.



        }

        private void ajoutlignevide()
        {
            int ind = -1;
            for(int i=0; i< lv.Items.Count; i++)
            {
                if (getvallv("codearticle", i) == "")
                {
                    ind = i;
                    break;
                }
            }
            if (ind == -1)
            {
                lv.Items.Add("");
                //lv.Items.Insert(ind, "0est");
                //ind++;
                ind = lv.Items.Count - 1;

                lv.Items[ind].BackColor = Color.AntiqueWhite;


                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");

                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].SubItems.Add("");
                lv.Items[ind].Group = lv.Groups[0]; ; // lv.SelectedItems[0].Group; // 
                lv.Update();
            }
            lv.Items[ind].Selected = true;
            lv.FocusedItem = lv.Items[ind];
            
        }

        private void calcultotalligne()
        {
            //calcul total et mise à jour dernière ligne
            int inbrart = 0;
            decimal dmtt = 0;
            decimal drabart = 0;

            for (int i = 0; i < lv.Groups[0].Items.Count - 1; i++)
            {
                inbrart += int.Parse(getvallv("nbrarticle", i));
                dmtt += decimal.Parse(getvallv("montantbrut", i));
                decimal d = 0;
                decimal.TryParse(getvallv("rabaisfacturechf", i), out d);
                drabart += d;

            }

            decimal dtva = (dmtt - drabart) * Fmain.dtvachf / 100;
            decimal dint = (dmtt - drabart) * dinterets / 100;
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[5].Text = "";
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[6].Text = inbrart.ToString();
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[7].Text = uf.getFormatCur(dmtt);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[8].Text = "-";
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[9].Text = uf.getFormatCur(drabart);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[10].Text = uf.getFormatCur(dtva);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[11].Text = uf.getFormatCur(dfraisenvoi);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[12].Text = uf.getFormatCur(dfraisassurance);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[13].Text = uf.getFormatCur(dint);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[14].Text = uf.getFormatCur(dfraisrappel);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[15].Text = uf.getFormatCur((dmtt - drabart) + dtva + dfraisenvoi + dfraisassurance + dint + dfraisrappel);
            lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[19].Text = uf.getFormatCur((dmtt - drabart) + dtva + dfraisenvoi + dfraisassurance + dint + dfraisrappel);
            //lv.Groups[0].Items[lv.Groups[0].Items.Count - 1].SubItems[15].Text = 
            //

        }

        private decimal calculeresteasaisir()
        {
            /*
            decimal asaisir = 0;
            decimal totalsaisi = 0;
            decimal.TryParse(uf.valtexte(montantfacture), out asaisir); 
            for (int i = 0; i< gv_fact.RowCount; i++)
            {
                decimal tmp = 0;
                if (gv_fact.Rows[i].Cells["g_numligne"].FormattedValue.ToString() != "0")
                {
                    decimal.TryParse(gv_fact.Rows[i].Cells["g_montantapayeart"].FormattedValue.ToString(), out tmp);
                    totalsaisi += tmp;
                }
            }
            string texteresteasaisir = uf.getFormatCur(asaisir - totalsaisi, false);
            */
            return 0;//saisir - totalsaisi;
        }

        private string getclient(string rechid = "0")
        {
            string ret = "";
            /*
            if (rechid == "0") //afficher le client en cours
            {
                if (uf.valtexte(raisonsociale) != "")
                    ret += uf.valtexte(raisonsociale) + ", ";
                if (uf.valtexte(nom) != "")
                    ret += uf.valtexte(nom) + " ";
                if (uf.valtexte(prenom) != "")
                    ret += uf.valtexte(prenom) + ", ";
                if (uf.valtexte(co) != "")
                    ret += uf.valtexte(co) + " ";
                ret += "\n";
                if (uf.valtexte(adresse1) != "")
                    ret += uf.valtexte(adresse1);
                if (uf.valtexte(adresse2) != "")
                    ret += ", " + uf.valtexte(adresse2) + " ";
                if (uf.valtexte(npa) != "")
                    ret += uf.valtexte(npa) + " " + uf.valtexte(ville);
                ret = ret.Trim();
            }*/
            return ret;
        }
        //leave : si row codeaticle = 0, recherches

        private void codearticle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                recherchearticle(codearticle.Text.Trim(), codearticle);
        }

        private void recherchearticle(string codeart, Control txtreturn)
        {
            codeart = codeart.Trim();
            uf.initcontrol(p_facture, "", null, codearticle, datecommande, reffactureentreprise, reffacturedeltareal);
            //string reqrechart = "SELECT idarticle, codearticle, descriptif_ligne1 as descriptif, unitecode, prix from fact_articles art INNER Join fact_unite unite ON unite.idunite = art.idunite";
            if (codeart.Trim() != "")
            {
                fcode.edcode.Text = codeart;
                //reqrechart += " WHERE codearticle LIKE '%" + codeart.Trim() + "%' ORDER BY codearticle LIKE '" + codeart.Trim() + "%' desc, codearticle, descriptif_ligne1";
                fcode.trouve = false;
                fcode.first = true;
                fcode.Initialisation();
                
                if (fcode.trouve)
                {
                    remplirarticle();
                }
            }

        }

        public void remplirarticle()
        {
            codearticle.Text = fcode.code;
            idarticle.Text = fcode.idcode;
            libellearticle.Text = fcode.lib;
            unite.Text = fcode.unite;
            prixunitaire.Text = fcode.prix;
            ed_rabaispourcent.Text = fcode.rabaispourcent;
            ed_rabaischf.Text = fcode.rabaismontant;
            idprix.Text = fcode.idprix;
            idrabais.Text = fcode.idrabais;

            remarquearticle.Focus();
            nbrarticle.Text = "1";
            //nbrarticle.SelectAll();
        }

        private void codearticle_Leave(object sender, EventArgs e)
        {
            if (codearticle.Text.Trim() != "")
                recherchearticle(codearticle.Text.Trim(), codearticle);
            else
                uf.initcontrol(p_facture, "6");
            //idarticle.Text = "";

        }

        private void nbrarticle_Leave(object sender, EventArgs e)
        {

        }

        private void nbrarticle_TextChanged(object sender, EventArgs e)
        {
            if (nbrarticle.Focused)
                calcmontart();
        }

        

        private void validersaisiearticle()
        {
            if (idarticle.Text.Trim() == "")
            {
                codearticle.Focus();
                return;
            }

            //validation saisie article
            if (uf.testchampvide(p_facture, reffactureentreprise, remarquearticle) == true)
                return;
            if (uf.testchampzero(nbrarticle, "nbr article") == true)
                return;
            //ajout dans grille facture
            ajoutligneart();
            /*decimal mont = 0;
            decimal.TryParse(uf.valtexte(prixunitaire), out mont);
            montantarticle.Text = uf.getFormatCur(decimal.Parse(uf.valtexte(nbrarticle)) * mont);
            */
        }

        private void codearticle_TextChanged(object sender, EventArgs e)
        {
            if (codearticle.Enabled && codearticle.Focused)
            {
                idarticle.Text = "";
            }
        }

        

        private void nbrarticle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                validersaisiearticle();
        }

        
        
        

        int etatrechcli = 0;
        
        

            /*
        private string rechercheclient()
        {
            string valret = "";
            string reqrechcli = "select cli.idclient " +
                "FROM fact_client cli " +
                "left join " + Fmain.baseInit + ".city ON city.idcity = cli.idville WHERE ";
            string condcli = "";
            if (uf.valtexte(raisonsociale) != "")
                condcli += " socligne LIKE '%" + uf.valtexte(raisonsociale) + "%'";
            if (uf.valtexte(nom) != "")
            {
                if (condcli != "")
                    condcli += " AND ";
                condcli += " nom LIKE '%" + uf.valtexte(nom) + "%'";
            }
            if (uf.valtexte(prenom) != "")
            {
                if (condcli != "")
                    condcli += " AND ";
                condcli += " prenom LIKE '%" + uf.valtexte(prenom) + "%'";
            }
            if (uf.valtexte(adresse1) != "")
            {
                if (condcli != "")
                    condcli += " AND ";
                condcli += " adresse1 LIKE '%" + uf.valtexte(adresse1) + "%'";
            }
            if (uf.valtexte(adresse2) != "")
            {
                if (condcli != "")
                    condcli += " AND ";
                condcli += " adresse2 LIKE '%" + uf.valtexte(adresse2) + "%'";
            }
            if (uf.valtexte(npa) != "")
            {
                if (condcli != "")
                    condcli += " AND ";
                condcli += " zip = '" + uf.valtexte(npa) + "'";
            }
            if (uf.valtexte(ville) != "")
            {
                if (condcli != "")
                    condcli += " AND ";
                condcli += " cityname LIKE '%" + uf.valtexte(ville) + "%'";
            }
            comrech.CommandText = reqrechcli + condcli;
            myread = comrech.ExecuteReader();
            int nbrret = 0;
            while(myread.Read())
            {
                if (uf.GetValue(myread, "idclient") == "")
                    break;
                valret = uf.GetValue(myread, "idclient");
                nbrret++;
            }
            myread.Close();
            if (nbrret == 0)
            {
                //non trouvé
            }
            else if (nbrret == 1)
            {
                if (etatfact > 0 && etatrechcli == 0)
                {
                    chargerclient(valret);
                }
                else if (etatfact == 0 && etatrechcli > 0) //recherche client pour affichage liste facture
                {
                    cond = "client.idclient = " + valret;
                    chargerfacture();
                }
            }
            else
            {
                //plusieurs résultats
                f_selection fsel = new f_selection();
                //fsel.Parent = this;
                fsel.comrealvistamod.Connection = comrealvistamod.Connection;
                fsel.condition = " WHERE " + condcli;
                if (fsel.ShowDialog() == DialogResult.OK)
                {
                    //chargerclient(fsel.idselection);
                    if (etatfact > 0 && etatrechcli == 0)
                    {
                        chargerclient(fsel.idselection);
                    }
                    else if (etatfact == 0 && etatrechcli > 0) //recherche client pour affichage liste facture
                    {
                        cond = "client.idclient = " + fsel.idselection;
                        chargerfacture();
                    }
                }
                else
                {

                }
            }
            

            return valret;
        }
        */

            /*
        private void refclient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && refclient.Text.Trim() != "")
            {
                if (etatfact > 0)
                {
                    chargerclient(refclient.Text.Trim());
                }
                else if (etatfact == 0 && etatrechcli > 0)
                {
                    cond = "client.idclient =" + refclient.Text.Trim();
                    chargerfacture();
                }
            }
            if (e.KeyChar == 27)
                chargerclient(currefclient.Text);
        }
        */
        
        private void keypress(KeyPressEventArgs e)
        {
            /*
            if (etatfact == 0 && etatrechcli == 0)
                return;
            if (e.KeyChar == 13)
                rechercheclient();
            if (e.KeyChar == 27)
                chargerclient(currefclient.Text);
                */
        }

        
        private void bt_recherche_Click(object sender, EventArgs e)
        {
            uf.initcontrol(p_facture, "", reffactureentreprise);
            //uf.enablecontrol(p_facture, "7", true);
            reffacturedeltareal.Enabled = reffactureentreprise.Enabled = true;
            uf.enablecontrol(p_menu, "1", false, "2", false);
            bt_annul.Enabled = true;

            reffactureentreprise.Focus();
        }

        private void bt_toutaffciher_Click(object sender, EventArgs e)
        {
            rechclient.Text = "";
            rechfacture.Text = "";
            cond = "";
            chargerfacture(orderclitmp:0);
        }

        private void reffactureentreprise_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void reffacturedeltareal_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        /*private void recherchefacture()
        {
            string c = "";
            if (uf.valtexte(reffactureentreprise) != "")
                c += "reffactureentreprise LIKE '%" + uf.valtexte(reffactureentreprise) + "%' ";
            if (uf.valtexte(reffacturedeltareal) != "")
            {
                if (c != "")
                    c += " AND ";
                c += "reffacturedeltareal LIKE '%" + uf.valtexte(reffacturedeltareal) + "%' ";
            }
            if (c != "")
                cond = c;
            chargerfacture();
        }*/
        
        
        private void bt_paiement_Click(object sender, EventArgs e)
        {
            /*string s = getreffact();
            if (s == "")
                return;
            f_paiement f = new f_paiement();
            f.comrech.Connection = comrech.Connection;
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.numfact = s; 
            f.ShowDialog(this);*/
        }
        /*
         * if (e.KeyChar == 13)
            {
                if (refentreprise.Text.Trim() == "")
                    return;
                chargerentreprise(refentreprise.Text.Trim());
                if (refentreprise.Text.Trim() != "")
                {
                    refclient.Focus();
                    if (etatfact == 2)
                        reffacturedeltareal.Text = generernumfacture(refentreprise.Text.Trim());
                }
            }
            else if (e.KeyChar == 27)
            {
                uf.readonlycontrol(p_entreprise, "", true);
            }
            */

        
        private void f_gesfact_Shown(object sender, EventArgs e)
        {
            if (ajoutdepuisclient && etatfact > 0)
            {
                
                    reffactureentreprise.Focus();
            }
        }
        
        private void codearticle_DoubleClick(object sender, EventArgs e)
        {
            recherchearticle(codearticle.Text.Trim(), codearticle);
        }

        private void codearticle_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                recherchearticle(codearticle.Text.Trim(), codearticle);
        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void libellearticle_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void recherchefacture(TextBox tx)
        {
                curidcli = "";
            int typeord = 0;
            if (uf.valtexte(tx) == "")
                cond = "";
            else
            {
                if (tx.Name == "rechclient")
                {
                    int idcli = 0;
                    int.TryParse(uf.valtexte(rechclient), out idcli);
                    if (idcli > 0)
                        cond = "client.idclient = " + idcli.ToString();
                    else
                    {
                        string[] s = uf.valtexte(rechclient).Split(' ');
                        string tmpnom = "";
                        string tmpprenom = "";
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (tmpnom != "")
                            {
                                tmpnom += " OR ";
                                tmpprenom += " OR ";
                            }
                            tmpnom += "client.nom like '%" + s[i] + "%'";
                            tmpprenom += "client.prenom like '%" + s[i] + "%'";
                        }
                        cond = "client.socligne like '%" + uf.valtexte(rechclient) + "%' " +
                            "OR (client.nom like '%" + uf.valtexte(rechclient) + "%' OR client.prenom like '%" + uf.valtexte(rechclient) + "%')" +
                            "OR ((" + tmpnom + ") AND (" + tmpprenom + "))";

                    }
                    typeord = 1;
                }
                else if (tx.Name == "rechfacture")
                {
                    cond = "(fact.reffacturedeltareal = '" + uf.valtexte(rechfacture) + "' OR fact.reffactureentreprise = '" + uf.valtexte(rechfacture) + "' OR " +
                        "right(fact.reffacturedeltareal, 4) = '" + uf.valtexte(rechfacture).PadLeft(4, '0') + "' )";
                }
                cond = "(" + cond + ") ";

            }
            chargerfacture(cond, typeord);
        }

        private void rechclient_DoubleClick(object sender, EventArgs e)
        {
            f_debiteur f2 = new f_debiteur();

            f2.comrealvista.Connection = comaffichefacture.Connection;
            f2.comrealvistamod.Connection = comrealvistamod.Connection;
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void rechclient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                recherchefacture(rechclient);
                if (lv.Groups.Count == 1)
                {
                    curidcli = getvallv("idclient", 0, lv.Items[0].Group.Name); // lv.Groups[0].Name;
                }
            }
        }

        private void rechfacture_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && etatfact == 0)
            {
                recherchefacture(rechfacture);
            }
        }

        private void rechclient_TextChanged(object sender, EventArgs e)
        {
            if (rechclient.Focused)
                rechfacture.Text = "";
        }

        private void rechfacture_TextChanged(object sender, EventArgs e)
        {
            if (rechfacture.Focused)
                rechclient.Text = "";
        }

        private void lv_ItemActivate(object sender, EventArgs e)
        {
                //lv.FocusedItem.BackColor = Color.Blue;

        }

        private void reffactureentreprise_TextChanged(object sender, EventArgs e)
        {
            if (etatfact > 0 && reffactureentreprise.Focused)
            {
                //if (ck_typesaisie.Checked)
                    lv.Groups[curidcli].Items[0].SubItems[1].Text = uf.valtexte(reffactureentreprise);
                //else
                //    lv.Groups[curidcli].Items[lv.FocusedItem.Index].SubItems[1].Text = uf.valtexte(reffactureentreprise);
            }
        }

        private void lv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            
        }

        private void bt_ajoutligne_Click(object sender, EventArgs e)
        {
            int ind = lv.SelectedItems[0].Index;

            
        }

        private void men_ligne_Opening(object sender, CancelEventArgs e)
        {
            if (etatfact == 0 || (etatfact == 2 && getvallv("codearticle", 0) == ""))
            {
                menligne_ajouterUneLigne.Enabled = false;
                menligne_supprimerUneLigne.Enabled = false;
                return;
            }
            menligne_ajouterUneLigne.Enabled = true;
            menligne_supprimerUneLigne.Enabled = true;
            if (lv.SelectedItems[0].Index == lv.Items.Count -1 || getvallv("codearticle", lv.SelectedItems[0].Index) == "" || lv.SelectedItems[0].Index == 0)
            {
                menligne_supprimerUneLigne.Enabled = false;
            }
            

        }

        private void menligne_ajouterUneLigne_Click(object sender, EventArgs e)
        {
            lv.Items.RemoveAt(lv.Items.Count - 1);
            ajoutlignevide();
            ajoutlignetot();
            calcultotalligne();
            ck_typesaisie.Checked = true;
            if (lv.Items.Count > 2)
                ck_typesaisie.Checked = false;
            int ind = lv.Items.Count - 2;
            lv.Items[ind].Selected = true;
            lv.FocusedItem = lv.Items[ind];
            uf.initcontrol(p_facture, "", codearticle, reffactureentreprise, reffacturedeltareal, datecommande);
        }

        private void menligne_supprimerUneLigne_Click(object sender, EventArgs e)
        {
            int ind = lv.SelectedItems[0].Index;
            lv.Items.RemoveAt(ind);
            calcultotalligne();
        }

        private void bt_suppr_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count < 0)
                return;
            string numf = getreffact();
            if (testerfactimp(numf) == true)
            {
                uf.message_info("Cette facture a déjà été imprimé. Impossible de supprimer !"); 
                return;
            }
            if (uf.confirmer_questionON(this, "Vraiement supprimer la facture ?") == DialogResult.Yes)
            {
                uf.executeSQL(comrealvistamod, "fact_facturation", "", "", 3, "reffacturedeltareal = '" + numf + "' AND identreprise = " + Fmain.identreprisesel);
                bt_toutaffciher_Click(bt_toutaffciher, new EventArgs());
            }

        }

        private void datecommande_ValueChanged(object sender, EventArgs e)
        {
            if (etatfact > 0 && datecommande.Focused)
            {
                //if (ck_typesaisie.Checked)
                lv.Groups[curidcli].Items[0].SubItems[2].Text = uf.valtexte(datecommande);
                //else
                //    lv.Groups[curidcli].Items[lv.FocusedItem.Index].SubItems[1].Text = uf.valtexte(reffactureentreprise);
            }
        }

        private void lv_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Text.Contains("er"))
                e.Item.Group.ListView.BackColor = Color.LightSteelBlue;
            
        }

        private void lv_Click(object sender, EventArgs e)
        {
            selfact();
        }

        private void lv_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void bt_imprimer_Click(object sender, EventArgs e)
        {
            

        }

        string sdaty = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        /*Microsoft.Office.Interop.Word.Application wrdApp;
        Microsoft.Office.Interop.Word._Document wrdDoc;
        Microsoft.Office.Interop.Word._Document newDoc;
        Object oMissing = System.Reflection.Missing.Value;
        Object oFalse = false;
        Object oTrue = true;
        object objNull = System.Reflection.Missing.Value;
        Microsoft.Office.Interop.Word.MailMerge wrdMailMerge;

        Object oleft = 240;
        Object oTop = 47;
        Object oleftdm = 453;
        Object oTopdm = 88;
        Object oWidth = 263;
        Object oHeight = 25;
        Object oWidthdm = 32;
        Object oHeightdm = 32;
        Object oType = Microsoft.Office.Interop.Word.WdFieldType.wdFieldIncludePicture;
        Object oType1 = Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty;
        public bool Fusionner(int typeF, string cond, string datys = "") //typeF : 1 = facture, 2 = action
        {
            foreach (string fic in System.IO.Directory.GetFiles(@Application.StartupPath, "TmpFic"))
            {
                try
                {
                    System.IO.File.Delete(fic);
                }
                catch
                {

                }
            }
            bool valret = true;

            string DocAfaire = "";

            string sz = 
                "select 'modele_facture_1' as document, fbvr.numbvrcomplet, concat_ws(' ', mid(numbvrcomplet, 0, 2), mid(numbvrcomplet, 2, 5), mid(numbvrcomplet, 7, 5), mid(numbvrcomplet, 12, 5), mid(numbvrcomplet, 17, 5), mid(numbvrcomplet, 22)) as numbvrspace, fact.reffacturedeltareal as fact_nofacture, fact.reffactureentreprise as fact_reffactureentreprise, date_format(fact.dateimpression, '%d.%m.%Y') as fact_datefacture, date_format(DATE_ADD(fact.dateimpression, INTERVAL entreprise.echeance day), '%d.%m.%Y') as fact_dateecheance, date_format(fact.datecommande, '%d.%m.%Y') as fact_datecommande, date_format(fact.datefacturedeltareal, '%d.%m.%Y') as fact_datefacturedeltareal, '' as fact_datepaiement, fact.totmontantbrut as fact_totalmontantbrut, concat(fact.tauxtva, '%') as fact_tvapourcent, fact.totrabais as fact_totalrabais, fact.tottva as fact_totaltvachf, fact.fraisenvoi as fact_fraisenvoi, fact.fraisassurance as fact_fraisassurance, fact.interets as fact_interets, fact.fraisrappel as fact_fraisrappel, (fact.totmontantbrut - fact.totrabais + fact.tottva) as fact_montantapayer, 0 as fact_montantpaye, " +

                "fact.numligne as art_numligne, article.codearticle as art_codearticle, concat_ws(char(13), if (trim(article.descriptif_ligne1) = '', null, article.descriptif_ligne1), if (trim(article.descriptif_ligne2) = '', null, article.descriptif_ligne2), if (trim(article.descriptif_ligne3) = '', null, article.descriptif_ligne3), if (trim(article.descriptif_ligne4) = '', null, article.descriptif_ligne4), if (trim(fact.remarquearticle) = '', null, fact.remarquearticle)) as art_libellearticle, fact.remarquearticle as art_remarque, unite.unitelibelle as art_unite, prix.prix as art_prixunitaire, fact.nbr as art_nbrarticle, (prix.prix * fact.nbr) as art_montantbrut, if (rabais.rabaispourcent > 0, concat(rabais.rabaispourcent, '%'), '-') as art_rabaispourcent, if (if (isnull(rabais.rabaispourcent), 0, rabais.rabaispourcent) > 0, (fact.nbr * prix.prix) * rabais.rabaispourcent / 100, if (isnull(rabais.rabaismontant), 0, rabais.rabaismontant)) as art_rabaischf,  " +

                "entreprise.identreprise, entreprise.iddeltareal, langent.letter, if (entreprise.iddeltareal > 0, clidel.socligne1, entreprise.socligne1) as ent_societe, if (entreprise.iddeltareal > 0, clidel.socligne2, entreprise.socligne2) as ent_societecompl, polent.politesselettre as ent_politesse, if (entreprise.iddeltareal > 0, foncdel.nomprenom, fonccli.nomprenom) as ent_nomprenom,   " +
                "if (entreprise.iddeltareal > 0, foncdel.adresse1, fonccli.adresse1) as ent_adresse1, if (entreprise.iddeltareal > 0, foncdel.adresse2, fonccli.adresse2) as ent_adresse2,  " +
                "if (entreprise.iddeltareal > 0, foncdel.co, fonccli.co) as ent_co, clicity.zip as ent_npa, clicity.cityname as ent_ville, if (entreprise.iddeltareal > 0, foncdel.comptebanque, fonccli.comptebanque) as ent_iban, concat(banque.nombanque, ' - ', banque.adresse, ', ', banque.npa, ' ', banque.ville) as ent_banqueccp,  " +
                "if (entreprise.iddeltareal > 0, clidel.numrc, entreprise.numtva) as ent_notva, entreprise.echeance as ent_echeancejour, if (entreprise.iddeltareal > 0, foncdel.email, fonccli.email) as ent_email, if (entreprise.iddeltareal > 0, foncdel.adresseweb, fonccli.siteweb) as ent_siteweb,  " +

                "client.idclient as iCli, concat_ws(char(13), if (trim(socligne) = '', null, socligne), concat(clientpolitesse.politesselettre, ' ', if (trim(client.nom) = '', null, client.nom), ' ', if (trim(client.prenom) = '', null, client.prenom)), if (trim(client.co) = '', null, client.co), concat_ws(' ', if (trim(client.adresse1) = '', null, client.adresse1), if (trim(client.adresse2) = '', null, client.adresse2)), concat(city.zip, ' ', city.cityname)) as cli_adressecomplet,  " +
                "client.socligne as cli_societe, clientpolitesse.politesselettre as cli_politesse, client.nom as cli_nom, client.prenom as cli_prenom, client.co as cli_co, client.adresse1 as cli_adresse1, client.adresse2 as cli_adresse2, city.zip as cli_npa, city.cityname as cli_ville,  " +

                "if (fact.nbrmens > 0, 'oui', 'non') as modemens, fact.nbrmens, article.idarticle, article.codearticle, concat_ws('\n', article.descriptif_ligne1, if (article.remarque = '', null, article.remarque)) as libellearticle, client.idclient, fact.identreprise, fact.idfacture, prix.idprix, rabais.idrabais " +

                "fROM " +
                "fact_facturation fact inner join (select idfacture, concat('000000', LPAD(identreprise, 4, '0'), LPAD(reffacturedeltareal, 10, '0'), date_format(now(), '%y%m%d'), ccpmodulo(concat('000000', LPAD(identreprise, 4, '0'), LPAD(reffacturedeltareal, 10, '0'), date_format(now(), '%y%m%d')))) as numbvrcomplet FROM fact_facturation) fbvr ON fbvr.idfacture = fact.idfacture " +

                "INNER join fact_entreprise entreprise on entreprise.identreprise = fact.identreprise " +
                "left join " + Fmain.baseInit + "client clidel on clidel.idclient = entreprise.iddeltareal " +
                "LEFT JOIN fact_entreprisefonction fonccli ON fonccli.identreprise = entreprise.identreprise AND(fonccli.idfonction = 1) " +
                "LEFT JOIN " + Fmain.baseInit + "clientfonction foncdel ON foncdel.idclient = entreprise.iddeltareal AND(foncdel.idfonctiondelta = 1) " +
                "LEFT join " + Fmain.baseInit + "typepolitesse polent ON polent.idpolitesse = if (entreprise.iddeltareal > 0, foncdel.idpolitesse, fonccli.idpolitesse)  " +
                "LEFT join " + Fmain.baseInit + "language langent ON langent.idlanguage = polent.idlangue " +
                "left join " + Fmain.baseInit + "city clicity ON clicity.idcity = if (entreprise.iddeltareal > 0, foncdel.idville, fonccli.idville)  " +
                "LEFT JOIn " + Fmain.baseInit + "cpta_banque banque ON banque.idbanque = if (entreprise.iddeltareal > 0, foncdel.idbanque, fonccli.idbanque) " +

                "LEFT JOIN fact_client client ON client.idclient = fact.idclient left join   " + Fmain.baseInit + "city ON city.idcity = client.idville left join " + Fmain.baseInit + "typepolitesse clientpolitesse ON client.idpolitesse = clientpolitesse.idpolitesse " +

                "LEFT join fact_articles article ON article.idarticle = fact.idarticle left join (select idprix, idarticleprix, prix, dateprix from fact_prix group by idarticleprix, idprix order by dateprix desc) prix on prix.idarticleprix = article.idarticle and prix.idprix = fact.idprix " +
                "LEFT JOIN(Select idrabais, idarticlerabais, rabaismontant, rabaispourcent, daterabaisde, daterabaisa FROM fact_rabais group by idarticlerabais, idrabais order by daterabaisa desc) rabais ON rabais.idarticlerabais = article.idarticle AND fact.idrabais = rabais.idrabais " +
                "LEFT JOIN fact_unite unite ON unite.idunite = article.idunite " + 
                "ORDER by fact.reffacturedeltareal, fact.idclient, fact.numligne";

            if (typeF == 1)
            {
                if (cond != "")
                {
                    sz = sz.Replace("ORDER", "WHERE " + cond + " ORDER");
                }
            }

            string Doc = "";
            comrealvistamod.CommandText = sz;
            myread = comrealvistamod.ExecuteReader();
            bool docdiff = false;

            string champs = "numbvrcomplet;numbvrspace;fact_nofacture;fact_reffactureentreprise;fact_datefacture;fact_dateecheance;fact_datecommande;fact_datefacturedeltareal;fact_datepaiement;fact_totalmontantbrut;fact_tvapourcent;fact_totalrabais;fact_totaltvachf;fact_fraisenvoi;fact_fraisassurance;fact_interets;fact_fraisrappel;fact_montantapayer;fact_montantpaye;" +

               "art_numligne;art_codearticle;art_libellearticle;art_remarque;art_unite;art_prixunitaire;art_nbrarticle;art_montantbrut;art_rabaispourcent;art_rabaischf;" +

               "identreprise;iddeltareal;letter;ent_societe;ent_societecompl;ent_politesse;ent_nomprenom;" +
               "ent_adresse1;ent_adresse2;" +
               "ent_co;ent_npa;ent_ville;ent_iban;ent_banqueccp;" +
               "ent_notva;ent_echeancejour;ent_email;ent_siteweb;" +

               "iCli;cli_adressecomplet;" +
               "cli_societe;cli_politesse;cli_nom;cli_prenom;cli_co;cli_adresse1;cli_adresse2;cli_npa;cli_ville;" +

               "modemens;nbrmens";

            string[] lvaleur = new string[] { "" };
            lvaleur.SetValue(champs, 0);
            string valeur = "";
            wrdApp = new Microsoft.Office.Interop.Word.Application();
            wrdApp.Visible = false;

            string annee = DateTime.Now.Year.ToString(); ;
            string mois = DateTime.Now.Month.ToString().PadLeft(2, '0'); // +@"_" + Util.ValMois(DateTime.Now.Month);
            string jour = DateTime.Now.Day.ToString().PadLeft(2, '0');

            string rep = Application.StartupPath + @"\Factures" + @"\" + Fmain.identreprisesel.PadLeft(2, '0') + @"\" + @annee + @"\" + @mois + @"\" + @jour;

            wrdApp = new Microsoft.Office.Interop.Word.Application();
            wrdApp.Visible = false;

            
            try
            {
                foreach (string ss in System.IO.Directory.GetFiles(@rep, "*.*"))
                    System.IO.File.Delete(ss);
                //System.IO.Directory.Delete(rep, true);
            }
            catch { }

            if (System.IO.Directory.Exists(rep) == false)
                System.IO.Directory.CreateDirectory(rep);

            int nrow = 1;
            bool erreur = false;

            while (myread.Read())
            {

                DocAfaire = uf.GetValue(myread, "document"); //uf.GetValue(myread, "")
                DocAfaire = DocAfaire.Replace(".docx", "").Replace(".doc", "");
                if (System.IO.File.Exists(DocAfaire + "_" + uf.GetValue(myread, "letter") + ".doc") == true)
                {
                    DocAfaire = DocAfaire + "_" + uf.GetValue(myread, "letter") + ".doc";
                }
                else if (System.IO.File.Exists(DocAfaire + "_" + uf.GetValue(myread, "letter") + ".docx") == true)
                {
                    DocAfaire = DocAfaire + "_" + uf.GetValue(myread, "letter") + ".docx";
                }
                else
                {
                    if (System.IO.File.Exists(DocAfaire + ".doc") == true)
                    {
                        DocAfaire = DocAfaire + ".doc";
                    }
                    else if (System.IO.File.Exists(DocAfaire + ".docx") == true)
                    {
                        DocAfaire = DocAfaire + ".docx";
                    }
                }

                if (!System.IO.File.Exists(DocAfaire))
                {
                    valret = false;
                    return valret;
                }
                

                string autre = "";
                string dernbouc = "";
                if (DocAfaire != "")
                {
                    
                    #region insertion ligne valeur

                    
                    valeur = uf.GetValue(myread, "numbvrcomplet") +
                        uf.GetValue(myread, "numbvrspace") + ";"+ 
                        uf.GetValue(myread, "fact_nofacture") + ";"+ 
                        uf.GetValue(myread, "fact_reffactureentreprise") + ";"+ 
                        uf.GetValue(myread, "fact_datefacture") + ";"+ 
                        uf.GetValue(myread, "fact_dateecheance") + ";"+ 
                        uf.GetValue(myread, "fact_datecommande") + ";"+ 
                        uf.GetValue(myread, "fact_datefacturedeltareal") + ";"+ 
                        uf.GetValue(myread, "fact_datepaiement") + ";"+ 
                        uf.GetValue(myread, "fact_totalmontantbrut") + ";"+ 
                        uf.GetValue(myread, "fact_tvapourcent") + ";"+ 
                        uf.GetValue(myread, "fact_totalrabais") + ";"+ 
                        uf.GetValue(myread, "fact_totaltvachf") + ";"+ 
                        uf.GetValue(myread, "fact_fraisenvoi") + ";"+ 
                        uf.GetValue(myread, "fact_fraisassurance") + ";"+ 
                        uf.GetValue(myread, "fact_interets") + ";"+ 
                        uf.GetValue(myread, "fact_fraisrappel") + ";"+ 
                        uf.GetValue(myread, "fact_montantapayer") + ";"+ 
                        uf.GetValue(myread, "fact_montantpaye") + ";"+ 
                        uf.GetValue(myread, "art_numligne") + ";"+ 
                        uf.GetValue(myread, "art_codearticle") + ";"+ 
                        uf.GetValue(myread, "art_libellearticle") + ";"+ 
                        uf.GetValue(myread, "art_remarque") + ";"+ 
                        uf.GetValue(myread, "art_unite") + ";"+ 
                        uf.GetValue(myread, "art_prixunitaire") + ";"+ 
                        uf.GetValue(myread, "art_nbrarticle") + ";"+ 
                        uf.GetValue(myread, "art_montantbrut") + ";"+ 
                        uf.GetValue(myread, "art_rabaispourcent") + ";"+ 
                        uf.GetValue(myread, "art_rabaischf") + ";"+ 
                        uf.GetValue(myread, "identreprise") + ";"+ 
                        uf.GetValue(myread, "iddeltareal") + ";"+ 
                        uf.GetValue(myread, "letter") + ";"+ 
                        uf.GetValue(myread, "ent_societe") + ";"+ 
                        uf.GetValue(myread, "ent_societecompl") + ";"+ 
                        uf.GetValue(myread, "ent_politesse") + ";"+ 
                        uf.GetValue(myread, "ent_nomprenom") + ";"+ 
                        uf.GetValue(myread, "ent_adresse1") + ";"+ 
                        uf.GetValue(myread, "ent_adresse2") + ";"+ 
                        uf.GetValue(myread, "ent_co") + ";"+ 
                        uf.GetValue(myread, "ent_npa") + ";"+ 
                        uf.GetValue(myread, "ent_ville") + ";"+ 
                        uf.GetValue(myread, "ent_iban") + ";"+ 
                        uf.GetValue(myread, "ent_banqueccp") + ";"+ 
                        uf.GetValue(myread, "ent_notva") + ";"+ 
                        uf.GetValue(myread, "ent_echeancejour") + ";"+ 
                        uf.GetValue(myread, "ent_email") + ";"+ 
                        uf.GetValue(myread, "ent_siteweb") + ";"+ 
                        uf.GetValue(myread, "iCli") + ";"+ 
                        uf.GetValue(myread, "cli_adressecomplet") + ";"+ 
                        uf.GetValue(myread, "cli_societe") + ";"+ 
                        uf.GetValue(myread, "cli_politesse") + ";"+ 
                        uf.GetValue(myread, "cli_nom") + ";"+ 
                        uf.GetValue(myread, "cli_prenom") + ";"+ 
                        uf.GetValue(myread, "cli_co") + ";"+ 
                        uf.GetValue(myread, "cli_adresse1") + ";"+ 
                        uf.GetValue(myread, "cli_adresse2") + ";"+ 
                        uf.GetValue(myread, "cli_npa") + ";"+ 
                        uf.GetValue(myread, "cli_ville") + ";"+ 
                        uf.GetValue(myread, "modemens") + ";"+ 
                        uf.GetValue(myread, "nbrmens");

                    #endregion
                    Array.Resize(ref lvaleur, lvaleur.Length + 1);

                    lvaleur.SetValue(valeur, nrow);
                    nrow++;

                    if (DocAfaire.Replace(".docx", "").Replace(".doc", "") !=
                             uf.GetValue(myread, "fact.document").Replace("_F", "").Replace("_D", "").Replace("_I", "").Replace(".docx", "").Replace(".doc", "") + "_" + uf.GetValue(myread, "letter"))
                        docdiff = true;

                    if (docdiff)
                    {
                        string ff = @Application.StartupPath + @"\TmpFicFact.txt";
                        //try
                        //{
                            System.IO.File.WriteAllLines(ff, lvaleur);
                        //}
                        //catch
                        //{
                            //ff = @Application.StartupPath + @"\TmpFic" + string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now) + ".txt";
                            //System.IO.File.WriteAllLines(ff, lvaleur);
                        //}
                        string fich = @rep + @"\Facture_" + uf.GetValue(myread, "letter") + @"_" + Fmain.identreprisesel.PadLeft(2, '0') + ".doc";

                        CreateMailMergeDataFile(ff, DocAfaire, docdiff, fich);


                        lvaleur = new string[] { "" };
                        lvaleur.SetValue(champs, 0);
                        nrow = 1;
                        docdiff = false;
                    }

                }
                else
                {
                    erreur = true;

                }

                Doc = DocAfaire;
                if (erreur)
                    uf.AfficherErreur("Il y a eu un erreur ! Veuillez vérifier les données dans la colonne 'imp OK'!");

                try
                {
                    wrdDoc.MailMerge.DataSource.Close();
                    // tell word this not a merge document
                    wrdDoc.MailMerge.MainDocumentType = Microsoft.Office.Interop.Word.WdMailMergeMainDocType.wdNotAMergeDocument;

                    wrdDoc.Close(ref oFalse);
                    //wrdApp.Documents.Close(ref oFalse);
                    wrdApp.Visible = true;
                    wrdApp.Quit(ref oFalse);
                    wrdMailMerge = null;
                    wrdDoc = null;
                    wrdApp = null;
                }
                catch { }


            }
            return true;
        }

        public void CreateMailMergeDataFile(string tmpfic, string Doc, bool nouveau, string dest)
        {

            try
            {
                System.IO.File.Delete(@Application.StartupPath + @"\tmpdm.jpg");
            }
            catch { }
            if (nouveau)
            {

                try
                { wrdDoc.Close(ref oFalse, ref oMissing, ref oMissing); }
                catch { }
                wrdDoc = wrdApp.Documents.Open(Doc, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oFalse);
            }
            wrdDoc.Fields.Update();

            object oName = tmpfic; // Application.StartupPath + @"\TmpFic.txt";

            wrdDoc.MailMerge.OpenDataSource(oName.ToString(), Microsoft.Office.Interop.Word.WdOpenFormat.wdOpenFormatText,
                ref oMissing, ref oTrue, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing);
            Object fileName = @dest; // Application.StartupPath + @"\TmpDoc.doc";

            wrdMailMerge = wrdDoc.MailMerge;

            wrdMailMerge.Destination = Microsoft.Office.Interop.Word.WdMailMergeDestination.wdSendToNewDocument;

            wrdMailMerge.Execute(ref oFalse);
            //wrdDoc.Fields.Update();

            object wdFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;
            wrdApp.ActiveDocument.Fields.Update();
            //wrdApp.ActiveDocument.Shapes.SelectAll();
            //wrdApp.Selection.Fields.Update();

            //wrdApp.ActiveDocument.Shapes.AddPicture(@Application.StartupPath + @"\PP.jpg", oFalse, oMissing, oleft, oTop, oWidth, oHeight, ref oMissing);
            wrdApp.ActiveDocument.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref
                oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref
                oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            // Release References.


            try
            {
                wrdApp.ActiveDocument.Close(ref oMissing);
                wrdDoc.MailMerge.DataSource.Close();
                // tell word this not a merge document
                wrdDoc.MailMerge.MainDocumentType = Microsoft.Office.Interop.Word.WdMailMergeMainDocType.wdNotAMergeDocument;
            }
            catch { }

            // Release References.
            object saveChanges = true;
            //wrdApp.Quit(ref saveChanges, ref oMissing, ref oMissing);


        }
        */
        private void bt_imprimertout_Click(object sender, EventArgs e)
        {
            
        }

        private void afficherprocedure(string numfact)
        {
            gv_procedure.Rows.Clear();
            bt_supproc.Enabled = false;
            if (numfact == "")
                return;
            string s = "SELECT idprocedure, identreprise, idclient, numfacture, inouttype, initial, dateproc, typecourrier, echeanceproc FROM fact_procedures WHERE identreprise = " + Fmain.identreprisesel + " AND numfacture = '" + numfact + "' ORDER BY dateproc desc";
            uf.afficherInfo(null, s, comrech, gv_procedure);
            if (gv_procedure.RowCount > 0)
                bt_supproc.Enabled = true;
        }

        private void bt_supproc_Click(object sender, EventArgs e)
        {
            if (gv_procedure.RowCount == 0)
            {
                uf.message_info("Il n'y a pas encore de procedure sur cette facture !");
                return;
            }
            if (gv_procedure.SelectedRows[0].Index < gv_procedure.RowCount-1)
            {
                uf.message_info("Vous ne pouvez supprimer que la dernière procédure !");
                return;
            }
            if (uf.confirmer_questionON(this, "Etes-vous sûre de supprimer la procédure sélectionnée ?") == DialogResult.Yes)
            {
                uf.executeSQL(comrech, "fact_procedures", "", "", 3, "idprocedure =" + gv_procedure.SelectedRows[0].Cells["g_idprocedure"].FormattedValue.ToString());
                afficherprocedure(getreffact());
            }
        }

        private void pg_envoyes_Click(object sender, EventArgs e)
        {
            
        }

        private void tp_facture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_facture.SelectedIndex == -1)
                return;
            chargerfacture(orderclitmp: ordercli);

            if (tp_facture.SelectedIndex == 1 || tp_facture.SelectedIndex == 4)
                impressionComptableToolStripMenuItem.Enabled = true;
            else
                impressionComptableToolStripMenuItem.Enabled = false;

            if (lv.Items.Count > 0)
            {
                lv.Items[0].Selected = true;
                lv_Click(lv, new EventArgs());
            }
            else
            {
                gv_procedure.Rows.Clear();
                gv_paiement.Rows.Clear();
                bt_supproc.Enabled = bt_listepaiement.Enabled = false;
            }
        }

        private void bt_compta_Click(object sender, EventArgs e)
        {
            
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            string cl = getvallv("idclient", 0, lv.SelectedItems[0].Group.Name);
            rechclient.Text = cl;
            rechfacture.Text = "";
            cond = "fact.idclient = " + cl;
            chargerfacture("fact.idclient = " + cl, 1);
        }

        private void bt_pajout_Click(object sender, EventArgs e)
        {
            string reff = getreffact();
            if (reff == "")
            {
                uf.message_info("Veuillez sélectionner une facture !");
                return;
            }
            f_paiement f = new f_paiement();
            f.comrech.Connection = comrech.Connection;
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.numfact = reff;
            f.typefen = 1;
            f.typemod = 1;
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                string cl = getvallv("idclient", 0, lv.SelectedItems[0].Group.Name);
                rechclient.Text = cl;
                rechfacture.Text = "";
                cond = "fact.idclient = " + cl;
                chargerfacture("fact.idclient = " + cl, 1);
                tp_facture.SelectedIndex = 4;
            }
        }

        private void bt_listepaiement_Click(object sender, EventArgs e)
        {
            string reff = getreffact();
            if (reff == "")
            {
                uf.message_info("Veuillez sélectionner une facture !");
                return;
            }
            f_paiement f = new f_paiement();
            f.comrech.Connection = comrech.Connection;
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.numfact = reff;
            f.typefen = 1;
            f.typemod = 0;
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                string cl = getvallv("idclient", 0, lv.SelectedItems[0].Group.Name);
                rechclient.Text = cl;
                rechfacture.Text = "";
                cond = "fact.idclient = " + cl;
                chargerfacture("fact.idclient = " + cl, 1);
            }
        }

        private void imprimerLaFactureSélectionnéeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_modelefact f = new f_modelefact();
            f.cond = "fact.reffacturedeltareal = '" + getreffact() + "'";
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.comrech.Connection = comrech.Connection;
                f.bt_valider.Visible = false;
            if (tp_facture.SelectedIndex == 0)
                f.bt_valider.Visible = true;
            if (f.ShowDialog(this) == DialogResult.OK)
                tp_facture.SelectedIndex = 1;
        }

        private void imprimerToutesLesFacturesDansLaListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_modelefact f = new f_modelefact();
            f.bt_valider.Visible = false;

            if (tp_facture.SelectedIndex == 1) //envoyées mais non payées en totalité et pas en echeance et pas encore de rappel
            {
                if (cond != "")
                {
                    f.cond = cond + " AND ";
                }

                f.cond += " fact.dateimpression is not null AND fact.rappel = 0 AND fact.dateecheance >= now() AND (paiement.montantpaye = 0 OR paiement.montantpaye IS NULL or paiement.montantpaye < fact.montantapayer)";
            }
            else if (tp_facture.SelectedIndex == 2) //envoyées mais non payées en totalité et pas en echeance et rappel déjà envoyé
            {
                string condrap = "";
                if (ck_rap1.Checked && ck_rap2.Checked)
                    condrap = "";
                else
                {
                    if (ck_rap1.Checked)
                        condrap = " AND fact.rappel = 1 ";
                    if (ck_rap2.Checked)
                        condrap = " AND fact.rappel = 2 ";
                }
                if (cond != "")
                {
                    f.cond = cond + " AND ";
                }

                f.cond += " fact.dateimpression is not null AND fact.rappel > 0 " + condrap + " AND fact.dateecheance >= now() AND (paiement.montantpaye = 0 OR paiement.montantpaye IS NULL or paiement.montantpaye < fact.montantapayer)";
            }
            else if (tp_facture.SelectedIndex == 0) //saisies non encore envoyées
            {
                if (cond != "")
                {
                    f.cond = cond + " AND ";
                }

                f.cond += " fact.dateimpression is null";
                f.bt_valider.Visible = true; 
            }
            else if (tp_facture.SelectedIndex == 4) //payées
            {
                if (cond != "")
                {
                    f.cond = cond + " AND ";
                }

                f.cond += " fact.dateimpression is not null AND paiement.montantpaye >= fact.montantapayer";
            }
            else if (tp_facture.SelectedIndex == 3) //echeance
            {
                if (cond != "")
                {
                    f.cond = cond + " AND ";
                }

                f.cond += " fact.dateimpression is not null AND fact.dateecheance < now() and fact.rappel > -1 ";
            }
            //f.cond = cond;

            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.comrech.Connection = comrech.Connection;
            if (f.ShowDialog(this) == DialogResult.OK && lv.SelectedItems.Count > 0)
                tp_facture.SelectedIndex = 1;
                //afficherprocedure(getreffact());

        }

        private void impressionComptableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_etatfact f = new f_etatfact();
            if (tp_facture.SelectedIndex == 1)
                f.typecompta = 1; //envoyé
            else if (tp_facture.SelectedIndex == 4)
                f.typecompta = 2; //envoyé
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.ShowDialog(this);
        }

        private void bt_impression_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                men_impression.Show(bt_impression.PointToScreen(e.Location));
        }

        private void bt_rappel_Click(object sender, EventArgs e)
        {
            
        }

        private void tp_facture_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (pg_saisies.Text != "sdfsdfsdffd")
                pg_saisies.Text = "sdfsdfsdffd";

        }

        private void lb_toutes_Click(object sender, EventArgs e)
        {
            afficheronglet(5);
        }

        private void afficheronglet(int indeonglet)
        {
            if (indeonglet == 2)
            {
                lb_lbrappel.Visible = ck_rap1.Visible = ck_rap2.Visible = true;
            }
            else
            {
                lb_lbrappel.Visible = ck_rap1.Visible = ck_rap2.Visible = false;
                ck_rap2.Checked = ck_rap1.Checked = true;
            }
            tp_facture.SelectedIndex = indeonglet;
            
        }

        private void lb_payees_Click(object sender, EventArgs e)
        {
            afficheronglet(4);
        }

        private void lb_echeances_Click(object sender, EventArgs e)
        {
            afficheronglet(3);
        }

        private void lb_encoyees_Click(object sender, EventArgs e)
        {
            afficheronglet(1);
        }

        private void lb_saisies_Click(object sender, EventArgs e)
        {
            afficheronglet(0);
        }

        private void lb_payees_MouseHover(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.Bisque;
        }

        private void lb_toutes_BackColorChanged(object sender, EventArgs e)
        {
            
            if ((sender as Label).Name == "lb_toutes")
            {
                lb_mtttou.BackColor = (sender as Label).BackColor;
                lb_nbrtou.BackColor = (sender as Label).BackColor;
                lb_rappelenvoye.BackColor = lb_payees.BackColor = lb_echeances.BackColor = lb_saisies.BackColor = lb_envoyees.BackColor = Color.Transparent;
            }
            else if ((sender as Label).Name == "lb_payees")
            {
                lb_mttpay.BackColor = (sender as Label).BackColor;
                lb_nbrpay.BackColor = (sender as Label).BackColor;
                lb_rappelenvoye.BackColor = lb_toutes.BackColor = lb_echeances.BackColor = lb_saisies.BackColor = lb_envoyees.BackColor = Color.Transparent;
            }
            else if ((sender as Label).Name == "lb_echeances")
            {
                lb_mttech.BackColor = (sender as Label).BackColor;
                lb_nbrech.BackColor = (sender as Label).BackColor;
                lb_rappelenvoye.BackColor = lb_toutes.BackColor = lb_payees.BackColor = lb_saisies.BackColor = lb_envoyees.BackColor = Color.Transparent;
            }
            else if ((sender as Label).Name == "lb_envoyees")
            {
                lb_mttenv.BackColor = (sender as Label).BackColor;
                lb_nbrenv.BackColor = (sender as Label).BackColor;
                lb_rappelenvoye.BackColor = lb_toutes.BackColor = lb_payees.BackColor = lb_echeances.BackColor = lb_saisies.BackColor = Color.Transparent;
            }
            else if ((sender as Label).Name == "lb_rappelenvoye")
            {
                lb_mttrap.BackColor = (sender as Label).BackColor;
                lb_nbrrap.BackColor = (sender as Label).BackColor;
                //ck_rap1.BackColor = (sender as Label).BackColor;
                //ck_rap2.BackColor = (sender as Label).BackColor;
                lb_envoyees.BackColor = lb_toutes.BackColor = lb_payees.BackColor = lb_echeances.BackColor = lb_saisies.BackColor = Color.Transparent;
            }
            else if ((sender as Label).Name == "lb_saisies")
            {
                lb_mttsai.BackColor = (sender as Label).BackColor;
                lb_nbrsai.BackColor = (sender as Label).BackColor;
                lb_rappelenvoye.BackColor = lb_toutes.BackColor = lb_payees.BackColor = lb_echeances.BackColor = lb_envoyees.BackColor = Color.Transparent;
            }

        }

        private void tp_facture_MouseEnter(object sender, EventArgs e)
        {
            lb_rappelenvoye.BackColor = lb_toutes.BackColor = lb_payees.BackColor = lb_echeances.BackColor = lb_saisies.BackColor = lb_envoyees.BackColor = Color.Transparent;
        }

        private void tp_facture_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void lb_rappelenvoye_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox))
            {

                if (ck_rap1.Checked == false && ck_rap2.Checked == false)
                    ck_rap2.Checked = ck_rap1.Checked = true;
                tp_facture.SelectedIndex = -1;
            }
            afficheronglet(2);
        }

        private void bt_rappel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                men_rappel.Show(bt_rappel.PointToScreen(e.Location));
        }

        private void pourToutesLesFacturesÀÉchéanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_modelefact f = new f_modelefact();
            f.cond = "fact.dateimpression is not null AND fact.dateecheance < now()  and fact.rappel > -1 AND (paiement.montantpaye is null or paiement.montantpaye < montantapayer )";
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.bt_valider.Visible = false;
            f.brappel = true;
            f.comrech.Connection = comrech.Connection;
            if (tp_facture.SelectedIndex == 3)
                f.bt_valider.Visible = true;
            if (f.ShowDialog(this) == DialogResult.OK)
                tp_facture.SelectedIndex = 2;
        }

        private void pourLaFactureSélectionnéeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_modelefact f = new f_modelefact();
            f.cond = "fact.dateimpression is not null AND fact.dateecheance < now()  and fact.rappel > -1 AND fact.reffacturedeltareal = '" + getreffact() + "' ";
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.bt_valider.Visible = false;
            f.brappel = true;
            f.comrech.Connection = comrech.Connection;
            if (tp_facture.SelectedIndex == 3)
                f.bt_valider.Visible = true;
            if (f.ShowDialog(this) == DialogResult.OK)
                tp_facture.SelectedIndex = 2;
        }

        private void imprimerrappel_Click(object sender, EventArgs e)
        {
            f_modelefact f = new f_modelefact();
            f.cond = " fact.reffacturedeltareal = '" + getreffact() + "' ";
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.bt_valider.Visible = false;
            f.brappel = f.brappelimp = true;
            f.comrech.Connection = comrech.Connection;
            if (tp_facture.SelectedIndex == 3)
                f.bt_valider.Visible = true;
            if (f.ShowDialog(this) == DialogResult.OK)
                tp_facture.SelectedIndex = 1;
        }

        private void bt_modifajoutart_Click(object sender, EventArgs e)
        {
            if (etatfact == 0)
            {
                bt_modif_Click(bt_modif, new EventArgs());
            }
            menligne_ajouterUneLigne_Click(bt_modifajoutart, new EventArgs());
        }

        private void imprimerLaListeDesFacturesÀÉchéanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_modelefact f = new f_modelefact();
            
            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.bt_valider.Visible = false;
            f.blisterap = true;
            f.stypefact = 3;
            f.comrech.Connection = comrech.Connection;
            f.ShowDialog(this);
        }

        private void men_impression_Opening(object sender, CancelEventArgs e)
        {
            imprimerrappel.Enabled = false;
            if (lb_rappel.Text != "0")
                imprimerrappel.Enabled = true;
        }

        private void imprimerÉtatDeFactureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_modelefact f = new f_modelefact();

            f.comrealvistamod.Connection = comrealvistamod.Connection;
            f.bt_valider.Visible = false;
            f.blisterap = true;
            f.stypefact = tp_facture.SelectedIndex;
            f.comrech.Connection = comrech.Connection;
            f.ShowDialog(this);
        }
    }
}
