using LibraProFinalAPI.dto;
using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class UserController : ControllerBase
    {
        private readonly LibraProFinalDataContext _Context;

        private readonly IConfiguration _Configuration;
        public UserController(LibraProFinalDataContext context, IConfiguration configuration)
        {
            _Context = context;
            _Configuration = configuration;
        }

        //User registeration function
        [HttpPost]
        [Route("userregister")]
        public async Task<IActionResult> UserRegister([FromBody] Userregisterdto user)
        {
            try
            {
                //if (!IsValidID(user.UserIDNumber))
                //{
                //    return BadRequest("ID Number is Invalid");
                //}

                    var db = _Context.Users.Where(a => a.UserEmail == user.UserEmail || a.UserIdnumber == user.UserIDNumber).FirstOrDefault();
                    if (db != null)
                    {
                        return BadRequest("User already exists");
                    }
                    var newuser = new User();

                    newuser.UserName = user.UserName;
                    newuser.UserSurname = user.UserSurname;
                    newuser.UserIdnumber = user.UserIDNumber;
                    newuser.UserEmail = user.UserEmail;
                    newuser.UserAddress = user.UserAddress;
                    newuser.UserPhone = user.UserPhone;
                    newuser.UserType = "GENERAL";
                    newuser.UserPassword = user.UserPassword;
                    newuser.UserStatus = "Available";
                    newuser.UserCreatedDate = DateTime.Now;

                    _Context.Users.Add(newuser);

                    await _Context.SaveChangesAsync();

                    return Ok(newuser);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Web login function 
        [HttpPost]
        [Route("weblogin")]
        public async Task<IActionResult> Weblogin([FromBody] Userlogindto user)
        {
            try
            {
                var db = _Context.Users.FirstOrDefault(a => a.UserEmail == user.UserEmail && user.UserPassword == user.UserPassword);
            
                if(db == null)
                {
                    return BadRequest("Username or Password is incorrect!");
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.UserEmail),
                        new Claim("UserType", db.UserType),
                        new Claim("userID",db.UserId.ToString())
                    };


                    var token = this.GetToken(claims);

                    if(db.UserType == "ADMIN")
                    {
                        return Ok(new
                        {
                            Message = "Admin user successfully logged in",
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expiration = token.ValidTo,
                            RedirectUrl = "AdminWeb/index.html"
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            Message = "General user successfully logged in",
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expiration = token.ValidTo,
                            RedirectUrl = "Home.html"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //User login function
        [HttpPost]
        [Route("userlogin")]
        public async Task<IActionResult> UserLogin([FromBody] Userlogindto login)
        {
            try
            {
                var db = _Context.Users.Where(a => a.UserEmail == login.UserEmail && a.UserPassword == login.UserPassword).FirstOrDefault();
                if (db == null)
                {
                    return BadRequest("Username or Password is incorrect");
                }
                //return Ok("User succesfully logged in");
                else
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, db.UserEmail),
                        new Claim("UserType",db.UserType),
                        new Claim("userID",db.UserId.ToString())

                    };

                   var token = this.GetToken(claims);

                   return Ok(new 
                   { 
                        Message = "User successfully logged",

                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo

                  });
                }



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Website login function 
        //[HttpPost]
        //[Route("adminlogin")]
        //public async Task<IActionResult> Adminlogin([FromBody] Adminlogindto adminlogin)
        //{
        //    try
        //    {
        //        var db = _Context.Users.Where(u => u.UserEmail == adminlogin.UserEmail &&
        //        u.UserPassword == adminlogin.UserPassword && u.User).FirstOrDefault();
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //Get all registered users
        [HttpGet]
        [Route("getallusers")]

        public async Task<IActionResult> Getallusers()
        {
            try
            {
                List<User> listuser = _Context.Users.ToList();
                {
                    if (listuser != null)
                    {
                        //int getallusers = _Context.Users.Count();
                        return Ok(listuser);
                    }
                    
                    return Ok("No user registered");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get all users by descending order and status is Available
        [HttpGet]
        [Route("getuserstatus")]
        public async Task<IActionResult> Getallusersdescending()
        {
            try
            {
                List<User> listuser = _Context.Users.Where(u => u.UserStatus == "Available").OrderByDescending(t => t.UserId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);

                }
                return Ok("No Users in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Get all users by descending order and block status is blocked
        [HttpGet]
        [Route("getallblockedusers")]
        public async Task<IActionResult> Getallblockedusers()
        {
            try
            {
                List<User> listuser = _Context.Users.Where(u => u.UserStatus == "Block").OrderByDescending(t => t.UserId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);

                }
                return Ok("No users in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get User by ID
        [HttpGet]
        [Route("userby/{id}")]
        public async Task<IActionResult> Getuserid(int id)
        {
            var user = _Context.Users.Select(t => new
            {
                t.UserId,
                t.UserName,
                t.UserSurname,
                t.UserIdnumber,
                t.UserEmail,
                t.UserPhone,
                t.UserAddress,
                t.UserStatus,
                t.UserCreatedDate

            }
            ).Where(u => u.UserId == id).FirstOrDefault();

            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        //Get current logged in user
        [HttpGet]
        [Route("user/current")]
        public async Task<IActionResult> Getcurrentuser()
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));

            if (id == null || id <= 0)
            {
                return BadRequest("User not logged in");
            }

            var user = _Context.Users.Select(t => new {
                t.UserId,
                t.UserName,
                t.UserSurname,
                t.UserIdnumber,
                t.UserEmail,
                t.UserPhone,
                t.UserAddress,
                t.UserStatus,
                t.UserCreatedDate
            }).Where(u => u.UserId == id).FirstOrDefault();

            return Ok(user);
        }

        //Edit user details
        [HttpPut]
        [Route("edituser/{id}")]
        public async Task<ActionResult> Userupdate([FromBody] UserUpdatedto edituser, int id)
        {

            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue("UserID"));
            var dbu = await _Context.Users.FindAsync(id);

            if (userid == null || userid <= 0)
            {
                return BadRequest("User not logged in");
            }
            if (dbu == null)
            {
                return BadRequest("User not found");
            }

            dbu.UserName = edituser.UserName;
            dbu.UserSurname = edituser.UserSurname;
            dbu.UserPhone = edituser.UserPhoneNumber;
            dbu.UserAddress = edituser.UserAddress;

            //_Context.Users.Update(dbu);
            await _Context.SaveChangesAsync();

            return Ok(new { message = "User profile successful updated" });
        }

        //Delete User
        [HttpDelete]
        [Route("deleteuser/{id}")]
        public async Task<IActionResult> Deleteuser(int id)
        {
            var deluser = await _Context.Users.FindAsync(id);

            if (deluser == null)
            {
                return BadRequest("User not found");

            }
            _Context.Users.Remove(deluser);
            await _Context.SaveChangesAsync();

            return Ok(new { message = "User has been deleted" });
        }

        ///Function used to update user status
        [HttpPut]
        [Route("updateuserstatus/{id}")]
        public async Task<IActionResult> UpdateUserstatus(int id)
        {
            try
            {
                int Userid = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));

                if(Userid == null)
                {
                    return BadRequest("User not logged in");
                }
                var userToUpdate = await _Context.Users.FindAsync(id);

                if (userToUpdate == null)
                {
                    return NotFound("User not found");
                }
                userToUpdate.UserId = userToUpdate.UserId;
                userToUpdate.UserStatus = "Deactivated";

                await _Context.SaveChangesAsync();

                return Ok(new {message = "Status successfully updated"});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Token function
        [NonAction]
        private JwtSecurityToken GetToken(List<Claim> authclaim)
        {
            var signtoken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:Secret"]));

            var token = new JwtSecurityToken
            (
                issuer: _Configuration["JWT:ValidIssuer"],
                audience: _Configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims : authclaim,
                signingCredentials : new SigningCredentials(signtoken, SecurityAlgorithms.HmacSha256)
            );

         return token;
        }
        

        
    }
}
