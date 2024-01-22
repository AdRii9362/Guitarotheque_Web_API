using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Interfaces
{
    public interface IAccessoireRepository
    {
        AccessoireData Get(int id_Accessoire);
        IEnumerable<AccessoireData> GetAll();
        void Insert (AccessoireData accessoire);
        bool Update (AccessoireData accessoire, int id_Accessoire);
        void Delete(int id_Accessoire);
    }
}
