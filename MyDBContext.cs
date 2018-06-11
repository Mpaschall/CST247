using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace YellowGroupCST247.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; } 
    }
}