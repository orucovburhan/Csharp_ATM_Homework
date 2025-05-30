namespace homework5_Bank;

public class BankCard
{
    public BankCard(string bankName, string fullname, string pan, string pin, string expDate, int budget)
    {
        BankName = bankName;
        Fullname = fullname;
        PAN = pan;
        PIN = pin;
        Random rng = new Random();
        CVC=rng.Next(100,999);
        ExpDate = expDate;
        Budget = budget;
    }

    public string BankName { get; set; }
    public string Fullname { get; set; }
    public string PAN { get; set; }
    public string PIN { get; set; }
    public int CVC { get; set; }
    public string ExpDate { get; set; }
    public int ?Budget { get; set; }
    
}