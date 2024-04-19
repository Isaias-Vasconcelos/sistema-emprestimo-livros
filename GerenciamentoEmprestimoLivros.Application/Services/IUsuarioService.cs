using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Response;
using GerenciamentoEmprestimoLivros.Application.ViewModel;

namespace GerenciamentoEmprestimoLivros.Application.Services
{
    public interface IUsuarioService
    {
        Task<ResponseService<UsuarioViewModel>> ListarUsuarios();
        Task<ResponseService<UsuarioViewModel>> BuscarUsuarioPorId(int id);
        Task<ResponseService<UsuarioViewModel>> CriarUsuario(AdicionarUsuarioInputModel input);
        Task<ResponseService<UsuarioViewModel>> AtualizarUsuario(AtualizarUsuarioInputModel input);
    }
}
