
using System.Transactions;

namespace homework5_Bank;

public class Bank
{
    public Client[] clients = new Client[] { };
    public int SearchClient(string PAN)
    {
        for (int i = 0; i < clients.Length; i++)
        {
            if (clients[i].Card.PAN == PAN)
                return i;
        }
        return -1;
    }
    static string[] AddStringToArray(string[] array, string newString)
    {
        if (array == null)
        {
            return new string[] { newString };
        }
        string[] newArray = new string[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[array.Length] = newString;
        return newArray;
    }
    public void ShowBudget(string PAN, string PIN)
    {
        Console.Clear();
        int index = SearchClient(PAN);
        if (index != -1)
        {
            if (clients[index].Card.PIN == PIN)
                Console.WriteLine($"Budget: {clients[index].Card.Budget} AZN");
            else
                throw new ApplicationException("PIN does not match");
            
        }
        else
        {
            throw new ApplicationException("Client not found");
        }
    }
    
    public void Withdraw(string PAN, string PIN,int amount)
    {
        int index = SearchClient(PAN);
        if (index != -1)
        {
            if (clients[index].Card.PIN == PIN)
            {
                if (clients[index].Card.Budget >= amount)
                {
                    clients[index].Card.Budget -= amount;
                    Console.WriteLine("Success");

                    clients[index].Transactions =AddStringToArray(clients[index].Transactions, $"Withdraw {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}");
                }
                else
                {
                    throw new ApplicationException("Insufficient balance");
                }
            }
            else
            {
                throw new ApplicationException("PIN does not match");
            }
        }
        else
        {
            throw new ApplicationException("Client not found");
        }
    }
    public void Transfer(string PAN, string PANtoTransfer, string PIN, int sendAmount)
    {
        int index = SearchClient(PAN);
        int index2 = SearchClient(PANtoTransfer);
        if (index != -1)
        {
            if (clients[index].Card.PIN == PIN)
            {
                if (index2 != -1)
                {
                    if (clients[index].Card.Budget >= sendAmount)
                    {
                        clients[index].Card.Budget -= sendAmount;
                        clients[index2].Card.Budget += sendAmount;
                        Console.WriteLine("Succesfully transfered...");
                        clients[index].Transactions =AddStringToArray(clients[index].Transactions, $"Transfer {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}");
                    }
                    else
                    {
                        throw new InsufficientBalanceException("Insufficient balance");
                    }
                }
                else
                {
                    throw new NotFoundException("There is no correct PAN to transfer");
                }
            }
            else
            {
                throw new PINCanNotMatchException("PIN does not match");
            }
        }
        else
        {
            throw new NotFoundException("Client not found");
        }
    }

    public void ShowHistory(string PAN, string PIN)
    {
        int index = SearchClient(PAN);
        if (index != -1)
        {
            if (clients[index].Transactions != null)
            {
                if (clients[index].Card.PIN == PIN)
                {
                    Console.WriteLine("Today: ");
                    for (int i = 0; i < clients[index].Transactions.Length; i++)
                    {
                        string str = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}";
                        if (clients[index].Transactions[i].Contains(str))
                        {
                            Console.WriteLine(clients[index].Transactions[i]);
                        }
                    }

                    Console.WriteLine("\nLast 5 days: ");
                    for (int i = 0; i < clients[index].Transactions.Length; i++)
                    {
                        if (int.Parse(clients[index].Transactions[i].Substring(9, 2)) < DateTime.Now.Day &&
                            int.Parse(clients[index].Transactions[i].Substring(9, 2)) > DateTime.Now.Day - 5 &&
                            int.Parse(clients[index].Transactions[i].Substring(12, 2)) == DateTime.Now.Month &&
                            int.Parse(clients[index].Transactions[i].Substring(15, 4)) == DateTime.Now.Year)
                        {
                            Console.WriteLine(clients[index].Transactions[i]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You do not have any transactions yet");
            }
        }
        
    }

   
}

