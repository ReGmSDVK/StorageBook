using StorageBook.Context;
using StorageBook.Menu;
using StorageBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.CRUD.UpdateData
{
    /// <summary>
    /// Изменение данных в таблицу Авторы
    /// </summary>
    public class UpdatorAuthor
    {
        private static Author CurrentEntity;
        /// <summary>
        /// Меню для изменения данных в таблицу Автор
        /// </summary>
        /// <param name="author"></param>
        public static void UpdateAuthor(Author author)
        {
            CurrentEntity = author;

            options = new List<MenuOption>()
            {
                new MenuOption()
                {
                    Title = "ФИО - " + CurrentEntity.Name,
                    Action = UpdateName,
                },
                new MenuOption()
                {
                    Title = "Дата рождения - " + CurrentEntity.Birth,
                    Action = UpdateBirthDate,
                }
            };

            var helper = new MenuHelper();
            bool exit = false;
            while (!exit)
            {
                helper.ExecuteMenu(options);
                Console.WriteLine("Хотите сохранить данные? (y/n)");
                switch (Console.ReadLine())
                {
                    case "y":
                        SaveData();
                        exit = true;
                        break;
                    case "n":
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
            CurrentEntity = null;
        }

        public static List<MenuOption> options { get; set; }

        /// <summary>
        /// Изменение имени автора
        /// </summary>
        public static void UpdateName()
        {
            Console.WriteLine("Введите новое ФИО");
            var newName = CRUD.InputCheck.InputCheck.GetValue("Введите новое ФИО автора:", "", x => true);
            CurrentEntity.Name = newName;
            options[0].Title = "ФИО - " + CurrentEntity.Name;
        }
        /// <summary>
        /// Изменение даты рождения
        /// </summary>
        public static void UpdateBirthDate()
        {
            var newBDate = CRUD.InputCheck.InputCheck.GetDateTime("Введите дату рождения:", "Введите в формате YYYY-MM-DD", x => true);
            CurrentEntity.Birth = newBDate; 
            options[1].Title = "Дата рождения - " + CurrentEntity.Birth;
        }
        /// <summary>
        /// Сохранение внесенных изменений
        /// </summary>
        public static void SaveData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var entity = db.Authors.Find(CurrentEntity.Id);

                entity.Name = CurrentEntity.Name;
                entity.Birth = CurrentEntity.Birth;

                db.SaveChanges();
            }
        }
    }
}
