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
            Application.Run(new UI());

            #region Demo

            //Demo.demo1_CreationObjets();

            //Demo.demo2_NourirAnimal();
<<<<<<< Updated upstream

            //Demo.demo3_NourirAnimalException();

            //Demo.demo4_NourirAnimalException2();

            Demo.demo5_SoignerAnimal();
            #endregion
=======
>>>>>>> Stashed changes
        }
    }
}
