using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Model
{
    public class UserAuthenticationOptions: AuthenticationSchemeOptions
    {
        public string Item { get; set; }
    }
}
