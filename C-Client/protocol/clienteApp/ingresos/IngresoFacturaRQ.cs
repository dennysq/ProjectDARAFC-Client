using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using protocol.models;

namespace protocol.clienteApp.ingresos
{
    public class IngresoFacturaRQ : Cuerpo
    {

        private String idFactura;
        private String identificacion;
        private String total;
        private String numeroDetalles;
        private List<DetalleFacturaAppRQ> detalles;
        private String fecha;

        public String IdFactura
        {
            get { return idFactura; }
            set { idFactura = value.PadLeft(10, '0'); }
        }

        public String Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public String Total
        {
            get { return total; }
            set { total = value.PadLeft(10, '0'); }
        }

        public String NumeroDetalles
        {
            get { return numeroDetalles; }
            set { numeroDetalles = value.PadLeft(4, '0'); }
        }

        public List<DetalleFacturaAppRQ> Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }

        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string asTexto()
        {
            return this.idFactura + this.identificacion + this.numeroDetalles + this.fecha + this.total + detallesAsTexto();
        }

        public bool validate(string input)
        {
            throw new NotImplementedException();
        }

        public void build(string input)
        {
            throw new NotImplementedException();
        }

        private String detallesAsTexto()
        {
            String text = "";
            if (detalles != null)
            {
                for (int i = 0; i < detalles.Count; i++)
                {
                    text += detalles[i].toString();
                }
            }
            return text;
        }
    }
}
