using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_BLL.Services;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Tools;

string CS = @"Data Source=GOS-VDI206\TFTIC;Initial Catalog=DB_Guitarotheque;Integrated Security=True;";

SqlConnection sqlConnection = new SqlConnection(CS);
Connection co = new Connection(CS);

#region Test Accessoire

IAccessoireRepository accessoireRepository = new AccessoireRepository(co);
IAccessoireService accessoireService = new AccessoireService(accessoireRepository);

#region Insert Accessoire

//AccessoireModel accessoireModel = new AccessoireModel
//{
//    Libelle = "Accessoire de ma BLL",
//    Description = "J ai modifié",
//    Prix = 99.99M
//};


//accessoireService.Insert(accessoireModel);

#endregion

#region UpdateAccessoire

//AccessoireModel accessoireModel = new AccessoireModel
//{
//    Libelle = "Accessoire de ma BLL",
//    Description = "J ai modifié",
//    Prix = 99.99M
//};
//accessoireService.Update(accessoireModel,5);

#endregion

#region Delete Accessoire

//accessoireService.Delete(5);

#endregion

#region GetAccessoireByID

//int accessoireId = 4; // Remplacez par l'ID réel que vous souhaitez récupérer.
//AccessoireModel accessoire = new AccessoireModel();
//accessoire = accessoireService.Get(accessoireId);

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

//IEnumerable<AccessoireModel> accessoire = accessoireService.GetAll();

//foreach (AccessoireModel a in accessoire)
//{
//    Console.WriteLine($"Accessoire trouvé - ID: {a.Id_Accessoire}, Libelle: {a.Libelle}, Description: {a.Description}, Prix: {a.Prix}");

//}
#endregion

#endregion

Console.WriteLine("--------------------------------------------------");

#region Test Groupe

IGroupeRepository groupeRepository = new GroupeRepository(co);
IGroupeService groupeService = new GroupeService(groupeRepository);

#region Insert Groupe

//GroupeModel groupeModel = new GroupeModel
//{
//    Nom = "test",
//    Genre = "Rock",
//    AnneeCreation = 1985
//};


//groupeService.Insert(groupeModel);

#endregion

#region UpdateGroupe

//GroupeModel groupeModel = new GroupeModel
//{
//    Nom = "Megadeth",
//    Genre = "Rock/Metal",
//    AnneeCreation = 1985
//};
//groupeService.Update(groupeModel, 4);

#endregion

#region Delete Groupe

//groupeService.Delete(5);

#endregion

#region GetGroupeByID

//int groupeId = 4; // Remplacez par l'ID réel que vous souhaitez récupérer.
//GroupeModel groupe = new GroupeModel();
//groupe = groupeService.Get(groupeId);

//// Afficher les données récupérées.
//if (groupe != null)
//{
//    Console.WriteLine($"Groupe trouvé - ID: {groupe.Id_Groupe}, Nom: {groupe.Nom}, Genre: {groupe.Genre}, Annee de creation: {groupe.AnneeCreation}");
//}
//else
//{
//    Console.WriteLine($"Aucun Groupe trouvé avec l'ID {groupeId}");
//}

#endregion

#region GetAllGroupe

//IEnumerable<GroupeModel> groupe = groupeService.GetAll();

//foreach (GroupeModel g in groupe)
//{
//    Console.WriteLine($"Groupe trouvé - ID: {g.Id_Groupe}, Nom: {g.Nom}, Genre: {g.Genre}, Annee de creation: {g.AnneeCreation}");

//}
#endregion

#endregion

Console.WriteLine("--------------------------------------------------");

#region Test Guitare

IGuitareRepository guitareRepository = new GuitareRepository(co);
IGuitareService guitareService = new GuitareService(guitareRepository);

#region Insert Guitare

//GuitareModel guitareModel = new GuitareModel
//{
//    Libelle = "test",
//    AnneeDeSortie = 2016,
//    Description = "test",
//    NbrCordes = 6,
//    Prix = 2145.00M
//};


//guitareService.Insert(guitareModel);

#endregion

#region UpdateGuitare

//GuitareModel guitareModel = new GuitareModel
//{
//    Libelle = "Godin Radiator Faded Cream RN",
//    AnneeDeSortie = 2019,
//    Description = "Corps en érable argenté\r\nManche en érable argenté\r\nTouche en palissandre\r\n22 frettes\r\nDiapason: 628 mm (24,75\")\r\nLargeur au sillet: 43 mm (1,72\")\r\nRayon de la touche: 304,8 mm (12\")\r\nSillet Graph Tech Tusq\r\n2 micros double bobinage Godin Custom\r\n2 réglages de volume\r\n2 réglages de tonalité\r\nSélecteur 3 positions\r\nChevalet/cordier Wraparound\r\nMécaniques 18:1 cordes graves / 26:1 cordes aigues\r\nFinition: Semi-brillant\r\nCouleur: Trans Cream\r\nLivrée en housse",
//    NbrCordes = 6,
//    Prix = 1090.00M
//};
//guitareService.Update(guitareModel, 7);

#endregion

#region Delete Guitare

//guitareService.Delete(8);

#endregion

#region GetGuitareByID

//int guitareId = 7; // Remplacez par l'ID réel que vous souhaitez récupérer.
//GuitareModel guitare = new GuitareModel();
//guitare = guitareService.Get(guitareId);

//// Afficher les données récupérées.
//if (guitare != null)
//{
//    Console.WriteLine($"Guitare trouvée - ID: {guitare.Id_Guitare}, Libelle: {guitare.Libelle}, Nombre de corde: {guitare.NbrCordes}, Description: {guitare.Description}, Annee de sortie: {guitare.AnneeDeSortie}, Prix: {guitare.Prix}");
//}
//else
//{
//    Console.WriteLine($"Aucune Guitare trouvée avec l'ID {guitareId}");
//}

#endregion

#region GetAllGuitare

//IEnumerable<GuitareModel> guitare = guitareService.GetAll();

//foreach (GuitareModel gu in guitare)
//{
//    Console.WriteLine($"Guitare trouvée - ID: {gu.Id_Guitare}, Libelle: {gu.Libelle}, Nombre de corde: {gu.NbrCordes}, Description: {gu.Description}, Annee de sortie: {gu.AnneeDeSortie}, Prix: {gu.Prix}");

//}
#endregion

#endregion