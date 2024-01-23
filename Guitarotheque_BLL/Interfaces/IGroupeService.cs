using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Interfaces
{
    public interface IGroupeService
    {
        GroupeModel Get(int id_Groupe);
        IEnumerable<GroupeModel> GetAll();
        void Insert(GroupeModel groupe);
        bool Update(GroupeModel groupe, int id_Groupe);
        void Delete(int id_Groupe);
    }
}
