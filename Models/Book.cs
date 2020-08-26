using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Books.Models
{
    public class Book
    {
        public string Title { get; set; }
        public Decimal Price { get; set; }
        public int Count { get; set; }
    }
}
