using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace WaCube.Models
{

    public class Articoli : baseModel
    {

        [Key]
        [MaxLength(50, ErrorMessage = "Lughezza maassima 50")]
        [MinLength(2, ErrorMessage = "Lunghezza minima 2")]
        [Required]
        public string ar_codart { get; set; } = string.Empty;
        [Required]
        [MaxLength(255, ErrorMessage = "Lughezza massima 255")]
        public string ar_descr { get; set; } = string.Empty;
        [MaxLength(3, ErrorMessage = "Lughezza massima 255")]
        [Required]
        public string ar_unmis { get; set; }= "NR";
        public Int16? ar_codiva { get; set; } = 0;
        public Int16 ar_gruppo { get; set; }=0;
        //public int ar_sotgru { get; set; }
        public string ar_famprod { get; set; } = " ";
        //public decimal? prezzo { get; set; }
        public Int16 ar_codmarc { get; set; } = 0;
        public Int16 ar_codtipa { get; set; } = 0;

        public decimal ar_pesolor {get; set;} = 0;
        public decimal ar_pesonet { get; set; }=0;
        public string ? ar_confez2 { get; set; } 
        public decimal  ar_qtacon2 { get; set; } = 1;
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ar_datins { get; set; }

        //public virtual Marche marca{get;set;}
        //[JsonIgnore]

        //public virtual Gruppi gruppo { get; set; }
        //public virtual Sgruppi sgruppo { get; set; }
        
        //public virtual Accessori accessorio { get; set; }

      

        [NotMapped]
        public decimal prezzo { get; set; }
    }
}