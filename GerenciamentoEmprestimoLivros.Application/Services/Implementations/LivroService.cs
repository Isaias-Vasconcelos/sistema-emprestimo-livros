using AutoMapper;
using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Response;
using GerenciamentoEmprestimoLivros.Application.ViewModel;
using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEmprestimoLivros.Application.Services.Implementations
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivroService(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }
        public async Task<ResponseService<LivroViewModel>> ListarLivros()
        {
            var livrosRepository = await _livroRepository.GetAll();

            if (livrosRepository.IsSuccess)
            {
                var livrosViewModel = livrosRepository.ManyResult.Select(_mapper.Map<LivroViewModel>);

                return new ResponseService<LivroViewModel>
                {
                    Success = "Livros listados com sucesso!",
                    ManyResult = livrosViewModel.ToList()
                };
            }

            return new ResponseService<LivroViewModel>
            {
                Exception = livrosRepository.Exception
            };
        }
        public async Task<ResponseService<LivroViewModel>> BuscarLivroPorId(int id)
        {
            var livroRepository = await _livroRepository.GetById(id);

            if (livroRepository.IsSuccess)
            {
                var livroViewModel = _mapper.Map<LivroViewModel>(livroRepository.SingleResult);

                return new ResponseService<LivroViewModel>
                {
                    Success = "Livro recuperado com sucesso",
                    SingleResult = livroViewModel
                };
            }

            return new ResponseService<LivroViewModel>
            {
                Exception = livroRepository.Exception
            };
        }
        public async Task<ResponseService<LivroViewModel>> AdicionarLivro(AdicionarLivroInputModel adicionarLivroInputModel)
        {
            var livroEntity = _mapper.Map<Livro>(adicionarLivroInputModel);

            var livroCreateResponse = await _livroRepository.Create(livroEntity);

            return livroCreateResponse.IsSuccess ?
                new ResponseService<LivroViewModel>
                {
                    Success = "Livro adicionado com sucesso!"
                } : new ResponseService<LivroViewModel>
                {
                    Exception = livroCreateResponse.Exception
                };
        }

        public async Task<ResponseService<LivroViewModel>> AtualizarLivro(AtualizarLivroInputModel atualizarLivroInputModel)
        {
            var livroEntity = _mapper.Map<Livro>(atualizarLivroInputModel);

            var livroUpdateResponse = await _livroRepository.Update(livroEntity);

            return livroUpdateResponse.IsSuccess ?
                new ResponseService<LivroViewModel>
                {
                    Success = "Livro atualizado com sucesso!"
                } : new ResponseService<LivroViewModel>
                {
                    Exception = livroUpdateResponse.Exception
                };
        }
        public async Task<ResponseService<LivroViewModel>> ExcluirLivro(int id)
        {
            var livroDeleteResponse = await _livroRepository.Delete(id);

            return livroDeleteResponse.IsSuccess ?
                new ResponseService<LivroViewModel>
                {
                    Success = "Livro excluido com sucesso!"
                } : new ResponseService<LivroViewModel>
                {
                    Exception = livroDeleteResponse.Exception
                };
        }
    }
}
