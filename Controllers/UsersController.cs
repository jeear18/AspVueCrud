using AspVueCrud.Data;       // <-- your DbContext namespace
using AspVueCrud.Models;     // <-- your Product model namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/user")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_context.Users.ToList());
    }
        
    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }
    // ✅ POST login
    [HttpPost("login")]
    [Route("api/user/login")]  
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new { message = "Email and password are required" });
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email && u.PasswordHash == request.Password);

        if (user == null)
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        return Ok(new
        {
            message = "Login successful",
            user = new
            {
                user.Id,
                user.Username,
                user.Email
            }
        });
    }

    
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; }= string.Empty;
}
