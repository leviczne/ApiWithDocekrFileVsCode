using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroAPI.Data;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI.Repositorios
{
    public class UsuariosViagemRepositorio : IUsuariosViagemRepositorio
    {
        private readonly SistemaCadastroDBContex _dbContext;

        public UsuariosViagemRepositorio(SistemaCadastroDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuariosViagemModel> Adicionar(UsuariosViagemModel viagemFeita)
        {
            await _dbContext.UsuariosViagems.AddAsync(viagemFeita);
            await _dbContext.SaveChangesAsync();

            return viagemFeita;
        }

        public async Task<List<UsuariosViagemModel>> BuscarTodasViagensFeitas()
        {
            return await _dbContext.UsuariosViagems.ToListAsync();
        }
    }
}
