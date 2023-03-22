using Microsoft.EntityFrameworkCore;
using BlogWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogWebAppContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogWebAppContext") ?? throw new InvalidOperationException("Connection string 'BlogWebAppContext' not found.")));

builder.Services.AddRazorPages();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BlogPosts}/{action=Index}/{id?}");

app.UseAuthorization();

app.MapRazorPages();

app.Run();
