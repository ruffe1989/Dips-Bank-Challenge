using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dips_Bank_Challenge
{
    public class Bank
    {
        //Initiation of variables with .NET get and set syntax
        public string BankName { get; set; }
        /* I have chosen to set a constant with the value of 50. 
         * It will not be possible to do a transaction below that amount*/
        public const decimal AllowedValue = 50;

        //Constructor
        public Bank(string name)
        {
            BankName = name;
        }
        //Method to create a account
        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            if (ValidFirstDeposit(customer, initialDeposit))
            {
                Account newAccount = new Account(initialDeposit, customer);
                customer.PersonAmount = new Money(customer.PersonAmount.Value - initialDeposit.Value);
                customer.NewAccount(newAccount);
                return newAccount;
            }
            return null;
        }
        //Method to show all account that one person has
        public Account[] GetAccountsForCustomer(Person customer) => customer.Accounts;

        //Deposit method
        public void Deposit(Account to, Money amount)
        {
            if (AllowedTransaction(amount))
            {
                throw new ArgumentException("You have not enough funds to do the deposit.\n" +
                                            "The amount has to be higher then 100 and your amount is: "
                                            + amount.Value);                
            }
            else
            {
                to.amount = new Money(to.amount.Value + amount.Value);
            }
        }

        //Withdraw method
        public void Withdraw(Account from, Money amount)
        {
            if (ValidTransaction(from, amount))
            {
                from.amount = new Money(from.amount.Value - amount.Value);
            }
            

        }       

        //Transfer method
        public void Transfer(Account from, Account to, Money amount)
        {
            if (ValidTransaction(from, amount))
            {
                Withdraw(from, amount);
                Deposit(to, amount);
            }

        }        
        /*Help methods*/
        //Method that check if the amount has the correct amount and its not enough money
        private bool ValidFirstDeposit(Person customer, Money amount)
        {
            if (AllowedTransaction(amount))
            {
                throw new ArgumentException("The amount is negativ. Your amount is: " + amount.Value);
            }
            if (customer.PersonAmount.Value <= amount.Value)
            {
                throw new ArgumentException("You have not enough money for first deposit. Your fund is"
                                            + customer.PersonAmount.Value);
            }
            return true;
        }
        //Method to check that valu is not less then allowed value
        private bool AllowedTransaction(Money amount)
        {
            if (amount.Value < AllowedValue)
            {
                return true;
            }
            return false;
        }
        //Method to check that the transaction i possible to do
        private bool ValidTransaction(Account from, Money amount)
        {
            if (AllowedTransaction(amount))
            {
                throw new ArgumentException("The amount is negativ. Your amount is: " + amount.Value);
            }
            if (from.amount.Value <= amount.Value)
            {
                throw new ArgumentException("You have not enough money for the transaction. Your fund is"
                                            + from.amount.Value);
            }
            return true;
        }
        
        

    }
}
