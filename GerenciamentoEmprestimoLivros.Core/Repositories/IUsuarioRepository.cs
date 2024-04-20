using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Response;

namespace GerenciamentoEmprestimoLivros.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<ResponseOperation<Usuario>> GetAll();
        Task<ResponseOperation<Usuario>> GetById(int id);
        Task<ResponseOperation<Usuario>> Save(Usuario usuario);
        Task<ResponseOperation<Usuario>> Update(Usuario usuario);
        Task<ResponseOperation<Usuario>> Delete(int id);
    }
}
