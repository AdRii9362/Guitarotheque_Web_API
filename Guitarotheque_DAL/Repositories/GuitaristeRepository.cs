using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Guitarotheque_DAL.Repositories
{
    public class GuitaristeRepository : IGuitaristeRepository
    {
        private readonly Connection _connection;

        public GuitaristeRepository(Connection connection)
        {
            _connection = connection;
        }
        public void Delete(int Id_Guitariste)
        {
            Command c = new Command("DeleteGuitariste",true);
            c.AddParameter("id", Id_Guitariste);

            _connection.ExecuteNonQuery(c);
        }

        public GuitaristeData Get(int Id_Guitariste)
        {
            Command c = new Command("SELECT * FROM Guitaristes WHERE Id_Guitaristes = @id");
            c.AddParameter("id", Id_Guitariste);

            return _connection.ExecuteReader(c, ER => ER.DbGuitaristeToDal()).SingleOrDefault();
        }

        public IEnumerable<GuitaristeData> GetAll()
        {
            Command c = new Command("GetAllGuitaristes", true);



            return _connection.ExecuteReader(c, ER => ER.DbGuitaristeToDal());
        }

        public void Insert(GuitaristeData guitariste, List<int> Id_Guitares)
        {
            // Créer un DataTable pour représenter le type de table TGuitareId
            DataTable table = new DataTable();
            table.Columns.Add("GuitareId", typeof(int));

            // Remplir le DataTable avec les ID de guitares
            foreach (int guitareId in Id_Guitares)
            {
                table.Rows.Add(guitareId);
            }

            // Voir la procédure stockée dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("InsertGuitariste", true);

            c.AddParameter("Nom", guitariste.Nom);
            c.AddParameter("Prenom", guitariste.Prenom);
            c.AddParameter("DateNaiss", guitariste.DateNaiss);

            // Utiliser le DataTable comme paramètre
            c.AddParameter("Guitares", table);

            _connection.ExecuteNonQuery(c);
        }




        public bool Update(GuitaristeData guitariste, int id_Guitariste)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("UpdateGuitariste", true);

            c.AddParameter("Id_Guitariste", id_Guitariste);
            c.AddParameter("Nom", guitariste.Nom);
            c.AddParameter("Prenom ", guitariste.Prenom);
            c.AddParameter("DateNaiss", guitariste.DateNaiss);

            int NbRow = _connection.ExecuteNonQuery(c);

            if (NbRow == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Permet de verifier si un guitariste existe deja en verifiant nom prenom datenaiss
        public bool GuitaristeExists(string nom, string prenom, DateTime dateNaiss)
        {
            Command c = new Command("SELECT COUNT(*) FROM Guitaristes WHERE Nom = @Nom AND Prenom = @Prenom AND DateNaiss = @DateNaiss");
            c.AddParameter("Nom", nom);
            c.AddParameter("Prenom", prenom);
            c.AddParameter("DateNaiss", dateNaiss);

            int count = (int)_connection.ExecuteScalar(c);

            return count > 0;
        }
    }
}
