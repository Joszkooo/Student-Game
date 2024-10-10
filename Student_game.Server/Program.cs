global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Mvc;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Text.Json.Serialization;

global using AutoMapper;

global using Student_game.Server.Models;
global using Student_game.Server.Data;

global using Student_game.Server.Dtos.Account;
global using Student_game.Server.Dtos.Stats;
global using Student_game.Server.Dtos.Fight;

global using Student_game.Server.Services.AccountService;
global using Student_game.Server.Services.ArmourService;
global using Student_game.Server.Services.EnemyService;
global using Student_game.Server.Services.FightService;
global using Student_game.Server.Services.FoodService;
global using Student_game.Server.Services.StatService;
global using Student_game.Server.Services.StudentService;
global using Student_game.Server.Services.WeaponService;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddDbContext<DataContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{options.AddPolicy("AllowSpecificOrigin", builder =>{
    builder.WithOrigins("https://localhost:5173") // Your frontend URL
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IArmourService, ArmourService>();
builder.Services.AddScoped<IEnemyService, EnemyService>();
builder.Services.AddScoped<IFightService, FightService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IStatService, StatService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();


services.AddHttpContextAccessor();

services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "Cookies";
        options.DefaultChallengeScheme = "Google";
    })
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    });

services.AddAuthorization();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
