using System;
using System.Data.SqlClient;
using System.Data;
namespace BankCreditManager
{
  public class PersonalAccount
  {
    public const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=BankCreditManager; Integrated Security = True";
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

    public void SelectAllApplicationsAdmin()
    {
      string  sqlExpression = $"Select * from OveralMark";
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
          connection.Open();
          SqlCommand command = new SqlCommand(sqlExpression, connection);
          var reader = command.ExecuteReader();
          while (reader.Read())
          {
              Console.WriteLine($"ID: {reader.GetValue(0)}, | Баллы:  {reader.GetValue(1)} | Ответ на заявку:{reader.GetValue(2)} | Имя :  {reader.GetValue(4)} | Фамилия: {reader.GetValue(5)} | Отчество: {reader.GetValue(6)} ");
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


    public void Input()
    {
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите логин: "); Console.ResetColor();
      string login = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите пароль: "); Console.ResetColor();
      string password = Console.ReadLine();
      string  sqlExpressionn = $"Select * from PassportData where PassportData.Login = '{login}' AND PassportData.Password = '{password}'";
      using (SqlConnection connectionn = new SqlConnection(connectionString))
      {
          connectionn.Open();
          SqlCommand commandd = new SqlCommand(sqlExpressionn, connectionn);
          var reader1 = commandd.ExecuteReader();
          while (reader1.Read())
          {
              var user = new PassportData(){
                Id = Convert.ToInt32(reader1.GetValue(0)),
                Login = Convert.ToString(reader1.GetValue(1)),
                Password = Convert.ToString(reader1.GetValue(2)),
                FirstName = Convert.ToString(reader1.GetValue(3)),
                LastName = Convert.ToString(reader1.GetValue(4)),
                MiddleName = Convert.ToString(reader1.GetValue(5)),
                Pol = Convert.ToString(reader1.GetValue(6)),
                Nationality = Convert.ToString(reader1.GetValue(7)),
                PassportSeries = Convert.ToString(reader1.GetValue(8)),
                NationalId = Convert.ToString(reader1.GetValue(9)),
                Address = Convert.ToString(reader1.GetValue(10)),
                DateOfBirth = Convert.ToDateTime(reader1.GetValue(11))
              };
              passportData = user;
               Console.WriteLine($"ID: {reader1.GetValue(0)}, Логин:{reader1.GetValue(1)} | Имя:{reader1.GetValue(3)} | Фамилия:{reader1.GetValue(4)} | Отчество:{reader1.GetValue(5)} | Пол:{reader1.GetValue(6)}| Гражданство: {reader1.GetValue(7)} | Серия паспорта: {reader1.GetValue(8)} | ИНН {reader1.GetValue(9)} | Адрес: {reader1.GetValue(10)} | Дата рождения: {reader1.GetValue(11)}");
            
               
          }
      }
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.WriteLine("Выберите действие: ");
      Console.ResetColor();
      Console.WriteLine("Введите [1] для того чтобы оставить заявку на кредит: ");
      Console.WriteLine("Любой другой ввод - выход");

      int command = Convert.ToInt32(Console.ReadLine());

      if (command == 1)
      {
        Appliation();
      }
      else 
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Выход!");
        Console.ResetColor();
      }
      
    }
    public void Appliation()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("То поле в котором есть [*] может быть пустым!"); // но посмотреть чтобы не осталось только имя

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      questionary.FirstName = passportData.FirstName;
      

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      questionary.LastName =  passportData.LastName;

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      questionary.MiddleName = passportData.MiddleName;

      questionary.Nationality = passportData.Nationality;

        if (questionary.Nationality == "Таджикистан")
          overalMark.Mark++;

      
        questionary.Pol = passportData.Pol;
      
        if (TrimCommand(questionary.Pol) == "жен")
          overalMark.Mark += 2;

        else if (TrimCommand(questionary.Pol) == "муж")
          overalMark.Mark++;
        
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        questionary.DateOfBirth = passportData.DateOfBirth;

        questionary.DateOfApplication = DateTime.Now;
        questionary.Age = Convert.ToInt32(DateTime.Now.Year - passportData.DateOfBirth.Year);
        if (DateTime.Now.Month < passportData.DateOfBirth.Month)
          questionary.Age--;

        if (questionary.Age < 18)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Возраст меньше 18!");
          Console.ResetColor();
          overalMark.Mark -= 12;
        }

        if (questionary.Age >= 26 && questionary.Age <= 35)
          overalMark.Mark++;
        else if (questionary.Age >= 36 && questionary.Age <= 62)
          overalMark.Mark += 2;
        else if (questionary.Age > 62)
          overalMark.Mark++;

        questionary.DateOfApplication = DateTime.Now;

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
        bool trueCreditAmount = true; // для проверки если сумма кредита <= 0
        while(trueCreditAmount)
        {
          if (questionary.CreditAmount <= 0)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сумма кредита не может быть <= 0");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Повторите попытку : ");
            Console.ResetColor();
            questionary.CreditAmount = Convert.ToDecimal(Console.ReadLine());
            if (questionary.CreditAmount > 0)
              trueCreditAmount = false;
          }
          else
            trueCreditAmount = false;
        }

        questionary.CreditAmount = (questionary.CreditAmount * 10) / 100 + questionary.CreditAmount; // добавила полную сумму с 10%

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите свой доход (в месяц) : "); Console.ResetColor();
        questionary.Imcome = Convert.ToDecimal(Console.ReadLine());
        bool trueIncome = true; // для проверки, доход < 0
        while(trueIncome)
        {
          if (questionary.Imcome < 0)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Доход не может быть отрицательным числом!");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Повторите попытку: ");
            questionary.Imcome = Convert.ToDecimal(Console.ReadLine());
            if (questionary.Imcome >= 0)
            trueIncome = false;
          }
          else
            trueIncome = false;
        }

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите срок кредита, (в месяцах): "); Console.ResetColor();
        questionary.CreditTerm = Convert.ToInt32(Console.ReadLine());
        bool trueCreditTerm = true; // для проверки правильности срока <= 0
        while (trueCreditTerm)
        {
          if (questionary.CreditTerm <= 0 || questionary.CreditTerm > 24)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Срок кредита не может быть отрицательным, нулевым числом или числом больше чем 24 месяца");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Повторите попытку : ");
            Console.ResetColor();
            questionary.CreditTerm = Convert.ToInt32(Console.ReadLine());
            if (questionary.CreditTerm > 0 && questionary.CreditTerm <= 24)
              trueCreditTerm = false;
          }
          else
            trueCreditTerm = false;
        }
      
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
        bool trueCreditHistory = true;
        while (trueCreditHistory)
        {
          if (questionary.CreditHitory < 0)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Кредитная история не может быть < 0");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Повторите попытку : ");
            Console.ResetColor();
            questionary.CreditHitory = Convert.ToInt32(Console.ReadLine());
            if (questionary.CreditHitory >= 0)
              trueCreditHistory = false;
         }
            else
              trueCreditHistory = false;
        }

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
        bool trueDelayInCreditHistory = true; // для проверки просрочка < 0
        while (trueDelayInCreditHistory)
        {
          if (questionary.DelayInCredithistory < 0)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Просрочка в кредитной истории не может быть < 0");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Повторите попытку : ");
            Console.ResetColor();
            questionary.DelayInCredithistory = Convert.ToInt32(Console.ReadLine());
            if (questionary.DelayInCredithistory >= 0)
                trueDelayInCreditHistory = false;
            }
            else
                trueDelayInCreditHistory = false;
        }

      
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
        bool truePurposeOfCredit = true;
        while (truePurposeOfCredit)
        {
          if (questionary.PurposeOfCredit <= 0 || questionary.PurposeOfCredit > 4)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Введена неправильная команда!");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Повторите попытку!");
            Console.ResetColor();
            Console.WriteLine("Введите [1] для Бытовой техники\n" +
              "Введите [2] для ремонта\n" +
              "Введите [3] для телефона\n" +
              "Введите [4] Для прочего");
            questionary.PurposeOfCredit = Convert.ToInt32(Console.ReadLine());
            if (questionary.PurposeOfCredit > 0 && questionary.PurposeOfCredit <= 4)
              truePurposeOfCredit = false;
          }
          else
            truePurposeOfCredit = false;
        }


        if (questionary.PurposeOfCredit == 1)
        {
          overalMark.Mark += 2;
          questionary.PurposeOfCrditString = "Бытовая техника";
        }
          
        
        else if (questionary.PurposeOfCredit == 2)
        {
          overalMark.Mark++;
          questionary.PurposeOfCrditString = "Ремонт";
        }

          
        
        else if (questionary.PurposeOfCredit == 4)
        {
          overalMark.Mark--;
          questionary.PurposeOfCrditString = "Прочее";
        }
          
        else if (questionary.PurposeOfCredit == 3)
        {
          questionary.PurposeOfCrditString = "Телефон";
        }
        questionary.UserId = passportData.Id;

        InsertIntoQuestionary(questionary.UserId);

        overalMark.ReplyToTheApplicationRus(overalMark.Mark);
        
        InsertIntoOveralMark(questionary.UserId);

        if (overalMark.ReplyToApplication == "Да")
        {
          CreditRepaymentSchedule();
        }

  }

    /// <summary>
    /// Функция для заполнения данных и вставки их в таблицу PersonalAccount
    /// </summary>
    public void InformationRus()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("То поле в котором есть [*] может быть пустым!"); // но посмотреть чтобы не осталось только имя

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите имя: "); Console.ResetColor(); 
      passportData.FirstName = Console.ReadLine();

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите фамилию [*]: "); Console.ResetColor(); 
      passportData.LastName = Console.ReadLine();

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите отчество: "); Console.ResetColor(); 
      passportData.MiddleName = Console.ReadLine();

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.Write("Введите логин (номер телефона): "); Console.ResetColor(); Login = Console.ReadLine(); //посмотреть чтобы сюда не попали буквы и символы

      bool trueNumber = true; // для правильности номера
      while (trueNumber)
      {  
        if (PhoneNumberVertification(Login) == false || Login.Length != 9)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("Введите правильный номер телефона!");
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          Console.Write("Повторите попытку: ");
          Login = Console.ReadLine();
          if (PhoneNumberVertification(Login) == true && Login.Length == 9)
            trueNumber = false;
        }
        if (PhoneNumberVertification(Login) == true && Login.Length == 9)
        {
          trueNumber = false;
        }
      }

      bool truePassword = true; // для правильности пароля
      bool continueInsert = false; // для продолжения программы есди пароль правильный или неправильный
      string testPassword1, testPassword2; // для проверки правильности пароля
      int countOfWhileTruePassword = 0; // количество попыток для введения пароля 

      while (truePassword)
      {
        countOfWhileTruePassword++;
        if (countOfWhileTruePassword == 3) 
          truePassword = false;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите пароль: (больше 4 символов) "); Console.ResetColor(); 
        testPassword1 = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Повторите пароль: "); Console.ResetColor(); 
        testPassword2 = Console.ReadLine();
        if (testPassword1.Length >= 4)
        {
          if (testPassword1 == testPassword2)
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
        else
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Длина пароля меньше чем 4!");
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
        bool truePol = true;
        while(truePol)
        {
            if (TrimCommand(passportData.Pol) != "жен" && TrimCommand(passportData.Pol) != "муж")
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Пол указан неверно!");
              Console.ForegroundColor = ConsoleColor.DarkBlue;
              Console.WriteLine("Повторите попытку!");
              Console.ResetColor();
              Console.WriteLine("[жен] для женского пола\n" +
                "[муж] для мужского");
              passportData.Pol = Console.ReadLine();
              if (TrimCommand(passportData.Pol) == "жен" || TrimCommand(passportData.Pol) == "муж")
                truePol = false;
            }
              else
                truePol = false;
        }
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Гражданство: "); Console.ResetColor();
        Console.WriteLine("Для гражданства Таджикистан введите: [Таджикистан]\n" +
          "Другое [Другое]");
        passportData.Nationality = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Введите дату рождения: "); Console.ResetColor();
        Console.WriteLine("Формат: [день.месяц.год]");
        passportData.DateOfBirth = Convert.ToDateTime(Console.ReadLine()); 

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите адрес: "); Console.ResetColor();
        passportData.Address = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите серию паспорта: "); Console.ResetColor();
        passportData.PassportSeries = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Введите ИНН: "); Console.ResetColor();
        passportData.NationalId = Console.ReadLine();

        InsertIntoPassportData();
      }
    }
    /// <summary>
    /// График погашения кредита
    /// </summary>
    public void CreditRepaymentSchedule()
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("\t\tГрафик погашения кредита:");
      Console.ResetColor();
      int TermOfCredit = questionary.CreditTerm;
      int month = Convert.ToInt32(questionary.DateOfApplication.Month) + 1;
      int day = Convert.ToInt32(questionary.DateOfApplication.Day);
      int year = Convert.ToInt32(questionary.DateOfApplication.Year);
      if (questionary.DateOfApplication.Day > 28)
        day = 28;
      for (int i = 1; i <= questionary.CreditTerm; i++)
      {
        if (month <= 9 && day <= 9)
        {
           Console.WriteLine($"{i} взнос --> 0{day}.0{month}.{year} || сумма : {Math.Round((questionary.CreditAmount / questionary.CreditTerm),2)}");
        }
        else if (month <= 9 && day > 9)
        {
          Console.WriteLine($"{i} взнос --> {day}.0{month}.{year}  || сумма : {Math.Round((questionary.CreditAmount / questionary.CreditTerm), 2)}");
        }
        else if (month > 9 && month != 12 && day <= 9 )
        {
          Console.WriteLine($"{i} взнос --> 0{day}.{month}.{year}  || сумма : {Math.Round((questionary.CreditAmount / questionary.CreditTerm), 2)}");
        }
        else if (month > 9 && month != 12 && day > 9)
        {
          Console.WriteLine($"{i} взнос --> {day}.{month}.{year}  || сумма : {Math.Round((questionary.CreditAmount / questionary.CreditTerm), 2)}");
        }
        else if (month == 12 && day <= 9)
        {
          Console.WriteLine($"{i} взнос --> 0{day}.{month}.{year}  || сумма : {Math.Round((questionary.CreditAmount / questionary.CreditTerm), 2)}");
          month = 0;
          year++;
        }
        else if (month == 12 && day > 9)
        {
          Console.WriteLine($"{i} взнос --> 0{day}.{month}.{year}  || сумма : {Math.Round((questionary.CreditAmount / questionary.CreditTerm), 2)}");
          month = 0;
          year++;
        }
        month++; 
      }
    }
    /// <summary>
    /// Метод для вставки в таблицу данные PassportData
    /// </summary>
    public void InsertIntoPassportData()
    {
      string sqlExpression = $"INSERT INTO PassportData ([Login], [Password], [FirstName], [LastName], [MiddleName], [Pol], [Nationality], [PassportSeries], [NationalId], [Adress], [DateOfBirth]) VALUES ( '{Login}', '{Password}', '{ passportData.FirstName}', '{passportData.LastName}', '{passportData.MiddleName}', '{passportData.Pol}' , '{passportData.Nationality}', '{passportData.PassportSeries}', '{passportData.NationalId}', '{passportData.Address}', '{passportData.DateOfBirth}' )";
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        int number = Convert.ToInt32(command.ExecuteNonQuery());
        Console.WriteLine("Добавлено объектов: {0}", number);
     }
    }
    /// <summary>
    /// Метод для вставки в таблицу данные OveralMark
    /// </summary>
    public void InsertIntoOveralMark(int UserId)
    {
        
      string sqlExpression = $"INSERT INTO OveralMark ([Mark], [ReplyToApplication], [UserId], [FirstName], [LastName], [MiddleName]) VALUES ( '{overalMark.Mark}', '{overalMark.ReplyToApplication}', '{UserId}', '{passportData.FirstName}', '{passportData.LastName}', '{passportData.MiddleName}')";
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        int number = command.ExecuteNonQuery();
        Console.WriteLine("Добавлено объектов: {0}", number);
     }
    }
    /// <summary>
    /// Метод для вставки в таблицу данные PersonalAccount
    /// </summary>
    public void InsertIntoQuestionary(int UserId)
    {
      string sqlExpression = $"INSERT INTO Questionary ([FirstName], [LastName], [MiddleName], [Pol], [DateOfBirth], [Age], [MaritalStatus], [CreditAmount], [Income], [CreditHistory], [DelayInCreditHistory], [PurposeOfCrdit], [CreditTerm], [DateOfApplication], [UserId], [Nationality]) VALUES ('{ questionary.FirstName}', '{questionary.LastName}', '{questionary.MiddleName}', '{passportData.Pol}', '{passportData.DateOfBirth}', '{questionary.Age}','{questionary.MaritalStatus}','{questionary.CreditAmount}','{questionary.Imcome}', '{questionary.CreditHitory}', '{questionary.DelayInCredithistory}', '{questionary.PurposeOfCrditString}', '{questionary.CreditTerm}', '{questionary.DateOfApplication}', '{UserId}', '{passportData.Nationality}')";
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        int number = command.ExecuteNonQuery();
        Console.WriteLine("Добавлено объектов: {0}", number);
     }
    }
    public void InsertIntoPersonalAccountEng()
    {
      Console.WriteLine();
    }
  }
}