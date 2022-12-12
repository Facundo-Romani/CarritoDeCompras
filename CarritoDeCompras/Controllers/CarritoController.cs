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
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }


        // POST: api/Carrito
        [HttpPost("{dni}")]
        public IActionResult PostCarrito(int dni)
        {
            var carrito = _carritoService.CrearCarrito(dni);

            return Ok(carrito);
        }


        // DELETE: api/Carrito
        [HttpDelete("{id}")]
        public IActionResult DeleteCarrito(int id)
        {
            if (id != null)
            {
                _carritoService.DeleteCarrito(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }



        [HttpPost]
        public IActionResult AgregarProductos(int idProducto, int idCarrito)
        {
            _carritoService.AddProducto(idProducto, idCarrito);

            return Ok();
        }



        [HttpDelete]
        public IActionResult RemoverProductos(int idProducto, int idCarrito)
        {
            _carritoService.DeleteProductoCarrito(idProducto, idCarrito);

            return Ok();
        }
    }
}
