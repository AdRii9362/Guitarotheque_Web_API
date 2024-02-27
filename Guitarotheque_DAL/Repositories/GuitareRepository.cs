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
    public class GuitareRepository : IGuitareRepository
    {
        private readonly Connection _connection;

        public GuitareRepository(Connection connection)
        {
            _connection = connection;
        }
        public void Delete(int id_Guitare)
        {
            Command c = new Command("DELETE FROM Guitares WHERE Id_Guitares = @id");
            c.AddParameter("id", id_Guitare);

            _connection.ExecuteNonQuery(c);
        }

        public GuitareData Get(int id_Guitare)
        {
            Command c = new Command("SELECT * FROM Guitares WHERE Id_Guitares = @id");
            c.AddParameter("id", id_Guitare);

            return _connection.ExecuteReader(c, ER => ER.DbGuitareToDal()).SingleOrDefault();
        }

        public IEnumerable<GuitareData> GetAll()
        {
            Command c = new Command("SELECT * FROM Guitares");
            return _connection.ExecuteReader(c, ER => ER.DbGuitareToDal());
        }

        public IEnumerable<GuitareData> GetByGuitariste(int id_Guitariste)
        {
            // Créez une commande SQL avec un paramètre pour l'identifiant du guitariste
            Command c = new Command(@"SELECT G.*
                                FROM Guitares G
                                INNER JOIN MM_Guitariste_Guitare MM ON G.Id_Guitares = MM.Id_Guitares
                                WHERE MM.Id_Guitaristes = @id");

            c.AddParameter("id", id_Guitariste); // Ajoutez le paramètre pour l'identifiant du guitariste

            // Exécutez la commande SQL et convertissez les résultats en objets GuitareData
            return _connection.ExecuteReader(c, ER => ER.DbGuitareToDal());
        }


        public void Insert(GuitareData guitare)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("InsertGuitare", true);

            c.AddParameter("NbrCordes", guitare.NbrCordes);
            c.AddParameter("AnneeDeSortie", guitare.AnneeDeSortie);
            c.AddParameter("Libelle", guitare.Libelle);
            c.AddParameter("Description", guitare.Description);
            c.AddParameter("Prix", guitare.Prix);

            _connection.ExecuteNonQuery(c);
        }

        public bool Update(GuitareData guitare, int id_Guitare)
        {
            //voir procedure stockee dans SQL => DB_Guitarotheque -> Programmability -> Stocked Procedure
            Command c = new Command("UpdateGuitare", true);

            c.AddParameter("Id_Guitare", id_Guitare);
            c.AddParameter("NbrCordes", guitare.NbrCordes);
            c.AddParameter("AnneeDeSortie", guitare.AnneeDeSortie);
            c.AddParameter("Libelle", guitare.Libelle);
            c.AddParameter("Description", guitare.Description);
            c.AddParameter("Prix", guitare.Prix);

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

        
    }
}
