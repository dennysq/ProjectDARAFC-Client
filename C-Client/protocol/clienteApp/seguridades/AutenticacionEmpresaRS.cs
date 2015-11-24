using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using protocol.models;
using protocol.utils;


namespace protocol.clienteApp.seguridades
{
    public class AutenticacionEmpresaRS : Cuerpo
    {
        private String resultado;
        private Empresa empresa;
        public static char FIELD_SEPARATOR_CHAR='|';
        
        


        public string asTexto()
        {
            if (this.resultado != null && this.resultado.Equals("1"))
            {
                //solo si es uno retorno con los datos de la empresa encontrada
                return this.resultado + this.empresa.toString();
            }
            else
            {
                return this.resultado;
            }
        }

        public bool validate(string input)
        {
            return input.Length >= 1 && input.Length <= 401;
        }

        public void build(string input)
        {
            myStringUtils mySU = new myStringUtils();
           if (validate(input)) {
            if (input.Length < 401) {
                input = input.PadRight(401,' ');
            }
            try {
                String[] values = mySU.splitByFixedLengths(input, new int[]{1, 400});
                this.resultado = values[0];
                if (resultado.Equals("1")) {
                    String[] empresaValues = values[1].Split(FIELD_SEPARATOR_CHAR);
                    this.empresa = new Empresa();
                    this.empresa.Ruc=empresaValues[0];
                    this.empresa.Nombre=empresaValues[1];
                    this.empresa.Telefono=empresaValues[2];
                    this.empresa.Direccion=empresaValues[3];
                    this.empresa.Usuario=empresaValues[4];
                    this.empresa.Password=empresaValues[5];
                }
            } catch (Exception ex) {
               // Logger.getLogger(AutenticacionEmpresaRS.class.getName()).log(Level.SEVERE, null, ex);
                Console.Out.WriteLine(ex.ToString());
            }
        }
        }

        public String Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
    }
}
