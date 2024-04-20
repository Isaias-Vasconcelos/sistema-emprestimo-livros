using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEmprestimoLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioService.ListarUsuarios();

            if (!string.IsNullOrEmpty(usuarios.Exception)) return BadRequest(usuarios);
            
            return Ok(usuarios);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(id);

            if (!string.IsNullOrEmpty(usuario.Exception)) return BadRequest(usuario);
            
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<IActionResult> PostUsuario(AdicionarUsuarioInputModel usuarioInputModel)
        {
            var usuarioCriado = await _usuarioService.CriarUsuario(usuarioInputModel);

            if (!string.IsNullOrEmpty(usuarioCriado.Exception)) return BadRequest(usuarioCriado);
            
            return Ok(usuarioCriado);
        }
        [HttpPut]
        public async Task<IActionResult> PutUsuario(AtualizarUsuarioInputModel atualizarUsuarioInputModel)
        {
            var usuarioAtualizado = await _usuarioService.AtualizarUsuario(atualizarUsuarioInputModel);

            if (!string.IsNullOrEmpty(usuarioAtualizado.Exception)) return BadRequest(usuarioAtualizado);

            return Ok(usuarioAtualizado);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuarioExcluido = await _usuarioService.ExcluirUsuario(id);

            if (!string.IsNullOrEmpty(usuarioExcluido.Exception)) return BadRequest(usuarioExcluido);

            return Ok(usuarioExcluido);
        }
    }
}
