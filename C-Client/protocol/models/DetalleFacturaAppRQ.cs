using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.models
{
    public class DetalleFacturaAppRQ
    {
        private String idProducto;
        private String cantidad;
        private static char FIELD_SEPARATOR_CHAR = '|';

        public DetalleFacturaAppRQ()
        {
        }

        public DetalleFacturaAppRQ(String idProducto, String cantidad)
        {
            this.idProducto = idProducto;
            this.cantidad = cantidad;
        }

        public String IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public String Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public String toString()
        {
            return idProducto + FIELD_SEPARATOR_CHAR + cantidad + FIELD_SEPARATOR_CHAR;
        }


    }
}
