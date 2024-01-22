// �tape 1: Cr�ation du builder pour configurer l'application ASP.NET Core
using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Services;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using Tools;

var builder = WebApplication.CreateBuilder(args);

//// �tape 2: Configuration de l'application � partir du fichier appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp => new Connection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IAccessoireRepository, AccessoireRepository>();
builder.Services.AddScoped<IAccessoireService, AccessoireService>();


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
