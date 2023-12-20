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
    public class CheckoutController : ControllerBase
    {
        //Variable for connecting database
        private readonly LibraProFinalDataContext _Context;

        public CheckoutController(LibraProFinalDataContext context)
        {
            _Context = context;
        }

        //Function used to checout books when user comes to collect them
         [HttpPost("checkoutbooks")]
        public IActionResult CheckoutBooks([FromBody] AddToCheckedout checkedout)
        {
            try
            {
                if (checkedout == null)
                {
                    return BadRequest("Invalid input data.");
                }

                var checkoutbook = new Checkout
                {
                    UserId = checkedout.UserId,
                    BookId = checkedout.BookId,
                    BorrowId = checkedout.BorrowId,
                    BorrowCode = checkedout.BorrowCode,
                    BorrowDate = checkedout.BorrowDate,
                    BorrowReturnedDate = checkedout.BorrowReturnedDate,
                    BookTitle = checkedout.BookTitle,
                    BookImage = checkedout.BookImage,
                    BookAuthor = checkedout.BookAuthor,
                    CategoryId = checkedout.CategoryId,
                    CategoryName = checkedout.CategoryName,
                    Status = checkedout.Status
                };

                _Context.Checkouts.Add(checkoutbook);
                _Context.SaveChanges();

                // Use the UpdateBorrowStatus function to update the status of the borrowed book
                //   UpdateBorrowStatus(checkedout.BorrowId, "Checked Out");

                return Ok(new { Message = "Book checked out successfully." });
            }
            catch (Exception ex)
            {
                // Log the inner exception for debugging purposes
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                return BadRequest($"Error checking out book: {ex.Message}");
            }

        }

        // Your existing UpdateBorrowStatus function here
        //[NonAction]
        //public void UpdateBorrowStatus(int borrowid, string newStatus)
        //{
        //    var borrowedBook = _Context.Borrows.FirstOrDefault(b => b.BorrowId ==borrowid);
        //    if (borrowedBook != null)
        //    {
        //        borrowedBook.Status = newStatus;
        //        _Context.SaveChanges();
        //    }
        //}


        //Function used to get all checked out books
        [HttpGet]
        [Route("getallcheckedoutbooks")]
        public async Task<IActionResult> Getallcheckedoutbooks()
        {
            try
            {

                string _Status = "Checked Out";
                List<Checkout> checkedoutbook = _Context.Checkouts.Where(b => b.Status == _Status).ToList();
                if (checkedoutbook != null)
                {
                    int allcheckedout = _Context.Checkouts.Where(c => c.Status == _Status).Count();
                    return Ok( checkedoutbook);
                }
                return BadRequest("No books has been added to Bag");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Edit checkout details
        [HttpPut]
        [Route("updateStatus")]
        public async Task<ActionResult> Updatebook([FromBody] UpdateStatus update)
        {
            try
            {
                if (update == null)
                {
                    return BadRequest("Invalid input data.");
                }

                var checkout = _Context.Checkouts.FirstOrDefault(c => c.BorrowId == update.BorrowId);

                if (checkout == null)
                {
                    return NotFound("Checkout record not found.");
                }

                // Update the status
                checkout.Status = update.Status;
                _Context.SaveChanges();

                return Ok(new { Message = "Status updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating status: {ex.Message}");
            }
        }


            [HttpDelete]
            [Route("checkInbycode/{borrowId}")]
            public async Task<IActionResult> CheckIn(int borrowId)
            {
                try
                {
                    // int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                    //  if (UserId == null || UserId <= 0)
                    //  {
                    // return BadRequest("User not logged in");
                    // }

                    List<Checkout> _bag = _Context.Checkouts.Where(u => u.BorrowId == borrowId).ToList();

                    foreach (var cbook in _bag)
                    {
                        _Context.Checkouts.Remove(cbook);
               
                    }
                    await _Context.SaveChangesAsync();

                    return Ok(new { message = "Book Checked in Successfully!" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


           


        //Function used by ADMIN to check-in borrowed books when user returns them.
        //[HttpPut]
        [HttpDelete]
        [Route("checkInbycode")]
        public async Task<IActionResult> CheckIn(string borrowcode)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }

                List<Checkout> _bag = _Context.Checkouts.Where(u => u.BorrowCode == borrowcode).ToList();

                foreach (var cbook in _bag)
                {
                    _Context.Checkouts.Remove(cbook);
                }
                await _Context.SaveChangesAsync();

                return Ok(new { message = "Book Checked in Successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Function used to checkout books by borrow code
        [HttpPost]
        [Route("checkbyborrowcode")]
        public async Task<IActionResult> CheckoutBooks(string _borrowcode)
        {
            try
            {
                //Check if user has logged in
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }
                else
                {
                    var _pendingbooks = _Context.Borrows.Where(u => u.Status == "Pending Book" && u.BorrowCode == _borrowcode).ToList();

                    //Generating Dates
                    DateTime _borrowdate = DateTime.Now;
                    DateTime _borrowreturndate = DateTime.Now.AddMinutes(10);

                    foreach (var _pendingbook in _pendingbooks)
                    {
                        var checkoutbook = new Checkout();

                        checkoutbook.UserId = _pendingbook.UserId;
                        checkoutbook.BorrowId = _pendingbook.BorrowId;
                        checkoutbook.BookId = _pendingbook.BookId;
                        checkoutbook.BorrowCode = _pendingbook.BorrowCode;
                        checkoutbook.BorrowDate = _borrowdate;
                        checkoutbook.BorrowReturnedDate = _borrowreturndate;
                        checkoutbook.BookAuthor = _pendingbook.BookAuthor;
                        checkoutbook.BookTitle = _pendingbook.BookTitle;
                        checkoutbook.BookImage = _pendingbook.BookImage;
                        checkoutbook.Status = "Checked Out";

                        //Updating the book borrowed after being checked out
                        UpdateBorrowStatus(checkoutbook.BorrowId);

                        //Updating borrow date and due date under borrow table
                        UpdateDates(checkoutbook.BorrowId, _borrowdate, _borrowdate);

                        _Context.Checkouts.Add(checkoutbook);
                    }
                    _Context.SaveChanges();

                    return Ok("Success");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Method to update the borrowed status after being checked out by the librarian
        [NonAction]
        public string UpdateBorrowStatus(int id)
        {
            int numb;
            // var decrembookQ = new Book();
            var _borrowstatus = _Context.Borrows.Where(u => u.BorrowId == id).FirstOrDefault();
            if (_borrowstatus != null)
            {
                _borrowstatus.Status = "Checked Out";

                // _Context.Books.Update(decrembookQ);
                //_Context.SaveChangesAsync();

            }
            return _borrowstatus.Status;
        }


        //Update Borrow and Due date after Books are checked out
        [NonAction]
        public void UpdateDates(int ID, DateTime _borrowdate, DateTime _duedate)
        {
            var _updatedates = _Context.Borrows.Where(u => u.BorrowId == ID).FirstOrDefault();

            if (_updatedates != null)
            {
                _updatedates.BorrowDate = _borrowdate;
                _updatedates.BorrowReturnedDate = _duedate;
            }
        }
    }
 }

