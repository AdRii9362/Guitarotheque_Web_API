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
    public class AccessoireRepository : IAccessoireRepository
    {
        private readonly Connection _connection;

        public AccessoireRepository(Connection connection)
        {
            _connection = connection;
        }

        public void Delete(int id_Accessoire)
        {
            Command c = new Command("DELETE FROM Accessoires WHERE Id_Accessoires = @id");
            c.AddParameter("id", id_Accessoire);

            _connection.ExecuteNonQuery(c);

        }

        public AccessoireData Get(int id_Accessoire)
        {
            Command c = new Command("SELECT * FROM Accessoires WHERE Id_Accessoires = @id");
            c.AddParameter("id", id_Accessoire);

            return _connection.ExecuteReader(c, ER => ER.DbAccessoireToDal()).SingleOrDefault();
        }

        public IEnumerable<AccessoireData> GetAll()
        {
            Command c = new Command("SELECT * FROM Accessoires");
            return _connection.ExecuteReader(c, ER => ER.DbAccessoireToDal());
        }

        public void Insert(AccessoireData accessoire)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("InsertAccessoire", true);

            c.AddParameter("Description", accessoire.Description);
            c.AddParameter("Libelle", accessoire.Libelle);
            c.AddParameter("Prix", accessoire.Prix);

            _connection.ExecuteNonQuery(c);
        }

        public void Update(AccessoireData accessoire, int id_Accessoire)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("UpdateAccessoire", true);

            c.AddParameter("Id_Accessoires", id_Accessoire);
            c.AddParameter("Description", accessoire.Description);
            c.AddParameter("Libelle", accessoire.Libelle);
            c.AddParameter("Prix", accessoire.Prix);

            _connection.ExecuteNonQuery(c);

        }
    }
}
