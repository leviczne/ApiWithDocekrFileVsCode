using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Models.DTO_s;
using SistemaDeCadastroAPI.Repositorios;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly IViagemRepositorio _viagemRepositorio;
        public ViagemController(IViagemRepositorio viagemRepositorio)
        {
            _viagemRepositorio = viagemRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> BuscasTodasViagens()
        {
            List<ViagemModel> viagens = await _viagemRepositorio.BuscarTodasViagens();
            return Ok(viagens);
        }

        [HttpPost]
        public async Task<ActionResult<ViagemModel>> Cadastrar([FromBody] ViagemModel viagemModel)
        {
             ViagemModel viagem = await _viagemRepositorio.Adicionar(viagemModel);
             return Ok(viagem);
        }
    }
}
