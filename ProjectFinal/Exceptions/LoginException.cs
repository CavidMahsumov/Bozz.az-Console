using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Exception1
{
    class LoginException:ApplicationException
    {
        public LoginException(string message):base(message)
        {

        }
    }
}
