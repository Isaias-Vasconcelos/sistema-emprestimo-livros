using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEmprestimoLivros.Application.InputModel
{
    public class AtualizarUsuarioInputModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(5, ErrorMessage = "Poucos caracters informados!")]
        public string Nome { get; set; }
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8, ErrorMessage = "Poucos caracters informados!")]
        public string? Senha { get; set; }
    }
}
