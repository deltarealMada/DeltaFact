using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace DeltaFact
{
    public partial class f_paiement : Form
    {
        public f_paiement()
        {
            InitializeComponent();
        }
        util_fact uf = new util_fact();
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);

        private void bt_valid_Click(object sender, EventArgs e)
        {
            
            string mtt = mttpaye.Text.Trim();
            decimal dmtt = 0;
            decimal.TryParse(mtt, out dmtt);
            string postbanq = "1";
            if (ck_banque.Checked)
                postbanq = "2";
            if (dmtt <= 0)
            {
                uf.message_info("Veuillez saisir le montant payé !");
                return;
            }
            int numfolio = int.Parse(Fmain.Maxsuivant(Fmain.nombasecompta + ".cpta_mouvement", "numfolio", "year(datemouvement) = " + DateTime.Now.Year.ToString()));
            string idcomptedebit = uf.ValeurParCond(comrech, Fmain.nombasecompta + ".cpta_compte", "idcompte, codecompte", "idcompte", "codecompte = " + Fmain.comptedebit);
            string idcompteb = uf.ValeurParCond(comrech, Fmain.nombasecompta + ".cpta_compte", "idcompte, codecompte", "idcompte", "codecompte = " + Fmain.compteb);

                string typetrans = "0"; //tft banque
            if (typetransfert.SelectedIndex == 1)
                typetrans = "1";
            string textedeb = coordpayeur.Text.Trim();
            string datyp = uf.getDateSQL(datepaiement.Value);
            //Comptabilisation
            string newid = uf.executeSQL(comrealvistamod, Fmain.nombasecompta + ".cpta_mouvement", "numfolio,datesaisie,datemouvement,typeecriture,idcompte,codecompte,idcomptec,codecomptec,libelledetail,entree,sortie",
                                numfolio.ToString() + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "1" + "$" + idcompteb + "$" + Fmain.compteb + "$" + idcomptedebit + "$" + Fmain.comptedebit + "$" + "Paiement " + numfact + "-" + textedeb + "-" + comptepayeur.Text.Trim() + "$" + dmtt.ToString() + "$" + "0", 2, "");

            string champ = "typepaiement, postebanque, datesaisie, datepaiement, identreprise, idclient, numfacture, montant, refpaiement, coordpayeur, comptepaiement, typetransfert, idmouvementpaye";
            string valeur = typepaiement.SelectedIndex.ToString() + "$" + postbanq + "$" + uf.getDateSQL(datesaisie.Value) + "$" + uf.getDateSQL(datepaiement.Value) + "$" +
                Fmain.identreprisesel + "$" + int.Parse(numfact.Substring(4, 2)).ToString() + "$" + numfact + "$" + dmtt.ToString() + "$" + refpaiement.Text.Trim() + "$" + textedeb + "$" + comptepayeur.Text.Trim() + "$" + typetrans + "$" + newid ;
            if (typemod == 2) //modif
            {
                uf.executeSQL(comrealvistamod, "fact_paiement", champ, valeur, 1, "idpaiement = " + gv_listepaiement.CurrentRow.Cells["g_idpaiement"].FormattedValue.ToString());
                chargerpaiement();
            }
            else
            {
                uf.executeSQL(comrealvistamod, "fact_paiement", champ, valeur, 2, "");
                //Si solde = 0
                uf.executeSQL(comrealvistamod, "fact_facturation", "rappel", "0", 2, "reffacturedeltareal='" + numfact + "'");

                DialogResult = DialogResult.OK;
            }

        }

        public string numfact = "";
        
            
        public int typefen = 1; ///liste paiement d'une facture sélectionnée.
        public int typemod = 0; //1=ajout 2=modif

        private void f_paiement_Load(object sender, EventArgs e)
        {
            uf.initialisation(p_frais);
            uf.initcontrol(p_frais, "");
            uf.enablecontrol(p_frais, "", false);
            uf.enablecontrol(p_payeur, "", false);
            typetransfert.SelectedIndex = 0;
            foreach (DataGridViewColumn dd in gv_import.Columns)
                dd.ReadOnly = false;
            ck_poste.Checked = true;
            typepaiement.SelectedIndex = 0;
            if (typefen == 1) //liste paiement d'une facture sélectionnée.
            {
                gv_listepaiement.Visible = bt_pmodif.Visible = bt_psuppr.Visible = true;
                p_payeur.Visible = true;
                bt_valid.Visible = true;
                this.Height = 520;
                bt_annul.Top = 435;
                string s = " select reffacturedeltareal as reffacture, montantapayer as totfacture, if(isnull(paie.totalpaye), 0, paie.totalpaye) as totalpaye, (montantapayer - if(isnull(paie.totalpaye), 0, paie.totalpaye)) as solde FROM fact_facturation fact LEFT JOIN (select sum(montant) as totalpaye, numfacture, identreprise FROM fact_paiement group by identreprise, numfacture) paie on paie.identreprise = fact.identreprise and paie.numfacture = fact.reffacturedeltareal WHERE fact.reffacturedeltareal ='" + numfact + "'";

                uf.afficherInfo(p_solde, s, comrech, null);
                chargerpaiement();
                bt_valid.Enabled = false;
                if (typemod == 1) // ajout paiement
                {
                    uf.enablecontrol(p_payeur, "", true);
                    uf.enablecontrol(p_frais, "", true);
                    bt_valid.Enabled = true;
                }
                
            }
            else
            {
                button1.Visible = gv_import.Visible = bt_valider.Visible = bt_impsuppr.Visible = bt_impverif.Visible = true;
                bt_impverif.Enabled = bt_impsuppr.Enabled = false;
                uf.enablecontrol(p_frais, "", true);
               
            }

            
            
        }

        private void chargerpaiement()
        {
            bt_pmodif.Enabled = bt_psuppr.Enabled = false;

            string s = "select idpaiement, if (typepaiement = 0, 'Entreprise', 'Deltareal') as typepaiement, if(postebanque = 1, 'poste', 'banque') as postebanque, if (typetransfert = 0, 'tft banque', 'banque diff.') as typetransfert, datesaisie, datepaiement, identreprise, idclient, numfacture, montant as montantpaye, refpaiement, coordpayeur, comptepaiement FROM " +
                    "fact_paiement WHERE identreprise = " + Fmain.identreprisesel + " AND numfacture = '" + numfact + "' ORDER BY datepaiement desc, idpaiement desc";
            uf.afficherInfo(null, s, comrealvistamod, gv_listepaiement);
            if (gv_listepaiement.RowCount > 0)
            {
                gv_listepaiement.Focus();
                //gv_listepaiement.CurrentCell = gv_listepaiement.Rows[0].Cells[1];
                //bt_pmodif.Enabled = bt_psuppr.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gv_import.Rows.Clear();
            bt_valid.Enabled = false;
            bt_valider.Enabled = false;
            bt_impverif.Enabled = bt_impsuppr.Enabled = false;

            if (FileDg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            XmlReader xmlfile;
            DataSet ds = new DataSet();
            gv_import.AutoGenerateColumns = true;
            //xmlfile = XmlReader.Create(@"D:\Boulots\Tambours\1234.xml", new XmlReaderSettings());
            xmlfile = XmlReader.Create(FileDg.FileName, new XmlReaderSettings());
            ds.ReadXml(xmlfile);
            //XmlReader ss; = new XmlReader((@"D:\Boulots\Tambours\123.xml");

            //s = XmlSchema.Read(ss, new ValidationEventHandler(SchemaValidationHandler));
            //ss.Close();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            if (textBox1.Text.Trim() != "")
            {
                try
                {
                    int ff = int.Parse(textBox1.Text);
                    //gv_import.DataSource = ds.Tables[int.Parse(textBox1.Text)];
                    textBox2.Text = ds.Tables[int.Parse(textBox1.Text)].ParentRelations[0].ParentTable.TableName;
                    for (int i = 0; i < ds.Tables[int.Parse(textBox1.Text)].ChildRelations.Count; i++)
                        listBox1.Items.Add(ds.Tables[int.Parse(textBox1.Text)].ChildRelations[i].ChildTable.TableName);
                    for (int i = 0; i < ds.Tables[int.Parse(textBox1.Text)].Columns.Count; i++)
                        listBox2.Items.Add(ds.Tables[int.Parse(textBox1.Text)].Columns[i].ColumnName);
                }
                catch
                {
                    //gv_import.DataSource = ds.Tables[textBox1.Text];
                    textBox2.Text = ds.Tables[textBox1.Text].ParentRelations[0].ParentTable.TableName;
                    for (int i = 0; i < ds.Tables[textBox1.Text].ChildRelations.Count; i++)
                        listBox1.Items.Add(ds.Tables[textBox1.Text].ChildRelations[i].ChildTable.TableName);
                    for (int i = 0; i < ds.Tables[textBox1.Text].Columns.Count; i++)
                        listBox2.Items.Add(ds.Tables[textBox1.Text].Columns[i].ColumnName);
                }
            }
            DataTable dc = ds.Tables["Ntry"];
            int ngroupe = dc.Rows.Count;
            string Refentree = "";
            string dateGroupe = "";
            string mttTot = "";
            string ccyTot = "";
            int nbL = -1;
            for (int i = 0; i < ngroupe; i++)
            {
                //Pour chaque groupe de paiement

                DataRow dc_ss = dc.Rows[i].GetChildRows("Ntry_Amt")[0]; //Montant groupement
                Refentree = dc.Rows[i].ItemArray.GetValue(dc.Columns["NtryRef"].Ordinal).ToString();

                mttTot = dc_ss.ItemArray.GetValue(dc_ss.Table.Columns["Amt_Text"].Ordinal).ToString(); //dc.Rows[i].ItemArray.GetValue(dc.Columns["Amt"].Ordinal).ToString();  //
                ccyTot = dc_ss.ItemArray.GetValue(dc_ss.Table.Columns["Ccy"].Ordinal).ToString();
                dc_ss = dc.Rows[i].GetChildRows("Ntry_BookgDt")[0];
                dateGroupe = dc_ss.ItemArray.GetValue(dc_ss.Table.Columns["Dt"].Ordinal).ToString();


                int nbrLdet = ds.Tables["Ntry"].Rows[i].GetChildRows("Ntry_NtryDtls")[0].GetChildRows("NtryDtls_TxDtls").Length;
                for (int j = 0; j < nbrLdet; j++)
                {
                    DataRow detL = ds.Tables["Ntry"].Rows[i].GetChildRows("Ntry_NtryDtls")[0].GetChildRows("NtryDtls_TxDtls")[j];
                    gv_import.Rows.Add(1);
                    nbL++;
                    gv_import.Rows[nbL].Cells["grp_ref"].Value = Refentree;
                    gv_import.Rows[nbL].Cells["grp_mttot"].Value = mttTot;
                    gv_import.Rows[nbL].Cells["grp_ccymtt"].Value = ccyTot;
                    gv_import.Rows[nbL].Cells["grp_date"].Value = dateGroupe;

                    gv_import.Rows[nbL].Cells["p_ref"].Value = detL.GetChildRows("TxDtls_Refs")[0].ItemArray.GetValue(detL.GetChildRows("TxDtls_Refs")[0].Table.Columns["AcctSvcrRef"].Ordinal).ToString();

                    if (detL.GetChildRows("TxDtls_Amt").Length > 0)
                    {
                        string MttPaye = "";
                        string CcyPaye = "";
                        if (detL.GetChildRows("TxDtls_Amt")[0].Table.Columns["Ccy"].Ordinal > -1)
                            CcyPaye = detL.GetChildRows("TxDtls_Amt")[0].ItemArray.GetValue(detL.GetChildRows("TxDtls_Amt")[0].Table.Columns["Ccy"].Ordinal).ToString();
                        if (detL.GetChildRows("TxDtls_Amt")[0].Table.Columns["Amt_Text"].Ordinal > -1)
                            MttPaye = detL.GetChildRows("TxDtls_Amt")[0].ItemArray.GetValue(detL.GetChildRows("TxDtls_Amt")[0].Table.Columns["Amt_Text"].Ordinal).ToString();
                        //gv_import.Rows[nbL].Cells["p_ccypaye"].Value = CcyPaye;
                        gv_import.Rows[nbL].Cells["p_mttpaye"].Value = MttPaye;
                    }

                    if (detL.GetChildRows("TxDtls_RltdPties").Length > 0) //coordonnées payeur
                    {
                        DataRow detL_det = detL.GetChildRows("TxDtls_RltdPties")[0];
                        if (detL_det.GetChildRows("RltdPties_Dbtr").Length > 0)
                        {
                            if (detL_det.GetChildRows("RltdPties_Dbtr")[0].Table.Columns["Nm"].Ordinal > -1)
                            {
                                string nomm = detL_det.GetChildRows("RltdPties_Dbtr")[0].ItemArray.GetValue(detL_det.GetChildRows("RltdPties_Dbtr")[0].Table.Columns["Nm"].Ordinal).ToString();
                                if (nomm == "NOTPROVIDED")
                                {
                                    nomm = "Inconnu";
                                    gv_import.Rows[nbL].Cells["p_moyenpaiement"].Value = "tft banque";
                                }
                                gv_import.Rows[nbL].Cells["p_deb"].Value = nomm;
                            }
                            if (detL_det.GetChildRows("RltdPties_Dbtr")[0].GetChildRows("Dbtr_PstlAdr").Length > 0 && detL_det.GetChildRows("RltdPties_Dbtr")[0].GetChildRows("Dbtr_PstlAdr")[0].GetChildRows("PstlAdr_AdrLine").Length > 0 && detL_det.GetChildRows("RltdPties_Dbtr")[0].GetChildRows("Dbtr_PstlAdr")[0].GetChildRows("PstlAdr_AdrLine")[0].Table.Columns["AdrLine_Text"].Ordinal > -1)
                            {
                                string adr = "";
                                for (int k = 0; k < detL_det.GetChildRows("RltdPties_Dbtr")[0].GetChildRows("Dbtr_PstlAdr")[0].GetChildRows("PstlAdr_AdrLine").Length; k++)
                                {
                                    if (adr != "")
                                        adr += ", ";
                                    adr += detL_det.GetChildRows("RltdPties_Dbtr")[0].GetChildRows("Dbtr_PstlAdr")[0].GetChildRows("PstlAdr_AdrLine")[k].ItemArray.GetValue(detL_det.GetChildRows("RltdPties_Dbtr")[0].GetChildRows("Dbtr_PstlAdr")[0].GetChildRows("PstlAdr_AdrLine")[k].Table.Columns["AdrLine_Text"].Ordinal).ToString();
                                }
                                gv_import.Rows[nbL].Cells["p_debadr"].Value = adr;
                            }
                        }
                        if (detL_det.GetChildRows("RltdPties_DbtrAcct").Length > 0 && detL_det.GetChildRows("RltdPties_DbtrAcct")[0].GetChildRows("DbtrAcct_Id")[0].Table.Columns["IBAN"].Ordinal > -1) //Compte débiteur
                        {
                            gv_import.Rows[nbL].Cells["p_debcompte"].Value = detL_det.GetChildRows("RltdPties_DbtrAcct")[0].GetChildRows("DbtrAcct_Id")[0].ItemArray.GetValue(detL_det.GetChildRows("RltdPties_DbtrAcct")[0].GetChildRows("DbtrAcct_Id")[0].Table.Columns["IBAN"].Ordinal).ToString();
                            gv_import.Rows[nbL].Cells["p_moyenpaiement"].Value = "tft banque";
                        }
                    }
                    else if (detL.GetChildRows("TxDtls_RltdAgts").Length > 0) //coordonnées bancaire paiement
                    {
                        DataRow detL_det = detL.GetChildRows("TxDtls_RltdAgts")[0];
                        if (detL_det.GetChildRows("RltdAgts_DbtrAgt").Length > 0)
                        {
                            string coord = "";
                            string adr = "";
                            if (detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId").Length > 0)
                            {
                                gv_import.Rows[nbL].Cells["p_moyenpaiement"].Value = "poste diff.";

                                if (detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].Table.Columns["Nm"].Ordinal > -1)
                                    coord = detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].ItemArray.GetValue(detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].Table.Columns["Nm"].Ordinal).ToString();
                                if (detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].Table.Columns["BICFI"].Ordinal > -1)
                                    coord += "-" + detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].ItemArray.GetValue(detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].Table.Columns["BICFI"].Ordinal).ToString();
                                if (coord.Substring(0, 1) == "-")
                                    coord = coord.Substring(1);
                                gv_import.Rows[nbL].Cells["p_deb"].Value = coord;

                                if (detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].GetChildRows("FinInstnId_PstlAdr").Length > 0 && 
                                    detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].GetChildRows("FinInstnId_PstlAdr")[0].GetChildRows("PstlAdr_Adrline").Length > 0 &&
                                    detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].GetChildRows("FinInstnId_PstlAdr")[0].GetChildRows("PstlAdr_Adrline")[0].Table.Columns["AdrLine_Text"].Ordinal > -1)
                                {
                                    for (int k = 0; k < detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].GetChildRows("FinInstnId_PstlAdr")[0].GetChildRows("PstlAdr_Adrline").Length; k++)
                                    {
                                        if (adr != "")
                                            adr += ", ";
                                        adr += detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].GetChildRows("FinInstnId_PstlAdr")[0].GetChildRows("PstlAdr_Adrline")[k].ItemArray.GetValue(detL_det.GetChildRows("RltdAgts_DbtrAgt")[0].GetChildRows("DbtrAgt_FinInstnId")[0].GetChildRows("FinInstnId_PstlAdr")[0].GetChildRows("PstlAdr_Adrline")[k].Table.Columns["AdrLine_Text"].Ordinal).ToString();
                                    }
                                    gv_import.Rows[nbL].Cells["p_debadr"].Value = adr;
                                }
                            }

                        }
                        if (detL_det.GetChildRows("RltdPties_DbtrAcct").Length > 0 && detL_det.GetChildRows("RltdPties_DbtrAcct")[0].GetChildRows("DbtrAcct_Id")[0].Table.Columns["IBAN"].Ordinal > -1) //Compte débiteur
                        {
                            gv_import.Rows[nbL].Cells["p_debcompte"].Value = detL_det.GetChildRows("RltdPties_DbtrAcct")[0].GetChildRows("DbtrAcct_Id")[0].ItemArray.GetValue(detL_det.GetChildRows("RltdPties_DbtrAcct")[0].GetChildRows("DbtrAcct_Id")[0].Table.Columns["IBAN"].Ordinal).ToString();
                        }
                    }

                    if (detL.GetChildRows("TxDtls_RmtInf").Length > 0)
                    {
                        string refFact = "";
                        if (detL.GetChildRows("TxDtls_RmtInf")[0].GetChildRows("RmtInf_Strd").Length > 0 && detL.GetChildRows("TxDtls_RmtInf")[0].GetChildRows("RmtInf_Strd")[0].GetChildRows("Strd_CdtrRefInf").Length > 0)
                            refFact = detL.GetChildRows("TxDtls_RmtInf")[0].GetChildRows("RmtInf_Strd")[0].GetChildRows("Strd_CdtrRefInf")[0].ItemArray.GetValue(detL.GetChildRows("TxDtls_RmtInf")[0].GetChildRows("RmtInf_Strd")[0].GetChildRows("Strd_CdtrRefInf")[0].Table.Columns["Ref"].Ordinal).ToString();
                        //DataRow detL_det = detL.GetChildRows("TxDtls_RmtInf")[0];
                        gv_import.Rows[nbL].Cells["p_reffact"].Value = refFact;
                        if (refFact != "" && refFact.Length > 19)
                            gv_import.Rows[nbL].Cells["p_numfact"].Value = refFact.Substring(10, 10);

                    }

                }

            }
            if (gv_import.Rows.Count > 0)
            {
                testerdonnees();
                gv_import.ReadOnly = false;
                bt_impverif.Enabled = bt_impsuppr.Enabled = true;

            }
        }

        private void testerdonnees(int bouton = 0)
        {
            bt_valider.Enabled = false;
            if (gv_import.RowCount > 0)
            {
                bool bOK = true;
                for (int i = 0; i < gv_import.RowCount; i++)
                {
                    gv_import.Rows[i].Cells["p_mttpaye"].Style.BackColor = gv_import.Rows[i].DefaultCellStyle.BackColor;
                    gv_import.Rows[i].Cells["p_mttpaye"].Style.SelectionBackColor = gv_import.Rows[i].DefaultCellStyle.BackColor;
                    gv_import.Rows[i].Cells["p_numfact"].Style.BackColor = gv_import.Rows[i].DefaultCellStyle.BackColor;
                    gv_import.Rows[i].Cells["p_numfact"].Style.SelectionBackColor = gv_import.Rows[i].DefaultCellStyle.BackColor;
                    string numf = gv_import.Rows[i].Cells["p_numfact"].FormattedValue.ToString();
                    string ident = "";
                    string idcli = "";
                    string mtt = "";
                    string refp = "";
                    string datep = "";
                    if (numf != "" && numf.Length >=10)
                    {

                        //gv_import.Rows[i].Cells["p_numfact"].Value = numf.Substring(10, 10);
                        if (uf.ValeurParCond(comrech, "fact_facturation", "reffacturedeltareal", "reffacturedeltareal", "reffacturedeltareal ='" + numf + "'") == "")
                        {
                            gv_import.Rows[i].Cells["p_numfact"].Style.BackColor = gv_import.Rows[i].Cells["p_numfact"].Style.SelectionBackColor = Color.Red;
                            bOK = false;
                        }
                        ident = numf.Substring(4, 2);
                        idcli = numf.Substring(6, 4);
                        gv_import.Rows[i].Cells["p_client"].Value = idcli;
                        mtt = gv_import.Rows[i].Cells["p_mttpaye"].FormattedValue.ToString();
                        decimal dmtt = 0;
                        decimal.TryParse(mtt, out dmtt);
                        if (dmtt == 0)
                        {
                            bOK = false;
                            gv_import.Rows[i].Cells["p_mttpaye"].Style.BackColor = gv_import.Rows[i].Cells["p_mttpaye"].Style.SelectionBackColor = Color.Red;
                        }
                    }
                    else
                    {
                        bOK = false;
                        gv_import.Rows[i].Cells["p_numfact"].Style.BackColor = gv_import.Rows[i].Cells["p_numfact"].Style.SelectionBackColor = Color.Red;
                    }
                }
                if (bOK)
                {
                    gv_import.CurrentCell = gv_import.Rows[0].Cells[0];
                    bt_valider.Enabled = true;
                }
            }

        }

        private void gv_import_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gv_import.RowCount > 0 && e.RowIndex > -1 && gv_import.Rows[e.RowIndex].Cells["p_reffact"].FormattedValue.ToString() != "")
            {
                
                string numf = gv_import.Rows[e.RowIndex].Cells["p_reffact"].FormattedValue.ToString();
                numfact = numf.Substring(10, 10);
                string s = " select reffacturedeltareal as reffacture, montantapayer as totfacture, if(isnull(paie.totalpaye), 0, paie.totalpaye) as totalpaye, (montantapayer - if(isnull(paie.totalpaye), 0, paie.totalpaye)) as solde FROM fact_facturation fact LEFT JOIN (select sum(montant) as totalpaye, numfacture, identreprise FROM fact_paiement group by identreprise, numfacture) paie on paie.identreprise = fact.identreprise and paie.numfacture = fact.reffacturedeltareal WHERE fact.reffacturedeltareal ='" + numfact + "'";

                datepaiement.Value = DateTime.Parse(gv_import.Rows[e.RowIndex].Cells["grp_date"].FormattedValue.ToString());
                uf.afficherInfo(p_solde, s, comrech, null);
                mttpaye.Text = gv_import.Rows[e.RowIndex].Cells["p_mttpaye"].FormattedValue.ToString();
            }
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            int numfolio = int.Parse(Fmain.Maxsuivant(Fmain.nombasecompta + ".cpta_mouvement", "numfolio", "year(datemouvement) = " + DateTime.Now.Year.ToString()));
            string idcomptedebit = uf.ValeurParCond(comrech, Fmain.nombasecompta + ".cpta_compte", "idcompte, codecompte", "idcompte", "codecompte = " + Fmain.comptedebit);
            string idcompteb = uf.ValeurParCond(comrech, Fmain.nombasecompta + ".cpta_compte", "idcompte, codecompte", "idcompte", "codecompte = " + Fmain.compteb);

            for (int i = 0; i < gv_import.RowCount; i++)
            {
               
                string numf = gv_import.Rows[i].Cells["p_numfact"].FormattedValue.ToString();
                string ident = "";
                string idcli = "";
                string mtt = "";
                string refp = "";
                string datep = "";
                string postbanq = "1";
                if (ck_banque.Checked)
                    postbanq = "2";
                
                ident = numf.Substring(4, 2);
                idcli = numf.Substring(6, 4);
                
                mtt = gv_import.Rows[i].Cells["p_mttpaye"].FormattedValue.ToString();
                decimal dmtt = 0;
                decimal.TryParse(mtt, out dmtt);
                refp = gv_import.Rows[i].Cells["grp_ref"].FormattedValue.ToString() + "<<>>" + gv_import.Rows[i].Cells["p_ref"].FormattedValue.ToString();
                if (refp.Replace("<<>>", "") == "")
                    refp = "";
                string typetrans = "0"; //tft banque
                if (gv_import.Rows[i].Cells["p_moyenpaiement"].FormattedValue.ToString().Contains("tft") == false)
                    typetrans = "1"; //poste diffé
                string textedeb = (gv_import.Rows[i].Cells["p_deb"].FormattedValue.ToString() + ", " + gv_import.Rows[i].Cells["p_debadr"].FormattedValue.ToString()).Trim();
                if (textedeb.Replace(",", "").Trim() == "")
                    textedeb = "";
                string datyp = uf.getDateSQL(DateTime.Parse(gv_import.Rows[i].Cells["grp_date"].FormattedValue.ToString()));
                //Comptabilisation
                string newid = uf.executeSQL(comrealvistamod, Fmain.nombasecompta + ".cpta_mouvement", "numfolio,datesaisie,datemouvement,typeecriture,idcompte,codecompte,idcomptec,codecomptec,libelledetail,entree,sortie",
                                numfolio.ToString() + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "$" + "1" + "$" + idcompteb + "$" + Fmain.compteb + "$" + idcomptedebit + "$" + Fmain.comptedebit+ "$" + "Paiement " + numf + "-" + textedeb + "-" + gv_import.Rows[i].Cells["p_debcompte"].FormattedValue.ToString().Trim() + "$" + dmtt.ToString() + "$" + "0", 2, "");


                string champ = "typepaiement, postebanque, datesaisie, datepaiement, identreprise, idclient, numfacture, montant, refpaiement, coordpayeur, comptepaiement, typetransfert, idmouvementpaye";
                string valeur = typepaiement.SelectedIndex.ToString() + "$" + postbanq + "$" + uf.getDateSQL(DateTime.Now) + "$" + datyp + "$" +
                    ident + "$" + idcli + "$" + numf + "$" + dmtt.ToString() + "$" + refp + "$" + textedeb + "$" + gv_import.Rows[i].Cells["p_debcompte"].FormattedValue.ToString() + "$" + typetrans + "$" + newid;

                uf.executeSQL(comrealvistamod, "fact_paiement", champ, valeur, 2, "");
                uf.executeSQL(comrealvistamod, "fact_facturation", "rappel", "0", 2, "reffacturedeltareal='" + numf + "'");
                numfolio++;
            }
            uf.message_info("Importation paiement effectuée avec succès !");
            this.DialogResult = DialogResult.OK;
        }

        private void bt_pmodif_Click(object sender, EventArgs e)
        {
            uf.initialisation(p_frais);
            uf.enablecontrol(p_frais, "", true);
                uf.enablecontrol(p_payeur, "", true);
            typemod = 2;
            bt_valid.Enabled = true;
        }

        private void gv_listepaiement_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gv_listepaiement.RowCount > 0 && gv_listepaiement.Rows[e.RowIndex].Cells["g_idpaiement"].FormattedValue.ToString() != "")
            {
                uf.initcontrol(p_frais, "");
                uf.initcontrol(p_payeur, "");

                uf.enablecontrol(p_frais, "", false);
                uf.enablecontrol(p_payeur, "", false);
                datesaisie.Value = DateTime.Parse(gv_listepaiement.Rows[e.RowIndex].Cells["g_datesaisie"].FormattedValue.ToString());
                datepaiement.Value = DateTime.Parse(gv_listepaiement.Rows[e.RowIndex].Cells["g_datepaiement"].FormattedValue.ToString());
                typepaiement.Text = gv_listepaiement.Rows[e.RowIndex].Cells["g_typepaiement"].FormattedValue.ToString();
                typetransfert.SelectedIndex = 1;
                if (gv_listepaiement.Rows[e.RowIndex].Cells["g_typetransfert"].FormattedValue.ToString().Contains("tft"))
                    typetransfert.SelectedIndex = 0;
                ck_poste.Checked = true;
                if (gv_listepaiement.Rows[e.RowIndex].Cells["g_postebanque"].FormattedValue.ToString() == "banque")
                    ck_banque.Checked = true;
                mttpaye.Text = gv_listepaiement.Rows[e.RowIndex].Cells["g_montantpaye"].FormattedValue.ToString();
                refpaiement.Text = gv_listepaiement.Rows[e.RowIndex].Cells["g_refpaiement"].FormattedValue.ToString();
                coordpayeur.Text = gv_listepaiement.Rows[e.RowIndex].Cells["g_coordpayeur"].FormattedValue.ToString();
                bt_valid.Enabled = false;
                typemod = 0;
            }
        }

        private void bt_psuppr_Click(object sender, EventArgs e)
        {
            if (uf.confirmer_questionON(this, "Etes-vous sûre de supprimer cette ligne de paiement ?") == DialogResult.Yes)
            {
                uf.executeSQL(comrealvistamod, "fact_paiement", "", "", 3, "idpaiement = " + gv_listepaiement.CurrentRow.Cells["g_idpaiement"].FormattedValue.ToString());
                chargerpaiement();
                bt_annul.DialogResult = DialogResult.OK;
            }
        }

        private void bt_impsuppr_Click(object sender, EventArgs e)
        {
            if (gv_import.SelectedRows.Count > 0)
            {
                gv_import.Rows.Remove(gv_import.SelectedRows[0]);
            }
        }

        private void bt_impverif_Click(object sender, EventArgs e)
        {
            testerdonnees();
        }

        private void gv_import_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bt_valider.Enabled = false;
        }
    }
}
