using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBook.Context;
using Microsoft.EntityFrameworkCore;
using StorageBook.Models;
namespace StorageBook.Factory
{
    /// <summary>
    /// создает экземпляр dbContext во время миграции
    /// </summary>
    public class SampleDataBaseContextFactory
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = @"Server=.;Database=StorageBookDB;Trusted_Connection=True;TrustServerCertificate=True";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new ApplicationContext();
            return context;
        }
    }
}
