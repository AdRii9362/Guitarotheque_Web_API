using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_BLL.Services;
using Guitarotheque_DAL.Data;
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
        private readonly IGuitareService _guitareService;

        public GuitaristeController(IGuitaristeService guitaristeService, IGuitareService guitareService)
        {
            _guitaristeService = guitaristeService;
            _guitareService = guitareService;
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
            //{

            //    return Ok(_guitaristeService.GetAll().Select(x => x.BllGuitaristeToApi()));
            //}



            //// Récupérer tous les guitaristes
            //var allGuitaristes = _guitaristeService.GetAll().Select(x => x.BllGuitaristeToApi()).ToList();

            //// Liste pour stocker toutes les guitares de tous les guitaristes
            //List<GuitareDTO> allGuitares = new List<GuitareDTO>();

            //// Parcourir tous les guitaristes pour récupérer leurs guitares
            //foreach (var guitariste in allGuitaristes)
            //{
            //    // Vérifier si le guitariste existe par ID
            //    if (!_guitaristeService.GuitaristeExists(guitariste.Id_Guitariste))
            //    {
            //        // Retourner une réponse BadRequest si le guitariste n'existe pas
            //        return BadRequest($"Le guitariste avec l'ID {guitariste.Id_Guitariste} n'existe pas.");
            //    }

            //    // Récupérer les guitares du guitariste actuel
            //    var guitares = _guitareService.GetByGuitariste(guitariste.Id_Guitariste);

            //    // Ajouter les guitares du guitariste actuel à la liste de toutes les guitares
            //    allGuitares.AddRange(guitares.Select(g => g.BllGuitareToApi()));
            //}

            //// Créer un objet de réponse contenant tous les guitaristes et toutes les guitares
            //var response = new
            //{
            //    Guitaristes = allGuitaristes,
            //    Guitares = allGuitares
            //};

            //// Retourner la réponse
            //return Ok(response);

            // Récupérer tous les guitaristes
            var allGuitaristes = _guitaristeService.GetAll().Select(x => x.BllGuitaristeToApi()).ToList();

            // Parcourir tous les guitaristes pour récupérer leurs guitares
            foreach (var guitariste in allGuitaristes)
            {            
                // Récupérer les guitares du guitariste actuel
                var guitares = _guitareService.GetByGuitariste(guitariste.Id_Guitariste);

                // Ajouter les identifiants des guitares du guitariste actuel à la liste de guitares du guitariste
                guitariste.Id_Guitare = guitares.Select(g => g.Id_Guitare).ToList();
                guitariste.Libelle_Guitare = guitares.Select(g => g.Libelle).ToList();
            }

            // Retourner la liste des guitaristes avec les identifiants de leurs guitares associées
            return Ok(allGuitaristes);

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

            // Vérification si le guitariste existe déjà
            if (_guitaristeService.GuitaristeExists(form.Nom, form.Prenom, form.DateNaiss))
            {
                return BadRequest("Ce guitariste existe déjà.");
            }

            // Vérification si les IDs de guitare existent
            foreach (int guitare in form.Guitare)
            {
                if (!_guitareService.GuitareExists(guitare))
                {
                    return BadRequest($"Cette guitare n'existe pas");
                }
            }

                _guitaristeService.Insert(model, form.Guitare);
                return Ok();

        }

        #endregion

        #region Update

        [HttpPut]
        [Route("{id_Guitariste}")]
        public ActionResult Update(int id_Guitariste, GuitaristeForm form)
        {
            // Convertir le formulaire en modèle (GuitaristeModel)
            GuitaristeModel updatedModel = form.ApiGuitaristeToBll();

            // Vérification si les IDs de guitare existent
            foreach (int guitare in form.Guitare)
            {
                if (!_guitareService.GuitareExists(guitare))
                {
                    return BadRequest($"Cette guitare n'existe pas");
                }
              
            }

            // Appeler la méthode de mise à jour dans le service avec la liste des ID de guitare
            bool UpdatedGuitariste = _guitaristeService.Update(updatedModel, id_Guitariste, form.Guitare);

            if (!UpdatedGuitariste)
            {
                return Ok();
            }
            else
            {
                // Si la mise à jour a échoué, retourner une réponse avec le code d'état correspondant
                return NotFound("La mise à jour du guitariste a échoué.");
            }
        }

        #endregion
    }
}
