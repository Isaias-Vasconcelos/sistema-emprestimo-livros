namespace GerenciamentoEmprestimoLivros.Core.Entities
{
    public class Usuario
    {
        public int Id { get;private set; }
        public string Nome { get;private set; }
        public string Email { get;private set; }
        public string? Senha { get;private set; }

        public Usuario(string nome,string email,string senha) {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Usuario(int id,string nome,string email) {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Usuario(int id, string nome, string email,string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
