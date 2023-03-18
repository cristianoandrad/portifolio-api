using Microsoft.EntityFrameworkCore;
using Portifolio.API.Data;
using Portifolio.API.Repository;
using Portifolio.Domain.Models;
using Portifolio.Persistence.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<PortifolioContext>(builder.Configuration.GetConnectionString("ServerConnection"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyHeader());

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("ServerConnection");

    builder.Services.AddDbContext<PortifolioContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });
}

app.MapPost("/contacts", async (IContactRepository _contactRepository,Contact contact) =>
{
    contact.Date = DateTime.Now;

    var contactReturn = await _contactRepository.AddContact(contact);

    return Results.Ok(contactReturn);
})
.WithOpenApi();

app.MapGet("/contacts", async (IContactRepository _contactRepository) =>
{
    var contactsReturn = await _contactRepository.GetAllContacts();

    return Results.Ok(contactsReturn);
})
.WithOpenApi();

app.Run();
