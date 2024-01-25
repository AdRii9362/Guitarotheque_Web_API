// Étape 1: Création du builder pour configurer l'application ASP.NET Core
using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Services;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using Tools;

var builder = WebApplication.CreateBuilder(args);

//// Étape 2: Configuration de l'application à partir du fichier appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder pour la connexion
builder.Services.AddSingleton(sp => new Connection(builder.Configuration.GetConnectionString("default")));

//builder Accessoire
builder.Services.AddScoped<IAccessoireRepository, AccessoireRepository>();
builder.Services.AddScoped<IAccessoireService, AccessoireService>();

//builder Groupe
builder.Services.AddScoped<IGroupeRepository, GroupeRepository>();
builder.Services.AddScoped<IGroupeService, GroupeService>();

//builder Guitare
builder.Services.AddScoped<IGuitareRepository, GuitareRepository>();
builder.Services.AddScoped<IGuitareService, GuitareService>();

//builder Guitariste
builder.Services.AddScoped<IGuitaristeRepository, GuitaristeRepository>();
builder.Services.AddScoped<IGuitaristeService, GuitaristeService>();

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
