using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using protocol.clienteApp.seguridades;

namespace protocol.clienteApp
{
    public class MensajeRS : Mensaje
    {
        public MensajeRS()
        {
        }
        public MensajeRS(String originador, String idMensaje)
        {
            this.cabecera = new Cabecera(Mensaje.TIPO_MENSAJE_RESPONSE, originador, idMensaje);
        }

        public override bool build(string input)
        {
            Boolean result = true;
            if (validate(input))
            {
                this.cabecera = new Cabecera();

                if (this.cabecera.build(input.Substring(0, Cabecera.HEADER_LENGTH)))
                {
                    String cuerpo = input.Substring(Cabecera.HEADER_LENGTH);

                    if (this.cabecera.TipoMensaje.Equals(Mensaje.TIPO_MENSAJE_RESPONSE))
                    {
                        if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_AUTENTICACIONCLIENTE))
                        {
                            
                            AutenticacionEmpresaRS autenticacionClienteRS = new AutenticacionEmpresaRS();
                            autenticacionClienteRS.build(cuerpo);
                            this.cuerpo = autenticacionClienteRS; 
                        }
                        else
                        {
                            result=false;
                        }
                        /*switch (this.cabecera.IdMensaje)
                        {
                            case ID_MENSAJE_AUTENTICACIONCLIENTE+"":
                                AutenticacionEmpresaRS autenticacionClienteRS = new AutenticacionEmpresaRS();
                                autenticacionClienteRS.build(cuerpo);
                                this.cuerpo = autenticacionClienteRS;
                                break;
                            case ID_MENSAJE_CONSULTACLIENTE:
                                ConsultaClienteRS consultaClienteRS = new ConsultaClienteRS();
                                consultaClienteRS.build(cuerpo);
                                this.cuerpo = consultaClienteRS;
                                break;
                            case ID_MENSAJE_CONSULTAFACTURA:
                                ConsultaFacturaRS consultaFacturaRS = new ConsultaFacturaRS();
                                consultaFacturaRS.build(cuerpo);
                                this.cuerpo = consultaFacturaRS;
                                break;
                            case ID_MENSAJE_INGRESOCLIENTE:
                                IngresoClienteRS ingresoClienteRS = new IngresoClienteRS();
                                ingresoClienteRS.build(cuerpo);
                                this.cuerpo = ingresoClienteRS;
                                break;
                            case ID_MENSAJE_INGRESOFACTURA:
                                IngresoFacturaRS ingresoFacturaRS = new IngresoFacturaRS();
                                ingresoFacturaRS.build(cuerpo);
                                this.cuerpo = ingresoFacturaRS;
                                break;
                            default:
                                result = false;
                        }*/
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
