using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Show")]
    public class Show
    {
        [Key]
        public Guid ShowID { get; set; }
        [MaxLength(60)]
        [Required]
        public string Title { get; set; }
        [MaxLength(60)]
        public string AlternativeTitle { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public decimal NumberOfEpisode { get; set; }
        [Required]
        public Boolean IsComplete { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public decimal YearStarted { get; set; }
        [Required]
        public decimal Season { get; set; }

    }
}
