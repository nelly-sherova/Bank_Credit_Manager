using System;
namespace BankCreditManager
{
  class PersonalAccount
  {
    public string Login { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public void InsertIntoPersonalAccountRus()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("То поле в котором есть [*] может быть пустым!");
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите имя: "); Console.ResetColor(); FirstName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите фамилию [*]: "); Console.ResetColor(); LastName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите отчество [*]: "); Console.ResetColor(); LastName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите логин (номер телефона): "); Console.ResetColor(); Login = Console.ReadLine();
      bool truePassword = true;
      string testPassword1, testPassword2; // для проверки правильности пароля
      int countOfWhileTruePassword = 0;
      while(truePassword)
      {
        countOfWhileTruePassword++;
        if (countOfWhileTruePassword == 3) truePassword = false;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите пароль: "); Console.ResetColor(); testPassword1 = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Повторите пароль: "); Console.ResetColor(); testPassword2 = Console.ReadLine();
        if(testPassword1 == testPassword2)
        {
          Password = testPassword1;
          truePassword = false;
        }
        else if (testPassword1 != testPassword2 && countOfWhileTruePassword < 3)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Пароли не совпадают!");
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          Console.WriteLine("Повторите попытку!");
        }
      }
    }
  }
}