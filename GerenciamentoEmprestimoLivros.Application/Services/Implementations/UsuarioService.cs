using AutoMapper;
using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Response;
using GerenciamentoEmprestimoLivros.Application.ViewModel;
using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Repositories;

namespace GerenciamentoEmprestimoLivros.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<ResponseService<UsuarioViewModel>> ListarUsuarios()
        {
            var usuariosRepositoryResponse = await _usuarioRepository.GetAll();

            if (usuariosRepositoryResponse.IsSuccess)
            {
                var usuariosViewModel = usuariosRepositoryResponse.ManyResult.Select(_mapper.Map<UsuarioViewModel>);

                return new ResponseService<UsuarioViewModel>
                {
                    Success = "Listagem realizada com sucesso!",
                    ManyResult = usuariosViewModel.ToList()
                };
            }
            else
            {
                return new ResponseService<UsuarioViewModel>
                {
                    Exception = usuariosRepositoryResponse.Exception
                };
            }
        }
        public async Task<ResponseService<UsuarioViewModel>> BuscarUsuarioPorId(int id)
        {
            var usuarioRepositoryResponse = await _usuarioRepository.GetById(id);

            if (usuarioRepositoryResponse.IsSuccess)
            {
                var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuarioRepositoryResponse.SingleResult);

                return new ResponseService<UsuarioViewModel>
                {
                    Success = "Usuário recuperado com sucesso",
                    SingleResult = usuarioViewModel
                };
            }
            else
            {
                return new ResponseService<UsuarioViewModel>
                {
                    Exception = usuarioRepositoryResponse.Exception
                };
            }
        }
        public async Task<ResponseService<UsuarioViewModel>> CriarUsuario(AdicionarUsuarioInputModel input)
        {
            var usuarioEntity = _mapper.Map<Usuario>(input);

            var usuarioCreateResponse = await _usuarioRepository.Save(usuarioEntity);

            if (usuarioCreateResponse.IsSuccess)
            {
                return new ResponseService<UsuarioViewModel>
                {
                    Success = "Usuário criado com sucesso!"
                };
            }
            else
            {
                return new ResponseService<UsuarioViewModel>
                {
                    Exception = usuarioCreateResponse.Exception
                };
            }
        }
        public async Task<ResponseService<UsuarioViewModel>> AtualizarUsuario(AtualizarUsuarioInputModel input)
        {
            var usuarioEntity = _mapper.Map<Usuario>(input);

            var usuarioUpdateResponse = await _usuarioRepository.Update(usuarioEntity);

            if (usuarioUpdateResponse.IsSuccess)
            {
                return new ResponseService<UsuarioViewModel>
                {
                    Success = "Usuário atualizado com sucesso"
                };
            }
            else
            {
                return new ResponseService<UsuarioViewModel>
                {
                    Exception = usuarioUpdateResponse.Exception
                };

            }
        }
    }
}
