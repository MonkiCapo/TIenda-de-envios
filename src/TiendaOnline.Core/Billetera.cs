using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Core
{
    public class Billetera
    {
        public byte ID_Billetera { get; set; }
        public Cliente ID_Cliente { get; set; }
        public BancoDigital ID_BancoDigital { get; set; }
        public decimal Saldo { get; set; }
    }
}