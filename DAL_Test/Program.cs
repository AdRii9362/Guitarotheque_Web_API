
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
//    Console.WriteLine($"Aucun accessoire trouvé avec l'ID {groupeId}");
//}
#endregion

#region GetAllGroupe

IEnumerable<GroupeData> groupedata = group.GetAll();

foreach (GroupeData g in groupedata)
{
    Console.WriteLine($"Groupe trouvé - ID: {g.Id_Groupe}, Nom: {g.Nom}, Genre: {g.Genre}, Annee de creation: {g.AnneeCreation}");

}
#endregion

#endregion

