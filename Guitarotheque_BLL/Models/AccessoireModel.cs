using Guitarotheque_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Models
{
    public class AccessoireModel 
    {
        public int Id_Accessoire { get; set; }
        public string? Description { get; set; }
        public string? Libelle { get; set; }
        public decimal Prix { get; set; }
    }
}
