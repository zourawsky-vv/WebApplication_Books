﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplication_Books.Data;
using WebApplication_Books.Hubs;
using WebApplication_Books.Models;

namespace WebApplication_Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly IHubContext<IndexPageHub> _indexHub;
        private readonly IHubContext<BooksPageHub> _bookHub;

        public BooksController(ApplicationDbContext database, IHubContext<IndexPageHub> indexHub, IHubContext<BooksPageHub> bookHub)
        {
            _database = database;
            _indexHub = indexHub;
            _bookHub = bookHub;
        }
        [HttpGet]
        public IActionResult Books()
        {
            var books = _database.Books.ToList();

            return View(books);
        }

        [HttpGet]
        public IActionResult AddBookView()
        {            
            return View("AddBook");
        }

        [HttpGet]
        public IActionResult ShowEditView (int id)
        {
            var book = _database.Books.FirstOrDefault(b => b.ID == id);
            var model = new BookViewModel
            {
                Title = book.Title,
                Price = decimal.Round( book.Price ),
                Count = book.Count
            };
            return View("EditBook", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook (BookViewModel model)
        {
            var book = await _database.Books.FirstOrDefaultAsync(b => b.ID == model.ID);

            if (book != null)
            {
                book.Title = model.Title;
                book.Price = model.Price;
                book.Count = model.Count;

                _database.Books.Update(book);
                await _database.SaveChangesAsync();

                //List<BookCount> booksCount = new List<BookCount>();
                //foreach (var item in _database.Books.ToList())
                //{
                //    booksCount.Add(new BookCount
                //    {
                //        ID = item.ID,
                //        Count = item.Count
                //    });
                //}
                //await _bookHub.Clients.All.SendAsync("CountPerBook", booksCount);

                var editBook = new Book
                {
                    ID = model.ID,
                    Title = model.Title,
                    Price = model.Price,
                    Count = model.Count
                };
                await _bookHub.Clients.All.SendAsync("EditBook", editBook);

                return RedirectToAction("Books", "Books");
            }
            
            return View("Error", model);
        }

        [HttpGet]
        public IActionResult ShowInfo(int id)
        {
            var book = _database.Books.FirstOrDefault(b => b.ID == id);
            var model = new BookViewModel
            {
                Title = book.Title,
                Price = book.Price,
                Count = book.Count
            };
            return View("ShowInfo", model);
        }

        [HttpGet]
        public IActionResult ShowDeleteBook(int id)
        {
            var book = _database.Books.FirstOrDefault(b => b.ID == id);
            var model = new BookViewModel
            {
                Title = book.Title,
                Price = decimal.Round( book.Price ),
                Count = book.Count
            };
            return View("ConfirmDelete", model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookViewModel model)
        {
            var book = await _database.Books.FirstOrDefaultAsync(b => b.ID == model.ID);

            if (book != null)
            {
                book.Title = model.Title;
                book.Price = model.Price;
                book.Count = model.Count;

                _database.Books.Remove(book);
                await _database.SaveChangesAsync();
                await _indexHub.Clients.All.SendAsync("SendBooksCount", _database.Books.ToList().Count);

                return RedirectToAction("Books", "Books");
            }

            return View("Error", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Price = model.Price,
                Count = model.Count
            };

            await _database.Books.AddAsync(book);
            await _database.SaveChangesAsync();
            await _indexHub.Clients.All.SendAsync("SendBooksCount", _database.Books.ToList().Count);

            return RedirectToAction("Books", "Books");
        }
    }
}
