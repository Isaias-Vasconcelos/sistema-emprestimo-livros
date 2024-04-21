using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Response;

namespace GerenciamentoEmprestimoLivros.Core.Repositories
{
    public interface ILivroRepository
    {
        Task<ResponseOperation<Livro>> GetAll();
        Task<ResponseOperation<Livro>> GetById(int id);
        Task<ResponseOperation<Livro>> Create(Livro livro);
        Task<ResponseOperation<Livro>> Update(Livro livro);
        Task<ResponseOperation<Livro>> Delete(int id);
    }
}
