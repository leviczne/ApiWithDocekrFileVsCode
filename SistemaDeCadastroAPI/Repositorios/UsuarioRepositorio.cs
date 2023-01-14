using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroAPI.Data;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Models.DTO_s;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaCadastroDBContex _dbContext;


        public UsuarioRepositorio(SistemaCadastroDBContex sistemaCadastroDBContex)
        {
            _dbContext = sistemaCadastroDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x=> x.Id==id);
        }

        public async Task<List<UsuarioDTO>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.Select(x=> new UsuarioDTO {Name=x.Name, Email = x.Email}).ToListAsync();
        }
         public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {

            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

       
    
    }
}
