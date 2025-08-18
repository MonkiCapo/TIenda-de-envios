using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public class Envio
    {
        public uint ID_Envio { get; set; }
        public Carrito ID_Carrito { get; set; }
        public required DateTime Enviado { get; set; }
        public required DateTime Entregado { get; set; }
    }
}