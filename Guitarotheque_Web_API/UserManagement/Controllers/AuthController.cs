using API_DemoBlazor.Tools;
using Guitarotheque_Web_API.UserManagement.Models;
using Guitarotheque_Web_API.UserManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guitarotheque_Web_API.UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _service;
        private readonly JwtGenerator _jwt;

        public AuthController(UserService service, JwtGenerator jwt)
        {
            _service = service;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User u)
        {
            _service.Register(u);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            User? connectedUser = _service.Login(form.Email, form.Password);
            if (connectedUser == null) return BadRequest("Connexion pas bien");
            return Ok(_jwt.GenerateToken(connectedUser));
        }

        //[Authorize("connectedPolicy")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            return Ok(_service.GetUsers());
        }
    }
}
