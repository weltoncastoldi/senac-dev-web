using MeuCorre.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuCorre.Infra.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(
            DbContextOptions<MeuDbContext> opcoes) : base(opcoes)
        {
            //Desabilita o rastreamento de alterações para melhorar a
            //performance em consultas somente leitura.
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        //Define a ligação entre a classe c# com a tabela do DB.
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica as configurações de mapeamento das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MeuDbContext).Assembly);

            // Seed: usuário padrão para desenvolvimento / testes
            var usuarioId = Guid.Parse("da3b9f4c-8e6a-4a4f-9e6b-1c2d3e4f5a6b");

            modelBuilder.Entity<Usuario>().HasData(new
            {
                Id = usuarioId,
                Nome = "Welton Castoldi",
                Email = "weltoncastoldi@hotmail.com",
                Senha = "123456",
                DataNascimento = new DateTime(1985, 7, 6),
                Ativo = true,
                DataCriacao = new DateTime(2025, 1, 1)
            });

            // Seed: categorias para o usuário Welton
            modelBuilder.Entity<Categoria>().HasData(
                new
                {
                    Id = Guid.Parse("9f1e2d3c-4b5a-6c7d-8e9f-0a1b2c3d4e5f"),
                    UsuarioId = usuarioId,
                    Nome = "Moradia",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 2,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                },
                new
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-47a8-9b0c-1d2e3f4a5b6c"),
                    UsuarioId = usuarioId,
                    Nome = "Alimentação",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 2,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                },
                new
                {
                    Id = Guid.Parse("b7c6d5e4-f3a2-41b0-9c8d-7e6f5a4b3c2d"),
                    UsuarioId = usuarioId,
                    Nome = "Saúde",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 2,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                },
                new
                {
                    Id = Guid.Parse("c0d1e2f3-0415-4a6b-8c7d-9e8f7a6b5c4d"),
                    UsuarioId = usuarioId,
                    Nome = "Transporte",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 2,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                },
                new
                {
                    Id = Guid.Parse("d4e5f6a7-b8c9-40d1-8e2f-3a4b5c6d7e8f"),
                    UsuarioId = usuarioId,
                    Nome = "Lazer",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 2,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                },
                new
                {
                    Id = Guid.Parse("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9a0b"),
                    UsuarioId = usuarioId,
                    Nome = "Salário",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 1,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                },
                new
                {
                    Id = Guid.Parse("f1a2b3c4-d5e6-4789-8b0c-2d3e4f5a6b7c"),
                    UsuarioId = usuarioId,
                    Nome = "Outras",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 1,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                },
                new
                {
                    Id = Guid.Parse("0a1b2c3d-4e5f-4678-9a0b-1c2d3e4f5a6b"),
                    UsuarioId = usuarioId,
                    Nome = "Investimentos",
                    Descricao = (string?)null,
                    Cor = (string?)null,
                    Icone = (string?)null,
                    TipoDaTransacao = 1,
                    Ativo = true,
                    DataCriacao = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
