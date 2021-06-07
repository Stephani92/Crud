﻿// <auto-generated />
using Crud.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crud.Infrastruture.Migrations
{
    [DbContext(typeof(CrudContext))]
    partial class CrudContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crud.ApplicationCore.Entity.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Name = "Master"
                        },
                        new
                        {
                            Name = "ADM"
                        });
                });

            modelBuilder.Entity("Crud.ApplicationCore.Entity.UserRole", b =>
                {
                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleName", "UserEmail");

                    b.HasIndex("UserEmail");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            RoleName = "Master",
                            UserEmail = "boechat.stephani@gmail.com"
                        });
                });

            modelBuilder.Entity("Crud.DTOS.Entity.Usuario", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Email");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Email = "boechat.stephani@gmail.com",
                            Nome = "Master",
                            PasswordHash = "pvZ2UDVoS7aQD+Hx+Z9uuJBEXKJjKt/2aBI7cT6a6v0=",
                            Sobrenome = "tecnico"
                        });
                });

            modelBuilder.Entity("Crud.ApplicationCore.Entity.UserRole", b =>
                {
                    b.HasOne("Crud.ApplicationCore.Entity.Role", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crud.DTOS.Entity.Usuario", "User")
                        .WithMany("UserRole")
                        .HasForeignKey("UserEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crud.ApplicationCore.Entity.Role", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Crud.DTOS.Entity.Usuario", b =>
                {
                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
