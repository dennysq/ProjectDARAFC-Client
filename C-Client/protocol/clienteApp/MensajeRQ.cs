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
    public class MensajeRQ : Mensaje
    {
        public MensajeRQ()
        {
        }

        public MensajeRQ(String originador, String idMensaje)
        {
            this.cabecera = new Cabecera(Mensaje.TIPO_MENSAJE_REQUEST, originador, idMensaje);
        }
        public override bool build(string input)
        {
            Boolean result = true;
            if (validate(input))
            {
                this.cabecera = new Cabecera();
                // Prueba repositorio GIT
                if (this.cabecera.build(input.Substring(0, Cabecera.HEADER_LENGTH)))
                {
                    // se obtiene el resto del mensaje que seria el cuerpo
                    String cuerpo = input.Substring(Cabecera.HEADER_LENGTH);
                    if (this.cabecera.TipoMensaje.Equals(Mensaje.TIPO_MENSAJE_REQUEST))
                    {
                        if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_AUTENTICACIONCLIENTE))
                        {
                            AutenticacionEmpresaRQ autenticacionClienteRQ = new AutenticacionEmpresaRQ();
                            autenticacionClienteRQ.build(cuerpo);
                            this.cuerpo = autenticacionClienteRQ;
                        }
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_INGRESOCLIENTE))
                        {
                            IngresoClienteRQ ingresoClienteRQ = new IngresoClienteRQ();
                            ingresoClienteRQ.build(cuerpo);
                            this.cuerpo = ingresoClienteRQ;
                        }
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_CONSULTACLIENTE))
                        {
                            ConsultaClienteRQ consultaClienteRQ = new ConsultaClienteRQ();
                            consultaClienteRQ.build(cuerpo);
                            this.cuerpo = consultaClienteRQ;
                        }
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_CONSULTAPRODUCTO))
                        {
                            
                            ConsultaProductoRQ consultaProductoRQ = new ConsultaProductoRQ();
                            consultaProductoRQ.build(cuerpo);
                            this.cuerpo = consultaProductoRQ;
                        }
                        else if (this.cabecera.IdMensaje.Equals(ID_MENSAJE_INGRESOFACTURA))
                        {

                            IngresoFacturaRQ ingresoFacturaRQ = new IngresoFacturaRQ();
                            ingresoFacturaRQ.build(cuerpo);
                            this.cuerpo = ingresoFacturaRQ;
                        }
                        
                        else {
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
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
