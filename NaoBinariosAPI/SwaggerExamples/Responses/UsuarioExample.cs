using NaoBinariosAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace NaoBinariosAPI.SwaggerExamples.Responses
{
    public class UsuarioExample : IExamplesProvider<Usuario>
    {
        public Usuario GetExamples()
        {
            return new Usuario
            {
                IDUsuario = 99,
                Nome = "João das Bananas",
                Idade = 200,
                Profissao = "Dançarino exótico"
            };
        }
    }
}