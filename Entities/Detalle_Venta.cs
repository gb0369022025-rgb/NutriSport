using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Detalle_Venta
	{
		public int DetalleVentaId { get; set; }
		public short Cantidad { get; set; }
		public decimal PrecioUnitario { get; set; }
		public decimal TotalPagar { get; set; }
		public int? IdVenta { get; set; }
		public short? ProductoId { get; set; }
	}
}
