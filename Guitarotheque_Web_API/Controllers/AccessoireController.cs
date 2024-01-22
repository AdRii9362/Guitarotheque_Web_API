using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Models;
using Guitarotheque_Web_API.Mapper;
using Guitarotheque_Web_API.Models.DTO;
using Guitarotheque_Web_API.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
