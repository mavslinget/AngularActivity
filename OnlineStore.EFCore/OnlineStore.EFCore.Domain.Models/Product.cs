using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        [MaxLength(60)]
        [Required]
        public string ProductName { get; set; }
        public Guid SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }
        public Guid CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
        [Required]
        public decimal QuantityPerUnit { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal UnitsInStock { get; set; }
        [Required]
        public decimal UnitsInOrder { get; set; }
        [Required]
        public decimal ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //public string Tags { get; set; }
    }
}
