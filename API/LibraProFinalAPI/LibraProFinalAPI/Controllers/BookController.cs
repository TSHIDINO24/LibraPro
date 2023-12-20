using LibraProFinalAPI.dto;
using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class BookController : ControllerBase
    {
        //Variable for database connection
        private readonly LibraProFinalDataContext _DataContext;

        public BookController(LibraProFinalDataContext dataContext)
        {
            _DataContext = dataContext;
        }


        //Add a book function
        [HttpPost]
        [Route("addbook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookdto bookdto)
        {
            try
            {
                var book = _DataContext.Books.Where(u => u.BookTitle == bookdto.BookTitle).FirstOrDefault();
                if (book != null)
                {
                    return BadRequest("Book already exists");
                }
                else
                {
                    book = new Book();

                    book.BookTitle = bookdto.BookTitle;
                    book.BookDescription = bookdto.BookDescription;
                    book.BookQuantity = bookdto.BookQuantity;
                    book.BookAuthor = bookdto.BookAuthor;
                    book.BookStatus = "Available";
                    book.BookImage = bookdto.BookImage;
                    book.Isbn = bookdto.ISBN;
                    book.CategoryId = bookdto.CategoryId;
                    book.CategoryName = bookdto.CategoryName;

                    _DataContext.Books.Add(book);
                    await _DataContext.SaveChangesAsync();

                    return Ok("Book added succesfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Get all registered books
        [HttpGet]
        [Route("allbooks")]
        public async Task<IActionResult> Getallbooks()
        {
           
            try
            {

                List<Book> _book = _DataContext.Books.ToList();
                if (_book != null)
                {
                    int allbooks = _DataContext.Books.Count();
                    return Ok( _book );
                }
                return BadRequest("No books has been registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get a book by Title
        [HttpGet]
        [Route("getbooktitle")]
        public async Task<IActionResult> Getbookid(string _BookTitle)
        {
            var _book = _DataContext.Books.Select(t => new
            {
                t.BookId,
                t.BookTitle,
                t.BookDescription,
                t.BookAuthor,
                t.BookStatus,
                t.BookImage,
                category = t.Category.CategoryName,

            }).Where(u => u.BookTitle == _BookTitle).FirstOrDefault();
            if (_book == null)
            {
                return BadRequest("Book does not exist");
            }
            return Ok(_book);
        }

        //Get a book by Title
        [HttpGet]
        [Route("getbookid")]
        public async Task<IActionResult> Getbookid(int id)
        {
            var _book = _DataContext.Books.Select(t => new
            {
                t.BookId,
                t.BookTitle,
                t.BookDescription,
                t.BookAuthor,
                t.BookStatus,
                t.Isbn,
                t.BookImage,
                category = t.Category.CategoryName,

            }).Where(u => u.BookId == id).FirstOrDefault();
            if (_book == null)
            {
                return BadRequest("Book does not exist");
            }
            return Ok(_book);
        }



        //A function that get a list of books based on a category ID,
        [HttpGet]
        [Route("getbooksbycategory")]
        public async Task<IActionResult> GetBooksbyCategory(int Id)
        {
            try
            {
                var books = _DataContext.Books.Select(t => new
                {
                    t.BookId,
                    t.BookTitle,
                    t.BookDescription,
                    t.BookAuthor,
                    t.BookStatus,
                    t.BookQuantity,
                    t.Isbn,
                    t.Category.CategoryName,
                    t.BookImage,                                     
                   category = t.Category.CategoryId,
                }).Where(u => u.category == Id).ToList();
                if (books == null)
                {
                    return BadRequest("No books found in this category");
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Delete Book
        [HttpDelete]
        [Route("deleteuser/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deluser = await _DataContext.Books.FindAsync(id);

            if (deluser == null)
            {
                return BadRequest("Book not found");

            }
            _DataContext.Books.Remove(deluser);
            await _DataContext.SaveChangesAsync();

            return Ok(new { message = "Book has been deleted" });
        }


        //Edit book details
        [HttpPut]
        [Route("editbook")]
        public async Task<ActionResult> Updatebook([FromBody] Bookupdatedto editbook)
        {

            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue("UserID"));
            var dbu = await _DataContext.Books.FindAsync(editbook.BookId);

            if (userid == null || userid <= 0)
            {
                return BadRequest("User not logged in");
            }
            if (dbu == null)
            {
                return BadRequest("Book not found");
            }

            dbu.BookTitle = editbook.BookTitle;
            dbu.BookAuthor = editbook.BookAuthor;
            dbu.BookDescription = editbook.BookDescription;
            dbu.BookStatus = editbook.BookStatus;
            dbu.BookQuantity = editbook.BookQuantity;

            //_DataContext.Books.Update(dbu);
            await _DataContext.SaveChangesAsync();

            return Ok(new { message = "Book successful updated" });
        }
    }
}
