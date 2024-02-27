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
    public class GuitareController : ControllerBase
    {
        private readonly IGuitareService _guitareService;
        private readonly IGuitaristeService _guitaristeService;

        public GuitareController(IGuitareService guitareService, IGuitaristeService guitaristeService)
        {
            _guitareService = guitareService;
            _guitaristeService = guitaristeService;
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

        #region GetAll

        [HttpGet(nameof(GetByGuitariste))]

        public ActionResult<IEnumerable<GuitareDTO>> GetByGuitariste(int id_Guitariste)
        {

            //Verification guitariste existe by ID
            if (!_guitaristeService.GuitaristeExists(id_Guitariste))
            {
                return BadRequest("Ce guitariste n'existe pas.");
            }
            // Appelez la méthode GetByGuitariste de votre service de guitare
            var guitares = _guitareService.GetByGuitariste(id_Guitariste);

            // Vérifiez si la guitare retournée est nulle
            if (guitares == null)
            {
                // Si elle est nulle, retournez une réponse NotFound
                return NotFound();
            }

            // Convertissez la guitare en un objet DTO approprié
            var guitaresDTO = guitares.Select(g => g.BllGuitareToApi());

            // Retournez la liste des guitares DTO dans une réponse Ok
            return Ok(guitaresDTO);
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
