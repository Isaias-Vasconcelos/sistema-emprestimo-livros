using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Response;

namespace GerenciamentoEmprestimoLivros.Core.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<ResponseOperation<Emprestimo>> GetAll();
        Task<ResponseOperation<Emprestimo>> GetEmprestimo(int livroId);
        Task<ResponseOperation<Emprestimo>> GetEmprestimosResponsible(string responsible);
        Task<ResponseOperation<Emprestimo>> Create(Emprestimo emprestimo);
        Task<ResponseOperation<Emprestimo>> Delete(int id);
    }
}
