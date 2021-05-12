

using Crud.ApplicationCore.Entity;
using Crud.Infrastruture.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastruture.Data
{

	public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Usuario>().ToTable("Usuario");
            mb.ApplyConfiguration(new UsuarioMap());

        }
    }
}
