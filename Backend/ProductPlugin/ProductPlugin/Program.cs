using Microsoft.EntityFrameworkCore;
using Plugin.Application.Common.Interfaces;
using Plugin.Application.Features;
using Plugin.Application.Services;
using Plugin.Application.Strategies;
using Plugin.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetProductLookup.Handler).Assembly)
);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName!.Replace("+", "_"));
});
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPricingStrategy, DiscountPricingStrategy>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy
          .WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseCors("AllowAngularDev");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
