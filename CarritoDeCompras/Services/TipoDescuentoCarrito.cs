using CarritoDeCompras.Context;
using CarritoDeCompras.Models;
using CarritoDeCompras.Services.ServicesContract;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;

namespace CarritoDeCompras.Services
{
    public class TipoDescuentoCarrito : ITipoDescuentoCarrito
    {
        private readonly DbContextCarrito _context;

        public TipoDescuentoCarrito(DbContextCarrito context)
        {
            _context = context;
        }


        public Carrito CalcularDescuento(Carrito carrito)
        {

            if (carrito.Cantidad > 5)
            {

                carrito.totalDescuento = carrito.Total * Convert.ToDecimal(0.20);

            }
            else if(carrito.Cantidad > 10 && carrito is Carrito)
            {

                carrito.totalDescuento = carrito.Total - 1000;

            }
            else if(carrito.Cantidad > 10 && carrito is CarroPromocional) 
            {

                carrito.totalDescuento = carrito.Total - 2500;

            }
            else if(carrito.Cantidad > 10 && carrito is CarroVip)
            {
                carrito.Productos = _context.Productos.OrderBy(p => p.Precio).ToList(); 
                // Corrección obtengo el precio de la lista y luego lo guardo para restar el total. 
            }
            
            _context.Carritos.Update(carrito);
            _context.SaveChanges();

            return carrito;
        }
    }
}
