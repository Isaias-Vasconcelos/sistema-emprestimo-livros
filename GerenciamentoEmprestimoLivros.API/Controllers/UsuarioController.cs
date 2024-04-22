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

            return !string.IsNullOrEmpty(usuarios.Exception)
                 ? BadRequest(usuarios)
                 : Ok(usuarios);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(id);

            return !string.IsNullOrEmpty(usuario.Exception)
                 ? BadRequest(usuario)
                 : Ok(usuario);

        }
        [HttpPost]
        public async Task<IActionResult> PostUsuario(AdicionarUsuarioInputModel usuarioInputModel)
        {
            var usuarioCriado = await _usuarioService.CriarUsuario(usuarioInputModel);

            return !string.IsNullOrEmpty(usuarioCriado.Exception)
                ? BadRequest(usuarioCriado)
                : Ok(usuarioCriado);
        }
        [HttpPut]
        public async Task<IActionResult> PutUsuario(AtualizarUsuarioInputModel atualizarUsuarioInputModel)
        {
            var usuarioAtualizado = await _usuarioService.AtualizarUsuario(atualizarUsuarioInputModel);

            return !string.IsNullOrEmpty(usuarioAtualizado.Exception) 
                ? BadRequest(usuarioAtualizado) 
                : Ok(usuarioAtualizado);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuarioExcluido = await _usuarioService.ExcluirUsuario(id);

            return !string.IsNullOrEmpty(usuarioExcluido.Exception) 
                ? BadRequest(usuarioExcluido) 
                : Ok(usuarioExcluido);
        }
    }
}
