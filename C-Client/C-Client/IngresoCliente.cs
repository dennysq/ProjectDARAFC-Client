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

namespace C_Client
{
    public partial class IngresoCliente : Form
    {

        private static IngresoCliente instance = null;
        private static readonly object padlock = new object();
        private TextValidations textValidations = new TextValidations();

        public static IngresoCliente Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new IngresoCliente();
                    }
                    return instance;
                }
            }
            set { instance = value; }
            
        }


        IngresoCliente()
        {
            InitializeComponent();
        }

        private void IngresoCliente_Load(object sender, EventArgs e)
        {
            
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateDigits(e,txtIdentificacion.Text,10);
        }

        private void IngresoCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            IngresoCliente.Instance = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            IngresoCliente.instance = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String identificacion;//valor fijo: 10 Ejemplo: 1312139866
            String nombre;//valor fijo: 30 ejepmlo Ana Lucia
            String telefono;// valor fijo: 10 ejemplo: 0993188521
            String direccion;//valor fijo: 50 ejemplo Quito
            nombre = txtNombre.Text;
            telefono = txtTelefono.Text;
            direccion = txtDireccion.Text;
            identificacion = txtIdentificacion.Text;

            if (nombre != null && telefono != null && direccion != null && identificacion.Length == 10)
            {
                if (Comunicacion.insertCliente(identificacion, nombre, direccion, telefono))
                {
                    MessageBox.Show("Ingreso Correcto");
                    
                }
                else
                {
                    MessageBox.Show("Ingreso Incorrecto");
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateLettersWithSpace(e, txtNombre.Text, 30);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateLength(e, txtDireccion.Text, 50);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateDigits(e, txtTelefono.Text, 10);
        }
    }
}
