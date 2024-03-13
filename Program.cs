using SICEI.DataAccess;
using SICEI.Interfaces;
using SICEI.Services;
using SICEI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Mi API", Version = "v1" });
});

builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alumnos API V1");
    c.RoutePrefix = string.Empty; // Especificar la ruta raíz del Swagger UI
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
