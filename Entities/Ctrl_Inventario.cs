using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Ctrl_Inventario
	{
		public int ControlInvId { get; set; }
		public int NombreUsuario { get; set; }
		public DateTime FechaHora { get; set; }
		public int CantProducto { get; set; }
		public string? Observacion { get; set; }
		public string Estado { get; set; } = string.Empty;
	}
}
