using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEmprestimoLivros.Application.InputModel
{
    public class AdicionarLivroInputModel
    {
        [Required,DataType(DataType.ImageUrl)]
        public string UrlImage { get; set; }
        [Required,MinLength(2)]
        public string Titulo { get;  set; }
        [Required, MinLength(10, ErrorMessage = "Descrição inválida!")]
        public string Descricao { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required, DataType(DataType.DateTime,ErrorMessage = "Formato de data inválido")]
        public DateTime DataLancamento { get; set; }
    }
}
