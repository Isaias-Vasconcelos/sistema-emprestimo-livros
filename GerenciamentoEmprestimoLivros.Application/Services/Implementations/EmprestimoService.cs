using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Response;
using GerenciamentoEmprestimoLivros.Application.ViewModel;

namespace GerenciamentoEmprestimoLivros.Application.Services.Implementations
{
    public class EmprestimoService : IEmprestimoService
    {
        public Task<ResponseService<EmprestimoViewModel>> CriarEmprestimo(AdicionarEmprestimoInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<EmprestimoViewModel>> ExcluirEmprestimo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<EmprestimoViewModel>> InformacoesEmprestimo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<EmprestimoViewModel>> ListarEmprestimos()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<EmprestimoViewModel>> ListarEmprestimosPorResponsavel(string responsavel)
        {
            throw new NotImplementedException();
        }
    }
}
