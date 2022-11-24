using HIT.API.Routes.Configuration;
using HIT.Application;
using HIT.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddRouteConfigurations();

// Add services to the container.
builder.Services.RegisterApplicationDependencies();
builder.Services.RegisterInfrastructureDependencies(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouteConfigurations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowCredentials()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
