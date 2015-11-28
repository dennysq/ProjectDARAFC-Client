using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.clienteApp.ingresos
{
    public class IngresoFacturaRS : Cuerpo
    {
        private String resultado;

        public String Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public string asTexto()
        {
            return this.resultado;
        }

        public bool validate(string input)
        {
            return input.Length == 1;
        }

        public void build(string input)
        {
            if (validate(input))
            {
                this.resultado = input;
            }
        }
    }
}
