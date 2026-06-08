using AgroSpace.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Buscar a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");

// 2. Injetar o AgroDbContext configurado para usar o Oracle
builder.Services.AddDbContext<AgroDbContext>(options =>
    options.UseOracle(connectionString));

// Configurações padrão da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();