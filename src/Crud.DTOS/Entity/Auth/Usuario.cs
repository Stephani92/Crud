using Crud.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crud.DTOS.Entity
{
	public class Usuario
    {
		public Usuario()
		{
		}

		public Usuario(string nome, string sobrenome, string email, string passwordHash)
		{
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            PasswordHash = passwordHash;


        }


		
        [Required(ErrorMessage = "O nome deve ser preeenchido")]
        public string Nome { get;  set; }

        [Required(ErrorMessage = "O sobrenome deve ser preeenchido")]
        public string Sobrenome { get;  set; }

        [Required(ErrorMessage = "A senha deve ser preeenchido")]
        public string PasswordHash { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O email deve ser preeenchido")]
        public string Email { get;  set; }
        [Required(ErrorMessage = "O data de nascimento deve ser preeenchido")]
        public List<UserRole> UserRole { get;  set; }

    }
}

