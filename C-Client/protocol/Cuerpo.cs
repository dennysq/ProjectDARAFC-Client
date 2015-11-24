using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protocol
{
    public interface Cuerpo
    {
        

	      String asTexto();

          Boolean validate(String input);

          void build(String input);
    }
}
