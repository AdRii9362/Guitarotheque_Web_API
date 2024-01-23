using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_BLL.Services;
using Guitarotheque_Web_API.Mapper;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Guitarotheque_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeController : ControllerBase
    {
        private readonly IGroupeService _groupeService;

        public GroupeController(IGroupeService groupeService)
        {
            _groupeService = groupeService;
        }


        #region GetById

        [HttpGet]
        [Route("{id_Groupe:int}")]

        public ActionResult<GroupeDTO> GetById(int id_Groupe)
        {
            GroupeModel? groupe = _groupeService.Get(id_Groupe);

            return groupe is null ? NotFound() : Ok(groupe.BllGroupeToApi());
        }

        #endregion

        #region GetAll

        [HttpGet(nameof(GetAll))]
        public ActionResult<IEnumerable<GroupeDTO>> GetAll()
        {

            return Ok(_groupeService.GetAll().Select(x => x.BllGroupeToApi()));
        }
        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id_Groupe}")]

        public ActionResult DeleteById(int id_Groupe)
        {
            GroupeModel groupe = _groupeService.Get(id_Groupe);

            if (groupe == null)
            {
                return NotFound(); // Renvoie une réponse 404 si l'accessoire n'est pas trouvé
            }

            _groupeService.Delete(id_Groupe);

            return Ok();
        }
        #endregion

        #region Insert

        [HttpPost(nameof(Insert))]
        public ActionResult Insert(GroupeForm form)
        {
            GroupeModel model = form.ApiGroupeToBll();

            if (_groupeService.GetAll().Any(g => g.Nom == model.Nom))
            {
                return BadRequest("Le groupe existe déjà.");
            }
            _groupeService.Insert(model);

            return Ok();
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("{id_Groupe}")]
        public ActionResult Update(int id_Groupe, GroupeForm form)
        {
            // Convertir le formulaire en modèle (AccessoireModel)
            GroupeModel updatedModel = form.ApiGroupeToBll();

            // Appeler la méthode de mise à jour dans le service
            bool UpdatedGroupe = _groupeService.Update(updatedModel, id_Groupe);

            if (UpdatedGroupe == true)
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
