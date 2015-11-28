using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using protocol.utils;
using protocol.models;

namespace C_Client
{
    public partial class IngresoFactura : Form
    {
        private static IngresoFactura instance = null;
        private static readonly object padlock = new object();
        private TextValidations textValidations = new TextValidations();
        private static DataTable dtFactura;
        double precioTotal = 0;
        public static IngresoFactura Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new IngresoFactura();
                    }
                    return instance;
                }
            }
            set { instance = value; }

        }
        IngresoFactura()
        {
            InitializeComponent();
        }

        private void RegistroFactura_Load(object sender, EventArgs e)
        {
            txtRucEmpresa.Text = Login.Instance.Empresa.Ruc;
            txtNombreEmpresa.Text = Login.Instance.Empresa.Nombre;
            txtTelefonoEmpresa.Text = Login.Instance.Empresa.Telefono;
            txtDireccionEmpresa.Text = Login.Instance.Empresa.Direccion;
            dtFactura = new DataTable();
            dtFactura.Columns.Add("CODIGO", typeof(string));
            dtFactura.Columns.Add("NOMBRE", typeof(string));
            dtFactura.Columns.Add("CANTIDAD", typeof(string));
            dtFactura.Columns.Add("PRECIO/U", typeof(string));
            dtFactura.Columns.Add("PRECIO", typeof(string));
            dgvDetalle.DataSource = dtFactura;
        }

        private void IngresoFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            IngresoFactura.Instance = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (!txtBuscarCliente.Text.Equals(""))
            {
                Cliente cliente = Comunicacion.retrieveCliente(txtBuscarCliente.Text);
                if (cliente == null)
                {
                    MessageBox.Show("No se encontró el cliente");
                }
                else
                {
                    txtIdentificacionCliente.Text = cliente.Identificacion;
                    txtNombreCliente.Text = cliente.Nombre;
                    txtTelefonoCliente.Text = cliente.Telefono;
                    txtDireccionCliente.Text = cliente.Direccion;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar la identificación del cliente");
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (!txtBuscarCodigo.Text.Equals(""))
            {
                Producto producto = Comunicacion.retrieveProducto(txtBuscarCodigo.Text);
                if (producto == null)
                {
                    MessageBox.Show("No se encontró el producto");
                }
                else
                {
                    txtCodigoProducto.Text = producto.Id;
                    txtNombreProducto.Text = producto.Nombre;
                    txtPrecioProducto.Text = producto.Precio;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar el código del producto");
            }
        }

        private void brnAniadirProducto_Click(object sender, EventArgs e)
        {
            if (!txtCantidadProducto.Text.Equals(""))
            {
                int flag = -1;

                for (int i = 0; i < dtFactura.Rows.Count; i++)
                {
                   
                    if (dtFactura.Rows[i][0].ToString() == txtCodigoProducto.Text)
                    {
                        flag = i;
                        break;
                    }
                }
                if (flag == -1)
                {
                    double precioD;
                    
                    if (txtPrecioProducto.Text.Contains('.'))
                    {
                        String[] precio = txtPrecioProducto.Text.Split('.');
                        if (precio.Length > 1)
                        {
                             precioD = double.Parse(precio[0]) + double.Parse("0," + precio[1]);
                        }
                        else
                        {

                             precioD = double.Parse(precio[0]);
                        }

                    }
                    else
                    {
                         precioD = double.Parse(txtPrecioProducto.Text);

                    }
                    precioTotal = precioTotal + precioD;
                    txtTotal.Text = precioTotal.ToString();

                    dtFactura.Rows.Add(txtCodigoProducto.Text,
                                        txtNombreProducto.Text,
                                        txtCantidadProducto.Text,
                                        txtPrecioProducto.Text,
                                       Math.Round((int.Parse(txtCantidadProducto.Text) * precioD), 2) + "");
                }
                else
                {
                    MessageBox.Show("El producto ya existe");
                }
            }
            else
            {
                MessageBox.Show("Debe elegir un producto e ingresar la cantidad");
            }
        }

        private static double convert(String dato)
        {
            double result = 0;
            String[] partes = dato.Split('.');

            return result;
        }

        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            if (dtFactura.Rows.Count > 0 && !txtIdentificacionCliente.Text.Equals(""))
            {
                List<DetalleFacturaAppRQ> detalles = new List<DetalleFacturaAppRQ>();

                for (int i = 0; i < dtFactura.Rows.Count; i++)
                {
                    detalles.Add(new DetalleFacturaAppRQ(dtFactura.Rows[i][0].ToString(), dtFactura.Rows[i][2].ToString()));
                    
                }

               
                int codFactura = int.Parse(txtCodigoFactura.Text);
                DateTime date = DateTime.Now;

                String result = Comunicacion.registrarFactura(codFactura.ToString(), txtIdentificacionCliente.Text, date, (float)precioTotal, detalles);

                if (result.Equals("1"))
                {
                    MessageBox.Show("Factura ingresada correctamente");
                }
                if (result.Equals("3"))
                {
                    MessageBox.Show("El código de la factura esta duplicado");
                }
                else
                {
                    MessageBox.Show("La Factura no pudo ser ingresada");
                }

               
            }
            else
            {
                MessageBox.Show("Debe registrar productor y seleccionar un cliente");
            }
        }

        private void txtCodigoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateDigits(e,txtCodigoFactura.Text,10);
        }

        private void txtBuscarCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateDigits(e, txtCodigoProducto.Text, 10);
        }

        private void txtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateDigits(e, txtIdentificacionCliente.Text, 20);
        }
    }
}
