using NaoBinariosAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace NaoBinariosAPI.SwaggerExamples.Responses
{
    public class ListUsuariosExample : IExamplesProvider<IEnumerable<Usuario>>
    {
        public IEnumerable<Usuario> GetExamples()
        {
            return
            [
                new Usuario
                {
                    IDUsuario = 99,
                    Nome = "João das Bananas",
                    Idade = 200,
                    Profissao = "Dançarino exótico"
                },
                new Usuario
                {
                    IDUsuario = 98,
                    Nome = "Carinha que mora logo ali",
                    Idade = 15,
                    Profissao = "Suco de Fruta"
                }
            ];
        }
    }
}