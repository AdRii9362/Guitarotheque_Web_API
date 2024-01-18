using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    internal static class GuitareMapper
    {
        internal static GuitareData DbGuitareToDal(this IDataRecord record)
        {
            return new GuitareData()
            {
                Id_Guitare = (int)record["Id_Guitare"],
                Libelle = (string)record["Libelle"],
                AnneeDeSortie = (int)record["AnneeSortie"],
                Description = (string)record["Description"],
                NbrCordes = (int)record["NbrCordes"],
                Prix = (decimal)record["Prix"]
            };
        }
    }
}
