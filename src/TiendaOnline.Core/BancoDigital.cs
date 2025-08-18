using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public class BancoDigital
    {
        public uint ID_BancoDigital { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }
    }
}