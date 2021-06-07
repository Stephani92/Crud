using Crud.DTOS.Entity;
using Crud.DTOS.Interfaces.Repositories;
using Crud.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Crud.Infrastruture.Repositories.EF
{
	public class VeiculoCondutorEfRepository : DefaultEfRepository, IVeiculoCondutorEfRepository
	{
		public VeiculoCondutorEfRepository(CrudContext _data) : base(_data)
		{
		}
		public Veiculo GetHistorioVeiculoCondutores(string placa)
		{
			IQueryable<Veiculo> query = data.Veiculos	
				.Where(c => c.Placa == placa)
				.Include(c => c.HistoricoVeiculo)
				.ThenInclude(c => c.Condutor);
			return query.FirstOrDefaultAsync().Result;
		}
		public Condutor GetHistorioCondutoresVeiculo(string CPF)
		{
			IQueryable<Condutor> query = data.Condutors
				.Where(c => c.CPF == CPF)
				.Include(c => c.HistoricoVeiculo)
				.ThenInclude(c => c.Veiculo);
			return query.FirstOrDefaultAsync().Result;
		}
	}
}
