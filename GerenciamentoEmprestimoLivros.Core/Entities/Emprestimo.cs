namespace GerenciamentoEmprestimoLivros.Core.Entities
{
    public class Emprestimo
    {
        public int Id { get; private set; }
        public int LivroId { get;private set; }
        public string Responsavel { get;private set; }
        public string Telefone { get;private set; }
        public DateTime EmprestadoEm { get;private set; }
        public DateTime PrazoEntrega { get;private set; }

        public Emprestimo(int id,int livroId, string responsavel, string telefone, DateTime emprestadoEm, DateTime prazoEntrega)
        {
            Id = id;
            LivroId = livroId;
            Responsavel = responsavel;
            Telefone = telefone;
            EmprestadoEm = emprestadoEm;
            PrazoEntrega = prazoEntrega;
        }
        public Emprestimo(int livroId,string responsavel,string telefone,DateTime emprestadoEm, DateTime prazoEntrega)
        {
            LivroId = livroId;
            Responsavel = responsavel;
            Telefone = telefone;
            EmprestadoEm = emprestadoEm;
            PrazoEntrega = prazoEntrega;
        }
    }
}
