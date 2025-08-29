using AspVueCrud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

// 👇 Enable CORS BEFORE MapControllers
app.UseCors("AllowVueApp");
app.MapControllers(); // 👈 This maps [ApiController] routes
app.Run();
