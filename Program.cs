using Api.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConexaoBanco = builder.Configuration.GetConnectionString("Railway");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(stringConexaoBanco, ServerVersion.AutoDetect(stringConexaoBanco)));


builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.WebHost.UseUrls("http://0.0.0.0:5032");

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");
//app.UseHttpsRedirection();
app.MapControllers();
app.Run();
