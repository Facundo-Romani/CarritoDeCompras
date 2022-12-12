using CarritoDeCompras.Models;

namespace CarritoDeCompras.Services.ServicesContract
{
    public interface ITipoDescuentoCarrito
    {
        Carrito CalcularDescuento(Carrito carrito);
    }
}
