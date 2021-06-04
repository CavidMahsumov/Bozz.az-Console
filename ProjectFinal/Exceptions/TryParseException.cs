using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Exception1
{
    class TryParseException:ApplicationException
    {
        public TryParseException(string message):base(message)
        {

        }
    }
}
