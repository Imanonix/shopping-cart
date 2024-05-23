using Application.Mapper;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Domain.Interfaces.Repository;
using Infrastructure.Implementation;
using Infrastructure.ShoppingCartDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddDbContext<CartDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CartDbContextConnectionStrings"));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(option =>
{
    option.AddPolicy("Policy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Policy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
