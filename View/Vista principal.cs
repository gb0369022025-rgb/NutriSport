namespace View
{
    public partial class NutriSport : Form
    {
        public NutriSport()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmEmpleados())
            {
                frm.ShowDialog(this);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblVentasTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClientes())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmVentas())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmPedidos())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCategorias())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnControlInventario_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmControlInventario())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProductos())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCompras())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProveedores())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmUsuarios())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
