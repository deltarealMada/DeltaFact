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
    public partial class f_selection : Form
    {
        MainForm Fmain = (MainForm)(Application.OpenForms["MainForm"]);
        util_fact uf = new util_fact();
        public string condition = "";
        public f_selection()
        {
            InitializeComponent();
        }

        private void f_selection_Load(object sender, EventArgs e)
        {
            chargerclient(condition);
        }

        public void chargerclient(string cond)
        {
            gv_client.Visible = true;
            string reqdon = "select cli.idclient as refclient, socligne as raisonsociale, pol.idlangue as idlanguage, lang.language as language, " +
                "cli.idpolitesse as idpolitesse, pol.politesse as politesse, cli.nom, cli.prenom, cli.co, " +
                "cli.adresse1 as adresse1, cli.adresse2 as adresse2, city.zip as npa, city.cityname as ville, " +
                "cli.idville as idville, cli.telpro as telpro, cli.telmob as telmob, " +
                "cli.fax as fax, cli.email as email " +
                "FROM fact_client cli " +
                "LEFT join " + Fmain.baseInit + ".typepolitesse pol ON pol.idpolitesse = cli.idpolitesse LEFT join " + Fmain.baseInit + ".language lang ON lang.idlanguage = pol.idlangue " +
                "left join " + Fmain.baseInit + ".city ON city.idcity = cli.idville " + cond +
                " ORDER BY nom, prenom, socligne";
            uf.afficherInfo(this, reqdon, comrealvistamod, gv_client, "");

        }

        public string idselection = "";
        private void gv_client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gv_client.RowCount > 0)
            {
                idselection = gv_client.CurrentRow.Cells["g_refclient"].FormattedValue.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
