using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Application.Services;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;
using YashGems.Commerce.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySQL");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IGoldKaratRepository, GoldKaratRepository>();
builder.Services.AddScoped<IGoldKaratRepository, GoldKaratRepository>();
builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IJewelTypeService, JewelTypeService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IGoldKaratService, GoldKaratService>();
builder.Services.AddScoped<ICertificationService, CertificationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();