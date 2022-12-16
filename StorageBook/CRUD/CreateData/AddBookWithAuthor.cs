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
    /// Добавление Автора и Книги, в данном классе добавляются связанные данные между таблицами
    /// </summary>
    public class AddBookWithAuthor
    {
        /// <summary>
        /// Метод добавляющий данные в БД, данные заполняются в 2 таблицах и 1 промежуточной, осуществляюшей связь многие ко многим
        /// </summary>
        public void AddBookAuthor()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в раздел \"Добавить книгу с автором\"");
            
            var nameBook = CRUD.InputCheck.InputCheck.GetValue("Название книги:", "", x => true);
            var genre = CRUD.InputCheck.InputCheck.GetValue("Жанр:", "", x => true);
            int created = CRUD.InputCheck.InputCheck.GetInt("Год выпуска:", "Введите год в формате YYYY:", x => 1800 < x && DateTime.Now.Year >= x);
            int numberCopies = CRUD.InputCheck.InputCheck.GetInt("Количество экземпляров:", "Больше нуля:", x => x > 0);
            int pages = CRUD.InputCheck.InputCheck.GetInt("Количество страниц:", "Больше нуля:", x => x > 0);
            decimal price = CRUD.InputCheck.InputCheck.GetDecimal("Цена:", "Больше нуля:", x => x > 0); 
            var fullName = CRUD.InputCheck.InputCheck.GetValue("Имя автора:", "", x => true);
            DateTime birth = CRUD.InputCheck.InputCheck.GetDateTime("День рождения:", "Введите в формате YYYY-MM-DD", x => true);

            using (ApplicationContext db = new ApplicationContext())
            {
                Book inputBook = new Book 
                { 
                    Name = nameBook, 
                    Genre = genre, 
                    Created = created, 
                    NumberCopies = numberCopies, 
                    Pages = pages, 
                    Price = price
                };
                Author inputAuthor = new Author 
                { 
                    Name = fullName, 
                    Birth = birth
                };
                db.Books.Add(inputBook);
                inputBook.Authors.Add(inputAuthor);
                db.SaveChanges();
            }
            Console.WriteLine("Книга и автор успешно добавлены!\n" +
                "Нажмите любую клавишу для возвращения в главное меню.");
            Console.ReadKey();
        }

      
    }
}
