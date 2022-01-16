using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Okussakula.API.Helpers
{
    public class AppSettings
    {
        public string Email { get; set; }
        public string ServerSMTP { get; set; }
        public int PortSMTP { get; set; }
        public string TokenSecret { get; set; }
    }
}
