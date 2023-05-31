using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankApplication.MSTest
{
    [TestClass]
    public class BankSystemTests
    {
        [TestMethod]
        public void SavingsAccount_Is_The_Interest_Correct_Calculated_By_The_Year()
        {

            // Arrange

            Tuple<string, string, float> Vacation = new Tuple<string, string, float>("1", "Vacation", 20f);
            Tuple<string, string, float> Pension = new Tuple<string, string, float>("2", "Pension", 2.42f);
            Tuple<string, string, float> Childsavings = new Tuple<string, string, float>("3", "Childsavings", 3.49f);

            
            // Act

            float vacExpected = 120;
            float penExpected = 102.42f;
            float chiExpected = 103.49f;


            // Assert

            Assert.AreEqual(Rate(Vacation.Item3), vacExpected);
            Assert.AreEqual(Rate(Pension.Item3), penExpected);
            Assert.AreEqual(Rate(Childsavings.Item3), chiExpected);


        }

        public float Rate(float Rate)
        {

            // Actual

            float Depo = 100;
            float interestAmount = Depo * (Rate / 100);
            float TotalAmount = Depo + interestAmount;

            return TotalAmount;
        }

        [TestMethod]
        public void OpenAccount_AddsAccountToAccounts()
        {
            // Arrange

            var customer1Dict = new Dictionary<string, List<string>>()
            {
            { "Sparkonto", new List<string>() { 1000.0f.ToString(), "kr", "Personkonto" } },
            { "Lönekonto", new List<string>() { 2000.0f.ToString(), "$", "Personkonto" } }
            };
            var customer = new Customer("Anas", "111", new Dictionary<string, List<string>>());

            customer.accounts = customer1Dict;

            string newAccChoice = "NewAccount";
            string curChoice = "kr";

            // Act
            BankSystem.OpenAccount(customer, newAccChoice, curChoice);

            // Assert
            Assert.IsTrue(customer.accounts.Count == 3);
        }

        [TestMethod]
        public void CustomerCreation_If_the_Customer_is_Created()
        {
            //Arrange

            string name = "Damir";
            string password = "Mehic";

            //Act

            BankSystem.CustomerCreation(name, password);

            //Assert

            Assert.IsNotNull(Users.customerList);
        }

      


    }
}
