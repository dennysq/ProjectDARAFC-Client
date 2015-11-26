using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.clienteApp.ingresos
{
    public class IngresoClienteRQ : Cuerpo
    {
        private String id;
        private String nombre;
        private String direccion;
        private String telefono;
        private static char FIELD_SEPARATOR_CHAR = '|';

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

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    



        public string asTexto()
        {
            return this.id + FIELD_SEPARATOR_CHAR + this.nombre + FIELD_SEPARATOR_CHAR + this.direccion + FIELD_SEPARATOR_CHAR +
                this.telefono + FIELD_SEPARATOR_CHAR;
        }

        public bool validate(string input)
        {
            if (input.Length >= 1 && input.Length <= 200)
                return true;
            else
                return false;
        }

        public void build(string input)
        {
            if(validate(input))
            {
                try{
                   String[] values=input.Split(FIELD_SEPARATOR_CHAR);
                    Id=values[0];
                    Nombre=values[1];
                    Direccion=values[2];
                    Telefono=values[3];
                
                }catch(Exception e){
                    Console.Out.WriteLine(" "+e.ToString());
                }
            }
        }

    }
}
