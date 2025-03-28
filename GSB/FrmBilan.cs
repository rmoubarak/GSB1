using GSB.Properties;
using lesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    public partial class FrmBilan : FrmBase
    {
        private Visite uneVisite;


        public FrmBilan()
        {
            InitializeComponent();
        }

        #region procédures évènementielle

        private void FrmBilan_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            remplirZoneDeListe(cbxPremierMedicament);
            remplirZoneDeListe(cbxSecondMedicament);
            remplirZoneDeListe(cbxEchantillon);
            remplirCbxDate();
            remplirCbxPraticien();

        }

        private void cbxDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            remplirCbxPraticien();
        }

        private void cbxPraticien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            afficherVisite();
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {

            if (cbxEchantillon.SelectedIndex >= 0) { 
                ajouterEchantillon();
            }
            else { 
                MessageBox.Show("Vous devez sélectionner le médicament fourni en échantillon", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            bool premierMedicamentOk = controlerPremierMedicament();
            bool secondMedicamentOk = controlerSecondMedicament();
            bool bilanOk = controlerBilan();
            if (premierMedicamentOk && secondMedicamentOk && bilanOk)
            {
                enregistrer();
            }
        }


        #endregion



        #region méthodes
        private void parametrerComposant()
        {
            // ouverture et redimensionnement limités
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.Text = "Laboratoire Galaxy-Swiss Bourdin - Enregistrement le bilan d'un visite";

            // la zone de liste doit contenir des objets Visite en affichant uniquement le nom prénom du praticien
            cbxPraticien.DisplayMember = "NomPrenomPraticien";

            // parametrage du composant ctpQuantite
            cptQuantite.Minimum = 1;
            cptQuantite.Maximum = 10;
            cptQuantite.Value = 1;

            // paramétrage du datagridview
            parametrerDgv(dgvEchantillons);
        }

        
        private void parametrerDgv(DataGridView dgv)
        {
            #region paramètrage concernant le datagridview dans son ensemble

            // style de bordure
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // couleur de fond 
            dgv.BackgroundColor = Color.White;

            // couleur de texte  
            dgv.ForeColor = Color.Black;

            // police de caractères par défaut
            dgv.DefaultCellStyle.Font = new Font("Garamond", 11);

            // mode de sélection dans le composant : FullRowSelect, CellSelect ...
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // sélection multiple 
            dgv.MultiSelect = false;

            // l'utilisateur peut-il ajouter ou supprimer des lignes ?
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;

            // L'utilisateur peut-il modifier le contenu des cellules ou est-elle réservée à la programmation ?
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;

            // l'utilisateur peut-il redimensionner les colonnes et les lignes ?
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            // l'utilisateur peut-il modifier l'ordre des colonnes ?
            dgv.AllowUserToOrderColumns = false;

            // le composant accepte t'il le 'déposer' dans un Glisser - Déposer ?
            dgv.AllowDrop = false;

            #endregion

            #region paramètrage concernant la ligne d'entête (les entêtes de chaque colonnes)

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
            // unDgv.Width = 603;

            // Dimensionner la hauteur du DataGridview en fonction du nombre de lignes
            // unDgv.Height = Globale.LeVisiteur.getNbRendezVous() * (unDgv.RowTemplate.Height) + unDgv.ColumnHeadersHeight;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            // unDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            dgv.Columns.Add(colSupprimer);

            // colonne 2 le nom du médicament en lecture seule
            DataGridViewTextBoxColumn colNomMedicament = new DataGridViewTextBoxColumn();
            colNomMedicament.ReadOnly = true;
            colNomMedicament.Name = "Medicament";
            colNomMedicament.HeaderText = "Médicament";
            colNomMedicament.Width = 200;
            dgv.Columns.Add(colNomMedicament);

            // colonne 3 : la quantité qui est modifiable
            DataGridViewTextBoxColumn colQuantite = new DataGridViewTextBoxColumn();
            colQuantite.Name = "Quantite";
            colQuantite.HeaderText = "Quantité";
            colQuantite.Width = 100;
            colQuantite.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns.Add(colQuantite);

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        private void remplirCbxDate()
        {
            // remplir la zone de liste déroulante des dates des visites
            List<Visite> lesVisites = Globale.mesVisites.FindAll(x => x.DateEtHeure <= DateTime.Now);
            // Extraire les dates distinctes
            var lesDates = lesVisites
                                    .Select(v => v.DateEtHeure.Date)  // Prendre uniquement la partie Date de DateEtHeure
                                    .Distinct()                      // Sélectionner les dates distinctes
                                    .OrderBy(date => date)           // Optionnel : trier les dates par ordre croissant
                                    .ToList();
            // Remplir le ComboBox avec les dates distinctes
            cbxDate.Items.Clear();
            foreach (var date in lesDates)
            {
                cbxDate.Items.Add(date.ToShortDateString()); // Ajouter la date au ComboBox sous format court (ex: "10/03/2025")
            }
            cbxDate.SelectedIndex = 0;
        }


        private void remplirCbxPraticien()
        {
            // récupérer les praticiens visités à la date sélectionnée
            DateTime dateVisite = DateTime.Parse(cbxDate.SelectedItem.ToString());
            List<Visite> lesVisites = Globale.mesVisites.FindAll(x => x.DateEtHeure.Date == dateVisite);

            // remplir la zone de liste
            cbxPraticien.Items.Clear();
            foreach (Visite v in lesVisites)
            {
                cbxPraticien.Items.Add(v);
            }
            // sélectionner le premier praticien de la liste
            cbxPraticien.SelectedIndex = 0;
            afficherVisite();
        }

        private void remplirZoneDeListe(ComboBox zdl)
        {
            foreach (Medicament m in Globale.lesMedicaments)
            {
                zdl.Items.Add(m);
            }
            zdl.DisplayMember = "Nom";
            zdl.ValueMember = "Id";
            zdl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            zdl.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void remplirDgvEchantillon()
        {
            dgvEchantillons.Rows.Clear();
            foreach (KeyValuePair<Medicament, int> unCouple in uneVisite)
            {
                Medicament unMedicament = unCouple.Key;
                int quantite = unCouple.Value;
                dgvEchantillons.Rows.Add(unMedicament, null, unMedicament.Nom, quantite.ToString());
            }
        }

        private void afficherVisite()
        {
            uneVisite = cbxPraticien.SelectedItem as Visite;

            // alimentation éventuelle des champs de saisie s'il s'agit de modifier une visite dont le bilan est déjà saisi
            txtBilan.Text = uneVisite.Bilan ?? "";
            cbxPremierMedicament.SelectedItem = uneVisite.PremierMedicament;
            cbxSecondMedicament.SelectedItem = uneVisite.SecondMedicament;
            // remplir le datagridview avec les échantillons de la visite
            remplirDgvEchantillon();
        }

        private void ajouterEchantillon()
        {
            // récupération du médicament contenu dans la zone de liste
            Medicament leMedicament = (Medicament)cbxEchantillon.SelectedItem;
            // ajout de ce médicament associé à sa quantité comme échantillon dans l'objet visite 
            uneVisite.ajouterEchantillon(leMedicament, Decimal.ToInt32(cptQuantite.Value));
            // ajout dans le datagridView : il peut s'agir d'ajouter une ligne ou de modifier la quantité d'une ligne existente
            // le plus simple consiste à le réafficher  
            afficherEchantillon();
        }

        // réinitialiser le datagridview en parcourant les chantillons de l'objet visite
        private void afficherEchantillon()
        {
            dgvEchantillons.Rows.Clear();
            foreach (KeyValuePair<Medicament, int> unCouple in uneVisite)
            {
                Medicament unMedicament = unCouple.Key;
                int quantite = unCouple.Value;
                dgvEchantillons.Rows.Add(unMedicament, null, unMedicament.Nom, quantite.ToString());
            }
        }

        // retourne false si le premierMedicament n'est pas correctement 
        private bool controlerPremierMedicament()
        {
            if (cbxPremierMedicament.SelectedIndex == -1)
            {
                if (cbxPremierMedicament.Text.Length > 0)
                {
                    msgPremierMedicament.Text = "Veuillez sélectionner un médicament dans la liste proposée.";
                }
                else
                {
                    msgPremierMedicament.Text = "Vous devez indiquer le médicament présenté lors de votre visite.";
                }
                msgPremierMedicament.Visible = true;
                return false;
            }

            msgPremierMedicament.Text = "";
            msgPremierMedicament.Visible = false;
            return true;
        }

        // retourne false si le secondMedicament sélectionné est le même que le premier et place un message sous le champ
        private bool controlerSecondMedicament()
        {
            bool ok = true;
            msgSecondMedicament.Text = "";
            msgSecondMedicament.Visible = false;
            if (cbxSecondMedicament.SelectedIndex == -1)
            {
                if (cbxSecondMedicament.Text.Length > 0)
                {
                    msgSecondMedicament.Text = "Veuillez sélectionner un médicament dans la liste proposée.";
                    msgSecondMedicament.Visible = true;
                    ok = false;
                }
            }
            else if (cbxPremierMedicament.SelectedIndex == cbxSecondMedicament.SelectedIndex)
            {
                msgSecondMedicament.Text = "Veuillez sélectionner un autre médicament.";
                msgSecondMedicament.Visible = true;
                ok = false;
            }
            return ok;
        }

        // retourne false si le champ bilan n'est pas renseigné et place un message sous le champ
        private bool controlerBilan()
        {
            if (txtBilan.Text == string.Empty)
            {
                msgBilan.Text = "Le bilan doit être complété ";
                msgBilan.Visible = true;
                return false;
            }
            msgBilan.Text = "";
            msgBilan.Visible = false;
            return true;
        }


        private void enregistrer()
        {
            // récupérer le premier médicament sélectionné
            Medicament premierMedicament = (Medicament)cbxPremierMedicament.SelectedItem;
            // récupérer le second médicament sélectionné
            Medicament secondMedicament = (cbxSecondMedicament.SelectedIndex >= 0) ? (Medicament)cbxSecondMedicament.SelectedItem : null;
            // mise à jour de l'objet Visite en mémoire
            uneVisite.enregistrerBilan(txtBilan.Text, premierMedicament, secondMedicament);
            // mise à jour dans la base de données
            bool ok = Passerelle.enregistrerBilan(uneVisite, out string message);
            if (!ok)
            {
                MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Bilan enregistré", "Bilan enregistré", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

       
    } 
}
