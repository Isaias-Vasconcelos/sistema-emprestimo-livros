using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEmprestimoLivros.Application.ViewModel
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        public string UrlImage { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public DateTime DataLancamento { get;set; }
    }
}
