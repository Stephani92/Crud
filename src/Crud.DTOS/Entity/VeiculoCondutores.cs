using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Crud.DTOS.Entity
{
	public class VeiculoCondutores
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public DateTime? DataVenda { get; set; }
		public DateTime DataCompra { get; set; }

		public string VeiculoPlaca { get; set; }

		public string CondutorCpf { get; set; }
		[JsonIgnore]
		[IgnoreDataMember]
		public Veiculo Veiculo { get; set; }
		[JsonIgnore]
		[IgnoreDataMember]
		public Condutor Condutor { get; set; }
	}
}
