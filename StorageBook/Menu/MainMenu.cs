using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBook.CRUD;
using StorageBook.CRUD.Search;

namespace StorageBook.Menu
{
    /// <summary>
    /// Главная менюшка
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// Заполнение меню опции
        /// </summary>
        public static List<MenuOption> options = new List<MenuOption>()
        {
            new MenuOption()
            {
                Title = "Добавить книгу с автором", 
                Action = AddBookWithAuthor,
            },
            new MenuOption()
            {
                Title = "Добавить книгу",           
                Action = AddBookWithoutAuthor,
            },
            new MenuOption()
            {
                Title = "Удалить книгу",            
                Action = DeleteBook,
            },
            new MenuOption()
            {
                Title = "Добавить Автора",           
                Action = AddAuthor,
            },
            new MenuOption()
            {
                Title = "Удалить Автора",
                Action = DeleteAuthor,
            },
            new MenuOption()
            {
                Title = "Посмотреть все книги",
                Action = ViewAllBook,
            },
            new MenuOption()
            {
                Title = "Посмотреть всех авторов",
                Action = ViewAllAuthor,
            },
            new MenuOption()
            {
                Title = "Поиск книги по названию",
                Action = SearchBookName,
            },
            new MenuOption()
            {
                Title = "Поиск автора по имени",
                Action = SearchAuthorName,
            },
            new MenuOption()
            {
                Title = "Изменить существующую книгу",
                Action = EditExistingBook,
            },
            new MenuOption()
            {
                Title = "Изменить существующего автора",
                Action = EditExistingAuthor,
            },
            new MenuOption()
            {
                Title = "Выйти",                           
                Action = OnExit,
            },
        };
        
        /// <summary>
        /// Метод ссылается на добавление Книг и Автора
        /// </summary>
        public static void AddBookWithAuthor() 
        {
            CRUD.CreateData.AddBookWithAuthor addBookWithAuthor = new CRUD.CreateData.AddBookWithAuthor();
            addBookWithAuthor.AddBookAuthor();
        }
        /// <summary>
        /// Метод ссылается на добавление Книг 
        /// </summary>
        public static void AddBookWithoutAuthor() 
        {
            CRUD.CreateData.AddBookWithoutAuthor addBookWithoutAuthor = new CRUD.CreateData.AddBookWithoutAuthor();
            addBookWithoutAuthor.AddBook();
        }
        /// <summary>
        /// Метод ссылается на удаление книг
        /// </summary>
        public static void DeleteBook() 
        {
            CRUD.DeleteData.DeleteBook deleteBook = new CRUD.DeleteData.DeleteBook();
            int number = 2;
            var selector = new BookSelector();
            selector.ExecuteMenu(number);
        }
        // <summary>
        /// Метод ссылается на добавление Автора
        /// </summary>
        public static void AddAuthor() 
        {
            CRUD.CreateData.AddAuthor addAuthor = new CRUD.CreateData.AddAuthor();
            addAuthor.AuthorAdd();
        }
        /// <summary>
        /// Метод ссылается на удаление автора
        /// </summary>
        public static void DeleteAuthor() 
        {
            CRUD.DeleteData.DeleteAuthor deleteAuthor = new CRUD.DeleteData.DeleteAuthor();
            int number = 2;
            var selector = new AuthorSelector();
            selector.ExecuteMenu(number);
        }
        /// <summary>
        /// Ссылается на класс для отображения всех книг (меню)
        /// </summary>
        public static void ViewAllBook()
        {
            int number = 3;
            var selector = new BookSelector();
            selector.ExecuteMenu(number);
        }
        /// <summary>
        /// Ссылается на класс для отображения всех авторов (меню)
        /// </summary>
        public static void ViewAllAuthor()
        {
            int number = 3;
            var selector = new AuthorSelector();
            selector.ExecuteMenu(number);
        }
        /// <summary>
        /// Ссылается на класс поиска книг по названию
        /// </summary>
        public static void SearchBookName()
        {
            SearchBook.SeleSelectBookctBook();
        }
        /// <summary>
        /// Ссылается на класс поска автора по ФИО
        /// </summary>
        public static void SearchAuthorName()
        {
            SearchAuthor.SeleSelectBookctBook();
        }
        /// <summary>
        /// Ссылается на изменение данных о книге
        /// </summary>
        public static void EditExistingBook() 
        {
            int number = 1;
            var selector = new BookSelector();
            selector.ExecuteMenu(number);
        }
        /// <summary>
        /// Ссылается на изменение данных о авторе
        /// </summary>
        public static void EditExistingAuthor() 
        {
            int number = 1;
            var selector = new AuthorSelector();
            selector.ExecuteMenu(number);
            
        }
        /// <summary>
        /// Завершение работы консольного приложения
        /// </summary>
        public static void OnExit() 
        {
            Environment.Exit(0);
        }
    }
}
