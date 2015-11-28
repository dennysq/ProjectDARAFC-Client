using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.clienteApp.Consultas
{
    public class ConsultaClienteRQ : Cuerpo
    {
        private String identificacion;

        public String Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public string asTexto()
        {
            return identificacion;
        }

        public bool validate(string input)
        {
            if (input != null && input.Length <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void build(string input)
        {
            if (this.validate(input))
            {
                Identificacion=input;
            }
        }
    }
}
