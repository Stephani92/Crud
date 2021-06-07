using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Crud.DTOS.Entity
{
	public class Condutor
	{
		public string Name { get; set; }
		public string CPF{ get; set; }
		public string Telefone { get; set; }

		[EmailAddress]
		[Required(ErrorMessage = "O email deve ser preeenchido")]
		public string Email { get; set; }
		public string CNH { get; set; }
		public DateTime DataNascimento { get; set; }
		public List<VeiculoCondutores> HistoricoVeiculo { get; set; }
	}
}
