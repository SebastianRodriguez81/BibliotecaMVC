using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaMVC.Models;


namespace BibliotecaMVC.Context
{
    public class BiblioDatabaseContext: DbContext
    {
        
    public BiblioDatabaseContext(DbContextOptions<BiblioDatabaseContext> options)
    :base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:nt1.database.windows.net;Database=BiblioDatabase;User ID=sebas;Password=Sebowi0510");
        }
        // .\\SQLExpress
        // Server=tcp:nt1.database.windows.net,1433;Initial Catalog=BiblioDatabase;Persist Security Info=False;User ID=sebas;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasOne<Autor>(a => a.Autor)
                .WithMany(l => l.Libros)
                .HasForeignKey(a => a.IDAutor);

            modelBuilder.Entity<Libro>()
                .HasOne<Editorial>(e => e.Editorial)
                .WithMany(l => l.Libros)
                .HasForeignKey(e => e.IDEditorial);

            modelBuilder.Entity<Libro>()
                .HasOne<Genero>(g => g.Genero)
                .WithMany(l => l.Libros)
                .HasForeignKey(g => g.IDGenero);
        }



        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

