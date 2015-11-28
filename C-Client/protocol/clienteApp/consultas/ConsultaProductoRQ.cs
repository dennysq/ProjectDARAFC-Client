using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.clienteApp.consultas
{
    public class ConsultaProductoRQ : Cuerpo
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public string asTexto()
        {
            return id;
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
                Id=input;
            }
        }
    }
}
