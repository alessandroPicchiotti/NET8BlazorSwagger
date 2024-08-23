using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaCube.Models
{
    public class baseModel
    {
        [Key]
        [MaxLength(12, ErrorMessage = "Lughezza maassima 12")]
        [MinLength(2, ErrorMessage = "Lunghezza minima 2")]
        public string codditt { get; set; } = "PROVA";
    }
}