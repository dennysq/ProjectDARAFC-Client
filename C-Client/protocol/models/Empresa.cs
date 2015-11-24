using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol.models
{
    public class Empresa
    {
        private String ruc;//Longitud : 13              Ejemplo: 0000235681000
        private String nombre; //Longitud: 20           Ejemplo: AlterBios
        private String telefono;//Longitud: 10          Ejemplo: 032816955
        private String direccion;//Longitud: 50         Ejemplo: Latacunga, Calle 2 de Mayo y Tarqui 
        private String usuario; //Longitud fija: 10     Ejemplo:admin
        private String password; // Longitud fija: 10   Ejemplo:123456789
        public static char FIELD_SEPARATOR_CHAR='|';
       

        //Todos los string de longitud fija usan StringUtils.rightPad y se rellenan con espacios en blanco
        //excepto si son IDs de la clase, esos usan StringUtils.leftPad y se rellenan con ceros
        //Solo manejamos la autentifacion de una empresa
        public Empresa(String a, String b, String c, String d, String e, String f)
        {
            ruc = a;
            nombre = b;
            telefono = c;
            direccion = d;
            usuario = e;
            password = f;
        }

        public Empresa()
        {

        }

        public String Ruc
        {
            get { return ruc; }
            set { ruc = value; }
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

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String toString()
        {
            return ruc + FIELD_SEPARATOR_CHAR + nombre + FIELD_SEPARATOR_CHAR + telefono + FIELD_SEPARATOR_CHAR + direccion + FIELD_SEPARATOR_CHAR + usuario + FIELD_SEPARATOR_CHAR + password + FIELD_SEPARATOR_CHAR;
        }
    }
}
