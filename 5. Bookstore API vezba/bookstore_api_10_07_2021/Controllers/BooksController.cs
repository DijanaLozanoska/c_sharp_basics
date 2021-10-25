using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_api_10_07_2021.Data;
using bookstore_api_10_07_2021.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_api_10_07_2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        private ApplicationDbContext context { get; set; }

        public BooksController(ApplicationDbContext _context)
        {
            context = _context;
        }

        //localhost:5001/api/Books/ByCategoryID/1/5?

        [HttpGet("ByCategoryID/{id}/{count?}")]
        public List<Book> GetBooksByCategoryID(int id, int count)
        {
            // Gets All book with the given category ID
            IQueryable<Book> firstCallData = context.books.Where(b => b.CategoryID == id);
            // Orders the result by the given condition and returns ordered list
            IQueryable<Book> orderedData = firstCallData.OrderBy(b => b.Price);
            if (count > 0)
            {
                // Returns the first 'count' rows of the orderedData and converts them to a list of books
                return orderedData.Take(count).ToList();
            }
            else
            {
                // Returns the all rows of the orderedData and converts them to a list of books
                return orderedData.ToList();
            }
        }


        //localhost:5001/api/AddBook/
        [HttpPost("AddBook")]

        public string AddBook([FromBody] Book _book)
        {
            Book book = context.books.FirstOrDefault(b => b.Title == _book.Title);

            if (book == null)
            {
                context.books.Add(_book);
                context.SaveChanges();
                return String.Format("The book with title '{0}' has been added to db", _book.Title);
            }
            else
            {
                return String.Format("The book with title '{0}' has already been added to db. Try another title!", _book.Title);
            }
        }
    
        [HttpPost]

        public string UpdateBook([FromBody] Book _book)
        {
            Book book = context.books.FirstOrDefault(b => b.BookID == _book.BookID);
            if (book != null)
            {
                context.Entry(book).CurrentValues.SetValues(_book);
                //context.books.Update(_book);
                context.SaveChanges();
                return String.Format("The book with title '{0}' has been updated to db" , _book.Title);
            }
            else
            {
                return String.Format("The book with title '{0}' is not added to the db", _book.Title);
            }
        }

        [HttpDelete("Delete/{id}")]

        public string Delete(int id)
        {
            Book book = context.books.FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return String.Format("The book with title '{0}' is not added to the db", book.Title);
            }
            else
            {
                context.books.Remove(book);
                context.SaveChanges();
                return String.Format("The book with title '{0}' is deleted from the db", book.Title);
            }
        }



    }
}