using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBook.Models;
using Microsoft.EntityFrameworkCore;

namespace StorageBook.Context
{
    /// <summary>
    /// Контекст в котором создается и хранится БД
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
       
        /// <summary>
        /// Метод подключения к БД
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=StorageBookDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        /// <summary>
        /// Метод меняющий DataTime на date 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>()
                        .Property(x => x.Birth)
                        .HasColumnType("date");
        }
    }
}
