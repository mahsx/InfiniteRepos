using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Accounts
    {
        private string accountNo;
        private string customerName;
        private double balance;

        public Accounts(string accountNo, string customerName)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.balance = 0;
        }

        public void Deposit(double amount)
        {
            this.balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (this.balance >= amount)
            {
                this.balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance for withdrawal.");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Account No: {accountNo}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Balance: {balance}");
        }

        public static void Main()
        {
            Console.Write("Enter Account No: ");
            string accountNo = Console.ReadLine();

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Accounts account1 = new Accounts(accountNo, customerName);

            while (true)
            {
                Console.WriteLine("\nChoose transaction type:");
                Console.WriteLine("D -> Deposit");
                Console.WriteLine("W -> Withdrawal");
                string transactionType = Console.ReadLine().ToUpper();

                if (transactionType == "D")
                {
                    Console.Write("Enter amount to deposit: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    account1.Deposit(amount);
                }
                else if (transactionType == "W")
                {
                    Console.Write("Enter amount to withdraw: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    account1.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Invalid transaction type. Please enter D or W.");
                }

                account1.DisplayInfo();
            }
        }
    }
}
