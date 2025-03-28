// ------------------------------------------
// Nom du fichier : Passerelle.cs
// Objet : classe Passerelle assurant l'alimentation des objets en mémoire
// Auteur :
// Date  : 
// ------------------------------------------

using System;
using System.Data;   // pour ParameterDirection
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using lesClasses;

namespace GSB
{
    static class Passerelle
    {

        private static MySqlConnection cnx;

        // Vérifier les paramètres de connexion et alimente l'objet globale leVisiteur
        static public bool seConnecter(string login, string mdp, out string message) {

            string chaineConnexion = $"Data Source=localhost;Database=gsb; User Id={login}; Password={mdp}";
            cnx = new MySqlConnection(chaineConnexion);
            bool ok = true;
            message = null;

            try {
                // etablit une connexion saut si une connexion existe déjà 
                cnx.Open();

            } catch (MySqlException e) {
                ok = false;
                if (e.Message.Contains("Accès refusé")) {
                    message = "Vos identifiants sont incorrects.";
                } else {
                    message = "Problème lors de la tentative de connexion au serveur.\n";
                    message += "Prière de contacter le service informatique";
                }
            } catch (Exception e) {
                message = e.ToString();
                ok = false;
            }

            if (ok) {
                // récupération des informations sur le visiteurs depuis la vue leVisiteur           
                MySqlCommand cmd = new MySqlCommand("Select nomPrenom from leVisiteur;", cnx);
                try {
                    Globale.nomVisiteur = cmd.ExecuteScalar().ToString();
                } catch (MySqlException e) {
                    message = "Erreur lors de la récupération de vos paramètres \n";
                    message += "Veuillez contacter le service informatique\n";
                    ok = false;
                }
            }
            if (ok) message = "Visiteur authentifié";
            return ok;
        }

        // se déconnecter
        static public void seDeConnecter() => cnx.Close();


        // chargement des données de la base dans les différentes collections statiques de la classe Globale 
        // dans cette méthode pas de bloc try catch car aucune erreur imprévisible en production ne doit se produire
        // en cas d'erreur en développement il faut laisser faire le debogueur de VS qui va signaler la ligne en erreur
        // le chargement des données concernant tous les visiteurs (médicament, type praticien, specialite, motif) ne doit être fait qu'une fois
        // si elles sont déja chargées on ne les recherche pas.
        // le chargement des données spécifiques au visiteur connecté doit se faire à chaque fois en vidant les anciennes données 
        static public void chargerDonnees()
        {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                MySqlDataReader curseur;

                // chargement des données générales si l'application vient d'être lancée : les médicaments, les types de praticiens, les spécialités ...
                if (Globale.lesMedicaments.Count == 0)
                {

                    // chargement des motifs de visite dans la collection lesMotifs de la classe Globale
                    cmd.CommandText = "Select id, libelle from Motif order by libelle;";
                    curseur = cmd.ExecuteReader();
                    while (curseur.Read()) Globale.lesMotifs.Add(new Motif(curseur.GetInt32("id"), curseur.GetString("libelle")));
                    curseur.Close();

                    // Chargement des types de praticien dans la collection lesTypes de la classe Globale

                    cmd.CommandText = "Select id, libelle from TypePraticien order by libelle;";
                    curseur = cmd.ExecuteReader();
                    while (curseur.Read()) Globale.lesTypes.Add(new TypePraticien(curseur.GetString("id"), curseur.GetString("libelle")));
                    curseur.Close();

                    // Chargement des Spécialités dans la collection lesSpecialites de la classe Globale
                    cmd.CommandText = "Select id, libelle from Specialite order by libelle;";
                    curseur = cmd.ExecuteReader();
                    while (curseur.Read()) Globale.lesSpecialites.Add(new Specialite(curseur.GetString("id"), curseur.GetString("libelle")));
                    curseur.Close();

                    // Chargement des familles de médicaments dans le dictionnaire lesFamilles de la classe Globale
                    cmd.CommandText = "Select id, libelle from Famille order by libelle;";
                    curseur = cmd.ExecuteReader();
                    while (curseur.Read())
                    {
                        string id = curseur.GetString("id");
                        Globale.lesFamilles.Add(id, new Famille(id, curseur.GetString("libelle")));
                    }
                    curseur.Close();

                    // chargement des médicaments dans la collection lesMedicaments de la classe Globale
                    cmd.CommandText = "SELECT id, nom, composition, effets, contreIndication, idFamille FROM medicament order by nom;";
                    curseur = cmd.ExecuteReader();
                    while (curseur.Read())
                    {
                        string id = curseur.GetString("id");
                        string nom = curseur.GetString("nom");
                        string composition = curseur.GetString("composition");
                        string effet = curseur.GetString("effets");
                        string contreIndication = curseur.GetString("contreIndication");
                        string idFamille = curseur.GetString("idFamille");
                        Globale.lesMedicaments.Add(new Medicament(id, nom, composition, effet, contreIndication, Globale.lesFamilles[idFamille]));
                    }
                    curseur.Close();
                }

                // chargement des données spécifiques au visiteur connecté (réalisé à chaque connexion d'un visiteur)

                // vider les anciennes données : nécessaire si une autre visiteur était connecté avant
                Globale.mesPraticiens.Clear();
                Globale.mesVisites.Clear();
                Globale.mesVilles.Clear();

                // chargement des villes gérées par le visiteur dans la collection mesVilles de la classe Globale
                cmd.CommandText = "Select nom, codePostal from mesVilles";
                curseur = cmd.ExecuteReader();
                while (curseur.Read()) Globale.mesVilles.Add(new Ville(curseur.GetString("nom"), curseur.GetString("codePostal")));
                curseur.Close();

                // chargement des praticiens à partir de la vue afin d'alimenter la collection mesPraticiens de la classe Globale
                // il faut récupérer l'objet TypePraticien et éventuellement l'objet Specialite
                cmd.CommandText = "SELECT id, nom, prenom, rue, codePostal, ville, email, telephone, idType, idSpecialite FROM mespraticiens;";
                curseur = cmd.ExecuteReader();
                while (curseur.Read())
                {
                    int id = curseur.GetInt32("id");
                    string nom = curseur.GetString("nom");
                    string prenom = curseur.GetString("prenom");
                    string rue = curseur.GetString("rue");
                    string codePostal = curseur.GetString("codePostal");
                    string ville = curseur.GetString("ville");
                    string email = curseur.GetString("email");
                    string telephone = curseur.GetString("telephone");
                    string idType = curseur.GetString("idType");
                    string idSpecialite = curseur.IsDBNull(9) ? null : (string)curseur["idSpecialite"];
                    // Récupération des objets TypePraticien et Specialite
                    TypePraticien t = Globale.lesTypes.Find(x => x.Id == idType);
                    Specialite s = null;
                    if (idSpecialite != null)
                    {
                        s = Globale.lesSpecialites.Find(x => x.Id == idSpecialite);
                    }
                    Globale.mesPraticiens.Add(new Praticien(id, nom, prenom, rue, codePostal, ville, email, telephone, t, s));
                }
                curseur.Close();

                // chargement des visites du visiteur connecté à partir de la vue afin d'alimenter la collection mesVisites
                cmd.CommandText = "SELECT id, dateEtHeure,  idMotif, idPraticien, bilan, premierMedicament, secondMedicament from mesvisites;";
                curseur = cmd.ExecuteReader();
                while (curseur.Read())
                {
                    int idVisite = curseur.GetInt32("id");
                    int idPraticien = curseur.GetInt32("idPraticien");
                    int idMotif = curseur.GetInt32("idMotif");

                    DateTime dateEtHeure = curseur.GetDateTime("dateEtHeure");
                    // récupération des objets liés
                    Motif m = Globale.lesMotifs.Find(x => x.Id == idMotif);
                    Praticien p = Globale.mesPraticiens.Find(x => x.Id == idPraticien);
                    // création de l'objet visite 
                    Visite uneVisite = new Visite(idVisite, p, m, dateEtHeure);
                    // si le bilan est enregistré
                    if (!curseur.IsDBNull(4))
                    {
                        // initialisation du bilan et du premierMedicament
                        string bilan = curseur.GetString("bilan");
                        string idPremierMedicament = curseur.GetString("premierMedicament");
                        Medicament premierMedicament = Globale.lesMedicaments.Find(x => x.Id == idPremierMedicament);
                        Medicament secondMedicament = null;
                        // initialisation éventuelle du second médicament s'il est renseigné
                        if (!curseur.IsDBNull(6))
                        {
                            string idSecondMedicament = curseur.GetString("secondMedicament");
                            secondMedicament = Globale.lesMedicaments.Find(x => x.Id == idSecondMedicament);
                        }
                        uneVisite.enregistrerBilan(bilan, premierMedicament, secondMedicament);
                        // le chargement des échantillons s'effetue globalement à la fin
                    }
                    Globale.mesVisites.Add(uneVisite);
                }
                curseur.Close();

                // chargement de la synthèse des échantillons distribués par le visiteur
                cmd.CommandText = "SELECT idVisite, idMedicament, quantite from mesEchantillons";
                curseur = cmd.ExecuteReader();
                while (curseur.Read())
                {
                    // récupération des données du curseur
                    int idVisite = curseur.GetInt32("idVisite");
                    string idMedicament = curseur.GetString("idMedicament");
                    int quantite = curseur.GetInt32("quantite");
                    // récupération de l'objet visite correspondant 
                    Visite v = Globale.mesVisites.Find(x => x.Id == idVisite);
                    // récupération de l'objet medicament
                    Medicament m = Globale.lesMedicaments.Find(x => x.Id == idMedicament);
                    // ajout d'un échantillon
                    v.ajouterEchantillon(m, quantite);
                }
                curseur.Close();
            
        }


        /// <summary>
        ///     Ajout d'une nouvelle visite
        /// </summary>
        /// <param name="idPraticien"></param>
        /// <param name="idMotif"></param>
        /// <param name="uneDate"></param>
        /// <param name="uneHeure"></param>
        /// <param name="message"></param>
        /// <returns>identifiant de la nouvelle visite ou 0 si erreur lors de la création</returns>
        static public int ajouterRendezVous(int idPraticien, int idMotif, DateTime uneDate, out string message)
        {
            int idVisite = 0;
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = cnx,
                CommandText = "ajouterRendezVous",
                CommandType = CommandType.StoredProcedure,
            };
            cmd.Parameters.AddWithValue("_idPraticien", idPraticien);
            cmd.Parameters.AddWithValue("_idMotif", idMotif);
            cmd.Parameters.AddWithValue("_dateEtHeure", uneDate);
            // paramètre en sortie
            cmd.Parameters.Add("_idVisite", MySqlDbType.Int32);
            cmd.Parameters["_idVisite"].Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                idVisite = (Int32)cmd.Parameters["_idVisite"].Value;
            }
            catch (MySqlException e)
            {
                message += e.Message;
            }
            return idVisite;
        }
        static public bool supprimerRendezVous(int idVisite, out string message)
        {
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = cnx,
                CommandText = "supprimerRendezVous",
                CommandType = CommandType.StoredProcedure,
            };
            cmd.Parameters.AddWithValue("_idVisite", idVisite);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                message += e.Message;
                return false;
            }
        }

        static public bool modifierRendezVous(int idVisite, DateTime uneDate, out string message)
        {
            bool success = false;
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = cnx,
                CommandText = "modifierRendezVous",
                CommandType = CommandType.StoredProcedure,
            };

            // Ajout du paramètre idVisite pour identifier le rendez-vous à modifier
            cmd.Parameters.AddWithValue("_idVisite", idVisite);
            cmd.Parameters.AddWithValue("_dateEtHeure", uneDate);

            try
            {
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (MySqlException e)
            {
                message += e.Message;
            }
            return success;
        }

        static public bool enregistrerBilan(Visite uneVisite, out string message)
        {
            message = string.Empty;
            // Déclaration d'un transaction
            MySqlTransaction uneTransaction = cnx.BeginTransaction();


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            // attacher la commande à la transcation
            cmd.Transaction = uneTransaction;

            // enregistrement au niveau de la table visite 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "enregistrerBilanVisite";
            cmd.Parameters.AddWithValue("_idVisite", uneVisite.Id);
            cmd.Parameters.AddWithValue("_bilan", uneVisite.Bilan);
            cmd.Parameters.AddWithValue("_premierMedicament", uneVisite.PremierMedicament.Id);
            cmd.Parameters.AddWithValue("_secondMedicament", uneVisite.SecondMedicament is null ? null : uneVisite.SecondMedicament.Id);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                message += e.Message;
                // annuler la transaction
                uneTransaction.Rollback();
                return false;
            }

            // suppression préalable des anciens échantillons
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "supprimerEchantillon";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("_idVisite", uneVisite.Id);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                message += e.Message;
                uneTransaction.Rollback();
                return false;
            }

            // enregistrements au niveau des echantillons
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ajouterEchantillon";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("_idVisite", uneVisite.Id);
            cmd.Parameters.Add("_idMedicament", MySqlDbType.VarChar, 10);
            cmd.Parameters.Add("_quantite", MySqlDbType.Int32);
            foreach (KeyValuePair<Medicament, int> unCouple in uneVisite)
            {
                Medicament unMedicament = unCouple.Key;
                int quantite = unCouple.Value;
                cmd.Parameters["_idMedicament"].Value = unMedicament.Id;
                cmd.Parameters["_quantite"].Value = quantite;

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    message += e.Message;
                    uneTransaction.Rollback();
                    return false;
                }
            }
            // validation de la transaction
            uneTransaction.Commit();
            return true;
        }


        static public int ajouterPraticien(string nom, string prenom, string rue, string codePostal, string ville, string telephone, string email, string unType, string uneSpecialite, out string message)
        {
            message = string.Empty;
            
            return 0;
        }


        static public bool modifierPraticien(int id, string nom, string rue, string codePostal, string ville, string telephone, string email, string unType, string uneSpecialite, out string message)
        {
            message = string.Empty;
            
            return false;
        }

        static public bool supprimerPraticien(int id, out string message)
        {
            message = string.Empty;
            return false;
        }

    }
}
