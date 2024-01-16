using Guitarotheque_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Mapper
{
    internal static class G_Marq_Access_GuitareMapper
    {
        internal static G_Marq_Acess_GuitareData DbGMarqAcessGuitToDal(this IDataReader reader)
        {
            return new G_Marq_Acess_GuitareData()
            {
                Id_Accessoire = (int)reader["Id_Accessoires"],
                Id_Guitare = (int)reader["Id_Guitares"],
                Id_Marque = (int)reader["Id_Marques"]
            };
        }
    }
}
