using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _userRepository;

        public UsersController(UsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // This UsersController is used for calling methods from UsersRepository

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.SelectAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.SelectByPK(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var isDeleted = _userRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] UsersModel user)
        {
            if (user == null)
                return BadRequest();

            bool isInserted = _userRepository.Insert(user);
            if (isInserted)
                return Ok(new { Message = "User Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the user");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UsersModel user)
        {
            if (user == null || id != user.UserID)
                return BadRequest();

            var isUpdated = _userRepository.Update(user);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpPost("SignUpUser")]
        public IActionResult SignUpUser([FromBody] UsersModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest(new { Message = "Invalid user data." });
            }

            string errorMessage;
            bool isInserted = _userRepository.Signup(userModel, out errorMessage);

            if (!isInserted)
            {
                return BadRequest(new { Message = errorMessage });
            }

            return Ok(new { Message = "User registered successfully!" });
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest(new { Message = "Invalid login data." });
            }

            string errorMessage;
            string token = _userRepository.Login(loginModel, out errorMessage);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { Message = errorMessage });
            }

            return Ok(new
            {
                Token = token,
                Message = "Login successfully!"
            });
        }
    }
}

