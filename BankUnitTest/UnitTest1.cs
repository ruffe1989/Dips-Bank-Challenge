using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dips_Bank_Challenge;

namespace BankUnitTest
{
    [TestClass]
    //A test to check if it is possible to create a new Person
    public class PersonClassTest
    {
        [TestMethod]
        public void CreatePerson()
        {
            Person testPerson = new Person("Test");
            Assert.AreEqual(testPerson.Name, "Test");
        }
        
    }
    [TestClass]
    //A test to check if it is possible to use the Money constructor
    public class MoneyClassTest
    {
        [TestMethod]
        public void AddMoney()
        {
            decimal testAmount = 1000;
            Money testMoney = new Money(testAmount);
            Assert.AreEqual(testMoney.Value, testAmount);
        }
    }
    [TestClass]
    //A test to check if it is possible to create a account
    public class AccountClassTest
    {
        [TestMethod]
        public void AddAccount()
        {
            decimal testAmount = 1000;
            Person testPerson = new Person("Test");
            Money testMoney = new Money(testAmount);
            Account testAccount = new Account(testMoney, testPerson);
        }
    }

    [TestClass]
    //Test to check if the serial is incremented
    public class PersonMethodClassTest
    {
        [TestMethod]
        public void IncrementSerialTest()
        {
            decimal testAmount = 1000;
            Person testPerson = new Person("Test");
            Money testMoney = new Money(testAmount);
            Account testAccount = new Account(testMoney, testPerson);        
            Assert.AreEqual(testAccount.customer.SerialNr, 1);
            
        }
    }
    [TestClass]
    //This class has several methods that check methods in the Bank.cs file
    public class BankClassTest
    {
        [TestMethod]
        //A test to check that it is possible to create a account
        public void CreateAccountTest()
        {
            decimal PersonAmount = 6000;
            decimal AccountAmount = 1000;

            Money MoneyPerson = new Money(PersonAmount);
            Money MoneyAccount = new Money(AccountAmount);
            Person testCustomer = new Person("Heine");
            Bank testBank = new Bank("BankWorking");
            Account testAccount = new Account(MoneyAccount, testCustomer);

            testCustomer.PersonAmount = MoneyPerson;
            testBank.CreateAccount(testCustomer, MoneyAccount);

            int indexAccount = testCustomer.Accounts.Length - 1;
            Assert.AreEqual(testAccount.amount.Value, testCustomer.Account[indexAccount].amount.Value);

            Assert.AreEqual(AccountAmount, testCustomer.Account[indexAccount].amount.Value);
        }
        [TestMethod]
        //ExpectedException is used when there is a method that there has been made a exception
        [ExpectedException(typeof(ArgumentException))]
        //A test to check if the program detects that there is something wrong when creating account
        public void CreateAccountFail()
        {
            decimal PersonAmount = 600;
            decimal AccountAmount = 1000;

            Money MoneyPerson = new Money(PersonAmount);
            Money MoneyAccount = new Money(AccountAmount);
            Person testCustomer = new Person("Heidi");
            Bank testBank = new Bank("BankWorking");

            testCustomer.PersonAmount = MoneyPerson;
            testBank.CreateAccount(testCustomer, MoneyAccount);
        }
        [TestMethod]
        public void GetAccountsForCustomerTest()
        {
            decimal testMoney = 300;

            Bank testBank = new Bank("New");
            Person testPerson = new Person("Rolf");
            Money moneyAccount = new Money(testMoney);
            Account testAccount = new Account(moneyAccount, testPerson);

            Assert.AreEqual(testBank.GetAccountsForCustomer(testPerson).Length, 0);

            testPerson.NewAccount(testAccount);

            int PersonAccountIndex = testPerson.Accounts.Length - 1;
            Assert.AreEqual(testAccount, testBank.GetAccountsForCustomer(testPerson)[PersonAccountIndex]);
        }
        [TestMethod]
        //A test if the Deposit method works
        public void DepositTest()
        {
            decimal testMoney = 300;
            decimal testAccountMoney = 300;

            Bank testBank = new Bank("New");
            Person testPerson = new Person("Rolf");
            Money moneyDeposit = new Money(testMoney);
            Money moneyAccount = new Money(testAccountMoney);
            Account testAccount = new Account(moneyAccount, testPerson);

            testBank.Deposit(testAccount, moneyDeposit);

            Assert.AreEqual(testAccount.amount.Value, testAccountMoney + testMoney);

        }
        [TestMethod]
        //And a test if a fail is detected
        [ExpectedException(typeof(ArgumentException))]
        public void DepositTestFail()
        {
            decimal testMoney = -300;
            decimal testAccountMoney = 300;

            Bank testBank = new Bank("New");
            Person testPerson = new Person("Rolf");
            Money moneyDeposit = new Money(testMoney);
            Money moneyAccount = new Money(testAccountMoney);
            Account testAccount = new Account(moneyAccount, testPerson);

            testBank.Deposit(testAccount, moneyDeposit);

            Assert.AreEqual(testAccount.amount.Value, testAccountMoney + testMoney);

        }
        [TestMethod]
        //Testing the withdraw method
        public void WithdrawTest()
        {
            decimal testMoney = 300;
            decimal testAccountMoney = 1000;

            Bank testBank = new Bank("New");
            Person testPerson = new Person("Rolf");
            Money moneyWithdraw = new Money(testMoney);
            Money moneyAccount = new Money(testAccountMoney);
            Account testAccount = new Account(moneyAccount, testPerson);

            testBank.Withdraw(testAccount, moneyWithdraw);

            Assert.AreEqual(testAccount.amount.Value, testAccountMoney - testMoney);

        }
        [TestMethod]
        //Checking if there is a fail in withdraw method
        [ExpectedException(typeof(ArgumentException))]
        public void WithdrawTestFail()
        {
            decimal testMoney = 3000;
            decimal testAccountMoney = 2000;

            Bank testBank = new Bank("New");
            Person testPerson = new Person("Rolf");
            Money moneyDeposit = new Money(testMoney);
            Money moneyAccount = new Money(testAccountMoney);
            Account testAccount = new Account(moneyAccount, testPerson);

            testBank.Withdraw(testAccount, moneyDeposit);
        }
        [TestMethod]
        //Testing the transfer method
        public void TransferTest()
        {
            decimal testMoney = 300;
            decimal testAccountMoney1 = 2000;
            decimal testAccountMoney2 = 2000;

            Bank testBank = new Bank("New");
            Person testPerson1 = new Person("Rolf");
            Person testPerson2 = new Person("Ivar");
            Money moneyTransfer = new Money(testMoney);
            Money moneyAccount1 = new Money(testAccountMoney1);
            Money moneyAccount2 = new Money(testAccountMoney2);
            Account testAccount1 = new Account(moneyAccount1, testPerson1);
            Account testAccount2 = new Account(moneyAccount2, testPerson2);

            testBank.Transfer(testAccount1, testAccount2, moneyTransfer);

            Assert.AreEqual(testAccount1.amount.Value, testAccountMoney1 - testMoney);
            Assert.AreEqual(testAccount2.amount.Value, testAccountMoney1 + testMoney);

        }
    }
}
