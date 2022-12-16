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
    public static class SearchBook
    {
        public static string _nameBook;
        public static List<Book> _books = new List<Book>();
        /// <summary>
        /// Метод перебирающий Книги, позволяет найти нужную книгу
        /// </summary>
        public static void SeleSelectBookctBook()
        {
            bool isSelect = true;
            using (ApplicationContext db = new ApplicationContext())
            {
                _books = db.Books.ToList();
            }
            PrintBook();
            while (isSelect)
            {
                Console.WriteLine("Введите название книги, или напишите <Выйти>");
                _nameBook = Console.ReadLine();
                if (_nameBook == "выйти")
                    isSelect = false;
                using (ApplicationContext db = new ApplicationContext())
                {
                    _books = db.Books.Where(x => x.Name.Contains(_nameBook)).ToList();
                }
                PrintBook(); 
            }
        }
        /// <summary>
        /// Вывод Книг на консоль
        /// </summary>
        public static void PrintBook()
        {
            Console.Clear();
            foreach (var item in _books)
            {
                item.PrintInfo();
            }
        }

    }
}
