using BusinessService.Layer.Concrete;
using BusinessService.Layer.Interface;
using DataAccess.Layer.Concrete;
using DataAccess.Layer.Entity;
using DataAccess.Layer.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data Access Layer
builder.Services.AddScoped<DataAccess.Layer.DataAccess>();
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();

//Business Layer
builder.Services.AddScoped<IBookBusinessService, BookBusinessService>();


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
