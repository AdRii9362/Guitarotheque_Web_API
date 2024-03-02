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
        IEnumerable<GuitareData> GetByGuitariste(int id_Guitariste);
        IEnumerable<GuitareData> GetAll();
        void Insert (GuitareData guitare);
        bool Update (GuitareData guitare, int id_Guitare);
        void Delete (int id_Guitare);

        bool UpdateImgGuitares(GuitareData guitare, int id_Guitare);

        IEnumerable<GuitareData> GetAllPagination(int pageNumber, int pageSize);


    }
}
