using Microsoft.EntityFrameworkCore;
using smart_home_backend.Datasource.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace smart_home_backend.Datasource.Context
{
    public class smart_home_backend_context : DbContext
    {
        public DbSet<PersonEntity> Person { get; set; }
        
        public smart_home_backend_context(DbContextOptions<smart_home_backend_context> options) : base(options)
        {

        }

    }
}
