using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    internal static class MM_Guitare_GuitaristeMapper
    {
        internal static MM_Guitare_GuitaristeData DbMMGuitareGuitaristeToDal(this IDataReader reader)
        {
            return new MM_Guitare_GuitaristeData()
            {
                Id_Guitare = (int)reader["Id_Guitares"],
                Id_Guitariste = (int)reader["Id_Guitaristes"]
            };
        }
    }
}
