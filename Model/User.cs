using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMBPublic.Model
{
    [Table("WebUsers", Schema = "dbo")]
    public class User
    {
        public int UserID { get; set; }
        public String WebUserID { get; set; }
        public string WebUserPassword { get; set; }
        public string WebUserFullName { get; set; }
        public string WebUserDepartment { get; set; }
        public byte AcceptedAgreements { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public byte IsDeleted { get; set; }

    }
}
