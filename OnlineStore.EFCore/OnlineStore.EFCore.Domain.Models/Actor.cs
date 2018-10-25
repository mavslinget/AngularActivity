using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Actor")]
    public class Actor
    {
        [Key]
        public Guid ActorID { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public decimal NumberOfFilm { get; set; }
        public string SocialMediaAccount { get; set; }
        [Required]
        public Boolean isActive { get; set; }

    }
}
