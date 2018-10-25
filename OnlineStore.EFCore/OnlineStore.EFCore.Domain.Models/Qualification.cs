using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    public class Qualification
    {
        [Key]
        public Guid QualificationID { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Boolean IsActive { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

    }
}
