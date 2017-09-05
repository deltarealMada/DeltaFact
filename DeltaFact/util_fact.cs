using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsControlLibrary1;
using System.Data;

namespace DeltaFact
{
    class util_fact
    {
        public static string variableglobale = "lklk";
        MySqlDataReader myread;
        MySqlDataReader myread1;
        MySqlDataAdapter myadapt;
        string typetelfax = "telpro telmob mobile natel fax mob";
        string typecur = "decimal double float single";

        public void message_info(string texte)
        {
            MessageBox.Show(texte, "Information", MessageBoxButtons.OK);
        }

        public void AfficherErreur(string texte)
        {
            MessageBox.Show(texte, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult confirmer_questionON(IWin32Window own, string texte)
        {
            DialogResult rep = MessageBox.Show(own, texte, "Attention", MessageBoxButtons.YesNo);
            return rep;
        }

        //**************** Renvoi l'index à partir d'une valeur ***********************************

        public string IndexParValeur(MySqlCommand QC, string sTable, string sChamp, string sChampResult, string sValue)
        {
            //int iCount = GetRecordCount(QC, sTable, "");
            QC.CommandText = "SELECT * FROM " + sTable + " WHERE " + sChamp + " = \"" + sValue + "\"";
            MySqlDataReader Q = QC.ExecuteReader();
            //Q.Read();
            string Ret = "";

            //if (Q.RecordCount != 0)
            //if (iCount != 0)
            if (Q.Read())
            {
                Ret = Q.GetValue(Q.GetOrdinal(sChampResult)).ToString();
            }
            else
                Ret = "-1";
            Q.Close();
            return Ret;
        }

        //**************** Renvoi la valeur d'une paramètre d'une table à partir d'une condition***********************************

        public string ValeurParCond(MySqlCommand QC, string sTable, string sChamp, string sChampResult, string sCondition, string requeteavant = "")
        {
            if (requeteavant != "")
            {
                QC.CommandText = requeteavant;
                QC.ExecuteNonQuery();
            }
            QC.CommandText = "SELECT " + sChamp + " FROM " + sTable + " WHERE " + sCondition; // + " order by (" + sChampResult + " <> '' and " + sChampResult + " is not null) desc limit 1";
            //QC.FetchAll = true;
            MySqlDataReader Qr = QC.ExecuteReader();
            string Ret = "";
            if (Qr.Read())
            {
                if (Qr.GetValue(Qr.GetOrdinal(sChampResult)).GetType().Name !=  typeof(DBNull).Name)
                    Ret = Qr.GetString(Qr.GetOrdinal(sChampResult));
                Qr.Close();
                return Ret;
            }
            else
            {
                Qr.Close();
                return Ret;
            }
        }

        public void RemplirCombo(Object TComb, string Rekety, MySqlCommand SQLCom, MySqlDataAdapter SQLAdapt)
        {

            //(TComb as ComboBox).DataSource = null;
            if (TComb.GetType() == typeof(ComboBox))
                (TComb as ComboBox).Invalidate(true);
            else if (TComb.GetType() == typeof(ListBox))
                (TComb as ListBox).Invalidate(true);

            BindingSource bs = new BindingSource();
            DataTable table = new DataTable();
            bs.DataSource = table;

            SQLCom.CommandText = Rekety;

            SQLAdapt.SelectCommand = SQLCom;

            SQLAdapt.Fill(table);
            if (TComb.GetType() == typeof(ComboBox))
            {
                (TComb as ComboBox).DataSource = bs;
                (TComb as ComboBox).Update();
            }
            else if (TComb.GetType() == typeof(ListBox))
            {
                (TComb as ListBox).DataSource = bs;
                (TComb as ListBox).Update();
            }
            else if (TComb.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                (TComb as DataGridViewComboBoxColumn).DataSource = bs;
                //(TComb as DataGridViewComboBoxColumn).reUpdate();
            }
        }

        public string valcombo(ComboBox comb)
        {
            //ComboBox cmbval = (Controls.Find("id_" + comb.Name, true)[0]) as ComboBox;
            if (comb.SelectedIndex > -1)
                return comb.SelectedValue.ToString();
            else
                return "-1";
        }

        public string valliste(ListBox comb)
        {
            //ComboBox cmbval = (Controls.Find("id_" + comb.Name, true)[0]) as ComboBox;
            if (comb.SelectedIndex > -1)
                return comb.SelectedValue.ToString();
            else
                return "-1";
        }

        public string GetValueNonRound(MySqlDataReader tmp, string Champ)
        {
            string ret = "";
            //if (Tab.GetFieldType(Tab.GetOrdinal(nomCol)) == typeof(string))

            if ((tmp.GetFieldType(tmp.GetOrdinal(Champ)).Name == typeof(double).Name || tmp.GetFieldType(tmp.GetOrdinal(Champ)).Name == typeof(Decimal).Name || tmp.GetFieldType(tmp.GetOrdinal(Champ)).Name == typeof(Single).Name || tmp.GetFieldType(tmp.GetOrdinal(Champ)).Name == typeof(float).Name))
            {

                if (tmp.GetValue(tmp.GetOrdinal(Champ)).ToString() != "")
                {
                    if (tmp.GetValue(tmp.GetOrdinal(Champ)).GetType().Name == typeof(DBNull).Name)
                        ret = "0.00";
                    else
                        ret = string.Format("{0:#0.00;-#.00;'0.00'}", tmp.GetDouble(tmp.GetOrdinal(Champ)));
                    ret = getFormatCur(ret);
                }
                else
                    ret = "0.00";

            }
            else
            {
                if (tmp.GetValue(tmp.GetOrdinal(Champ)) == null)
                    ret = "";
                else
                    ret = tmp.GetValue(tmp.GetOrdinal(Champ)).ToString();
            }
            return ret;
        }

        public string GetValue(MySqlDataReader tmp, string Champ)
        {
            string ret = "";
            //if (Tab.GetFieldType(Tab.GetOrdinal(nomCol)) == typeof(string))

            if ((tmp.GetFieldType(tmp.GetOrdinal(Champ)) == typeof(DateTime)))
            {
                if ((tmp.GetValue(tmp.GetOrdinal(Champ)).ToString() == ""))
                    ret = "NULL#";
                else
                    ret = string.Format("{0:dd.MM.yyyy}", tmp.GetValue(tmp.GetOrdinal(Champ)));
            }
            else if ((tmp.GetValue(tmp.GetOrdinal(Champ)).ToString() != "") && (tmp.GetFieldType(tmp.GetOrdinal(Champ)) == typeof(double) || tmp.GetFieldType(tmp.GetOrdinal(Champ)) == typeof(float)))
            {
                ret = string.Format("{0:#0.00;-#.00;'0.00'}", Math.Round(tmp.GetDouble(tmp.GetOrdinal(Champ)) / 0.05) * 0.05);
                ret = getFormatCur(ret);
            }
            else
            {
                if (tmp.GetValue(tmp.GetOrdinal(Champ)).ToString() == "")
                    ret = "";
                else
                    ret = tmp.GetValue(tmp.GetOrdinal(Champ)).ToString();
            }
            return ret;
        }

        public Boolean testchampvide(Panel ctrl, Control ignore1 = null, Control ignore2 = null, Control ignore3 = null, Control ignore4 = null)
        {
            Boolean ret = false;
            foreach (Control c in ctrl.Controls)
            {
                if (c.Visible == false || (ignore1 != null && c.Name == ignore1.Name) || (ignore2 != null && c.Name == ignore2.Name) || (ignore3 != null && c.Name == ignore3.Name) || (ignore4 != null && c.Name == ignore4.Name))
                    continue;
                if (c.GetType().Name == typeof(TextBox).Name)
                {
                    if (c.Text.Trim() == "")
                        ret = true;
                }
                if (c.GetType().Name == typeof(ComboBox).Name)
                {
                    if ((c as ComboBox).SelectedIndex == -1)
                        ret = true;
                }
                if (ret == true)
                    break;
            }
            return ret;
        }

        public Boolean testchampzero(TextBox c, string mess)
        {
            Boolean ret = false;
            decimal tmp = 0;
            decimal.TryParse(c.Text.Trim(), out tmp);
            if (tmp <= 0)
            {
                message_info("Veuillez saisir une valeur valide dans le champ '" + mess + "' !");
                ret = true;
            }
            return ret;
        }

        public string valtexte(Control txt)
        {
            if (txt.Name.Contains("tel") || txt.Name.Contains("fax") || txt.Name.Contains("mob"))
                return txt.Text.Replace(" ", "");
            else if (txt.GetType().Name == typeof(DateTimePicker).Name)
            {
                return string.Format("{0:dd.MM.yyyy}", (txt as DateTimePicker).Value);
            }
            else if (txt.Name.Contains("cent"))
            {
                return txt.Text.Trim().Replace("%", "");
            }
            else // if (txt.Name.Contains("prix") || txt.Name.Contains("mtt") || txt.Name.Contains("taux") || txt.Name.Contains("tva") || txt.Name.Contains("int"))
            {

                return txt.Text.Trim();
            }

            
        }

        public void afficherInfo(Control sender, string sql, MySqlCommand mycom, DataGridView grille, string ignorecontrol = "", MySqlDataReader myreads = null, int nrow = 0, Control sender1 = null, Control sender2 = null) // bool grille)
        {
            bool readexiste = true;
            if (myreads == null)
                readexiste = false;
            if (!readexiste)
            {
                //sql = sql.Replace("'", "\"").Replace("`", )
                mycom.CommandText = sql;
                myreads = myread = mycom.ExecuteReader();
            }
            else
            {
                
            }
            string[] ign = ignorecontrol.Split(';');
            if (grille == null)
            {
                
                if (myreads.Read())
                {
                    //parcours des champs du reader en comparaison avec les champs existants dans la fenêtre
                    //Si grille false
                    for (int i = 0; i < myreads.FieldCount; i++)
                    {
                        //Form ff = ((mycom.Container) as Form);

                        Control[] contr = (sender as Control).Controls.Find(myreads.GetName(i), true);
                        if (contr.Length == 0)
                            contr = (sender as Control).Controls.Find(myreads.GetName(i) + "_1", true);
                        if (contr.Length == 0 && sender1 != null)
                            contr = (sender1 as Control).Controls.Find(myreads.GetName(i), true);
                        if (contr.Length == 0 && sender2 != null)
                            contr = (sender2 as Control).Controls.Find(myreads.GetName(i), true);
                        if (contr.Length > 0)
                        {
                            if (ign.Contains<string>(contr[0].Name))
                                continue;
                            if (contr[0].GetType().Name == "TextBox")
                            {
                                if (typecur.Contains(myreads.GetFieldType(i).Name.ToLower()))
                                    ((contr[0]) as TextBox).Text = getFormatCur(myreads.GetValue(i).ToString());
                                else if (myreads.GetFieldType(i).Name.ToLower().Contains("date"))
                                    ((contr[0]) as TextBox).Text = string.Format("{0:dd.MM.yyyy}", myreads.GetDateTime(i));

                                else if (typetelfax.Contains((contr[0] as TextBox).Name.ToLower()))
                                    ((contr[0]) as TextBox).Text = miseenformeTel(myreads.GetValue(i).ToString());
                                else // if (myreads.GetFieldType(i).Name.ToLower() == "varchar")
                                    ((contr[0]) as TextBox).Text = myreads.GetValue(i).ToString();
                            }
                            else if (contr[0].GetType().Name == "RichTextBox")
                            {
                                ((contr[0]) as RichTextBox).LoadFile(myreads.GetValue(i).ToString(), RichTextBoxStreamType.RichText);
                            }
                            else if (contr[0].GetType().Name == "DateTimePicker")
                            {
                                ((contr[0]) as DateTimePicker).Text = string.Format("{0:dd.MM.yyyy}", myreads.GetDateTime(i));
                            }
                            else if (contr[0].GetType().Name == "MaskedTextBox")
                            {
                                //((contr[0]) as MaskedTextBox).Text = myreads.GetValue(i).ToString();
                                if (typecur.Contains(myreads.GetFieldType(i).Name.ToLower()))
                                    ((contr[0]) as MaskedTextBox).Text = getFormatCur(myreads.GetValue(i).ToString());
                                else if (myreads.GetFieldType(i).Name.ToLower().Contains("date"))
                                    ((contr[0]) as MaskedTextBox).Text = string.Format("{0:dd.MM.yyyy}", myreads.GetDateTime(i));
                                else // if (myreads.GetFieldType(i).Name.ToLower() == "varchar")
                                    ((contr[0]) as MaskedTextBox).Text = myreads.GetValue(i).ToString();
                            }
                            else if (contr[0].GetType().Name == "CheckBox")
                            {
                                ((contr[0]) as CheckBox).Checked = false;
                                if (myreads.GetValue(i).ToString() == "1")
                                    ((contr[0]) as CheckBox).Checked = true;
                            }
                            else if (contr[0].GetType().Name == "ComboBox")
                            {
                                //if (contr[0].Name.Contains("id_"))
                                //{
                                if (((contr[0]) as ComboBox).Items.Count > 0)
                                {
                                    ((contr[0]) as ComboBox).Text = "";
                                    ((contr[0]) as ComboBox).SelectedIndex = -1;
                                    if (myreads.GetValue(i).ToString() != "" && myreads.GetValue(i).ToString() != "null")
                                        ((contr[0]) as ComboBox).SelectedValue = myreads.GetValue(myreads.GetOrdinal("id" + contr[0].Name)).ToString();

                                    //((sender as Form).Controls.Find(myreads.GetName(i).Replace("id_", "val_"), true)[0] as ComboBox).SelectedIndex = ((contr[0]) as ComboBox).SelectedIndex;
                                    //((sender as Form).Controls.Find(myreads.GetName(i).Replace("id_", ""), true)[0] as ComboBox).SelectedIndex = ((contr[0]) as ComboBox).SelectedIndex;
                                }
                                else
                                {
                                    ((contr[0]) as ComboBox).Text = "";
                                    ((contr[0]) as ComboBox).SelectedIndex = -1;
                                }
                                //}
                            }
                            else if (contr[0].GetType().Name == "ComboMi")
                            {
                                ((contr[0]) as ComboMi).drom.Etat = true;
                                ((contr[0]) as ComboMi).IndCombo = "0";
                                ((contr[0]) as ComboMi).textBox1.Text = "";
                                ((contr[0]) as ComboMi).IndCombo = myreads.GetValue(myreads.GetOrdinal("idville")).ToString();
                            }
                        }
                    }
                }
                myreads.Close();
                myread.Close();
            }
            else
            {
                if (!readexiste)
                {


                    int r = 0;
                    grille.Rows.Clear();
                    while (myreads.Read())
                    {
                        grille.Rows.Add();
                        rempgrille(myreads, grille, r);
                        r++;
                    }
                    myreads.Close();
                    myread.Close();
                }
                else
                {
                    
                        grille.Rows.Add();
                        rempgrille(myreads, grille, nrow);
                    //myreads.Close();
                    //myread.Close();

                }
            }
        }


        private void rempgrille(MySqlDataReader myreads, DataGridView grille, int r)
        {
            for (int i = 0; i < myreads.FieldCount; i++)
            {
                if (grille.Columns.Contains("g_" + myreads.GetName(i)) || grille.Columns.Contains("g1_" + myreads.GetName(i)))
                {
                    object val = myreads.GetValue(i);
                    string typechamp = myreads.GetFieldType(i).Name.ToLower();
                    string valret = "";
                    if (val.GetType().Name.ToLower().Contains("null"))
                    {
                        valret = "";
                    }
                    else
                    {
                        if (typechamp == "double" || typechamp == "float" || typechamp == "decimal")
                            valret = getFormatCur(val.ToString());
                        else if (typechamp == "date" || typechamp == "datetime")
                            valret = string.Format("{0:dd.MM.yyyy}", DateTime.Parse(val.ToString()));
                        else
                            valret = myreads.GetString(i);
                        if (grille.Columns.Contains("g1_" + myreads.GetName(i)))
                            grille.Rows[r].Cells["g1_" + myreads.GetName(i)].Value = valret;
                        else
                            grille.Rows[r].Cells["g_" + myreads.GetName(i)].Value = valret;
                    }
                }
            }
        }

        public string getidvaluecombo(ComboBox combname)
        {
            if (combname.SelectedIndex == -1)
                return "-1";
            
            string ret = combname.SelectedValue.ToString();
            return ret;
        }

        public void remplircombo(ComboBox cmb, MySqlCommand mcom, string req)
        {
            //Le nom du combo doit être le nom du champ ID sans "ID";
            myadapt = new MySqlDataAdapter();
            Control fr = (cmb.Parent) as Control;
            /*if (fr.Parent != null)
            {
                fr = (fr.Parent) as Form;
            }*/
            string h = fr.Name;
            
            if (fr.Controls.ContainsKey("lb_" + cmb.Name))
            {

                Control g = fr.Controls.Find("lb_" + cmb.Name, true)[0];
                //lb = g as Label;
                (g as Label).Text = "";
                cmb.SelectedIndexChanged += Cmb_SelectedIndexChanged;
            }
            ComboBox Combval;
            ComboBox Combid;
            if (fr.Controls.ContainsKey("val_" + cmb.Name) == false)
            {
                mcom.CommandText = req;
                myread = mcom.ExecuteReader();
                Combval = new ComboBox();
                Combval.Name = "val_" + cmb.Name;
                fr.Controls.Add(Combval);
                Combval.Visible = false;
                Combid = new ComboBox();
                Combid.Name = "id_" + cmb.Name;
                fr.Controls.Add(Combid);
                Combid.Visible = false;
            }
            else
            {
                ((ComboBox)(fr.Controls["val_" + cmb.Name])).Items.Clear();
                ((ComboBox)(fr.Controls["id_" + cmb.Name])).Items.Clear();
                Combval = ((ComboBox)(fr.Controls["val_" + cmb.Name]));
                Combid = ((ComboBox)(fr.Controls["id_" + cmb.Name]));
            }
            while (myread.Read())
            {
                cmb.Items.Add(myread.GetString(cmb.DisplayMember));
                Combval.Items.Add(myread.GetString(cmb.ValueMember));
                Combid.Items.Add(myread.GetString("id" + cmb.Name));
            }
            myread.Close();

            /*BindingSource bs = new BindingSource();
            System.Data.DataTable tbl = new System.Data.DataTable();
            bs.DataSource = tbl;
            mcom.CommandText = req;
            myadapt.SelectCommand = mcom;
            myadapt.Fill(tbl);
            cmb.DataSource = bs;
            cmb.Update();
            
            if (cmb.Items.Count > 0)
            {
                bs.MoveFirst();
                
                idComb.Items.Add(bs.Current)
            }
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                idComb.Items.Add(bs.)
            }
            */
            if (cmb.Items.Count > 0)
                cmb.SelectedIndex = 0;
        }

        public void TestKey(KeyPressEventArgs e, bool Virgule)
        {

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 13 || e.KeyChar == 8 || e.KeyChar.ToString() == "." || e.KeyChar.ToString() == "," || e.KeyChar.ToString() == "-")
            {
                if (e.KeyChar.ToString() == "," || e.KeyChar.ToString() == ".")
                {
                    if (Virgule == true)
                        e.KeyChar = char.Parse(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    else
                    {
                        e.KeyChar = (char)0;
                        e.Handled = true;
                    }
                }
            }
            else
            {
                e.KeyChar = (char)0;
                e.Handled = true;
            }
        }

        public string formatsqldec(TextBox f)
        {
            string ret = "";
            if (f.Text == "")
                ret = "0.00";
            ret = f.Text.Replace("'", "");
            return ret;
        }

        public string executeSQL(MySqlCommand msom, string table, string champ, string val, int typereq, string cond)
        {
            val = val.Replace("\"", "'");
                string sz = "";
            string[] schamp = champ.Split((char)(','));
            string[] sval = val.Split((char)('$'));
            string ret = "";
            if (typereq == 2) // ajout
            {

                sz += "INSERT INTO " + table + " (" + champ + ") VALUES (";
                val = "";

                for (int i = 0; i < schamp.Length; i++)
                {
                    if (sval[i].Trim().ToLower() != "null")
                    {
                        if (schamp[i].Contains("daty") || schamp[i].Contains("date"))
                            sval[i] = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(sval[i]));
                        if (sval[i].Contains("##"))
                            sval[i] = sval[i].Trim().Replace("##", "");
                        else
                            sval[i] = "\"" + sval[i].Trim() + "\"";
                    }
                    //sval[i] = "\"" + sval[i].Trim() + "\"";
                    if (i == 0)
                        sz += sval[i];
                    else
                        sz += ", " + sval[i];
                }
                sz += ")";

            }
            else if (typereq == 1) //modif
            {
                sz = "UPDATE " + table + " SET ";
                for (int i = 0; i < schamp.Length; i++)
                {
                    if (sval[i].Trim().ToLower() != "null")
                    {
                        if (sval[i].Contains("##"))
                            sval[i] = sval[i].Trim().Replace("##", "");
                        else
                            sval[i] = "\"" + sval[i].Trim() + "\"";
                    }
                    if (i == 0)
                        sz += schamp[i] + "=" + sval[i];
                    else
                        sz += ", " + schamp[i] + "=" + sval[i];
                }
                sz += " WHERE " + cond;
            }
            else if (typereq == 3) //suppr
                sz = "DELETE FROM " + table + " WHERE " + cond;
                msom.CommandText = sz;
            int f = msom.ExecuteNonQuery();
            if (f < 0)
            {
                message_info("Erreur ! Veuillez demander l'admin !");
                return "-1";
            }
            else
            {
                if (typereq == 2)
                    return msom.LastInsertedId.ToString();
                else
                    return "1";
            }

        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Control fr = (sender as ComboBox).Parent as Control;
            Control g = fr.Controls.Find("lb_" + (sender as ComboBox).Name, true)[0];
            Label lb = g as Label;
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                ComboBox b;
                b = (fr.Controls.Find("val_" + (sender as ComboBox).Name, true)[0]) as ComboBox;
                //b.Name = "val_" + (sender as ComboBox).Name;
                lb.Text = b.Items[(sender as ComboBox).SelectedIndex].ToString();
            }
            else
                lb.Text = "";

        }

        public void enablecontrol(Control fr, string tg, bool actif, string tg1 = "", bool actif1 = false, string tg2 = "", bool actif2 = false, string tg3 = "", bool actif3 = false)
        {
            foreach (Control c in fr.Controls)
            {
                if (tg != "")
                {
                    if (c.GetType().Name != "Label" && c.Tag != null)
                    {
                        if (c.Tag.ToString() == tg)
                            c.Enabled = actif;
                        else
                        {
                            if (tg1 != "" && c.Tag.ToString() == tg1)
                                c.Enabled = actif1;
                            else if (tg2 != "" && c.Tag.ToString() == tg2)
                                c.Enabled = actif2;
                            else if (tg3 != "" && c.Tag.ToString() == tg3)
                                c.Enabled = actif3;
                        }
                    }
                }
                else
                {
                    if (c.GetType().Name != "Label")
                        c.Enabled = actif;
                }
            }
        }

        public void readonlycontrol(Control fr, string tg, bool actif, string tg1 = "", bool actif1 = false, string tg2 = "", bool actif2 = false, string tg3 = "", bool actif3 = false)
        {
            foreach (Control c in fr.Controls)
            {
                if (tg != "")
                {
                    if (c.GetType().Name == "TextBox" && c.Tag != null)
                    {
                        if (c.Tag.ToString() == tg)
                            (c as TextBox).ReadOnly = actif;
                        else
                        {
                            if (tg1 != "" && c.Tag.ToString() == tg1)
                                (c as TextBox).ReadOnly = actif1;
                            else if (tg2 != "" && c.Tag.ToString() == tg2)
                                (c as TextBox).ReadOnly = actif2;
                            else if (tg3 != "" && c.Tag.ToString() == tg3)
                                (c as TextBox).ReadOnly = actif3;
                        }
                    }
                }
                else
                {
                    if (c.GetType().Name == "TextBox")
                        (c as TextBox).ReadOnly = actif;
                }
            }
        }


        public void initcontrol(Control fr, string tg, Control firstfocus = null, Control ignorecontrol1 = null, Control ignorecontrol2 = null, Control ignorecontrol3 = null, Control ignorecontrol4 = null)
        {
            foreach (Control c in fr.Controls)
            {
                if ((c.Tag != null && c.Tag.ToString() == tg) || tg == "")
                {
                    if ((ignorecontrol1 != null && c.Name == ignorecontrol1.Name) || (ignorecontrol2 != null && c.Name == ignorecontrol2.Name) || (ignorecontrol3 != null && c.Name == ignorecontrol3.Name) || (ignorecontrol4 != null && c.Name == ignorecontrol4.Name))
                        continue;
                    string typ = c.GetType().Name.ToLower();
                    if (typ == "datetimepicker")
                        (c as DateTimePicker).Value = DateTime.Now;
                    if (typ == "textbox")
                    {
                        c.Text = "";
                        if (c.Name.ToLower().Contains("mtt") || c.Name.ToLower().Contains("prix") || c.Name.ToLower().Contains("exced") || c.Name.ToLower().Contains("rabais") || c.Name.ToLower().Contains("montant") || c.Name.ToLower().Contains("tva") || c.Name.ToLower().Contains("pourcent") || c.Name.ToLower().Contains("taux") || c.Name.ToLower().Contains("tot") || c.Name.ToLower().Contains("frais") || c.Name.ToLower().Contains("hon") || c.Name.ToLower().Contains("int"))
                            c.Text = "0.00";
                        else if (c.Name.ToLower().Contains("nbr"))
                            c.Text = "0";
                    }
                    else if (typ == "maskedtextbox")
                        c.Text = "";
                    else if (typ == "combobox")
                        (c as ComboBox).SelectedIndex = -1;
                    else if (typ == "combomi")
                    {
                        (c as ComboMi).IndCombo = "-1";
                        (c as ComboMi).textBox1.Text = "";
                    }
                    //Control[] clabel;
                    //clabel = fr.Controls.Find("lb_" + c.Name, false);
                    //if (clabel.Length > 0)
                    //    clabel[0].Text = "";

                }
            }
            if (firstfocus != null)
                firstfocus.Focus();
        }

        public void enablemulticontrol(Control fr, string tagActif, string tagNonactif)
        {
            //Active ou désactive des controles dans un conteneur. Mettre les tag séparés par des virgules
            string[] sact = tagActif.Split(',');
            string[] snon = tagNonactif.Split(',');
            
            foreach (Control c in fr.Controls)
            {
                if (c.Tag != null && sact.Contains(c.Tag.ToString()))
                    c.Enabled = true;
                else if (c.Tag != null && snon.Contains(c.Tag.ToString()))
                    c.Enabled = false;
            }
        }

        public string getDateSQL(DateTime date)
        {
            return string.Format("{0:yyyy-MM-dd}", date);
        }

        public string getFormatCur(object tx, bool millier = false)
        {
            string ret = "";
            if (tx.GetType().Name == typeof(string).Name)
            {
                if (tx.ToString() == "null" || tx.ToString() == "")
                    ret = "0";
                else
                    ret = string.Format("{0:#0.00;-#.00;'0.00'}", float.Parse(tx.ToString()));
            }
            else if (tx.GetType().Name == typeof(decimal).Name)
                ret = string.Format("{0:#0.00;-#.00;'0.00'}", tx);

            ret = ret.Replace(",", ".").Replace("%", "");
            if (millier)
            {
                string ret1 = ret;
                try
                {
                    for (int i = ret1.IndexOf(".") - 3; i > 0; i = i - 3)
                        ret1 = ret1.Insert(i, "\'");
                }
                catch { }
                ret = ret1;
            }
            return ret;
        }

        public string miseenformeTel(string tel)
        {
            tel = tel.Replace(" ", "");
            Int64 tmp = 0;
            string ret = "";
            Int64.TryParse(tel, out tmp);
            if (tmp == 0)
                return "";
            if (tmp.ToString().Length <= 10)
                ret = string.Format("041 {0:00 ### ## ##}", tmp);
            else
                ret = string.Format("{0:000 00 ### ## ##}", tmp);

            return ret;
        }

        public void initialisation(Control frm)
        {
            foreach (Control c in frm.Controls)
            {
                if (c.GetType().Name.ToLower() == "textbox" &&
                    ((c as TextBox).Name.ToLower().Contains("tel") || (c as TextBox).Name.ToLower().Contains("fax") || (c as TextBox).Name.ToLower().Contains("mobl")))
                {
                    (c as TextBox).Leave += telleave;
                    (c as TextBox).Enter += telenter;
                    (c as TextBox).KeyPress += telkeypress;

                }
                else if (c.GetType().Name.ToLower() == "textbox" &&
                    ((c as TextBox).Name.ToLower().Contains("nbr")))
                {
                    (c as TextBox).TextAlign = HorizontalAlignment.Right;
                    (c as TextBox).Leave += nbrleave;
                    (c as TextBox).Enter += telenter;
                    (c as TextBox).KeyPress += telkeypress;

                }
                else if (c.GetType().Name.ToLower() == "textbox" &&
                    ((c as TextBox).Name.ToLower().Contains("mtt") || (c as TextBox).Name.ToLower().Contains("exced") || (c as TextBox).Name.ToLower().Contains("rabais") || (c as TextBox).Name.ToLower().Contains("montant") || (c as TextBox).Name.ToLower().Contains("tva") || (c as TextBox).Name.ToLower().Contains("taux") || (c as TextBox).Name.ToLower().Contains("frais")
                     || (c as TextBox).Name.ToLower().Contains("tot") || (c as TextBox).Name.ToLower().Contains("prix") || (c as TextBox).Name.ToLower().Contains("frais")))
                {
                    (c as TextBox).TextAlign = HorizontalAlignment.Right;
                    //(c as TextBox).BackColor = System.Drawing.Color.Red;
                    (c as TextBox).Leave += montantleave;
                    (c as TextBox).Enter += telenter;
                    (c as TextBox).KeyPress += telkeypressvirg;

                }

            }
        }

        private void telleave(Object txb, EventArgs e)
        {
            (txb as TextBox).Text = miseenformeTel((txb as TextBox).Text);
        }

        private void montantleave(Object txb, EventArgs e)
        {
            if ((txb as TextBox).Text.Trim() == "")
                (txb as TextBox).Text = "0.00";
            else
            {
                if ((txb as TextBox).Text.Contains("%"))
                    (txb as TextBox).Text = getFormatCur((txb as TextBox).Text.Replace("%", ""));
                else
                    (txb as TextBox).Text = getFormatCur((txb as TextBox).Text);

            }
        }

        private void nbrleave(Object txb, EventArgs e)
        {
            if ((txb as TextBox).Text.Trim() == "")
                (txb as TextBox).Text = "0";
            else
                (txb as TextBox).Text = ((txb as TextBox).Text.Trim());
        }


        private void telenter(Object txb, EventArgs e)
        {
            (txb as TextBox).Text = (txb as TextBox).Text.Trim().Replace(" ", "");
        }

        private void telkeypress(Object txb, KeyPressEventArgs e)
        {
            TestKey(e, false);
        }

        private void telkeypressvirg(Object txb, KeyPressEventArgs e)
        {
            TestKey(e, true);
        }

        public void RemplirGrilleAuto(DataGridView Grille, string Rekety, MySqlCommand SQLCom, MySqlDataAdapter SQLAdapt)
        {
            BindingSource bs = new BindingSource();
            DataTable table = new DataTable();
            bs.DataSource = table;

            SQLCom.CommandText = Rekety;

            SQLAdapt.SelectCommand = SQLCom;
            Grille.AutoGenerateColumns = true;
            SQLAdapt.Fill(table);
            Grille.DataSource = bs;

        }
    }

    
}
