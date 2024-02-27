using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Interfaces
{
    public interface IGuitareService
    {
        GuitareModel Get(int id_Guitare);
        IEnumerable <GuitareModel> GetByGuitariste(int id_Guitariste);
        IEnumerable<GuitareModel> GetAll();
        void Insert(GuitareModel guitare);
        bool Update(GuitareModel guitare, int id_Guitare);
        void Delete(int id_Guitare);
        bool GuitareExists(int id_Guitare);
    }
}
