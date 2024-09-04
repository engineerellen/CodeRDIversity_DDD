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
        private readonly IRepository<Pessoa> _repository;

        public PessoasController(PessoaService service
                               , IRepository<Pessoa> repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
           var Pessoas = _repository.GetAll();
            return Ok(Pessoas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            var Pessoa = _repository.GetById(id);

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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            try
            {
                pessoa.ID = id;
                _service.Save(pessoa);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}