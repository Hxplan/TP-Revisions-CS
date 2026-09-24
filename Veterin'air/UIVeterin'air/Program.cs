using System;
using System.Windows.Forms;

namespace UIVeterin_air
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UI());

            Demo.demo1_CreationObjets();
           
        }
    }
}
