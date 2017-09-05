using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaFact
{
    
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Globalization.CultureInfo aa = new System.Globalization.CultureInfo("fr-FR", true);
            aa.NumberFormat.NumberGroupSeparator = " ";
            aa.NumberFormat.NumberDecimalSeparator = ".";
            aa.NumberFormat.CurrencyGroupSeparator = " ";
            aa.NumberFormat.CurrencyDecimalSeparator = ".";
            aa.DateTimeFormat.DateSeparator = ".";
            aa.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";

            Application.CurrentCulture = aa;
            Application.Run(new MainForm());
        }
        public static string variableglobale = "lklk";
    }


}
