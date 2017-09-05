using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Utils;

namespace DeltaFact
{
    public partial class f_selcode : Form
    {
        private util_fact Ul;
        private MySqlDataReader sqlReader;
        private int idProv;
        private int iId;
        

        public f_selcode()
        {
            InitializeComponent();
            Ul = new util_fact();
        }

        public bool trouve = false;
        public string code = "";
        public string idcode = "";
        public string lib = "";
        public string unite = "";
        public string prix = "";
        public string rabaispourcent = "";
        public string rabaismontant = "";
        public string idrabais = "";
        public string idprix = "";

        public DateTime datyfact = DateTime.Now;
        public bool first = false;
        public void Initialisation()
        {
            string reqrechart = "";
            reqrechart = "SELECT article.idarticle as idcodearticle, codearticle, descriptif_ligne1, descriptif_ligne2, unitelibelle as unitecode, prix.idprix, if(isnull(rabais.idrabais), 0, rabais.idrabais) as idrabais, prix.prix, if(isnull(rabais.rabaispourcent), 0, rabais.rabaispourcent) as rabaispourcent, if(rabais.rabaispourcent > 0, prix.prix*rabais.rabaispourcent/100, if(isnull(rabais.rabaismontant), 0, rabais.rabaismontant)) as rabaismontant from fact_articles article " +
                "left join (select idprix, idarticleprix, prix, dateprix from fact_prix group by idarticleprix, idprix order by dateprix desc) prix on prix.idarticleprix = article.idarticle and prix.dateprix <= '" + string.Format("{0:yyyy-MM-dd}", datyfact) + "' " +
                "LEFT JOIN (Select idrabais, idarticlerabais, rabaismontant, rabaispourcent, daterabaisde, daterabaisa FROM fact_rabais group by idarticlerabais, idrabais order by daterabaisa desc) rabais ON rabais.idarticlerabais = article.idarticle AND '" + string.Format("{0:yyyy-MM-dd}", datyfact) + "' between rabais.daterabaisde and rabais.daterabaisa " +

                "INNER Join fact_unite unite ON unite.idunite = article.idunite ";
            if (edcode.Text.Trim() == "")
            {
                Ul.afficherInfo(null, reqrechart + "  ORDER BY codearticle ", DeltaSQLCon, dgView);
            }
            else
            {
                if (first)
                    reqrechart += " WHERE article.codearticle = '" + edcode.Text.Trim() + "'";
                else
                    reqrechart += " WHERE codearticle LIKE '" + edcode.Text.Trim() + "%' ORDER BY codearticle LIKE '" + edcode.Text.Trim() + "%' desc, codearticle, descriptif_ligne1";
                Ul.afficherInfo(null, reqrechart, DeltaSQLCon, dgView);
                if (dgView.RowCount == 0)
                {
                    edcode.Text = edcode.Text.Substring(0, 1);
                    trouve = false;
                    first = false;
                    Initialisation();
                }
                else if (dgView.RowCount == 1)
                {
                    code = dgView.Rows[0].Cells["g_codearticle"].FormattedValue.ToString();
                    idcode = dgView.Rows[0].Cells["g_idcodearticle"].FormattedValue.ToString();
                    lib = dgView.Rows[0].Cells["g_descriptif_ligne1"].FormattedValue.ToString();
                    unite = dgView.Rows[0].Cells["g_unitecode"].FormattedValue.ToString();
                    prix = dgView.Rows[0].Cells["g_prix"].FormattedValue.ToString();
                    rabaismontant = dgView.Rows[0].Cells["g_rabaismontant"].FormattedValue.ToString();
                    rabaispourcent = dgView.Rows[0].Cells["g_rabaispourcent"].FormattedValue.ToString();
                    idrabais = dgView.Rows[0].Cells["g_idrabais"].FormattedValue.ToString();
                    idprix = dgView.Rows[0].Cells["g_idprix"].FormattedValue.ToString();
                    trouve = true;
                    first = false;
                }
                else
                {
                    this.Show();
                    trouve = false;
                    first = false;
                }
            }
            
            //gv_City.Columns[3].Visible = false;
        }


        private void F_langues_Load(object sender, EventArgs e)
        {
            //Initialisation();
        }

        public void recherche()
        {
            
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            idcode = code = lib = prix = unite = "";
            trouve = false;
            this.Hide();
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            trouve = false;
            idcode = code = lib = prix = unite = "";
            if (dgView.SelectedRows.Count > 0)
            {
                code = dgView.SelectedRows[0].Cells["g_codearticle"].FormattedValue.ToString();
                idcode = dgView.SelectedRows[0].Cells["g_idcodearticle"].FormattedValue.ToString();
                lib = dgView.SelectedRows[0].Cells["g_descriptif_ligne1"].FormattedValue.ToString();
                unite = dgView.SelectedRows[0].Cells["g_unitecode"].FormattedValue.ToString();
                prix = dgView.SelectedRows[0].Cells["g_prix"].FormattedValue.ToString();
                trouve = true;

                this.Hide();
                (Application.OpenForms["f_gesfact"] as f_gesfact).remplirarticle();
            }
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void edcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Ul.TestKey(e, false);
            if (e.KeyChar == 13)
            {
                Initialisation();
            }
        }
    }
}
