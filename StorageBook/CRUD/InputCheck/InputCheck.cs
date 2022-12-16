using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBook.CRUD.InputCheck
{
    /// <summary>
    /// Здесь хранятся методы использующиеся для проверки вводимых через консоль данных
    /// </summary>
    public class InputCheck
    {
        /// <summary>
        /// метод для проверки Stringa
        /// </summary>
        
        public static string GetValue(string inputStr, string error, Func<string, bool> f)
        {
            Console.WriteLine(inputStr);
            while (true)
            {
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && f(input))
                    return input;
                Console.WriteLine(error);
            }
        }

        /// <summary>
        /// метод для проверки Int
        /// </summary>
        public static int GetInt(string inputStr, string error, Func<int, bool> f)
        {
            Console.WriteLine(inputStr);
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var res) && f(res))
                    return res;
                Console.WriteLine(error);
            }
        }

        /// <summary>
        /// метод для проверки Decimal
        /// </summary>
        public static decimal GetDecimal(string inputStr, string error, Func<decimal, bool> f)
        {
            Console.WriteLine(inputStr);
            while (true)
            {
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out var res) && f(res))
                    return res;
                Console.WriteLine(error);
            }
        }

        /// <summary>
        /// метод для проверки DateTime
        /// </summary>
        public static DateTime GetDateTime(string inputStr, string error, Func<DateTime, bool> f)
        {
            Console.WriteLine(inputStr);
            while (true)
            {
                var input = Console.ReadLine();
                if (DateTime.TryParse(input, out var res) && f(res))
                    return res;
                Console.WriteLine(error);
            }
        }
    }
}
