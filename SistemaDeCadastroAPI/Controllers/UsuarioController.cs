﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Models.DTO_s;
using SistemaDeCadastroAPI.Repositorios.Intefaces;
using System.Collections.Generic;
using System.Net;

namespace SistemaDeCadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    
    public class UsuarioController : ControllerBase
    {
       private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
  
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> BuscasTodosUsuarios()
        {
          List<UsuarioDTO> usuarios=  await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            if (usuario == null)
            {
                throw new Exception("O usuário com este ID nao existe");
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpGet("nome")]
        public async Task<ActionResult<UsuarioModel>> BuscarViagens(string nome)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarViagens(nome);
            List<String> NomesViagens = new List<String>(); 
            foreach (var Viagem in usuario.UsuariosViagems)
            {
                NomesViagens.Add(Viagem.IdViagemNavigation.NomeViagem);
            }

            return Ok(NomesViagens);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody]UsuarioModel usuarioModel)
        {
           UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
           return Ok(usuario);
        }
       
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel,int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel,id);
            return Ok(usuario);
        }
       

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }


    }
}
