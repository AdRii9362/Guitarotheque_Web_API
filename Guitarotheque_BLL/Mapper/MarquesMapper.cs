using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Mapper
{
    internal static class MarquesMapper
    {
        internal static MarquesData BllMarquesToDal(this MarquesModel model)
        {
            return new MarquesData()
            {
                Id_Marques = model.Id_Marques,
                Nom = model.Nom,
                SiegeSocial = model.SiegeSocial,
                Description = model.Description
            };
        }

        internal static MarquesModel DalMarquesToBll(this MarquesData data)
        {
            if (data is null)
            {
                return null;
            }
            return new MarquesModel()
            {
                Id_Marques = data.Id_Marques,
                Nom = data.Nom,
                SiegeSocial = data.SiegeSocial,
                Description = data.Description

            };
        }

    }
}
