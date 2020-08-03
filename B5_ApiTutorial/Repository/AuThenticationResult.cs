using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B5_ApiTutorial.Repository
{
    public class AuThenticationResult
    {
        public string token { get; set; }
        public bool success { get; set; }
        public IEnumerable<string> Error { get; set; }
    }
}
