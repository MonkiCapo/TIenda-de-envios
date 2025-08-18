using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public class ProductoCarrito
    {
        public Carrito carrito { get; set; }
        public Producto producto { get; set; }
        public uint cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}