using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Controllers
{
    public class BookController
    {
        private readonly LibraryDbContext _context;

        public BookController()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;")
                .Options;
            _context = new LibraryDbContext(options);
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
