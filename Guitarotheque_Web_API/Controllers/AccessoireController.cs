using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_Web_API.Mapper;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Drawing;

namespace Guitarotheque_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoireController : ControllerBase
    {
        private readonly IAccessoireService _accessoireService;

        public AccessoireController(IAccessoireService accessoireService)
        {
            _accessoireService = accessoireService;
        }

        #region GetById

        [HttpGet]
        [Route("{id_Accessoire:int}")]

        public ActionResult<AccessoireDTO> GetById(int id_Accessoire)
        {
            AccessoireModel? accessoire = _accessoireService.Get(id_Accessoire);

            return accessoire is null ? NotFound() : Ok(accessoire.BllAccessToApi());
        }

        //[HttpGet(nameof(Get))]

        //public IActionResult Get(int id_Accessoire)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    _accessoireService.Get(id_Accessoire);

        //    return Ok();
        //}
        #endregion

        #region GetAll

        [HttpGet(nameof(GetAll))]
        public ActionResult<IEnumerable<AccessoireDTO>> GetAll()
        {

            return Ok(_accessoireService.GetAll().Select(x => x.BllAccessToApi()));
        }
        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id_Accessoire}")]

        public ActionResult DeleteById(int id_Accessoire)
        {
            AccessoireModel accessoire = _accessoireService.Get(id_Accessoire);

            if (accessoire == null)
            {
                return NotFound(); // Renvoie une réponse 404 si l'accessoire n'est pas trouvé
            }

            _accessoireService.Delete(id_Accessoire);

            return Ok();
        }
        #endregion

        #region Insert

        [HttpPost(nameof(Insert))]
        public ActionResult Insert(AccessoireForm form)
        {
            AccessoireModel model = form.ApiAccessToBll();

            if (_accessoireService.GetAll().Any(a => a.Libelle == model.Libelle))
            {
                return BadRequest("L'accessoire existe déjà.");
            }
            _accessoireService.Insert(model);

            return Ok();
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("{id_Accessoire}")]
        public ActionResult Update(int id_Accessoire, AccessoireForm form)
        {
            // Convertir le formulaire en modèle (AccessoireModel)
            AccessoireModel updatedModel = form.ApiAccessToBll();          

            // Appeler la méthode de mise à jour dans le service
            bool UpdatedAccessoire = _accessoireService.Update(updatedModel, id_Accessoire);

            if(UpdatedAccessoire == true)
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
