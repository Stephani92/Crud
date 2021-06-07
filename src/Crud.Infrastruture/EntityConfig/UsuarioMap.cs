using Crud.ApplicationCore.Entity;
using Crud.DTOS.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Infrastruture.EntityConfig
{
	public class UsuarioMap : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.HasKey(p => p.Email);		
			builder.Property(e => e.PasswordHash);
			builder.Property(e => e.Nome).HasColumnType("varchar(100)");
			builder.Property(e => e.Sobrenome).HasColumnType("varchar(200)");
		}
	}
	public class RoleMap : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(p => p.Name);
		}
	}
	public class UserRoleMap : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			
			builder.HasKey(ur => new { ur.RoleName, ur.UserEmail });
			builder.HasOne(ur => ur.User).WithMany(ur => ur.UserRole).HasForeignKey(ur => ur.UserEmail).IsRequired();
			builder.HasOne(ur => ur.Role).WithMany(ur => ur.Usuarios).HasForeignKey(ur => ur.RoleName).IsRequired();
		}
	}
	public class CondutoresMap : IEntityTypeConfiguration<Condutor>
	{
		public void Configure(EntityTypeBuilder<Condutor> builder)
		{

			builder.HasKey(ur => new {ur.CPF, ur.CNH});
		}
	}
	public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
	{
		public void Configure(EntityTypeBuilder<Veiculo> builder)
		{

			builder.HasKey(ur => ur.Placa);
		}
	}
	public class VeiculoCondutoresMap : IEntityTypeConfiguration<VeiculoCondutores>
	{
		public void Configure(EntityTypeBuilder<VeiculoCondutores> builder)
		{

			builder.HasKey(ur => new { ur.Veiculo.Placa, ur.Condutor.CPF});
			builder.HasOne(ur => ur.Condutor).WithMany(ur => ur.HistoricoVeiculo).HasForeignKey(ur => ur.Condutor.CPF).IsRequired();
			builder.HasOne(ur => ur.Veiculo).WithMany(ur => ur.HistoricoVeiculo).HasForeignKey(ur => ur.Veiculo.Placa).IsRequired();
		}
	}
	
}
