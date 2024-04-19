namespace GerenciamentoEmprestimoLivros.Application.Response
{
    public class ResponseService<T>
    {
        public string Success { get; set; }
        public string Exception { get; set; }
        public ICollection<T> ManyResult { get; set; } = [];
        public T SingleResult { get; set; }
    }
}

