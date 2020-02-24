using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.MyAirport.EF
{
    public class Vol
    {
        public int VolId { get; set; }

        public string CIE { get; set; }

        public string LIG { get; set; }

        public DateTime DHC { get; set; }

        public string PKG { get; set; }

        public string IMM { get; set; }

        public short PAX { get; set; }

        public string DES { get; set; }

        //public List<Bagage> Bagages { get; set; }

        //Permet de faire vol1.bagages
        // Ne devrait pas changer la base. EF va modifier la REQUETE quand il va chercher l'info, mais la base reste la même.
        // Virtual : Fait la reqûete de jointure seulement si on fait vol1.bagages, permet meilleure opti
        public /*virtual*/ ICollection<Bagage> Bagages { get; set; } 


        /*public Vol(string CIE)
        {
            this.CIE = CIE;
        }*/
    }
}
