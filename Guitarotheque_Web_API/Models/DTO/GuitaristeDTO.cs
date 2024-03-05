namespace Guitarotheque_Web_API.Models.DTO
{
    public class GuitaristeDTO
    {
        public int Id_Guitariste { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaiss { get; set; }

        public List<int> Id_Guitare { get; set; }
        public List <string>Libelle_Guitare { get; set; }


    }
}
