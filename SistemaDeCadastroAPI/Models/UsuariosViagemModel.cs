using System;
using System.Collections.Generic;

namespace SistemaDeCadastroAPI.Models
{
    public partial class UsuariosViagemModel
    {
        public int Id { get; set; }
        public int IdUsuarios { get; set; }
        public int IdViagem { get; set; }

        public virtual UsuarioModel IdUsuariosNavigation { get; set; } = null!;
        public virtual ViagemModel IdViagemNavigation { get; set; } = null!;
    }
}
