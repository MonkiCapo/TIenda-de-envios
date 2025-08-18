using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using TiendaOnline.Core;

namespace TiendaOnline.Dapper
{
    public class AdoDapper
    {
        private readonly IDbConnection _conexion;
        public AdoDapper(IDbConnection conexion) => this._conexion = conexion;
        public AdoDapper(string cadena) => _conexion = (new MySqlConnection(cadena));

        // void AltaBancoDigital(string Nombre, string tipo);
        // void AltaCategoria(string Nombre);
        // void AltaCliente(string Nombre, string Correo, string Telefono);
        // void AltaBilletera(Cliente cliente, BancoDigital bancoDigital, decimal Saldo);
        // void AltaProducto(string Nombre, string Descripcion, decimal Precio, uint Stock, Categoria categoria);
        // void AltaCarrito(Carrito carrito, Cliente cliente, uint total, bool Pagado, DateTime Emision);
        // void AltaProductoCarrito(Carrito carrito, Producto producto, uint cantidad, decimal PrecioUnitario);
    }
}