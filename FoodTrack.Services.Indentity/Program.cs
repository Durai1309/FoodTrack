using FoodTrack.Services.Indentity;
using FoodTrack.Services.Indentity.DbContexts;
using FoodTrack.Services.Indentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FoodTrack")));
 builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

 builder.Services.AddIdentityServer(options =>
{
	options.Events.RaiseErrorEvents = true;
	options.Events.RaiseInformationEvents = true;
	options.Events.RaiseFailureEvents = true;
	options.Events.RaiseSuccessEvents = true;
	options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(StaticData.IdentityResources)
.AddInMemoryApiScopes(StaticData.ApiScopes)
.AddInMemoryClients(StaticData.Clients)
.AddAspNetIdentity<ApplicationUser>().AddDeveloperSigningCredential();


// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

