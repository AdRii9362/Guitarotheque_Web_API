using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Interfaces
{
    public interface IGroupeRepository
    {
        GroupeData Get(int id_Groupe);
        IEnumerable<GroupeData> GetAll();
        void Insert(GroupeData groupe);
        void Update(GroupeData groupe, int id_Groupe);
        void Delete(int id_Groupe);
    }
}
