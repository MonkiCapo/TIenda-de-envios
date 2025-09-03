namespace TiendaOnline.Core;

public class Producto
{
    public byte ID_Producto { get; set; }
    public Categoria Categoria { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public required decimal Precio { get; set; }
    public uint Stock { get; set; }
    public decimal Calificacion { get; set; }
}