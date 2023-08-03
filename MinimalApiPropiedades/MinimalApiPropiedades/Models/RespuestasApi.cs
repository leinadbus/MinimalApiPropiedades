using System.Net;

namespace MinimalApiPropiedades.Models
{
    public class RespuestasApi
    {
        public RespuestasApi()
        {
            Errores = new List<string>();
        }
        public bool Success { get; set; }
        public Object Resultado { get; set; }
        public HttpStatusCode codigoEstado { get; set; }
        public List<string> Errores { get; set; }
    }
}
