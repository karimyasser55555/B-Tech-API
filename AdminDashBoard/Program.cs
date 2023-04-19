using AdminDashBoard.Models.IRepository.Admin;
using AdminDashBoard.Models.Services.Admin;
using ApiContext;
using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ApiDataBase")));
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 52428800000; // the maximum file size in bytes
});
builder.Services.AddMvc(options =>
{
    var jsonInputFormatter = options.InputFormatters.OfType<SystemTextJsonInputFormatter>().First();
    jsonInputFormatter.SupportedMediaTypes.Add("multipart/form-data");
});
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddTransient(typeof(IAdminRepository), typeof(AdminRepository));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<DBContext>();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//         .AddCookie(cookieOptions =>
//         {
//             cookieOptions.LoginPath = "/AdminAccount/LogIN";
//             cookieOptions.AccessDeniedPath = "/account/denied";
//             cookieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(120);
//         });
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.Cookie.Name = "YourAppCookieName";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/AdminAccount/LogIN";
    // ReturnUrlParameter requires 
    //using Microsoft.AspNetCore.Authentication.Cookies;
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
