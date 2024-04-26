using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEmprestimoLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;
        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmprestimos()
        {
            var emprestimos = await _emprestimoService.ListarEmprestimos();

            return !string.IsNullOrEmpty(emprestimos.Exception)
                ? BadRequest(emprestimos)
                : Ok(emprestimos);
        }
        [HttpGet("{responsible}")]
        public async Task<IActionResult> GetAllEmprestimosResponsible(string responsible)
        {
            var emprestimosResponsible = await _emprestimoService.ListarEmprestimosPorResponsavel(responsible);

            return !string.IsNullOrEmpty(emprestimosResponsible.Exception)
                ? BadRequest(emprestimosResponsible)
                : Ok(emprestimosResponsible);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmprestimoId(int id)
        {
            var emprestimoPorId = await _emprestimoService.InformacoesEmprestimo(id);

            return !string.IsNullOrEmpty(emprestimoPorId.Exception)
                ? BadRequest(emprestimoPorId)
                : Ok(emprestimoPorId);
        }
        [HttpPost]
        public async Task<IActionResult> PostEmprestimo(AdicionarEmprestimoInputModel adicionarEmprestimoInputModel)
        {
            var criarEmprestimoResponse = await _emprestimoService.CriarEmprestimo(adicionarEmprestimoInputModel);

            return !string.IsNullOrEmpty(criarEmprestimoResponse.Exception)
                ? BadRequest(criarEmprestimoResponse)
                : Ok(criarEmprestimoResponse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteEmprestimo(int id)
        {
            var excluirEmprestimoResponse = await _emprestimoService.ExcluirEmprestimo(id);

            return !string.IsNullOrEmpty(excluirEmprestimoResponse.Exception)
                ? BadRequest(excluirEmprestimoResponse)
                : Ok(excluirEmprestimoResponse);
        }
    }
}
