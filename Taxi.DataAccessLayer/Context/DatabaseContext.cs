﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.DataAccessLayer.Context
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { 

        }


        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Driver> Drivers{ get; set; }
        public DbSet<Car>Cars{ get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        
    }
}
