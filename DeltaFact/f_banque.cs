using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DeltaFact
{
    public partial class f_banque : Form
    {
        util_fact Util = new util_fact();
        MySqlDataReader myread;
        public string idbanque;
        public f_banque()
        {
            InitializeComponent();
        }

        private void charger()
        {
            string sql = "SELECT * from " + (Application.OpenForms["MainForm"] as MainForm).baseInit + ".cpta_banque order by idbanque";
            //DeltaSQLTmp.CommandText = sql;
            Util.RemplirGrilleAuto(gvins, sql, DeltaSQLTmp, mySqlDataAdapter1);
            //Util.afficherInfo(null, sql, DeltaSQLTmp, gvins);
        }

        private void gvins_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idbanque = gvins.Rows[e.RowIndex].Cells["idbanque"].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void f_banque_Load(object sender, EventArgs e)
        {
            //charger();
        }

        private void ed_cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.TestKey(e, false);
            if (e.KeyChar == 13)
            {
                recherchebanque();
            }
        }

        private void ed_sic_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.TestKey(e, false);
            if (e.KeyChar == 13)
            {
                recherchebanque();
            }
        }

        private void ed_nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                recherchebanque();
            }
        }

        private void recherchebanque()
        {
            string cond = "";

            if (ed_cb.Text.Trim() != "")
                cond = "nocb = " + ed_cb.Text.Trim();
            if (ed_sic.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "nosic = " + ed_sic.Text.Trim();
                else
                    cond += " AND nosic = " + ed_sic.Text.Trim();
            }

            if (ed_nom.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "nombanque LIKE '%" + ed_nom.Text.Trim() + "%' OR nomabrege LIKE '%" + ed_nom.Text.Trim() + "%'";
                else
                    cond += " AND (nombanque LIKE '%" + ed_nom.Text.Trim() + "%' OR nomabrege LIKE '%" + ed_nom.Text.Trim() + "%')";
            }
            if (cond != "")
                cond = " WHERE " + cond;
            string sql = "SELECT * from " + (Application.OpenForms["MainForm"] as MainForm).baseInit + ".cpta_banque " + cond;
            //Util.afficherInfo(null, sql, DeltaSQLTmp, gvins);
            Util.RemplirGrilleAuto(gvins, sql, DeltaSQLTmp, mySqlDataAdapter1);

        }

        private void bt_tout_Click(object sender, EventArgs e)
        {
            charger();
        }
    }
}
