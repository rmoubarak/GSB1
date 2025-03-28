using GSB.Properties;
using lesClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace GSB
{
    public partial class FrmVisiteMaj : FrmBase
    {
        private Visite laVisite;
        public FrmVisiteMaj()
        {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmVisiteMaj_Load(object sender, EventArgs e)
        {
            parametrerComposant();
          
        }

        private void btnModifie_Click(object sender, EventArgs e)
        {
            modification();
        }

        private void dgvVisitesMaj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                suppression();
            }

        }

        #endregion



        #region méthodes
        private void parametrerComposant()
        {
            this.Text = "Laboratoire pharmaceutique Galaxy-Swiss Bourdin - Modification de la planification d'un rendez-vous";
            parametrerDate();
            parametrerDgv(dgvVisitesMaj);
            remplirdgvVisitesMaj();
        }


        private void modification()
        {
            // récupérer la date et l'heure
            DateTime date = dtpDate.Value;
            // déplacer le rendez-vous
            laVisite.deplacer(date);
            // mettre à jour le datagridview
            remplirdgvVisitesMaj();
            // vider les contrôles
            lblNom.Text = "";
            lblDate.Text = "";
            dtpDate.Value = dtpDate.MinDate;
        }

        private void suppression()
        {
            // Vérifier si une ligne est effectivement sélectionnée
            if (dgvVisitesMaj.SelectedRows.Count == 0)
            {
                MessageBox.Show("Aucune visite sélectionnée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Récupérer la visite
                Visite uneVisite = (Visite)dgvVisitesMaj.SelectedRows[0].Cells[0].Value;

                // Demander confirmation avant suppression
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette visite ?", "Confirmation",

                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Supprimer la visite
                    Globale.mesVisites.Remove(uneVisite);

                    // Mettre à jour le datagridview
                    remplirdgvVisitesMaj();

                    // Réinitialiser les contrôles
                    ReinitialiserControles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Méthode extraite pour réinitialiser les contrôles
        private void ReinitialiserControles()
        {
            lblNom.Text = string.Empty;
            lblDate.Text = string.Empty;
            dtpDate.Value = dtpDate.MinDate;
        }

        private void parametrerDate()
        {
            // la prise de rendez vous s'effectue sur les deux mois à venir : propriétés MinDate et MaxDate
            // la valeur la plus petite (qui sera la valeur proposée par défaut) est dans 2 heures sans les minutes ou après demain 8 heure si demain est un dimanche
            // la valeur la plus grande possible est dans 60 jours à 19 heures

            DateTime dateMin = DateTime.Now.AddHours(2).AddMinutes(-DateTime.Now.Minute);
            if (dateMin.Hour >= 19) dateMin = DateTime.Today.AddDays(1).AddHours(8);
            if (dateMin.DayOfWeek == DayOfWeek.Sunday) dateMin = DateTime.Today.AddDays(1).AddHours(8);
            dtpDate.MinDate = dateMin;
            dtpDate.MaxDate = DateTime.Today.AddDays(60).AddHours(19);
            dtpDate.Value = dateMin;  // ne semble pas utile
                                      // Mise en forme de la date
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;

        }

        private void parametrerDgv(DataGridView dgv)
        {
            #region paramétrage concernant le datagridview dans son ensemble

            // style de bordure
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // couleur de fond 
            dgv.BackgroundColor = Color.White;

            // couleur de texte  
            dgv.ForeColor = Color.Black;

            // police de caractères par défaut
            dgv.DefaultCellStyle.Font = new Font("Garomond", 11);

            // mode de sélection dans le composant : FullRowSelect, CellSelect ...
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // sélection multiple 
            dgv.MultiSelect = false;

            // l'utilisateur peut-il ajouter ou supprimer des lignes ?
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;

            // L'utilisateur peut-il modifier le contenu des cellules ou est-elle réservée à la programmation ?
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;

            // l'utilisateur peut-il redimensionner les colonnes et les lignes ?
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;

            // l'utilisateur peut-il modifier l'ordre des colonnes ?
            dgv.AllowUserToOrderColumns = false;

            // le composant accepte t'il le 'déposer' dans un Glisser - Déposer ?
            dgv.AllowDrop = false;

            // barre de défilement
            dgv.ScrollBars = ScrollBars.Both;

            #endregion

            #region paramétrage concernant la ligne d'entête (les entêtes de chaque colonnes)

            // accessibilité du composant
            dgv.Enabled = true;

            // permissions
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowDrop = false;
            dgv.AllowUserToOrderColumns = false;

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie
            // dgv.Width = 754;

            //  bordures extérieures
            dgv.GridColor = Color.Black;
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // Bordure au niveau des cellules
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // bordure au niveau de la colonne d'entête
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // hauteur 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            #endregion

            #region paramètrage concernant l'entête de ligne (la colonne d'entête ou le sélecteur)

            // visibilité
            dgv.RowHeadersVisible = false;

            // style de bordure  
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            #endregion

            #region paramètrage au niveau des lignes

            // Hauteur 
            dgv.RowTemplate.Height = 30;

            #endregion

            #region paramètrage au niveau des cellules

            // couleur de fond, ne pas utiliser transparent car la couleur de la ligne sélectionnée restera après sélection
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            // Couleur alternative appliquée une ligne sur deux
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238);

            #endregion

            #region paramètrage au niveau de la zone sélectionnée

            // couleur de fond mettre la même que les cellules si on ne veut pas mettre la zone en évidence 
            // dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lavender;

            // couleur du texte
            // dgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;


            #endregion

            #region paramètrage des colonnes

            // Entête aux niveaux des colonnes 
            dgv.ColumnHeadersVisible = false;

            // Dimensionner la hauteur du DataGridview en fonction du nombre de lignes
            // unDgv.Height = Globale.LeVisiteur.getNbRendezVous() * (unDgv.RowTemplate.Height) + unDgv.ColumnHeadersHeight;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut

            // colonne 0 masquée contenant l'objet Medicament
            DataGridViewTextBoxColumn colMedicament = new DataGridViewTextBoxColumn();
            colMedicament.Width = 0;
            dgv.Columns.Add(colMedicament);


            // colonne 1 colonne afficher l'image permettant la suppression
            DataGridViewImageColumn colSupprimer = new DataGridViewImageColumn();
            colSupprimer.HeaderText = "";
            colSupprimer.Image = Resources.supprimer;
            colSupprimer.Width = 40;
            colSupprimer.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns.Add(colSupprimer);

            // colonne 2 colonne affichant la date et l'heure du rendez-vous
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.HeaderText = "Date et heure du rendez-vous";
            colDate.Width = 250;
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns.Add(colDate);


            // colonne 3 colonne affichant le praticien
            DataGridViewTextBoxColumn colPraticien = new DataGridViewTextBoxColumn();
            colPraticien.HeaderText = "Praticien";
            colPraticien.Width = 400;
            colPraticien.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns.Add(colPraticien);

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }


        // Remplir le dgvVisitesMaj
        private void remplirdgvVisitesMaj()
        {
            // récupérer les rendez-vous
            List<Visite> lesRendezVous = Globale.mesVisites.FindAll(x => x.Bilan is null);

            // vider le datagridView
            dgvVisitesMaj.Rows.Clear();

            // Parcourir ces visites pour les ajouter dans le datagridview
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (Visite uneVisite in lesRendezVous)
            {
                // mise en forme de la ville 
                string ville = ti.ToTitleCase(uneVisite.LePraticien.Ville.ToLower());
                dgvVisitesMaj.Rows.Add(uneVisite, null, uneVisite.DateEtHeure.ToString("dddd dd MMMM yyyy ' à ' hh:mm"), uneVisite.LePraticien.NomPrenom + '(' + ville + ')');
            }
        }


        private void afficherVisite(Visite uneVisite)
        {
            lblNom.Text = uneVisite.LePraticien.NomPrenom;
            lblDate.Text = uneVisite.DateEtHeure.ToLongDateString();
            // dtpDate.Value = uneVisite.DateEtHeure;
            dtpDate.Value = dtpDate.MinDate;
        }

        private void dgvVisitesMaj_SelectionChanged(object sender, EventArgs e)
        {
            // vider le datagridview déclenche cet évènement : il faut vérifier qu'
            if (dgvVisitesMaj.SelectedRows.Count > 0) { 
            laVisite = (Visite)dgvVisitesMaj.SelectedRows[0].Cells[0].Value;
                afficherVisite(laVisite);


            }
        }

        
    }
}
#endregion