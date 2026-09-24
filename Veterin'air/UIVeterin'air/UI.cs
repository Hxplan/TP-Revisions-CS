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
            try
            {
                cboEspece.DataSource = Enum.GetValues(typeof(Espece));
                RegimeAlimentaire[] regimes = Enum.GetValues(typeof(RegimeAlimentaire))
                    .Cast<RegimeAlimentaire>().Where(r => r != RegimeAlimentaire.Inconnu).ToArray();
                chkRegimes.Items.AddRange(regimes.Cast<object>().ToArray());
                cboAlimentation.DataSource = regimes;
                cboMotif.DataSource = Enum.GetValues(typeof(MotifConsultation));
                cboMotif.SelectedItem = MotifConsultation.Inconnu;

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
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomProprietaire.Text) || string.IsNullOrWhiteSpace(txtPrenomProprietaire.Text))
                    throw new ArgumentException("Le nom et le prénom du propriétaire sont obligatoires.");

                Proprietaire proprietaire = new Proprietaire(
                    txtNomProprietaire.Text.Trim(), txtPrenomProprietaire.Text.Trim(), (float)numSoldeInitial.Value);
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
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void listProprietaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!interfaceInitialisee) return;
                ViderChamps();
                ActualiserListe();
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnDeposer_Click(object sender, EventArgs e)
        {
            try
            {
                Proprietaire proprietaire = ObtenirProprietaireSelectionne();
                proprietaire.deposerCompte((float)numDepot.Value);
                ActualiserSolde();
                lblStatut.Text = "Dépôt effectué pour " + proprietaire.nomComplet + ".";
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
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
            try
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
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnVider_Click(object sender, EventArgs e)
        {
            try
            {
                ViderChamps();
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                Proprietaire proprietaire = ObtenirProprietaireSelectionne();
                Animal animal = ObtenirAnimalSelectionne();
                proprietaire.rmAnimal(proprietaire.getLesAnimaux().IndexOf(animal));
                ActualiserListe();
                lblStatut.Text = animal.nom + " a été retiré de la liste du propriétaire.";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        #endregion

        #region Actions sur un animal

        private void btnVieillir_Click(object sender, EventArgs e)
        {
            try
            {
                Animal animal = ObtenirAnimalSelectionne();
                animal.Vieillir();
                ActualiserListe(animal);
                lblStatut.Text = animal.nom + " a vieilli d'un an.";
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnNourrir_Click(object sender, EventArgs e)
        {
            try
            {
                Animal animal = ObtenirAnimalSelectionne();
                if (cboAlimentation.SelectedItem == null)
                    throw new ArgumentException("Choisissez le type de repas.");
                Proprietaire prop = ObtenirProprietaireSelectionne();
                prop.nourrirAnimal(animal, (RegimeAlimentaire)cboAlimentation.SelectedItem);
                ActualiserListe(animal);
                lblStatut.Text = animal.nom + " a été nourri.";
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnGrossir_Click(object sender, EventArgs e)
        {
            try
            {
                Animal animal = ObtenirAnimalSelectionne();
                animal.Grossir((float)numVariation.Value);
                ActualiserListe(animal);
                lblStatut.Text = animal.nom + " a pris du poids.";
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnSport_Click(object sender, EventArgs e)
        {
            try
            {
                Animal animal = ObtenirAnimalSelectionne();
                animal.FaireduSport((float)numVariation.Value);
                ActualiserListe(animal);
                lblStatut.Text = animal.nom + " a fait du sport.";
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnPeser_Click(object sender, EventArgs e)
        {
            try
            {
                Animal animal = ObtenirAnimalSelectionne();
                animal.Peser((float)numVariation.Value);
                ActualiserListe(animal);
                lblStatut.Text = animal.nom + " a été pesé.";
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void btnSoigner_Click(object sender, EventArgs e)
        {
            try
            {
                Animal animal = ObtenirAnimalSelectionne();
                if (cboMotif.SelectedItem == null)
                    throw new ArgumentException("Choisissez un motif de consultation.");
                Proprietaire prop = ObtenirProprietaireSelectionne();
                prop.setMotif((MotifConsultation)cboMotif.SelectedItem);
                prop.faireSoigner(animal);
                cboMotif.SelectedItem = prop.getMotif();
                ActualiserListe(animal);
                lblStatut.Text = animal.nom + " a été soigné. Le tarif a été débité du compte du propriétaire.";
            }
            catch (ArgumentException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                AfficherErreur(ex.Message);
            }
            catch (Exception ex)
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
            try
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
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void ActualiserSolde()
        {
            try
            {
                Proprietaire proprietaire = listProprietaires.SelectedItem as Proprietaire;
                lblSolde.Text = proprietaire == null ? "Aucun propriétaire sélectionné" :
                    "Solde : " + proprietaire.soldeCompte.ToString("N2") + " €";
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!interfaceInitialisee) return;
                ActualiserBoutons();
                if (DataGridView.SelectedRows.Count == 0) return;
                Animal animal = DataGridView.SelectedRows[0].DataBoundItem as Animal;
                if (animal != null && animal.LesRegimesAlimentaires.Count > 0)
                    cboAlimentation.SelectedItem = animal.LesRegimesAlimentaires[0];
            }
            catch (Exception ex)
            {
                AfficherErreur(ex.Message);
            }
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
            cboMotif.SelectedItem = MotifConsultation.Inconnu;
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