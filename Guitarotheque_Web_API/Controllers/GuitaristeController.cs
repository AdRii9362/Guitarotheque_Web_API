using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_BLL.Services;
using Guitarotheque_Web_API.Mapper;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guitarotheque_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitaristeController : ControllerBase
    {
        private readonly IGuitaristeService _guitaristeService;

        public GuitaristeController(IGuitaristeService guitaristeService)
        {
            _guitaristeService = guitaristeService;
        }

        #region GetById

        [HttpGet]
        [Route("{id_Guitariste:int}")]

        public ActionResult<GuitaristeDTO> GetById(int id_Guitariste)
        {
            GuitaristeModel? guitariste = _guitaristeService.Get(id_Guitariste);

            return guitariste is null ? NotFound() : Ok(guitariste.BllGuitaristeToApi());
        }

        #endregion

        #region GetAll

        [HttpGet(nameof(GetAll))]
        public ActionResult<IEnumerable<GuitaristeDTO>> GetAll()
        {

            return Ok(_guitaristeService.GetAll().Select(x => x.BllGuitaristeToApi()));
        }
        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id_Guitariste}")]

        public ActionResult DeleteById(int id_Guitariste)
        {
            GuitaristeModel guitariste = _guitaristeService.Get(id_Guitariste);

            if (guitariste == null)
            {
                return NotFound(); // Renvoie une réponse 404 si l'accessoire n'est pas trouvé
            }

            _guitaristeService.Delete(id_Guitariste);

            return Ok();
        }
        #endregion

        #region Insert

        [HttpPost(nameof(Insert))]
        public ActionResult Insert(GuitaristeForm form)
        {
            GuitaristeModel model = form.ApiGuitaristeToBll();
           
            _guitaristeService.Insert(model);

            return Ok();
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("{id_Guitariste}")]
        public ActionResult Update(int id_Guitariste, GuitaristeForm form)
        {
            // Convertir le formulaire en modèle (AccessoireModel)
            GuitaristeModel updatedModel = form.ApiGuitaristeToBll();

            // Appeler la méthode de mise à jour dans le service
            bool UpdatedGuitariste = _guitaristeService.Update(updatedModel, id_Guitariste);

            if (UpdatedGuitariste == true)
            {
                return Ok();
            }
            else
            {
                return NotFound("Id Not Found");
            }

        }


        #endregion
    }
}
