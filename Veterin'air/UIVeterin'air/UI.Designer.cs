namespace UIVeterin_air
{
    partial class UI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupProprietaires = new System.Windows.Forms.GroupBox();
            this.GroupBoxNvPatient = new System.Windows.Forms.GroupBox();
            this.groupAnimaux = new System.Windows.Forms.GroupBox();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.lblStatut = new System.Windows.Forms.Label();
            this.lblNomProprietaire = new System.Windows.Forms.Label();
            this.txtNomProprietaire = new System.Windows.Forms.TextBox();
            this.lblPrenomProprietaire = new System.Windows.Forms.Label();
            this.txtPrenomProprietaire = new System.Windows.Forms.TextBox();
            this.lblSoldeInitial = new System.Windows.Forms.Label();
            this.numSoldeInitial = new System.Windows.Forms.NumericUpDown();
            this.btnAjouterProprietaire = new System.Windows.Forms.Button();
            this.lblListeProprietaires = new System.Windows.Forms.Label();
            this.listProprietaires = new System.Windows.Forms.ListBox();
            this.lblSolde = new System.Windows.Forms.Label();
            this.lblDepot = new System.Windows.Forms.Label();
            this.numDepot = new System.Windows.Forms.NumericUpDown();
            this.btnDeposer = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblEspece = new System.Windows.Forms.Label();
            this.cboEspece = new System.Windows.Forms.ComboBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblPoids = new System.Windows.Forms.Label();
            this.numPoids = new System.Windows.Forms.NumericUpDown();
            this.lblPuce = new System.Windows.Forms.Label();
            this.txtPuce = new System.Windows.Forms.TextBox();
            this.lblRegimes = new System.Windows.Forms.Label();
            this.chkRegimes = new System.Windows.Forms.CheckedListBox();
            this.lblUnites = new System.Windows.Forms.Label();
            this.lblRegimesAide = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnVider = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.btnVieillir = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.lblVariation = new System.Windows.Forms.Label();
            this.numVariation = new System.Windows.Forms.NumericUpDown();
            this.btnGrossir = new System.Windows.Forms.Button();
            this.btnSport = new System.Windows.Forms.Button();
            this.btnPeser = new System.Windows.Forms.Button();
            this.lblAlimentation = new System.Windows.Forms.Label();
            this.cboAlimentation = new System.Windows.Forms.ComboBox();
            this.btnNourrir = new System.Windows.Forms.Button();
            this.lblMotif = new System.Windows.Forms.Label();
            this.cboMotif = new System.Windows.Forms.ComboBox();
            this.btnSoigner = new System.Windows.Forms.Button();
            this.lblTarifs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSoldeInitial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDepot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariation)).BeginInit();
            this.groupProprietaires.SuspendLayout();
            this.GroupBoxNvPatient.SuspendLayout();
            this.groupAnimaux.SuspendLayout();
            this.groupActions.SuspendLayout();
            this.SuspendLayout();
            // groupProprietaires
            this.groupProprietaires.Name = "groupProprietaires";
            this.groupProprietaires.Location = new System.Drawing.Point(12, 12);
            this.groupProprietaires.Size = new System.Drawing.Size(250, 650);
            this.groupProprietaires.Text = "1. Propriétaires";
            this.groupProprietaires.TabIndex = 0;
            this.groupProprietaires.TabStop = false;
            this.groupProprietaires.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.Controls.Add(this.groupProprietaires);
            // GroupBoxNvPatient
            this.GroupBoxNvPatient.Name = "GroupBoxNvPatient";
            this.GroupBoxNvPatient.Location = new System.Drawing.Point(274, 12);
            this.GroupBoxNvPatient.Size = new System.Drawing.Size(894, 208);
            this.GroupBoxNvPatient.Text = "2. Créer un animal";
            this.GroupBoxNvPatient.TabIndex = 1;
            this.GroupBoxNvPatient.TabStop = false;
            this.GroupBoxNvPatient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Controls.Add(this.GroupBoxNvPatient);
            // groupAnimaux
            this.groupAnimaux.Name = "groupAnimaux";
            this.groupAnimaux.Location = new System.Drawing.Point(274, 232);
            this.groupAnimaux.Size = new System.Drawing.Size(894, 230);
            this.groupAnimaux.Text = "Animaux";
            this.groupAnimaux.TabIndex = 2;
            this.groupAnimaux.TabStop = false;
            this.groupAnimaux.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Controls.Add(this.groupAnimaux);
            // groupActions
            this.groupActions.Name = "groupActions";
            this.groupActions.Location = new System.Drawing.Point(274, 474);
            this.groupActions.Size = new System.Drawing.Size(894, 188);
            this.groupActions.Text = "3. Actions sur l'animal sélectionné";
            this.groupActions.TabIndex = 3;
            this.groupActions.TabStop = false;
            this.groupActions.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.groupActions.Enabled = false;
            this.Controls.Add(this.groupActions);
            // lblStatut
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Location = new System.Drawing.Point(12, 674);
            this.lblStatut.Size = new System.Drawing.Size(1156, 20);
            this.lblStatut.Text = "Ajoutez un propriétaire pour commencer.";
            this.lblStatut.TabIndex = 4;
            this.lblStatut.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblStatut.AutoEllipsis = true;
            this.Controls.Add(this.lblStatut);
            // lblNomProprietaire
            this.lblNomProprietaire.Name = "lblNomProprietaire";
            this.lblNomProprietaire.Location = new System.Drawing.Point(16, 28);
            this.lblNomProprietaire.Size = new System.Drawing.Size(218, 20);
            this.lblNomProprietaire.Text = "Nom du propriétaire";
            this.lblNomProprietaire.TabIndex = 0;
            this.groupProprietaires.Controls.Add(this.lblNomProprietaire);
            // txtNomProprietaire
            this.txtNomProprietaire.Name = "txtNomProprietaire";
            this.txtNomProprietaire.Location = new System.Drawing.Point(16, 50);
            this.txtNomProprietaire.Size = new System.Drawing.Size(218, 24);
            this.txtNomProprietaire.TabIndex = 1;
            this.groupProprietaires.Controls.Add(this.txtNomProprietaire);
            // lblPrenomProprietaire
            this.lblPrenomProprietaire.Name = "lblPrenomProprietaire";
            this.lblPrenomProprietaire.Location = new System.Drawing.Point(16, 86);
            this.lblPrenomProprietaire.Size = new System.Drawing.Size(218, 20);
            this.lblPrenomProprietaire.Text = "Prénom";
            this.lblPrenomProprietaire.TabIndex = 2;
            this.groupProprietaires.Controls.Add(this.lblPrenomProprietaire);
            // txtPrenomProprietaire
            this.txtPrenomProprietaire.Name = "txtPrenomProprietaire";
            this.txtPrenomProprietaire.Location = new System.Drawing.Point(16, 108);
            this.txtPrenomProprietaire.Size = new System.Drawing.Size(218, 24);
            this.txtPrenomProprietaire.TabIndex = 3;
            this.groupProprietaires.Controls.Add(this.txtPrenomProprietaire);
            // lblSoldeInitial
            this.lblSoldeInitial.Name = "lblSoldeInitial";
            this.lblSoldeInitial.Location = new System.Drawing.Point(16, 144);
            this.lblSoldeInitial.Size = new System.Drawing.Size(218, 20);
            this.lblSoldeInitial.Text = "Solde initial (€)";
            this.lblSoldeInitial.TabIndex = 4;
            this.groupProprietaires.Controls.Add(this.lblSoldeInitial);
            // numSoldeInitial
            this.numSoldeInitial.Name = "numSoldeInitial";
            this.numSoldeInitial.Location = new System.Drawing.Point(16, 166);
            this.numSoldeInitial.Size = new System.Drawing.Size(218, 24);
            this.numSoldeInitial.TabIndex = 5;
            this.numSoldeInitial.Maximum = 1000000m;
            this.numSoldeInitial.Value = 0m;
            this.numSoldeInitial.DecimalPlaces = 2;
            this.numSoldeInitial.ThousandsSeparator = true;
            this.groupProprietaires.Controls.Add(this.numSoldeInitial);
            // btnAjouterProprietaire
            this.btnAjouterProprietaire.Name = "btnAjouterProprietaire";
            this.btnAjouterProprietaire.Location = new System.Drawing.Point(16, 208);
            this.btnAjouterProprietaire.Size = new System.Drawing.Size(218, 30);
            this.btnAjouterProprietaire.Text = "Ajouter le propriétaire";
            this.btnAjouterProprietaire.TabIndex = 6;
            this.btnAjouterProprietaire.UseVisualStyleBackColor = true;
            this.btnAjouterProprietaire.Click += new System.EventHandler(this.btnAjouterProprietaire_Click);
            this.groupProprietaires.Controls.Add(this.btnAjouterProprietaire);
            // lblListeProprietaires
            this.lblListeProprietaires.Name = "lblListeProprietaires";
            this.lblListeProprietaires.Location = new System.Drawing.Point(16, 249);
            this.lblListeProprietaires.Size = new System.Drawing.Size(218, 20);
            this.lblListeProprietaires.Text = "Choisir un propriétaire";
            this.lblListeProprietaires.TabIndex = 7;
            this.groupProprietaires.Controls.Add(this.lblListeProprietaires);
            // listProprietaires
            this.listProprietaires.Name = "listProprietaires";
            this.listProprietaires.Location = new System.Drawing.Point(16, 274);
            this.listProprietaires.Size = new System.Drawing.Size(218, 218);
            this.listProprietaires.TabIndex = 8;
            this.listProprietaires.IntegralHeight = false;
            this.listProprietaires.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.listProprietaires.SelectedIndexChanged += new System.EventHandler(this.listProprietaires_SelectedIndexChanged);
            this.groupProprietaires.Controls.Add(this.listProprietaires);
            // lblSolde
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Location = new System.Drawing.Point(16, 508);
            this.lblSolde.Size = new System.Drawing.Size(218, 20);
            this.lblSolde.Text = "Aucun propriétaire sélectionné";
            this.lblSolde.TabIndex = 9;
            this.lblSolde.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.groupProprietaires.Controls.Add(this.lblSolde);
            // lblDepot
            this.lblDepot.Name = "lblDepot";
            this.lblDepot.Location = new System.Drawing.Point(16, 544);
            this.lblDepot.Size = new System.Drawing.Size(218, 20);
            this.lblDepot.Text = "Montant à déposer (€)";
            this.lblDepot.TabIndex = 10;
            this.lblDepot.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.groupProprietaires.Controls.Add(this.lblDepot);
            // numDepot
            this.numDepot.Name = "numDepot";
            this.numDepot.Location = new System.Drawing.Point(16, 570);
            this.numDepot.Size = new System.Drawing.Size(116, 24);
            this.numDepot.TabIndex = 11;
            this.numDepot.Maximum = 1000000m;
            this.numDepot.Value = 50m;
            this.numDepot.DecimalPlaces = 2;
            this.numDepot.ThousandsSeparator = true;
            this.numDepot.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.groupProprietaires.Controls.Add(this.numDepot);
            // btnDeposer
            this.btnDeposer.Name = "btnDeposer";
            this.btnDeposer.Location = new System.Drawing.Point(142, 567);
            this.btnDeposer.Size = new System.Drawing.Size(92, 30);
            this.btnDeposer.Text = "Déposer";
            this.btnDeposer.TabIndex = 12;
            this.btnDeposer.UseVisualStyleBackColor = true;
            this.btnDeposer.Click += new System.EventHandler(this.btnDeposer_Click);
            this.btnDeposer.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.groupProprietaires.Controls.Add(this.btnDeposer);
            // lblNom
            this.lblNom.Name = "lblNom";
            this.lblNom.Location = new System.Drawing.Point(16, 26);
            this.lblNom.Size = new System.Drawing.Size(148, 20);
            this.lblNom.Text = "Nom de l'animal";
            this.lblNom.TabIndex = 0;
            this.GroupBoxNvPatient.Controls.Add(this.lblNom);
            // txtNom
            this.txtNom.Name = "txtNom";
            this.txtNom.Location = new System.Drawing.Point(16, 50);
            this.txtNom.Size = new System.Drawing.Size(148, 24);
            this.txtNom.TabIndex = 1;
            this.GroupBoxNvPatient.Controls.Add(this.txtNom);
            // lblEspece
            this.lblEspece.Name = "lblEspece";
            this.lblEspece.Location = new System.Drawing.Point(178, 26);
            this.lblEspece.Size = new System.Drawing.Size(140, 20);
            this.lblEspece.Text = "Espèce";
            this.lblEspece.TabIndex = 2;
            this.GroupBoxNvPatient.Controls.Add(this.lblEspece);
            // cboEspece
            this.cboEspece.Name = "cboEspece";
            this.cboEspece.Location = new System.Drawing.Point(178, 50);
            this.cboEspece.Size = new System.Drawing.Size(140, 24);
            this.cboEspece.TabIndex = 3;
            this.cboEspece.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupBoxNvPatient.Controls.Add(this.cboEspece);
            // lblAge
            this.lblAge.Name = "lblAge";
            this.lblAge.Location = new System.Drawing.Point(332, 26);
            this.lblAge.Size = new System.Drawing.Size(76, 20);
            this.lblAge.Text = "Âge (ans)";
            this.lblAge.TabIndex = 4;
            this.GroupBoxNvPatient.Controls.Add(this.lblAge);
            // numAge
            this.numAge.Name = "numAge";
            this.numAge.Location = new System.Drawing.Point(332, 50);
            this.numAge.Size = new System.Drawing.Size(76, 24);
            this.numAge.TabIndex = 5;
            this.numAge.Maximum = 50m;
            this.numAge.Value = 0m;
            this.numAge.DecimalPlaces = 0;
            this.numAge.ThousandsSeparator = true;
            this.GroupBoxNvPatient.Controls.Add(this.numAge);
            // lblPoids
            this.lblPoids.Name = "lblPoids";
            this.lblPoids.Location = new System.Drawing.Point(422, 26);
            this.lblPoids.Size = new System.Drawing.Size(152, 20);
            this.lblPoids.Text = "Poids (g)";
            this.lblPoids.TabIndex = 6;
            this.GroupBoxNvPatient.Controls.Add(this.lblPoids);
            // numPoids
            this.numPoids.Name = "numPoids";
            this.numPoids.Location = new System.Drawing.Point(422, 50);
            this.numPoids.Size = new System.Drawing.Size(152, 24);
            this.numPoids.TabIndex = 7;
            this.numPoids.Maximum = 1000000m;
            this.numPoids.Value = 0m;
            this.numPoids.DecimalPlaces = 1;
            this.numPoids.ThousandsSeparator = true;
            this.GroupBoxNvPatient.Controls.Add(this.numPoids);
            // lblPuce
            this.lblPuce.Name = "lblPuce";
            this.lblPuce.Location = new System.Drawing.Point(588, 26);
            this.lblPuce.Size = new System.Drawing.Size(280, 20);
            this.lblPuce.Text = "Puce (15 caractères)";
            this.lblPuce.TabIndex = 8;
            this.GroupBoxNvPatient.Controls.Add(this.lblPuce);
            // txtPuce
            this.txtPuce.Name = "txtPuce";
            this.txtPuce.Location = new System.Drawing.Point(588, 50);
            this.txtPuce.Size = new System.Drawing.Size(280, 24);
            this.txtPuce.TabIndex = 9;
            this.GroupBoxNvPatient.Controls.Add(this.txtPuce);
            // lblRegimes
            this.lblRegimes.Name = "lblRegimes";
            this.lblRegimes.Location = new System.Drawing.Point(16, 88);
            this.lblRegimes.Size = new System.Drawing.Size(290, 20);
            this.lblRegimes.Text = "Régimes autorisés (au moins un)";
            this.lblRegimes.TabIndex = 10;
            this.GroupBoxNvPatient.Controls.Add(this.lblRegimes);
            // chkRegimes
            this.chkRegimes.Name = "chkRegimes";
            this.chkRegimes.Location = new System.Drawing.Point(16, 112);
            this.chkRegimes.Size = new System.Drawing.Size(240, 78);
            this.chkRegimes.TabIndex = 11;
            this.chkRegimes.CheckOnClick = true;
            this.chkRegimes.IntegralHeight = false;
            this.GroupBoxNvPatient.Controls.Add(this.chkRegimes);
            // lblUnites
            this.lblUnites.Name = "lblUnites";
            this.lblUnites.Location = new System.Drawing.Point(278, 114);
            this.lblUnites.Size = new System.Drawing.Size(310, 20);
            this.lblUnites.Text = "Tous les poids sont exprimés en grammes.";
            this.lblUnites.TabIndex = 12;
            this.GroupBoxNvPatient.Controls.Add(this.lblUnites);
            // lblRegimesAide
            this.lblRegimesAide.Name = "lblRegimesAide";
            this.lblRegimesAide.Location = new System.Drawing.Point(278, 138);
            this.lblRegimesAide.Size = new System.Drawing.Size(310, 20);
            this.lblRegimesAide.Text = "Le repas devra respecter un régime coché.";
            this.lblRegimesAide.TabIndex = 13;
            this.GroupBoxNvPatient.Controls.Add(this.lblRegimesAide);
            // btnAjouter
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Location = new System.Drawing.Point(628, 143);
            this.btnAjouter.Size = new System.Drawing.Size(130, 30);
            this.btnAjouter.Text = "Ajouter l'animal";
            this.btnAjouter.TabIndex = 14;
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.GroupBoxNvPatient.Controls.Add(this.btnAjouter);
            // btnVider
            this.btnVider.Name = "btnVider";
            this.btnVider.Location = new System.Drawing.Point(770, 143);
            this.btnVider.Size = new System.Drawing.Size(98, 30);
            this.btnVider.Text = "Effacer";
            this.btnVider.TabIndex = 15;
            this.btnVider.UseVisualStyleBackColor = true;
            this.btnVider.Click += new System.EventHandler(this.btnVider_Click);
            this.GroupBoxNvPatient.Controls.Add(this.btnVider);
            // DataGridView
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Location = new System.Drawing.Point(14, 26);
            this.DataGridView.Size = new System.Drawing.Size(866, 190);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.DataGridView.AutoGenerateColumns = false;
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.ReadOnly = true;
            this.DataGridView.MultiSelect = false;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
            this.groupAnimaux.Controls.Add(this.DataGridView);
            // btnVieillir
            this.btnVieillir.Name = "btnVieillir";
            this.btnVieillir.Location = new System.Drawing.Point(16, 38);
            this.btnVieillir.Size = new System.Drawing.Size(92, 30);
            this.btnVieillir.Text = "Vieillir (+1)";
            this.btnVieillir.TabIndex = 0;
            this.btnVieillir.UseVisualStyleBackColor = true;
            this.btnVieillir.Click += new System.EventHandler(this.btnVieillir_Click);
            this.groupActions.Controls.Add(this.btnVieillir);
            // btnSupprimer
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Location = new System.Drawing.Point(120, 38);
            this.btnSupprimer.Size = new System.Drawing.Size(110, 30);
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.TabIndex = 1;
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            this.groupActions.Controls.Add(this.btnSupprimer);
            // lblVariation
            this.lblVariation.Name = "lblVariation";
            this.lblVariation.Location = new System.Drawing.Point(260, 20);
            this.lblVariation.Size = new System.Drawing.Size(290, 20);
            this.lblVariation.Text = "Quantité / nouveau poids (g)";
            this.lblVariation.TabIndex = 2;
            this.groupActions.Controls.Add(this.lblVariation);
            // numVariation
            this.numVariation.Name = "numVariation";
            this.numVariation.Location = new System.Drawing.Point(260, 44);
            this.numVariation.Size = new System.Drawing.Size(158, 24);
            this.numVariation.TabIndex = 3;
            this.numVariation.Maximum = 1000000m;
            this.numVariation.Value = 100m;
            this.numVariation.DecimalPlaces = 1;
            this.numVariation.ThousandsSeparator = true;
            this.groupActions.Controls.Add(this.numVariation);
            // btnGrossir
            this.btnGrossir.Name = "btnGrossir";
            this.btnGrossir.Location = new System.Drawing.Point(440, 38);
            this.btnGrossir.Size = new System.Drawing.Size(130, 30);
            this.btnGrossir.Text = "Grossir (+)";
            this.btnGrossir.TabIndex = 4;
            this.btnGrossir.UseVisualStyleBackColor = true;
            this.btnGrossir.Click += new System.EventHandler(this.btnGrossir_Click);
            this.groupActions.Controls.Add(this.btnGrossir);
            // btnSport
            this.btnSport.Name = "btnSport";
            this.btnSport.Location = new System.Drawing.Point(582, 38);
            this.btnSport.Size = new System.Drawing.Size(130, 30);
            this.btnSport.Text = "Sport (−)";
            this.btnSport.TabIndex = 5;
            this.btnSport.UseVisualStyleBackColor = true;
            this.btnSport.Click += new System.EventHandler(this.btnSport_Click);
            this.groupActions.Controls.Add(this.btnSport);
            // btnPeser
            this.btnPeser.Name = "btnPeser";
            this.btnPeser.Location = new System.Drawing.Point(724, 38);
            this.btnPeser.Size = new System.Drawing.Size(144, 30);
            this.btnPeser.Text = "Peser (=)";
            this.btnPeser.TabIndex = 6;
            this.btnPeser.UseVisualStyleBackColor = true;
            this.btnPeser.Click += new System.EventHandler(this.btnPeser_Click);
            this.groupActions.Controls.Add(this.btnPeser);
            // lblAlimentation
            this.lblAlimentation.Name = "lblAlimentation";
            this.lblAlimentation.Location = new System.Drawing.Point(16, 82);
            this.lblAlimentation.Size = new System.Drawing.Size(180, 20);
            this.lblAlimentation.Text = "Type de repas";
            this.lblAlimentation.TabIndex = 7;
            this.groupActions.Controls.Add(this.lblAlimentation);
            // cboAlimentation
            this.cboAlimentation.Name = "cboAlimentation";
            this.cboAlimentation.Location = new System.Drawing.Point(16, 106);
            this.cboAlimentation.Size = new System.Drawing.Size(180, 24);
            this.cboAlimentation.TabIndex = 8;
            this.cboAlimentation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupActions.Controls.Add(this.cboAlimentation);
            // btnNourrir
            this.btnNourrir.Name = "btnNourrir";
            this.btnNourrir.Location = new System.Drawing.Point(210, 102);
            this.btnNourrir.Size = new System.Drawing.Size(104, 30);
            this.btnNourrir.Text = "Nourrir";
            this.btnNourrir.TabIndex = 9;
            this.btnNourrir.UseVisualStyleBackColor = true;
            this.btnNourrir.Click += new System.EventHandler(this.btnNourrir_Click);
            this.groupActions.Controls.Add(this.btnNourrir);
            // lblMotif
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Location = new System.Drawing.Point(350, 82);
            this.lblMotif.Size = new System.Drawing.Size(330, 20);
            this.lblMotif.Text = "Motif de consultation";
            this.lblMotif.TabIndex = 10;
            this.groupActions.Controls.Add(this.lblMotif);
            // cboMotif
            this.cboMotif.Name = "cboMotif";
            this.cboMotif.Location = new System.Drawing.Point(350, 106);
            this.cboMotif.Size = new System.Drawing.Size(234, 24);
            this.cboMotif.TabIndex = 11;
            this.cboMotif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupActions.Controls.Add(this.cboMotif);
            // btnSoigner
            this.btnSoigner.Name = "btnSoigner";
            this.btnSoigner.Location = new System.Drawing.Point(598, 102);
            this.btnSoigner.Size = new System.Drawing.Size(118, 30);
            this.btnSoigner.Text = "Soigner";
            this.btnSoigner.TabIndex = 12;
            this.btnSoigner.UseVisualStyleBackColor = true;
            //this.btnSoigner.Click += new System.EventHandler(this.btnSoigner_Click);
            this.groupActions.Controls.Add(this.btnSoigner);
            // lblTarifs
            this.lblTarifs.Name = "lblTarifs";
            this.lblTarifs.Location = new System.Drawing.Point(16, 148);
            this.lblTarifs.Size = new System.Drawing.Size(858, 20);
            this.lblTarifs.Text = "Tarifs : contrôle 35 € · vaccination 55 € · identification 70 € · chirurgie 250 € · urgence 120 €";
            this.lblTarifs.TabIndex = 13;
            this.groupActions.Controls.Add(this.lblTarifs);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.MinimumSize = new System.Drawing.Size(1196, 739);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "UI";
            this.Text = "Veterin\'air — Propriétaires et animaux";
            this.Load += new System.EventHandler(this.UI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoldeInitial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDepot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariation)).EndInit();
            this.groupProprietaires.ResumeLayout(false);
            this.groupProprietaires.PerformLayout();
            this.GroupBoxNvPatient.ResumeLayout(false);
            this.GroupBoxNvPatient.PerformLayout();
            this.groupAnimaux.ResumeLayout(false);
            this.groupAnimaux.PerformLayout();
            this.groupActions.ResumeLayout(false);
            this.groupActions.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupProprietaires;
        private System.Windows.Forms.GroupBox GroupBoxNvPatient;
        private System.Windows.Forms.GroupBox groupAnimaux;
        private System.Windows.Forms.GroupBox groupActions;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.Label lblNomProprietaire;
        private System.Windows.Forms.TextBox txtNomProprietaire;
        private System.Windows.Forms.Label lblPrenomProprietaire;
        private System.Windows.Forms.TextBox txtPrenomProprietaire;
        private System.Windows.Forms.Label lblSoldeInitial;
        private System.Windows.Forms.NumericUpDown numSoldeInitial;
        private System.Windows.Forms.Button btnAjouterProprietaire;
        private System.Windows.Forms.Label lblListeProprietaires;
        private System.Windows.Forms.ListBox listProprietaires;
        private System.Windows.Forms.Label lblSolde;
        private System.Windows.Forms.Label lblDepot;
        private System.Windows.Forms.NumericUpDown numDepot;
        private System.Windows.Forms.Button btnDeposer;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblEspece;
        private System.Windows.Forms.ComboBox cboEspece;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblPoids;
        private System.Windows.Forms.NumericUpDown numPoids;
        private System.Windows.Forms.Label lblPuce;
        private System.Windows.Forms.TextBox txtPuce;
        private System.Windows.Forms.Label lblRegimes;
        private System.Windows.Forms.CheckedListBox chkRegimes;
        private System.Windows.Forms.Label lblUnites;
        private System.Windows.Forms.Label lblRegimesAide;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnVider;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button btnVieillir;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Label lblVariation;
        private System.Windows.Forms.NumericUpDown numVariation;
        private System.Windows.Forms.Button btnGrossir;
        private System.Windows.Forms.Button btnSport;
        private System.Windows.Forms.Button btnPeser;
        private System.Windows.Forms.Label lblAlimentation;
        private System.Windows.Forms.ComboBox cboAlimentation;
        private System.Windows.Forms.Button btnNourrir;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.ComboBox cboMotif;
        private System.Windows.Forms.Button btnSoigner;
        private System.Windows.Forms.Label lblTarifs;
    }
}
