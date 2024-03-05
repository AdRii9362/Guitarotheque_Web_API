using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_BLL.Services;
using Guitarotheque_Web_API.Mapper;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        #region GetByGuitariste

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

        #region Update Image
        [HttpPut("{id_Guitare}/UpdateImgGuitares")]
        [Consumes("multipart/form-data")]
        public ActionResult UpdateImgGuitares(int id_Guitare, [FromForm] GuitareImageDTO form )
        {
            if (!_guitareService.GuitareExists(id_Guitare))
            {
                return NotFound();
            }

            // Définition du répertoire pour sauvegarder les images
            string directory = Path.Combine(Environment.CurrentDirectory, "Images");

            // Définition du nom de fichier unique
            string now = DateTime.UtcNow.ToString("yyyyMMdd");
            string rng = Guid.NewGuid().ToString();
            string ext = Path.GetExtension(form.GuitareImage.FileName);
            string filename = now + "-" + rng + ext;

            // Création du chemin d'accès au fichier
            string filePath = Path.Combine(directory, filename);

            // Création du chemin d'accès au fichier source
            //string sourceFilePath = Path.Combine(directory, form.UrlImage);

            // Vérifie si le fichier source existe
            //if (!System.IO.File.Exists(sourceFilePath))
            //{
            //    return NotFound("Image file not found");
            //}

            // Ouverture d'un flux de lecture pour le fichier source

                // Ouverture d'un flux d'écriture pour le fichier de destination
                using (FileStream destinationStream = new FileStream(filePath, FileMode.Create))
                {
                // Copie du contenu du fichier source vers le fichier de destination
                    form.GuitareImage.CopyTo(destinationStream);
                }


            // Mise à jour des données de la guitare avec le nom de fichier
            GuitareModel updatedModel = new GuitareModel();

            updatedModel.UrlImage = filename;

            bool updatedGuitare = _guitareService.UpdateImgGuitares(updatedModel, id_Guitare);

            if (updatedGuitare)
            {
                return Ok();
            }
            else
            {
                return NotFound("Id Not Found");
            }
        }
        #endregion

        //[HttpGet(nameof(GetAllPagination))]
        //public ActionResult<IEnumerable<GuitareDTO>> GetAllPagination(int pageNumber)
        //{
        //    try
        //    {
        //        IEnumerable<GuitareModel> guitares = _guitareService.GetAllPagination(pageNumber);
        //        return Ok(guitares.Select(x => x.BllGuitareToApi()));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
        //    }
        //}

        [HttpGet(nameof(GetAllPagination))]
        public ActionResult<IEnumerable<GuitareDTO>> GetAllPagination(int pageNumber)
        {
            try
            {
                // Obtenir toutes les guitares
                IEnumerable<GuitareModel> allGuitares = _guitareService.GetAll();

                // Compter le nombre total de guitares
                int totalGuitaresCount = allGuitares.Count();

                // Pagination : obtenir uniquement les guitares de la page demandée
                IEnumerable<GuitareModel> guitares = _guitareService.GetAllPagination(pageNumber);

                // Retourner le résultat
                return Ok(new
                {
                    TotalItems = totalGuitaresCount,
                    Guitares = guitares.Select(x => x.BllGuitareToApi())
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
