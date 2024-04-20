namespace GerenciamentoEmprestimoLivros.Infra.Database.Tables
{
    public class Usuario
    {
        public string Id { get; private set; } = "int not null AUTO_INCREMENT";
        public string Nome { get; private set; } = "varchar(50) not null";
        public string Email { get; private set; } = "varchar(150) not null";
        public string Senha { get; private set; } = "varchar(255) not null";
    }
}
