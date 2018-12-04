using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FMBPublic.Model
{
    public class ConnectionSetting
    {
        [Key]
        public int Id { get; set; }

        public String Server { get; set; }

        public String Instance { get; set; }

        public String DataBase { get; set; }

        public bool Integrated { get; set; }

        public String User { get; set; }

        public String Password { get; set; }

        internal string GetConnection()
        {
            if (Integrated)
            {
                return String.Format(@"Data source={0}\{1};initial catalog={2};integrated security=true;",Server,Instance,DataBase);
            }
            else
            {
                return String.Format(@"Data source={0}\{1};initial catalog={2};user={3};password={4}",Server, Instance, DataBase,User,Password);
            }
        }

        public bool UseBulkQuery { get; set; }

    }
}
