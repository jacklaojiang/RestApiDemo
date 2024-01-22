using Microsoft.Extensions.Configuration;
using RestApiDemo.Configs;
using RestApiDemo.Repos;
using RestApiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<IUrlRepo, UrlRepo>();

builder.Services.Configure<UrlConfig>(builder.Configuration.GetSection("UrlConfig"));
builder.Services.Configure<DbConfig>(builder.Configuration.GetSection("DBConfig"));

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
