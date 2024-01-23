namespace Guitarotheque_Web_API.Models.DTO
{
    public class GroupeDTO
    {
        //DTO : on sort des informations de l'api vers la visu
        //DTO permet de déclarer uniquement les elements de ta table avec lequel il peut avoir connaissance,
        //l utilisateur peut lire toutes les donnees faisant partie de la DTO
        public string Nom { get; set; }
        public int AnneeCreation { get; set; }
        public string Genre { get; set; }
    }
}
