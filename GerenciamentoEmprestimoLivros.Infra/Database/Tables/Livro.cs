using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEmprestimoLivros.Infra.Database.Tables
{
    public class Livro
    {
        public string Id { get; private set; } = "int not null AUTO_INCREMENT";
        public string UrlImage { get; private set; } = "text not null";
        public string Titulo { get; private set; } = "varchar(255) not null";
        public string Descricao { get; private set; } = "text not null";
        public string Autor { get; private set; } = "varchar(255) not null";
        public string Status { get; private set; } = "varchar(255) not null";
        public string DataLancamento { get; private set; } = "timestamp not null";
    }
}
