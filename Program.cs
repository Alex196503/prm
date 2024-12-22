using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectMediiBun.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Members");
    options.Conventions.AllowAnonymousToPage("/Members/Index");
    options.Conventions.AllowAnonymousToPage("/Members/Details");
    options.Conventions.AuthorizeFolder("/Memberships", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Memberships/Index");
    options.Conventions.AllowAnonymousToPage("/Memberships/Details");
    options.Conventions.AuthorizeFolder("/Trainers", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Trainers/Index");
    options.Conventions.AllowAnonymousToPage("/Trainers/Details");
    options.Conventions.AuthorizeFolder("/Reviews", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Reviews/Index");
    options.Conventions.AllowAnonymousToPage("/Reviews/Details");
    options.Conventions.AuthorizeFolder("/Reservations", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Reservations/Index");
    options.Conventions.AllowAnonymousToPage("/Reservations/Details");
    options.Conventions.AuthorizeFolder("/Terenuri", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Terenuri/Index");
    options.Conventions.AllowAnonymousToPage("/Terenuri/Details");





});
builder.Services.AddDbContext<ProiectMediiBunContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMediiBunContext") ?? throw new InvalidOperationException("Connection string 'ProiectMediiBunContext' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMediiBunContext") ?? throw new InvalidOperationException("Connectionstring 'ProiectMediiBunContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
     .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
