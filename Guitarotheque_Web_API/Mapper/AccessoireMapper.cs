using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;

namespace Guitarotheque_Web_API.Mapper
{
    public static class AccessoireMapper
    {
        internal static AccessoireDTO BllAccessToApi(this AccessoireModel accessoire)
        {
            return new AccessoireDTO()
            {
                Description = accessoire.Description,
                Libelle = accessoire.Libelle,
                Prix = accessoire.Prix

            };
        }
    }
}
