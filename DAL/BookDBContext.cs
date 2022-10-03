using InterviewAPI2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewAPI2.DAL
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book() { id = 1, Name = "The Power of Your Mind", AuthorName = "Joseph Murphy"},
                new Book() { id = 2, Name = "Sri M: The Journey Continues", AuthorName = "Sri M"},
                new Book() { id = 3, Name = "Apprenticed To A Himalayan Master", AuthorName = "Sri M"},
                new Book() { id = 4, Name = "Mukajjiya Kanasugalu", AuthorName = "Shivram Karanth" },
                new Book() { id = 5, Name = "Karvalo", AuthorName = "PoornaChandra Tejasvi" },
                new Book() { id = 6, Name = "AutoBiography of A Yogi", AuthorName = "Paramahamsa Yogananda" },
                new Book() { id = 7, Name = "A Night At A Call Center", AuthorName = "Chetan Bhagat" }
                );
        }

        public DbSet<Book> Books { get; set; }
    }
}
