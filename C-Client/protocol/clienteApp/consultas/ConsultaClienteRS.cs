using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using protocol.models;
using protocol.utils;

namespace protocol.clienteApp.Consultas
{
    public class ConsultaClienteRS : Cuerpo
    {
        private String resultado;
        private Cliente cliente;
        private MyStringUtils mySU = new MyStringUtils();
        private static char FIELD_SEPARATOR_CHAR = '|';

        public String Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        public string asTexto()
        {
            if (this.resultado != null && this.resultado.Equals("1"))
            {
                //solo si es uno retorno con los datos de la empresa encontrada
                return this.resultado + this.cliente.toString();
            }
            else
            {
                return this.resultado;
            }
        }

        public bool validate(string input)
        {
            if (input != null && input.Length >= 1 && input.Length <= 201)
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
            if (validate(input)) {
            if (input.Length < 201) {
                input = input.PadRight(201, ' ');
            }
            try {
                String[] values = mySU.splitByFixedLengths(input, new int[]{1, 200});
                this.resultado = values[0];
                if (resultado.Equals("1")) {
                    String[] CliValues = values[1].Split(FIELD_SEPARATOR_CHAR);
                    this.cliente = new Cliente();
                    this.cliente.Identificacion=CliValues[0];
                    this.cliente.Nombre=CliValues[1];
                    this.cliente.Telefono=CliValues[2];
                    this.cliente.Direccion=CliValues[3];
                }
                } catch (Exception ex) {
                    Console.Out.WriteLine(ex.ToString());
                }
            }
        }
    }
}
