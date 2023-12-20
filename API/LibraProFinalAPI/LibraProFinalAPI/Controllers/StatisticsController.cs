using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        LibraProFinalDataContext _Context;
        public StatisticsController(LibraProFinalDataContext context)
        {
            _Context = context;
        }


        //for stats
        [HttpGet]
        [Route("getallborrowed")]
        public async Task<IActionResult> Getallborrowed()
        {
            try
            {
                //int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                //if (UserId == null || UserId <= 0)
                //{
                //    return BadRequest("User not logged in");
                //}


                List<Borrow> _book = _Context.Borrows.ToList();
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



        //for stats
        [HttpGet]
        [Route("getallreserved")]
        public async Task<IActionResult> Getallreserved()
        {
            try
            {

                List<Bag> _book = _Context.Bags.Where(u => u.Status == "Reserved").ToList();
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


        ///Function used to get all over due books
        [HttpGet]
        [Route("getoverduebooks")]
        public async Task<IActionResult> GetFine()
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
                     List<Fine> _fine = _Context.Fines.ToList();
                    if (_fine.Count < 0)
                    {
                        return BadRequest("No over due books");

                    }
                    return Ok(_fine);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
