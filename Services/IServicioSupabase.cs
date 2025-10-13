using APIRestIndotInventarioMovil.Models;

namespace APIRestIndotInventarioMovil.Services
{
    public interface IServicioSupabase
    {
       Task<Usuario> DameUsuarioSupabase
           (LoginAPI login);
    }
}

