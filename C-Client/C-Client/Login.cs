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

namespace C_Client
{
    public partial class Login : Form
    {
        public Login()
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
                    
                }
                else
                {
                    MessageBox.Show("El Usuario es incorrecto");
                }
            }
        }
    }
}
