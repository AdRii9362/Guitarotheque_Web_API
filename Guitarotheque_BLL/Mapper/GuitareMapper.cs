using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Mapper
{
    internal static class GuitareMapper
    {
        internal static GuitareData BllGuitareToDal(this GuitareModel model)
        {
            return new GuitareData()
            {
                Id_Guitare = model.Id_Guitare,
                Libelle = model.Libelle,
                AnneeDeSortie = model.AnneeDeSortie,
                Description = model.Description,
                NbrCordes = model.NbrCordes,
                Prix = model.Prix
            };
        }

        internal static GuitareModel DalGuitareToBll(this GuitareData data)
        {
            if (data is null)
            {
                return null;
            }
            return new GuitareModel()
            {
                Id_Guitare = data.Id_Guitare,
                Libelle = data.Libelle,
                AnneeDeSortie = data.AnneeDeSortie,
                Description = data.Description,
                NbrCordes = data.NbrCordes,
                Prix = data.Prix
            };
        }
    }
}
