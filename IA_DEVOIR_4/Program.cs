using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

////
///     Nom: ISAAC Sammuel Ramclief
///     Cours: Introduction à l'intelligence artificielle
///     Devoir: Devoir 4
///             -> Jeu de Dames
///             
///     ****    VOIR LE FICHIER Form1.cs    ****
///

namespace IA_DEVOIR_4
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
