using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FLS.MyAirport.EF
{
    /// <summary>
    /// Objet Bagage
    /// </summary>
    public class Bagage
    {
        /// <summary>
        /// Id clé primaire de l'objet bagage
        /// </summary>
        public int BagageID { get; set; }
        
        /// <summary>
        /// Vol associé au bagage
        /// </summary>
        public int? VolID { get; set; }

        /// <summary>
        /// Proprieté de navigation 19h11 20200415
        /// </summary>
        public virtual Vol? Vol { get; set; }

        /// <summary>
        /// CodeIata du bagage, unique à un instant t
        /// </summary>
        [StringLength(16)]
        [Display(Name = "Code IATA")]
        public string CodeIata { get; set; }
        /// <summary>
        /// Date à laquelle le bagage a été crée par la compagnie
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// Classe passager
        /// </summary>
        [Display(Name = "Classe Passager")]
        public string? Classe { get; set; }
        public bool? Prioritaire { get; set; }

        [Display(Name = "Status")]
        public string? STA { get; set; }
        /// <summary>
        /// Indique le status surete du bagage
        /// </summary>
        [Display(Name = "Status Surete")]
        public string? SSUR { get; set; }
        /// <summary>
        /// Destination finale du bagage
        /// </summary>
        public string? Destination { get; set; }
        /// <summary>
        /// Destination pour le vol en cour du bagage
        /// </summary>
        public string? Escale { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Bagage() { }

        /// <summary>
        /// Constructeur prennant en paramètres les champs obligatoires
        /// </summary>
        /// <param name="codeIata">Code Iata du Bagage</param>
        /// <param name="dateCreation">Date et Heure de création du bagage par la compagnie</param>
        public Bagage(string codeIata, DateTime dateCreation)
        {
            CodeIata = codeIata;
            DateCreation = dateCreation;
        }
    }
}
