using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DeltaFact
{
    class util_fact
    {
        MySqlDataReader myread;
        MySqlDataReader myread1;
        MySqlDataAdapter myadapt;
        string typecur = "decimal double float single";

        public void message_info(IWin32Window sender, string texte)
        {
            MessageBox.Show(sender, texte, "Information");
        }

        public void afficherInfo(IWin32Window sender, string sql, MySqlCommand mycom, bool grille)
        {
            
            mycom.CommandText = sql;
            myread = mycom.ExecuteReader();

            if (!grille)
            {
                if (myread.Read())
                {
                    //parcours des champs du reader en comparaison avec les champs existants dans la fenêtre
                    //Si grille false
                    for (int i = 0; i < myread.FieldCount; i++)
                    {
                        //Form ff = ((mycom.Container) as Form);

                        Control[] contr = (sender as Form).Controls.Find(myread.GetName(i), true);
                        if (contr.Length > 0)
                        {

                            if (contr[0].GetType().Name == "TextBox")
                            {
                                if (typecur.Contains(myread.GetFieldType(i).Name.ToLower()))
                                    ((contr[0]) as TextBox).Text = getFormatCur(myread.GetValue(i).ToString());
                                else if (myread.GetFieldType(i).Name.ToLower().Contains("date"))
                                    ((contr[0]) as TextBox).Text = string.Format("{0:dd.MM.yyyy}", myread.GetDateTime(i));
                                else // if (myread.GetFieldType(i).Name.ToLower() == "varchar")
                                    ((contr[0]) as TextBox).Text = myread.GetValue(i).ToString();
                            }
                            else if (contr[0].GetType().Name == "MaskedTextBox")
                            {
                                //((contr[0]) as MaskedTextBox).Text = myread.GetValue(i).ToString();
                                if (typecur.Contains(myread.GetFieldType(i).Name.ToLower()))
                                    ((contr[0]) as MaskedTextBox).Text = getFormatCur(myread.GetValue(i).ToString());
                                else if (myread.GetFieldType(i).Name.ToLower().Contains("date"))
                                    ((contr[0]) as MaskedTextBox).Text = string.Format("{0:dd.MM.yyyy}", myread.GetDateTime(i));
                                else // if (myread.GetFieldType(i).Name.ToLower() == "varchar")
                                    ((contr[0]) as MaskedTextBox).Text = myread.GetValue(i).ToString();
                            }
                            else if (contr[0].GetType().Name == "ComboBox")
                            {
                                ((contr[0]) as ComboBox).SelectedValue = myread.GetValue(i).ToString();
                            }
                        }
                    }
                }
                myread.Close();
            }
            else
            {

            }
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

            mcom.CommandText = req;
            myread = mcom.ExecuteReader();
            ComboBox Combval = new ComboBox();
            Combval.Name = "val_" + cmb.Name;
            fr.Controls.Add(Combval);
            Combval.Visible = false;
            ComboBox Combid = new ComboBox();
            Combid.Name = "id_" + cmb.Name;
            fr.Controls.Add(Combid);
            Combid.Visible = false;
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

        public void enablecontrol(Control fr, string tg, bool actif)
        {
            foreach (Control c in fr.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == tg)
                    c.Enabled = actif;
            }
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

        public string getFormatCur(string tx)
        {
            string ret;
            if (tx == "null")
                ret = "0";
            ret = string.Format("{0:#0.00;-#.00;'0.00'}", float.Parse(tx));
            ret = ret.Replace(",", ".");
            string ret1 = ret;
            try
            {
                for (int i = ret1.IndexOf(".") - 3; i > 0; i = i - 3)
                    ret1 = ret1.Insert(i, "\'");
            }
            catch { }
            return ret;
        }
    }

    
}
