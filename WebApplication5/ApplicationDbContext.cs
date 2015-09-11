using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5
{
    using System.Data.Entity;
    using Entities;

    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}