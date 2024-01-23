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
    public class MarqueRepository : IMarqueRepository
    {
        private readonly Connection _connection;

        public MarqueRepository(Connection connection)
        {
            _connection = connection;
        }
        public void Delete(int id_Marque)
        {
            Command c = new Command("DELETE FROM Marques WHERE Id_Marques = @id");
            c.AddParameter("id", id_Marque);

            _connection.ExecuteNonQuery(c);
        }

        public MarquesData Get(int id_Marque)
        {
            Command c = new Command("SELECT * FROM Marques WHERE Id_Marques = @id");
            c.AddParameter("id", id_Marque);

            return _connection.ExecuteReader(c, ER => ER.DbMarqueToDal()).SingleOrDefault();
        }

        public IEnumerable<MarquesData> GetAll()
        {
            Command c = new Command("SELECT * FROM Marques");
            return _connection.ExecuteReader(c, ER => ER.DbMarqueToDal());
        }

        public void Insert(MarquesData marque)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("InsertMarque", true);

            c.AddParameter("Nom", marque.Nom);
            c.AddParameter("SiegeSocial", marque.SiegeSocial);
            c.AddParameter("Description", marque.Description);

            _connection.ExecuteNonQuery(c);
        }

        public void Update(MarquesData marque, int id_Marque)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("UpdateMarque", true);

            c.AddParameter("Id_Marque", id_Marque);
            c.AddParameter("Nom", marque.Nom);
            c.AddParameter("SiegeSocial", marque.SiegeSocial);
            c.AddParameter("Description", marque.Description);

            _connection.ExecuteNonQuery(c);
        }
    }
}
