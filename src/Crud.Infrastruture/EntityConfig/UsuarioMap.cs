using Crud.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Infrastruture.EntityConfig
{
	public class UsuarioMap : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.HasKey(p => p.Id);			
			builder.Property(e => e.Email).HasColumnType("varchar(300)");
			builder.Property(e => e.Nome).HasColumnType("varchar(100)");
			builder.Property(e => e.Sobrenome).HasColumnType("varchar(200)");
		}
	}
}
