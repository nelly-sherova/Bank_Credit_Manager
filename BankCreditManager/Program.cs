using System;

namespace BankCreditManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Administrator administrator = new Administrator();
            PersonalAccount personalAccount = new PersonalAccount();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("~ ~ ~ Bank Credit Manager ~ ~ ~");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Select the language to continue!");
            Console.ResetColor();

            Console.WriteLine("Введите [rus] для выбора русского языка\n" +
                "Enter [eng] for English Language");
            string languageOfProgram = Console.ReadLine();

            bool trueLanguageOfProgram = true;
            while(trueLanguageOfProgram)
            {
                for(int i = 1; i <= 3; i++)
                {
                    if (TrimCommand(languageOfProgram) != "rus" && TrimCommand(languageOfProgram) != "eng")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введена неправильная команда!");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Повторите попытку!");
                        Console.ResetColor();
                         Console.WriteLine("Введите [rus] для выбора русского языка\n" +
                            "Enter [eng] for English Language");
                        languageOfProgram = Console.ReadLine();
                        if (TrimCommand(languageOfProgram) == "rus" || TrimCommand(languageOfProgram) == "eng")
                        {
                           trueLanguageOfProgram = false;
                        }
                        if (i == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Попытка введения команды закончилась\n" +
                                "Будет осуществлен выход из программы!");
                            Console.ResetColor();
                            trueLanguageOfProgram = false;
                        }
                    }
                    else
                        trueLanguageOfProgram = false;
                }
            }


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
                string chooseUser = Console.ReadLine(); 
                bool trueChooseUser = true; // для проверки введенной команды
                int countOfCheckChooseUser = 3; // попытки для введения 
                while(trueChooseUser)
                {
                    for (int i = 0; i < countOfCheckChooseUser; i++)
                    {
                        if (TrimCommand(chooseUser) != "administrator" && TrimCommand(chooseUser) != "client")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введена неправильная команда!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Повторите попытку!");
                            Console.ResetColor();
                            Console.WriteLine("Если вы администратор, введите: [administrator]\n" +
                                "Если вы клиент, введите: [client] ");
                            
                            chooseUser = Console.ReadLine();
                            if (TrimCommand(chooseUser) == "administrator" || TrimCommand(chooseUser) == "client")
                            {
                                trueChooseUser = false;
                            }
                            if (i == countOfCheckChooseUser - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Попытка введения команды закончилась\n" +
                                    "Будет осуществлен выход из программы!");
                                Console.ResetColor();
                                trueChooseUser = false;
                            }
                                
                        }
                        else
                            trueChooseUser = false;
                    }
                }

                
                if(TrimCommand(chooseUser) == "administrator")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Введите логин: ");
                    Console.ResetColor();
                    string administratorLogin = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Введите пароль: ");
                    Console.ResetColor();
                    string password = Console.ReadLine(); 

                    if (password == administrator.Password && administratorLogin == administrator.Login)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Вы успешно вошли в систему!");
                        Console.ResetColor();
                        Console.WriteLine("Для регистрации клиента нажмите [1]\n" +
                            "Для просмотра истории заявок нажмите [2]\n" +
                            "Любая другая команда - выход из программы");
                        string chooseAdmin = Console.ReadLine();
                        
                        if (TrimCommand(chooseAdmin) == "1")
                        {
                            personalAccount.InformationRus();
                        }
                    }
                    
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неправильный пароль или логин, вход будет осуществляться как Клиент");
                        chooseUser = "client";
                        Console.ResetColor();
                    }
                }
                
                if (TrimCommand(chooseUser) == "client")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Здравствуйте, дорогой клиент!");
                    Console.ResetColor();
                     Console.WriteLine("Для регистрации нажмите [1]\n" +
                        "Для входа нажмите [2]\n" +
                        "Для выхода из программы нажмите [0]");
                    string chooseCommandClient = Console.ReadLine();

                    if (TrimCommand(chooseCommandClient) == "1")
                    {
                        personalAccount.InformationRus();
                        personalAccount.CreditRepaymentSchedule();

                    }
                    
                }
            }
            else if (TrimCommand(languageOfProgram) == "eng")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("You have chosen English!");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Select a user: ");
                Console.ResetColor();

                Console.WriteLine("If You are an Administrator, enter: [administrator]\n" +
                    "If you are a Customer enter: [client] ");
                string chooseUser = Console.ReadLine(); 

                if (TrimCommand(chooseUser) == "administrator")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Enter the login: ");
                    Console.ResetColor();
                    string administratorLogin = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Enter the password: ");
                    Console.ResetColor();
                    string password = Console.ReadLine(); // изменить название переменной

                    if (password == administrator.Password && administratorLogin == administrator.Login)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("You have successfully logged in!");
                        Console.ResetColor();
                        Console.WriteLine("To regidtration the client enter [1]\n" + // есть
                            "To view the history of applications, enter [2]\n" + //нету
                            "Any other team output from the program ");// нету
                        string chooseAdmin = Console.ReadLine();

                        if (TrimCommand(chooseAdmin) == "1")
                        {
                            personalAccount.InformationRus();
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect password or login! The input will be made as a client");
                        chooseUser = "client";
                        Console.ResetColor();
                    }
                }
                if (TrimCommand(chooseUser) == "client")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Hello dear customer!");
                    Console.ResetColor();
                    Console.WriteLine("For registration, enter [1]\n" + // eсть
                        "To enter the acoount enter [2]\n" +
                        "Any other team output from the program");
                    string chooseCommandClient = Console.ReadLine();

                    if (TrimCommand(chooseCommandClient) == "1")
                    {
                        personalAccount.InformationRus();

                    }

                }
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
