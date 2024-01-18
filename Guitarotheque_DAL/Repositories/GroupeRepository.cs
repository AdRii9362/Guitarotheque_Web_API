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
    public class GroupeRepository : IGroupeRepository
    {
        private readonly Connection _connection;

        public GroupeRepository(Connection connection)
        {
            _connection = connection;
        }
        public void Delete(int id_Groupe)
        {
            Command c = new Command("DELETE FROM Groupes WHERE Id_Groupes = @id");
            c.AddParameter("id", id_Groupe);

            _connection.ExecuteNonQuery(c);
        }

        public GroupeData Get(int id_Groupe)
        {
            Command c = new Command("SELECT * FROM Groupes WHERE Id_Groupes = @id");
            c.AddParameter("id", id_Groupe);

            return _connection.ExecuteReader(c, ER => ER.DbGroupeToDal()).SingleOrDefault();
        }

        public IEnumerable<GroupeData> GetAll()
        {
            Command c = new Command("SELECT * FROM Groupes");
            return _connection.ExecuteReader(c, ER => ER.DbGroupeToDal());
        }

        public void Insert(GroupeData groupe)
        {
            //creer la procedure stockee dans sql
            Command c = new Command("InsertGroupe", true);

            c.AddParameter("Nom", groupe.Nom);
            c.AddParameter("Genre", groupe.Genre);
            c.AddParameter("AnneeCreation", groupe.AnneeCreation);

            _connection.ExecuteNonQuery(c);
        }

        public void Update(GroupeData groupe, int id_Groupe)
        {
            Command c = new Command("UpdateGroupe", true);

            c.AddParameter("Id_Groupes", id_Groupe);
            c.AddParameter("Nom",groupe.Nom);
            c.AddParameter("Genre", groupe.Genre);
            c.AddParameter("AnneeCreation", groupe.AnneeCreation);

            _connection.ExecuteNonQuery(c);
        }
    }
}
