using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEmprestimoLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLivros()
        {
            var livros = await _livroService.ListarLivros();

            return !string.IsNullOrEmpty(livros.Exception)
                ? BadRequest(livros)
                : Ok(livros);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLivro(int id)
        {
            var livro = await _livroService.BuscarLivroPorId(id);

            return !string.IsNullOrEmpty(livro.Exception)
                ? BadRequest(livro)
                : Ok(livro);
        }
        [HttpPost]
        public async Task<IActionResult> PostLivro(AdicionarLivroInputModel adicionarLivroInputModel)
        {
            var livroCreateResponse = await _livroService.AdicionarLivro(adicionarLivroInputModel);

            return !string.IsNullOrEmpty(livroCreateResponse.Exception)
                ? BadRequest(livroCreateResponse)
                : Ok(livroCreateResponse);
        }
        [HttpPut]
        public async Task<IActionResult> PutLivro(AtualizarLivroInputModel atualizarLivroInputModel)
        {
            var livroUpdateResponse = await _livroService.AtualizarLivro(atualizarLivroInputModel);

            return !string.IsNullOrEmpty(livroUpdateResponse.Exception)
                ? BadRequest(livroUpdateResponse)
                : Ok(livroUpdateResponse);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livroDeleteResponse = await _livroService.ExcluirLivro(id);

            return !string.IsNullOrEmpty(livroDeleteResponse.Exception)
                ? BadRequest(livroDeleteResponse)
                : Ok(livroDeleteResponse);
        }
    }
}
