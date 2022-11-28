using HIT.REST.BL;
using HIT.REST.BL.Interfaces;
using HIT.REST.Infrastructure.Persistence;
using HIT.REST.Routes.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICandidateBL, CandidateBL>();
builder.Services.AddTransient<IJobPostingBL, JobPostingBL>();
builder.Services.AddTransient<IJobPostingApplicationBL, JobPostingApplicationBL>();
builder.Services.AddTransient<IJobSkillBL, JobSkillBL>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    /*
        options.UseNpgsql(configuration.GetConnectionString("HITDatabase"), x =>
        {
            x.MigrationsAssembly("HIT.Infrastructure");
        });
    */
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    options.UseSqlite($"Data Source={System.IO.Path.Join(path, "hit.db")}");
});

builder.Services.AddCors();

builder.Services.AddRouteConfigurations();

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