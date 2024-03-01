namespace NaoBinariosAPI.Models
{
    public class Usuario
    {
        public required int IDUsuario { get; set; }
        public required string Nome { get; set; }
        public int Idade { get; set; }
        public string? Profissao { get; set; }
        public int IdadeEmMeses => Idade * 12;
    }
}