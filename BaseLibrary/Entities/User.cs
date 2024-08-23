using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class User
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; } = string.Empty;
        [Required(ErrorMessage = "username is required")]
        [MinLength(6)]
        public string username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]        
        public string email { get; set; } = string.Empty;
        [Required]
        public string phone { get; set; } = string.Empty;
        public string website { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;

    }
}
