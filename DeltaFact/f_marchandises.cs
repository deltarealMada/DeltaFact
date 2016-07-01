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
    public partial class f_marchandises : Form
    {
        public f_marchandises()
        {
            InitializeComponent();
        }

        util_fact uf = new util_fact();

        private void f_marchandises_Load(object sender, EventArgs e)
        {
            connection();
            //remplir les combos
            uf.remplircombo(client, comrealvista, "SELECT socligne as client, idclient FROM client ORDER BY idclient ");
            uf.remplircombo(unite, comrealvista, "SELECT unitecode, unitelibelle, idunite FROM fact_unite ORDER BY unitecode");
            affichedonnees();
            uf.enablecontrol(p_affiche, "2", false);
            uf.enablemulticontrol(p_button, "1", "2,3");
        }

        private void connection()
        {
            conrealvista.ConnectionString = "Server=localhost;UserId =root;Password=realvista;Database=realvista";
            try
            {
                conrealvista.Open();
                
            }
            catch
            {
                uf.message_info(this, "Erreur de Connection !");
            }
            
        }

        private void affichedonnees()
        {
            string sz = "select idarticle, client.idclient, codearticle, descriptif, remarque, concat(unitecode, ' ', unitelibelle) as unite, prix FROM fact_articles " +
                "LEFT JOIN client ON client.idclient = fact_articles.idclient LEFT JOIN fact_unite ON fact_unite.idunite = fact_articles.idunite ORDER BY codearticle";
            uf.afficherInfo(this, sz, comrealvista, false);
        }

        private void bt_modif_Click(object sender, EventArgs e)
        {
            modifajout();
        }

        private void annule()
        {
            uf.enablemulticontrol(p_button, "1", "2");
            uf.enablecontrol(p_affiche, "2", false);
        }

        private void modifajout()
        {
            uf.enablemulticontrol(p_button, "2", "1");
            uf.enablecontrol(p_affiche, "2", true);
        }

        private void bt_ajout_Click(object sender, EventArgs e)
        {
            modifajout();
        }

        private void bt_annul_Click(object sender, EventArgs e)
        {
            annule();
        }
    }
}
