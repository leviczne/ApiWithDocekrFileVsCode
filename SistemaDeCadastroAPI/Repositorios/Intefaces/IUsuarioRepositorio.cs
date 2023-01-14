using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Models.DTO_s;

namespace SistemaDeCadastroAPI.Repositorios.Intefaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioDTO>>BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario,int id);
        Task<bool> Apagar(int id);
         
    }
}
