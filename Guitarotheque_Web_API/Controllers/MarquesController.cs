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
    public class MarquesController : ControllerBase
    {
        private readonly IMarquesService _marquesService;

        public MarquesController(IMarquesService marquesService)
        {
            _marquesService = marquesService;
        }

        #region GetById

        [HttpGet]
        [Route("{id_Marques:int}")]

        public ActionResult<MarquesDTO> GetById(int id_Marques)
        {
            MarquesModel? marques = _marquesService.Get(id_Marques);

            return marques is null ? NotFound() : Ok(marques.BllMarquesToApi());
        }

        #endregion

        #region GetAll

        [HttpGet(nameof(GetAll))]
        public ActionResult<IEnumerable<MarquesDTO>> GetAll()
        {

            return Ok(_marquesService.GetAll().Select(x => x.BllMarquesToApi()));
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id_Marques}")]

        public ActionResult DeleteById(int id_Marques)
        {
            MarquesModel marques = _marquesService.Get(id_Marques);

            if (marques == null)
            {
                return NotFound(); // Renvoie une réponse 404 si l'accessoire n'est pas trouvé
            }

            _marquesService.Delete(id_Marques);

            return Ok();
        }
        #endregion

        #region Insert

        [HttpPost(nameof(Insert))]
        public ActionResult Insert(MarquesForm form)
        {
            MarquesModel model = form.ApiMarquesToBll();

            _marquesService.Insert(model);

            return Ok();
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("{id_Marques}")]
        public ActionResult Update(int id_Marques, MarquesForm form)
        {
            // Convertir le formulaire en modèle (AccessoireModel)
            MarquesModel updatedModel = form.ApiMarquesToBll();

            // Appeler la méthode de mise à jour dans le service
            bool UpdatedMarques = _marquesService.Update(updatedModel, id_Marques);

            if (UpdatedMarques == true)
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
