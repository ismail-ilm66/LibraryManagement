using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Books
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "C# Programming", Author = "John Doe", Genre = "Programming", ISBN = "1234567890", AvailableCopies = 5 },
                new Book { BookId = 2, Title = "Database Systems", Author = "Jane Doe", Genre = "Database", ISBN = "0987654321", AvailableCopies = 3 }
            );

            // Seed data for Members
            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, Name = "Alice Johnson", MembershipID = "M001", Password = "pass123", PhoneNumber = "1234567890", Address = "123 Main St" },
                new Member { MemberId = 2, Name = "Bob Smith", MembershipID = "M002", Password = "pass456", PhoneNumber = "9876543210", Address = "456 Elm St" }
            );

            // Seed data for BorrowingRecords
            modelBuilder.Entity<BorrowingRecord>().HasData(
                new BorrowingRecord { BorrowingRecordId = 1, MemberId = 1, BookId = 1, BorrowDate = System.DateTime.Now, ReturnDate = null }
            );
        }
    }
}
