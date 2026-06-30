using Microsoft.EntityFrameworkCore;
using QuickFix.web.Data;
using QuickFix.web.Interfaces;
using QuickFix.web.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// Database Connection
// ==========================

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================
// Dependency Injection
// ==========================

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ==========================
// MVC
// ==========================

builder.Services.AddControllersWithViews();

// ==========================
// Session
// ==========================

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ==========================
// Swagger
// ==========================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==========================
// Build App
// ==========================

var app = builder.Build();

// ==========================
// Configure Middleware
// ==========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

// ==========================
// Routes
// ==========================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();