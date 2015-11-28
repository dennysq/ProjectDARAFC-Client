using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using protocol.clienteApp.seguridades;
using protocol.clienteApp.ingresos;
using protocol.clienteApp.Consultas;
using protocol.clienteApp.consultas;

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
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_INGRESOCLIENTE))
                        {

                            IngresoClienteRS ingresoClienteRS = new IngresoClienteRS();
                            ingresoClienteRS.build(cuerpo);
                            this.cuerpo = ingresoClienteRS;
                        }
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_CONSULTACLIENTE))
                        {
                            ConsultaClienteRS consultaClienteRS = new ConsultaClienteRS();
                            consultaClienteRS.build(cuerpo);
                            this.cuerpo = consultaClienteRS;
                        }
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_CONSULTAPRODUCTO))
                        {
                            ConsultaProductoRS consultaProductoRS = new ConsultaProductoRS();
                            consultaProductoRS.build(cuerpo);
                            this.cuerpo = consultaProductoRS;
                        }
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_INGRESOFACTURA))
                        {
                            IngresoFacturaRS ingresoFacturaRS = new IngresoFacturaRS();
                            ingresoFacturaRS.build(cuerpo);
                            this.cuerpo = ingresoFacturaRS;
                        }
                        else
                        {
                            result=false;
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
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
