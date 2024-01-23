namespace Guitarotheque_Web_API.Models.Forms
{
    public class GuitareForm
    {
        public int NbrCordes { get; set; }
        public int AnneeDeSortie { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
    }
}
