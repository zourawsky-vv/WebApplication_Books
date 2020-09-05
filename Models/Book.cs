using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Books.Models
{
    public class BookCount
    {
        public int ID { get; set; }
        public int Count { get; set; }
    }
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
