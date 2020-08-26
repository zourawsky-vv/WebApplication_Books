using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Books.Models;

namespace WebApplication_Books.Controllers
{
    public class BooksController : Controller
    {
        private List<Book> books;

        public BooksController() => books = new List<Book>
            {
                new Book {Title = "Book 1", Price = 100, Count = 09},
                new Book {Title = "Book 2", Price = 200, Count = 11}
            };
        public IActionResult Books()
        {
            return View(books);
        }
    }
}
