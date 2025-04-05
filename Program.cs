using Api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConexaoBanco = builder.Configuration.GetConnectionString("Railway");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(stringConexaoBanco, ServerVersion.AutoDetect(stringConexaoBanco)));

builder.Services.AddControllers();
builder.WebHost.UseUrls("http://0.0.0.0:5032");



var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

if (builder.Environment.IsProduction())
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();
    app.UseCors("AllowAll");
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
    app.Run();
