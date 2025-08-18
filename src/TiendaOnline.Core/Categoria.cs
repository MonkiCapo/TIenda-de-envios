using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public class Categoria
    {
        public byte ID_Categoria { get; set; }
        public required string Nombre { get; set; }
    }
}