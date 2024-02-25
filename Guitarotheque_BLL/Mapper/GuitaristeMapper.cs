using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Mapper
{
    internal static class GuitaristeMapper
    {
        internal static GuitaristeData BllGuitaristeToDal(this GuitaristeModel model)
        {
            return new GuitaristeData()
            {
                Id_Guitariste = model.Id_Guitariste,
                Nom = model.Nom,
                Prenom = model.Prenom,
                DateNaiss = model.DateNaiss
            };
        }

        internal static GuitaristeModel DalGuitaristeToBll(this GuitaristeData data)
        {
            if (data is null)
            {
                return null;
            }
            return new GuitaristeModel()
            {
                Id_Guitariste = data.Id_Guitariste,
                Nom = data.Nom,
                Prenom= data.Prenom,
                DateNaiss = data.DateNaiss

            };
        }
    }
}
