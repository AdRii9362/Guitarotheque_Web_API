namespace Guitarotheque_Web_API.Models.Forms
{
    //Form va nous permettre de specifier ce que l utilsiateur à le droit de rentrer comme informations ainsi que les regles impliquées
    public class AccessoireForm
    {
        public string Description { get; set; }
        public string Libelle { get; set; }
        public decimal Prix { get; set; }
    }
}
