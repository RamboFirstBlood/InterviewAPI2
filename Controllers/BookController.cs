using AutoMapper;
using InterviewAPI2.Models;
using InterviewAPI2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        dynamic config;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger logger;
        public BookController(IBookRepository bookRepository, ILoggerFactory loggerFactory)
        {
            _bookRepository = bookRepository;
            _loggerFactory = loggerFactory;
            logger = loggerFactory.CreateLogger<BookController>();
            config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Book, BookDTO>()
                    .ForMember(dest => dest.BookTitle, act => act.MapFrom(src => src.Name))
                     .ForMember(dest => dest.Author, act => act.MapFrom(src => src.AuthorName))
                );
        }

        [HttpGet("GetBooks")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Index()
        {
            logger.LogInformation("Logging information.");
            try
            {
                return Ok(_bookRepository.GetAllBooks());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet("GetBookById")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Index(int id)
        {
            Book book = new Book();
            try
            {
                book = _bookRepository.GetBookById(id);
                if (book == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var mapper = new Mapper(config);
                var bookDTO = mapper.Map<BookDTO>(book);
                logger.LogInformation("GetBookById requested(id):" + id);
                return StatusCode(StatusCodes.Status200OK, bookDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpPost("PostBook")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Index(Book book)
        {
            Book _book = new Book();
            try
            {
                if (ModelState.IsValid)
                {
                    _book = _bookRepository.PostBook(book);
                    if (_book == null)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            var mapper = new Mapper(config);
            var bookDTO = mapper.Map<BookDTO>(_book);
            return StatusCode(StatusCodes.Status201Created, bookDTO);
        }

        [HttpPut("UpdateBook")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult PutBook(Book book)
        {
            Book _book = new Book();
            try
            {
                if (ModelState.IsValid)
                {
                    _book = _bookRepository.UpdateBook(book);
                    if (_book == null)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Exception occured: "+ex.Message);
            }
            var mapper = new Mapper(config);
            var bookDTO = mapper.Map<BookDTO>(book);
            return Ok(bookDTO);
        }

        
    }
}
