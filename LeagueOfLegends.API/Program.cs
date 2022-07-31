using LeagueOfLegends.Scrapper;
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
});

builder.Services.AddScoped<IPatchNotesScrapper, PatchNoteScrapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();