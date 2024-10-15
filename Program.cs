using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Test_EduHub.Models;
using Test_EduHub.Repositories.Abstract;
using Test_EduHub.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("dbcs") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(12);
    options.Cookie.Name = "EduHub.Session"; // <--- Add line
    options.Cookie.IsEssential = true;
});
builder.Services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUserService, UserServiceRepository>();
builder.Services.AddScoped<ICourseService, CourseServiceRepository>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentServiceRepository>();
builder.Services.AddScoped<IMaterialService, MaterialServiceRepository>();
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
// {
//     options.LoginPath = "/user/login";
// });
// builder.Services.AddAuthorization(options =>
// {
//     options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
// });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSession();
app.UseStaticFiles();

app.UseRouting();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
