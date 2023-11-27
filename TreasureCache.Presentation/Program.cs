using TreasureCache.Infrastructure;
using Tailwind;
using TreasureCache.Abstractions.Mediator.Extensions;
using TreasureCache.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.InstallInfrastructure(builder.Configuration);
builder.Services.AddMediator(cfg =>
{
    cfg.RegisterFromAssembliesContainingMarkers(new[]
    {
        typeof(IInfrastructureMarker),
        typeof(IApplicationMarker)
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.RunTailwind("tailwind", "../");
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
IFormFile image;
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();