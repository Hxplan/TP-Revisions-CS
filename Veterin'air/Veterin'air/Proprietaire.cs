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

        private string _nom = "Inconnu";
        
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

        public string nomComplet
        {
            get { return prenom + " " + nom; }
        }

        #endregion

        #region Accesseurs (getteurs/setteurs) 

        // Get/Set nom
        public string getNom()
        {
            return nom;
        }

        public void setNom(string nom)
        {
            this.nom = nom;
        }

        // Get/Set prenom
        public string getPrenom()
        {
            return prenom;
        }

        public void setPrenom(string prenom)
        {
            this.prenom = prenom;
        }

        // Get/Set soldeCompte
        public float getSolde()
        {
            return soldeCompte;
        }

        public void setSolde(float soldeCompte)
        {
            this.soldeCompte = soldeCompte;
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

        //Get/Set Motif
        public MotifConsultation getMotif()
        {
            return _motif;
        }

        public void setMotif(MotifConsultation motif)
        {
            _motif = motif;
        }


        //Get/Set Moyen de paiement
        public MoyenPaiement getMoyPaiement()
        {
            return _moyPaiement;
        }

        public void setMoyPaiement(MoyenPaiement moyPaiement)
        {
            _moyPaiement = moyPaiement;
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

        public Proprietaire(string nom, string prenom, float soldeCompte, MotifConsultation motif)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
            this._motif = motif;
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
            addLesAnimaux(lesAnimaux);
        }

        public Proprietaire(string nom, string prenom, float soldeCompte, List<Animal> lesAnimaux, MotifConsultation motif)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
            addLesAnimaux(lesAnimaux);
            this._motif = motif;
        }

        public Proprietaire(string nom, string prenom, float soldeCompte, List<Animal> lesAnimaux, MotifConsultation motif, MoyenPaiement moyPaiement)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.soldeCompte = soldeCompte;
            addLesAnimaux(lesAnimaux);
            this._motif = motif;
            this._moyPaiement = moyPaiement;
        }

        #endregion

        #region Méthodes

        // Ajouter un animal à la liste du propriétaire
        public List<Animal> addAnimal(Animal unAnimal)
        {
            VerifierAjoutAnimal(unAnimal);
            if (!lesAnimaux.Contains(unAnimal))
            {
                lesAnimaux.Add(unAnimal);
            }
            unAnimal.leProprietaire = this;
            return getLesAnimaux();
        }

        private void VerifierAjoutAnimal(Animal unAnimal)
        {
            if (unAnimal == null)
                throw new ArgumentNullException(nameof(unAnimal), "L'animal est obligatoire.");
            if (unAnimal.leProprietaire != null && unAnimal.leProprietaire != this)
                throw new InvalidOperationException("Cet animal appartient déjà à un autre propriétaire.");
            if (lesAnimaux.Any(a => a != unAnimal && string.Equals(a.numeroPuce, unAnimal.numeroPuce, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Un animal possède déjà ce numéro de puce.");
        }


        // Ajouter une liste d'animal à la liste du propriétaire
        public List<Animal> addLesAnimaux(List<Animal> lesAnimaux)
        {
            if (lesAnimaux == null)
                throw new ArgumentNullException(nameof(lesAnimaux));
            foreach (Animal unAnimal in lesAnimaux)
                VerifierAjoutAnimal(unAnimal);
            if (lesAnimaux.Distinct().GroupBy(a => a.numeroPuce, StringComparer.OrdinalIgnoreCase).Any(g => g.Count() > 1))
                throw new ArgumentException("Plusieurs animaux possèdent le même numéro de puce.");
            foreach (Animal unAnimal in lesAnimaux)
            {
                addAnimal(unAnimal);
            }
            return getLesAnimaux();
        }

        // Retirer un animal de le liste du propriétaire
        public List<Animal> rmAnimal(int index)
        {
            if (index < 0 || index >= lesAnimaux.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Sélectionnez un animal existant.");
            Animal animal = lesAnimaux[index];
            lesAnimaux.RemoveAt(index);
            if (animal.leProprietaire == this)
                animal.leProprietaire = null;
            return getLesAnimaux();
        }

        // Deposer de l'argent sur le compte du propriétaire
        public float deposerCompte(float montant)
        {
            if (float.IsNaN(montant) || float.IsInfinity(montant) || montant <= 0)
                throw new ArgumentException("Le dépôt doit être strictement positif.");
            this.soldeCompte += montant;
            return this.soldeCompte;
        }

        // Soiger un animal du propriétaire en déclarant le motif
        public void faireSoigner(Animal unAnimal, MotifConsultation leMotif)
        {
            VerifierAnimalDuProprietaire(unAnimal);

            float tarif;

            switch (leMotif)
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
                    throw new ArgumentOutOfRangeException(nameof(leMotif), "Motif de consultation non reconnu.");
            }

            this.facturer(tarif);
            _motif = leMotif;
        }

        // facturer le propriétaire
        public void facturer(float tarif)
        {
            if (float.IsNaN(tarif) || float.IsInfinity(tarif) || tarif <= 0)
                throw new ArgumentException("Le tarif doit être strictement positif.");
            if (soldeCompte < tarif)
                throw new InvalidOperationException("Le solde du propriétaire est insuffisant.");
            this.soldeCompte -= tarif;
        }


        public void nourrirAnimal(Animal unAnimal, RegimeAlimentaire typeRegime)
        {
            string messageException = "";
            bool mauvaisRegime = false;

            if (!lesAnimaux.Contains(unAnimal))
            {
                messageException = $"L'animal '{unAnimal.nom}' n'appartient pas à ce propriétaire.";
                
            }

            if (unAnimal.testRegimeAlimentaire(typeRegime))
            {
                messageException = $"Régime Alimentaire de '{unAnimal.nom}' non respecté, son régime alimentaire est ";
                mauvaisRegime = true;
            }

            int gainGrammes;

            switch (typeRegime)
            {
                case RegimeAlimentaire.Carnivore:
                    gainGrammes = 300; 
                    break;

                case RegimeAlimentaire.Herbivore:
                    gainGrammes = 150; 
                    break;

                case RegimeAlimentaire.Omnivore:
                    gainGrammes = 200; 
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(typeRegime), "Type d'aliment invalide.");
            }

            if (messageException != "")
            {
                

                if (mauvaisRegime)
                {
                     // On renseigne la liste dans l'exception

                    foreach (RegimeAlimentaire unRegime in unAnimal.LesRegimesAlimentaires)
                        messageException += "\n" + "- " + unRegime.ToString();
                }
                Exception animalEx = new Exception(messageException);
                animalEx.Data["régime"] = unAnimal.LesRegimesAlimentaires;
                throw animalEx;
            }

            unAnimal.Grossir(gainGrammes);

        }

        private void VerifierAnimalDuProprietaire(Animal unAnimal)
        {
            if (unAnimal == null)
                throw new ArgumentNullException(nameof(unAnimal));
            if (!lesAnimaux.Contains(unAnimal) || unAnimal.leProprietaire != this)
                throw new InvalidOperationException("Cet animal n'appartient pas à ce propriétaire.");
        }
        #endregion

        #region Méthodes redéfinie

        public override string ToString()
        {
            string description = this.prenom + " " + this.nom +"\n" +
                "Solde de : " + this.soldeCompte + " €\n" +
                "Moyen de paiement : " + this._moyPaiement + "\n";

            description += "\nListe des animaux de compagnie ("+ lesAnimaux.Count() +"): \n";

            if(this.lesAnimaux.Count() == 0)
            {
                description += "    - aucun animal de compagnie\n";
                return description;
            }
            else
            {
                foreach (Animal unAnimal in lesAnimaux)
                {
                    description += unAnimal.ToString() + "\n";
                }
                return description;
            }
            
        }

        #endregion

    }
}
