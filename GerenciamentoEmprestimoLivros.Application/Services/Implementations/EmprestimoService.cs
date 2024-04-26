using AutoMapper;
using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Response;
using GerenciamentoEmprestimoLivros.Application.ViewModel;
using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Repositories;
using GerenciamentoEmprestimoLivros.Infra.Database;
using System.Data;
using System.Text.Json;

namespace GerenciamentoEmprestimoLivros.Application.Services.Implementations
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IMapper _mapper;
        public EmprestimoService(IEmprestimoRepository emprestimoRepository, IMapper mapper)
        {
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
        }
        public async Task<ResponseService<EmprestimoViewModel>> CriarEmprestimo(AdicionarEmprestimoInputModel inputModel)
        {
            var novoEmprestimo = _mapper.Map<Emprestimo>(inputModel);

            var emprestimoCreateResponse = await _emprestimoRepository.Create(novoEmprestimo);

            return emprestimoCreateResponse.IsSuccess ?
                new ResponseService<EmprestimoViewModel>
                {
                    Success = "Emprestimo criado com sucesso!"
                } : new ResponseService<EmprestimoViewModel>
                {
                    Exception = emprestimoCreateResponse.Exception,
                };
        }

        public async Task<ResponseService<EmprestimoViewModel>> ExcluirEmprestimo(int id)
        {
            var excluirEmprestimoRepository = await _emprestimoRepository.Delete(id);

            return excluirEmprestimoRepository.IsSuccess ?
                new ResponseService<EmprestimoViewModel>
                {
                    Success = "Emprestimo excluido com sucesso!"
                } : new ResponseService<EmprestimoViewModel>
                {
                    Exception = excluirEmprestimoRepository.Exception,
                };
        }

        public async Task<ResponseService<EmprestimoViewModel>> InformacoesEmprestimo(int livroId)
        {
            var emprestimoRepository = await _emprestimoRepository.GetEmprestimo(livroId);

            if (emprestimoRepository.IsSuccess)
            {
                var emprestimoViewModel = _mapper.Map<EmprestimoViewModel>(emprestimoRepository.SingleResult);

                return new ResponseService<EmprestimoViewModel>
                {
                    Success = "Informações retornadas com sucesso",
                    SingleResult = emprestimoViewModel
                };
            }

            return new ResponseService<EmprestimoViewModel>
            {
                Exception = emprestimoRepository.Exception,
            };
        }

        public async Task<ResponseService<EmprestimoViewModel>> ListarEmprestimos()
        {
            var emprestimosRepository = await _emprestimoRepository.GetAll();

            if (emprestimosRepository.IsSuccess)
            {
                var emprestimosViewModel = emprestimosRepository.ManyResult.Select(_mapper.Map<EmprestimoViewModel>);

                return new ResponseService<EmprestimoViewModel>
                {
                    Success = "Emprestimos listados com sucesso!",
                    ManyResult = emprestimosViewModel.ToList()
                };
            }

            return new ResponseService<EmprestimoViewModel>
            {
                Exception = emprestimosRepository.Exception,
            };
        }

        public async Task<ResponseService<EmprestimoViewModel>> ListarEmprestimosPorResponsavel(string responsavel)
        {
            var emprestimosRepository = await _emprestimoRepository.GetEmprestimosResponsible(responsavel);

            if (emprestimosRepository.IsSuccess)
            {
                var emprestimosViewModel = emprestimosRepository.ManyResult.Select(_mapper.Map<EmprestimoViewModel>);

                return new ResponseService<EmprestimoViewModel>
                {
                    Success = "Emprestimos listados com sucesso!",
                    ManyResult = emprestimosViewModel.ToList()
                };
            }

            return new ResponseService<EmprestimoViewModel>
            {
                Exception = emprestimosRepository.Exception,
            };
        }
    }
}
