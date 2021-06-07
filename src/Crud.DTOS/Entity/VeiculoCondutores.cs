using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DTOS.Entity
{
	public class VeiculoCondutores
	{
		public DateTime? DataVenda { get; set; }
		public DateTime DataCompra { get; set; }

		public string VeiculoPlaca { get; set; }

		public string CondutorCpf { get; set; }
		public Veiculo Veiculo { get; set; }
		public Condutor Condutor { get; set; }
	}
}
