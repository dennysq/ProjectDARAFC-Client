using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using protocol.models;
using protocol.utils;

namespace protocol.clienteApp.consultas
{
    public class ConsultaProductoRS : Cuerpo
    {
        private String resultado; // Si 1: un solo producto, 2: no encontro; 3: mas 
        private Producto producto;
        private MyStringUtils mySU = new MyStringUtils();
        private static char FIELD_SEPARATOR_CHAR = '|';

        public String Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public string asTexto()
        {
            if (this.resultado != null && this.resultado.Equals("1"))
            {
                return this.resultado + this.producto.toString();
            }
            else
            {
                return this.resultado;
            }
        }

        public bool validate(string input)
        {
            return input.Length >= 1 && input.Length <= 73;
        }

        public void build(string input)
        {
            if (validate(input)) {
            if (input.Length < 401) {
                input = input.PadRight( 73, ' ');
            }
            try {
                String[] values = mySU.splitByFixedLengths(input, new int[]{1, 72});
                this.resultado = values[0];
                if (this.resultado.Equals("1")) {
                    String[] productoValues = values[1].Split(FIELD_SEPARATOR_CHAR);
                    this.producto = new Producto();
                    this.producto.Id=productoValues[0];
                    this.producto.Nombre=productoValues[1];
                    this.producto.Precio=productoValues[2];
                    this.producto.Cantidad=productoValues[3];
                }
            } catch (Exception ex) {
                Console.Out.WriteLine(ex.ToString());
            }
        }
        }
    }
}
