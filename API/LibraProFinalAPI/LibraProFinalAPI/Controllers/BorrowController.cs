using LibraProFinalAPI.dto;
using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class BorrowController : ControllerBase
    {
        //Variable for connecting database
        private readonly LibraProFinalDataContext _Context;

        public BorrowController(LibraProFinalDataContext context)
        {
            _Context = context;
        }

        //Function used to checkout books from Bag
        [HttpPost]
        [Route("borrowbook")]
        public async Task<IActionResult> BorrowBook()
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }
                else
                {
                    var BorrowStatus = "Pending Book";
                    int PendingBooks = _Context.Borrows.Where(u => u.UserId == UserId && u.Status == BorrowStatus).Count();
                    if (PendingBooks > 0)
                    {
                        return BadRequest("Please return borrowed books first");
                    }

                    var _Status = "Checked out";
                    int countbooks = _Context.Checkouts.Where(u => u.UserId == UserId && u.Status == _Status).Count();
                    if (countbooks > 0)
                    {
                        return BadRequest("Please return borrowed books first");
                    }

                    List<Bag> _bag = _Context.Bags.Where(u => u.UserId == UserId && u.Status == "Active").ToList();

                    // Loop through each book in the bag
                    var BorrowCode = GenerateUniqueBorrowCode();
                    //DateTime _borrowdate = DateTime.Now;
                    //DateTime _borrowreturndate = DateTime.Now.AddDays(10);

                    foreach (var bagitem in _bag)
                    {
                        var newborrow = new Borrow();

                        //newborrow.BorrowDate = _borrowdate;
                        //newborrow.BorrowReturnedDate = _borrowreturndate;
                        newborrow.BorrowCode = BorrowCode;
                        newborrow.UserId = UserId;
                        newborrow.BookTitle = bagitem.BookTitle;
                        newborrow.BookAuthor = bagitem.BookAuthor;
                        newborrow.BookImage = bagitem.BookImage;
                        newborrow.BookId = bagitem.BookId;
                        newborrow.CategoryId = bagitem.CategoryId;
                        newborrow.CategoryName = bagitem.CategoryName;
                        newborrow.BagId = bagitem.BagId;
                        newborrow.Status = "Pending Book";

                        UpdateBag(newborrow.BagId);

                        //Decrement Book Quantity
                        Updatequantity(newborrow.BookId);
                       
                        _Context.Borrows.Add(newborrow);
                        await _Context.SaveChangesAsync();
                        
                    }

                    return Ok(new { BorrowCode });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Method to update the book status after being borrowed
        [NonAction]
        public string UpdateBag(int id)
        {
            int numb;
            // var decrembookQ = new Book();
            var user = _Context.Bags.Where(u => u.BagId == id).FirstOrDefault();
            if (user != null)
            {
                user.Status = "InActive";

                // _Context.Books.Update(decrembookQ);
                //_Context.SaveChangesAsync();

            }
            return user.Status;
        }


        // Method to update the quantity of the book
        [NonAction]
        public int Updatequantity(int id)
        {

            // var decrembookQ = new Book();
            var user = _Context.Books.Where(u => u.BookId == id).FirstOrDefault();
            if (user != null)
            {
                user.BookQuantity = user.BookQuantity - 1;

                // _Context.Books.Update(decrembookQ);
                //_Context.SaveChangesAsync();

            }


            return user.BookQuantity;
        }


        //Function used to get borrowed books by BorrowCode which are still pending
        [HttpGet]
        [Route("getallborrowedbooks")]
        public async Task<IActionResult> Getallborrowedbooks()
        {
            try
            {
                //int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                //if (UserId == null || UserId <= 0)
                //{
                //    return BadRequest("User not logged in");
                //}

                string _Status = "Pending Book";
                List<Borrow> _book = _Context.Borrows.Where(b => b.Status == _Status).ToList();
                if (_book != null)
                {
                    //int pendingbooks = _Context.Borrows.Where(s => s.Status == _Status).Count();
                    return Ok(_book);
                }
                return BadRequest("No books has been added to Bag");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //Function used to get books from by BorrowCode
        [HttpGet]
        [Route("userborrowedbooks")]
        public async Task<IActionResult> Userborrowedbooks()
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }
                string[] statuses = { "Pending Book", "Checked Out" };
                List<Borrow> userBooks = _Context.Borrows.Where(b => statuses.Contains(b.Status) && b.UserId == UserId).ToList();

                if (userBooks.Count > 0)
                {
                    return Ok(userBooks);
                }
                return BadRequest("No books are currently borrowed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //Functions used to generate a code      
        [NonAction]
        private string GenerateUniqueBorrowCode()
        {
            string newBorrowCode = string.Empty;
            Random rand = new Random();

            bool isDuplicate = true;

            while (isDuplicate)
            {
                var stringBuilder = new StringBuilder();

                for (int i = 0; i < 2; i++)
                {
                    char randChar = (char)rand.Next('A', 'Z');
                    char randChar1 = (char)rand.Next('A', 'Z');
                    int randNum = rand.Next(1, 9);

                    stringBuilder.Append(randChar);
                    stringBuilder.Append(randChar1);
                    stringBuilder.Append(randNum);
                }

                newBorrowCode = stringBuilder.ToString();

                isDuplicate = _Context.Borrows.Any(b => b.BorrowCode == newBorrowCode);
            }

            return newBorrowCode;
        }

     //Edit borrow details
        [HttpPut]
        [Route("updateStatus")]
        public async Task<ActionResult> Updatebook([FromBody] UpdateStatus update)
        {


            var dbu = await _Context.Borrows.FindAsync(update.BorrowId);

            dbu.Status = update.Status;

            //_DataContext.Books.Update(dbu);
            await _Context.SaveChangesAsync();

            return Ok(new { message = "Status successful updated" });
        }

        //Function used to get all checked in books
        [HttpGet]
        [Route("getallcheckdInbooks")]
        public IActionResult GetallcheckedInbooks()
        {
            try
            {


                string _Status = "Checked In";
                List<Borrow> _book = _Context.Borrows.Where(b => b.Status == _Status).ToList();
                if (_book != null)
                {
                    return Ok(_book);
                }
                return BadRequest("No books checked in");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    }
