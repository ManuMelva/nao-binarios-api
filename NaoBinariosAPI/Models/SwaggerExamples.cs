using Swashbuckle.AspNetCore.Filters;

namespace NaoBinariosAPI.Models
{
    public class SwaggerExamples : IExamplesProvider<Usuario>
    {
        public Usuario GetExamples()
        {
            return new Usuario
            {
                IDUsuario = 99,
                Nome = "João das Bananas",
                Idade = 200,
                Profissao = "Macho flexível"
            };
        }
    }
}