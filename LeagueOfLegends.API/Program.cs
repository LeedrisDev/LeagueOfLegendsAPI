using System.Reflection;
using LeagueOfLegends.API.Business.PatchNoteBusiness;
using LeagueOfLegends.API.Business.SummonerBusiness;
using LeagueOfLegends.API.DataAccess;
using LeagueOfLegends.API.DataAccess.PatchNoteData;
using LeagueOfLegends.API.DataAccess.SummonerData;
using LeagueOfLegends.Scrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "League Of Legends API",
        Contact = new OpenApiContact
        {
            Name = "Thomas Blondel",
            Email = "tfoenix@gmail.com",
            Url = new Uri("https://github.com/Thomas-blondel")
        }
    });
    
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
}, ServiceLifetime.Singleton);

// Dependency Injection
builder.Services.AddSingleton<IPatchNotesScrapper, PatchNoteScrapper>();
builder.Services.AddSingleton<IPatchNoteBusiness, PatchNotesBusiness>();
builder.Services.AddSingleton<IPatchNoteData, PatchNoteData>();
builder.Services.AddSingleton<ISummonerBusiness, SummonerBusiness>();
builder.Services.AddSingleton<ISummonerData, SummonerData>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();