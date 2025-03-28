using lesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB {
    public partial class FrmVisiteAjout : FrmBase {
        public FrmVisiteAjout() {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmVisiteAjout_Load(object sender, EventArgs e) {
            parametrerComposant();
            remplirdgvVisites();
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ajout();
        }
        #endregion

        #region méthodes

        private void parametrerComposant()
        {
            this.Text = "Laboratoire pharmaceutique Galaxy-Swiss Bourdin Enregistrer un nouveau rendez-vous";

            parametrerZdl();
            parametrerDate();
            parametrerDgv(dgvVisites);
        }

        private void parametrerZdl()
        {
            // alimentation de la zone de liste déroulante contenant les praticiens
            foreach (Praticien p in Globale.mesPraticiens)
            {
                cbxPraticien.Items.Add(p);
            }
            cbxPraticien.DisplayMember = "NomPrenom";
            cbxPraticien.DropDownStyle = ComboBoxStyle.DropDownList;

            // alimentation de la zone de liste déroulante contenant les motifs
            foreach (Motif m in Globale.lesMotifs)
            {
                cbxMotif.Items.Add(m);
            }
            cbxMotif.DisplayMember = "Libelle";
            cbxMotif.DropDownStyle = ComboBoxStyle.DropDownList;
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
            #region paramètrage concernant le datagridview dans son ensemble

            // Accessibilité (doit être sur true si on veut pouvoir utiliser les barres de défilement)
            dgv.Enabled = true;

            // style de bordure
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // couleur de fond 
            dgv.BackgroundColor = Color.White;

            // couleur de texte  
            dgv.ForeColor = Color.Black;

            // police de caractères par défaut
            dgv.DefaultCellStyle.Font = new Font("Georgia", 11);

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
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            // l'utilisateur peut-il modifier l'ordre des colonnes ?
            dgv.AllowUserToOrderColumns = false;

            // le composant accepte t'il le 'déposer' dans un Glisser - Déposer ?
            dgv.AllowDrop = false;


            #endregion

            #region paramètrage concernant la ligne d'entête 

            // visibilité
            dgv.ColumnHeadersVisible = true;

            // bordure
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // style  [à adapter] (ici : noir sur fond transparent sans mise en évidence de la sélection)
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;    // même couleur que backColor pour ne pas mettre en évidence la colonne sélectionnée
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 12, FontStyle.Bold);


            // hauteur 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            #endregion

            #region paramètrage concernant l'entête de ligne (la colonne d'entête ou le sélecteur)

            // visible 
            dgv.RowHeadersVisible = false;

            // style de bordure  
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            #endregion

            #region paramètrage au niveau des lignes

            // Hauteur 
            dgv.RowTemplate.Height = 30;

            #endregion

            #region paramètrage au niveau des cellules

            // style de bordure 
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // couleur de fond, ne pas utiliser transparent car la couleur de la ligne sélectionnée restera après sélection
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            // Couleur alternative appliquée une ligne sur deux
            // unDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238);

            #endregion

            #region paramètrage au niveau de la zone sélectionnée

            // couleur de fond mettre la même que les cellules si on ne veut pas mettre la zone en évidence 
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;

            // couleur du texte
            dgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region paramètrage des colonnes

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie
            dgv.Width = 700;

            // Dimensionner la hauteur du DataGridview en fonction du nombre de lignes
            // à faire ici si le composant n'est pas dynamique

            // Nombre de colonne sans compter les colonnes ajoutées par la méthode Add
            dgv.ColumnCount = 4;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut
            dgv.Columns[0].HeaderText = "programmée le";
            dgv.Columns[0].Name = "Date";
            dgv.Columns[0].Width = 200;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.Columns[1].HeaderText = "à";
            dgv.Columns[1].Name = "Heure";
            dgv.Columns[1].Width = 50;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns[2].HeaderText = "sur";
            dgv.Columns[2].Name = "Lieu";
            dgv.Columns[2].Width = 200;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.Columns[3].HeaderText = "chez";
            dgv.Columns[3].Name = "Praticien";
            dgv.Columns[3].Width = 250;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        // remplir le datagridview dgvVisites
        private void remplirdgvVisites()
        {
            // récupérer les rendez-vous
            List<Visite> lesRendezVous = Globale.mesVisites.FindAll(x => x.Bilan is null);

            // vider le datagridView
            dgvVisites.Rows.Clear();

            // Parcourir ces visites pour les ajouter dans le datagridview
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (Visite uneVisite in lesRendezVous)
            {
                // mise en forme de la ville 
                string ville = ti.ToTitleCase(uneVisite.LePraticien.Ville.ToLower());
                dgvVisites.Rows.Add(uneVisite.DateEtHeure.ToLongDateString(), uneVisite.DateEtHeure.ToShortTimeString(), ville, uneVisite.LePraticien.NomPrenom);
            }
        }

        // enregistrement dans la base de données si aucune erreur retournée par le Sgbdr
        private void ajout()
        {
            // récupération du praticien
            Praticien lePraticien = (Praticien)cbxPraticien.SelectedItem;
            // récupération du motif
            Motif leMotif = (Motif)cbxMotif.SelectedItem;
            DateTime uneDate = dtpDate.Value;

            // ajout dans la base de données
            // en cas d'erreur afficher le message retourné 
            // sinon 
            //   créer un objet visite
            //   ajouter le dans la propriété LesVisites de l'objet global db 
            //   trier cette propriété
            //   recharger le datagridview afin qu'il intègre ce nouveau rendez-vous
            //    réactiver l'option du menu permettant la modification d'un rendez-vous (elle pouvait être désactivée si le visiteur n'avait pas encore de rendez-vous

            int idVisite = Passerelle.ajouterRendezVous(lePraticien.Id, leMotif.Id, uneDate, out string message);
            if (idVisite == 0)
            {
                MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // ajout de la visite dans la collection mesVisites et tri sur la date
                Globale.mesVisites.Add(new Visite(idVisite, lePraticien, leMotif, dtpDate.Value));
                Globale.mesVisites.Sort();


                // Message de réussite de l'opération d'ajout
                MessageBox.Show("Rendez-vous enregistré", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // mise à jour de l'interface au niveau du datagridview
                remplirdgvVisites();

                // réactiver l'option du menu permettant la modification d'un rendez-vous (elle pouvait être désactivée si le visiteur n'avait pas encore de rendez-vous
                modifierRendezVous.Enabled = true;
            }
        }


        #endregion

      
    }
}
