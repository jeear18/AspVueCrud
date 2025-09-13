using AspVueCrud.Data;       // your DbContext namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspVueCrud.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/dashboard/stats
        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var usersCount = await _context.Users.CountAsync();
            var productsCount = await _context.Products.CountAsync();

            return Ok(new
            {
                users_count = usersCount,
                products_count = productsCount
            });
        }
    }
}
