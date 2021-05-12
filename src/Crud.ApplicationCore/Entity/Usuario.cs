using System;
using System.ComponentModel.DataAnnotations;

namespace Crud.ApplicationCore.Entity
{
	public class Usuario
    {
		public Usuario()
		{
		}

		public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento, string escolaridade)
		{
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;

        }


		public int Id { get;  set; }
        [Required(ErrorMessage = "O Nome deve ser preeenchido")]
        public string Nome { get;  set; }

        [Required(ErrorMessage = "O Sobrenome deve ser preeenchido")]
        public string Sobrenome { get;  set; }

        [EmailAddress]
        [Required(ErrorMessage = "O Email deve ser preeenchido")]
        public string Email { get;  set; }
        [Required(ErrorMessage = "O DataNascimento deve ser preeenchido")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O Escolaridade deve ser preeenchido")]
        public string Escolaridade { get;  set; }

    }
}

