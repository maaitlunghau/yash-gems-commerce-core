using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Application.Services;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;
using YashGems.Commerce.Infrastructure.Repositories;
using YashGems.Commerce.Infrastructure.Services;
using YashGems.Commerce.Infrastructure.Settings;

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
builder.Services.AddScoped<IJewelTypeRepository, JewelTypeRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IGoldKaratRepository, GoldKaratRepository>();
builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<IDiamondColorRepository, DiamondColorRepository>();
builder.Services.AddScoped<IDiamondClarityRepository, DiamondClarityRepository>();
builder.Services.AddScoped<IDiamondCutRepository, DiamondCutRepository>();
builder.Services.AddScoped<IGemstoneTypeRepository, GemstoneTypeRepository>();
builder.Services.AddScoped<IStoneQualityRepository, StoneQualityRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IJewelTypeService, JewelTypeService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IGoldKaratService, GoldKaratService>();
builder.Services.AddScoped<ICertificationService, CertificationService>();
builder.Services.AddScoped<IDiamondColorService, DiamondColorService>();
builder.Services.AddScoped<IDiamondClarityService, DiamondClarityService>();
builder.Services.AddScoped<IDiamondCutService, DiamondCutService>();
builder.Services.AddScoped<IGemstoneTypeService, GemstoneTypeService>();
builder.Services.AddScoped<IStoneQualityService, StoneQualityService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<IPhotoService, PhotoService>();

builder.Services.Configure<GoldPriceSettings>(builder.Configuration.GetSection("GoldPrice"));
builder.Services.AddHttpClient<IGoldPriceService, GoldPriceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();

        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();

        await DbInitializer.SeedAsync(db);
    }
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.Run();