using NaoBinariosAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace NaoBinariosAPI.SwaggerExamples.Responses
{
    public class ErrorExample : IExamplesProvider<ErrorResponse>
    {
        public ErrorResponse GetExamples()
        {
            return new ErrorResponse
            {
                Errors =
                [
                    new ErrorModel
                    {
                        ErrorMessage = "O campo Nome não foi informado",
                        FieldName = "nome"
                    },
                    new ErrorModel
                    {
                        ErrorMessage = "O campo Profissão não foi informado",
                        FieldName = "profissao"
                    }
                ]
            };
        }
    }
}