using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace protocol.utils
{
    class myStringUtils
    {
        public String md5Hex(String cadena)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(cadena);
            bs = md5.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();

        }

        public String[] splitByFixedLengths(String str, int[] lenghts) {
		if (str != null && !str.Equals("") && lenghts != null && lenghts.Length != 0) {
			int sum = 0;
			for (int i = 0; i < lenghts.Length; i++) {
				sum += lenghts[i];
			}

			if (sum == str.Length) {

                String[] values = new String[lenghts.Length];
				int index = 0;
                for (int i = 0; i < lenghts.Length; i++)
                {
					values[i] = str.Substring(index, index = index + lenghts[i]);
				}
				return values;
			} else {
				throw new Exception(
						"La suma de las longitudes ingresadas supera a la longitud de la cadena de caracteres");

			}
		}
		return null;
	}
    }
}
