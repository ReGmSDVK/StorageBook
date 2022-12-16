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
    /// Добавление автора
    /// </summary>
    public class AddAuthor
    {
        /// <summary>
        /// Метод для добавления автора
        /// </summary>
        public void AuthorAdd()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в раздел \"Добавить автора\"");
            var fullName = CRUD.InputCheck.InputCheck.GetValue("Имя автора:", "", x => true);
            DateTime birth = CRUD.InputCheck.InputCheck.GetDateTime("День рождения:", "Введите в формате YYYY-MM-DD", x => true);

            using (ApplicationContext db = new ApplicationContext())
            {
                Author inputAuthor = new Author
                {
                    Name = fullName,
                    Birth = birth
                };
                db.Authors.Add(inputAuthor);
                db.SaveChanges();
            }
            Console.WriteLine("Автор успешно добавлен!\n" +
                "Нажмите любую клавишу для возвращения в главное меню.");
            Console.ReadKey();
        }
    }
}
