using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    internal static class MM_Guitariste_GroupeMapper
    {
        internal static MM_Guitariste_GroupeData DbGuitaristeGroupeToDal(this IDataReader reader)
        {
            return new MM_Guitariste_GroupeData()
            {
                Id_Groupe = (int)reader["Id_Groupes"],
                Id_Guitariste = (int)reader["Id_Guitaristes"]

            };
        }
    }
}
