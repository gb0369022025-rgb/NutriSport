using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Compra
	{
		public int CompraId { get; set; }
		public DateTime FechaHora { get; set; }
		public short NombreProveedor { get; set; }
		public int NumFact { get; set; }
		public int NombreUsuario { get; set; }
		public decimal SubTotal { get; set; }
		public decimal TotalPagar { get; set; }
		public string Estado { get; set; } = "Completada";
	}
}
