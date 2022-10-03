using InterviewAPI2.DAL;
using InterviewAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewAPI2.Repository
{
    public class BookRepository: IBookRepository
    {
        public readonly BookDBContext _bookDBContext;
        public BookRepository(BookDBContext bookDBContext)
        {
            _bookDBContext = bookDBContext;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> _list = _bookDBContext.Books.Select(e => e).ToList();
            return _list;
        }

        public Book GetBookById(int id)
        {
            Book book = _bookDBContext.Books.Where(e => e.id == id).Select(e => e).FirstOrDefault();
            return book;
        }

        public Book PostBook(Book book)
        {
            _bookDBContext.Books.Add(book);
            _bookDBContext.SaveChanges();
            return _bookDBContext.Books.OrderByDescending(e => e.id).Select(e => e).FirstOrDefault();
        }

        public Book UpdateBook(Book book)
        {
            if(_bookDBContext.Books.Any(e=>e.id==book.id))
            {
                _bookDBContext.Books.Update(book);
                _bookDBContext.SaveChanges();
            }
            return _bookDBContext.Books.Where(e => e.id == book.id).FirstOrDefault();
        }
    }
}
