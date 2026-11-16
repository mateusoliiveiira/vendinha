using Microsoft.AspNetCore.Mvc;
using Vendinha.Services;

namespace Vendinha.Api.Controllers
{
    [ApiController]
    [Route("api/dividas")]
    public class DividasController : ControllerBase
    {
        private readonly DividaService service;

        public DividasController(DividaService service)
        {
            this.service = service;
        }

        [HttpPut("{id:int}/pagar")]
        public IActionResult Pagar(int id)
        {
            if (!service.MarcarComoPaga(id, out var erros))
            {
                return BadRequest(ClientesController.Erros(erros));
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Excluir(int id)
        {
            if (!service.Excluir(id, out var erros))
            {
                return NotFound(ClientesController.Erros(erros));
            }
            return NoContent();
        }
    }
}
