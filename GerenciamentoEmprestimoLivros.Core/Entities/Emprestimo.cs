namespace GerenciamentoEmprestimoLivros.Core.Entities
{
    public class Emprestimo(int livroId,string responsavel,string telefone,DateTime emprestadoEm, DateTime prazoEntrega)
    {
        public int Id { get; private set; }
        public int LivroId { get;private set; } = livroId;
        public string Responsavel { get;private set; } = responsavel;
        public string Telefone { get;private set; } = telefone;
        public DateTime EmprestadoEm { get;private set; } = emprestadoEm;
        public DateTime PrazoEntrega { get;private set; } = prazoEntrega;
    }
}
