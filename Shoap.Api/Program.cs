using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Shoap.Api.Data;
using Shoap.Api.Repositories;
using Shoap.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<ShoapDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("ShoapConnection")!)
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7098", "http://localhost:5079")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType, "productid", "userid")
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
