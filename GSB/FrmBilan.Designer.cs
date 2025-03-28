namespace GSB
{
    partial class FrmBilan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSelection = new System.Windows.Forms.Panel();
            this.cbxPraticien = new System.Windows.Forms.ComboBox();
            this.cbxDate = new System.Windows.Forms.ComboBox();
            this.panelSaisie = new System.Windows.Forms.Panel();
            this.dgvEchantillons = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.cptQuantite = new System.Windows.Forms.NumericUpDown();
            this.cbxEchantillon = new System.Windows.Forms.ComboBox();
            this.msgBilan = new System.Windows.Forms.Label();
            this.msgSecondMedicament = new System.Windows.Forms.Label();
            this.msgPremierMedicament = new System.Windows.Forms.Label();
            this.txtBilan = new System.Windows.Forms.TextBox();
            this.cbxSecondMedicament = new System.Windows.Forms.ComboBox();
            this.cbxPremierMedicament = new System.Windows.Forms.ComboBox();
            this.btnEnregistrerBilan = new System.Windows.Forms.Button();
            this.panelSelection.SuspendLayout();
            this.panelSaisie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cptQuantite)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.cbxPraticien);
            this.panelSelection.Controls.Add(this.cbxDate);
            this.panelSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelection.Location = new System.Drawing.Point(0, 29);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(1120, 100);
            this.panelSelection.TabIndex = 13;
            // 
            // cbxPraticien
            // 
            this.cbxPraticien.FormattingEnabled = true;
            this.cbxPraticien.Location = new System.Drawing.Point(448, 35);
            this.cbxPraticien.Name = "cbxPraticien";
            this.cbxPraticien.Size = new System.Drawing.Size(270, 21);
            this.cbxPraticien.TabIndex = 1;
            this.cbxPraticien.SelectionChangeCommitted += new System.EventHandler(this.cbxPraticien_SelectionChangeCommitted);
            // 
            // cbxDate
            // 
            this.cbxDate.FormattingEnabled = true;
            this.cbxDate.Location = new System.Drawing.Point(80, 35);
            this.cbxDate.Name = "cbxDate";
            this.cbxDate.Size = new System.Drawing.Size(253, 21);
            this.cbxDate.TabIndex = 0;
            this.cbxDate.SelectionChangeCommitted += new System.EventHandler(this.cbxDate_SelectionChangeCommitted);
            // 
            // panelSaisie
            // 
            this.panelSaisie.Controls.Add(this.btnEnregistrerBilan);
            this.panelSaisie.Controls.Add(this.dgvEchantillons);
            this.panelSaisie.Controls.Add(this.btnAjouter);
            this.panelSaisie.Controls.Add(this.cptQuantite);
            this.panelSaisie.Controls.Add(this.cbxEchantillon);
            this.panelSaisie.Controls.Add(this.msgBilan);
            this.panelSaisie.Controls.Add(this.msgSecondMedicament);
            this.panelSaisie.Controls.Add(this.msgPremierMedicament);
            this.panelSaisie.Controls.Add(this.txtBilan);
            this.panelSaisie.Controls.Add(this.cbxSecondMedicament);
            this.panelSaisie.Controls.Add(this.cbxPremierMedicament);
            this.panelSaisie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSaisie.Location = new System.Drawing.Point(0, 129);
            this.panelSaisie.Name = "panelSaisie";
            this.panelSaisie.Size = new System.Drawing.Size(1120, 402);
            this.panelSaisie.TabIndex = 14;
            // 
            // dgvEchantillons
            // 
            this.dgvEchantillons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEchantillons.Location = new System.Drawing.Point(569, 116);
            this.dgvEchantillons.Name = "dgvEchantillons";
            this.dgvEchantillons.Size = new System.Drawing.Size(406, 174);
            this.dgvEchantillons.TabIndex = 9;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(991, 72);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 8;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // cptQuantite
            // 
            this.cptQuantite.Location = new System.Drawing.Point(789, 75);
            this.cptQuantite.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cptQuantite.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cptQuantite.Name = "cptQuantite";
            this.cptQuantite.Size = new System.Drawing.Size(132, 20);
            this.cptQuantite.TabIndex = 7;
            this.cptQuantite.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxEchantillon
            // 
            this.cbxEchantillon.FormattingEnabled = true;
            this.cbxEchantillon.Location = new System.Drawing.Point(553, 71);
            this.cbxEchantillon.Name = "cbxEchantillon";
            this.cbxEchantillon.Size = new System.Drawing.Size(165, 21);
            this.cbxEchantillon.TabIndex = 6;
            // 
            // msgBilan
            // 
            this.msgBilan.AutoSize = true;
            this.msgBilan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgBilan.ForeColor = System.Drawing.Color.Red;
            this.msgBilan.Location = new System.Drawing.Point(117, 277);
            this.msgBilan.Name = "msgBilan";
            this.msgBilan.Size = new System.Drawing.Size(35, 13);
            this.msgBilan.TabIndex = 5;
            this.msgBilan.Text = "label1";
            // 
            // msgSecondMedicament
            // 
            this.msgSecondMedicament.AutoSize = true;
            this.msgSecondMedicament.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgSecondMedicament.ForeColor = System.Drawing.Color.Red;
            this.msgSecondMedicament.Location = new System.Drawing.Point(117, 100);
            this.msgSecondMedicament.Name = "msgSecondMedicament";
            this.msgSecondMedicament.Size = new System.Drawing.Size(35, 13);
            this.msgSecondMedicament.TabIndex = 4;
            this.msgSecondMedicament.Text = "label1";
            // 
            // msgPremierMedicament
            // 
            this.msgPremierMedicament.AutoSize = true;
            this.msgPremierMedicament.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgPremierMedicament.ForeColor = System.Drawing.Color.Red;
            this.msgPremierMedicament.Location = new System.Drawing.Point(117, 47);
            this.msgPremierMedicament.Name = "msgPremierMedicament";
            this.msgPremierMedicament.Size = new System.Drawing.Size(35, 13);
            this.msgPremierMedicament.TabIndex = 3;
            this.msgPremierMedicament.Text = "label1";
            // 
            // txtBilan
            // 
            this.txtBilan.Location = new System.Drawing.Point(119, 116);
            this.txtBilan.Multiline = true;
            this.txtBilan.Name = "txtBilan";
            this.txtBilan.Size = new System.Drawing.Size(247, 148);
            this.txtBilan.TabIndex = 2;
            // 
            // cbxSecondMedicament
            // 
            this.cbxSecondMedicament.FormattingEnabled = true;
            this.cbxSecondMedicament.Location = new System.Drawing.Point(117, 72);
            this.cbxSecondMedicament.Name = "cbxSecondMedicament";
            this.cbxSecondMedicament.Size = new System.Drawing.Size(216, 21);
            this.cbxSecondMedicament.TabIndex = 1;
            // 
            // cbxPremierMedicament
            // 
            this.cbxPremierMedicament.FormattingEnabled = true;
            this.cbxPremierMedicament.Location = new System.Drawing.Point(117, 19);
            this.cbxPremierMedicament.Name = "cbxPremierMedicament";
            this.cbxPremierMedicament.Size = new System.Drawing.Size(216, 21);
            this.cbxPremierMedicament.TabIndex = 0;
            // 
            // btnEnregistrerBilan
            // 
            this.btnEnregistrerBilan.Location = new System.Drawing.Point(319, 324);
            this.btnEnregistrerBilan.Name = "btnEnregistrerBilan";
            this.btnEnregistrerBilan.Size = new System.Drawing.Size(355, 44);
            this.btnEnregistrerBilan.TabIndex = 10;
            this.btnEnregistrerBilan.Text = "Enregistrer le bilan";
            this.btnEnregistrerBilan.UseVisualStyleBackColor = true;
            this.btnEnregistrerBilan.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // FrmBilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 568);
            this.Controls.Add(this.panelSaisie);
            this.Controls.Add(this.panelSelection);
            this.Name = "FrmBilan";
            this.Text = "FrmBilan";
            this.Load += new System.EventHandler(this.FrmBilan_Load);
            this.Controls.SetChildIndex(this.panelSelection, 0);
            this.Controls.SetChildIndex(this.panelSaisie, 0);
            this.panelSelection.ResumeLayout(false);
            this.panelSaisie.ResumeLayout(false);
            this.panelSaisie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEchantillons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cptQuantite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.Panel panelSaisie;
        private System.Windows.Forms.ComboBox cbxPraticien;
        private System.Windows.Forms.ComboBox cbxDate;
        private System.Windows.Forms.ComboBox cbxPremierMedicament;
        private System.Windows.Forms.ComboBox cbxSecondMedicament;
        private System.Windows.Forms.Label msgPremierMedicament;
        private System.Windows.Forms.TextBox txtBilan;
        private System.Windows.Forms.NumericUpDown cptQuantite;
        private System.Windows.Forms.ComboBox cbxEchantillon;
        private System.Windows.Forms.Label msgBilan;
        private System.Windows.Forms.Label msgSecondMedicament;
        private System.Windows.Forms.DataGridView dgvEchantillons;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnEnregistrerBilan;
    }
}