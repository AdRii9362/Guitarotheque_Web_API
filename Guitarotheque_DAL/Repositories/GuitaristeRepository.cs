using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Mapper;
using System;
using System.Collections.Generic;
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
            Command c = new Command("DELETE FROM Guitaristes WHERE Id_Guitaristes = @id");
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
            Command c = new Command("SELECT * FROM Guitaristes");
            return _connection.ExecuteReader(c, ER => ER.DbGuitaristeToDal());
        }

        public void Insert(GuitaristeData guitariste)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("InsertGuitariste", true);

            c.AddParameter("Nom", guitariste.Nom);
            c.AddParameter("Prenom ", guitariste.Prenom);
            c.AddParameter("DateNaiss", guitariste.DateNaiss);

            _connection.ExecuteNonQuery(c);
        }

        public void Update(GuitaristeData guitariste, int id_Guitariste)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("UpdateGuitariste", true);

            c.AddParameter("Id_Guitaristes", id_Guitariste);
            c.AddParameter("Nom", guitariste.Nom);
            c.AddParameter("Prenom ", guitariste.Prenom);
            c.AddParameter("DateNaiss", guitariste.DateNaiss);

            _connection.ExecuteNonQuery(c);

        }
    }
}
