namespace GerenciamentoEmprestimoLivros.Application.ViewModel
{
    public class EmprestimoViewModel
    {
        public int LivroId { get; set; }   
        public string Responsavel { get; set; }
        public string Telefone { get; set; }
        public DateTime EmprestadoEm { get; set; }
        public DateTime PrazoEntrega { get; set; }
    }
}
