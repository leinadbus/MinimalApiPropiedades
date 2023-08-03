using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApiPropiedades.Data;
using MinimalApiPropiedades.Mapper;
using MinimalApiPropiedades.Models;
using MinimalApiPropiedades.Models.DTOS;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//Configuración de la conexión a la Base de Datos
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de AutoMapper
builder.Services.AddAutoMapper(typeof(ConfiguracionMapper));

//Añadir validaciones
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



//Primeros EndPoints
//Obtener todas las propiedades - GET - MapGet
app.MapGet("/api/propiedades", async (ApplicationDbContext _bd, ILogger<Program> logger) =>
{
    RespuestasApi respuesta = new();
    //Usar el logger como ejemplo de inyección de dependencias
    logger.Log(LogLevel.Information, "Carga todas las propiedades");

    respuesta.Resultado = _bd.Propiedad;
    respuesta.Success = true;
    respuesta.codigoEstado = HttpStatusCode.OK;

    return Results.Ok(respuesta);

}).WithName("ObtenerPorpiedades").Produces<IEnumerable<RespuestasApi>>(200); 



//Obtener propiedad individual - GET - MapGet
app.MapGet("/api/propiedades/{id:int}", (int id) =>
{
    RespuestasApi respuesta = new();

    respuesta.Resultado = DatosPropiedad.listaPropiedades.FirstOrDefault(p => p.IdPropiedad == id);
    if(respuesta.Resultado == null)
    {
        respuesta.Success = false;
        respuesta.codigoEstado = HttpStatusCode.BadRequest;
        return Results.BadRequest(respuesta);
    }

        respuesta.Success = true;
        respuesta.codigoEstado = HttpStatusCode.OK;

    return Results.Ok(respuesta);

}).WithName("ObtenerPorpiedad").Produces<RespuestasApi>(200);



//Crear propiedad 
app.MapPost("/api/crearPropiedad", (IMapper _mapper, 
    IValidator<CrearPropiedadDto> _validacion , [FromBody] CrearPropiedadDto crearPropiedadDto) =>
{

    RespuestasApi respuesta = new() { Success = false, codigoEstado = HttpStatusCode.BadRequest };

    var resultadoValidaciones = _validacion.ValidateAsync(crearPropiedadDto).GetAwaiter().GetResult();

    //Validar id de propiedad y nombre no null
    if(!resultadoValidaciones.IsValid)
    {
        respuesta.Errores.Add(resultadoValidaciones.Errors.FirstOrDefault().ToString());
        return Results.BadRequest(respuesta);
    }
    //Validar si el nombre ya existe
    if(DatosPropiedad.listaPropiedades.FirstOrDefault(p => p.Nombre.ToLower() == crearPropiedadDto.Nombre.ToLower()) != null)
    {
        respuesta.Errores.Add("El nombre ya está registrado");
        return Results.BadRequest(respuesta);
    }

    Propiedad propiedad =_mapper.Map<Propiedad>(crearPropiedadDto);

    propiedad.IdPropiedad = DatosPropiedad.listaPropiedades.OrderByDescending(p => p.IdPropiedad).FirstOrDefault().IdPropiedad +1;
    DatosPropiedad.listaPropiedades.Add(propiedad);

    PropiedadDto propiedadDto = _mapper.Map<PropiedadDto>(propiedad);

    //return Results.CreatedAtRoute($"ObtenerPorpiedad", new { id = propiedad.IdPropiedad}, propiedadDto);

    respuesta.Resultado = propiedadDto;
    respuesta.Success = true;
    respuesta.codigoEstado = HttpStatusCode.Created;

    return Results.Ok(respuesta);

}).WithName("CrearPorpiedad").Accepts<CrearPropiedadDto>("application/json").Produces<RespuestasApi>(201).Produces(400);



app.MapPut("/api/actualizarPropiedad", (IMapper _mapper,
    IValidator<ActualizarPropiedadDto> _validacion, [FromBody] ActualizarPropiedadDto actualizarPropiedadDto) =>
{

    RespuestasApi respuesta = new() { Success = false, codigoEstado = HttpStatusCode.BadRequest };

    var resultadoValidaciones = _validacion.ValidateAsync(actualizarPropiedadDto).GetAwaiter().GetResult();

    //Validar id de propiedad y nombre no null
    if (!resultadoValidaciones.IsValid)
    {
        respuesta.Errores.Add(resultadoValidaciones.Errors.FirstOrDefault().ToString());
        return Results.BadRequest(respuesta);
    }

    Propiedad propiedadDesdeBD = DatosPropiedad.listaPropiedades.FirstOrDefault(p => p.IdPropiedad == actualizarPropiedadDto.IdPropiedad);
    propiedadDesdeBD.Nombre = actualizarPropiedadDto.Nombre;
    propiedadDesdeBD.Descripcion = actualizarPropiedadDto.Descripcion;
    propiedadDesdeBD.Ubicacion = actualizarPropiedadDto.Ubicacion;
    propiedadDesdeBD.Activa = actualizarPropiedadDto.Activa;

    respuesta.Resultado = _mapper.Map<PropiedadDto>(propiedadDesdeBD);
    respuesta.Success = true;
    respuesta.codigoEstado = HttpStatusCode.Created;

    return Results.Ok(respuesta);

}).WithName("ActualizarPorpiedad").Accepts<ActualizarPropiedadDto>("application/json").Produces<RespuestasApi>(200).Produces(400);



//Borrar propiedad individual
app.MapDelete("/api/propiedades/{id:int}", (int id) =>
{

    RespuestasApi respuesta = new() { Success = false, codigoEstado = HttpStatusCode.BadRequest }; ;

    //Obtener el Id de la propiedad a eliminar
    Propiedad propiedadDesdeBD = DatosPropiedad.listaPropiedades.FirstOrDefault(p => p.IdPropiedad == id);
    if (propiedadDesdeBD != null)
    {
        DatosPropiedad.listaPropiedades.Remove(propiedadDesdeBD);
        respuesta.Success = true;
        respuesta.codigoEstado = HttpStatusCode.NoContent;

        return Results.Ok(respuesta);
    }
    else
    {
        respuesta.Errores.Add("El Id de la propiedad es Invalido");
    return Results.BadRequest(respuesta);
    }
});


app.UseHttpsRedirection();

app.Run();
