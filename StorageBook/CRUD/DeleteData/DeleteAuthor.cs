using StorageBook.Context;
using StorageBook.Menu;
using StorageBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.CRUD.DeleteData
{
    /// <summary>
    /// Удаление Автора
    /// </summary>
    public class DeleteAuthor
    {
        /// <summary>
        /// Метод удаляет данные из таблицы Автор
        /// </summary>
        /// <param name="index"></param>
        public static void DropAuthor(Author index)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var author = db.Authors.FirstOrDefault(x => x.Id == index.Id);
                if (author != null)
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                }
            }
            MenuHelper menu = new MenuHelper();
            menu.ExecuteMenu(MainMenu.options);
        }
    }
}
