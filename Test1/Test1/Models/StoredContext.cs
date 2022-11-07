using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class StoredContext:DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}