using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class StockNegativoException:Exception
    {
        public StockNegativoException(string mensaje) : base(mensaje)
        {
            
        }
    }
}
