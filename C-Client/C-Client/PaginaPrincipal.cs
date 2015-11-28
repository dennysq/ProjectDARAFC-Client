using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Client
{
    public partial class PaginaPrincipal : Form
    {

        private static PaginaPrincipal instance = null;
        private static readonly object padlock = new object();

        public static PaginaPrincipal Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PaginaPrincipal();
                    }
                    return instance;
                }
            }
        }

        PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void PaginaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void PaginaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.Instance.Show();
            Login.Instance.borrarCampos();
        }

        private void MenuItemRegistrarCliente_Click(object sender, EventArgs e)
        {
            IngresoCliente ingresoCliente = IngresoCliente.Instance;

            ingresoCliente.MdiParent = this;
            ingresoCliente.Show();
        }

        private void MenuItemRegistrarFactura_Click(object sender, EventArgs e)
        {
            IngresoFactura.Instance.MdiParent = this;
            IngresoFactura.Instance.Show();
        }

        private void MenuItemConsultarFactura_Click(object sender, EventArgs e)
        {
            ConsultaFactura.Instance.MdiParent = this;
            ConsultaFactura.Instance.Show();
        }

        private void MenuItemConsultarCliente_Click(object sender, EventArgs e)
        {
            ConsultaCliente.Instance.MdiParent = this;
            ConsultaCliente.Instance.Show();
        }
    }
}
