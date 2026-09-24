using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Veterin_air;
using UIVeterin_air;

public static class UiChecks
{
    private static int checks;
    private static UI form;
    private static DataGridView grid;
    private static readonly BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
    private delegate bool EnumProc(IntPtr window, IntPtr parameter);
    [DllImport("user32.dll")] private static extern bool EnumWindows(EnumProc callback, IntPtr parameter);
    [DllImport("user32.dll")] private static extern uint GetWindowThreadProcessId(IntPtr window, out uint processId);
    [DllImport("user32.dll")] private static extern bool EnumChildWindows(IntPtr parent, EnumProc callback, IntPtr parameter);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern int GetClassName(IntPtr window, StringBuilder text, int size);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern int GetWindowText(IntPtr window, StringBuilder text, int size);
    [DllImport("user32.dll")] private static extern bool PostMessage(IntPtr window, uint message, IntPtr wParam, IntPtr lParam);

    private static T Field<T>(string name) { return (T)typeof(UI).GetField(name, flags).GetValue(form); }
    private static void Click(string name) { Field<Button>(name).PerformClick(); Application.DoEvents(); }
    private static void Check(bool condition, string label)
    {
        if (!condition) throw new Exception("ECHEC : " + label);
        checks++;
        Console.WriteLine("OK : " + label);
    }
    private static void Fill(string name, int age, decimal weight, string chip)
    {
        Field<TextBox>("txtNom").Text = name;
        Field<ComboBox>("cboEspece").SelectedItem = Espece.Rongeur;
        Field<NumericUpDown>("numAge").Value = age;
        Field<NumericUpDown>("numPoids").Value = weight;
        Field<TextBox>("txtPuce").Text = chip;
    }
    private static void ExpectError(string button, string expectedText)
    {
        string message = "";
        uint testProcessId = (uint)System.Diagnostics.Process.GetCurrentProcess().Id;
        using (System.Threading.Timer timer = new System.Threading.Timer(delegate
        {
                EnumWindows(delegate(IntPtr window, IntPtr unused)
                {
                    uint processId;
                    GetWindowThreadProcessId(window, out processId);
                    if (processId != testProcessId) return true;
                    StringBuilder className = new StringBuilder(100);
                    GetClassName(window, className, className.Capacity);
                    if (className.ToString() != "#32770") return true;
                    EnumChildWindows(window, delegate(IntPtr child, IntPtr unusedChild)
                    {
                        StringBuilder text = new StringBuilder(1000);
                        GetWindowText(child, text, text.Capacity);
                        message += text.ToString() + " ";
                        return true;
                    }, IntPtr.Zero);
                    PostMessage(window, 0x111, new IntPtr(1), IntPtr.Zero);
                    return false;
                }, IntPtr.Zero);
        }, null, 100, 100))
        {
            Click(button);
        }
        Check(message.Contains(expectedText), "MessageBox : " + expectedText);
    }

    private static void FillOwner(string name, string firstName, decimal balance)
    {
        Field<TextBox>("txtNomProprietaire").Text = name;
        Field<TextBox>("txtPrenomProprietaire").Text = firstName;
        Field<NumericUpDown>("numSoldeInitial").Value = balance;
    }

    private static void FillAnimal(string name, int age, decimal weight, string chip, RegimeAlimentaire regime)
    {
        Fill(name, age, weight, chip);
        CheckedListBox regimes = Field<CheckedListBox>("chkRegimes");
        for (int i = 0; i < regimes.Items.Count; i++)
            regimes.SetItemChecked(i, (RegimeAlimentaire)regimes.Items[i] == regime);
    }

    private static void Throws<T>(Action action, string label) where T : Exception
    {
        bool raised = false;
        try { action(); }
        catch (T) { raised = true; }
        Check(raised, label);
    }

    private static void CheckDomain()
    {
        Animal animal = new Animal("Test", 4, 2000, "999999999999991", Espece.Felin);
        Proprietaire p = new Proprietaire("Martin", "Alice", 10, new List<Animal> { animal });
        Check(animal.leProprietaire == p && p.getLesAnimaux().Count == 1, "Constructeur : association propriétaire/animal");
        p.getLesAnimaux().Clear();
        Check(p.getLesAnimaux().Count == 1, "Collection du propriétaire protégée par une copie");
        Proprietaire other = new Proprietaire("Durand", "Paul");
        Throws<InvalidOperationException>(() => other.addAnimal(animal), "Rattachement à deux propriétaires refusé");
        Throws<InvalidOperationException>(() => other.nourrir(animal, RegimeAlimentaire.Carnivore), "Nourrir l'animal d'un autre propriétaire refusé");
        Throws<ArgumentException>(() => animal.Grossir(-10), "Gain négatif refusé");
        Throws<ArgumentException>(() => animal.FaireduSport(-10), "Perte négative refusée");
        Throws<ArgumentException>(() => animal.Peser(float.NaN), "Poids NaN refusé");
        Throws<ArgumentException>(() => animal.Grossir(float.PositiveInfinity), "Gain infini refusé");
        Check(animal.poids == 2000, "Erreurs de poids : objet inchangé");
        Throws<ArgumentException>(() => p.deposerCompte(-5), "Dépôt négatif refusé");
        Throws<InvalidOperationException>(() => p.facturer(15), "Facture supérieure au solde refusée");
        Check(p.soldeCompte == 10, "Erreurs de compte : solde inchangé");
        Animal a2 = new Animal("Autre", 1, 150, "999999999999992", Espece.Rongeur);
        p.addLesAnimaux(new List<Animal> { animal, a2 });
        Check(p.getLesAnimaux().Count == 2 && a2.leProprietaire == p, "Ajout multiple et absence de doublon");
        p.rmAnimal(0);
        Check(animal.leProprietaire == null && p.getLesAnimaux().Count == 1, "Suppression : association libérée");
        other.addAnimal(animal);
        Check(animal.leProprietaire == other, "Réattribution après suppression");
    }

    public static void Run(string previewPath)
    {
        CheckDomain();
        Application.EnableVisualStyles();
        using (form = new UI())
        {
            form.ShowInTaskbar = false;
            form.Opacity = 0;
            form.Show();
            Application.DoEvents();
            grid = Field<DataGridView>("DataGridView");
            List<Proprietaire> owners = Field<List<Proprietaire>>("lesProprietaires");
            ListBox ownerList = Field<ListBox>("listProprietaires");
            Check(grid.Rows.Count == 0 && grid.Columns.Count == 6, "Tableau initial vide, six colonnes");
            Check(!Field<GroupBox>("GroupBoxNvPatient").Enabled && !Field<GroupBox>("groupActions").Enabled, "Création et actions désactivées sans propriétaire");
            FillOwner("   ", "Alice", 20);
            ExpectError("btnAjouterProprietaire", "nom");
            Check(owners.Count == 0, "Propriétaire invalide non ajouté");
            FillOwner(" Martin ", " Alice ", 20);
            Click("btnAjouterProprietaire");
            Proprietaire alice = owners[0];
            Check(alice.NomComplet == "Alice Martin" && ownerList.SelectedItem == alice, "Création et sélection du propriétaire");
            Check(Field<GroupBox>("GroupBoxNvPatient").Enabled && !Field<GroupBox>("groupActions").Enabled, "Création autorisée, actions sans animal désactivées");

            FillAnimal("   ", 49, 4000, "123456789012345", RegimeAlimentaire.Carnivore);
            ExpectError("btnAjouter", "nom");
            FillAnimal("Milo", 49, 4000, "123", RegimeAlimentaire.Carnivore);
            ExpectError("btnAjouter", "15 caractères");
            FillAnimal("Milo", 49, 4000, "123456789012345", RegimeAlimentaire.Inconnu);
            ExpectError("btnAjouter", "au moins un");
            Check(alice.getLesAnimaux().Count == 0, "Saisies invalides sans ajout partiel");
            FillAnimal("Milo", 49, 4000, "123456789012345", RegimeAlimentaire.Carnivore);
            Click("btnAjouter");
            Animal milo = alice.getLesAnimaux()[0];
            Check(milo.leProprietaire == alice && grid.Rows.Count == 1, "Animal rattaché au propriétaire et affiché");
            Check(Convert.ToString(grid.Rows[0].Cells["numeroPuce"].Value) == "123456789012345", "Numéro de puce affiché");
            Check(Convert.ToString(grid.Rows[0].Cells["RegimesAlimentairesDescription"].Value) == "Carnivore", "Régime alimentaire affiché");
            Check(Field<TextBox>("txtNom").Text == "" && Field<CheckedListBox>("chkRegimes").CheckedItems.Count == 0, "Formulaire réinitialisé après ajout");

            Field<ComboBox>("cboAlimentation").SelectedItem = RegimeAlimentaire.Carnivore;
            Click("btnNourrir");
            Check(milo.poids == 4300 && Convert.ToSingle(grid.Rows[0].Cells["poids"].Value) == 4300, "Repas carnivore : +300 g, tableau actualisé");
            Field<ComboBox>("cboAlimentation").SelectedItem = RegimeAlimentaire.Herbivore;
            ExpectError("btnNourrir", "Régime alimentaire");
            Check(milo.poids == 4300, "Repas incompatible : poids inchangé");
            Field<NumericUpDown>("numVariation").Value = 125;
            Click("btnGrossir");
            Check(milo.poids == 4425, "Grossir ajoute la quantité saisie");
            Click("btnSport");
            Check(milo.poids == 4300, "Sport retire la quantité saisie");
            Field<NumericUpDown>("numVariation").Value = 5000;
            ExpectError("btnSport", "poids");
            Check(milo.poids == 4300, "Perte excessive : poids inchangé");
            Field<NumericUpDown>("numVariation").Value = 0;
            ExpectError("btnGrossir", "strictement positive");
            Field<NumericUpDown>("numVariation").Value = 3999.5m;
            Click("btnPeser");
            Check(milo.poids == 3999.5f, "Peser remplace le poids et conserve les décimales");
            Click("btnVieillir");
            Check(milo.age == 50, "Vieillir ajoute un an");
            ExpectError("btnVieillir", "0 et 50");
            Check(milo.age == 50, "Âge maximal : état inchangé");

            Field<ComboBox>("cboMotif").SelectedItem = MotifConsultation.Vaccination;
            ExpectError("btnSoigner", "insuffisant");
            Check(alice.soldeCompte == 20, "Soin refusé : aucun débit");
            Field<NumericUpDown>("numDepot").Value = 50;
            Click("btnDeposer");
            Check(alice.soldeCompte == 70, "Dépôt sur le bon propriétaire");
            Click("btnSoigner");
            Check(alice.soldeCompte == 15 && Field<Label>("lblSolde").Text.Contains("15"), "Soin facturé selon le motif sélectionné, solde affiché");

            Field<NumericUpDown>("numVariation").Value = (decimal)Animal.PoidsMaximum;
            Click("btnPeser");
            Field<ComboBox>("cboAlimentation").SelectedItem = RegimeAlimentaire.Carnivore;
            ExpectError("btnNourrir", "poids");
            Check(milo.poids == Animal.PoidsMaximum, "Poids maximal : repas refusé sans modification");
            Field<NumericUpDown>("numVariation").Value = 4300;
            Click("btnPeser");

            FillOwner("Durand", "Paul", 100);
            Click("btnAjouterProprietaire");
            Proprietaire paul = owners[1];
            Check(ownerList.SelectedItem == paul && grid.Rows.Count == 0, "Second propriétaire : liste distincte et vide");
            Check(!Field<GroupBox>("groupActions").Enabled, "Changement de propriétaire : ancienne sélection désactivée");
            FillAnimal("Doublon", 1, 500, "123456789012345", RegimeAlimentaire.Herbivore);
            ExpectError("btnAjouter", "déjà");
            Check(paul.getLesAnimaux().Count == 0 && alice.getLesAnimaux().Count == 1, "Puce unique entre propriétaires");
            FillAnimal("Noisette", 2, 450.5m, "223456789012345", RegimeAlimentaire.Herbivore);
            Click("btnAjouter");
            Animal noisette = paul.getLesAnimaux()[0];
            Click("btnNourrir");
            Check(noisette.poids == 600.5f && milo.poids == 4300, "Nourrir agit uniquement sur l'animal sélectionné");
            Click("btnVieillir");
            Check(noisette.age == 3 && milo.age == 50, "Vieillir ne modifie pas l'animal de l'autre propriétaire");
            ownerList.SelectedIndex = 0;
            Application.DoEvents();
            Check(grid.Rows.Count == 1 && ((Animal)grid.Rows[0].DataBoundItem) == milo, "Retour au premier propriétaire : son animal est conservé");
            Check(!Field<GroupBox>("groupActions").Enabled, "Sélection requise après changement de propriétaire");
            grid.CurrentCell = grid.Rows[0].Cells[0];
            grid.Rows[0].Selected = true;

            FillAnimal("Brouillon", 3, 100, "333333333333333", RegimeAlimentaire.Omnivore);
            Click("btnVider");
            Check(alice.getLesAnimaux().Count == 1 && Field<TextBox>("txtNom").Text == "", "Effacer préserve les animaux existants");
            using (Bitmap bitmap = new Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
                bitmap.Save(previewPath);
            }
            Click("btnSupprimer");
            Check(alice.getLesAnimaux().Count == 0 && milo.leProprietaire == null && grid.Rows.Count == 0, "Suppression : tableau, collection et association mis à jour");
            Check(paul.getLesAnimaux().Count == 1, "Suppression préserve l'autre propriétaire");
            Check(!Field<GroupBox>("groupActions").Enabled, "Dernier animal supprimé : actions désactivées");
        }
        Console.WriteLine("TOTAL : " + checks + " vérifications réussies");
    }
}
