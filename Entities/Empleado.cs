namespace Entities
{
	public class Empleado
	{
		public int EmpleadoId { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string Apellido { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string DUI { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public short RolId { get; set; }
		public short CargoId { get; set; }
		public int Estado { get; set; } = 1;
	}
}
