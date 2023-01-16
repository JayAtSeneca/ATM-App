using System;

public class CardHolder
{
    String m_cardNum;
    int m_pin;
    String m_firstName;
    String m_lastName;
    double m_balance;

    public CardHolder(String cardNum, int pin, String firstName, String lastName,  double balance)
    {
        this.m_cardNum = cardNum;
        this.m_firstName = firstName;
        this.m_lastName = lastName;
        this.m_pin = pin;
        this.m_balance = balance;
    }

    public String getNum()
    {
        return this.m_cardNum;
    }

    public int getPin()
    {
        return this.m_pin;
    }

    public String getFirstName()
    {
        return this.m_firstName;
    }

    public String getLastName()
    {
        return this.m_lastName;
    }

    public double getBalance()
    {
        return this.m_balance;
    }

    public void setNum(String cardNum)
    {
        this.m_cardNum = cardNum;
    }

    public void setPin(int pin)
    {
        this.m_pin = pin;
    }

    public void setFirstName(String firstName)
    {
        this.m_firstName = firstName;
    }

    public void setLastName(String lastName)
    {
        this.m_lastName = lastName;
    }

    public void setBalance(double balance)
    {
        this.m_balance = balance;
    }

    public static void Main(String[] args)
    {
         void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentuser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double amountDeposit = Double.Parse(Console.ReadLine());
            currentuser.setBalance(amountDeposit + currentuser.getBalance());
            Console.WriteLine($"Thank you for your $$. Your new balance is: {currentuser.getBalance()}");

        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            double amountWithdraw = Double.Parse(Console.ReadLine());

            if(currentUser.getBalance() < amountWithdraw)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - amountWithdraw);
                Console.WriteLine($"Thank you. Your withdrawl amount ${currentUser.getBalance() - amountWithdraw}");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine($"Current Balance: ${currentUser.getBalance()}");
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4532 4321 2468 6824", 1234, "John", "Doe", 150.31));
        cardHolders.Add(new CardHolder("4532 2468 6824 4321", 4321, "Ashley", "Jones", 321.13));
        cardHolders.Add(new CardHolder("4321 2468 6824 4532", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new CardHolder("2468 6824 4532 4321", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new CardHolder("6824 4532 4321 2468", 4826, "Dawn", "Smith", 54.27));

        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your card number: ");
        String debitCardNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.Find(a => a.getNum() == debitCardNum);
                if(currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognised. Please try again..");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognised. Please try again..");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incoreect Pin. Please try again..");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again..");
            }
        }
    }
}
