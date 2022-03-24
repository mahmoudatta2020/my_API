using System;
using System.Collections.Generic;

namespace my_API.Models
{
    public partial class Books1
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Auther { get; set; }
        public decimal BookPrice { get; set; }
        public int Quantity { get; set; }
    }
}
