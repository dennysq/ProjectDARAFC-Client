using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using protocol;
using protocol.clienteApp;
using protocol.clienteApp.seguridades;
using protocol.clienteApp.ingresos;
using protocol.models;

namespace C_Client
{
    public class Comunicacion
    {
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
       
    }
}
