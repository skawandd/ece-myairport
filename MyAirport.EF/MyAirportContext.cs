﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace FLS.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
        //https://docs.microsoft.com/fr-fr/ef/core/miscellaneous/logging?tabs=v3
        public static readonly ILoggerFactory MyAirportLoggerFactory 
            = LoggerFactory.Create(builder => { builder.AddConsole(); }); // Simple factory , il faut créer le logger 

        // https://docs.microsoft.com/fr-fr/ef/core/miscellaneous/logging?tabs=v3
        //Créer mon propre logger dédié pour y balancer du log 


        public DbSet<Bagage> Bagages { get; set; }
        public DbSet<Vol> Vols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=airport.db");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Airport;Integrated Security=True");
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportDatabase"].ConnectionString);

            //Pas logique que lui aille chercher l'option dans le fichier de conf... étape d'après
            // Pas logique que le connecteur sur la bdd ait la charge d'aller chercher la chaine de connection
            optionsBuilder.UseLoggerFactory(MyAirportLoggerFactory); // Utiise la factory pour gérer tes logs. Utilise une instance de ILogger
        }
    }
}
