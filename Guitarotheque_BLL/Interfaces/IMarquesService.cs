using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Interfaces
{
    public interface IMarquesService
    {
        MarquesModel Get(int id_Marque);
        IEnumerable<MarquesModel> GetAll();
        void Insert(MarquesModel marque);
        bool Update(MarquesModel marque, int id_Marque);
        void Delete(int id_Marque);
    }
}
