using Microsoft.EntityFrameworkCore;
using ServicoCepAtividade.Repository;
using ServicoCepAtividade.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Serviço CEP API", Version = "v1" });
});

builder.Services.AddDbContext<CepDbContext>(options =>
    options.UseSqlite("Data Source=ceps.db"));

builder.Services.AddScoped<ICepRepository, CepRepository>();
builder.Services.AddScoped<ICepService, CepService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Serviço CEP API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
