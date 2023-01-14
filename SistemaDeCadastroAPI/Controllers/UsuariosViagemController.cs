
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Repositorios;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosViagemController : ControllerBase
    {
        private readonly IUsuariosViagemRepositorio _usuariosViagemRepositorio;

        public UsuariosViagemController (IUsuariosViagemRepositorio usuariosViagemRepositorio){
           _usuariosViagemRepositorio = usuariosViagemRepositorio;

        }

        [HttpGet]
        public async Task<ActionResult<List<UsuariosViagemModel>>> BuscasTodasViagensFeitas()
        {
            List<UsuariosViagemModel> usuariosViagem = await _usuariosViagemRepositorio.BuscarTodasViagensFeitas();
            return Ok(usuariosViagem);
        }

        [HttpPost]
        public async Task<ActionResult<UsuariosViagemModel>> Cadastrar([FromBody] UsuariosViagemModel usuariosViagemModel)
        {
            UsuariosViagemModel usuariosViagem = await _usuariosViagemRepositorio.Adicionar(usuariosViagemModel);
            return Ok(usuariosViagem);
        }


    }
}
