using System;
using System.Linq;

using FLS.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FLS.MyAirport.ConsoleApp
{
    class Program
    {
        public static readonly ILoggerFactory MyAirportLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        static void Main(string[] args)
        {
            System.Console.WriteLine("MyAirport project bonjour!!");

            var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Airport;Integrated Security=True");
            optionsBuilder.UseLoggerFactory(MyAirportLoggerFactory);

            using (var db = new MyAirportContext(optionsBuilder.Options))
            {
                // Create
                Console.WriteLine("Création du vol LH1232");
                Vol v1 = new Vol
                {
                    CIE = @"LH",
                    DES = @"BKK",
                    DHC = Convert.ToDateTime("14/01/2020 16:45"),
                    IMM = "RZ62",
                    LIG = "1232",
                    PKG = "R52",
                    PAX = 238
                };
                db.Add(v1);

                Console.WriteLine("Creation vol SQ333");
                Vol v2 = new Vol
                {
                    CIE = "SK",
                    DES = "CDG",
                    DHC = Convert.ToDateTime("14/01/2020 18:20"),
                    IMM = "TG43",
                    LIG = "333",
                    PKG = "R51",
                    PAX = 423
                };
                db.Add(v2);
                db.SaveChanges();

                Console.WriteLine("creation du bagage 012387364501");
                Bagage b1 = new Bagage
                {
                    //VolID = v2.VolId,
                    Classe = "Y",
                    CodeIata = "012387364501",
                    DateCreation = Convert.ToDateTime("14/01/2020 12:52"),
                    Destination = "BEG"
                };
                db.Add(b1);

                db.SaveChanges();
                Console.ReadLine();

                // Read
                Console.WriteLine("Voici la liste des vols disponibles");
                var vol = db.Vols
                    .OrderBy(v => v.CIE);
                foreach (var v in vol)
                {
                    Console.WriteLine($"Le vol {v.CIE}{v.LIG} N° {v.VolId} a destination de {v.DES} part à {v.DHC} heure");
                }
                Console.ReadLine();

                // Update
                //Console.WriteLine($"Le bagage {b1.BagageID} est modifié pour être rattaché au vol {v1.VolId} => {v1.CIE}{v1.LIG}");
                Console.WriteLine($"Le bagage {b1.BagageID} est modifié pour être rattaché au vol {v2.VolId} => {v2.CIE}{v2.LIG}");

                b1.VolID = v2.VolId;
                db.SaveChanges();
                Console.ReadLine();

                // Delete vol et bagages du vol
                Console.WriteLine($"Suppression du vol {v1.VolId} => {v1.CIE}{v1.LIG}");
                db.Remove(v1);
                db.SaveChanges();
                Console.ReadLine();
            }
        }
    }
}
