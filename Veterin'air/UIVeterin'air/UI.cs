using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Veterin_air;

namespace UIVeterin_air
{
    public partial class UI : Form
    {
        #region Champs privés

        private readonly List<Proprietaire> lesProprietaires = new List<Proprietaire>();
        private readonly List<Animal> lesAnimaux = new List<Animal>();
        private readonly BindingSource sourceProprietaires;
        private readonly BindingSource sourceAnimaux;
        private bool interfaceInitialisee;

        #endregion

        #region Constructeur

        public UI()
        {
            InitializeComponent();

            if (components == null)
                components = new System.ComponentModel.Container();
            sourceProprietaires = new BindingSource(components);
            sourceAnimaux = new BindingSource(components);
        }

        #endregion

        #region Initialisation

        private void UI_Load(object sender, EventArgs e)
        {
            cboEspece.DataSource = Enum.GetValues(typeof(Espece));
            RegimeAlimentaire[] regimes = Enum.GetValues(typeof(RegimeAlimentaire))
                .Cast<RegimeAlimentaire>().Where(r => r != RegimeAlimentaire.Inconnu).ToArray();
            chkRegimes.Items.AddRange(regimes.Cast<object>().ToArray());
            cboAlimentation.DataSource = regimes;
            cboMotif.DataSource = Enum.GetValues(typeof(MotifConsultation))
                .Cast<MotifConsultation>().Where(m => m != MotifConsultation.Inconnu).ToArray();

            numPoids.Maximum = (decimal)Animal.PoidsMaximum;
            numVariation.Maximum = (decimal)Animal.PoidsMaximum;
            AjouterColonne(nameof(Animal.nom), "nom", 100);
            AjouterColonne(nameof(Animal.espece), "Espèce", 85);
            AjouterColonne(nameof(Animal.age), "Âge (ans)", 75);
            AjouterColonne(nameof(Animal.poids), "Poids (g)", 90);
            AjouterColonne(nameof(Animal.numeroPuce), "Numéro de puce", 140);
            AjouterColonne(nameof(Animal.RegimesAlimentairesDescription), "Régimes autorisés", 170);
            DataGridView.Columns[nameof(Animal.poids)].DefaultCellStyle.Format = "N1";

            sourceProprietaires.DataSource = lesProprietaires;
            listProprietaires.DisplayMember = nameof(Proprietaire.nomComplet);
            listProprietaires.DataSource = sourceProprietaires;
            sourceAnimaux.DataSource = lesAnimaux;
            DataGridView.DataSource = sourceAnimaux;
            interfaceInitialisee = true;
            ViderChamps();
            ActualiserListe();
            lblStatut.Text = "Commencez par ajouter un propriétaire. Les données sont conservées pendant cette session.";
        }

        private void AjouterColonne(string propriete, string titre, int largeur)
        {
            DataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = propriete,
                DataPropertyName = propriete,
                HeaderText = titre,
                MinimumWidth = largeur,
                FillWeight = largeur,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        #endregion

        #region Propriétaires

        private void btnAjouterProprietaire_Click(object sender, EventArgs e)
        {
            ExecuterAction(() =>
            {
                Proprietaire proprietaire = new Proprietaire(
                    txtNomProprietaire.Text, txtPrenomProprietaire.Text, (float)numSoldeInitial.Value);
                lesProprietaires.Add(proprietaire);
                sourceProprietaires.ResetBindings(false);
                listProprietaires.SelectedIndex = lesProprietaires.IndexOf(proprietaire);
                txtNomProprietaire.Clear();
                txtPrenomProprietaire.Clear();
                numSoldeInitial.Value = 0;
                ViderChamps();
                ActualiserListe();
                lblStatut.Text = "Propriétaire ajouté : " + proprietaire.nomComplet + ". Vous pouvez créer son animal.";
                txtNom.Focus();
            });
        }

        private void listProprietaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!interfaceInitialisee) return;
            ViderChamps();
            ActualiserListe();
        }

        private void btnDeposer_Click(object sender, EventArgs e)
        {
            ExecuterAction(() =>
            {
                Proprietaire proprietaire = ObtenirProprietaireSelectionne();
                proprietaire.deposerCompte((float)numDepot.Value);
                ActualiserSolde();
                lblStatut.Text = "Dépôt effectué pour " + proprietaire.nomComplet + ".";
            });
        }

        private Proprietaire ObtenirProprietaireSelectionne()
        {
            Proprietaire proprietaire = listProprietaires.SelectedItem as Proprietaire;
            if (proprietaire == null)
                throw new InvalidOperationException("Sélectionnez ou créez un propriétaire.");
            return proprietaire;
        }

        #endregion

        #region Création et suppression des animaux

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ExecuterAction(() =>
            {
                Proprietaire proprietaire = ObtenirProprietaireSelectionne();
                if (cboEspece.SelectedItem == null)
                    throw new ArgumentException("Sélectionnez une espèce.");
                if (chkRegimes.CheckedItems.Count == 0)
                    throw new ArgumentException("Cochez au moins un régime alimentaire.");

                Animal animal = new Animal(txtNom.Text.Trim(), (int)numAge.Value,
                    (float)numPoids.Value, txtPuce.Text.Trim(), (Espece)cboEspece.SelectedItem);
                animal.AddRegimeAlimentaire(chkRegimes.CheckedItems.Cast<RegimeAlimentaire>().ToList());

                if (lesProprietaires.SelectMany(p => p.getLesAnimaux()).Any(a =>
                    string.Equals(a.numeroPuce, animal.numeroPuce, StringComparison.OrdinalIgnoreCase)))
                    throw new ArgumentException("Un animal possède déjà ce numéro de puce.");

                proprietaire.addAnimal(animal);
                ActualiserListe(animal);
                ViderChamps();
                lblStatut.Text = animal.nom + " a été ajouté à la liste de " + proprietaire.nomComplet + ".";
            });
        }

        private void btnVider_Click(object sender, EventArgs e)
        {
            ViderChamps();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            ExecuterAction(() =>
            {
                Proprietaire proprietaire = ObtenirProprietaireSelectionne();
                Animal animal = ObtenirAnimalSelectionne();
                proprietaire.rmAnimal(proprietaire.getLesAnimaux().IndexOf(animal));
                ActualiserListe();
                lblStatut.Text = animal.nom + " a été retiré de la liste du propriétaire.";
            });
        }

        #endregion

        #region Actions sur un animal

        private void btnVieillir_Click(object sender, EventArgs e)
        {
            ExecuterSurAnimal(a => a.Vieillir(), "a vieilli d'un an.");
        }

        private void btnNourrir_Click(object sender, EventArgs e)
        {
            ExecuterSurAnimal(a =>
            {
                if (cboAlimentation.SelectedItem == null)
                    throw new ArgumentException("Choisissez le type de repas.");
                ObtenirProprietaireSelectionne().nourrirAnimal(a, (RegimeAlimentaire)cboAlimentation.SelectedItem);
            }, "a été nourri.");
        }

        private void btnGrossir_Click(object sender, EventArgs e)
        {
            ExecuterSurAnimal(a => a.Grossir((float)numVariation.Value), "a pris du poids.");
        }

        private void btnSport_Click(object sender, EventArgs e)
        {
            ExecuterSurAnimal(a => a.FaireduSport((float)numVariation.Value), "a fait du sport.");
        }

        private void btnPeser_Click(object sender, EventArgs e)
        {
            ExecuterSurAnimal(a => a.Peser((float)numVariation.Value), "a été pesé.");
        }

        private void btnSoigner_Click(object sender, EventArgs e)
        {
            ExecuterSurAnimal(a =>
            {
                if (cboMotif.SelectedItem == null)
                    throw new ArgumentException("Choisissez un motif de consultation.");
                ObtenirProprietaireSelectionne().faireSoigner(a, (MotifConsultation)cboMotif.SelectedItem);
            }, "a été soigné. Le tarif a été débité du compte du propriétaire.");
        }

        private void ExecuterSurAnimal(Action<Animal> action, string resultat)
        {
            ExecuterAction(() =>
            {
                Animal animal = ObtenirAnimalSelectionne();
                action(animal);
                ActualiserListe(animal);
                lblStatut.Text = animal.nom + " " + resultat;
            });
        }


        private void ExecuterAction(Action action)
        {
            try
            {
                action();
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        #endregion

        #region Affichage

        private Animal ObtenirAnimalSelectionne()
        {
            if (DataGridView.SelectedRows.Count == 0)
                throw new InvalidOperationException("Sélectionnez un animal dans le tableau.");
            Animal animal = DataGridView.SelectedRows[0].DataBoundItem as Animal;
            if (animal == null || animal.leProprietaire != ObtenirProprietaireSelectionne())
                throw new InvalidOperationException("Sélectionnez un animal du propriétaire courant.");
            return animal;
        }

        private void ActualiserListe(Animal animalSelectionne = null)
        {
            Proprietaire proprietaire = listProprietaires.SelectedItem as Proprietaire;

            lesAnimaux.Clear();
            if (proprietaire != null)
                lesAnimaux.AddRange(proprietaire.getLesAnimaux());
            sourceAnimaux.ResetBindings(false);
            DataGridView.ClearSelection();
            if (animalSelectionne != null)
            {
                int index = lesAnimaux.IndexOf(animalSelectionne);
                if (index >= 0)
                {
                    DataGridView.CurrentCell = DataGridView.Rows[index].Cells[0];
                    DataGridView.Rows[index].Selected = true;
                }
            }

            GroupBoxNvPatient.Enabled = proprietaire != null;
            GroupBoxNvPatient.Text = proprietaire == null ? "2. Créer un animal" : "2. Créer un animal pour " + proprietaire.nomComplet;
            groupAnimaux.Text = proprietaire == null ? "Animaux" :
                "Animaux de " + proprietaire.nomComplet + " (" + lesAnimaux.Count + ")";
            btnDeposer.Enabled = proprietaire != null;
            ActualiserSolde();
            ActualiserBoutons();
        }

        private void ActualiserSolde()
        {
            Proprietaire proprietaire = listProprietaires.SelectedItem as Proprietaire;
            lblSolde.Text = proprietaire == null ? "Aucun propriétaire sélectionné" :
                "Solde : " + proprietaire.soldeCompte.ToString("N2") + " €";
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!interfaceInitialisee) return;
            ActualiserBoutons();
            if (DataGridView.SelectedRows.Count == 0) return;
            Animal animal = DataGridView.SelectedRows[0].DataBoundItem as Animal;
            if (animal != null && animal.LesRegimesAlimentaires.Count > 0)
                cboAlimentation.SelectedItem = animal.LesRegimesAlimentaires[0];
        }

        private void ActualiserBoutons()
        {
            bool selection = listProprietaires.SelectedItem != null && DataGridView.SelectedRows.Count > 0;
            groupActions.Enabled = selection;
        }

        private void ViderChamps()
        {
            txtNom.Clear();
            cboEspece.SelectedIndex = -1;
            numAge.Value = 0;
            numPoids.Value = 0;
            txtPuce.Clear();
            for (int i = 0; i < chkRegimes.Items.Count; i++)
                chkRegimes.SetItemChecked(i, false);
            txtNom.Focus();
        }

        private void AfficherErreur(string message)
        {
            lblStatut.Text = "Action refusée : " + message;
            MessageBox.Show(this, message, "Erreur — Veterin'air", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}