using AssetManager.Core.Contracts;
using AssetManager.Core.Data;
using AssetManager.Core.Models;
using AssetManager.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AssetManager.Core.Data.Common;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<AssetManagerDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("AssetManager.Core")));
builder.Services.AddDefaultIdentity<UserModel>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;
})
    .AddEntityFrameworkStores<AssetManagerDbContext>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IRepository, Repository>();

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
