using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using protocol;
using protocol.clienteApp;
using protocol.clienteApp.seguridades;
using protocol.clienteApp.ingresos;
using protocol.clienteApp.Consultas;
using protocol.clienteApp.consultas;
using protocol.models;


namespace C_Client
{
    public class Comunicacion
    {
        public static String OK_RESPONSE = "OK";
        public static String BAD_RESPONSE = "BAD";
        public static String NULL_PARAMETERS = "Uno de los campos usados para el metodo es nulo";

        public static Empresa retrieveEmpresa(String usuario, String password) {
        if (usuario != null && password != null) {
            AppClient appClient = new AppClient();
            AutenticacionEmpresaRQ aerq = new AutenticacionEmpresaRQ();

            aerq.Password=password;
            aerq.UserId=usuario;

            MensajeRQ mensajeRQ = new MensajeRQ("raul", Mensaje.ID_MENSAJE_AUTENTICACIONCLIENTE);
            mensajeRQ.Cuerpo=aerq;
            MensajeRS mensajeRS = appClient.sendRequest(mensajeRQ);
            AutenticacionEmpresaRS aers;
            if (mensajeRS != null)
                aers = (AutenticacionEmpresaRS)mensajeRS.Cuerpo;
            else
            {
                aers = new AutenticacionEmpresaRS();
                aers.Resultado = "2";
            }
            
            if (aers.Resultado.Equals("1")) {
                Console.Out.WriteLine(""+aers.Empresa);
                return aers.Empresa;
            }
            }
            return null;
        }

        public static Boolean insertCliente(String id, String nombre, String direccion, String telefono)
        {
            if (nombre != null && telefono != null && direccion != null && id.Length == 10)
            {
                AppClient appClient = new AppClient();
                IngresoClienteRQ IngresoClienteRQ = new IngresoClienteRQ();
                IngresoClienteRQ.Id = id;
                IngresoClienteRQ.Nombre = nombre;
                IngresoClienteRQ.Direccion = direccion;
                IngresoClienteRQ.Telefono = telefono;

                MensajeRQ mensajeRQ = new MensajeRQ("raul", Mensaje.ID_MENSAJE_INGRESOCLIENTE);
                mensajeRQ.Cuerpo = IngresoClienteRQ;
                MensajeRS mensajeRS = appClient.sendRequest(mensajeRQ);
                IngresoClienteRS ingresoClienteRS = (IngresoClienteRS)mensajeRS.Cuerpo;
                if (ingresoClienteRS.Resultado.Equals("1"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static Cliente retrieveCliente(String datos) {
        if (datos != null && datos.Length == 10) {
            AppClient appClient = new AppClient();
            ConsultaClienteRQ cliRQ = new ConsultaClienteRQ();
            cliRQ.Identificacion=datos;

            MensajeRQ mensajeRQ = new MensajeRQ("Raul", Mensaje.ID_MENSAJE_CONSULTACLIENTE);
            mensajeRQ.Cuerpo=cliRQ;
            MensajeRS mensajeRS = appClient.sendRequest(mensajeRQ);
            ConsultaClienteRS cliRS = (ConsultaClienteRS) mensajeRS.Cuerpo;
            if (cliRS.Resultado.Equals("1")) {
                Console.Out.WriteLine("" + cliRS.Cliente);
                return cliRS.Cliente;
            }

            }
            return null;
        }

        public static Producto retrieveProducto(String idProducto) {

            if (idProducto != null) {
                AppClient appClient = new AppClient();
                ConsultaProductoRQ cprq = new ConsultaProductoRQ();

                cprq.Id=idProducto;

                MensajeRQ mensajeRQ = new MensajeRQ("Raul", Mensaje.ID_MENSAJE_CONSULTAPRODUCTO);
                mensajeRQ.Cuerpo=cprq;
                MensajeRS mensajeRS = appClient.sendRequest(mensajeRQ);
                ConsultaProductoRS cprs = (ConsultaProductoRS) mensajeRS.Cuerpo;
                if (cprs.Resultado.Equals("1")) {
                    Console.Out.WriteLine("" + cprs.Producto);
                    return cprs.Producto;
                }
            }
            return null;
        }

        public static String registrarFactura(String idFactura, String identificacionCliente, DateTime fecha, float totalFactura, List<DetalleFacturaAppRQ> detalles)
        {

            if (identificacionCliente != null && fecha != null && detalles != null && idFactura != null)
            {
                IngresoFacturaRQ ingresoFacturaRQ = new IngresoFacturaRQ();
                AppClient appClient = new AppClient();
                ingresoFacturaRQ.Detalles=detalles;
                ingresoFacturaRQ.IdFactura=idFactura;
                ingresoFacturaRQ.Identificacion=identificacionCliente;
                ingresoFacturaRQ.NumeroDetalles=detalles.Count.ToString();
                ingresoFacturaRQ.Fecha = fecha.ToString("yyyyMMdd");
                ingresoFacturaRQ.Total = totalFactura.ToString();
                MensajeRQ mensajeRQ = new MensajeRQ("Raul", Mensaje.ID_MENSAJE_INGRESOFACTURA);
                mensajeRQ.Cuerpo=ingresoFacturaRQ;
                MensajeRS mensajeRS = appClient.sendRequest(mensajeRQ);
                if (mensajeRS != null)
                {
                    IngresoFacturaRS ingresoFacturaRS = (IngresoFacturaRS)mensajeRS.Cuerpo;
                    return ingresoFacturaRS.Resultado;
                }
                return BAD_RESPONSE;
            }
            else
            {
                return NULL_PARAMETERS;
            }

        }
       
    }
}
