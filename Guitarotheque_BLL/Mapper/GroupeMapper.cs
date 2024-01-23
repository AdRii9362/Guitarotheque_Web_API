using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Mapper
{
    public static class GroupeMapper
    {
        internal static GroupeData BllGroupeToDal(this GroupeModel model)
        {
            return new GroupeData()
            {
                Id_Groupe = model.Id_Groupe,
                Nom = model.Nom,
                Genre = model.Genre,
                AnneeCreation = model.AnneeCreation
            };
        }

        internal static GroupeModel DalGroupeToBll(this GroupeData data)
        {
            if (data is null)
            {
                return null;
            }
            return new GroupeModel()
            {
                Id_Groupe = data.Id_Groupe,
                Nom = data.Nom,
                Genre = data.Genre,
                AnneeCreation = data.AnneeCreation
            };
        }
    }
}
