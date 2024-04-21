using GerenciamentoEmprestimoLivros.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEmprestimoLivros.Core.Entities
{
    public class Livro
    {
        public int Id { get; private set; }
        public string UrlImage { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Autor { get; private set; }
        public string Status { get; set; }
        public DateTime DataLancamento { get; private set; }

        public Livro(string urlImage, string titulo, string descricao, string autor, DateTime dataLancamento)
        {
            UrlImage = urlImage;
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            Status = nameof(StatusLivro.DISPONIVEL);
            DataLancamento = dataLancamento;
        }

        public Livro(int id, string urlImage, string titulo, string descricao, string autor,string status, DateTime dataLancamento)
        {
            Id = id;
            UrlImage = urlImage;
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            Status = status;
            DataLancamento = dataLancamento;
        }
    }
}
