using FMBPublic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMBPublic.Services
{
    public interface INPIService
    {
        List<NPISearchResult> SearchNPI(NPISearchRequest request);
    }
}
