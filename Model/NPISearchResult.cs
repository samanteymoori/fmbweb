using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMBPublic.Model
{
    public class NPISearchResult
    {
        [Key]
        public long Id { get; set; }

        public decimal NPI { get; set; }
        public string LastNameOrEntity { get; set; }

        public string Prefix { get; set; }

        public string FirstAndMiddle { get; set; }

        public string MailingAddress { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
        public string Taxonomy { get; set; }
        [NotMapped]
        public long NPILong { get { return (long)NPI; } }

    }
}
