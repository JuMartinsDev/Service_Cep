using Microsoft.AspNetCore.Mvc;
using ServicoCepAtividade.Domain;
using ServicoCepAtividade.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoCepAtividade.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpPost]
        public async Task<ActionResult<Cep>> PostCep([FromBody] string cep)
        {
            var result = await _cepService.ConsultarCepAsync(cep);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Cep>>> GetCeps()
        {
            var result = await _cepService.GetAllCepsAsync();
            return Ok(result);
        }
    }
}
