using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public class Cabecera
    {
        private String tipoMensaje; //Longitud fija: 2      Ejemplo: RS o RQ
        private String originador; //Longitud fija:20       Ejemplo: appServer/ip
        private String fecha;//Longitud fija:17             Ejemplo: yyyyMMddHHmmssSSS 20151109213615012
        private String idMensaje;//Longitud fija:10         Ejemplo: CONSULTACL
        private String longitudCuerpo;//Longitud fija:4     Ejemplo: 0098
        private String verificacion;//Longitud fija:32      Ejemplo: 6fb6aaba394b3b6759160add3b53b070
        public static int HEADER_LENGTH = 85;
        private utils.MyStringUtils mySU = new utils.MyStringUtils();
        public Cabecera(String tipoMensaje, String originador, String idMensaje)
        {
            
            this.tipoMensaje = tipoMensaje;
            this.Originador = originador;
            this.idMensaje = idMensaje;
            this.fecha=DateTime.Now.ToString("yyyyMMddHHmmssfff");
            /*SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmssSSS");
            this.fecha = sdf.format(Calendar.getInstance().getTime());*/

        }
        public Cabecera()
        { }

        public String TipoMensaje
        {
            get { return tipoMensaje; }
            set { tipoMensaje = value; }
        }

        public String Originador
        {
            get { return originador; }
            set { originador = value.PadLeft(20,'0'); }
        }

        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public String IdMensaje
        {
            get { return idMensaje; }
            set { idMensaje = value; }
        }

        public String LongitudCuerpo
        {
            get { return longitudCuerpo; }
            set { longitudCuerpo = value.PadLeft(4,'0'); }
        }

        public String Verificacion
        {
            get { return verificacion; }
            set { verificacion = value; }
        }

        public String asTexto()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(this.tipoMensaje);
            sb.Append(this.originador);
            sb.Append(this.fecha);
            sb.Append(this.idMensaje);
            sb.Append(this.LongitudCuerpo);
            sb.Append(this.Verificacion);
            return sb.ToString();

        }
        public Boolean validate(String input)
        {
            return input.Length == HEADER_LENGTH;
        }

        public Boolean build(String input) {
        if (validate(input)) {
            try {
                
                String[] values = mySU.splitByFixedLengths(input, new int[]{2, 20, 17, 10, 4, 32});
                this.tipoMensaje = values[0];
                this.originador = values[1];
                this.fecha = values[2];
                this.idMensaje = values[3];
                this.longitudCuerpo = values[4];
                this.verificacion = values[5];
                return true;
            } catch (Exception e) {

                // e.printStackTrace();
                Console.Out.WriteLine("" + e);
                
            }

        }
        return false;
    }


    }
}
