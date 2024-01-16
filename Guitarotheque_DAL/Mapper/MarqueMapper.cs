using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    internal static class MarqueMapper
    {
        internal static MarquesData DbMarqueToDal(this IDataRecord record)
        {
            return new MarquesData()
            {
                Id_Marques = (int)record["Id_Marques"],
                Description = (string)record["Description"],
                Nom = (string)record["Nom"],
                SiegeSocial = (string)record["SiegeSocial"]
            };
        }
    }
}
