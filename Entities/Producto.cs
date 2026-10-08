namespace Entities
{
	public class Producto
	{
		public short ProductoId { get; set; }
		public string NombreProducto { get; set; } = string.Empty;
		public decimal Precio { get; set; }
		public int Existencia { get; set; }
		public int? CategoriaId { get; set; }
		public int Estado { get; set; } = 1;
	}
}
