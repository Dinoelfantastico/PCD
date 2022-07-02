using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Product.Domain.Repositories;
using Product.Domain.Services;
using Product.Mapping;
using Product.Persistence.Contexts;
using Product.Persistence.Repositories;
using Product.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//var connectionStrings = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseMySQL(connectionStrings).LogTo(Console.WriteLine, LogLevel.Information)
    //.EnableSensitiveDataLogging()
    //.EnableDetailedErrors());
    //options.UseInMemoryDatabase("product-api-in-memory");
    //options.UseMySQL(builder.Configuration.GetConnectionString("DefaulConnection"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IProduct_Repository, Product_Repository>();
builder.Services.AddScoped<IProduct_Service, Product_Service>();
builder.Services.AddScoped<IUnitOfwork, UnitOfwork>();

builder.Services.AddAutoMapper(typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//using (var context = scope.ServiceProvider.GetService<AppDbContext>())
//{
    //context.Database.EnsureCreated();
//}

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
