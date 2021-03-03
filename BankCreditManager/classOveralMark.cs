using System;

namespace BankCreditManager
{
  public class OveralMark
  {
    public int Id {get; set;}

    public double Mark = 0;

    public string ReplyToApplication { get; set; }

    /// <summary>
    /// Метод для вывода результата заявки на кредит
    /// </summary>
    /// <param name="Баллы"></param>
    public void ReplyToTheApplicationRus(double Mark)
    {
      if (Mark >= 11)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ваша заявка на кредит одобрена!"); Console.ResetColor();
        Console.WriteLine("Ответ - Да");
        ReplyToApplication = "Да";
      }
                
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ваша заявка на кредит отклонена!"); Console.ResetColor();
        Console.WriteLine("Ответ - Нет");
        ReplyToApplication = "Нет";
      }
    }
  }
}