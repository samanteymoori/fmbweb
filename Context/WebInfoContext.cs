using FMBPublic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Context
{
    public class WebInfoContext : DbContext
    {
        public string cs;
        public WebInfoContext(string ConnectionSetting)
        {
            cs = ConnectionSetting;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }



    }
}
