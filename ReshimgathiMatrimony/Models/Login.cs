using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ReshimgathiMatrimony.Models
{
    public class Login : DbContext
    {
        public DbSet<Login> login { get; set; }
    }
}