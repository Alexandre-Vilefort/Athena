using Microsoft.EntityFrameworkCore;
using Athena.Models;
using Athena.Data;
using Athena.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null); // to be able to use [JsonPropertyName("Name")]

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase("TodoList"));

builder.Services.AddDbContext<PostgressDbContext>( options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgressDefaultConnection")));

builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

// Create singletons
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<CustomerService>();

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
