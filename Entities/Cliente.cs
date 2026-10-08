using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Cliente
	{
		public int ClienteId { get; set; }
		public string? Nombre { get; set; }
		public string? Apellido { get; set; }
		public string? Telefono { get; set; }
		public string? Email { get; set; }
		public string? DUI { get; set; }
		public int Estado { get; set; } = 1;
	}
}
