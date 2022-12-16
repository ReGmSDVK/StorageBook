using StorageBook.Context;
using StorageBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.CRUD.Search
{
    /// <summary>
    /// Мне не хватило времени для полноценной реализации Поиска с удобным управлением, но сам поиск работает исправно
    /// </summary>
    public class SearchAuthor
    {
        public static string _nameAuthor;
        public static List<Author> _authors = new List<Author>();
        /// <summary>
        /// Метод перебирает данные находя нужного нам автора
        /// </summary>
        public static void SeleSelectBookctBook()
        {
            bool isSelect = true;
            using (ApplicationContext db = new ApplicationContext())
            {
                _authors = db.Authors.ToList();
            }
            PrintBook();
            while (isSelect)
            {
                Console.WriteLine("Введите имя автора, или напишите <Выйти>");
                _nameAuthor = Console.ReadLine();
                if(_nameAuthor == "выйти")
                    isSelect = false;
                using (ApplicationContext db = new ApplicationContext())
                {
                    _authors = db.Authors.Where(x => x.Name.Contains(_nameAuthor)).ToList();
                }
                PrintBook();
            }
        }
        /// <summary>
        /// Вывод на консоль всех Авторов
        /// </summary>
        public static void PrintBook()
        {
            Console.Clear();
            foreach (var item in _authors)
            {
                item.PrintInfo();
            }
        }
    }
}
