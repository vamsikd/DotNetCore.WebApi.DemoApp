using DemoApp.API;
using DemoApp.API.Data;
using DemoApp.API.Middlewares;
using DemoApp.API.Services;
using DemoApp.API.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connecttionString = builder.Configuration.GetConnectionString("DefaultConnection");
int intervalInMinutes = Convert.ToInt32(builder.Configuration["Scheduler:IntervalInMinutes"]);
// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(o => o.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API for CRUD operations on Products and Categories",
        Version = "v1",
        Description = "This project is a Asp.Net Core Web API and Entity Framework code first approach with MySQL as Database"
    });
});
builder.Services.AddDbContext<DemoAppDbContext>(opts =>
{
    opts.UseMySql(connecttionString, ServerVersion.AutoDetect(connecttionString));
});
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IExcelFileProcessor, ExcelFileProcessor>();

builder.Services.AddScheduledJobs(intervalInMinutes);

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

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();
