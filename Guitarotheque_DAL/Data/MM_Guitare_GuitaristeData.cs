using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_DAL.Data
{
    public class MM_Guitare_GuitaristeData
    {
        public int Id_Guitare { get; set; }
        public int Id_Guitariste { get; set; }
        public virtual GuitareData Guitare { get; set; } = null!;
        public virtual GuitaristeData Guitariste { get; set; } = null!;
    }
}
