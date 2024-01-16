
//test insert accessoire

using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using System.Data.SqlClient;
using Tools;

string CS = @"Data Source=GOS-VDI206\TFTIC;Initial Catalog=DB_Guitarotheque;Integrated Security=True;";

SqlConnection sqlConnection = new SqlConnection(CS);
Connection co = new Connection(CS);

IAccessoireRepository access = new AccessoireRepository(co);


#region InsertAccessoire
//AccessoireData accessoire = new AccessoireData()
//{
//    Libelle = "Accordeur",
//    Description = "Sert à accorder",
//    Prix = 50.50M
//};

//access.Insert(accessoire);
#endregion

#region DeleteAccesoire by Id
//access.Delete(1);
#endregion

#region UpdateAccessoire
//AccessoireData accessoire = new AccessoireData()
//{
//    Libelle = "Mediator",
//    Description = "C est vraiment un mediator",
//    Prix = 120.50M
//};

//access.Update(accessoire,2);
#endregion

#region GetAcessoireById
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
IEnumerable<AccessoireData> accessoire = access.GetAll();

foreach(AccessoireData a in accessoire)
{
    Console.WriteLine($"Accessoire trouvé - ID: {a.Id_Accessoire}, Libelle: {a.Libelle}, Description: {a.Description}, Prix: {a.Prix}");

}
#endregion


