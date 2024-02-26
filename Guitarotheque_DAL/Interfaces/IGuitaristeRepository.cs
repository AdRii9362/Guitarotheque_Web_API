using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Interfaces
{
    public interface IGuitaristeRepository
    {
        GuitaristeData Get(int Id_Guitariste);
        IEnumerable<GuitaristeData> GetAll();
        void Insert(GuitaristeData guitariste, List<int>Id_Guitare);
        bool Update(GuitaristeData guitariste, int id_Guitariste, List<int> Id_Guitares);
        void Delete(int Id_Guitariste);

        public bool GuitaristeExists(string nom, string prenom, DateTime dateNaiss);
    }
}
