using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;
using Crud.DTOS.Entity;
using Crud.DTOS.Entity.Dtos;
using Crud.DTOS.Interfaces.Repositories;
using System;

namespace Crud.ApplicationCore.Services.Ef
{
	public class VeiculoCondutorService : CrudService, ICrudService
	{
		private readonly IVeiculoCondutorEfRepository _condutorEfRepository;

		public VeiculoCondutorService(IRepository efRepository, 
									  IVeiculoCondutorEfRepository condutorEfRepository) : base(efRepository)
		{
			_condutorEfRepository = condutorEfRepository;
		}

		public void AddVeiculoCondutores(VeiculosCondutoresDto veiculosCondutoresDto)
		{
			var condutor = efRepository.GetAsyncById<Condutor>(veiculosCondutoresDto.CPF);
			if (condutor is null) throw new ArgumentException("Condutor não cadastrado");
			var veiculo = efRepository.GetAsyncById<Veiculo>(veiculosCondutoresDto.Placa);
			if (veiculo is null) throw new ArgumentException("Veiculo não cadastrado");

			Add(new VeiculoCondutores() 
				{ 
					DataCompra = veiculosCondutoresDto.DataCompra, 
					DataVenda = veiculosCondutoresDto.DataVenda, 
					Condutor = condutor, 
					Veiculo = veiculo 
				}
			);
		}

		public void UpdateVeiculoCondutores(VeiculosCondutoresDto veiculosCondutoresDto)
		{
			var VeiculoCondutor = efRepository.GetAsyncById<VeiculoCondutores>( veiculosCondutoresDto.Placa + veiculosCondutoresDto.CPF);
			if (VeiculoCondutor is null) throw new ArgumentException("Registro não cadastrado");
			VeiculoCondutor.DataVenda = veiculosCondutoresDto.DataVenda;
			efRepository.Update(VeiculoCondutor);
			efRepository.SaveChangesAsync();
		}
		public Condutor GetHistorioCondutoresVeiculo(string Cpf)
		{
			return _condutorEfRepository.GetHistorioCondutoresVeiculo(Cpf);
		}
		public Veiculo GetHistorioVeiculoCondutores(string placa)
		{
			return _condutorEfRepository.GetHistorioVeiculoCondutores(placa);
		}
	}
}
