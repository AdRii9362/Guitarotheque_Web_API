using Guitarotheque_BLL.Models;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;

namespace Guitarotheque_Web_API.Mapper
{
    public static class GuitaristeMapper
    {
        internal static GuitaristeDTO BllGuitaristeToApi(this GuitaristeModel guitariste)
        {
            return new GuitaristeDTO()
            {
                Id_Guitariste = guitariste.Id_Guitariste,
                Nom = guitariste.Nom,
                Prenom = guitariste.Prenom,
                DateNaiss = guitariste.DateNaiss
            };
        }

        internal static GuitaristeModel ApiGuitaristeToBll(this GuitaristeForm form)
        {
            return new GuitaristeModel()
            {
                Id_Guitariste = form.Id_Guitariste,
                Nom = form.Nom,
                Prenom = form.Prenom,
                DateNaiss = form.DateNaiss
                
            };
        }
    }
}
