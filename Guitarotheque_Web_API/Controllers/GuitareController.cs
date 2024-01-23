using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_Web_API.Mapper;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guitarotheque_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitareController : ControllerBase
    {
        private readonly IGuitareService _guitareService;

        public GuitareController(IGuitareService guitareService)
        {
            _guitareService = guitareService;
        }


        #region GetById

        [HttpGet]
        [Route("{id_Guitare:int}")]

        public ActionResult<GuitareDTO> GetById(int id_Guitare)
        {
            GuitareModel? guitare = _guitareService.Get(id_Guitare);

            return guitare is null ? NotFound() : Ok(guitare.BllGuitareToApi());
        }

        #endregion

        #region GetAll

        [HttpGet(nameof(GetAll))]
        public ActionResult<IEnumerable<GuitareDTO>> GetAll()
        {

            return Ok(_guitareService.GetAll().Select(x => x.BllGuitareToApi()));
        }
        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id_Guitare}")]

        public ActionResult DeleteById(int id_Guitare)
        {
            GuitareModel guitare = _guitareService.Get(id_Guitare);

            if (guitare == null)
            {
                return NotFound(); // Renvoie une réponse 404 si l'accessoire n'est pas trouvé
            }

            _guitareService.Delete(id_Guitare);

            return Ok();
        }
        #endregion

        #region Insert

        [HttpPost(nameof(Insert))]
        public ActionResult Insert(GuitareForm form)
        {
            GuitareModel model = form.ApiGuitareToBll();

            if (_guitareService.GetAll().Any(g => g.Libelle == model.Libelle))
            {
                return BadRequest("La guitare existe déjà.");
            }
            _guitareService.Insert(model);

            return Ok();
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("{id_Guitare}")]
        public ActionResult Update(int id_Guitare, GuitareForm form)
        {
            // Convertir le formulaire en modèle (AccessoireModel)
            GuitareModel updatedModel = form.ApiGuitareToBll();

            // Appeler la méthode de mise à jour dans le service
            bool UpdatedGuitare = _guitareService.Update(updatedModel, id_Guitare);

            if (UpdatedGuitare == true)
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
