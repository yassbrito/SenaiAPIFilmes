using api_filmes_senai.Domains;
using api_filmes_senai.interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filmes> listaDeFilmes = _filmeRepository.Listar();

                return Ok(listaDeFilmes);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(Filmes novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filmes filmesBuscados = _filmeRepository.BuscarPorId(id);
                return Ok(filmesBuscados);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Filmes filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
