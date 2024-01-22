using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Mapper
{
    public static class AccessoireMapper
    {
        internal static AccessoireData BllAccessToDal(this AccessoireModel model)
        {
            return new AccessoireData()
            {
                Id_Accessoire = model.Id_Accessoire,
                Description = model.Description,
                Libelle = model.Libelle,
                Prix = model.Prix
            };
        }

        internal static AccessoireModel DalAccessToBll(this AccessoireData data)
        {
            if (data is null)
            {
                return null;
            }
            return new AccessoireModel()
            {
                Id_Accessoire = data.Id_Accessoire,
                Description = data.Description,
                Libelle = data.Libelle,
                Prix = data.Prix
            };
        }
        
    }
}
