using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DTOS.Entity.Dtos
{
	public class VeiculosCondutoresDto
	{
		public string CPF { get; set; }
		public string Placa { get; set; }
		public DateTime DataCompra { get; set; }
		public DateTime DataVenda { get; set; }
	}
}
