using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public interface IAdo
    {
        void AltaBancoDigital(BancoDigital bancoDigital);
        void AltaCategoria(Categoria categoria);
        IEnumerable<Categoria> ObtenerCategorias();
        void AltaCliente(Cliente cliente);
        void AltaBilletera(Billetera billetera);
        void AltaProducto(Producto producto);
        void AltaCarrito(Carrito carrito);
        void AltaProductoCarrito(ProductoCarrito productoCarrito);
        
        

        
        
    }
}