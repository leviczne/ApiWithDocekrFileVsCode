using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Models.DTO_s;

namespace SistemaDeCadastroAPI.Repositorios.Intefaces
{
    public interface IViagemRepositorio
    {

        Task<List<ViagemModel>> BuscarTodasViagens();

        Task<ViagemModel> Adicionar(ViagemModel viagem);
    }
}
