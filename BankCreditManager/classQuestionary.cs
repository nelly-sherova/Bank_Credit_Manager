using System;

namespace BankCreditManager
{
  public class Questionary // анкета 
  {
    public int Id {get; set;}
    
    public int Age {get; set;}

    public string MaritalStatus { get; set; } // семейное положение

    public decimal CreditAmount { get; set; } // сумму кредита

    public decimal Imcome { get; set; } // доход

    public int CreditHitory { get; set; }

    public int DelayInCredithistory { get; set; } // просрочка в кредитной истории

    public int PurposeOfCredit { get; set; } // цель кредита 
    
    public int CreditTerm { get; set; } // срок кредита
    
     public DateTime DateOfApplication { get; set; } // дата заявки
  }
}