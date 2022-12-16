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
    /// Изменение данных в таблице Книги
    /// </summary>
    public class UpdatorBook
    {
        private static Book CurrentEntity;
        /// <summary>
        /// Менюшка для изменения книг
        /// </summary>
        /// <param name="book"></param>
        public static void UpdateBook(Book book)
        {
            CurrentEntity = book;
            options = new List<MenuOption>()
            {
                new MenuOption()
                {
                    Title = "Название - " + CurrentEntity.Name,
                    Action = UpdateName,
                },
                new MenuOption()
                {
                    Title = "Жанр - " + CurrentEntity.Genre,
                    Action = UpdateGenre,
                },
                new MenuOption()
                {
                    Title = "Год выпуска - " + CurrentEntity.Created,
                    Action = UpdateCreated,
                },
                new MenuOption()
                {
                    Title = "Экземпляры - " + CurrentEntity.NumberCopies,
                    Action = UpdateNumberCopies,
                },
                new MenuOption()
                {
                    Title = "Страниц - " + CurrentEntity.Pages,
                    Action = UpdatePages,
                },
                new MenuOption()
                {
                    Title = "Цена - " + CurrentEntity.Price,
                    Action = UpdatePrice,
                },
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
        /// Изменение названия книги
        /// </summary>
        public static void UpdateName()
        {
            var newName = CRUD.InputCheck.InputCheck.GetValue("Введите новое название", "", x => true);
            CurrentEntity.Name = newName;
            options[0].Title = "Название - " + CurrentEntity.Name;
        }
        
        /// <summary>
        /// Изменение жанра 
        /// </summary>
        public static void UpdateGenre()
        {
            var newGenre = CRUD.InputCheck.InputCheck.GetValue("Введите новый жанр", "", x => true);
            CurrentEntity.Genre = newGenre;
            options[1].Title = "Жанр - " + CurrentEntity.Genre;
        }
        /// <summary>
        /// Изменение даты выпуска
        /// </summary>
        public static void UpdateCreated()
        {
            var newCreated = CRUD.InputCheck.InputCheck.GetInt("Введите новый год выпуска:", "Введите год в формате YYYY:", x => 1800 < x && DateTime.Now.Year >= x);
            CurrentEntity.Created = newCreated;
            options[2].Title = "Год выпуска - " + CurrentEntity.Created;
        }
        /// <summary>
        /// Изменение количества экземпляров книги
        /// </summary>
        public static void UpdateNumberCopies()
        {
            var newNumberCopies = CRUD.InputCheck.InputCheck.GetInt("Введите новое количество экземпляров:", "Больше нуля:", x => x > 0);
            CurrentEntity.NumberCopies = newNumberCopies;
            options[3].Title = "Количество экземпляров - " + CurrentEntity.NumberCopies;
        }
        /// <summary>
        /// Изменение количества страниц
        /// </summary>
        public static void UpdatePages()
        {
            var newPages = CRUD.InputCheck.InputCheck.GetInt("Введите новое количество страниц:", "Больше нуля:", x => x > 0);
            CurrentEntity.Pages = newPages;
            options[4].Title = "Количество страниц - " + CurrentEntity.Pages;
        }
        /// <summary>
        /// Изменение цены 
        /// </summary>
        public static void UpdatePrice()
        {
            var newPrice = CRUD.InputCheck.InputCheck.GetDecimal("Введите новую цену:", "Больше нуля:", x => x > 0);
            CurrentEntity.Price = newPrice;
            options[5].Title = "Цена - " + CurrentEntity.Price;
        }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        public static void SaveData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var entity = db.Books.Find(CurrentEntity.Id);

                entity.Name = CurrentEntity.Name;
                entity.Genre = CurrentEntity.Genre;
                entity.Created = CurrentEntity.Created;
                entity.NumberCopies = CurrentEntity.NumberCopies;
                entity.Pages = CurrentEntity.Pages;
                entity.Price = CurrentEntity.Price;
                db.SaveChanges();
            }
        }
    }
}
