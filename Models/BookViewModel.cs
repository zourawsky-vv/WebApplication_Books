﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Books.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}