
using Crud.ApplicationCore.Entity;
using Crud.ApplicationCore.Helpers.Security;
using Crud.DTOS.Entity;
using Crud.Infrastruture.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Crud.Infrastruture.Data
{

	public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Condutor> Condutors { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<VeiculoCondutores> VeiculoCondutores { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            

            base.OnModelCreating(mb);

            mb.Entity<Usuario>().ToTable("Usuario");
            mb.ApplyConfiguration(new UsuarioMap());
            mb.Entity<Role>().ToTable("Role");
            mb.ApplyConfiguration(new RoleMap());
            mb.Entity<UserRole>().ToTable("UserRole");
            mb.ApplyConfiguration(new UserRoleMap());


            mb.Entity<Condutor>().ToTable("Condutores");
            mb.ApplyConfiguration(new CondutoresMap());
            mb.Entity<Veiculo>().ToTable("Veiculos");
            mb.ApplyConfiguration(new VeiculoMap());
            mb.Entity<VeiculoCondutores>().ToTable("VeiculoCondutores");
            mb.ApplyConfiguration(new VeiculoCondutoresMap());
            

            //Seed
            mb.Entity<Role>().HasData(new Role("Master"), new Role("ADM"));
			mb.Entity<Usuario>().HasData(new Usuario("Master", "tecnico", "master.tecnico@gmail.com", CripAlgoritmo.Criptografar("12345789")));
			mb.Entity<UserRole>().HasData(new UserRole("master.tecnico@gmail.com", "Master"));



		}
	}
}
