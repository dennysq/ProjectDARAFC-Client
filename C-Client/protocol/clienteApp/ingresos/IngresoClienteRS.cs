using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.clienteApp.ingresos
{
    public class IngresoClienteRS : Cuerpo
    {
        private String resultado;

        public String Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public string asTexto()
        {
            return this.Resultado;
        }

        public bool validate(string input)
        {
            if (input.Length == 1)
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
            if (validate(input))
            {
                this.Resultado=input;

            }
        }
    }
}
