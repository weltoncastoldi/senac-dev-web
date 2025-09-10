using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;

namespace MeuCorre.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task CriarUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task RemoverUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
