using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    internal static class GroupeMapper
    {
        internal static GroupeData DbGroupeToDal(this IDataRecord record)
        {
            return new GroupeData()
            {
                Id_Groupe = (int)record["Id_Groupes"],
                Nom = (string)record["Nom"],
                AnneeCreation = (int)record["AnneeCreation"],
                Genre = (string)record["Genre"]
            };
        }
    }
}
