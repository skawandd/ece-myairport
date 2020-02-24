using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FLS.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
        public DbSet<Bagage> Bagages { get; set; }
        public DbSet<Vol> Vols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=airport.db");
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Airport;Integrated Security=True");
        }
    }
}
