using Microsoft.AspNetCore.Mvc;
using NaoBinariosAPI.Models;

namespace NaoBinariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController: ControllerBase
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

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<Usuario> Get()
        {
            return Users;
        }

        [HttpGet("{id}")]
        public Usuario Get(string id)
        {
            return Users.FirstOrDefault(x => x.IDUsuario == Convert.ToInt32(id));
        }
    }
}