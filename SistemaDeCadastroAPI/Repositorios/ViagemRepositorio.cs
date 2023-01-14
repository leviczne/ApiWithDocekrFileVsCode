using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroAPI.Data;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Models.DTO_s;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI.Repositorios
{
    public class ViagemRepositorio : IViagemRepositorio
    {
        private readonly SistemaCadastroDBContex _dbContext;

        public ViagemRepositorio(SistemaCadastroDBContex sistemaCadastroDBContex)
        {
            _dbContext = sistemaCadastroDBContex;
        }
        public async Task<List<ViagemModel>> BuscarTodasViagens()
        {
            return await _dbContext.Viagems.ToListAsync();
        }
        public async Task<ViagemModel> Adicionar(ViagemModel viagem) 
        {
            object value = await _dbContext.Viagems.AddAsync(viagem);
            await _dbContext.SaveChangesAsync();

            return viagem;
        }
    }
}
