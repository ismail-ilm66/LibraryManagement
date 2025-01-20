using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class BorrowingController
    {
        private readonly LibraryDbContext _context;

        public BorrowingController()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;")
                .Options;
            _context = new LibraryDbContext(options);
        }

        public void BorrowBook(int memberId, int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null || book.AvailableCopies <= 0)
            {
                throw new Exception("Book is not available.");
            }

            var borrowingRecord = new BorrowingRecord
            {
                MemberId = memberId,
                BookId = bookId,
                BorrowDate = DateTime.Now
            };

            book.AvailableCopies--;
            _context.BorrowingRecords.Add(borrowingRecord);
            _context.SaveChanges();
        }

        public void ReturnBook(int borrowingId)
        {
            var record = _context.BorrowingRecords.Find(borrowingId);
            if (record == null || record.ReturnDate != null)
            {
                throw new Exception("Invalid return operation.");
            }

            record.ReturnDate = DateTime.Now;

            var book = _context.Books.Find(record.BookId);
            if (book != null)
            {
                book.AvailableCopies++;
            }

            _context.SaveChanges();
        }

        // Retrieve all borrowing records with member and book details
        public List<object> GetAllBorrowingRecords()
        {
            return _context.BorrowingRecords
                .Include(br => br.Member)
                .Include(br => br.Book)
                .Select(br => new
                {
                    br.BorrowingRecordId,
                    MemberName = br.Member.Name,
                    BookTitle = br.Book.Title,
                    br.BorrowDate,
                    br.ReturnDate
                })
                .ToList<object>();
        }
    }
}
