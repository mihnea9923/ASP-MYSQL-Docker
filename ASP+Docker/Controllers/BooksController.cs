using ASP_Docker.Data;
using ASP_Docker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Docker.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDB _context;
        public BooksController(ApplicationDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
