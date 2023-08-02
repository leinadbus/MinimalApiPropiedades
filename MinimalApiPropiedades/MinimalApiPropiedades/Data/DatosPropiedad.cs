using MinimalApiPropiedades.Models;

namespace MinimalApiPropiedades.Data
{
    public static class DatosPropiedad
    {
        public static List<Propiedad> listaPropiedades = new List<Propiedad>
        {
            new Propiedad{IdPropiedad = 1, Nombre = "Casa las palmas", Descripcion = "Descripción test", Ubicacion = "Cartagena", Activa = true , FechaCreacion = DateTime.Now.AddDays(-10)},
            new Propiedad{IdPropiedad = 2, Nombre = "Casa las flores", Descripcion = "Descripción test", Ubicacion = "Asturias", Activa = true , FechaCreacion = DateTime.Now.AddDays(-10)},
            new Propiedad{IdPropiedad = 3, Nombre = "Casa las castañas", Descripcion = "Descripción test", Ubicacion = "Galicia", Activa = false , FechaCreacion = DateTime.Now.AddDays(-10)},
            new Propiedad{IdPropiedad = 4, Nombre = "Casa las peras", Descripcion = "Descripción test", Ubicacion = "Madrid", Activa = true , FechaCreacion = DateTime.Now.AddDays(-10)}
        };
    }
}
