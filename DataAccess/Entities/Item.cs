using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Item
    {
        public enum ItemStatus { InStock, Unavailable, Limited }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public int Rating { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        public ItemStatus Status { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
