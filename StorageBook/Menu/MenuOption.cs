using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.Menu
{
    /// <summary>
    /// Тут хранятся элементы меню
    /// </summary>
    public class MenuOption
    {
        public string? Title { get; set; }
        public Action? Action { get; set; }
    }
}
