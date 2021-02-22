using System;

namespace BankCreditManager
{
    class Program
    {
        static void Main(string[] args)
        {
            const string key = "0001"; // изменить название переменной
            const string login = "909929763"; // возможно потом изменим
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("~ ~ ~ Bank Credit Manager ~ ~ ~");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Выберите язык для продолжения!");
            Console.ResetColor();
            Console.WriteLine("Enter [rus] for Russian Language\n" +
                "Enter [eng] for English Language");
            string languageOfProgram = Console.ReadLine();
            if (languageOfProgram == "rus" || languageOfProgram == " rus" || languageOfProgram == "rus " || languageOfProgram == " rus ") 
                // добавить метод с большими буквами или добавить метод для удаления пробелов, создать его
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Вы выбрали русский язык!");
                Console.ResetColor();
                 Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Выберите пользователя: ");
                Console.ResetColor();
                Console.WriteLine("Если вы администратор, ввидите: [administrator]\n" +
                    "Если вы клиент, введите: [client] ");
                string choosePolzovatel = Console.ReadLine(); // нужно потом переименовать эту переменную
                if(choosePolzovatel == "administrator") // добавить метод
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Введите логин: ");
                    Console.ResetColor();
                    string administratorLogin = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Введите пароль: ");
                    Console.ResetColor();
                    string parol = Console.ReadLine(); // изменить название переменной
                    // здесь добавить sql команду select по login и parol
                    // получается нужно создать таблицу администраторов и класс тоже
                    
                }
            }

        }
    }
}
