using DependencyInjection.Interfaces;
using DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registering services with different lifetimes
builder.Services.AddScoped<IScopedService, LifetimeService>();
builder.Services.AddSingleton<ISingletonService, LifetimeService>();
builder.Services.AddTransient<ITransientService, LifetimeService>();

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
