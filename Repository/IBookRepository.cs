using InterviewAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewAPI2.Repository
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(int id);
        public Book PostBook(Book book);

        public Book UpdateBook(Book book);
    }
}
