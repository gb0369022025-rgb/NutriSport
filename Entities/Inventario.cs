using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Inventario
	{
		public int InventarioId { get; set; }
		public int Existencias { get; set; }
		public DateTime FechaActualizacion { get; set; }
	}
}
