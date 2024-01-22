namespace Guitarotheque_Web_API.Models.DTO
{
    public class AccessoireDTO
    {
        //DTO : on sort des informations de l'api vers la visu
        //DTO permet de déclarer uniquement les elements de ta table avec lequel il peut avoir connaissance,
        //l utilisateur peut lire toutes les donnees faisant partie de la DTO
        public string Description { get; set; }
        public string Libelle { get; set; }
        public decimal Prix { get; set; }
    }
}
