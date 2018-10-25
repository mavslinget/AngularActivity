using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    public class Furniture
    {
        public Guid FurnitureID { get; set; }
        public Boolean isAvailable { get; set; }

        public string FurnitureName { get; set; }

        public string FurnitureType { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal UnitStock { get; set; }
        public string Description { get; set; }

        public byte[] FurniturePhoto { get; set; }

    }
}
