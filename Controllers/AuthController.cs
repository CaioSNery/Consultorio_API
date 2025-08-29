using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            if (dto.Username == "admin" && dto.Password == "123456")
            {
                var token = _authService.GenerateToken(dto.Username, "Admin");
                return Ok(new { token });
            }

            return Unauthorized("Usuário ou senha inválidos");
        }
    }
}