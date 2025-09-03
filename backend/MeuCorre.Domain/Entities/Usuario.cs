﻿namespace MeuCorre.Domain.Entities
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }

        //Construtor para criar um novo usuário.
        //Construtor é a primeira coisa que é executada quando uma classe é instanciada.
        public Usuario(string nome, string email, string senha, DateTime dataNascimento, bool ativo)
        {

            if (!TemIdadeMinima())
            {
                throw new Exception("Usuário deve ter no mínimo 13 anos.");
            }

            Nome = nome;
            Email = email;
            Senha = ValidarSenha(senha);
            DataNascimento = dataNascimento;
            Ativo = ativo;
        }

        //Regra negocio: Permite apenas usários maiores de 13 anos.
        private int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }

        private bool TemIdadeMinima()
        {
            var resultado = CalcularIdade() >= 13;
            return resultado;
        }

        public string ValidarSenha(string senha)
        {
            if (senha.Length < 6)
            {
                //Todo Fazer um tratamento de erro melhor
            }
            return senha;
        }

        public void AtivarUsuario()
        {
            Ativo = true;
            AtualizarDataMoficacao();
        }

        public void InativarUsuario()
        {
            Ativo = false;
            AtualizarDataMoficacao();
        }
    }
}
