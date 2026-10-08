using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Proveedor
	{
		public short ProveedorId { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public string? Telefono { get; set; }
		public int Estado { get; set; } = 1;
	}
}
