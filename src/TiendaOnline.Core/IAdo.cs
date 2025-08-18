using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public interface IAdo
    {
        void AltaBancoDigital(string Nombre, string tipo);
        void AltaCategoria(string Nombre);
        void AltaCliente(string Nombre, string Correo, string Telefono);
        void AltaBilletera(Cliente cliente, BancoDigital bancoDigital, decimal Saldo);
        void AltaProducto(string Nombre, string Descripcion, decimal Precio, uint Stock, Categoria categoria);
        void AltaCarrito(Carrito carrito, Cliente cliente, uint total, bool Pagado, DateTime Emision);
        void AltaProductoCarrito(Carrito carrito, Producto producto, uint cantidad, decimal PrecioUnitario);
        

        List<BancoDigital> ObtenerBancosdigitales();
        
    }
}