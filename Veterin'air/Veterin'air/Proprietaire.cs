using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterin_air
{
    public class Proprietaire
    {
        #region Champs privés

        private string _nom = "Inconnnu";
        
        private string _prenom = "Inconnu";

        private float _soldeCompte = 0;

        private List<Animal> lesAnimaux = new List<Animal>();

        #endregion

        #region Propriétés

        public string nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public float soldeCompte
        {
            get { return _soldeCompte; }
            set { _soldeCompte = value; }
        }

        #endregion

        #region Accesseurs (getteurs/setteurs) 

        // Get/Set nom
        public string getNom()
        {
            return _nom;
        }

        public void setNom(string nom)
        {
            _nom = nom;
        }

        // Get/Set prenom
        public string getPrenom()
        {
            return _prenom;
        }

        public void setPrenom(string prenom)
        {
            _prenom = prenom;
        }

        // Get/Set soldeCompte
        public string getSolde()
        {
            return _nom;
        }

        public void setSolde(float soldeCompte)
        {
            _soldeCompte = soldeCompte;
        }

        // Get / modif de la liste des animaux
        public List<Animal> getLesAnimaux()
        {
            List<Animal> copieDesAnimaux = new List<Animal>();

            foreach (Animal unAnimal in lesAnimaux)
            {
                copieDesAnimaux.Add(unAnimal);
            }
            return copieDesAnimaux;
        }
        public List<Animal> addAnimal(Animal unAnimal)
        {
            lesAnimaux.Add(unAnimal);
            return lesAnimaux;
        }

        public List<Animal> AddLesAnimaux(List<Animal> lesAnimaux)
        {
            foreach (Animal unAnimal in lesAnimaux)
            {
                lesAnimaux.Add(unAnimal);
            }
            return lesAnimaux;
        }

        #endregion

        #region Constructeurs 

        public Proprietaire()
        {

        }

        public Proprietaire(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public Proprietaire(string nom, string prenom, float soldeCompte)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
        }

        public Proprietaire(string nom, string prenom, float soldeCompte, List<Animal> lesAnimaux)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
            this.lesAnimaux = lesAnimaux;
        }

        #endregion

        #region Méthodes



        #endregion

        #region Méthodes redéfinie



        #endregion

    }
}
