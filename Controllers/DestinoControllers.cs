using Microsoft.AspNetCore.Mvc;
using myProject.Model;
using myProject.Repository;

namespace myProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinoController : ControllerBase
    {

        private readonly IDestinoRepository _repository;

        public DestinoController(IDestinoRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll(){
            var destino = await _repository.GetDestinos();
            return destino.Any() ? Ok(destino) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var destino = await _repository.GetDestinosById(id);
            return destino != null
            ? Ok(destino) : NotFound("Destino não encontrado.");
        }

        [HttpPost]
        
        public async Task<IActionResult> Post(Destino destino){
            _repository.AddDestinos(destino);
            return await _repository.SaveChangesAsync()
            ? Ok("Destino adicionado") : BadRequest("Destino deu errado.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Destino destino)
        {
            var destinoExiste = await _repository.GetDestinosById(id);
            if (destinoExiste == null) return NotFound("Destino não encontrado");

            destinoExiste.destino = destino.destino ?? destinoExiste.destino;
            destinoExiste.checkIn = destino.checkIn != new DateTime()
            ? destino.checkIn : destinoExiste.checkIn;
            destinoExiste.checkOut = destino.checkOut != new DateTime()
            ? destino.checkOut : destinoExiste.checkOut;

            _repository.AtualizarDestinos(destinoExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Destino atualizado.") : BadRequest("Algo deu errado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var destinoExiste = await _repository.GetDestinosById(id);
            if (destinoExiste == null)
                return NotFound("estino não encontrado");

            _repository.DeletarDestinos(destinoExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Destino deletado.") : BadRequest("Algo deu errado.");
        }
    }
}