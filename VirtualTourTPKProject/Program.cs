using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualTourTPKProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Подключение Razor Pages
builder.Services.AddRazorPages(options =>
{
    // Позже закроем папку Admin авторизацией
    options.Conventions.AuthorizeFolder("/Admin");
});

// Подключение PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка авторизации и пользователей
builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;

        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Настройка обработки запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();