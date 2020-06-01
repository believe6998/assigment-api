using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace undefined_shoes_api.Models
{
    public class MyDatabaseContext: DbContext
    {
        public MyDatabaseContext()
            : base("MyConnectionString")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}