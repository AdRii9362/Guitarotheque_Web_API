using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Interfaces
{
    public interface IMarqueRepository
    {
        MarquesData Get(int id_Marque);
        IEnumerable<MarquesData> GetAll();
        void Insert (MarquesData marque);
        void Update (MarquesData marque);
        void Delete (int id_Marque);
    }
}
