using APIRestIndotInventarioMovil.Models;
using Supabase;
using Supabase.Postgrest.Responses;

namespace APIRestIndotInventarioMovil.Services
{
    public class ServicioSupabase : IServicioSupabase
    {
        private readonly Client _client;
        private readonly ILogger<IServicioSupabase> _log;

        public ServicioSupabase(Client client, ILogger<IServicioSupabase> logger)
        {
            _client = client;
            _log = logger;
        }

        public async Task<Usuario> DameUsuarioSupabase(LoginAPI login)
        {
            try
            {
                // SELECT * FROM usuarios WHERE Email = '...' AND Password = '...' LIMIT 1
                var response = await _client
                    .From<Usuario>()
                    .Filter("email", Supabase.Postgrest.Constants.Operator.Equals, login.Email)
                    .Filter("password", Supabase.Postgrest.Constants.Operator.Equals, login.Password)
                    .Single();

                return response;
            }
            catch (Exception ex)
            {
                _log.LogError("ERROR: " + ex.ToString());
                throw new Exception("Se produjo un error al obtener datos del usuario de login: " + ex.Message);
            }
        }
    }
}
