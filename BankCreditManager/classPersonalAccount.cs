using System;
namespace BankCreditManager
{
  public class PersonalAccount
  {
    public int Id {get; set;}
    public string Login { get; set; }
    public string Password { get; set; }

    PassportData passportData = new PassportData();
    Questionary questionary = new Questionary();
    OveralMark overalMark = new OveralMark();

    /// <summary>
    /// Метод для проверки номера телефона, чтобы там не было букв
    /// </summary>
    /// <param name="Номер телефона"></param>
    /// <returns></returns>
    public bool PhoneNumberVertification(string text)
    {
      bool answer = false;
      for (int i = 0; i < text.Length; i++)
      {
        if (Convert.ToString(text[i]) == "1")
          answer = true;
        else if (Convert.ToString(text[i]) == "2")
          answer = true;
        else if (Convert.ToString(text[i]) == "3")
          answer = true;
        else if (Convert.ToString(text[i]) == "4")
          answer = true;
        else if (Convert.ToString(text[i]) == "5")
          answer = true;
        else if (Convert.ToString(text[i]) == "6")
          answer = true;
        else if (Convert.ToString(text[i]) == "7")
          answer = true;
        else if (Convert.ToString(text[i]) == "8")
          answer = true;
        else if (Convert.ToString(text[i]) == "9")
          answer = true;
        else if (Convert.ToString(text[i]) == "0")
          answer = true;
        else 
        {
          answer = false;
        }
        if (answer == false)
          break;
      }
        return answer;
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


    /// <summary>
    /// Функция для заполнения данных и вставки их в таблицу PersonalAccount
    /// </summary>
    public void InsertIntoPersonalAccountRus()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("То поле в котором есть [*] может быть пустым!"); // но посмотреть чтобы не осталось только имя

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите имя: "); Console.ResetColor(); 
      passportData.FirstName = Console.ReadLine();

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите фамилию [*]: "); Console.ResetColor(); passportData.MiddleName = Console.ReadLine();

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите отчество: "); Console.ResetColor(); passportData.LastName = Console.ReadLine();

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите логин (номер телефона): "); Console.ResetColor(); Login = Console.ReadLine(); //посмотреть чтобы сюда не попали буквы и символы

      bool trueNumber = true; // для правильности пароля
      
      while (trueNumber)
      {
        if (PhoneNumberVertification(Login) == false)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Введите правильный номер телефона!");
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          Console.Write("Повторите попытку: ");
          Login = Console.ReadLine();
          if (PhoneNumberVertification(Login) == true)
            trueNumber = false;
        }
        if (PhoneNumberVertification(Login) == true)
        {
          trueNumber = false;
        }
      }
      bool truePassword = true; // для правильности пароля
      bool continueInsert = false; // для продолжения программы есди пароль правильный или неправильный
      string testPassword1, testPassword2; // для проверки правильности пароля
      int countOfWhileTruePassword = 0; // количество попыток для введения пароля 

      while(truePassword)
      {
        countOfWhileTruePassword++; // переменная для количества проверки для правильности пароля
        if (countOfWhileTruePassword == 3) 
          truePassword = false;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите пароль: "); Console.ResetColor(); testPassword1 = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Повторите пароль: "); Console.ResetColor(); testPassword2 = Console.ReadLine();

        if(testPassword1 == testPassword2)
        {
          Password = testPassword1;
          truePassword = false;
          continueInsert = true;
        }

        else if (testPassword1 != testPassword2 && countOfWhileTruePassword < 3)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Пароли не совпадают!");
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          Console.WriteLine("Повторите попытку!");
        }
      }
      if (continueInsert == false)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Пароли были записаны неправльно, будет осуществлен выход из программы!");
        Console.ResetColor();
      }
      if (continueInsert == true)
      {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Укажите пол:\n");
        Console.ResetColor();
        Console.WriteLine("[жен] для женского пола\n" +
          "[муж] для мужского");
        passportData.Pol = Console.ReadLine();

        if (TrimCommand(passportData.Pol) == "жен")
          overalMark.Mark += 2;

        else if (TrimCommand(passportData.Pol) == "муж")
          overalMark.Mark++;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Гражданство: "); Console.ResetColor();
        Console.WriteLine("Для гражданства Таджикистан введите: [Таджикистан]\n" +
          "Другое [Другое]");
        passportData.Nationality = Console.ReadLine();

        if (passportData.Nationality == "Таджикистан")
          overalMark.Mark++;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Введите дату рождения: "); Console.ResetColor();
        Console.WriteLine("Формат: [день.месяц.год]");
        passportData.DateOfBirth = Convert.ToDateTime(Console.ReadLine()); 
        questionary.Age = Convert.ToInt32(DateTime.Now.Year - passportData.DateOfBirth.Year);
        if (DateTime.Now.Month < passportData.DateOfBirth.Month)
          questionary.Age--;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите адрес: "); Console.ResetColor();
        passportData.Address = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите серию паспорта: "); Console.ResetColor();
        passportData.PassportSeries = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите ИНН: "); Console.ResetColor();
        passportData.NationalId = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Укажите семейное положение: "); Console.ResetColor();
        Console.WriteLine("Введите [1], если холост (не замужем)\n" +
          "Введите [2], если семьянин\n" +
          "Введите [3], если в разводе\n" +
          "Введите [4], если вдовец (вдова)");
        int.TryParse(Console.ReadLine(), out int maritalStatusInt);

       bool trueMaritalStatusInt = true;
      while (trueMaritalStatusInt)
      {
        if (maritalStatusInt == 1)
        {
          questionary.MaritalStatus = "Холост";
          overalMark.Mark++;
          trueMaritalStatusInt = false;
        }

        else if (maritalStatusInt == 2)
        {
          questionary.MaritalStatus = "Семьянин";
          overalMark.Mark += 2;
          trueMaritalStatusInt = false;
        }

        else if (maritalStatusInt == 3)
        {
          questionary.MaritalStatus = "В разводе";
          overalMark.Mark++;
          trueMaritalStatusInt = false;
        }

        else if (maritalStatusInt == 4)
        {
          questionary.MaritalStatus = "Вдовец, вдова";
          overalMark.Mark += 2;
          trueMaritalStatusInt = false;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Неправильная команда!\nПовторите попытку:");
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          Console.WriteLine("Укажите семейное положение: "); Console.ResetColor();
          Console.WriteLine("Введите [1], если холост (не замужем)\n" +
            "Введите [2], если семьянин\n" +
            "Введите [3], если в разводе\n" +
            "Введите [4], если вдовец (вдова)");
          int.TryParse(Console.ReadLine(), out maritalStatusInt);
        }
      }
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите сумму кредита: "); Console.ResetColor();
        questionary.CreditAmount = Convert.ToDecimal(Console.ReadLine());

        questionary.CreditAmount = (questionary.CreditAmount * 10) / 100 + questionary.CreditAmount; // добавила полную сумму с 10%

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите свой доход (в месяц) : "); Console.ResetColor();
        questionary.Imcome = Convert.ToDecimal(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите срок кредита, (в месяцах): "); Console.ResetColor();
        questionary.CreditTerm = Convert.ToInt32(Console.ReadLine());
      
        overalMark.Mark++;

        decimal percent = ((questionary.CreditAmount / questionary.CreditTerm) * 100) / questionary.Imcome; // для определения суммы кредита от общего дохода в процентах чтобы поставить балл
      
        if (percent < 80)
          overalMark.Mark += 4;

        else if (percent >= 80 && percent < 150)
          overalMark.Mark += 3;

        else if (percent >= 150 && percent < 250)
        overalMark.Mark += 2;

        else if (percent >= 250)
          overalMark.Mark++;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Кредитная история: "); Console.ResetColor();
        Console.WriteLine("(Количество, если нет кредитной истории введите [0]: )"); 
        questionary.CreditHitory = Convert.ToInt32(Console.ReadLine());

        if (questionary.CreditHitory >= 3)
          overalMark.Mark += 2;

        else if (questionary.CreditHitory >= 1 && questionary.CreditHitory <= 2)
          overalMark.Mark++;

        else if (questionary.CreditHitory == 0)
          overalMark.Mark--;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Просрочка в кредитной истории: "); Console.ResetColor();
        Console.WriteLine("Количество, если нет просрочки введите [0]");
        questionary.DelayInCredithistory = Convert.ToInt32(Console.ReadLine());
      
        if (questionary.DelayInCredithistory > 7)
          overalMark.Mark -= 3;
      
        else if (questionary.DelayInCredithistory >= 5 && questionary.DelayInCredithistory <= 7)
          overalMark.Mark -= 2;
      
        else if (questionary.DelayInCredithistory == 4)
          overalMark.Mark--;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Введите цель кредита: "); Console.ResetColor();
        Console.WriteLine("Введите [1] для Бытовой техники\n" +
          "Введите [2] для ремонта\n" +
          "Введите [3] для телефона\n" +
          "Введите [4] Для прочего");
          questionary.PurposeOfCredit = Convert.ToInt32(Console.ReadLine());
        if (questionary.PurposeOfCredit == 1)
          overalMark.Mark += 2;
        
        else if (questionary.PurposeOfCredit == 2)
          overalMark.Mark++;
        
        else if (questionary.PurposeOfCredit == 4)
          overalMark.Mark--;

        overalMark.ReplyToTheApplicationRus(overalMark.Mark);
      }
    }
    public void InsertIntoPersonalAccountEng()
    {
      Console.WriteLine();
    }
  }
}