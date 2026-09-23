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

        private MotifConsultation _motif = MotifConsultation.Inconnu;

        private MoyenPaiement _moyPaiement = MoyenPaiement.Inconnu;

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

        // Get animaux
        public List<Animal> getLesAnimaux()
        {
            List<Animal> copieDesAnimaux = new List<Animal>();

            foreach (Animal unAnimal in lesAnimaux)
            {
                copieDesAnimaux.Add(unAnimal);
            }
            return copieDesAnimaux;
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

        public Proprietaire(string nom, string prenom, float soldeCompte, MotifConsultation motif, MoyenPaiement moyPaiement)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
            this._motif = motif;
            this._moyPaiement = moyPaiement;
        }

        public Proprietaire(string nom, string prenom, float soldeCompte, List<Animal> lesAnimaux)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
            this.lesAnimaux = lesAnimaux;
        }

        public Proprietaire(string nom, string prenom, float soldeCompte, List<Animal> lesAnimaux, MotifConsultation motif, MoyenPaiement moyPaiement)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
            this.lesAnimaux = lesAnimaux;
            this._motif = motif;
            this._moyPaiement = moyPaiement;
        }

        #endregion

        #region Méthodes

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

        public List<Animal> rmAnimal(int index)
        {
            lesAnimaux.RemoveAt(index);
            return lesAnimaux;
        }

        public void soigner(Animal unAnimal, MotifConsultation leMotif)
        {
            string messageException = "";

            float tarif;

            switch (_motif)
            {
                case MotifConsultation.ControleAnnuel:
                    tarif = 35;
                    break;

                case MotifConsultation.Vaccination:
                    tarif = 55;
                    break;

                case MotifConsultation.Identification:
                    tarif = 70;
                    break;

                case MotifConsultation.Chirurgie:
                    tarif = 250;
                    break;

                case MotifConsultation.Urgence:
                    tarif = 120;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_motif), "Motif de consultation non reconnu.");
            }

            if (this.soldeCompte < tarif)
            {
                messageException += "\nAttention, le solde est insuffisant !";
            }

        } 

        #endregion

        #region Méthodes redéfinie

        public override string ToString()
        {
            string description = this.nom + " [" + this.soldeCompte + " €]";

            description += "\nListe des animaux de compagnie : \n";

            foreach (Animal unAnimal in lesAnimaux)
            {
                description += "    - " + unAnimal.ToString() + "\n";
            }
            return description;
        }

        #endregion

    }
}
