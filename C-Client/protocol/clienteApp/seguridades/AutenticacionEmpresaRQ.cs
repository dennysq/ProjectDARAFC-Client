using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using protocol.utils;

namespace protocol.clienteApp.seguridades
{
    public class AutenticacionEmpresaRQ : Cuerpo
    {
        private String userId;
        private String password;

        public String UserId
        {
            get { return userId; }
            set { userId = value.PadRight(20,' '); }
        }

        public String Password
        {
            get { return password; }
            set { password = value.PadRight(20, ' '); }
        }

        public string asTexto()
        {
            return this.userId + this.password;
        }

        public bool validate(string input)
        {
            return input.Length == 40;
        }

        public void build(string input)
        {
            myStringUtils mySU = new myStringUtils();
            if (validate(input)) {
            try {

                String[] values = mySU.splitByFixedLengths(input, new int[]{20, 20});
                this.userId = values[0];
                this.password = values[1];

                } catch (Exception e) {
                    Console.Out.WriteLine("" + e.ToString());
                }
            }
        }


    }
}
