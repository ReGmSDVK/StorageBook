using StorageBook.Context;
using StorageBook.CRUD.DeleteData;
using StorageBook.CRUD.UpdateData;
using StorageBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.Menu
{
    /// <summary>
    /// Удобное отрисовывание данных из таблицы Автор
    /// </summary>
    public class AuthorSelector
    {
        private readonly List<Author> _entities;
        public AuthorSelector()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                _entities = db.Authors.ToList();
            }
        }
        /// <summary>
        /// Метод для управления меню клавиатурой
        /// </summary>
        /// <param name="number"></param>
        public void ExecuteMenu(int number)
        {
            int index = 0;
            PrintMenu(index);
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < _entities.Count)
                    {
                        index++;
                    }
                    PrintMenu(index);
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                    }
                    PrintMenu(index);
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (number == 1) // за это стыдно, но работает исправно
                    {
                        UpdatorAuthor.UpdateAuthor(_entities[index]);
                    }
                    if(number == 2)
                    {
                        DeleteAuthor.DropAuthor(_entities[index]);
                    }
                    if (number == 3)
                    {
                        
                    }

                    index = 0;
                    PrintMenu(index);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Вывод меню на консоль
        /// </summary>
        /// <param name="index"></param>
        public void PrintMenu(int index = 0)
        {
            Console.Clear();
            Console.WriteLine("Выберите объект\n" +
                "------------------------------------");
            foreach (var entity in _entities)
            {
                if (entity == _entities[index])
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" >> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(entity.Name);
                Console.ResetColor();
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("[UP] Вверх [Down] Вниз\n" +
                "[Enter] Выбрать опцию\n" +
                "[Escape] Вернуться назад");
        }
    }
}
