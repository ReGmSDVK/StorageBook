using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.Models
{
    /// <summary>
    /// Модель таблицы Книги
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Created { get; set; }
        public int NumberCopies { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public List<Author> Authors { get; set; } = new();

        /// <summary>
        /// Метод для поска Книг
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine("--------------------------");
        }
    }
}
