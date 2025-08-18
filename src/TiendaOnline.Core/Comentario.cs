using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public class Comentario
    {
        public Cliente FK_cliente { get; set; }
        public Producto FK_producto { get; set; }
        public required string comentario { get; set; }
        public required DateTime Publicado { get; set; }
        public required decimal Calificacion { get; set; }
    }
}