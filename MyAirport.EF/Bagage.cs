using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FLS.MyAirport.EF
{
    public class Bagage
    {
        [Key]
        public int BagageID { get; set; }
//        [ForeignKey("VolId")]
        public int? VolID { get; set; }
        [Column(TypeName = "char(12)")]
        public string CodeIata { get; set; }

        public DateTime DateCreation { get; set; }

        public string Classe { get; set; }
        public bool Prioritaire { get; set; }

        public string STA { get; set; }

        public string SSUR { get; set; }

        public string Destination { get; set; }

        public string Escale { get; set; }
    }
}
