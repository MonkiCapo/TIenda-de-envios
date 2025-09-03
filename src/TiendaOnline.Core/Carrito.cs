using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public class Carrito
    {
        public uint ID_Carrito { get; set; }
        public Cliente cliente { get; set; }
        public Billetera billetera { get; set; }
        public decimal total { get; set; }
        public bool Pagado { get; set; }
    }
}