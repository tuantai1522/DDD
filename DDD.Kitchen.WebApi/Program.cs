using Carter;
using DDD.Kitchen.Infrastructure;
using DDD.Kitchen.WebApi.Configuration;
using DDD.Kitchen.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCarter();

// Add DI for all projects
builder.Services
    .InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // await app.InitializeDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Global exception handling
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapCarter();

app.Run();

