using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace PessoasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PessoasController : ControllerBase
    {
        private readonly PessoaService _service;

        public PessoasController(PessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            var Pessoas = _service.GetAll();
            return Ok(Pessoas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            var Pessoa = _service.GetByID(id);

            if (Pessoa is null)
                return NotFound(new { message = $"Pessoa de {id} não encontrada!" });

            return Ok(Pessoa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            try
            {
                _service.Save(pessoa);
                return Created();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            try
            {
                _service.Update(pessoa);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idPessoa}")]
        public IActionResult Delete(int idPessoa)
        {
            try
            {
                _service.Delete(idPessoa);
                return Ok("Excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}