using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace protocol
{
    abstract class Mensaje
    {
        protected Cabecera cabecera;
        private String tipo;

        
        private Cuerpo cuerpo;

        
	    public static  String TIPO_MENSAJE_REQUEST = "RQ";
	    public static  String TIPO_MENSAJE_RESPONSE = "RS";
	    public static  String ID_MENSAJE_CONSULTACLIENTE = "CONSULTACL";
	    public static  String ID_MENSAJE_CONSULTAFACTURA = "CONSULTAFA";
	    public static  String ID_MENSAJE_INGRESOCLIENTE = "INGRESOCLI";
	    public static  String ID_MENSAJE_INGRESOFACTURA = "INGRESOFAC";
	    public static  String ID_MENSAJE_AUTENTICACIONCLIENTE = "LOGINCLIEN";
        private utils.myStringUtils mySU = new utils.myStringUtils();

        public Boolean validateBobyHash()
        {
            
            return mySU.md5Hex(cuerpo.asTexto()).Equals(cabecera.Verificacion);
            
            //return DigestUtils.md5Hex(this.cuerpo.asTexto()).equals(cabecera.getVerificacion());

        }

        protected Cuerpo Cuerpo
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

        public String asTexto()
        {

            return this.cabecera.asTexto() + this.cuerpo.asTexto();

        }

    }
}
