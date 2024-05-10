using ASPWebAPICRUD.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider=builder.Services.BuildServiceProvider();     //provider create kiya
var config=provider.GetRequiredService<IConfiguration>(); //iconfiguration settings create kiya
builder.Services.AddDbContext<MyDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));
// yaha pe sqlserver and connection string ko register kiya.
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
