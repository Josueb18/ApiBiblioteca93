using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi93.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { }

        //Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; } //Aqui establecemos que tablas vienen
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Kevin",
                    User = "Usuario",
                    Password = "123",
                    FkRol = 1
                }

                );
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                });
        }
    }
}
