using Microsoft.AspNetCore.Mvc;
using myProject.Model;
using myProject.Repository;

namespace myProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll(){
            var usuarios = await _repository.GetUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.GetUsuarioById(id);
            return usuario != null
            ? Ok(usuario) : NotFound("Usuário não encontrado.");
        }

        [HttpPost]
        
        public async Task<IActionResult> Post(Usuario usuario){
            _repository.AddUsuario(usuario);
            return await _repository.SaveChangesAsync()
            ? Ok("Usuário adicionado") : BadRequest("Algo deu errado.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Usuario usuario)
        {
            var usuarioExiste = await _repository.GetUsuarioById(id);
            if (usuarioExiste == null) return NotFound("Usuário não encontrado");

            usuarioExiste.Nome = usuario.Nome ?? usuarioExiste.Nome;
            usuarioExiste.DataNascimento = usuario.DataNascimento != new DateTime()
            ? usuario.DataNascimento : usuarioExiste.DataNascimento;

            _repository.AtualizarUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário atualizado.") : BadRequest("Algo deu errado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioExiste = await _repository.GetUsuarioById(id);
            if (usuarioExiste == null)
                return NotFound("Usuário não encontrado");

            _repository.DeletarUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário deletado.") : BadRequest("Algo deu errado.");
        }
    }
}