using Concerns;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Models;
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ITokenServicecs _tokenService;

        public AuthController(EmployeeContext employeeContext,ITokenServicecs tokenService)
        {
            _employeeContext = employeeContext;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Register(UserConcern userConcern)
        {
            if (await UserExists(userConcern.UserName))
            {
                return BadRequest("UserName is already Taken");
            }
            var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = userConcern.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userConcern.Password)),
                PasswordSalt = hmac.Key
            };

            _employeeContext.Users.Add(user);
            await _employeeContext.SaveChangesAsync();
            return new UserDto
            {
                Username = userConcern.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _employeeContext.Users.AnyAsync(user=>user.UserName == username);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Login(UserConcern userConcern)
        {
            var user= _employeeContext.Users.FirstOrDefault(x=>x.UserName==userConcern.UserName);
            if (user == null)
            {
                return Unauthorized("Invalid username");
            }

            var hmac= new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userConcern.Password));
            if(!user.PasswordHash.SequenceEqual(computedHash))
            {
                return Unauthorized("Invalid Password");
            }
            return new UserDto
            {
                Username=userConcern.UserName,
                Token=_tokenService.CreateToken(user)
            };
        }
    }
}
