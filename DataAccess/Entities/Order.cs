﻿using System.Collections.Generic;
using System;

namespace DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double TotalPrice { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
