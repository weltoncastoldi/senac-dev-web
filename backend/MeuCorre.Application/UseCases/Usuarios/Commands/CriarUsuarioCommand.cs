using System.ComponentModel.DataAnnotations;
using MediatR;

namespace MeuCorre.Application.UseCases.Usuarios.Commands
{
    /// <summary>
    /// Comando para criar um novo usuário.
    /// Aqui você pode adicionar propriedades necessárias para criar o usuário
    /// </summary>
    public class CriarUsuarioCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }
    }

    internal class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, string>
    {
        public Task<string> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
