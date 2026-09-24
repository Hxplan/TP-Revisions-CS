using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterin_air
{
    public class Animal
    {

        #region Champs
        private string _nom;
        private int _age;
        private float _poids; //en gramme
        private string _numeroPuce;

        private Espece _espece;
        public const float PoidsMaximum = 1000000f; // 1 000 kg, exprimés en grammes. 
        private List<RegimeAlimentaire> lesRegimesAlimentaires = new List<RegimeAlimentaire>();
        private Proprietaire _leProprietaire;

        #endregion

        #region Propriétés

        public string nom
        {
            get { return _nom; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le nom ne peut pas être vide ou nul.");
                }
                _nom = value.Trim();
            }
            
        }

        public int age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException("L'âge doit être compris entre 0 et 50.");
                }
                _age = value;
               

            }
        }

        public float poids
        {
            get { return _poids; }
            set
            {
                if (float.IsNaN(value) || float.IsInfinity(value) || value < 0 || value > PoidsMaximum)
                {

                    throw new ArgumentException("Le poids doit être compris entre 0 et 1 000 000 grammes.");
                }
                _poids = value;
            }
        }

        public string numeroPuce
        {
            get { return _numeroPuce; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 15 || !value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Le numéro de puce doit être composé de 15 caractères.");
                }
                _numeroPuce = value;
            }
        }

        public Espece espece
        {
            get { return _espece; }
            set
            {
                if (!Enum.IsDefined(typeof(Espece), value))
                    throw new ArgumentException("Espèce non reconnue.");
                _espece = value;
            }
        }

        public string RegimesAlimentairesDescription
        {
            get { return string.Join(", ", lesRegimesAlimentaires); }
        }

        public List<RegimeAlimentaire> LesRegimesAlimentaires
        {
            get
            {
                List<RegimeAlimentaire> copie = new List<RegimeAlimentaire>();
                foreach (RegimeAlimentaire unRegime in lesRegimesAlimentaires)
                {
                    copie.Add(unRegime);
                }
                return copie;
            }
        }

        public Proprietaire leProprietaire
        {
            get { return _leProprietaire; }
            set { _leProprietaire = value; }
        }


        #endregion

        #region Accesseurs (getteurs/setteurs)

        public string getNom()
        {
            return nom;
        }

        public void setNom(string nom)
        {
            this.nom = nom;
        }

        public int getAge()
        {
            return age;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public float getPoids()
        {
            return poids;
        }

        public void setPoids(float poids)
        {
            this.poids = poids;
        }

        public string getNumeroPuce()
        {
            return numeroPuce;
        }

        public void setNumeroPuce(string numeroPuce)
        {
            this.numeroPuce = numeroPuce;
        }

        public Espece getEspece()
        {
            return espece;
        }

        public void setEspece(Espece espece)
        {
            this.espece = espece;
        }

        public Proprietaire getLeProprietaire()
        {
            return leProprietaire;
        }

        public void setLeProprietaire(Proprietaire leProprietaire)
        {
            this.leProprietaire = leProprietaire;
        }

        public List<RegimeAlimentaire> getLesRegimesAlimentaires()
        {
            return LesRegimesAlimentaires;
        }

        #endregion

        #region Constructeurs

        public Animal()
        {
            _nom = "Inconnu";
            _age = 0;
            _poids = 0.0f;
            _numeroPuce = "000000000000000";
            _espece = Espece.Inconnu;
        }

        public Animal(string nom, int age, float poids, string numeroPuce, Espece espece)
        {
            this.nom = nom;
            this.age = age;
            this.poids = poids;
            this.numeroPuce = numeroPuce;
            this.espece = espece;
        }

        #endregion

        #region Methodes
        public void Vieillir()
        {
            age++;
        }

        public void Grossir(float poids)
        {
            VerifierVariationPoids(poids);
            this.poids += poids;
        }

        public void FaireduSport(float poids)
        {
            VerifierVariationPoids(poids);
            this.poids -= poids;
        }

        public void Peser(float poids)
        {
            this.poids = poids;
        }

        private static void VerifierVariationPoids(float quantite)
        {
            if (float.IsNaN(quantite) || float.IsInfinity(quantite) || quantite <= 0)
                throw new ArgumentException("La variation de poids doit être strictement positive.");
        }

        public void EstEnSurpoids()
        {
            if (poids > 100)
            {
                Console.WriteLine("L'animal est en surpoids.");
            }
            else
            {
                Console.WriteLine("L'animal n'est pas en surpoids.");
            }
        }

        public bool testRegimeAlimentaire(RegimeAlimentaire unRegime)
        {
            bool uneExeption = false;

            if (!this.lesRegimesAlimentaires.Contains(unRegime))
            {
                uneExeption = true;
            }       

            return uneExeption;
        }
           

        public void AddUnRegimeAlimentaire(RegimeAlimentaire regime)
        {
            if (!Enum.IsDefined(typeof(RegimeAlimentaire), regime) || regime == RegimeAlimentaire.Inconnu)
                throw new ArgumentException("Choisissez un régime alimentaire connu.");
            if (!lesRegimesAlimentaires.Contains(regime))
            {
                lesRegimesAlimentaires.Add(regime);
            }
        }

        public void AddRegimeAlimentaire(List<RegimeAlimentaire> regimes)
        {
            if (regimes == null)
                throw new ArgumentNullException(nameof(regimes));
            if (regimes.Any(r => !Enum.IsDefined(typeof(RegimeAlimentaire), r) || r == RegimeAlimentaire.Inconnu))
                throw new ArgumentException("Choisissez des régimes alimentaires connus.");
            foreach (RegimeAlimentaire regime in regimes)
            {
                AddUnRegimeAlimentaire(regime);
            }
        }
        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"Animal de {this.leProprietaire.nomComplet}:\n" +
                $"    - nom: {nom}, {age} ans,{poids/1000f} kg\n" +
                $"      Numéro de puce: {numeroPuce} | Espèce: {espece}\n";
        }
        #endregion
    }
}
