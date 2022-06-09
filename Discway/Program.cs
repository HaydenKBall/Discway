using Discway.Data.Context;
using Discway.Data.Dto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DiscwayContext>();

// Add services to the container.   
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("Discway");
builder.Services.AddDbContext<DiscwayContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Discway.Data")));

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
