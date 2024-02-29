// �tape 1: Cr�ation du builder pour configurer l'application ASP.NET Core
using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Services;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using Microsoft.Extensions.FileProviders;
using Tools;

var builder = WebApplication.CreateBuilder(args);

//// �tape 2: Configuration de l'application � partir du fichier appsettings.json
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

//builder Marques
builder.Services.AddScoped<IMarqueRepository, MarqueRepository>();
builder.Services.AddScoped<IMarquesService, MarquesService>();

//builder ajout d'un cors pour api => angular
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200", "https://localhost:7011", "http://localhost:8100")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//rendre le fichier API images static afin de le rendre visible
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/images"
});

//appel du cors
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
