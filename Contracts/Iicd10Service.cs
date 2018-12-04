using FMBPublic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMBPublic.Contracts
{
    public interface Iicd10Service
    {
        List<Icd10SearchResponse> SearchIcd10(Icd10SearchRequest request);
    }
}
