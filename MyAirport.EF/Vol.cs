using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FLS.MyAirport.EF
{
    /// <summary>
    /// Classe Vol représentant une instance de vol
    /// </summary>
    public class Vol
    {
        /// <summary>
        /// Cles primaire de ma classe Vol
        /// </summary>
        public int VolId { get; set; }

        /// <summary>
        /// Compagnie du vol
        /// </summary>
        [Display(Name = "Compagnie")]
        public string CIE { get; set; }
        /// <summary>
        /// Numéro de ligne
        /// </summary>
        [Display(Name = "Ligne")]
        public string LIG { get; set; }
        /// <summary>
        /// Dernier horaire connu, horaire de départ du vol
        /// </summary>
        [Display(Name = "Dernier Horaire Connu")]
        public DateTime DHC { get; set; }
        /// <summary>
        /// Parking affecté au vol
        /// </summary>
        [Display(Name = "Parking")]
        public string? PKG { get; set; }
        /// <summary>
        /// Numéro d'immatriculation de l'avion
        /// </summary>
        [Display(Name = "Immatriculation")]
        public string? IMM { get; set; }
        /// <summary>
        /// Nombre de passagers 
        /// </summary>
        [Display(Name = "Passagers")]
        public short? PAX { get; set; }
        /// <summary>
        /// Ville de destination finale du vol
        /// </summary>
        [Display(Name = "Destination")]
        public string? DES { get; set; }

        //public List<Bagage> Bagages { get; set; }

        //Permet de faire vol1.bagages
        // Ne devrait pas changer la base. EF va modifier la REQUETE quand il va chercher l'info, mais la base reste la même.
        // Virtual : Fait la reqûete de jointure seulement si on fait vol1.bagages, permet meilleure opti
        /// <summary>
        /// Propriété de navigation 
        /// </summary>
        public /*virtual*/ IEnumerable<Bagage>? Bagages { get; set; }

        /// <summary>
        /// Constructeur d'une instance Vol
        /// </summary>
        /// <param name="CIE">Nom d'un char de la doc</param>
        /// <param name="LIG"></param>
        /// <param name="DHC"></param>
        /*public Vol(String CIE, String LIG, DateTime DHC) : base()
        {
            this.LIG = LIG;
            this.CIE = CIE;
            this.DHC = DHC;
            Bagages = null; 
        }*/

        /*public Vol(string CIE, string LIG, DateTime DHC, string PKG, string IMM, short PAX, string DES )
        {
            base(CIE, LIG, DHC);
            Bagages = null;
        }*/
        public Vol() { }

    }
}
