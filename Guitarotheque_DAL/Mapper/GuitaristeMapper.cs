using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    internal static class GuitaristeMapper
    {
        internal static GuitaristeData DbGuitaristeToDal(this IDataRecord record)
        {
            return new GuitaristeData()
            {
                Id_Guitariste = (int)record["Id_Guitaristes"],
                Nom = (string)record["Nom"],
                Prenom = (string)record["Prenom"],
                DateNaiss = (DateTime)record["DateNaiss"]
            };
        }
    }
}
