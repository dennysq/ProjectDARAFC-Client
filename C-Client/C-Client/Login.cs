using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using protocol;
using protocol.clienteApp;
using protocol.clienteApp.seguridades;
using protocol.models;
using protocol.utils;

namespace C_Client
{
    public partial class Login : Form
    {
        private static Login instance = null;
        private static readonly object padlock = new object();
        TextValidations textValidations = new TextValidations();

        public static Login Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Login();
                    }
                    return instance;
                }
            }
        }

        Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            /*String s = "hola";
            MessageBox.Show(s.PadLeft(20,'0'));*/
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario;
            String password;

            usuario = txtUsuario.Text;
            password = txtPass.Text;

            if (usuario != null && password != null)
            {
                Empresa emp = Comunicacion.retrieveEmpresa(usuario, password);
                if (emp != null)
                {
                    MessageBox.Show("Usuario Correcto");
                    PaginaPrincipal paginaPrincipal = PaginaPrincipal.Instance;
                    paginaPrincipal.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("El Usuario es incorrecto");
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateDigits(e,txtUsuario.Text,10);
        }

        public void borrarCampos()
        {
            txtPass.Text = "";
            txtUsuario.Text = "";
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValidations.validateLength(e, txtPass.Text, 10);
        }
    }
}
