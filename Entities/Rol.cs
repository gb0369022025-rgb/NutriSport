using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Rol
	{
		public short RolId { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string Descripcion { get; set; } = string.Empty;
		public int Estado { get; set; } = 1;
	}
}
