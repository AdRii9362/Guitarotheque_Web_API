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
                Id_Guitare = (int)record["Id_Guitares"],
                Libelle = (string)record["Libelle"],
                AnneeDeSortie = (int)record["AnneeDeSortie"],
                Description = (string)record["Description"],
                NbrCordes = (int)record["NbrCordes"],
                Prix = (decimal)record["Prix"],
                UrlImage = (string)record["UrlImage"]
            };
        }
    }
}
