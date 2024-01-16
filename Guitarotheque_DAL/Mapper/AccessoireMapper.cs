using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    public static class AccessoireMapper
    {
        internal static AccessoireData DbAcessoireToDal(this IDataRecord record)
        {
            return new AccessoireData()
            {
                Id_Accessoire = (int)record["Id_Accessoires"],
                Libelle = (string)record["Libelle"],
                Description = (string)record["Description"],
                Prix = (decimal)record["Prix"]
            };
        }
    }
}
