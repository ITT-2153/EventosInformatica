using EventosInformatica.Web.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Models
{
    public class DataDbContext : IdentityDbContext<User>  // Hereda de DbContext  
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manager> Managers { get; set; }
        //public DbSet<User> Users { get; set; }

    }
}
