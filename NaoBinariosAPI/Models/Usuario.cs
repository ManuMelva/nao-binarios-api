using System.ComponentModel.DataAnnotations;

namespace NaoBinariosAPI.Models
{
    public class Usuario
    {
        public required int IDUsuario { get; set; }

        [Required(ErrorMessage = "O atributo Nome não pode ser nulo")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O atributo Idade não pode ser nulo")]
        public int Idade { get; set; }

        public string? Profissao { get; set; }

        public int IdadeEmMeses => Idade * 12;
    }
}