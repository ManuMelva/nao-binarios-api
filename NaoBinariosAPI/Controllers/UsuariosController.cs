using Microsoft.AspNetCore.Mvc;
using NaoBinariosAPI.Models;

namespace NaoBinariosAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/users")]
    public class UsuariosController : ControllerBase
    {
        private static readonly List<Usuario> Users = 
        [
            new Usuario{IDUsuario=1,Nome="Emmanuel",Idade=19,Profissao="Garoto de Programa"},
            new Usuario{IDUsuario=2,Nome="Guilherme",Idade=19,Profissao="Dama da Noite"}
        ];

        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(ILogger<UsuariosController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obter uma lista com todos os usuários.
        /// </summary>
        /// <returns>Lista contendo todos os usuários</returns>
        /// <response code="200">Sucesso ao consultar todos os usuários</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            return Ok(Users);
        }

        /// <summary>
        /// Retorna um usuário consultado por seu ID
        /// </summary>
        /// <remarks>
        /// Endpoint para consultar um usuário específico por seu ID.
        /// </remarks>
        /// <param name="id">ID do usuário</param>
        /// <returns>Dados do usuário</returns>
        /// <response code="200">Usuário consultado com sucesso!</response>
        /// <response code="404">Usuário não encontrado!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Usuario> GetByID(string id)
        {
            var user = Users.FirstOrDefault(x => x.IDUsuario == Convert.ToInt32(id));

            if(user != null) return Ok(user);

            return NotFound();
        }
    }
}