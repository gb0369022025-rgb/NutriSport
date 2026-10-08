using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSport.Entities
{
	public class Det_Ctrl_Iventario
	{
		public int DetControlInvId { get; set; }
		public int Cantidad { get; set; }
		public string Observacion { get; set; } = string.Empty;
		public int? NombreControlInv { get; set; }
	}
}
