using Microsoft.EntityFrameworkCore;
using TelephoneBookWeb.ApiInteraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();//добавление HttpClient в DI
builder.Services.AddScoped(provider => new ApiRequests(provider.GetRequiredService<HttpClient>(), "https://localhost:7298/api"));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Persone}/{action=GetPersones}");

app.Run();
