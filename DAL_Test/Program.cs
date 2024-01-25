
//test insert accessoire

using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using System.Data.SqlClient;
using Tools;

string CS = @"Data Source=GOS-VDI206\TFTIC;Initial Catalog=DB_Guitarotheque;Integrated Security=True;";

SqlConnection sqlConnection = new SqlConnection(CS);
Connection co = new Connection(CS);


#region Test Accessoire

IAccessoireRepository access = new AccessoireRepository(co);

#region InsertAccessoire
//AccessoireData accessoire = new AccessoireData()
//{
//    Libelle = "Siege",
//    Description = "Sert à s'asseoir",
//    Prix = 200.99M
//};

//access.Insert(accessoire);
#endregion

#region DeleteAccesoire by Id
//access.Delete(1);
#endregion

#region UpdateAccessoire
//AccessoireData accessoire = new AccessoireData()
//{
//    Libelle = "Modif DAL",
//    Description = "OK",
//    Prix = 120.50M
//};

//access.Update(accessoire, 5);
#endregion

#region GetAccessoireById
//int accessoireId = 3; // Remplacez par l'ID réel que vous souhaitez récupérer.
//AccessoireData accessoire = new AccessoireData();
//accessoire = access.Get(accessoireId);

//// Afficher les données récupérées.
//if (accessoire != null)
//{
//    Console.WriteLine($"Accessoire trouvé - ID: {accessoire.Id_Accessoire}, Libelle: {accessoire.Libelle}, Description: {accessoire.Description}, Prix: {accessoire.Prix}");
//}
//else
//{
//    Console.WriteLine($"Aucun accessoire trouvé avec l'ID {accessoireId}");
//}
#endregion

#region GetAllAccessoire
//IEnumerable<AccessoireData> accessoire = access.GetAll();

//foreach (AccessoireData a in accessoire)
//{
//    Console.WriteLine($"Accessoire trouvé - ID: {a.Id_Accessoire}, Libelle: {a.Libelle}, Description: {a.Description}, Prix: {a.Prix}");

//}
#endregion

#endregion

Console.WriteLine("----------------------------------------------------------------");

#region Test Groupe

IGroupeRepository group = new GroupeRepository(co);

#region InsertGroupe

//GroupeData groupe = new GroupeData()
//{
//    Nom = "Test",
//    Genre = "Rock",
//    AnneeCreation = 1981
//};

//group.Insert(groupe);

#endregion

#region DeleteGroupe by Id
//group.Delete(3);
#endregion

#region UpdateGroupe
//GroupeData groupe = new GroupeData()
//{
//    Nom = "Metallica",
//    Genre = "Rock/Metal",
//    AnneeCreation = 1981
//};

//group.Update(groupe, 2);
#endregion

#region GetGroupeById
//int groupeId = 2; // Remplacez par l'ID réel que vous souhaitez récupérer.
//GroupeData groupe = new GroupeData();
//groupe = group.Get(groupeId);

//// Afficher les données récupérées.
//if (groupe != null)
//{
//    Console.WriteLine($"Groupe trouvé - ID: {groupe.Id_Groupe}, Nom: {groupe.Nom}, Genre: {groupe.Genre}, Annee de creation: {groupe.AnneeCreation}");
//}
//else
//{
//    Console.WriteLine($"Aucun groupe trouvé avec l'ID {groupeId}");
//}
#endregion

#region GetAllGroupe

//IEnumerable<GroupeData> groupedata = group.GetAll();

//foreach (GroupeData g in groupedata)
//{
//    Console.WriteLine($"Groupe trouvé - ID: {g.Id_Groupe}, Nom: {g.Nom}, Genre: {g.Genre}, Annee de creation: {g.AnneeCreation}");

//}
#endregion

#endregion

Console.WriteLine("----------------------------------------------------------------");

#region Test Guitare

IGuitareRepository guitar = new GuitareRepository(co);

#region InsertGuitare

//GuitareData guitare = new GuitareData()
//{

//    Libelle = "ESP LTD EC-1000FR Black Satin",
//    AnneeDeSortie = 2021,
//    Description = "Corps en acajou\r\nManche collé en acajou\r\nTouche en ébène\r\nProfil du manche: U mince\r\n24 frettes Extra Jumbo en acier inoxydable\r\nLargeur au sillet: 42 mm\r\nDiapason: 629 mm\r\nRayon de la touche: 350 mm\r\n1 micro double bobinage EMG 81 (chevalet)\r\n1 micro double bobinage EMG 60 (manche)\r\n2 réglages de volume\r\n1 réglage de tonalité\r\nSélecteur 3 positions\r\nVibrato Floyd Rose 1000 SE\r\nMécaniques Grover\r\nAccastillage noir\r\nCordes D'Addario XL120 (.009 - .042)\r\nCouleur: Black Satin",
//    NbrCordes = 6,
//    Prix = 1299.00M
//};

//guitar.Insert(guitare);

#endregion

#region DeleteGuitare by Id
//guitar.Delete(4);
#endregion

#region UpdateGuitare
//GuitareData guitare = new GuitareData()
//{
//    Libelle = "ESP LTD EC-1000FR Black Satin",
//    AnneeDeSortie = 2021,
//    Description = "Corps en acajou\r\nManche collé en acajou\r\nTouche en ébène\r\nProfil du manche: U mince\r\n24 frettes Extra Jumbo en acier inoxydable\r\nLargeur au sillet: 42 mm\r\nDiapason: 629 mm\r\nRayon de la touche: 350 mm\r\n1 micro double bobinage EMG 81 (chevalet)\r\n1 micro double bobinage EMG 60 (manche)\r\n2 réglages de volume\r\n1 réglage de tonalité\r\nSélecteur 3 positions\r\nVibrato Floyd Rose 1000 SE\r\nMécaniques Grover\r\nAccastillage noir\r\nCordes D'Addario XL120 (.009 - .042)\r\nCouleur: Black Satin",
//    NbrCordes = 6,
//    Prix = 1399.00M
//};

//guitar.Update(guitare, 5);
#endregion

#region GetGuitareById
//int guitareId = 5; // Remplacez par l'ID réel que vous souhaitez récupérer.
//GuitareData guitare = new GuitareData();
//guitare = guitar.Get(guitareId);

//// Afficher les données récupérées.
//if (guitare != null)
//{
//    Console.WriteLine($"Guitare trouvée - ID: {guitare.Id_Guitare}, Libelle: {guitare.Libelle}, Nombre de corde: {guitare.NbrCordes}, Description: {guitare.Description}, Annee de sortie: {guitare.AnneeDeSortie}, Prix: {guitare.Prix}");
//}
//else
//{
//    Console.WriteLine($"Aucune guitare trouvée avec l'ID {guitareId}");
//}
#endregion

#region GetAllGuitare

//IEnumerable<GuitareData> guitaredata = guitar.GetAll();

//foreach (GuitareData gu in guitaredata)
//{
//    Console.WriteLine($"Guitare trouvée - ID: {gu.Id_Guitare}, Libelle: {gu.Libelle}, Nombre de corde: {gu.NbrCordes}, Description: {gu.Description}, Annee de sortie: {gu.AnneeDeSortie}, Prix: {gu.Prix}");

//}
#endregion

#endregion

Console.WriteLine("----------------------------------------------------------------");

#region Test Guitariste

IGuitaristeRepository guitarist = new GuitaristeRepository(co);

#region InsertGuitariste

//GuitaristeData guitariste = new GuitaristeData()
//{

//    Nom = "Nicolas",
//    Prenom = "Larussa",
//    DateNaiss = new DateTime(1996, 06, 30)
//};

//guitarist.Insert(guitariste);

#endregion

#region DeleteGuitariste by Id
//guitarist.Delete(2);
#endregion

#region UpdateGuitariste
//GuitaristeData guitariste = new GuitaristeData()
//{
//    Nom = "Nicolas",
//    Prenom = "D'Addabbo",
//    DateNaiss = new DateTime(2000, 06, 10)
//};

//guitarist.Update(guitariste, 3);
#endregion

#region GetGuitaristeById
//int guitaristeId = 3; // Remplacez par l'ID réel que vous souhaitez récupérer.
//GuitaristeData guitariste = new GuitaristeData();
//guitariste = guitarist.Get(guitaristeId);

//// Afficher les données récupérées.
//if (guitariste != null)
//{
//    Console.WriteLine($"Guitaristes trouvés - ID: {guitariste.Id_Guitariste}, Nom: {guitariste.Nom}, Prénom: {guitariste.Prenom}, Date de naisssance: {guitariste.DateNaiss}");
//}
//else
//{
//    Console.WriteLine($"Aucun guitariste trouvé avec l'ID {guitaristeId}");
//}
#endregion

#region GetAllGuitariste

//IEnumerable<GuitaristeData> guitaristeData = guitarist.GetAll();

//foreach (GuitaristeData gst in guitaristeData)
//{
//    Console.WriteLine($"Guitaristes trouvés - ID: {gst.Id_Guitariste}, Nom: {gst.Nom}, Prénom: {gst.Prenom}, Date de naisssance: {gst.DateNaiss}");

//}
#endregion

#endregion