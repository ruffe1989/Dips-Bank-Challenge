using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dips_Bank_Challenge
{
    public class Account
    {
        //Initiation of variables with .NET get and set syntax
        public Money amount { get; set; }
        public Person customer { get; set; }
        public string name { get; set; }

        //Constructor
        public Account (Money money, Person client)
        {
            client.IncrementSerialNr();
            amount = money;
            customer = client;
            name = client.Name + " Serial nr: " + client.SerialNr;
        }
    }
}
