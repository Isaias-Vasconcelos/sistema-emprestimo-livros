using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Response;
using GerenciamentoEmprestimoLivros.Application.ViewModel;

namespace GerenciamentoEmprestimoLivros.Application.Services
{
    public interface IEmprestimoService
    {
        Task<ResponseService<EmprestimoViewModel>> ListarEmprestimos();
        Task<ResponseService<EmprestimoViewModel>> ListarEmprestimosPorResponsavel(string responsavel);
        Task<ResponseService<EmprestimoViewModel>> InformacoesEmprestimo(int id);
        Task<ResponseService<EmprestimoViewModel>> CriarEmprestimo(AdicionarEmprestimoInputModel inputModel);
        Task<ResponseService<EmprestimoViewModel>> ExcluirEmprestimo(int id);
    }
}
