using homework5_Bank;


Client client1=new Client("Ramiz","Qasimli",(new BankCard("PAŞA Bank ASC","Ramiz Qasimli","5522898712342342","1234","08/2027",1507)));
Client client2=new Client("Nurlan","Mustafayev",(new BankCard("Expressbank ASC","Nurlan Mustafayev","9999888877776666","1313","09/2029",3516)));
Client client3=new Client("Aynur","Elizade",(new BankCard("Kapital Bank ASC","Aynur Elizade","4453243456752688","9823","11/2032",4023)));
Client client4=new Client("Afaq","Cavadzade",(new BankCard("ABB ASC","Afaq Cavadzade","1234432155443322","1987","05/2028",2051)));
Client client5=new Client("Malik","Agayev",(new BankCard("Yelo Bank ASC","Malik Agayev","4486975538559922","0612","02/2030",6033)));
Client[] clients=new Client[] { client1, client2, client3, client4 };
Bank bank=new Bank();
bank.clients=clients;

while (true)
{
    Console.WriteLine("Enter PAN: ");
    string pan=Console.ReadLine();
    Console.WriteLine("Enter PIN: ");
    string pin=Console.ReadLine();
    int index=bank.SearchClient(pan);
    if (index != -1)
    {
        if (bank.clients[index].Card.PIN == pin)
        {
            string choice;
            Console.WriteLine($"{bank.clients[index].Name} {bank.clients[index].Surname} welcome! ");
            Console.WriteLine("1.See your budget");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.History");
            Console.WriteLine("4.Transfer");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Choose: ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    bank.ShowBudget(pan,pin);
                    break;
                case "2":
                    decimal amount;
                    string choice2;
                    Console.WriteLine("1. 10 AZN");
                    Console.WriteLine("2. 20 AZN");
                    Console.WriteLine("3. 50 AZN");
                    Console.WriteLine("4. 100 AZN");
                    Console.WriteLine("5. Other");
                    Console.WriteLine("Choose: ");
                    choice2= Console.ReadLine();
                    switch (choice2)
                    {
                        case "1":
                            bank.Withdraw(pan,pin,10);
                            break;
                        case "2":
                            bank.Withdraw(pan,pin,20);
                            break;
                        case "3":
                            bank.Withdraw(pan,pin,50);
                            break;
                        case "4":
                            bank.Withdraw(pan,pin,100);
                            break;
                        case "5":
                            decimal amount2;
                            Console.WriteLine("Enter amount: \b");
                            amount2 = Convert.ToDecimal(Console.ReadLine());
                            bank.Withdraw(pan,pin,amount2);
                            break;
                    }

                    break;
                case "3":
                    bank.ShowHistory(pan,pin);
                    break;
                
            }
            



        }
        else
            Console.WriteLine("PIN does not match!");
    }
    else
    {
        Console.WriteLine("PAN does not match!");
    }


}
