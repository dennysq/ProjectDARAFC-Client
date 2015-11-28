using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace protocol.models
{
    public class Cliente
    {
        private String identificacion;  //Longitud: 15    Ejemplo: 0503337909
        private String nombre;//Longitud: 30            Ejemplo: Daniela Valdez Ayora
        private String telefono;//Longitud: 10          Ejemplo: 032816955
        private String direccion;//Longitud: 50         Ejemplo: Latacunga, Calle 2 de Mayo y Tarqui 
        private static char FIELD_SEPARATOR_CHAR = '|';
        public Cliente(String identificacion, String nombre, String telefono, String direccion)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;

        }
        public Cliente()
        {

        }

        public String Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String asTexto()
        {
            return identificacion + "\t" + nombre + "\t" + telefono + "\t" + direccion;
        }

        public String toString()
        {
            return identificacion + FIELD_SEPARATOR_CHAR + nombre + FIELD_SEPARATOR_CHAR + telefono
                    + FIELD_SEPARATOR_CHAR + direccion;
        }

    }
}
