using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Interfaces
{
    public interface IGuitareRepository
    {
        GuitareData Get(int id_Guitare);
        IEnumerable<GuitareData> GetAll();
        void Insert (GuitareData guitare);
        void Update (GuitareData guitare);
        void Delete (int id_Guitare);

    }
}
