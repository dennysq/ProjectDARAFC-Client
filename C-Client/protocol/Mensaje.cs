using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace protocol
{
    public abstract class Mensaje
    {
        protected Cabecera cabecera;

       
        private String tipo;

        
        protected Cuerpo cuerpo;

        
	    public static  String TIPO_MENSAJE_REQUEST = "RQ";
	    public static  String TIPO_MENSAJE_RESPONSE = "RS";
	    public static  String ID_MENSAJE_CONSULTACLIENTE = "CONSULTACL";
	    public static  String ID_MENSAJE_CONSULTAFACTURA = "CONSULTAFA";
	    public static  String ID_MENSAJE_INGRESOCLIENTE = "INGRESOCLI";
	    public static  String ID_MENSAJE_INGRESOFACTURA = "INGRESOFAC";
	    public static  String ID_MENSAJE_AUTENTICACIONCLIENTE = "LOGINCLIEN";
        private utils.MyStringUtils mySU = new utils.MyStringUtils();

        public Boolean validateBobyHash()
        {
            
            return mySU.md5Hex(cuerpo.asTexto()).Equals(cabecera.Verificacion);
            
            //return DigestUtils.md5Hex(this.cuerpo.asTexto()).equals(cabecera.getVerificacion());

        }

        public Cuerpo Cuerpo
        {
            get { return cuerpo; }
            set {
                cuerpo = value;
                
                this.cabecera.LongitudCuerpo = this.cuerpo.asTexto().Length+"";
                this.cabecera.Verificacion = mySU.md5Hex(this.cuerpo.asTexto());

            }
        }

        protected String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        protected Cabecera Cabecera
        {
            get { return cabecera; }
            set { cabecera = value; }
        }

        public String asTexto()
        {

            return this.cabecera.asTexto() + this.cuerpo.asTexto();

        }

        public abstract Boolean build(String input);

        public Boolean validate(String input)
        {

            return input.Length >= Cabecera.HEADER_LENGTH;
        }

    }
}
