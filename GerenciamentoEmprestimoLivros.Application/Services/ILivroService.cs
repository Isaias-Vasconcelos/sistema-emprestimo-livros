using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Response;
using GerenciamentoEmprestimoLivros.Application.ViewModel;

namespace GerenciamentoEmprestimoLivros.Application.Services
{
    public interface ILivroService
    {
        Task<ResponseService<LivroViewModel>> ListarLivros();
        Task<ResponseService<LivroViewModel>> BuscarLivroPorId(int id);
        Task<ResponseService<LivroViewModel>> AdicionarLivro(AdicionarLivroInputModel adicionarLivroInputModel);
        Task<ResponseService<LivroViewModel>> AtualizarLivro(AtualizarLivroInputModel atualizarLivroInputModel);
        Task<ResponseService<LivroViewModel>> ExcluirLivro(int id);
    }
}
