using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Crud.DTOS.Entity
{
	public class Veiculo
	{
		public string Placa { get; set; }
		public string Modelo { get; set; }
		public string Marca { get; set; }
		public string Cor { get; set; }
		public DateTime AnoDeFabricacao { get; set; }
		public List<VeiculoCondutores> HistoricoVeiculo { get; set; }
	}
}
