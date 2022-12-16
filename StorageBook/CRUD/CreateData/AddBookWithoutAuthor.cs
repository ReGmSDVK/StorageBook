using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBook.Context;
using StorageBook.Models;
namespace StorageBook.CRUD.CreateData
{
    /// <summary>
    /// Добавление данных в таблицу Книги
    /// </summary>
    public class AddBookWithoutAuthor
    {
        /// <summary>
        /// Добавление книг
        /// </summary>
        public void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в раздел \"Добавить книгу\"");
            var nameBook = CRUD.InputCheck.InputCheck.GetValue("Название книги:", "", x => true);
            var genre = CRUD.InputCheck.InputCheck.GetValue("Жанр:", "", x => true);
            int created = CRUD.InputCheck.InputCheck.GetInt("Год выпуска:", "Введите год в формате YYYY:", x => 1800 < x && DateTime.Now.Year >= x);
            int numberCopies = CRUD.InputCheck.InputCheck.GetInt("Количество экземпляров:", "Больше нуля:", x => x > 0);
            int pages = CRUD.InputCheck.InputCheck.GetInt("Количество страниц:", "Больше нуля:", x => x > 0);
            decimal price = CRUD.InputCheck.InputCheck.GetDecimal("Цена:", "Больше нуля:", x => x > 0);

            using (ApplicationContext db = new ApplicationContext())
            {
                Book input = new Book
                {
                    Name = nameBook,
                    Genre = genre,
                    Created = created,
                    NumberCopies = numberCopies,
                    Pages = pages,
                    Price = price
                };
                db.Books.Add(input);
                db.SaveChanges();
            }
            Console.WriteLine("Книга успешно добавлена!\n" +
                "Нажмите любую клавишу для возвращения в главное меню.");
            Console.ReadKey();
        }
    }
    
}
