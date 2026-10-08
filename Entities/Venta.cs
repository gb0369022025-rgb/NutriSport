using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Venta
	{
		public int IdVenta { get; set; }
		public DateTime FechaVenta { get; set; }
		public string Estado { get; set; } = string.Empty;
		public string Descripcion { get; set; } = string.Empty;
		public int? ClienteId { get; set; }
	}
}
