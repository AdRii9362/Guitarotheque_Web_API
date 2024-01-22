using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Interfaces
{
    public interface IAccessoireService
    {
        AccessoireModel Get(int id_Accessoire);
        IEnumerable<AccessoireModel> GetAll();
        void Insert(AccessoireModel accessoire);
        bool Update(AccessoireModel accessoire, int id_Accessoire);
        void Delete(int id_Accessoire);
    }
}
