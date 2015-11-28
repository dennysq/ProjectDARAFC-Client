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
    public partial class ConsultaFactura : Form
    {
        private static ConsultaFactura instance = null;
        private static readonly object padlock = new object();
        private TextValidations textValidations = new TextValidations();

        public static ConsultaFactura Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ConsultaFactura();
                    }
                    return instance;
                }
            }
            set { instance = value; }

        }
        
        ConsultaFactura()
        {
            InitializeComponent();
        }

        private void ConsultaFactura_Load(object sender, EventArgs e)
        {

        }

        private void ConsultaFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConsultaFactura.Instance = null;
        }
    }
}
