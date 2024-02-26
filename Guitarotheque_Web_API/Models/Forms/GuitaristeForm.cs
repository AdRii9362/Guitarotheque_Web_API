namespace Guitarotheque_Web_API.Models.Forms
{
    public class GuitaristeForm
    {
        //public int Id_Guitariste { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaiss { get; set; }

        public List<int> Guitare { get; set; }
    }
}
