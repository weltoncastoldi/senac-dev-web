using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
using MeuCorre.Domain.Interfaces.Repositories;

namespace MeuCorre.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public Task<Categoria> ObterPorIdAsync(Guid categoriaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> ListarTodasPorUsuarioAsync(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteAsync(Guid categoriaId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> NomeExisteParaUsuarioAsync(string nome, TipoTransacao tipo, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task AdicionarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
