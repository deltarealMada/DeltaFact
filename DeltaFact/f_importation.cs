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
    public partial class f_importation : Form
    {
        public f_importation()
        {
            InitializeComponent();
        }

        util_fact uf = new util_fact();
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);
        MySqlDataReader myread;


        private void bt_importer_Click(object sender, EventArgs e)
        {
                bt_verifaddclient.Enabled = false;
                bt_validerimport.Enabled = false;
            bt_verifier.Enabled = false;
            //gvins.Visible = true;
            importerfacture();
        }


        List<string> nomcol;
        public void importerfacture()
        {
            gvins.DataSource = null;
            nomcol = new List<string>(1);

            BindingSource bd = new BindingSource();
            //DataTable dat = new DataTable();
            if (FileDg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            DataTable dat;
            if (FileDg.FilterIndex == 3) // Filter.Contains("csv"))
            {
                dat = Fmain.ImportCSV(@FileDg.FileName, new string[] { ";" }, true);
            }
            else
            {
                Application.CurrentCulture.TextInfo.ListSeparator = ";";

                Microsoft.Office.Interop.Excel.Application excelApp;
                Microsoft.Office.Interop.Excel.Workbook excelBook;
                Microsoft.Office.Interop.Excel.Worksheet excelSheet;
                Object oMissing = System.Reflection.Missing.Value;
                Object oFalse = false;

                excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelBook = excelApp.Workbooks.Open(@FileDg.FileName, oMissing, oMissing, oMissing);
                excelSheet = excelBook.Worksheets[1];
                Microsoft.Office.Interop.Excel.XlFileFormat ff;
                ff = Microsoft.Office.Interop.Excel.XlFileFormat.xlCSVWindows;
                object sav = false;
                Application.CurrentCulture.TextInfo.ListSeparator = ";";
                Application.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";


                excelApp.UseSystemSeparators = true;
                System.Object omissing = false;
                System.Object otrue = true;
                try
                {
                    System.IO.File.Delete(Application.StartupPath + @"\tmpf.csv");
                }
                catch { }

                excelSheet.SaveAs(Application.StartupPath + @"\tmpf.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlTextWindows, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, otrue);
                //<excelSheet.SaveAs(Application.StartupPath + @"\tmp.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, otrue); 

                excelBook.Close(sav);
                excelApp.Quit();
                /*try
                {
                    dat = Fmain.ImportCSV(Application.StartupPath + @"\tmpf.csv", new string[] { "\t" }, true);
                }
                catch
                {*/
                    dat = Fmain.ImportCSV(Application.StartupPath + @"\tmpf.csv", new string[] { "\t" }, true);

                //}
            }


            bd.DataSource = dat;
            gvins.DataSource = bd;
            gvins.Refresh();


            //définition nom de colonne. premier : champ dans table. Autres : filtre de recherche colonne
            nomcol.Add("politesse;titre;polit");
            nomcol.Add("socligne;socl;soci");
            nomcol.Add("prenom;pren;prén");
            nomcol.Add("nom;nom");
            nomcol.Add("codearticle;code;article;marchan");
            nomcol.Add("libelle_article;libelle;libel;desc");
            nomcol.Add("nbr;nbr;pc;piece;pièce;nombre");
            //nomcol.Add("co;co;c/o");
            nomcol.Add("adresse2;adr2;adresse2");
            nomcol.Add("adresse1;adr;adresse");
            nomcol.Add("zip;npa;zip");
            nomcol.Add("cityname;ville;city");
            nomcol.Add("remarquearticle;remarque");
            nomcol.Add("paye;payé;paiement");
            nomcol.Add("no_commande;bon;no;réf;ref");
            nomcol.Add("date_commande;date");
            nomcol.Add("reffact_entreprise;no;réf;ref");
            nomcol.Add("date_facture;date");

            //nomcol.Add("reffactureentreprise;ref;"); idcity ts adino
            //nomcol.Add("datecommande;commande");
            //nomcol.Add("datefactureentreprise;date");



            //recherche colonne client
            for (int i = 0; i < nomcol.Count; i++)
            {
                string[] textearechercher = nomcol[i].Split(';');

                for (int j = 0; j < gvins.Columns.Count; j++)
                {
                    //if (gvins.Columns[j].DefaultCellStyle.BackColor == Color.LightGreen)
                    //    continue;
                    bool trouve = false;
                    if (gvins.Columns[j].DefaultCellStyle.BackColor == Color.LightGreen)
                        continue;
                    foreach (string txt in textearechercher)
                    {
                        if (gvins.Columns[j].Name.ToLower().Contains(txt))
                        {
                            if ((txt == "co" || txt == "c/o") && (gvins.Columns[j].Name.ToLower() == "co" || gvins.Columns[j].Name.ToLower() == "c/o"))
                            {
                                gvins.Columns[j].Name = textearechercher[0];
                                gvins.Columns[j].HeaderText = textearechercher[0];
                                gvins.Columns[j].DefaultCellStyle.BackColor = Color.LightGreen;
                                trouve = true;
                                break;
                            }
                            else if (txt == "no" || txt == "bon" || txt == "réf" || txt == "ref")
                            {
                                if (gvins.Columns[j].Name.ToLower().Contains("commande") || gvins.Columns[j].Name.ToLower().Contains("bon")) //no commande
                                {
                                    gvins.Columns[j].Name = textearechercher[0];
                                    gvins.Columns[j].HeaderText = textearechercher[0];
                                    gvins.Columns[j].DefaultCellStyle.BackColor = Color.LightGreen;
                                    trouve = true;
                                    break;
                                }
                                else if (gvins.Columns[j].Name.ToLower().Contains("facture")) //no facture
                                {
                                    gvins.Columns[j].Name = textearechercher[0];
                                    gvins.Columns[j].HeaderText = textearechercher[0];
                                    gvins.Columns[j].DefaultCellStyle.BackColor = Color.LightGreen;
                                    trouve = true;
                                    break;
                                }


                            }
                            else if (txt == "date")
                            {
                                if (gvins.Columns[j].Name.ToLower().Contains("commande") || gvins.Columns[j].Name.ToLower().Contains("bon")) //no commande
                                {
                                    gvins.Columns[j].Name = textearechercher[0];
                                    gvins.Columns[j].HeaderText = textearechercher[0];
                                    gvins.Columns[j].DefaultCellStyle.BackColor = Color.LightGreen;
                                    trouve = true;
                                    break;
                                }
                                else if (gvins.Columns[j].Name.ToLower().Contains("facture")) //no facture
                                {
                                    gvins.Columns[j].Name = textearechercher[0];
                                    gvins.Columns[j].HeaderText = textearechercher[0];
                                    gvins.Columns[j].DefaultCellStyle.BackColor = Color.LightGreen;
                                    trouve = true;
                                    break;
                                }


                            }
                            gvins.Columns[j].Name = textearechercher[0];
                            gvins.Columns[j].HeaderText = textearechercher[0];
                            gvins.Columns[j].DefaultCellStyle.BackColor = Color.LightGreen;
                            trouve = true;
                            break;
                        }
                    }
                    if (trouve)
                    {
                        if (textearechercher[0] == "politesse")
                            AjoutColCombo("politesse", Fmain.baseInit + ".typepolitesse", "politesse", "idpolitesse");
                        break;
                    }
                }
            }

            //recherche ref client
            if (gvins.Columns.Contains("idclient") == false)
                gvins.Columns.Add("idclient", "ID Client");
            if (gvins.Columns.Contains("idcity") == false)
                gvins.Columns.Add("idcity", "ID Ville");
            if(gvins.Columns.Contains("idarticle") == false)
                gvins.Columns.Add("idarticle", "idarticle");
            gvins.Columns["idclient"].DisplayIndex = 0;

            bool colobli = true;
            if (!gvins.Columns.Contains("socligne") && !gvins.Columns.Contains("nom"))
            {
                uf.message_info("Les données doivent contenir au moins la colonne 'raison sociale' ou 'nom' !");
                colobli = false;
            }
            if (!gvins.Columns.Contains("zip") || !gvins.Columns.Contains("cityname"))
            {
                uf.message_info("Les données doivent contenir les colonne 'NPA' et 'Ville' !");
                colobli = false;
            }
            if (!gvins.Columns.Contains("codearticle"))
            {
                uf.message_info("Les données doivent contenir la colonne 'code article' !");
                colobli = false;
            }
            if (!gvins.Columns.Contains("nbr"))
            {
                uf.message_info("Les données doivent contenir la colonne 'nbr article' !");
                colobli = false;
            }
            if (colobli)
            {
                bt_verifier.Enabled = true;
                bt_verifier_Click(bt_verifier, new EventArgs());
            }
        }

        private bool AjoutColCombo(string nomCol, string table, string nomChamp, string nomChampResult)
        {
            bool ret = false;
            if (gvins.Columns.Contains(nomCol))
            {
                if (gvins.Columns[nomCol].CellType != typeof(DataGridViewComboBoxCell))
                {
                    DataGridViewComboBoxColumn cmbPol = new DataGridViewComboBoxColumn();
                    cmbPol.Name = nomCol + "tmp";
                    cmbPol.HeaderText = gvins.Columns[nomCol].HeaderText;
                    cmbPol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    cmbPol.DisplayMember = nomChamp;
                    cmbPol.ValueMember = nomChampResult;
                    //cmbPol.DefaultCellStyle.NullValue = "#ERROR#";
                    cmbPol.HeaderCell.Style = gvins.Columns[nomCol].HeaderCell.Style;
                    cmbPol.DefaultCellStyle.BackColor = gvins.Columns[nomCol].DefaultCellStyle.BackColor;
                    uf.RemplirCombo(cmbPol, "SELECT " + nomChampResult + ", " + nomChamp + " FROM " + table + " ORDER By " + nomChampResult, comrech, mySqlDataAdapter1);
                    gvins.Columns.Insert(gvins.Columns[nomCol].Index, cmbPol);
                    //gvins.Columns.Add(cmbPol);
                    //gvins.Columns.Remove(nomCol);
                    //gvins.Columns[cmbPol.Name].Name = nomCol;
                    ret = true;
                }
            }
            return ret;
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
                if (nomcol[i].Contains("politesse") || nomcol[i].Contains("codearticle") || nomcol[i].Contains("reffact_entreprise") || nomcol[i].Contains("libelle_article") || nomcol[i].Contains("commande") || nomcol[i].Contains("remarque") || nomcol[i].Contains("nbr") || nomcol[i].Contains("paye"))
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

        private bool TestBase(string nomCol, string table, string nomChamp, string nomChampResult, int j)
        {
            bool ret = true;
            if (gvins.Columns.Contains(nomCol))
            {
                string tmp = "-1";
                string anc = "";
                if (gvins.Columns.Contains(nomCol + "tmp"))
                {
                    if (gvins.Rows[j].Cells[nomCol].Value != null && gvins.Rows[j].Cells[nomCol].Value.ToString().Trim() != "")
                    {
                        tmp = uf.IndexParValeur(comrech, table, nomChamp, nomChampResult, gvins.Rows[j].Cells[nomCol].Value.ToString());
                        anc = gvins.Rows[j].Cells[nomCol].Value.ToString();
                    }
                    if (gvins.Rows[j].Cells[nomCol].Value == null || tmp == "-1")
                    {
                        gvins.Rows[j].Cells[nomCol + "tmp"].Style.BackColor = Color.Red;
                        gvins.Rows[j].Cells[nomCol + "tmp"].ToolTipText = "Valeur inittttt. : " + anc;
                        ret = false;
                    }
                    else
                    {
                        ((DataGridViewComboBoxCell)gvins.Rows[j].Cells[nomCol + "tmp"]).Value = Int32.Parse(tmp);
                        gvins.Rows[j].Cells[nomCol + "tmp"].Style.BackColor = gvins.Columns[nomCol].DefaultCellStyle.BackColor;
                    }
                }
                else
                {
                    if (gvins.Rows[j].Cells[nomCol].Value != null)
                        gvins.Rows[j].Cells[nomCol].Style.BackColor = gvins.Columns[nomCol].DefaultCellStyle.BackColor;
                    else
                    {
                        gvins.Rows[j].Cells[nomCol].Style.BackColor = Color.Red;
                        ret = false;
                    }
                }

            }
            return ret;
        }

        private void bt_verifier_Click(object sender, EventArgs e)
        {
            bt_errsuiv.Enabled = false;
            comboMi1.Visible = false;
            comboMi1.drom.Visible = false;
            comboMi2.Visible = false;
            comboMi2.drom.Visible = false;
            bt_verifaddclient.Enabled = false;
                bt_validerimport.Enabled = false;
            bool npaok = true;
            bool DonneOk = true;
            string sz = "SELECT politesse";
            for (int i = 0; i < gvins.RowCount; i++)
            {
                //mettre à jour polistesse.
                if (!TestBase("politesse", Fmain.baseInit + ".typepolitesse", "politesse", "idpolitesse", i))
                    DonneOk = false;
                
                //Test erreur NPA VILLE
                //npaok = false;
                if (gvins.Columns.Contains("zip"))
                {
                    string val = uf.ValeurParCond(comrech, Fmain.baseInit + ".city", "zip, cityname, idcity", "idcity", "zip = '" + gvins.Rows[i].Cells["zip"].FormattedValue.ToString() + "' AND cityname = \"" + gvins.Rows[i].Cells["cityname"].FormattedValue.ToString() + "\"");
                    if (val == "")
                    {
                        npaok = false;
                        gvins.Rows[i].Cells["idcity"].Value = "";
                        gvins.Rows[i].Cells["zip"].Style.BackColor = Color.Red;
                        gvins.Rows[i].Cells["cityname"].Style.BackColor = Color.Red;
                        //break;
                    }
                    else
                    {
                        //npaok = true;
                        gvins.Rows[i].Cells["idcity"].Value = val;
                        gvins.Rows[i].Cells["zip"].Style.BackColor = gvins.Columns["zip"].DefaultCellStyle.BackColor;
                        gvins.Rows[i].Cells["cityname"].Style.BackColor = gvins.Columns["zip"].DefaultCellStyle.BackColor;
                    }
                }
                else
                {
                    npaok = false;
                    //break;
                }
                gvins.CurrentCell = gvins.Rows[i].Cells["idclient"];
                //TEST Code article
                if (gvins.Columns.Contains("codearticle"))
                {
                    string idart = uf.IndexParValeur(comrech, "fact_articles", "codearticle", "idarticle", gvins.Rows[i].Cells["codearticle"].Value.ToString());
                    if (idart == "-1")
                    {
                        DonneOk = false;
                        gvins.Rows[i].Cells["codearticle"].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        gvins.Rows[i].Cells["idarticle"].Value = idart;
                        gvins.Rows[i].Cells["codearticle"].Style.BackColor = gvins.Columns["codearticle"].DefaultCellStyle.BackColor;

                    }
                }
                //TEST montant payé si colonne existe
                if (gvins.Columns.Contains("paye"))
                {
                    if (!TestDecimales("paye", i))
                        DonneOk = false;
                }
                if (gvins.Columns.Contains("nbr"))
                {
                    int nbra = 0;
                    int.TryParse(GetDonnee("nbr"), out nbra);
                    if (nbra == 0)
                    {
                        gvins.Rows[i].Cells["nbr"].Value = "0";
                        gvins.Rows[i].Cells["nbr"].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        gvins.Rows[i].Cells["nbr"].Style.BackColor = gvins.Columns["nbr"].DefaultCellStyle.BackColor;
                    }
                }
                //recherche client. Si npa OK, ET socligne existe ou nom+adresse1
                if (npaok && ((GetDonnee("socligne") != "") || (GetDonnee("nom") != "" && GetDonnee("adresse1") != "")))
                gvins.Rows[i].Cells["idclient"].Value = chargerrechercheclient(i);
            }
            if (gvins.Columns.Contains("politessetmp"))
            {
                gvins.Columns.Remove("politesse");
                gvins.Columns["politessetmp"].Name = "politesse";
            }
            if (DonneOk && npaok)
            {
                bt_verifaddclient.Enabled = true;
                bt_verifier.Enabled = false;
                bt_verifaddclient_Click(bt_verifaddclient, new EventArgs());
            }
            else
            {
                bt_errsuiv.Enabled = true;
            }
        }

        private bool TestDecimales(string nomCol, int j)
        {
            bool ret = true;
            if (gvins.Columns.Contains(nomCol))
            {
                string dd = "";
                float tmp = 0;
                dd = gvins.Rows[j].Cells[nomCol].Value.ToString().Replace("\"", "").Replace(" ", "").Replace("'", ""); // CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
                if (dd.Contains(",") && dd.Contains("."))
                {
                    //1,234.45
                    int pos1 = dd.IndexOf(",");
                    int pos2 = dd.IndexOf(".");
                    if (pos1 < pos2)
                    {
                        dd = dd.Replace(",", "");
                    }
                    else
                        dd = dd.Replace(".", "");
                }
                gvins.Rows[j].Cells[nomCol].Value = dd;

                //dd = dd.Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
                try
                {
                    tmp = float.Parse(dd);
                    gvins.Rows[j].Cells[nomCol].Value = string.Format("{0:N2}", tmp);
                    gvins.Rows[j].Cells[nomCol].Style.BackColor = gvins.Columns[nomCol].DefaultCellStyle.BackColor;
                }
                catch
                {
                    try
                    {
                        if (dd.Contains(","))
                            tmp = float.Parse(dd.Replace(",", "."));
                        else if (dd.Contains("."))
                            tmp = float.Parse(dd.Replace(".", ","));
                        gvins.Rows[j].Cells[nomCol].Value = string.Format("{0:N2}", tmp);
                        gvins.Rows[j].Cells[nomCol].Style.BackColor = gvins.Columns[nomCol].DefaultCellStyle.BackColor;
                    }
                    catch
                    {
                        gvins.Rows[j].Cells[nomCol].Style.BackColor = Color.Red;
                        //gvins.Rows[j].Cells[nomCol].ToolTipText = "Valeur initiale :" + gvins.Rows[j].Cells[nomCol].Value;
                        //gvins.Rows[j].Cells[nomCol].Value = "";
                        ret = false;
                    }
                }

            }
            return ret;
        }

        string valcell = "";
        private void gvins_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            valcell = "";
            valcell = gvins.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
            bt_verifier.Enabled = true;
        }

        private void gvins_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvins.Columns["zip"].Index || e.ColumnIndex == gvins.Columns["cityname"].Index) //si zip ou city modifié
            {
                string tmp = "";
                //if (gvins.Columns[e.ColumnIndex].Name == "zip")
                //{
                tmp = uf.ValeurParCond(comrech, Fmain.baseInit + ".city", "zip, cityname, idcity", "idcity", "zip = " + gvins.Rows[e.RowIndex].Cells["zip"].FormattedValue.ToString() + " AND cityname = \"" + gvins.Rows[e.RowIndex].Cells["cityname"].FormattedValue.ToString() + "\"");
                if (tmp == "")
                {
                    gvins.Rows[e.RowIndex].Cells["idcity"].Value = "";
                    gvins.Rows[e.RowIndex].Cells["zip"].Style.BackColor = Color.Red;
                    gvins.Rows[e.RowIndex].Cells["cityname"].Style.BackColor = Color.Red;
                }
                else
                {
                    gvins.Rows[e.RowIndex].Cells["idcity"].Value = tmp;
                    gvins.Rows[e.RowIndex].Cells["zip"].Style.BackColor = gvins.Columns["zip"].DefaultCellStyle.BackColor;
                    gvins.Rows[e.RowIndex].Cells["cityname"].Style.BackColor = gvins.Columns["cityname"].DefaultCellStyle.BackColor;
                }
                //}
            }
            else if (gvins.Columns.Contains("codearticle") && e.ColumnIndex == gvins.Columns["codearticle"].Index) //si cdearticle
            {
                string tmp = "";
                //if (gvins.Columns[e.ColumnIndex].Name == "zip")
                //{
                string idart = uf.IndexParValeur(comrech, "fact_articles", "codearticle", "idarticle", gvins.CurrentRow.Cells["codearticle"].Value.ToString());
                if (idart == "-1")
                {
                    gvins.CurrentRow.Cells["codearticle"].Style.BackColor = Color.Red;
                }
                else
                {
                    gvins.CurrentRow.Cells["idarticle"].Value = idart;
                    gvins.CurrentRow.Cells["codearticle"].Style.BackColor = gvins.Columns["codearticle"].DefaultCellStyle.BackColor;

                }
                
            }
            else if (gvins.Columns.Contains("nbr") && e.ColumnIndex == gvins.Columns["nbr"].Index)
            {
                int nbra = 0;
                int.TryParse(GetDonnee("nbr"), out nbra);
                if (nbra == 0)
                {
                    gvins.CurrentRow.Cells["nbr"].Value = "0";
                    gvins.CurrentRow.Cells["nbr"].Style.BackColor = Color.Red;
                }
                else
                {
                    gvins.CurrentRow.Cells["nbr"].Style.BackColor = gvins.Columns["nbr"].DefaultCellStyle.BackColor;
                }
            }

            if ((gvins.Columns.Contains("socligne") && e.ColumnIndex == gvins.Columns["socligne"].Index) || 
                (gvins.Columns.Contains("nom") && e.ColumnIndex == gvins.Columns["nom"].Index) ||
                (gvins.Columns.Contains("prenom") && e.ColumnIndex == gvins.Columns["prenom"].Index) ||
                (gvins.Columns.Contains("adresse1") && e.ColumnIndex == gvins.Columns["adresse1"].Index) ||
                (gvins.Columns.Contains("adresse2") && e.ColumnIndex == gvins.Columns["adresse2"].Index) ||
                (gvins.Columns.Contains("zip") && e.ColumnIndex == gvins.Columns["zip"].Index) ||
                (gvins.Columns.Contains("cityname") && e.ColumnIndex == gvins.Columns["cityname"].Index))
            {
                if (gvins.Columns.Contains("idclient"))
                    gvins.CurrentRow.Cells["idclient"].Value = "";
            }
           bt_verifaddclient.Enabled = bt_validerimport.Enabled = false;
            
        }

        public string GetDonnee(string nomCol)
        {
            string ret = "";

            if (gvins.Columns.Contains(nomCol) && gvins.CurrentRow.Cells[nomCol].Value != null)
            {
                if (gvins.Columns[nomCol].GetType() == typeof(DataGridViewComboBoxColumn))
                    ret = (gvins.CurrentRow.Cells[nomCol] as DataGridViewComboBoxCell).Value.ToString().Replace("\"", "");
                else
                    ret = gvins.CurrentRow.Cells[nomCol].FormattedValue.ToString().Replace("\"", "");
            }
            return ret;

        }

        private void bt_verifaddclient_Click(object sender, EventArgs e)
        {
            f_debiteur fdeb ;

            if (Application.OpenForms["f_debiteur"] == null)
            {
                fdeb = new f_debiteur();

                fdeb.comrealvista.Connection = comrealvistamod.Connection;
                fdeb.comrealvistamod.Connection = comrech.Connection;
                
            }
            else
                fdeb = (f_debiteur)(Application.OpenForms["f_debiteur"]);

            
            bool needAjout = false;

            for (int i = 0; i < gvins.RowCount; i++)
            {
                gvins.CurrentCell = gvins.Rows[i].Cells["idclient"];
                if (gvins.Rows[i].Cells["idclient"].FormattedValue.ToString().Trim() == "")
                {
                    //gvins.Rows[rw].Cells["iddebiteur"].Selected = true;
                    needAjout = true;
                    //AfficherDonneesAjout();
                    break;

                }
            }
            DialogResult dgr;
            if (needAjout)
            {
                fdeb.etatajoutimport = 1;
                dgr = fdeb.ShowDialog();
                if (dgr == DialogResult.Cancel)
                    bt_verifaddclient.Enabled = true;
            }
            else
            {
                bt_verifaddclient.Enabled = false;
                bt_validerimport.Enabled = true;
            }

            /*
            /////////
            for (int i = 0; i < gvins.RowCount; i++)
            {
                if (gvins.Rows[i].Cells["idclient"].FormattedValue.ToString() == "")
                {
                    string val = "";
                    if (gvins.Columns.Contains("socligne") && gvins.Rows[i].Cells["socligne"].FormattedValue.ToString() != "")
                        val = uf.ValeurParCond(comrech, "fact_client", "socligne,nom, prenom, idville", "idclient", "socligne = \"" + gvins.Rows[i].Cells["socligne"].FormattedValue.ToString() +"\" AND idville = " + gvins.Rows[i].Cells["idcity"].FormattedValue.ToString());
                    else
                        val = uf.ValeurParCond(comrech, "fact_client", "socligne,nom, prenom, idville", "idclient", "nom = \"" + gvins.Rows[i].Cells["nom"].FormattedValue.ToString() + "\" AND prenom = \"" + gvins.Rows[i].Cells["prenom"].FormattedValue.ToString() + "\" AND idville = " + gvins.Rows[i].Cells["idcity"].FormattedValue.ToString());

                    if (val == "")
                    {
                        //ajout
                        
                        fdeb.etat = 2;
                        fdeb.modifajout();
                        if (gvins.Columns.Contains("socligne"))
                            fdeb.raisonsociale.Text = gvins.Rows[i].Cells["socligne"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("politesse"))
                            fdeb.politesse.Text = gvins.Rows[i].Cells["politesse"].FormattedValue.ToString();
                        fdeb.nom.Text = gvins.Rows[i].Cells["nom"].FormattedValue.ToString();
                        fdeb.prenom.Text = gvins.Rows[i].Cells["prenom"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("co"))
                            fdeb.co.Text = gvins.Rows[i].Cells["co"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("adresse1"))
                            fdeb.adresse1.Text = gvins.Rows[i].Cells["adresse1"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("adresse2"))
                            fdeb.adresse2.Text = gvins.Rows[i].Cells["adresse2"].FormattedValue.ToString();
                        fdeb.npa.textBox1.Text = gvins.Rows[i].Cells["zip"].FormattedValue.ToString();
                        fdeb.ville.textBox1.Text = gvins.Rows[i].Cells["cityname"].FormattedValue.ToString();
                        fdeb.npa.IndCombo = gvins.Rows[i].Cells["idcity"].FormattedValue.ToString();
                        fdeb.ville.IndCombo = gvins.Rows[i].Cells["idcity"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("telmob"))
                            fdeb.telmob.Text = gvins.Rows[i].Cells["telmob"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("telpro"))
                            fdeb.telpro.Text = gvins.Rows[i].Cells["telpro"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("fax"))
                            fdeb.fax.Text = gvins.Rows[i].Cells["fax"].FormattedValue.ToString();
                        if (gvins.Columns.Contains("emai"))
                            fdeb.email.Text = gvins.Rows[i].Cells["email"].FormattedValue.ToString();
                        fdeb.ShowDialog();
                    }
                    else
                    {
                        //recherche
                        fdeb.Show();
                        fdeb.bt_recherche.Text = "recherche";
                        fdeb.bt_recherche_Click(fdeb.bt_recherche, new EventArgs());
                        fdeb.raisonsociale.Text = gvins.Rows[i].Cells["socligne"].FormattedValue.ToString();
                        fdeb.politesse.Text = gvins.Rows[i].Cells["politesse"].FormattedValue.ToString();
                        fdeb.nom.Text = gvins.Rows[i].Cells["nom"].FormattedValue.ToString();
                        fdeb.prenom.Text = gvins.Rows[i].Cells["prenom"].FormattedValue.ToString();
                        fdeb.co.Text = gvins.Rows[i].Cells["co"].FormattedValue.ToString();
                        fdeb.adresse1.Text = gvins.Rows[i].Cells["adresse1"].FormattedValue.ToString();
                        fdeb.adresse2.Text = gvins.Rows[i].Cells["adresse2"].FormattedValue.ToString();
                        fdeb.npa.textBox1.Text = gvins.Rows[i].Cells["zip"].FormattedValue.ToString();
                        fdeb.ville.textBox1.Text = gvins.Rows[i].Cells["cityname"].FormattedValue.ToString();
                        fdeb.npa.IndCombo = gvins.Rows[i].Cells["idcity"].FormattedValue.ToString();
                        fdeb.ville.IndCombo = gvins.Rows[i].Cells["idcity"].FormattedValue.ToString();
                        fdeb.telmob.Text = gvins.Rows[i].Cells["telmob"].FormattedValue.ToString();
                        fdeb.telpro.Text = gvins.Rows[i].Cells["telpro"].FormattedValue.ToString();
                        fdeb.fax.Text = gvins.Rows[i].Cells["fax"].FormattedValue.ToString();
                        fdeb.email.Text = gvins.Rows[i].Cells["email"].FormattedValue.ToString();
                        fdeb.bt_recherche_Click(fdeb.bt_recherche, new EventArgs());
                    }
                }
            }*/
        }

        private void gvins_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvins.Columns.Contains("codearticle") && e.ColumnIndex == gvins.Columns["codearticle"].Index)
            {
                f_marchandises ff = new f_marchandises();
                ff.comrealvista.Connection = comrealvistamod.Connection;
                if (ff.ShowDialog() == DialogResult.OK)
                {
                    gvins.CurrentRow.Cells["codearticle"].Value = ff.selart;
                    gvins.CurrentRow.Cells["idarticle"].Value = ff.selidart; 

                    gvins.CurrentCell.Style.BackColor = gvins.Columns["zip"].DefaultCellStyle.BackColor;
                    gvins.EndEdit(DataGridViewDataErrorContexts.CurrentCellChange);// UpdateCellValue(e.ColumnIndex, e.RowIndex);
                }
            }
        }

        private void bt_validerimport_Click(object sender, EventArgs e)
        {
            string champ = "identreprise, reffactureentreprise,reffacturedeltareal, idclient,montantapayer, datefactureentreprise, datefacturedeltareal, datecommande, nocommande," +
                "rabaisfacturemontant, rabaisfacturepourcent, nbrmens, tauxtva, fraisenvoi, interets, fraisassurance, fraisrappel, numligne, " +
                //"rabaisfacturemontant, rabaisfacturepourcent, nbrmens, tauxtva, fraisenvoi, interets, fraisassurance, fraisrappel, numligne, " +
                "idarticle, idprix, remarquearticle, nbr, idrabais";

            
            decimal drabaisfactm = 0;
            decimal drabaisfactp = 0;
            string srabaisfactm = uf.getFormatCur(drabaisfactm);
            string srabaisfactp = uf.getFormatCur(drabaisfactp);
            string stva = uf.getFormatCur(Fmain.dtvachf);

            for (int i = 0; i< gvins.RowCount; i++)
            {
                gvins.CurrentCell = gvins.Rows[i].Cells["idclient"];
                int itypefact = 0; //1 si colonne payé existe
                if (gvins.Columns.Contains("paye") && GetDonnee("paye") != "0.00")
                {
                    itypefact = 1;
                }
                string daty = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                string datyech = string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(Fmain.iecheance));
                string datycom = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                if (GetDonnee("date_commande") != "")
                    datycom = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GetDonnee("date_commande")));

                DateTime datyfact = DateTime.Now;
                string s = "select article.idarticle, prix.idprix, prix.prix, rabais.idrabais, rabais.rabaismontant, rabais.rabaispourcent FROM fact_articles article " +
                    "INNER JOIN (select idprix, idarticleprix, prix, dateprix from fact_prix group by idarticleprix, idprix order by dateprix desc) prix on prix.idarticleprix = article.idarticle and prix.dateprix <= '" + string.Format("{0:yyyy-MM-dd}", datyfact) + "' " +
                    "LEFT JOIN (Select idrabais, idarticlerabais, rabaismontant, rabaispourcent, daterabaisde, daterabaisa FROM fact_rabais group by idarticlerabais, idrabais order by daterabaisa desc) rabais ON rabais.idarticlerabais = article.idarticle AND '" + string.Format("{0:yyyy-MM-dd}", datyfact) + "' between rabais.daterabaisde and rabais.daterabaisa " +
                    "WHERE article.idarticle =" + GetDonnee("idarticle");
                comrech.CommandText = s;
                myread = comrech.ExecuteReader();
                string idpri = "";
                string idrab = "0";
                decimal pri = 0;
                decimal rabp = 0;
                decimal rabm = 0;
                decimal pritot = 0;
                decimal montt = 0;
                int nbrart = 1;
                string idart = "";
                if (myread.Read())
                {
                    idpri = uf.GetValue(myread, "idprix");
                    decimal.TryParse(uf.GetValueNonRound(myread, "prix"), out pri);

                    decimal.TryParse(uf.GetValueNonRound(myread, "rabaispourcent"), out rabp);
                    decimal.TryParse(uf.GetValueNonRound(myread, "rabaismontant"), out rabm);
                    if (rabp > 0 || rabm > 0)
                        idrab = uf.GetValue(myread, "idrabais");
                    pritot = pri;
                    if (rabp > 0)
                        pritot = (pri - (pri * rabp / 100));
                    else if (rabm > 0)
                        pritot = (pri - (rabm));
                    //pritot = pritot + (pritot * Fmain.dtvachf / 100);
                    int.TryParse(GetDonnee("nbr"), out nbrart);
                    montt = (nbrart * pritot) + ((nbrart * pritot) * Fmain.dtvachf / 100);
                }
                myread.Close();
                string valeur = Fmain.identreprisesel + "$" + GetDonnee("reffact_entreprise") + "$" + Fmain.generernumfacture(Fmain.identreprisesel) + "$" + GetDonnee("idclient") +
                    "$" + uf.getFormatCur(montt, false) + "$" + daty + "$" + daty + "$" + datycom + "$" + GetDonnee("no_commande") + "$" + srabaisfactm + "$" + srabaisfactp + "$" + "0" + "$" + Fmain.dtvachf + "$" + "0" + "$" + "0" + "$" + "0" + "$" + "0" + "$" + "1" + "$" +
                    GetDonnee("idarticle") + "$" + idpri + "$" + GetDonnee("remarquearticle") + "$" + GetDonnee("nbr") + "$" + idrab;

                uf.executeSQL(comrealvistamod, "fact_facturation", champ, valeur, 2, "");

            }
            uf.message_info("Importation avec succès !");
            this.DialogResult = DialogResult.OK;
            
        }

        private void definircol(string nomc)
        {
            if (gvins.Columns.Contains(nomc))
            {
                gvins.Columns[nomc].DefaultCellStyle.BackColor = Color.LightGray;
                gvins.Columns[nomc].Name = "tmp_" + gvins.Columns[nomc].Name;
            }
            gvins.CurrentCell.OwningColumn.Name = nomc;
            gvins.Columns[nomc].DefaultCellStyle.BackColor = Color.LightGreen;

        }

        private void f_importation_Load(object sender, EventArgs e)
        {

            foreach (ToolStripMenuItem f in définirLaColonnea.DropDownItems)
                f.Click += delegate { definircol(f.ToolTipText); };
            string szSQL = "select idcity, zip, cityname from " + Fmain.baseInit + ".city order by zip, cityname";
            comrech.CommandText = szSQL;
            myread = comrech.ExecuteReader();

            #region Modif sur ComboMi par rapport à grille
            while (myread.Read())
            {
                comboMi1.charger(myread.GetValue(myread.GetOrdinal("zip")).ToString(),
                    myread.GetValue(myread.GetOrdinal("cityname")).ToString(),
                    myread.GetValue(myread.GetOrdinal("idcity")).ToString());

            }
            myread.Close();

            szSQL = "select idcity, zip, cityname from " + Fmain.baseInit +".city order by cityname, zip";
            comrech.CommandText = szSQL;
            myread = comrech.ExecuteReader();


            while (myread.Read())
            {

                comboMi2.charger(myread.GetValue(myread.GetOrdinal("cityname")).ToString(),
                    myread.GetValue(myread.GetOrdinal("zip")).ToString(),
                    myread.GetValue(myread.GetOrdinal("idcity")).ToString());
            }
            myread.Close();

            comboMi1.drom.dataGridView1.CellClick += delegate
            {
                gvins.BeginEdit(true);


                gvins.CurrentCell.Value = comboMi1.textBox1.Text;
                //MessageBox.Show(comboMi1.textBox1.Text);
                gvins.UpdateCellValue(gvins.CurrentCell.ColumnIndex, gvins.CurrentCell.RowIndex);
                gvins.CurrentRow.Cells["cityname"].Value = comboMi1.drom.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboMi1.Visible = false;
                gvins.EndEdit();
                if (gvins.CurrentRow.Index == gvins.RowCount - 1)
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["zip"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["zip"];
                }
                else
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["zip"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["zip"];
                }
                /*
                gvins.BeginEdit(true);

                if (gvins.CurrentCell.OwningColumn.Name == "npa")
                {
                    comboMi1.textBox1.Text = comboMi1.drom.dataGridView1.CurrentRow.Cells["col1"].Value.ToString();
                    gvins.CurrentRow.Cells["ville"].Value = comboMi1.drom.dataGridView1.CurrentRow.Cells["col2"].Value.ToString();
                    gvins.UpdateCellValue(gvins.CurrentRow.Cells["ville"].ColumnIndex, gvins.CurrentCell.RowIndex);
                }
                if (gvins.CurrentCell.OwningColumn.Name == "ville")
                {
                    comboMi1.textBox1.Text = comboMi1.drom.dataGridView1.CurrentRow.Cells["col2"].Value.ToString();
                    gvins.CurrentRow.Cells["npa"].Value = comboMi1.drom.dataGridView1.CurrentRow.Cells["col1"].Value.ToString();
                    gvins.UpdateCellValue(gvins.CurrentRow.Cells["npa"].ColumnIndex, gvins.CurrentCell.RowIndex);
                }
                gvins.CurrentCell.Value = comboMi1.textBox1.Text;
                //MessageBox.Show(comboMi1.textBox1.Text);
                gvins.UpdateCellValue(gvins.CurrentCell.ColumnIndex, gvins.CurrentCell.RowIndex);

                if (gvins.CurrentCell.OwningColumn.Name == "npa")
                {
                    gvins.CurrentCell = gvins.CurrentRow.Cells["ville"];
                    gvins_CellClick(gvins, new DataGridViewCellEventArgs(gvins.CurrentRow.Cells["npa"].ColumnIndex, gvins.CurrentRow.Index));
                    gvins.CurrentCell = gvins.CurrentRow.Cells["npa"];
                }
                else if (gvins.CurrentCell.OwningColumn.Name == "ville")
                {
                    gvins.CurrentCell = gvins.CurrentRow.Cells["npa"];
                    gvins_CellClick(gvins, new DataGridViewCellEventArgs(gvins.CurrentRow.Cells["ville"].ColumnIndex, gvins.CurrentRow.Index));
                    gvins.CurrentCell = gvins.CurrentRow.Cells["ville"];
                }
                gvins.EndEdit();*/

            };
            comboMi1.bt1.Click += delegate
            {
                if (comboMi1.drom.Visible == true && comboMi1.drom.Etat == false)
                {

                    return;
                }
                if (comboMi1.drom.Visible == false && comboMi1.drom.Etat == false)
                {

                    return;
                }
                gvins.CurrentCell.Value = comboMi1.textBox1.Text;
                gvins.CurrentRow.Cells["cityname"].Value = comboMi1.drom.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (gvins.CurrentRow.Index == gvins.RowCount - 1)
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["zip"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["zip"];
                }
                else
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["zip"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["zip"];
                }
                /*if (gvins.CurrentCell.OwningColumn.Name == "npa")
                {
                    gvins.CurrentRow.Cells["ville"].Value = comboMi1.drom.dataGridView1.CurrentRow.Cells["col2"].Value.ToString();

                }
                else if (gvins.CurrentCell.OwningColumn.Name == "ville")
                {
                    gvins.CurrentRow.Cells["npa"].Value = comboMi1.drom.dataGridView1.CurrentRow.Cells["col1"].Value.ToString();
                }*/
            };

            comboMi2.drom.dataGridView1.CellClick += delegate
            {


                gvins.BeginEdit(true);


                gvins.CurrentCell.Value = comboMi2.textBox1.Text;
                //MessageBox.Show(comboMi1.textBox1.Text);
                gvins.UpdateCellValue(gvins.CurrentCell.ColumnIndex, gvins.CurrentCell.RowIndex);
                gvins.CurrentRow.Cells["zip"].Value = comboMi2.drom.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboMi2.Visible = false;
                gvins.EndEdit();
                if (gvins.CurrentRow.Index == gvins.RowCount - 1)
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["cityname"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["cityname"];
                }
                else
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["cityname"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["cityname"];
                }

            };
            comboMi2.bt1.Click += delegate
            {
                if (comboMi2.drom.Visible == true && comboMi2.drom.Etat == false)
                    return;
                if (comboMi2.drom.Visible == false && comboMi2.drom.Etat == false)
                    return;
                gvins.CurrentCell.Value = comboMi2.textBox1.Text;
                gvins.CurrentRow.Cells["zip"].Value = comboMi2.drom.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (gvins.CurrentRow.Index == gvins.RowCount - 1)
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["cityname"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["cityname"];
                }
                else
                {
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index + 1].Cells["cityname"];
                    gvins.CurrentCell = gvins.Rows[gvins.CurrentRow.Index - 1].Cells["cityname"];
                }
                /*if (gvins.CurrentCell.OwningColumn.Name == "npa")
                {
                    gvins.CurrentRow.Cells["ville"].Value = comboMi2.drom.dataGridView1.CurrentRow.Cells["col2"].Value.ToString();

                }
                else if (gvins.CurrentCell.OwningColumn.Name == "ville")
                {
                    gvins.CurrentRow.Cells["npa"].Value = comboMi2.drom.dataGridView1.CurrentRow.Cells["col1"].Value.ToString();
                }*/
            };
            
            #endregion
        }

        private void gvins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((gvins.Columns[e.ColumnIndex].Name == "zip" || gvins.Columns[e.ColumnIndex].Name == "cityname") && (gvins.Columns.Contains("zip") == true && gvins.Columns.Contains("cityname") == true))
            {
                string colm, colm1, col1, col2 = "";
                WindowsFormsControlLibrary1.ComboMi cmbm;
                if (gvins.Columns[e.ColumnIndex].Name == "zip")
                {
                    //comboMi1.drom.dataGridView1.Columns["col1"].DisplayIndex = 0;
                    //comboMi1.drom.dataGridView1.Columns["col2"].DisplayIndex = 1;
                    colm = "zip";
                    colm1 = "cityname";
                    col1 = "col1";
                    col2 = "col2";
                    cmbm = comboMi1;
                    //comboMi1.drom.dataGridView1.Sort(comboMi1.drom.dataGridView1.Columns["col1"], ListSortDirection.Ascending);
                }
                else
                {
                    //comboMi1.drom.dataGridView1.Columns["col1"].DisplayIndex = 1;
                    //comboMi1.drom.dataGridView1.Columns["col2"].DisplayIndex = 0;
                    colm = "cityname";
                    colm1 = "zip";
                    col1 = "col2";
                    col2 = "col1";
                    cmbm = comboMi2;
                    //comboMi1.drom.dataGridView1.Sort(comboMi1.drom.dataGridView1.Columns["col2"], ListSortDirection.Ascending);
                }
                //comboMi1.drom.dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;

                cmbm.Visible = true;

                cmbm.drom.dataGridView1.Refresh();
                cmbm.Width = gvins.Columns[e.ColumnIndex].Width + 20;
                DataGridViewCell abc = gvins.CurrentCell;
                Point dd = new Point();

                Rectangle RECT = gvins.GetCellDisplayRectangle(abc.ColumnIndex, abc.RowIndex, true);
                dd.X = RECT.X + gvins.Left - 1;
                dd.Y = RECT.Y + gvins.Top;
                cmbm.Location = dd;
                dd.Y = dd.Y + cmbm.Height;
                cmbm.drom.Location = dd;
                bool trouve = false;
                string val = "";
                for (int i = 0; i < cmbm.drom.dataGridView1.RowCount; i++)
                {
                    if (cmbm.drom.dataGridView1.Rows[i].Cells[0].Value == null)
                        continue;
                    if (!trouve)
                    {
                        if (cmbm.drom.dataGridView1.Rows[i].Cells[0].Value.ToString() == gvins.CurrentCell.Value.ToString())
                        {
                            cmbm.IndCombo = cmbm.drom.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            trouve = true;
                            val = cmbm.drom.dataGridView1.Rows[i].Cells[0].Value.ToString();
                            cmbm.textBox1.Text = val;
                            cmbm.drom.dataGridView1.CurrentCell = cmbm.drom.dataGridView1.Rows[i].Cells[0];
                        }
                    }
                    if (trouve)
                    {
                        while (cmbm.drom.dataGridView1.Rows[i].Cells[0].Value.ToString() == val)
                        {
                            if (cmbm.drom.dataGridView1.Rows[i].Cells[1].Value.ToString() == gvins.CurrentRow.Cells[colm1].Value.ToString())
                            {
                                cmbm.IndCombo = cmbm.drom.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                val = cmbm.drom.dataGridView1.Rows[i].Cells[0].Value.ToString();
                                cmbm.textBox1.Text = val;
                                cmbm.drom.dataGridView1.CurrentCell = cmbm.drom.dataGridView1.Rows[i].Cells[0];
                                break;
                            }
                            i++;
                        }
                        break;
                    }

                }
                if (!trouve)
                    cmbm.textBox1.Text = gvins.CurrentCell.Value.ToString();
            }
        }

        private void comboMi2_Combo_DropDown(object sender, EventArgs e)
        {
            comboMi2.Visible = false;
        }

        private void comboMi2_Combo_DropUp(object sender, EventArgs e)
        {
            if (gvins.Left + gvins.Width < comboMi2.Left + comboMi2.drom.Width)
                comboMi2.drom.Left = comboMi2.Left - (comboMi2.drom.Width - comboMi2.Width);
            else
                comboMi2.drom.Left = comboMi2.Left;
            if ((comboMi2.Top + comboMi2.Height + comboMi2.drom.Height) > this.Height)
                comboMi2.drom.Top = comboMi2.Top - comboMi2.drom.Height;
        }

        private void comboMi1_Combo_DropUp(object sender, EventArgs e)
        {
            //comboMi1.IndCombo = comboMi1.IndCombo;
            if (gvins.Left + gvins.Width < comboMi1.Left + comboMi1.drom.Width)
                comboMi1.drom.Left = comboMi1.Left - (comboMi1.drom.Width - comboMi1.Width);
            else
                comboMi1.drom.Left = comboMi1.Left;
            if ((comboMi1.Top + comboMi1.Height + comboMi1.drom.Height) > this.Height)
                comboMi1.drom.Top = comboMi1.Top - comboMi1.drom.Height;
        }

        private void comboMi1_Combo_DropDown(object sender, EventArgs e)
        {
            comboMi1.Visible = false;
        }

        private void gvins_Click(object sender, EventArgs e)
        {
            if (comboMi1.Visible || comboMi2.Visible)
            {
                comboMi1.Visible = false;
                comboMi1.drom.Visible = false;
                comboMi2.Visible = false;
                comboMi2.drom.Visible = false;
            }
        }

        private void gvins_CurrentCellChanged(object sender, EventArgs e)
        {
            comboMi1.Visible = false;
            comboMi1.drom.Visible = false;
            comboMi2.Visible = false;
            comboMi2.drom.Visible = false;
        }

        private void gvins_Scroll(object sender, ScrollEventArgs e)
        {
            comboMi1.Visible = false;
            comboMi1.drom.Visible = false;
            comboMi2.Visible = false;
            comboMi2.drom.Visible = false;
        }

        private void men_col_Opening(object sender, CancelEventArgs e)
        {
            définirLaColonnea.Enabled = true;

            if (gvins.RowCount == 0)
                définirLaColonnea.Enabled = false;
        }

        private void bt_errsuiv_Click(object sender, EventArgs e)
        {
            for (int i = 0; i< gvins.RowCount; i++)
            {
                for (int j = 0; j< gvins.Columns.Count; j++)
                {
                    if (gvins.Rows[i].Cells[j].Style.BackColor == Color.Red)
                    {
                        gvins.CurrentCell = gvins.Rows[i].Cells[j];
                        gvins.CurrentCell.Selected = true;
                        gvins.FirstDisplayedCell = gvins.Rows[i].Cells[j];
                        return;
                    }
                }
            }
        }
    }
}
