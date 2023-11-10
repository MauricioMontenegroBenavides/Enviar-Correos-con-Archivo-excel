using Microsoft.Extensions.Configuration;
using SegurosAgro.Models;
using SegurosAgro.Services;

var builder = WebApplication.CreateBuilder(args);






// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSqlServer<AgroSegurosContext>(builder.Configuration.GetConnectionString("Agro"));
builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddScoped<IAseguradoService, AseguradoService>();
builder.Services.AddScoped<IAsignacionSeguroService, AsignacionSeguroService>();



builder.Services.AddSwaggerGen();
// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder.AllowAnyOrigin()
                                                      .AllowAnyHeader()
                                                      .AllowAnyMethod()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowWebapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
