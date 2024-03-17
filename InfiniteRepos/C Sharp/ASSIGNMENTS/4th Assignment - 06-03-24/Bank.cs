using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace assignment4
{
    class Bank
    {
        public float balance;

        public Bank(int amount)
        {
            balance = amount;
        }

        public void deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Write a valid amount ");
            }
            else
            {
                balance += amount;
                Console.WriteLine("Amount deposited successfully");
            }
        }

        public void withdrawal(int amount)
        {
            if (amount > balance)
            {
                throw new InsufficientAmountException("Insufficient balance for withdrawal.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Amount withdrawn successfully");
            }
        }
    }

    class InsufficientAmountException : Exception
    {
        public InsufficientAmountException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }

    class Solution
    {
        public static void Main()
        {
            Bank bs = new Bank(3000);
            bs.deposit(400);
            bs.withdrawal(40);
            Console.ReadKey();
        }
    }
}
