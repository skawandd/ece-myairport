using System;
using System.Linq;

using FLS.MyAirport.EF;

namespace FLS.MyAirport.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            using (var db = new MyAirportContext())
            {
                Bagage b1 = new Bagage { CodeIata = "1234567890" };
                Bagage b2 = new Bagage { CodeIata = "1234567890"/*, Poids = 4 */};

                Vol v1 = new Vol { CIE = "LH",
                    DHC = Convert.ToDateTime("14/01/2020 16:45"),
                    LIG = "42384",
                    PKG = "53R",
                    Bagages = new System.Collections.Generic.List<Bagage> { b1, b2 }
                };
                Vol v2 = new Vol
                {
                    CIE = "SQ",
                    DHC = Convert.ToDateTime("14/01/2020 12:15"),
                    LIG = "333",
                    PKG = "78R"
                };
                db.Vols.Add(v1);
                db.Vols.Add(v2);

                db.SaveChanges();

                using (var context = new MyAirportContext())
                {
                    var vols = context.Vols.ToList().First();
                    Console.WriteLine(vols.CIE.ToString());
                }


            }
                
        }
    }
}
