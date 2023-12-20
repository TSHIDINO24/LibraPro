using LibraProFinalAPI.dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using Microsoft.EntityFrameworkCore;

using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Diagnostics;
using LibraProFinalAPI.Model;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class BagController : ControllerBase
    {
        public readonly LibraProFinalDataContext _Context;
        public readonly IConfiguration _Configuration;
        

        public BagController(LibraProFinalDataContext context, IConfiguration configuration)
        {
            _Context = context;
            _Configuration = configuration;
        }


        //Function used to add books to bag
        [HttpPost]
        [Route("addtobag")]
        public async Task<IActionResult> Addtobag([FromBody]AddToBagdto Inbook)
        {

            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }
                else
                {

                    var bookavailable = _Context.Bags.Where(i => i.BookId == Inbook.BookId && i.UserId == UserId && i.Status == "Active").FirstOrDefault();
                    if (bookavailable != null)
                    {
                        return BadRequest("Book already added to bag");
                    }
                    else
                    {
                        var NewBookToBag = new Bag();

                        NewBookToBag.BookId = Inbook.BookId;
                        NewBookToBag.UserId = UserId;
                        NewBookToBag.BookTitle = Inbook.BookTitle;
                        NewBookToBag.BookAuthor = Inbook.BookAuthor;
                        NewBookToBag.BookImage = Inbook.BookImage;
                        NewBookToBag.CategoryId = Inbook.CategoryId;
                        NewBookToBag.CategoryName = Inbook.CategoryName;  
                        NewBookToBag.Status = "Active";
                    
                  
                        _Context.Bags.Add(NewBookToBag);
                        await _Context.SaveChangesAsync();

                        int countbooks = _Context.Bags.Where(i => i.UserId == UserId && i.Status == NewBookToBag.Status).Count();

                        return Ok(countbooks);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Function used to get books from Bag
        [HttpGet]
        [Route("getallbooks")]
        public async Task<IActionResult> Getallbooks()
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }
                string _Status = "Active";
                List<Bag> _book = _Context.Bags.Where(a => a.UserId == UserId && a.Status == _Status).ToList();
                if (_book != null)
                {
                    return Ok(_book);
                }
                return BadRequest("No books has been added to Bag");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //Function used to remove books from bag
        [HttpDelete]
        [Route("removebook/{id}")]
        public async Task<IActionResult> Removebook(int id)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }

                var _removebook = await _Context.Bags.FindAsync(id);

                if (_removebook == null)
                {
                    return BadRequest("Book not found");

                }
                _Context.Bags.Remove(_removebook);
                await _Context.SaveChangesAsync();

                return Ok(new { message = "Book has been deleted" });
            }
             catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Function used to reserve books
        [HttpPost]
        [Route("reservebook")]
        public async Task<IActionResult> ReserveBook([FromBody] AddToBagdto Inbook)
        {

            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }
                else
                {

                    var bookavailable = _Context.Bags.Where(i => i.BookId == Inbook.BookId && i.UserId == UserId && i.Status == "Reserved" +
                    "").FirstOrDefault();
                    if (bookavailable != null)
                    {
                        return BadRequest("Book already reserved");
                    }
                    else
                    {
                        var NewBookToBag = new Bag();

                        NewBookToBag.BookId = Inbook.BookId;
                        NewBookToBag.UserId = UserId;
                        NewBookToBag.BookTitle = Inbook.BookTitle;
                        NewBookToBag.BookAuthor = Inbook.BookAuthor;
                        NewBookToBag.BookImage = Inbook.BookImage;
                        NewBookToBag.CategoryId = Inbook.CategoryId;
                        NewBookToBag.CategoryName = Inbook.CategoryName;
                        NewBookToBag.Status = "Reserved";


                        _Context.Bags.Add(NewBookToBag);
                        await _Context.SaveChangesAsync();

                        int countbooks = _Context.Bags.Where(i => i.UserId == UserId && i.Status == NewBookToBag.Status).Count();

                        return Ok(countbooks);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Function used to get all reserved books by a user
        [HttpGet]
        [Route("userreservedbooks")]
        public async Task<IActionResult> Getreservedbooks()
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }
                string _Status = "Reserved";
                List<Bag> _book = _Context.Bags.Where(a => a.UserId == UserId && a.Status == _Status).ToList();
                if (_book != null)
                {
                    return Ok(_book);
                }
                return BadRequest("No book has been reserved");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
