using NUnit.Framework;
using CheckoutKata;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class CheckoutIntegrationTests
    {
        private Checkout _checkout;

        [SetUp]
        public void Setup()
        {
            var rules = new List<IPricingRule>
            {
                new UnitPriceRule("C", 20),
                new UnitPriceRule("D", 15),

                new MultiPriceRule("A", 50, 3, 130, startDate: new DateTime(2025, 8, 18), endDate: new DateTime(2025, 8, 25)), // one week only),

                new MultiPriceRule("B", 30, 2, 45, startDate: new DateTime(2025, 8, 18), endDate: new DateTime(2025, 8, 25)),

                //new BuyOneGetOneFreeRule("E", 40)
            };

            _checkout = new Checkout(rules);
        }

        [TestCase("A", 50)]
        [TestCase("AAA", 130)]   // special rule
        [TestCase("BB", 45)]     // special rule
        [TestCase("C", 20)]
        [TestCase("D", 15)]

        //[TestCase("EE", 40)]     // BOGOF
        //[TestCase("EEEEE", 120)] // pay for 3, 2 free

        [TestCase("ABACB", 175)] // mixed: 3 A’s = 130 + 2 B’s = 45
        public void CalculatesBasketCorrectly(string basket, int expectedTotal)
        {
            foreach (var sku in basket)
                _checkout.Scan(sku.ToString());

            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expectedTotal));
        }
    }
}
