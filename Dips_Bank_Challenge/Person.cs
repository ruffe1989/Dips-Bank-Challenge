using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dips_Bank_Challenge
{
    public class Person
    {
        //Initiation of variables with .NET get and set syntax
        public string Name { get; set; }
        public int SerialNr { get; set; }
        public Money PersonAmount { get; set; }
        public List<Account> Account { get; set; }

        //Constructor
        public Person(string name)
        {
            Name = name;
            SerialNr = 0;
            Account = new List<Account>();
        }
        //Method to make the serial number increase
        public void IncrementSerialNr() => ++SerialNr;

        //Method to put all account into a array
        public Account[] Accounts => Account.ToArray();

        public void NewAccount(Account newAccount) => Account.Add(newAccount);

        
    }
}
