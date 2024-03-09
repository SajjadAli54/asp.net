using System.Text.Json;
using CentosCrafts.Models;
using CentosCrafts.Services;

void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddControllers();
    services.AddTransient<JsonFileProductService>();
}

void configureEndpoints(WebApplication app)
{
    app.MapControllers();
    app.MapRazorPages();
    app.MapBlazorHub();
}
{

}

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

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

configureEndpoints(app);

app.Run();
