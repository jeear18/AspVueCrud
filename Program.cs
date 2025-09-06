using AspVueCrud.Data;
using Microsoft.EntityFrameworkCore;
//===========================
//   FOR JWT AUTHENTICATION  
// ==========================
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;




var builder = WebApplication.CreateBuilder(args);


// Secret key (normally store in appsettings.json)
var jwtKey = builder.Configuration["Jwt:Key"] ?? "SuperSecretKey123!";

// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});


// Use SQL Server instead of SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 👇 Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Vue dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();




// ✅ Check SQL Server connection
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        if (db.Database.CanConnect())
        {
            // Ensure database is created and seeded
            Console.WriteLine("✅ Connected to SQL Server!");
            DbInitializer.Seed(db);// 👈 Seed sample data
        }
        else
            Console.WriteLine("❌ Cannot connect to SQL Server.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("⚠️ DB error: " + ex.Message);
    }


}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// 👇 Enable CORS BEFORE MapControllers
app.UseCors("AllowVueApp");
app.MapControllers(); // 👈 This maps [ApiController] routes
app.Run();
