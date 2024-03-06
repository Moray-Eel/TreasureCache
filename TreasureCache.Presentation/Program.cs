using FluentValidation;
using OfficeOpenXml;
using QuestPDF.Infrastructure;
using TreasureCache.Infrastructure;
using Tailwind;
using TreasureCache.Abstractions.Mediator.Extensions;
using TreasureCache.Abstractions.Options;
using TreasureCache.Application;
using TreasureCache.Presentation.Requests;
using TreasureCache.Presentation.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.InstallInfrastructure(builder.Configuration);
builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection("Stripe"));
builder.Services.InstallApplication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IValidator<CreateProductRequest>, CreateProductRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();
QuestPDF.Settings.License = LicenseType.Community;
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();