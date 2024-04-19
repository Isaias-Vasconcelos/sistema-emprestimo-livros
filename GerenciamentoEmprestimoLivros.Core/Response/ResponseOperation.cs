namespace GerenciamentoEmprestimoLivros.Core.Response
{
    public class ResponseOperation<T>
    {
        public bool IsSuccess { get; set; }
        public string Exception { get; set; }
        public ICollection<T> ManyResult { get; set; } = [];
        public T SingleResult { get; set; }
    }
}

