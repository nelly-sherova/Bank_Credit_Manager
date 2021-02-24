using System;

namespace BankCreditManager
{
  public class Questionary // анкета 
  {
    public string MaritalStatus { get; set; } // семейное положение
    public decimal Imcome { get; set; } // доход
    public int CreditHitory { get; set; }
    public int DelayInCredithistory { get; set; } // просрочка в кредитной истории
    public int PurposeOfCredit { get; set; } // цель кредита 
    public int CreditTerm { get; set; } // срок кредита
  }
}