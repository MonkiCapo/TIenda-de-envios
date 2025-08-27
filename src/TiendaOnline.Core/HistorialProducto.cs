namespace TiendaOnline.Core
{
    public class HistorialProducto{
        public int ID_HistorialCompra { get; set; }
        public uint ID_Cliente { get; set; }
        public uint ID_Producto { get; set; }
        public required DateTime fechayhora {get; set; }

    }

}

