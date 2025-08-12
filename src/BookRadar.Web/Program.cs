using System.Reflection;
using BookRadar.Application.Abstractions;
using BookRadar.Infrastructure.Persistence;
using BookRadar.Infrastructure.Http.Clients;
using BookRadar.Domain.Abstractions;
using Mapster;
using MapsterMapper;
using MediatR;
using BookRadar.Infrastructure.Persistence.Context;
using BookRadar.Infrastructure.Repositories.History;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC + Razor
builder.Services.AddControllersWithViews();

// DbContext (SQL Server)
builder.Services.AddDbContext<BookRadarDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// MediatR (Application assembly)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

// HttpClient para Open Library
builder.Services.AddHttpClient<OpenLibraryHttpClient>();

// Puertos -> Implementaciones
builder.Services.AddScoped<IBookSearchService, OpenLibraryHttpClient>();
builder.Services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();

// Mapster (escanea Application + Infrastructure + Web)
var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(
    Assembly.GetExecutingAssembly(),
    typeof(ApplicationAssemblyReference).Assembly,
    typeof(BookRadarDbContext).Assembly);

builder.Services.AddSingleton(typeAdapterConfig);
builder.Services.AddScoped<IMapper, ServiceMapper>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookRadarDbContext>();
    db.Database.Migrate(); // crea/actualiza el esquema
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Search}/{id?}");

app.Run();
