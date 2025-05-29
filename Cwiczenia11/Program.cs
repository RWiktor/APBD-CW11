using Microsoft.EntityFrameworkCore;
using Cwiczenia11.Data;
using Cwiczenia11.Services;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja kontrolerów
builder.Services.AddControllers();

// Konfiguracja kontekstu bazy danych (pobranie connection string z pliku appsettings.json)
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// Wstrzykiwanie zależności - rejestracja serwisu DbService
builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Konfiguracja pipeline HTTP
app.UseAuthorization();

app.MapControllers();

app.Run();