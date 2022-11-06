using Microsoft.AspNetCore.Mvc;
using myProject.Model;
using myProject.Repository;

namespace myProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        
        public async Task<IActionResult> GetAll(){
            var cliente = await _repository.GetCliente();
            return cliente.Any() ? Ok(cliente) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _repository.GetClienteById(id);
            return cliente != null
            ? Ok(cliente) : NotFound("Cliente não encontrado.");
        }

        [HttpPost]
        
        public async Task<IActionResult> Post(Cliente cliente){
            _repository.AddCliente(cliente);
            return await _repository.SaveChangesAsync()
            ? Ok("Cliente adicionado") : BadRequest("Algo deu errado.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Cliente cliente)
        {
            var clienteExiste = await _repository.GetClienteById(id);
            if (clienteExiste == null) return NotFound("Cliente não encontrado");

            clienteExiste.TipoPessoa = cliente.TipoPessoa ?? clienteExiste.TipoPessoa;
            clienteExiste.Nome = cliente.Nome ?? clienteExiste.Nome;
            clienteExiste.CpfCnpj = cliente.CpfCnpj ?? clienteExiste.CpfCnpj;
            clienteExiste.Endereco = cliente.Endereco ?? clienteExiste.Endereco;
            clienteExiste.Cidade = cliente.Cidade ?? clienteExiste.Cidade;
            clienteExiste.UfEstado = cliente.UfEstado ?? clienteExiste.UfEstado;
            clienteExiste.Telefone = cliente.Telefone ?? clienteExiste.Telefone;
            clienteExiste.Email = cliente.Email ?? clienteExiste.Email;
            clienteExiste.Mensagem = cliente.Mensagem ?? clienteExiste.Mensagem;
            
            

            _repository.AtualizarCliente(clienteExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Cliente atualizado.") : BadRequest("Algo deu errado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteExiste = await _repository.GetClienteById(id);
            if (clienteExiste == null)
                return NotFound("Cliente não encontrado");

            _repository.DeletarCliente(clienteExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Cliente deletado.") : BadRequest("Algo deu errado.");
        }
    }
}