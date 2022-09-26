using BikeRentalAPI.Data;
using BikeRentalAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly BikeRentalAPIDbContext dbContext;
        public UserController(BikeRentalAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(dbContext.Users.ToList());
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> AddUsers(Registration addedUser)
        {
            var user = new Users()
            {
                Id = Guid.NewGuid(),
                FullName = addedUser.FullName,
                Email = addedUser.Email,
                Password = addedUser.Password,
                Address = addedUser.Address
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost]
        [Route("Login")]
        public string LoginValidation(Login loggedUser)
        {
            string validUser = string.Empty;
            var userExist = dbContext.Users.FirstOrDefault(u => u.Email == loggedUser.Email
                     && u.Password == loggedUser.Password);
            if(userExist == null)
            {
                validUser = "User Not Found!!";
            }
            else
            {
                validUser = "User Exists";
            }
            return validUser;
        }
    }
}
