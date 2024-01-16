using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Data
{
    public class GuitareData 
    {
        public int Id_Guitare { get; set; }
        public int NbreCordes { get; set; }
        public int AnneeSortie { get; set; }

        public string Libelle { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
    }
}
