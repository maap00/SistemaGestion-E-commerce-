using Microsoft.EntityFrameworkCore;
using SistemaGestion.Database;
using SistemaGestion.SistemaGestionBussiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<SalesServices>();
builder.Services.AddScoped<ProductSalesServices>();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

//Inyeccion la dependencia/objeto  CoderContext que puede ser llamado de cualquier archivo para generar la conexion a la base de datos
builder.Services.AddDbContext<CoderContext>(options =>
{
    string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

    options.UseSqlServer(stringConnection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
