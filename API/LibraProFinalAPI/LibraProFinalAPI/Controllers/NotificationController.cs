using LibraProFinalAPI.dto;
using LibraProFinalAPI.Model;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class NotificationController : ControllerBase
    {
        private readonly LibraProFinalDataContext _DataContext;

        public NotificationController(LibraProFinalDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        //Function used to create a notification when books return date is 2 days near 
        [HttpPost]
        [Route("duedatenotification")]
        public async Task<IActionResult> CreateNotification()
        {
            try
            {
                DateTime currentDate = DateTime.Today;

                // Find Books that are due in 2 days
                var checkDueDate = _DataContext.Checkouts
                    .Where(d => EF.Functions.DateDiffDay(currentDate, d.BorrowReturnedDate) >= 2)
                    .ToList(); // Fetch the data from the database

                // Create a list to store the notifications
                var notifications = new List<Notification>();

                foreach (var bookDue in checkDueDate)
                {
                    var createNotif = new Notification
                    {
                        NotificationTitle = "Reminder",
                        NotificationDetails = $"Book :{bookDue.BookTitle} under this Borrow Code: {bookDue.BorrowCode} are due in 2 days on {bookDue.BorrowReturnedDate.ToShortDateString()}",
                        NotificationDate = DateTime.Now,
                        UserId = bookDue.UserId,
                        Status = "sent"
                    };

                    notifications.Add(createNotif);
                }

                // Bulk insert the notifications into the database
                _DataContext.Notifications.AddRange(notifications);
                _DataContext.SaveChanges();

                return Ok("Notifications created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> CreateNotification([FromBody] Notification model)
        //{
        //    try
        //    {
        //        if (model == null)
        //        {
        //            return BadRequest("Please provide notification details");
        //        }

        //        // Assuming you have a User and Book model in your application

        //        var user = _DataContext.Users.FirstOrDefault(u => u.UserId == model.UserId);

        //        if (user == null)
        //        {
        //            return NotFound("User or book not found");
        //        }

        //        if (model.DaysUntilDue > 0)
        //        {
        //            // Calculate due date and create a notification
        //            var dueDate = DateTime.Now.AddDays(model.DaysUntilDue);
        //            var notification = new Notification
        //            {
        //                UserId = model.UserId,
        //                NotificationDetails = $"The book '{book.Title}' is due on {dueDate.ToShortDateString()}.",
        //                NotificationDate = DateTime.Now
        //            };

        //            _DataContext.Notifications.Add(notification);
        //        }
        //        else if (model.FineAmount > 0)
        //        {
        //            // Calculate fine and create a notification
        //            var fine = model.FineAmount;
        //            var notification = new Notification
        //            {
        //                UserId = model.UserId,
        //                NotificationDetails = $"You have a fine of ${fine} for the book '{book.Title}' (overdue).",
        //                NotificationDate = DateTime.Now
        //            };

        //            _DataContext.Notifications.Add(notification);

        //            // Optionally, log the fine in a separate Fines table
        //            var fineRecord = new Fine
        //            {
        //                UserId = model.UserId,
        //                BookId = model.BookId,
        //                FineAmount = fine,
        //                FineDate = DateTime.Now
        //            };

        //            _DataContext.Fines.Add(fineRecord);
        //        }

        //        await _DataContext.SaveChangesAsync();

        //        return Ok(new { message = "Notification created successfully" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        //Send notification to users 
        [HttpPost]
        [Route("sendnotification")]
        public async Task<IActionResult> Sendnotification([FromBody] SendNotification notifyuser)
        {
            try
            {
                if(notifyuser == null)
                {
                    return BadRequest("Please enter notification details");
                }

                var sendnotification = new Notification();

                sendnotification.NotificationDetails = notifyuser.NotificationDetails;
                sendnotification.NotificationDate = DateTime.UtcNow;
                sendnotification.UserId = notifyuser.UserId;

                _DataContext.Notifications.Add(sendnotification);
                await _DataContext.SaveChangesAsync();

                return Ok(new {message = "Notification sent to user"});

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //User get their notifications
        [HttpGet]
        [Route("usernotification")]
        public async Task<IActionResult> Getnotifications()
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }

                List<Notification> _notific = _DataContext.Notifications.Where(u => u.UserId == UserId).ToList();
                if(_notific.Count <= 0) 
                {
                    return BadRequest("User has no notifications");
                    
                }
                return Ok(_notific);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteNotification/{id}")]
        public async Task<IActionResult> Deletenotification(int id)
        {
            var delNot = await _DataContext.Notifications.FindAsync(id);

            if (delNot == null)
            {
                return BadRequest("User not found");

            }
            _DataContext.Notifications.Remove(delNot);
            await _DataContext.SaveChangesAsync();

            return Ok(new { message = "Notification has been deleted" });
        }


        ///Funcrtion used to edit notification status
        [HttpPut]
        [Route("editnotifstatus")]
        public async Task<IActionResult> Editnotification([FromBody] EditNotificationdto notific)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                var notification = await _DataContext.Notifications.FindAsync(notific.NotificationId);

                var Status = "Read";
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }

                notification.UserId = UserId;
                notification.Status = Status;

                await _DataContext.SaveChangesAsync();

                return Ok(new { message = " successful updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Function used to count sent notification
        [HttpGet]
        [Route("Countnotifications")]
        public async Task<IActionResult> Countnotifications()
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
                if (UserId == null || UserId <= 0)
                {
                    return BadRequest("User not logged in");
                }

                string _Status = "sent";
                int countnot = await _DataContext.Notifications.Where(u => u.UserId == UserId && u.Status == _Status).CountAsync();

                if (countnot <= 0)
                {
                    return Ok("User has no notifications");
                }
                return Ok(countnot);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Function used to Reminder user about the book they reserverd that is now available
        [HttpPost]
        [Route("reservereminder")]
        public async Task<IActionResult> ReservedBookReminder()
        {
            try
            {
                //Get reserved books
                var _Checkreservedbooks = _DataContext.Bags.Where(u => u.Status == "Reserved").FirstOrDefault();


                if (_Checkreservedbooks == null)
                {
                    return NotFound();
                }

                //Check reserved books if they are now available
                var _CheckAvailabity = _DataContext.Books.Where(u => u.BookId == _Checkreservedbooks.BookId && u.BookQuantity > 0).ToList();

                if (_CheckAvailabity == null)
                {
                    return NotFound();
                }


                foreach (var duebook in _CheckAvailabity)
                {
                    var createNotif = new Notification
                    {
                        NotificationTitle = "Reminder",
                        NotificationDetails = $"{duebook.BookTitle} book is now available you can now borrrow it.",
                        NotificationDate = DateTime.Now,
                        UserId = _Checkreservedbooks.UserId,
                        Status = "sent"
                    };

                    _DataContext.Notifications.Add(createNotif);
                    _DataContext.Bags.Remove(_Checkreservedbooks);
                }

                _DataContext.SaveChanges();
                return Ok("Notifications created");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
