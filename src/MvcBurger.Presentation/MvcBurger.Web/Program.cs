using Microsoft.AspNetCore.Identity;
using MvcBurger.Application;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance;
using MvcBurger.Persistance.Contexts;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

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
    option.LoginPath = "/Access/Login";
    option.SlidingExpiration = true;
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
       
