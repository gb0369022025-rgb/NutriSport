using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Categoria
	{
		public int CategoriaId { get; set; }
		public string NombreCategoria { get; set; } = string.Empty;
		public int Estado { get; set; } = 1;
	}
}
