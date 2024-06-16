using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDBEFCore.CRUD;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MongoDBContext>(options =>
{
    var connectionstring = "mongodb://admin:password@localhost:27017/";
    var database = "EFCOREDB";
    options.UseMongoDB(connectionstring, database);
});

builder.Services.AddScoped<IMovieRepo,MovieRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/movies/New", (IMovieRepo movieRepo,[FromBody]Movie movie) =>
{
    var response = movieRepo.AddMovie(movie);
    return Results.Ok(response);
});

app.MapGet("/movies/getall",(IMovieRepo movieRepo) => {
    var response = movieRepo.GetAllMovieList();
    return Results.Ok(response);
});

app.Run();
