using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Interfaces
{
    public interface IGuitaristeService
    {
        GuitaristeModel Get(int Id_Guitariste);
        IEnumerable<GuitaristeModel> GetAll();
        void Insert(GuitaristeModel guitariste, List<int> Id_Guitare);
        bool Update(GuitaristeModel guitariste, int id_Guitariste);
        void Delete(int Id_Guitariste);

        
    }
}
