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

        private static int RetornaUltimoID() => Users.Last().IDUsuario + 1;

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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public ActionResult<Usuario> GetByID(string id)
        {
            var user = Users.FirstOrDefault(x => x.IDUsuario == Convert.ToInt32(id));

            if (user != null) return Ok(user);

            return NotFound(new ErrorResponse{Errors = [new ErrorModel{ErrorMessage = "Usuário não encontrado"}]});
        }

        /// <summary>
        /// Atualiza um usuário por ID passado por parametro.
        /// </summary>
        /// <remarks>
        /// Endpoint para atualizar um usuário.
        /// </remarks>
        /// <param name="id">ID do usuário</param>
        /// <param name="editUsuario">Objeto usuário</param>
        /// <returns>Dados do usuário</returns>
        /// <response code="200">Usuário alterado com sucesso!</response>
        /// <response code="404">Usuário não encontrado!</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public ActionResult<Usuario> PutByID(string id, Usuario editUsuario)
        {
            var user = Users.FirstOrDefault(x => x.IDUsuario == Convert.ToInt32(id));

            if (user != null)
            {
                editUsuario.IDUsuario = RetornaUltimoID();
                Users.Remove(user);
                Users.Add(editUsuario);
                return Ok(editUsuario);
            }

            return NotFound(new ErrorResponse{Errors = [new ErrorModel{ErrorMessage = "Usuário não encontrado"}]});
        }

        /// <summary>
        /// Insere um usuário novo na API.
        /// </summary>
        /// <remarks>
        /// Endpoint para inserir um usuário.
        /// </remarks>
        /// <param name="novoUsuario">Objeto usuário</param>
        /// <returns>Dados do usuário</returns>
        /// <response code="200">Usuário inserido com sucesso!</response>
        /// <response code="400">Falha na inserção!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<Usuario> PostUsuario(Usuario novoUsuario)
        {
            if (novoUsuario == null)
            {
                return BadRequest(new ErrorResponse { Errors = [new ErrorModel { ErrorMessage = "O usuário enviado é inválido" }] });
            }

            if(!VerifyName(novoUsuario.Nome))
            {
                return BadRequest(new ErrorResponse { Errors = [new ErrorModel { ErrorMessage = "Já existe um usuário com este nome." }] });
            }

            novoUsuario.IDUsuario = RetornaUltimoID();
            Users.Add(novoUsuario);

            return CreatedAtAction(nameof(GetByID), new { id = novoUsuario.IDUsuario }, novoUsuario);
        }

        private static bool VerifyName(string name)
        {
            if (Users.Any(user => user.Nome.Equals(name)))
            {
                return false;
            }

            return true;
        }
    }
}
