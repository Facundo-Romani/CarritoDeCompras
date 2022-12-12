using CarritoDeCompras.Models;

namespace CarritoDeCompras.Services.ServicesContract
{
    public interface ICarritoService
    {
        Carrito CrearCarrito(int dni);

        void DeleteCarrito(int id);

        Carrito AddProducto(int idProducto , int idCarrito);

        Carrito DeleteProductoCarrito(int idProducto , int idCarrito);
    }
}
