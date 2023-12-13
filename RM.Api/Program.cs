using Microsoft.OpenApi.Models;
using RM.Api.Repositories;
using RM.Api.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Consumption",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "André Pereira",
            Email = "pereira.al.andre@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/almeidaandrep/")
        },
        Description = "That's a simple api consumption test."
    });

    // Adiciona informações de comentário dos métodos do controller
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
builder.Services.AddTransient<ICharacterService, CharacterService>();

builder.Services.AddHttpClient("rickandmortyapi", client => client.BaseAddress = new Uri("https://rickandmortyapi.com/api/"));

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
