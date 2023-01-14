using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastroAPI.Models.DTO_s
{
    public class UsuarioDTO
    {
        
  
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<ViagemModel> Viagems { get; set; }
    }
}
