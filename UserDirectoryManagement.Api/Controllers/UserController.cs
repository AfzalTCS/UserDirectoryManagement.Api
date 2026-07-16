using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserDirectoryManagement.Application.DTOs;
using UserDirectoryManagement.Application.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserDirectoryManagement.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET: api/<UserController>
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Fetching all user list");

            try
            {
                var user = await _userService.GetUserAsync();
                if (user == null)
                {
                    _logger.LogWarning("No Users exist!!");
                    return NotFound();
                }
                _logger.LogInformation("Successfully retrieved user details");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching user list");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Fetching user with ID {UserId}", id);
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} not found", id);
                    return NotFound();
                }
                _logger.LogInformation("Successfully retrieved user {UserId}", id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching user with ID {UserId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
           
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto? dto)  
        {
            _logger.LogInformation("Create new user details");
            try
            {
                if (dto == null) return BadRequest();
                var id = await _userService.CreateUserAsync(dto);

                _logger.LogInformation("Successfully user create");

                return CreatedAtAction(nameof(Get), new { id }, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating new user");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            } 
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            _logger.LogInformation("Update user details");
            try
            {
                await _userService.UpdateUserAsync(id, dto);
                _logger.LogInformation("Successfully user details updated.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user details.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Delete user details");
            try
            {
                await _userService.DeleteUserAsync(id);
                _logger.LogInformation("Successfully user deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user details.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
              
            }
        }
    }
}
