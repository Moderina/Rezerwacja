using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rezerwacja.Data;
using Rezerwacja.Interfaces;
using Rezerwacja.Repositories;
using Rezerwacja.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Reservations")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IBuildingRepo, BuildingRepo>();
builder.Services.AddTransient<IRoomService, RoomService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
await CreateAdminUser(app.Services.CreateScope().ServiceProvider);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();


static async Task CreateAdminUser(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string adminEmail = "admin@admin.com";
    string password = "Admin!234";

    if (await roleManager.FindByNameAsync("admin") == null)
    {
        await roleManager.CreateAsync(new IdentityRole("admin"));
    }
    System.Diagnostics.Debug.WriteLine("BBBBBBBBBB" + adminEmail);
    if (await userManager.FindByNameAsync(adminEmail) == null)
    {
        System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAA");

        var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
        var result = await userManager.CreateAsync(adminUser, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "admin");
        }
    }
}