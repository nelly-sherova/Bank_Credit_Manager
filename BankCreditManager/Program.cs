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
            if (TrimCommand(languageOfProgram) == "rus") 
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
                if(TrimCommand(choosePolzovatel) == "administrator")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Введите логин: ");
                    Console.ResetColor();
                    string administratorLogin = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Введите пароль: ");
                    Console.ResetColor();
                    string parol = Console.ReadLine(); // изменить название переменной
                    if (parol == key && administratorLogin == login)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Вы успешно вошли в систему!");
                        Console.ResetColor();
                        Console.WriteLine("Для регистрации клиента нажмите [1]\n" +
                            "Для просмотра истории заявок нажмите [2]\n" +
                            "Для выхода из программы нажмите [0]");
                        char.TryParse(Console.ReadLine(), out char chooseAdmin);
                        switch(chooseAdmin)
                        {
                            case '1':
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("Добро пожаловать в поле регистрации клиента!");
                                Console.ResetColor();
                            }break;
                        }
                    }
                     else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неправильный пароль или логин, вход будет осуществляться как Клиент");
                        choosePolzovatel = "client";
                        Console.ResetColor();
                    }
                }
                if (TrimCommand(choosePolzovatel) == "client")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Здравствуйте, дорогой клиент!");
                    Console.ResetColor();
                     Console.WriteLine("Для регистрации нажмите [1]\n" +
                        "Для входа нажмите [2]\n" +
                        "Для выхода из программы нажмите [0]");
                    PersonalAccount p = new PersonalAccount();
                    p.InsertIntoPersonalAccountRus();
                    
                }
            }
            else if (TrimCommand(languageOfProgram) == "eng")
            {

            }

        }
        /// <summary>
        /// Метод который удаляет пробелы и игнорирует большие и маленькие буквы
        /// </summary>
        /// <param string="text"></param>
        /// <returns></returns>
        public static string TrimCommand(string text) 
        {
            string toLowerText = text.ToLower();
            return toLowerText.Trim();
        }
    }
}
