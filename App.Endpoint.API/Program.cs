using App.Domain.AppServices.Product;
using App.Domain.Core.Product.Contract.AppServices;
using App.Domain.Core.Product.Contract.Repositories;
using App.Domain.Core.Product.Contract.Services;
using App.Domain.Services.Product;
using App.Infra.Data.Repos.Ef.Products;
using App.Infra.Data.SqlServer.Ef.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

builder.Services.AddDbContext<Maktab97ShopDbContext>();

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
