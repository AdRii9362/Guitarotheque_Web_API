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
        void Insert(GuitaristeData guitariste);
        void Update(GuitaristeData guitariste, int id_Guitariste);
        void Delete(int Id_Guitariste);
    }
}
