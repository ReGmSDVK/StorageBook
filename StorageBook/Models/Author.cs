using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.Models
{
    /// <summary>
    /// Модель таблицы Автор
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public List<Book> Books { get; set; } = new();

        /// <summary>
        /// Метод для поиска Автора
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine("--------------------------");
        }
    }
}
