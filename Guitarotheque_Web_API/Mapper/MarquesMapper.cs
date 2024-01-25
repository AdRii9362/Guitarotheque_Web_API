using Guitarotheque_BLL.Models;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;

namespace Guitarotheque_Web_API.Mapper
{
    public static class MarquesMapper
    {
        internal static MarquesDTO BllMarquesToApi(this MarquesModel marques)
        {
            return new MarquesDTO()
            {
                Nom = marques.Nom,
                SiegeSocial = marques.SiegeSocial,
                Description = marques.Description
            };
        } 

        internal static MarquesModel ApiMarquesToBll(this MarquesForm form)
        {
            return new MarquesModel()
            {
                Nom = form.Nom,
                SiegeSocial = form.SiegeSocial,
                Description = form.Description
            };
        }
    }
}
