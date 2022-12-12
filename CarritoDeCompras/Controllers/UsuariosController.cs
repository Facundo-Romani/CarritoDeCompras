using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarritoDeCompras.Context;
using CarritoDeCompras.Models;
using CarritoDeCompras.Services.ServicesContract;

namespace CarritoDeCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        // Crear Usuario.
        // POST: api/Usuarios
        [HttpPost]
        public IActionResult CrearUsuario(Usuario obj)
        {
            var usuario = _usuarioService.CrearUsuario(obj);

            return Ok(usuario);
        }

    }
}
