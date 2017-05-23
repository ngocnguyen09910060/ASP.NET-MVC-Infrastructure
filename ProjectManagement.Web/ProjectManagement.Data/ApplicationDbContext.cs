using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        { }

        public DbSet<Project> Projects { get; set; }
    }
}
