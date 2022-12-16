using StorageBook.CRUD.Search;
using StorageBook.Menu;
/// <summary>
/// Вход в программу
/// </summary>
class Prodgram
{
    static void Main(string[] args)
    {
        Console.Title = "Хранилище книг";
        MenuHelper menu = new MenuHelper();
        menu.ExecuteMenu(MainMenu.options);
    }
}
