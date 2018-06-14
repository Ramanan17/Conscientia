using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dhanak.Models;
using Microsoft.EntityFrameworkCore;

namespace Dhanak.Persistence
{
    public class DhanakDbContext:DbContext
    {
        public DhanakDbContext(DbContextOptions<DhanakDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<EventRegistration> Registration { get; set; } 
    }
}
