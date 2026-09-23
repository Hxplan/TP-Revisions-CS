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
        private float _poids;
        private string _numeroPuce;
        private Espece _espece;
        private Proprietaire _leProprietaire;
        private RegimeAlimentaire _regimeAlimentaire;

        private List<RegimeAlimentaire> lesregimesAlimentaires = new List<RegimeAlimentaire>();

        #endregion

        #region Propriétés

        public string Nom
        {
            get { return _nom; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Le nom ne peut pas être vide ou nul.");
                }
                _nom = value;
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
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentException("Le poids doit être compris entre 0 et 1000.");
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
            }
        }

        public Espece espece
        {
            get { return _espece; }
            set { _espece = value; }
        }

        public RegimeAlimentaire regimeAlimentaire
        {
            get { return _regimeAlimentaire; }
            set { _regimeAlimentaire = value; }
        }

        public Proprietaire leProprietaire
        {
            get { return _leProprietaire; }
            set { _leProprietaire = value; }
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
            Nom = nom;
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
            poids += poids;
            if (poids < 0)
            {
                throw new ArgumentException("Le poids ne peut pas être négatif.");
            }
        }

        public void FaireduSport(float poids)
        {
            poids -= poids;
            if (poids < 0)
            {
                throw new ArgumentException("Le poids ne peut pas être négatif.");
            }
        }

        public void Peser(float poids)
        {

            poids += poids;
            if (poids < 0)
            {
                throw new ArgumentException("Le poids ne peut pas être négatif.");
            }

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

        public void testRegimeAlimentaire(RegimeAlimentaire unRegime)
        {
            string uneExeption = "";

            if (!this.lesregimesAlimentaires.Contains(unRegime))
            {
                uneExeption += "Le régime alimentaire n'est pas compatible avec l'espèce de l'animal.";
            }

            if (uneExeption != "")
            {
                throw new ArgumentException(uneExeption);
            }
        }
           

        public void AddUnRegimeAlimentaire(RegimeAlimentaire regime)
        {
            if (!lesregimesAlimentaires.Contains(regime))
            {
                lesregimesAlimentaires.Add(regime);
            }
        }

        public void AddRegimeAlimentaire(List<RegimeAlimentaire> regimes)
        {
            foreach (RegimeAlimentaire regime in regimes)
            {
                if (!lesregimesAlimentaires.Contains(regime))
                {
                    lesregimesAlimentaires.Add(regime);
                }
            }
        }
        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"Nom: {Nom}, Age: {age}, Poids: {poids}, Numéro de puce: {numeroPuce}, Espèce: {espece}";
        }
        #endregion
    }
}
