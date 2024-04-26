using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEmprestimoLivros.Application.InputModel
{
    public class AdicionarEmprestimoInputModel
    {
        [Required]
        public int LivroId { get;set; }
        [Required,MinLength(5)]
        public string Responsavel { get;  set; }
        [Required,DataType(DataType.PhoneNumber)]
        public string Telefone { get;  set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime EmprestadoEm { get;  set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime PrazoEntrega { get;  set; }
    }
}
