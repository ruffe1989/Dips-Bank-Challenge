using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dips_Bank_Challenge
{
    public class Money
    {
        //Since this variable is money it is smart to use decimal instead of double
        public decimal Value { get; set; }

        //Constructor
        public Money(decimal value)
        {
            Value = value;
        }
    }
}
