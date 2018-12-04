using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMBPublic.Model
{
    public class NPISearchRequest
    {
        public string LastName_E { get; set; }
        public string FirstName { get; set; }
        public string State { get; set; }
        public long NPI { get; set; }
    }
}
