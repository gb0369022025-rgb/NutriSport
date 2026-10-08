using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Usuario
	{
		public int UsuarioId { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string NombreEmpleado { get; set; } = string.Empty;
		public string Clave { get; set; } = string.Empty;
		public string Tipo { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;
	}
}
