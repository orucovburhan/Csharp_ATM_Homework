using System.Transactions;

namespace homework5_Bank;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname{get; set; }
    public BankCard Card { get; set; }
    
    public string[] Transactions{get; set;}
    
    public Client(string name, string surname, BankCard card)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Card = card;
    }
    
}