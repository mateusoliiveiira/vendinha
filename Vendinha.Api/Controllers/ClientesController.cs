using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha.Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService clienteService;
        private readonly DividaService dividaService;

        public ClientesController(ClienteService clienteService, DividaService dividaService)
        {
            this.clienteService = clienteService;
            this.dividaService = dividaService;
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string? pesquisa, [FromQuery] int pagina = 1)
        {
            return Ok(clienteService.Listar(pesquisa, pagina));
        }

        [HttpGet("{id:int}")]
        public IActionResult Buscar(int id)
        {
            var cliente = clienteService.Buscar(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ClienteRequest request)
        {
            var cliente = ParaCliente(request);
            if (!clienteService.Criar(cliente, out var erros))
            {
                return BadRequest(Erros(erros));
            }
            return CreatedAtAction(nameof(Buscar), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id:int}")]
        public IActionResult Atualizar(int id, [FromBody] ClienteRequest request)
        {
            if (clienteService.Buscar(id) == null) return NotFound();

            if (!clienteService.Atualizar(id, ParaCliente(request), out var erros))
            {
                return BadRequest(Erros(erros));
            }
            return Ok(clienteService.Buscar(id));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Excluir(int id)
        {
            if (!clienteService.Excluir(id, out var erros))
            {
                return NotFound(Erros(erros));
            }
            return NoContent();
        }

        [HttpGet("{id:int}/dividas")]
        public IActionResult ListarDividas(int id)
        {
            if (clienteService.Buscar(id) == null) return NotFound();
            return Ok(dividaService.ListarPorCliente(id));
        }

        [HttpPost("{id:int}/dividas")]
        public IActionResult CriarDivida(int id, [FromBody] DividaRequest request)
        {
            if (clienteService.Buscar(id) == null) return NotFound();

            if (!dividaService.Criar(id, request.Valor, out var erros))
            {
                return BadRequest(Erros(erros));
            }
            return Ok(dividaService.ListarPorCliente(id));
        }

        private static Cliente ParaCliente(ClienteRequest request)
        {
            return new Cliente
            {
                Nome = request.Nome?.Trim() ?? string.Empty,
                Cpf = request.Cpf,
                DataNascimento = request.DataNascimento.Date,
                Email = request.Email
            };
        }

        internal static object Erros(IEnumerable<ValidationResult> erros)
        {
            return new { erros = erros.Select(e => e.ErrorMessage) };
        }
    }
}
