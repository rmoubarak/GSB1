
using System;
using System.Collections;
using System.Collections.Generic;

namespace lesClasses
{
    [Serializable]
    public class Visite : IEnumerable, IComparable<Visite>
    {

        // la classe doit implémenter une méthode de comparaison car les objets Visite
        // seront utilisés dans une collection qui sera triée après chaque ajout

        public int CompareTo(Visite o) => DateEtHeure.CompareTo(o.DateEtHeure);

        // attribut privé
        private SortedDictionary<Medicament, int> lesEchantillons;

        // Propriétés automatiques
        public int Id { get; }

        public Praticien LePraticien { get; set; }
        public Motif LeMotif { get; set; }
        public DateTime DateEtHeure { get; private set; }
        public string Bilan { get; set; }
        public Medicament PremierMedicament { get; set; }
        public Medicament SecondMedicament { get; set; }

        // Propriétés automatique en lecture seule ajoutées pour la mise en place du formulaire bilan 
        public string NomPrenomPraticien {
            get => LePraticien.NomPrenom;
        }

        public int NbEchantillon { 
            get => lesEchantillons.Count;
        }


        // Constructeur

        public Visite(int id, Praticien unPraticien, Motif unMotif, DateTime uneDateEtHeure)
        {
            Id = id;
            LePraticien = unPraticien;
            LeMotif = unMotif;
            DateEtHeure = uneDateEtHeure;
            Bilan = null;
            PremierMedicament = null;
            SecondMedicament = null;
            lesEchantillons = new SortedDictionary<Medicament, int>();

            // mise à jour de la relation bidirectionnelle avec l'objet Praticien
            LePraticien.ajouteVisite(this);
        }

        // méthode enregistrerBilan : alimente les propriétés Bilan, PremierMedicament, SecondMedicament
        public void enregistrerBilan(string bilan, Medicament premierMedicament, Medicament secondMedicament)
        {
            (Bilan, PremierMedicament, SecondMedicament) = (bilan, premierMedicament, secondMedicament);
        }

        // méthode déplacer ; alimente la propriété DateEtHeure
        public void deplacer(DateTime uneDateEtHeure) => DateEtHeure = uneDateEtHeure;


        // ajoute un échantillon 
        // si le médicament est déjà dans le dictionnaire on cumule les quantités
        public void ajouterEchantillon(Medicament unMedicament, int uneQuantite)
        {
            if (lesEchantillons.ContainsKey(unMedicament))
            {
                lesEchantillons[unMedicament] += uneQuantite;
            }
            else
            {
                lesEchantillons.Add(unMedicament, uneQuantite);
            }
        }

        // supprimer un échantillon
        public void supprimerEchantillon(Medicament unMedicament)
        {
            lesEchantillons.Remove(unMedicament);
        }

        // définition d'un itérateur permettant de parcourir les éléments du dictionnaire lesEchantillons
        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<Medicament, int> couple in lesEchantillons)
                yield return couple;
        }
    }
}
