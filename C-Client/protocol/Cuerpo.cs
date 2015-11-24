using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    interface Cuerpo
    {
        public static char FIELD_SEPARATOR_CHAR='|';

	    public String asTexto();

	    public Boolean validate(String input);

	    public void build(String input);
    }
}
