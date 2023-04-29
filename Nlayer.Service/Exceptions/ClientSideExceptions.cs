using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Exceptions
{
    public class ClientSideExceptions:Exception
    {
        public ClientSideExceptions(string message):base(message) 
        {
           

        }
    }
}
