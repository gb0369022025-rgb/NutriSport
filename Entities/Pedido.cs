using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Pedido
	{
		public int PedidoId { get; set; }
		public int? NumeroPedido { get; set; }
		public DateTime? Fecha { get; set; }
		public string Estado { get; set; } = "Pendiente";
	}
}
