using Microsoft.AspNetCore.Identity;
using MvcBurger.Application;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Web.Middlewares;
using Serilog;



var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddSession();

builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>(
    option =>
    {
        option.SignIn.RequireConfirmedPhoneNumber = false;
        option.SignIn.RequireConfirmedEmail = false;
        option.SignIn.RequireConfirmedAccount = false;
        option.Password.RequiredLength = 6;
        option.Password.RequireNonAlphanumeric = false;
        option.Password.RequireUppercase = false;
        option.Password.RequireLowercase = false;
        option.Password.RequireDigit = false;
    }).AddEntityFrameworkStores<BurgerDbContext>();


builder.Services.ConfigureApplicationCookie(option =>
{
    //option.AccessDeniedPath = null;
    option.LoginPath = "/u/Login";
    option.SlidingExpiration = true;
    option.Cookie.IsEssential = true;
    option.ExpireTimeSpan = TimeSpan.FromSeconds(10);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Menus}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();

