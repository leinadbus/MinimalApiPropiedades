using Microsoft.AspNetCore.Mvc;
using MinimalApiPropiedades.Data;
using MinimalApiPropiedades.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Primeros EndPoints
//Obtener todas las propiedades - GET - MapGet
app.MapGet("/api/propiedades", (ILogger<Program> logger) =>
{
    //Usar el logger como ejemplo de inyección de dependencias
    logger.Log(LogLevel.Information, "Carga todas las propiedades");

    return Results.Ok(DatosPropiedad.listaPropiedades);
}).WithName("ObtenerPorpiedades").Produces<IEnumerable<Propiedad>>(200); 

//Obtener propiedad individual - GET - MapGet
app.MapGet("/api/propiedades/{id:int}", (int id) =>
{
    return Results.Ok(DatosPropiedad.listaPropiedades.FirstOrDefault(p => p.IdPropiedad == id));
}).WithName("ObtenerPorpiedad").Produces<Propiedad>(200);

//Crear propiedad 
app.MapPost("/api/crearPropiedad", ([FromBody] Propiedad propiedad) =>
{
    //Validar id de propiedad y nombre no null
    if(propiedad.IdPropiedad != 0 || string.IsNullOrEmpty(propiedad.Nombre))
    {
        return Results.BadRequest("IdPropiedad incorrecto o nombre vacío");
    }
    //Validar si el nombre ya existe
    if(DatosPropiedad.listaPropiedades.FirstOrDefault(p => p.Nombre.ToLower() == propiedad.Nombre.ToLower()) != null)
    {
        return Results.BadRequest("El nombre ya está registrado");
    }
    propiedad.IdPropiedad = DatosPropiedad.listaPropiedades.OrderByDescending(p => p.IdPropiedad).FirstOrDefault().IdPropiedad +1;
    DatosPropiedad.listaPropiedades.Add(propiedad);
    //return Results.Ok(DatosPropiedad.listaPropiedades);

    //return Results.Created($"/api/propiedades/{propiedad.IdPropiedad}", propiedad);

    return Results.CreatedAtRoute($"ObtenerPorpiedad", new { id = propiedad.IdPropiedad}, propiedad);

}).WithName("CrearPorpiedad").Accepts<Propiedad>("application/json").Produces<Propiedad>(201).Produces(400); 

app.UseHttpsRedirection();

app.Run();
