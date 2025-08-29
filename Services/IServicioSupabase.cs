using APIRestIndotInventarioMovil.Models;

namespace APIRestIndotInventarioMovil.Services
{
    public interface IServicioSupabase
    {
       Task<Usuario> DameUsuarioSQLServer(LoginAPI login);
    }
}

