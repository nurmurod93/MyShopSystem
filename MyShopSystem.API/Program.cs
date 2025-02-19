using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services;
using MyShopSystem.API.Services.Intefaceis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IDeliveryDetailsService, DeliveryDetailsService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoreProductService, StoreProductService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWarehouceService, WarehouseService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
