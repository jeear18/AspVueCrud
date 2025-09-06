using AspVueCrud.Data;       // DbContext
using AspVueCrud.Models;     // User model
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

[Route("api/user")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/user
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_context.Users.ToList());
    }

    // GET: api/user/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // ✅ POST: api/user/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Username))
        {
            return BadRequest(new { message = "All fields are required" });
        }

        // check if email already exists
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (existingUser != null)
        {
            return Conflict(new { message = "Email already exists" });
        }

        // hash the password
        string hashedPassword = HashPassword(request.Password);

        var newUser = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = hashedPassword
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User registered successfully", userId = newUser.Id });
    }

    // ✅ POST: api/user/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new { message = "Email and password are required" });
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        return Ok(new
        {
            message = "Login successful",
            user = new { user.Id, user.Username, user.Email }
        });
    }

    // 🔐 Password hashing helpers
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private bool VerifyPassword(string password, string hashedPassword)
    {
        string hashOfInput = HashPassword(password);
        return hashOfInput == hashedPassword;
    }
}

// ✅ DTOs
public class RegisterRequest
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
