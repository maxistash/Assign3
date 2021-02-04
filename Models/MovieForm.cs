using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assign3.Models
{
    public class MovieForm
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1900,2021, ErrorMessage ="Must enter a valid Year")]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string Lent { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
