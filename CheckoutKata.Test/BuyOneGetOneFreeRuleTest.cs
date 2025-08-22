using NUnit.Framework;
using CheckoutKata;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class BuyOneGetOneFreeRuleTests
    {
        [TestCase(1, 40)]
        [TestCase(2, 40)]   // second free
        [TestCase(3, 80)]   // pay for 2, 1 free
        [TestCase(4, 80)]   // pay for 2, 2 free
        [TestCase(5, 120)]  // pay for 3, 2 free
        public void CalculatesCorrectPrice(int quantity, int expectedTotal)
        {
            var rule = new BuyOneGetOneFreeRule("E", 40);

            var total = rule.CalculatePrice(quantity);

            Assert.That(total, Is.EqualTo(expectedTotal));
        }
    }
}
