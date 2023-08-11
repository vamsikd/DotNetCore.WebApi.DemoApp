﻿using DemoApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.API.Data
{
    public class DemoAppDbContext : DbContext
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options)
            : base(options) 
        {
            
        }

        DbSet<Product> Products { get; set; }
    }
}
