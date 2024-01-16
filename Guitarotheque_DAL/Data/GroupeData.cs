using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Data
{
    public class GroupeData
    {
        public int Id_Groupe { get; set; }
        public string Nom { get; set; }
        public int AnneeCreation { get; set; }
        public string Genre { get; set; }
    }
}
