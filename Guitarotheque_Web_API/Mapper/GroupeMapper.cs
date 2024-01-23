using Guitarotheque_BLL.Models;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;

namespace Guitarotheque_Web_API.Mapper
{
    public static class GroupeMapper
    {
        internal static GroupeDTO BllGroupeToApi(this GroupeModel groupe)
        {
            return new GroupeDTO()
            {
                Nom = groupe.Nom,
                Genre = groupe.Genre,
                AnneeCreation = groupe.AnneeCreation
            };
        }

        internal static GroupeModel ApiGroupeToBll(this GroupeForm form)
        {
            return new GroupeModel()
            {
                Nom = form.Nom,
                Genre = form.Genre,
                AnneeCreation = form.AnneeCreation
            };
        }
    }
}
