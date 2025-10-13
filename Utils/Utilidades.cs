using APIRestIndotInventarioMovil.DTO;
using APIRestIndotInventarioMovil.Models;

namespace APIRestIndotInventarioMovil.Utils
{
    public static class Utilidades
    {
        public static UsuarioApiDTO convertirDTO(this Usuario usuarioSupabase)
        {
            if (usuarioSupabase != null)
            {
                return new UsuarioApiDTO
                {
                    Email = usuarioSupabase.Email,
                    Token = usuarioSupabase.Token,
                    CodEmpresa = usuarioSupabase.CodEmpresa
                };
            }

            return null;
        }
    }
}