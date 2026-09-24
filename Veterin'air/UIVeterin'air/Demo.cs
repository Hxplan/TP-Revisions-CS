using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterin_air;

namespace UIVeterin_air
{
    public static class Demo
    {

        public static void demo1_CreationObjets()
        {
            Proprietaire unProprietaire = new Proprietaire("jean", "Dupont", 250);

            unProprietaire.setMotif(MotifConsultation.ControleAnnuel);
            unProprietaire.setMoyPaiement(MoyenPaiement.CarteBancaire);       

            Console.WriteLine(unProprietaire.ToString());

            Animal unAnimal = new Animal("chat",12,10,"156898560486587",Espece.Felin);
            unProprietaire.addAnimal(unAnimal);

            Console.WriteLine(unProprietaire.ToString());

        }
    }
}
