using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace protocol.utils
{
    public class DateTableUtils
    {
        public DataTable fillDataTableFactura()
        {
            DataTable dataTable = new DataTable();
            //adding Columns
            dataTable.Columns.Add("NOMBRE", typeof(String));
            dataTable.Columns.Add("CANTIDAD", typeof(String));
            dataTable.Columns.Add("colString", typeof(String));
            return null;
        }
    }
}
