using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBook.Context;
using StorageBook.Menu;
using StorageBook.Models;

namespace StorageBook.CRUD.DeleteData
{
    /// <summary>
    /// Удаление книг
    /// </summary>
    public class DeleteBook
    {
        /// <summary>
        /// Метод удаляющий книги
        /// </summary>
        /// <param name="index"></param>
        public static void DropData(Book index)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var book = db.Books.FirstOrDefault(x => x.Id == index.Id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }

            }
            MenuHelper menu = new MenuHelper();
            menu.ExecuteMenu(MainMenu.options);
        }

    }
}
