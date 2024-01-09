using DotNetCrudWithMongoDb.Context;
using DotNetCrudWithMongoDb.Models;
using DotNetCrudWithMongoDb.Repositories;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.AddScoped<IApplicationDbContext>(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<BookStoreDatabaseSettings>>().Value;
    return new MongoDBContext(settings.ConnectionString, settings.DatabaseName);
});


// Register MongoRepositoryFactory
builder.Services.AddScoped<IMongoRepositoryFactory, MongoRepositoryFactory>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
