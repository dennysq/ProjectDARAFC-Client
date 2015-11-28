using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.models
{
    public class Producto
    {
        private String id;//Longitud fija: 10           Ejemplo: 0000000025  *Se completa con ceros a la ixquierda
        private String nombre;//Longitud: 30            Ejemplo: Cuaderno Norma
        private String precio;//Longitud fija:12        Ejemplo: 1256.30 *Siempre debe tener 2 decimales
        private String cantidad;//Longitud: 10          Ejemplo: 15
        private static char FIELD_SEPARATOR_CHAR = '|';
        public Producto()
        {

        }

        public Producto(String id, String nombre, String precio, String cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public String Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public String toString()
        {
            return id + FIELD_SEPARATOR_CHAR + nombre + FIELD_SEPARATOR_CHAR + precio + FIELD_SEPARATOR_CHAR + cantidad;
        }

    }
}
