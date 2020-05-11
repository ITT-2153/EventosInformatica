﻿using EventosInformatica.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Models
{
    public class DataDbContext : DbContext  // Hereda de DbContext  
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        { }
        public DbSet<Client> Clients { get; set; }

    }
}