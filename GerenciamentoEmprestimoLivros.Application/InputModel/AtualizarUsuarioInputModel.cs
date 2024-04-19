using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
