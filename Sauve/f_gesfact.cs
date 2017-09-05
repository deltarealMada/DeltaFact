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

        public bool ajoutdepuisclient = false;
        public string ajoutidcli = "";

        private void f_gesfact_Load(object sender, EventArgs e)
        {

            uf.initialisation(p_facture);
            uf.initialisation(p_article);
            //uf.RemplirCombo(refentreprise, "SELECT lpad(fact_entreprise.identreprise, 4, '0') as refentreprise, identreprise as idrefentreprise FROM fact_entreprise ORDER by identreprise", comrealvistamod, mySqlDataAdapter1);
            //chargement code article
            fcode.Owner = this;
            fcode.DeltaSQLCon.Connection = comrech.Connection;
            //fcode.Initialisation();
            //
            int nb = 0;
            foreach(Control c in p_facture.Controls)
            {
                if (c.GetType().Name == typeof(TextBox).Name || c.GetType().Name == typeof(DateTimePicker).Name)
                {
                    factcontrol.Add(c.Name);
                    factvaleur.Add(c.Text);
                }
            }
                
            chargerentreprise(Fmain.identreprisesel);

            if (!ajoutdepuisclient)
                chargerfacture(cond);
            else
            {
                currefclient.Text = ajoutidcli;
                refclient.Text = ajoutidcli;
                etatfact = 2;
                chargerclient(ajoutidcli);
                ajoutevent();
                //reffactureentreprise_Click(reffactureentreprise, new EventArgs());
                //refentreprise.Focus();
            }
        }
        public string cond = "";
        private void chargerfacture(string temprech = "")
        {
            ajoutdepuisclient = false;
            sqlfact = "select fact.numligne, " +
                "if (fact.numligne = 0, concat(if(isnull(fact.reffactureentreprise), '',fact.reffactureentreprise) , char(13), fact.reffacturedeltareal), article.codearticle) as reference, fact.reffacturedeltareal as reffactdeltareal, fact.reffactureentreprise as reffactentreprise, " +
                "fact.idfacture, if(isnull(fact.reffactureentreprise), '',fact.reffactureentreprise) as reffactureentreprise, entreprise.identreprise, entreprise.iddeltareal,  " +
                "concat_ws(' ', if (iddeltareal > 0, clidelta.socligne1, entreprise.socligne1), if (iddeltareal > 0, clidelta.socligne2, entreprise.socligne2)) as entreprise, " +
                "entreprise.tauxtva, client.idclient,  " +
                "if (fact.numligne = 0, concat_ws(char(13), concat_ws(' ', if(client.socligne = '', null, concat(client.socligne, ', ')), client.nom, client.prenom), concat_ws(' ', client.adresse1, client.adresse2, concat(city.zip, ' ', city.cityname))), article.descriptif_ligne1) as clientlibelle , " +
                "if (fact.numligne = 0, concat(date_format(fact.datecommande, '%d.%m.%Y'), char(13), date_format(fact.datefactureentreprise, '%d.%m.%Y')), article.prix) as dateprix,  " +
                "if (fact.numligne = 0, if (fact.nbrmens > 0, concat('oui', char(13), fact.nbrmens), concat('non', char(13), 0)), fact.nbr) as mensnbrarticle, " +
                "if (fact.numligne = 0, concat(date_format(fact.dateecheance, '%d.%m.%Y'), char(13), fact.montantfacture), fact.montantarticle) as montanttotecheance, " +
                "if (fact.numligne = 0, concat(concat(fact.rabaisfacturepourcent, '%'), char(13), concat(fact.tauxtva, '%')), concat(fact.rabaisarticlepourcent, '%')) as rabaistva,   " +
                "if (fact.numligne = 0, concat(fact.rabaisfacturemontant, char(13), fact.montanttva), fact.rabaisarticlemontant) as montantrabaistva, 0 as montantpaye, article.idarticle, " +
                "if (fact.numligne = 0, fact.montantfacturettc, fact.montantarticlefinal) as montantapayeart, " +
                "date_format(fact.dateecheance, '%d.%m.%Y') as dateecheance, fact.montantfacture, " +
                "article.codearticle, article.descriptif_ligne1 as libellearticle, unite.unitelibelle as unite, fact.prixunitaire, fact.nbr as nbrarticle, fact.montantarticle, fact.rabaisarticlepourcent as rabaispourcent, fact.rabaisarticlemontant as rabaismontant, fact.montantarticlefinal " +
                "from " +
                "fact_facturation fact left join fact_entreprise entreprise ON entreprise.identreprise = fact.identreprise and entreprise.identreprise = " + Fmain.identreprisesel + " " +
                "LEFT JOIN  " + Fmain.baseInit + ".client clidelta ON clidelta.idclient = entreprise.iddeltareal " +
                "LEFT JOIN fact_client client ON client.idclient = fact.idclient left join  " + Fmain.baseInit + ".city ON city.idcity = client.idville " +
                "LEFT join fact_articles article ON article.idarticle = fact.idarticle LEFT JOIN fact_unite unite ON unite.idunite = article.idunite ";
            if (temprech != "")
                sqlfact += " WHERE " + temprech;
            else if (cond != "")
                sqlfact += " WHERE " + cond;
             sqlfact += " order by fact.reffacturedeltareal, fact.numligne";
            gv_fact.Rows.Clear();
            initialisation();
            
            comrealvistamod.CommandText = sqlfact;
            myread = comrealvistamod.ExecuteReader();
            while (myread.Read())
            {
                //gv_fact.Rows.Add(1);
                uf.afficherInfo(this, "", comrealvistamod, gv_fact, "", myread, gv_fact.RowCount);
                if (uf.GetValue(myread, "numligne") == "0")
                {
                    gv_fact.Rows[gv_fact.RowCount - 1].Height = 30;
                    gv_fact.Rows[gv_fact.RowCount - 1].Cells[0].Style.SelectionBackColor = Color.NavajoWhite;
                    gv_fact.Rows[gv_fact.RowCount - 1].Cells[0].Style.SelectionForeColor = Color.Black;
                    gv_fact.Rows[gv_fact.RowCount - 1].DefaultCellStyle.BackColor = Color.NavajoWhite; 
                    gv_fact.Rows[gv_fact.RowCount - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                else
                {
                    gv_fact.Rows[gv_fact.RowCount - 1].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                    //gv_fact.Rows[gv_fact.RowCount - 1].Cells[0].Style.Padding.Left = 10;
                }
            }
            myread.Close();
            if (gv_fact.RowCount > 0)
                charger(0);
                //afficherfacture(gv_fact.Rows[0].Cells["g_idfacture"].FormattedValue.ToString());
        }

        private void affichecommentaire(string ident)
        {
            string reqcom = "SELECT identretien, identreprise as identreprisecom, typecom, dateentretien as datecom, infos as commentaire FROM fact_entreprisehistory WHERE identreprise = " + ident + " ORDER BY datecom";
            uf.afficherInfo(p_entreprise, reqcom, comrealvistamod, gv_commentaire, "");
            
        }

        private void afficherfacture(string idfacture)
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

        private void initialisation()
        {

            uf.initcontrol(p_facture, "", reffacturedeltareal);
            //uf.initcontrol(p_entreprise, "2", refentreprise);
            uf.initcontrol(p_client, "3", refclient);
            uf.initcontrol(p_article, "6", codearticle);
            uf.enablecontrol(p_article, "6", false);
            uf.readonlycontrol(p_entreprise, "", true);
            //refentreprise.reaf = false;
            uf.readonlycontrol(p_client, "", true);
            uf.enablecontrol(p_facture, "", false);
                uf.enablecontrol(p_menu, "1", false, "2", false, "3", false);
            bt_ajout.Enabled = true;
            //uf.enablecontrol(p_menu, "", false);

        }

        string idcurfact = "";
        private void charger(int numligne)
        {

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
                //idcurfact = gv_fact.Rows[lignef].Cells["g_idfacture"].Value.ToString();

                //
                
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
            }
        }

        private void gv_fact_Click(object sender, EventArgs e)
        {
            if (gv_fact.RowCount == 0 || gv_fact.CurrentRow.Index == -1)
            {
                uf.enablecontrol(p_menu, "1", false, "2", false, "3", true);
                bt_ajout.Enabled = true;
                return;
            }
            //lignefact(gv_fact.CurrentRow.Index);
            
            charger(gv_fact.CurrentRow.Index);
        }

        private void affichedetailarticle(int numligne)
        {
            codearticle.Text = gv_fact.Rows[numligne].Cells["g_codearticle"].FormattedValue.ToString();
            idarticle.Text = gv_fact.Rows[numligne].Cells["g_idarticle"].FormattedValue.ToString();
            libellearticle.Text = gv_fact.Rows[numligne].Cells["g_libellearticle"].FormattedValue.ToString();
            prixunitaire.Text = gv_fact.Rows[numligne].Cells["g_prixunitaire"].FormattedValue.ToString();
            unite.Text = gv_fact.Rows[numligne].Cells["g_unite"].FormattedValue.ToString();
            nbrarticle.Text = gv_fact.Rows[numligne].Cells["g_nbrarticle"].FormattedValue.ToString();
            montantarticle.Text = gv_fact.Rows[numligne].Cells["g_montantarticle"].FormattedValue.ToString();
            rabaisarticlepourcent.Text = gv_fact.Rows[numligne].Cells["g_rabaispourcent"].FormattedValue.ToString();
            rabaisarticlemontant.Text = gv_fact.Rows[numligne].Cells["g_rabaismontant"].FormattedValue.ToString();
            montantarticlefinal.Text = gv_fact.Rows[numligne].Cells["g_montantarticlefinal"].FormattedValue.ToString();
            if (etatfact > 0)
            {
                etatart = 1;
            }

        }

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

        int etatfact = 0; //1 modif; 2 ajout
        private void bt_modif_Click(object sender, EventArgs e)
        {
            //cond = ;
            chargerfacture("reffacturedeltareal = '" + uf.valtexte(reffacturedeltareal) + "' ");
            uf.enablecontrol(p_facture, "6", true, "7", false);
            uf.enablecontrol(p_menu, "1", false, "2", true, "3", false);
            refclient.ReadOnly = false;
            //refentreprise.ReadOnly = false;
            etatfact = 1;
        }

        string nouveaufacture = "";
        private string generernumfacture(string ident)
        {
            string req = "select right(max(reffacturedeltareal), 6) as max from fact_facturation where identreprise = " + ident;
            comrech.CommandText = req;
            myread = comrech.ExecuteReader();
            if (myread.Read() && uf.GetValue(myread, "max") != "")
            {
                int newfact = int.Parse(uf.GetValue(myread, "max")) + 1;
                nouveaufacture = DateTime.Now.Year.ToString() + ident.PadLeft(2, '0') + newfact.ToString().PadLeft(6, '0');
            }
            else
                nouveaufacture = DateTime.Now.Year.ToString() + ident.PadLeft(2, '0') + "000001";
            myread.Close();
            return nouveaufacture;

        }

        

        private void bt_ajout_Click(object sender, EventArgs e)
        {
            ajoutevent();
        }

        private void ajoutevent()
        {
            refclient.ReadOnly = false;
            uf.initcontrol(p_article, "6", codearticle);
            uf.initcontrol(p_facture, "", reffactureentreprise, idclient, identreprise);
            identreprise.Text = refentreprise.Text;
            if (idclient.Text == "")
                idclient.Text = refclient.Text;
            uf.enablecontrol(p_facture, "6", true, "7", false);
            uf.enablecontrol(p_menu, "1", false, "2", true, "3", false);
            for (int i = 0; i < factvaleur.Count; i++)
                factvaleur[i] = "";
            gv_fact.Rows.Clear();
            //if (!ajoutdepuisclient)
            reffacturedeltareal.Text = generernumfacture(refentreprise.Text);
            dateecheance.Value = DateTime.Now.AddDays(int.Parse(nbrecheance.Text));
            etatfact = 2;
            /*if (!ajoutdepuisclient)
                refclient.Focus();
            else*/
                reffactureentreprise.Focus();
        }

        private void rabaisfacturepourcent_Leave(object sender, EventArgs e)
        {
           
        }

        private void tvafacture_TextChanged(object sender, EventArgs e)
        {
            if (tvafacture.Focused)
                calcmontfact();
        }

        int etatart = 0;
        private void calcmontart()
        {
            if (etatart == 0)
                return;
            int nbr = 0;
            montantarticle.Text = "0.00";
            int.TryParse(nbrarticle.Text, out nbr);
            decimal prixunit = 0;
            decimal.TryParse(prixunitaire.Text, out prixunit);
            montantarticle.Text = uf.getFormatCur(prixunit * nbr);

            montantarticlefinal.Text = "0.00";
            decimal rab = 0;
            decimal rabm = 0;
            decimal rabm1 = 0;
            decimal mtt = 0;
            decimal.TryParse(montantarticle.Text, out mtt);

            decimal.TryParse(rabaisarticlepourcent.Text, out rab);
            
            if (rab > 0) //rabais article %
            {
                //rabaisarticlemontant.Text = "0.00";
                rabaisarticlemontant.Text = uf.getFormatCur((mtt * rab / 100).ToString());
            }
            /*else if (rabm > 0 && rab == 0) //rabais montant saisi
            {
                rabaisfacturemontant.Text = uf.getFormatCur((mtt * rab / 100).ToString());
            }*/
            decimal.TryParse(rabaisarticlemontant.Text, out rabm);
            //decimal.TryParse(montanttva.Text, out tvam);
            //decimal.TryParse(rabaisfacturemontant.Text, out rabm1);
            montantarticlefinal.Text = uf.getFormatCur(mtt - rabm);
        }

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
            /*if (rabm > 0 && rab ==0) //rabais %
            {
                rabaisfacturemontant.Text = uf.getFormatCur((mtt * rab / 100).ToString());
            }*/
            //if (tva > 0)
            //{
                montanttva.Text = "0.00";
                montanttva.Text = uf.getFormatCur(((mtt - rabm) * tva / 100).ToString());
            //}
            decimal.TryParse(montanttva.Text, out tvam);
            decimal.TryParse(rabaisfacturemontant.Text, out rabm1);
            montantfacturettc.Text = uf.getFormatCur(((mtt - rabm1) + tvam).ToString());
        }

        private void rabaisfacturepourcent_TextChanged(object sender, EventArgs e)
        {
            if (rabaisfacturepourcent.Focused)
                calcmontfact();
        }

        private void rabaisfacturemontant_TextChanged(object sender, EventArgs e)
        {
            if (rabaisfacturemontant.Focused)
            {
                decimal rab = 0;
                decimal.TryParse(rabaisfacturemontant.Text, out rab);
                if (rab > 0)
                    rabaisfacturepourcent.Text = "0.00";
                calcmontfact();
            }
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            string champ = "";
            string valeur = "";

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

                
            }
            //Enregistrement facture principale
            if (champ != "")
            {
                if (etatfact == 2) //ajout
                    uf.executeSQL(comrealvistamod, "fact_facturation", champ, valeur, etatfact, "");
                else if (etatfact == 1) //modif
                    uf.executeSQL(comrealvistamod, "fact_facturation", champ, valeur, etatfact, "idfacture = " + idfacture.Text);
            }
            
            string reffacturedelta = gv_fact.Rows[0].Cells["g_reffactdeltareal"].FormattedValue.ToString();
            enregistrerligne(reffacturedelta);
            uf.message_info("Enregistrement facture efféctué !");
            uf.enablecontrol(p_facture, "", false);
            etatfact = 0;
            etatart = 0;
            idfacture.Text = "";
            charger(0);
            gv_fact.CurrentCell = gv_fact.Rows[0].Cells[0];
            gv_fact.CurrentRow.Selected = true;
        }

        private void enregistrerligne(string reffacturedelta)
        {
            //parcours ligne details, si idfacture != "", modif, sinon ajout
            string champ = "identreprise, idclient, reffactureentreprise, reffacturedeltareal, numligne, idarticle, prixunitaire, nbr, montantarticle, rabaisarticlemontant, rabaisarticlepourcent, montantarticlefinal";
            string valeur = "";
            for (int i = 1; i < gv_fact.RowCount; i++)
            {
                DataGridViewRow dr = gv_fact.Rows[i];
                valeur = uf.valtexte(identreprise) + "$" + uf.valtexte(idclient) + "$" + dr.Cells["g_reffactentreprise"].FormattedValue.ToString() + "$" +
                    dr.Cells["g_reffactdeltareal"].FormattedValue.ToString() + "$" +
                    i.ToString() + "$" +
                    dr.Cells["g_idarticle"].FormattedValue.ToString() + "$" +
                    dr.Cells["g_prixunitaire"].FormattedValue.ToString() + "$" +
                    dr.Cells["g_nbrarticle"].FormattedValue.ToString() + "$" +
                    dr.Cells["g_montantarticle"].FormattedValue.ToString() + "$" +
                    dr.Cells["g_rabaismontant"].FormattedValue.ToString() + "$" +
                    dr.Cells["g_rabaispourcent"].FormattedValue.ToString() + "$" +
                    dr.Cells["g_montantarticlefinal"].FormattedValue.ToString();
                if (gv_fact.Rows[i].Cells["g_idfacture"].FormattedValue.ToString() == "") //ajout
                {
                    etatart = 2;
                    uf.executeSQL(comrealvistamod, "fact_facturation", champ, valeur, etatart, "");
                }
                else
                {
                    etatart = 1;
                    uf.executeSQL(comrealvistamod, "fact_facturation", champ, valeur, etatart, "idfacture = " + dr.Cells["g_idfacture"].FormattedValue.ToString());
                }
            }
        }

        private void bt_annul_Click(object sender, EventArgs e)
        {
            //if (etatfact == 1)
            //{
                etatfact = 0;
                chargerfacture();
            //}
            //else if (etatfact == 2)
            //    chargerfacture("");
        }

        private void montantfacture_TextChanged(object sender, EventArgs e)
        {
            if (montantfacture.Focused || ck_typesaisie.Checked)
                calcmontfact();
        }

        private bool testdonneesfact()
        {
            Boolean ret = true;
            if (uf.testchampvide(p_facture, idclient) == true && ck_typesaisie.Checked== false)
            {
                
                uf.message_info("Veuillez saisir les données utiles !");
                return false;
            }
            if (idclient.Text == "")
            {
                uf.message_info("Veuillez sélectionner le client !");
                return false;
            }
            decimal tmp = 0;
            decimal.TryParse(montantfacture.Text, out tmp);
            if (tmp == 0 && ck_typesaisie.Checked == false)
            {
                uf.message_info("Veuillez saisir le montant initial de la facture !");
                return false;
            }

            return ret;
        }

        private void validerfacture()
        {
            
            uf.enablecontrol(p_article, "", true);
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

            //calc reste a saisir
            calculeresteasaisir();

            //if (gv_fact.Rows.Count == 1)
            //    ajoutligneart();
            codearticle.Focus();
            
        }

        private void montantfacturettc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                validerfacture();
        }

        private void ajoutligneart()
        {
            if (etatart == 2)
            {
                gv_fact.Rows.Add(1);
                gv_fact.CurrentCell = gv_fact.Rows[gv_fact.Rows.Count - 1].Cells[0];
            }
            else
            {

            }
            /*
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

            //calcul reste à saisir. Si ajout et montant facture atteint donc validation auto.


            if (ck_typesaisie.Checked)
            {
                montantfacture.Text = uf.valtexte(montantarticle);
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
                if (etatart == 2)
                {
                    uf.initcontrol(p_article, "6", codearticle);
                }
                else if (etatart == 1)
                {
                    uf.initcontrol(p_article, "6", codearticle);
                    etatart = 2;
                }
            }
            else
            {
                //si etatfact 2, validation

                bt_valider_Click(bt_valider, new EventArgs());
            }
        }

        private decimal calculeresteasaisir()
        {
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
            lb_resteasaisir.Text = uf.getFormatCur(asaisir - totalsaisi, false);
            return asaisir - totalsaisi;
        }

        private string getclient(string rechid = "0")
        {
            string ret = "";
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
            }
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
            uf.initcontrol(p_article, "6");
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
            nbrarticle.Focus();
        }

        private void codearticle_Leave(object sender, EventArgs e)
        {
            if (codearticle.Text.Trim() != "")
                recherchearticle(codearticle.Text.Trim(), codearticle);

        }

        private void nbrarticle_Leave(object sender, EventArgs e)
        {

        }

        private void nbrarticle_TextChanged(object sender, EventArgs e)
        {
            if (nbrarticle.Focused)
                calcmontart();
        }

        private void rabaisarticlepourcent_TextChanged(object sender, EventArgs e)
        {
            if (rabaisarticlepourcent.Focused)
                calcmontart();
        }

        private void rabaisarticlemontant_TextChanged(object sender, EventArgs e)
        {
            if (rabaisarticlemontant.Focused)
            {
                decimal rab = 0;
                decimal.TryParse(rabaisarticlemontant.Text, out rab);
                if (rab > 0)
                    rabaisarticlepourcent.Text = "0.00";
                calcmontart();
            }
        }

        private void montantarticlefinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                validersaisiearticle();
        }

        private void validersaisiearticle()
        {
            //validation saisie article
            if (uf.testchampvide(p_article) == true)
                return;
            if (uf.testchampzero(nbrarticle, "nbr article") == true)
                return;
            //ajout dans grille facture
            ajoutligneart();
        }

        private void codearticle_TextChanged(object sender, EventArgs e)
        {
            if (codearticle.Enabled && codearticle.Focused)
            {
                idarticle.Text = "";
            }
        }

        private void datecommande_ValueChanged(object sender, EventArgs e)
        {

        }

        private void montantfacture_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                validerfacture();
        }

        private void nbrarticle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                validersaisiearticle();
        }

        private void rabaisfacturepourcent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                validerfacture();
        }

        private void rabaisfacturemontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                validerfacture();
        }

        private void refclient_Leave(object sender, EventArgs e)
        {
            if (etatfact > 0 && refclient.Text != currefclient.Text)
                refclient.Text = currefclient.Text;
            if (etatfact > 0)
                reffactureentreprise.Focus();
        }

        int etatrechcli = 0;
        private void bt_rechclient_Click(object sender, EventArgs e)
        {
            etatrechcli = 1;
            uf.initcontrol(p_client, "", socligne1, currefclient);
            uf.readonlycontrol(p_client, "1", false, "2", false);
            //raisonsociale.ReadOnly = nom.ReadOnly = prenom.ReadOnly = adresse1.ReadOnly = adresse2.ReadOnly = npa.ReadOnly = ville.ReadOnly = false;
        }

        public void chargerclient(string id = "")
        {
            if (id == "")
            {
                uf.initcontrol(p_client, "", socligne1, currefclient);
                uf.readonlycontrol(p_client, "2", true, "1", true);
                return;
            }
            string reqclient = "select cli.idclient as refclient, socligne as raisonsociale, pol.idlangue as idlanguage, lang.language as language, " +
                "cli.idpolitesse as idpolitesse, pol.politesse as politesse, cli.nom, cli.prenom, cli.co, " +
                "cli.adresse1 as adresse1, cli.adresse2 as adresse2, city.zip as npa, city.cityname as ville, " +
                "cli.idville as idville, cli.telpro as telpro, cli.telmob as telmob, " +
                "cli.fax as fax, cli.email as email " +
                "FROM fact_client cli " +
                "LEFT join " + Fmain.baseInit + ".typepolitesse pol ON pol.idpolitesse = cli.idpolitesse LEFT join " + Fmain.baseInit + ".language lang ON lang.idlanguage = pol.idlangue " +
                "left join " + Fmain.baseInit + ".city ON city.idcity = cli.idville where cli.idclient =" + id + " " +
                "ORDER BY nom, prenom, socligne";
            uf.initcontrol(p_client, "", socligne1, currefclient);
            uf.afficherInfo(p_client, reqclient, comrealvistamod, null, "");
            if (refclient.Text.Trim() != "")
            {
                currefclient.Text = refclient.Text;
                if (etatfact > 0)
                    idclient.Text = currefclient.Text;
                uf.readonlycontrol(p_client, "2", true,"1", false );
                reffactureentreprise.Focus();
            }
            else
            {
                //chargerclient(currefclient.Text);
                refclient.Focus();
            }
                
        }

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

        private void raisonsociale_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress(e);
        }

        private void nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress(e);
        }

        private void prenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress(e);
        }

        private void keypress(KeyPressEventArgs e)
        {
            if (etatfact == 0 && etatrechcli == 0)
                return;
            if (e.KeyChar == 13)
                rechercheclient();
            if (e.KeyChar == 27)
                chargerclient(currefclient.Text);
        }

        private void adresse1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress(e);
        }

        private void adresse2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress(e);
        }

        private void npa_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress(e);
        }

        private void ville_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypress(e);
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
            cond = "";
            chargerfacture();
        }

        private void reffactureentreprise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && etatfact == 0)
            {
                recherchefacture();
            }
            else if (e.KeyChar == 13 && etatfact > 0)
                validerfacture();
        }

        private void reffacturedeltareal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && etatfact == 0)
            {
                recherchefacture();
            }
        }

        private void recherchefacture()
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
        }
        List<string> nomcol = new List<string>(1);

        public void importerfacture()
        {
            BindingSource bd = new BindingSource();
            //DataTable dat = new DataTable();
            DataTable dat = Fmain.ImportCSV(@"D:\Boulots\DeltaFact\Commissaires.csv", new string[] { ";" }, true);

            //dat = ImportCSV(@FileDg.FileName, new string[] { ";" }, true);

            bd.DataSource = dat;
            gvins.DataSource = bd;
            gvins.Refresh();


            //définition nom de colonne
            nomcol.Add("politesse;titre;polit");
            nomcol.Add("socligne;socl;soci");
            nomcol.Add("prenom;pren;prén");
            nomcol.Add("nom;nom");
            nomcol.Add("codearticle;article;marchan");
            nomcol.Add("co;co;c/o");
            nomcol.Add("adresse2;adr2;adresse2");
            nomcol.Add("adresse1;adr;adresse");
            nomcol.Add("zip;npa;zip");
            nomcol.Add("cityname;ville;city");

            //nomcol.Add("reffactureentreprise;ref;");
            //nomcol.Add("datecommande;commande");
            //nomcol.Add("datefactureentreprise;date");

           

            //recherche colonne client
            for (int i=0; i< nomcol.Count; i++)
            {
                string[] textearechercher = nomcol[i].Split(';');

                for (int j=0; j< gvins.Columns.Count; j++)
                {
                    bool trouve = false;
                    if (gvins.Columns[j].DefaultCellStyle.BackColor == Color.LightGreen)
                        continue;
                    foreach (string txt in textearechercher)
                    {
                        if (gvins.Columns[j].Name.ToLower().Contains(txt))
                        {
                            gvins.Columns[j].Name = textearechercher[0];
                            gvins.Columns[j].HeaderText = textearechercher[0];
                            gvins.Columns[j].DefaultCellStyle.BackColor = Color.LightGreen;
                            trouve = true;
                        }
                    }
                    if (trouve)
                        break;
                }
            }

            //recherche ref client
            if (gvins.Columns.Contains("idclient") == false)
                gvins.Columns.Add("idclient", "ID Client");

            bool npaok = true;
            //remplir typepolitesse dans list
            string sz = "SELECT politesse";
            for (int i=0; i< gvins.RowCount; i++)
            {
                //Test erreur NPA VILLE
                if (gvins.Columns.Contains("zip"))
                {
                    if (uf.ValeurParCond(comrech, Fmain.baseInit + ".city", "zip, cityname, idcity", "idcity", "zip = " + gvins.Rows[i].Cells["zip"].FormattedValue.ToString() + " AND cityname = \"" + gvins.Rows[i].Cells["cityname"].FormattedValue.ToString() + "\"") == "")
                    {
                        npaok = false;
                        gvins.Rows[i].Cells["zip"].Style.BackColor = Color.Red;
                        gvins.Rows[i].Cells["cityname"].Style.BackColor = Color.Red;
                        //break;
                    }
                }
                else
                {
                    npaok = false;
                    //break;
                }
                gvins.Rows[i].Cells["idclient"].Value = chargerrechercheclient(i);
            }
            
        }

        private string chargerrechercheclient(int ligne)
        {
            string val = "";
            string reqclient = "select cli.idclient as refclient, socligne as raisonsociale, " +
                "cli.idpolitesse as idpolitesse, cli.nom, cli.prenom, cli.co, " +
                "cli.adresse1 as adresse1, cli.adresse2 as adresse2, city.zip as npa, city.cityname as ville, " +
                "cli.idville as idville, cli.telpro as telpro, cli.telmob as telmob, " +
                "cli.fax as fax, cli.email as email " + 
                "FROM fact_client cli " +
                "left join " + Fmain.baseInit + ".city ON city.idcity = cli.idville where ";
            string cond = "";
            string tmp = "";

            for (int i = 0; i < nomcol.Count; i++)
            {
                if (nomcol[i].Contains("politesse") || nomcol[i].Contains("codearticle"))
                    continue;
                string[] textearechercher = nomcol[i].Split(';');
                tmp = testercolonne(textearechercher[0], ligne);
                if (tmp != "")
                {
                    if (cond != "")
                        cond += " AND ";
                    cond += textearechercher[0] + " = \"" + tmp + "\" ";
                }
            }
            comrech.CommandText = reqclient + cond;
            myread = comrech.ExecuteReader();
            if (myread.Read())
            {
                val = uf.GetValue(myread, "refclient");
            }
            myread.Close();
            return val;
        }

        private string testercolonne(string nomcol, int ligne = 0)
        {
            string val = "";
            if (gvins.Columns.Contains(nomcol) == true && gvins.Rows[ligne].Cells[nomcol].FormattedValue.ToString() != "")
                val = gvins.Rows[ligne].Cells[nomcol].FormattedValue.ToString();
            return val;
        }

        private void bt_importerfacture_Click(object sender, EventArgs e)
        {
            gvins.Visible = true;
            importerfacture();

            
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

        private void refentreprise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
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
        }

        private void refentreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void f_gesfact_Shown(object sender, EventArgs e)
        {
            if (ajoutdepuisclient && etatfact > 0)
            {
                
                    reffactureentreprise.Focus();
            }
        }

        private void reffactureentreprise_Click(object sender, EventArgs e)
        {
            reffactureentreprise.Focus();
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
    }
}
