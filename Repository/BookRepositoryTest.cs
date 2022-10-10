using InterviewAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewAPI2.Repository
{
    public class BookRepositoryTest : IBookRepository
    {
        private readonly List<Book> _books;
        public BookRepositoryTest()
        {
            _books = new List<Book>()
            {
                new Book() { id = 1, Name = "The Power of Your Mind", AuthorName = "Joseph Murphy"},
                new Book() { id = 2, Name = "Sri M: The Journey Continues", AuthorName = "Sri M"},
                new Book() { id = 3, Name = "Apprenticed To A Himalayan Master", AuthorName = "Sri M"},
                new Book() { id = 4, Name = "Mukajjiya Kanasugalu", AuthorName = "Shivram Karanth" },
                new Book() { id = 5, Name = "Karvalo", AuthorName = "PoornaChandra Tejasvi" },
                new Book() { id = 6, Name = "AutoBiography of A Yogi", AuthorName = "Paramahamsa Yogananda" },
                new Book() { id = 7, Name = "A Night At A Call Center", AuthorName = "Chetan Bhagat" }
            };
        }
        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
           return _books.Where(a => a.id == id).FirstOrDefault();
        }

        public Book PostBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public Book UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
