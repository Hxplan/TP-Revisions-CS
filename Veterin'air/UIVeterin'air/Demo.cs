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
            Console.WriteLine("===== Création du propriétaire =====");
            Proprietaire unProprietaire = new Proprietaire("jean", "Dupont", 250);

            unProprietaire.setMotif(MotifConsultation.ControleAnnuel);
            unProprietaire.setMoyPaiement(MoyenPaiement.CarteBancaire);       

            Console.WriteLine(unProprietaire.ToString());

            Console.WriteLine("===== Ajout d'un animal =====");
            Animal unAnimal = new Animal("chat",12, 10000, "156898560486587",Espece.Felin);
            unProprietaire.addAnimal(unAnimal);

            Console.WriteLine(unProprietaire.ToString());

        }

        public static void demo2_NourirAnimal()
        {
            Proprietaire unProprietaire = new Proprietaire("Dupont", "Jean");

            Animal monChat = new Animal("chat", 12, 10000, "156898560486587", Espece.Felin);
            monChat.AddUnRegimeAlimentaire(RegimeAlimentaire.Carnivore);

            unProprietaire.addAnimal(monChat);

            Console.WriteLine("===== Nourir =====");
            Console.WriteLine(monChat.ToString());
            unProprietaire.nourrirAnimal(monChat, RegimeAlimentaire.Carnivore);
            Console.WriteLine(monChat.ToString());

        }

        public static void demo3_NourirAnimalException()
        {

            Proprietaire unProprietaire = new Proprietaire("Dupont", "Jean");

            Animal monChat = new Animal("chat", 12, 10000, "156898560486587", Espece.Felin);
            monChat.AddUnRegimeAlimentaire(RegimeAlimentaire.Carnivore);

            unProprietaire.addAnimal(monChat);

            Console.WriteLine("===== Nourir =====");

            unProprietaire.nourrirAnimal(monChat, RegimeAlimentaire.Herbivore);
            Console.WriteLine(monChat.ToString());

        }

        public static void demo4_NourirAnimalException2()
        {

            Proprietaire unProprietaire = new Proprietaire("Dupont", "Jean");

            Animal monChat = new Animal("chat", 12, 10000, "156898560486587", Espece.Felin);
            monChat.AddUnRegimeAlimentaire(RegimeAlimentaire.Carnivore);

            //unProprietaire.addAnimal(monChat);

            Console.WriteLine("===== Nourir =====");

            unProprietaire.nourrirAnimal(monChat, RegimeAlimentaire.Carnivore);
            Console.WriteLine(monChat.ToString());

        }

        public static void demo5_SoignerAnimal()
        {

            Proprietaire unProprietaire = new Proprietaire("Dupont", "Jean");

            Animal monChien = new Animal("chien", 7, 15000, "789541048658745", Espece.Canide);
            monChien.AddUnRegimeAlimentaire(RegimeAlimentaire.Carnivore);

            unProprietaire.addAnimal(monChien);

            Console.WriteLine("===== Soigner =====");

            unProprietaire.faireSoigner(monChien);
            Console.WriteLine(monChien.ToString());

        }
    }
}
