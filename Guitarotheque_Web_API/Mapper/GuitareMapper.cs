using Guitarotheque_BLL.Models;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;

namespace Guitarotheque_Web_API.Mapper
{
    public static class GuitareMapper
    {

        internal static GuitareDTO BllGuitareToApi(this GuitareModel guitare)
        {
            return new GuitareDTO()
            {
                Id_Guitare = guitare.Id_Guitare,
                Libelle =guitare.Libelle,
                AnneeDeSortie = guitare.AnneeDeSortie,
                Description = guitare.Description,
                NbrCordes=guitare.NbrCordes,
                Prix = guitare.Prix,
                UrlImage = guitare.UrlImage
            };
        }

        internal static GuitareModel ApiGuitareToBll(this GuitareForm form)
        {
            return new GuitareModel()
            {
                Libelle = form.Libelle,
                AnneeDeSortie = form.AnneeDeSortie,
                Description = form.Description,
                NbrCordes = form.NbrCordes,
                Prix = form.Prix,
                UrlImage = form.UrlImage
            };
        }
    }
}
