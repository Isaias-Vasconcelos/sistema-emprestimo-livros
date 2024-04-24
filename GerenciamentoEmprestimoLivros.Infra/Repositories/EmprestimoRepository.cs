using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Repositories;
using GerenciamentoEmprestimoLivros.Core.Response;

namespace GerenciamentoEmprestimoLivros.Infra.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        public Task<ResponseOperation<Emprestimo>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<ResponseOperation<Emprestimo>> GetEmprestimoResponsible(string responsible)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseOperation<Emprestimo>> GetEmprestimo(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseOperation<Emprestimo>> Create(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseOperation<Emprestimo>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
