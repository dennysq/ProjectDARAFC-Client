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
    public partial class ConsultaCliente : Form
    {
        private static ConsultaCliente instance = null;
        private static readonly object padlock = new object();
        private TextValidations textValidations = new TextValidations();

        public static ConsultaCliente Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ConsultaCliente();
                    }
                    return instance;
                }
            }
            set { instance = value; }

        }

        ConsultaCliente()
        {
            InitializeComponent();
        }

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {

        }

        private void ConsultaCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConsultaCliente.Instance = null;
        }
    }
}
