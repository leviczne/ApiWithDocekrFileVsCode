using SistemaDeCadastroAPI.Models;

namespace SistemaDeCadastroAPI.Repositorios.Intefaces
{
    public interface IUsuariosViagemRepositorio
    {
        Task<List<UsuariosViagemModel>> BuscarTodasViagensFeitas();
        Task<UsuariosViagemModel> Adicionar(UsuariosViagemModel viagemFeita);

    }
}
