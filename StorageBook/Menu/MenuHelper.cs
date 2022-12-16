using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.Menu
{
    /// <summary>
    /// Отрисовывает меню и добавляет управление клавишами 
    /// </summary>
    public class MenuHelper
    {
        /// <summary>
        /// Метод для управления меню клавиатурой
        /// </summary>
        /// <param name="options"></param>
        public void ExecuteMenu(List<MenuOption> options)
        {
            int index = 0;

            PrintMenu(options, index);
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                    }
                    PrintMenu(options, index);
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                    }
                    PrintMenu(options, index);
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    options[index].Action();
                    index = 0;
                    PrintMenu(options, index);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Вывод меню на консоль
        /// </summary>
        /// <param name="options"></param>
        /// <param name="index"></param>
        private void PrintMenu(List<MenuOption> options, int index = 0)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в Хранилище книг\n" +
                "------------------------------------");
            foreach (MenuOption option in options)
            {
                if (option == options[index])
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" >> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(option.Title);
                Console.ResetColor();
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("[UP] Вверх [Down] Вниз\n" +
                "[Enter] Выбрать опцию\n" +
                "[Escape] Вернуться назад");
        }
    }
}
