namespace GerenciamentoEmprestimoLivros.Infra.Database.Tables
{
    public class Emprestimo
    {
        public string Id { get; private set; } = "int not null AUTO_INCREMENT";
        public string LivroId { get; private set; } = "int not null";
        public string Responsavel { get; private set; } = "varchar(255) not null";
        public string Telefone { get; private set; } = "varchar(255) not null";
        public string EmprestadoEm { get; private set; } = "timestamp not null";
        public string PrazoEntrega { get; private set; } = "timestamp not null";
    }
}
